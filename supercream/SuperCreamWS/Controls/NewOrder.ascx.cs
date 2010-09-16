using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SP.Core.Enums;

using AjaxControlToolkit;

using WcfFoundationService;

public partial class Controls_NewOrder : System.Web.UI.UserControl
{
    #region Private Member Variables
    EventHandler<EventArgs> ChangeState;

    decimal priceTotal = 0;
    #endregion

    #region public Event Handlers
    public event ErrorMessageEventHandler ProductSearchError;
    public event PurchaseOrderEventHandler PurchaseOrderHandler;
    public event CancelEventHandler CancelHandler;
    #endregion

    #region public Accesors
    public int? OrderID
    {
        get
        {
            return (ViewState["OrderID"] == null) ? -1 : (int)ViewState["OrderID"];
        }
        set
        {
            ViewState["OrderID"] = value;
        }
    }

    public string AlphaID
    {
        get
        {
            return ViewState["AlphaID"] as string;
        }
        set
        {
            ViewState["AlphaID"] = value;
            OrderNoLabel.Text = value;
        }
    }

    public int? ProductID
    {
        get
        {
            return (ViewState["ProductID"] == null) ? -1 : (int)ViewState["ProductID"];
        }
        set
        {
            ViewState["ProductID"] = value;
        }
    }

    public DateTime OrderDate
    {
        set
        {
            OrderDateTextBox.Text = value.ToShortDateString();
        }
    }

    #endregion

    #region Page Load event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CustomerUI customerUI = new CustomerUI();
            List<Customer> customerList = customerUI.GetAll();

            CustomerDropDownList.Items.Add(new ListItem("-- Not Selected --", "-1"));
            foreach (Customer cs in customerList)
            {
                CustomerDropDownList.Items.Add(new ListItem(cs.Account + " " + cs.Name, cs.ID.ToString()));
            }
            OrderDateTextBox.Text = DateTime.Now.ToShortDateString();
            DeliveryDateTextBox.Text = DateTime.Now.AddDays(1).ToShortDateString();
        }
        else
            SpecialInstructionsTextBox.Visible = false;

        ProductSearch.ProductSearchError += ProductSearch_Error;
        ProductSearch.PurchaseOrderHandler += ProductSearch_Selected;
    }
    #endregion

    #region Public Methods
    public void AddOrderDetails(int productID)
    {
        AddOrderDetailsPanel.Visible = true;

        ProductUI productUI = new ProductUI();
        Product product = productUI.GetProductByID(productID);

        CustomerUI customerUI = new CustomerUI();
        Customer customer = customerUI.GetByID(Convert.ToInt32(CustomerDropDownList.SelectedValue));

        ProductCodeLabel.Text = product.ProductCode;
        ProductDescriptionLabel.Text = product.Description;
        QtyPerUnitLabel.Text = product.UnitQty.ToString();
        RRPLabel.Text = String.Format("{0:c}", product.RRPPerItem);
        ProductPriceLabel.Text = String.Format("{0:c}", product.UnitPrice);
        NoOfUnitsTextBox.Text = "1";

        PriceListItemUI priceListItemUI = new PriceListItemUI();
        PriceListItem priceListItem = priceListItemUI.GetPriceListItemByProductID(customer.PriceListHeaderID, product.ID);

        if (priceListItem.ProductID == null)
        {
            ViewState["PriceListItem"] = null;
            PriceListDiscountLabel.Text = String.Empty;
            PriceDiscountNameLabel.Visible = false;
            PriceListDiscountLabel.Visible = false;

            PriceListDefined.Visible = true;
            PriceListDefined.Text = "<i>Please note :-Price List Item not defined for this item</i>";

            TotalPriceLabel.Visible = true;

            Decimal originalPrice = Decimal.Parse(ProductPriceLabel.Text, System.Globalization.NumberStyles.Currency);
            PriceTextBox.Text = String.Format("{0:c}", originalPrice);
            TotalPriceValueLabel.Text = String.Format("{0:c}", originalPrice);
        }
        else
        {
            ViewState["PriceListItem"] = priceListItem;
            PriceDiscountNameLabel.Text = "Price List Discount";
            PriceDiscountNameLabel.Visible = true;

            PriceListDefined.Visible = false;
            PriceListDiscountLabel.Visible = true;
            PriceListDiscountLabel.Text = priceListItem.Discount.ToString();
            PriceListDiscountLabel.Text += '%';

            //NewUnitPriceNameLabel.Visible = true;
            //NewUnitPriceLabel.Visible = true;
            //NewUnitPriceNameLabel.Text = "<i>New Unit Price</i>";

            Decimal originalPrice = Decimal.Parse(ProductPriceLabel.Text, System.Globalization.NumberStyles.Currency);
            Decimal discount = Convert.ToDecimal(PriceListDiscountLabel.Text.Substring(0, (PriceListDiscountLabel.Text.Length - 1)));
            Decimal tmp = (originalPrice / 100) * discount;

            TotalPriceLabel.Visible = true;
            TotalPriceValueLabel.Text = String.Format("{0:c}", Math.Round((originalPrice - tmp), 2));

            decimal val = Math.Round((originalPrice - tmp), 2);
            PriceTextBox.Text = String.Format("{0:c}", val);
        }
    }

    public void Reset()
    {
        Util.ClearControls(this);

        OrderHeaderPanel.Visible = true;
        OrderDateTextBox.Text = DateTime.Now.ToShortDateString();
        DeliveryDateTextBox.Text = DateTime.Now.AddDays(1).ToShortDateString();

        ProductSearchPanel.Visible = false;
        AddOrderDetailsPanel.Visible = false;
        ContinueCheckBox.Checked = false;

        OrderNoLabel.Text = "<>";

        CalculateButton.Visible = true;
        AddOrderLineButton.Visible = false;

        SpecialInstructionsCheckBox.Checked = false;
    }

    #endregion

    #region Button Handlers
    protected void AddOrderDetailsButton_Click(object sender, EventArgs e)
    {
        try
        {
            using (OrderHeaderUI ui = new OrderHeaderUI())
            {
                StandardVatCodeUI standardVatCodeUI = new StandardVatCodeUI();
                StandardVatRate standardVatRate = standardVatCodeUI.GetStandardVatCode();

                VatCodeUI vatCodeUI = new VatCodeUI();
                VatCode vatCode = vatCodeUI.GetByID(standardVatRate.VatCodeID);

                OrderHeader orderHeader = new OrderHeader
                                              {
                                                  ID = 1,
                                                  CustomerID = Convert.ToInt32(CustomerDropDownList.SelectedValue),
                                                  OrderDate = Convert.ToDateTime(OrderDateTextBox.Text),
                                                  OrderStatus = (short)OrderStatus.Order,
                                                  DeliveryDate = Convert.ToDateTime(DeliveryDateTextBox.Text),
                                                  InvoiceDate = SP.Utils.Defaults.MinDateTime,
                                                  InvoiceProformaDate = SP.Utils.Defaults.MinDateTime,
                                                  SpecialInstructions = OrderHeaderSpecialInstructionsTextBox.Text,
                                                  VatCode = vatCode,
                                                  VatCodeID = vatCode.ID,
                                              };

                ValidateOrder(orderHeader);

                orderHeader = ui.Save(orderHeader);

                AuditEventsUI.LogEvent("Creating Order", orderHeader.AlphaID, Page.ToString(),
                                       AuditEventsUI.AuditEventType.Creating);

                OrderID = orderHeader.ID;
                this.OrderNoLabel.Text = orderHeader.AlphaID;
            }
            ChangeState += new EventHandler<EventArgs>(InitOrderState);
            ChangeState(this, e);
            // Set Alpha ID in View State
            AlphaID = OrderNoLabel.Text;
        }
        catch (Exception ex)
        {
            ErrorMessageEventArgs args = new ErrorMessageEventArgs();
            args.AddErrorMessages(ex.Message);
            ProductSearchError(this, args);
        }
    }

    protected void CancelButton_Click(object sender, EventArgs e)
    {
        ChangeState += new EventHandler<EventArgs>(InitOrderState);
        ChangeState(this, e);
    }

    protected void AddOrderLineButton_Click(object sender, EventArgs e)
    {
        try
        {
            Single discount = 0;

            if (!String.IsNullOrEmpty(PriceListDiscountLabel.Text))
            {
                string discountTmp = PriceListDiscountLabel.Text.Substring(0, PriceListDiscountLabel.Text.Length - 1);
                discount = (Single.TryParse(discountTmp, out discount)) ? Single.Parse(discountTmp) : 0;
            }

            ProductUI productUI = new ProductUI();
            using (OrderLineUI ui = new OrderLineUI())
            {
                OrderLine orderLine = new OrderLine
                {
                    ID = -1,
                    OrderID = this.OrderID.Value,
                    NoOfUnits = Convert.ToInt32(NoOfUnitsTextBox.Text),
                    QtyPerUnit = Convert.ToInt32(QtyPerUnitLabel.Text),
                    Price = Decimal.Parse(PriceTextBox.Text, System.Globalization.NumberStyles.Currency),
                    ProductID = this.ProductID.Value,
                    RRPPerItem = productUI.GetProductByID(this.ProductID.Value).RRPPerItem,
                    Discount = discount,
                    SpecialInstructions = SpecialInstructionsTextBox.Text,
                    OrderLineStatus = (short)SP.Core.Enums.OrderStatus.Order,
                };

                var product = GetProduct(orderLine.ProductID);

                AuditEventsUI.LogEvent("Creating Order Line", "Product: " + product.Description, Page.ToString(),
                                    AuditEventsUI.AuditEventType.Creating);
                OrderLineUI.Save(orderLine);

                DataBind();
            }
            ChangeState += new EventHandler<EventArgs>(InitOrderState);
            ChangeState(this, e);
        }
        catch (Exception ex)
        {
            ErrorMessageEventArgs args = new ErrorMessageEventArgs();
            args.AddErrorMessages(ex.Message);
            ProductSearchError(this, args);
        }
    }

    protected void CancelNewOrderButton_Click(object sender, EventArgs e)
    {
        if (OrderID.HasValue && OrderID.Value != -1)
        {
            OrderHeaderUI ui = new OrderHeaderUI();
            ui.DeleteOrderHeader(OrderID.Value);
        }

        AddOrderLineButton.Visible = false;
        ChangeState += new EventHandler<EventArgs>(CancelOrderState);
        ChangeState(this, e);
        CancelHandler(this, e);
    }

    protected void CancelPurchaseSearchButton_Click(object sender, EventArgs e)
    {
        Util.ClearControls(NewOrderPanel);
        ChangeState += new EventHandler<EventArgs>(CompleteOrderState);
        ChangeState(this, e);
        this.Visible = false;
    }

    protected void CompleteOrderButton_Click(object sender, EventArgs e)
    {
        Util.ClearControls(NewOrderPanel);
        ChangeState += new EventHandler<EventArgs>(CompleteOrderState);
        ChangeState(this, e);
        this.Visible = false;
    }

    protected void UpdateButton_Click(object sender, EventArgs e)
    {
        try
        {
            GridViewRow row = this.OrderDetailsGridView.Rows[OrderDetailsGridView.SelectedIndex];
            Panel messagePanel = row.FindControl("PanelMessage") as Panel;
            Label idLabel = row.FindControl("IDLabel") as Label;
            Label alphaIDLabel = messagePanel.FindControl("AlphaIDLabel") as Label;
            Label productNameLabel = messagePanel.FindControl("PanelProductNameLabel") as Label;
            Label productIDLabel = row.FindControl("ProductIDLabel") as Label;
            Label orderIDLabel = messagePanel.FindControl("OrderIDLabel") as Label;
            TextBox qtyTextBox = messagePanel.FindControl("QtyTextBox") as TextBox;
            TextBox noOfUnitsTextBox = messagePanel.FindControl("NoOfUnitsTextBox") as TextBox;
            TextBox discountTextBox = messagePanel.FindControl("DiscountTextBox") as TextBox;
            TextBox priceTextBox = messagePanel.FindControl("PriceTextBox") as TextBox;
            TextBox specialInstructionsTextBox = messagePanel.FindControl("SpecialInstructionsTextBox") as TextBox;

            int id = Convert.ToInt32(idLabel.Text);
            float discount;
            int noOfUnits;
            Decimal price;
            int qtyPerUnit;

            ValidateOrderLine(qtyTextBox, noOfUnitsTextBox, discountTextBox, priceTextBox, out discount, out noOfUnits, out price, out qtyPerUnit);

            string productName = productNameLabel.Text;
            int productID = Convert.ToInt32(productIDLabel.Text);

            OrderLine line = new OrderLine
            {
                ID = id,
                Discount = discount,
                OrderID = Convert.ToInt32(orderIDLabel.Text),
                NoOfUnits = noOfUnits,
                Price = price,
                ProductID = productID,
                OrderLineStatus = (short)SP.Core.Enums.OrderLineStatus.Open,
                QtyPerUnit = qtyPerUnit,
                SpecialInstructions = specialInstructionsTextBox.Text
            };

            AuditEventsUI.LogEvent("Updating Order Line", "Product: " + GetProduct(line.ProductID).Description, Page.ToString(),
                                 AuditEventsUI.AuditEventType.Modifying);

            OrderLineUI.Update(line);
            DataBind();

        }
        catch (Exception ex)
        {
            ErrorMessageEventArgs args = new ErrorMessageEventArgs();
            args.AddErrorMessages(ex.Message);
            ProductSearchError(this, args);
        }
    }

    protected void DeleteButton_Click(object sender, EventArgs e)
    {
        try
        {
            AuditEventsUI.LogEvent("Deleting Order Line", "line", Page.ToString(),
                                AuditEventsUI.AuditEventType.Deleting);

            Button btn = sender as Button;
            if (btn.CommandName == "DeleteButton")
                OrderLineUI.DeleteOrderLine(Convert.ToInt32(btn.CommandArgument));
            DataBind();
        }
        catch (Exception ex)
        {
            ErrorMessageEventArgs args = new ErrorMessageEventArgs();
            args.AddErrorMessages(ex.Message);
            ProductSearchError(this, args);
        }
    }

    protected void CalculateButton_Click(object sender, EventArgs e)
    {
        Calculate();
    }

    #endregion

    #region General Event Handlers

    protected void CustomerDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void PriceTextBox_TextChanged(object sender, EventArgs e)
    {

    }

    protected void NoOfUnitsTextBox_TextChanged(object sender, EventArgs e)
    {
        Calculate();
    }

    protected void ContinueCheckBox_CheckedChanged(object sender, EventArgs e)
    {
        if (ContinueCheckBox.Checked == true)
        {
            AddOrderLineButton.Visible = true;
            CalculateButton.Visible = false;
        }
        else
        {
            CalculateButton.Visible = true;
            AddOrderLineButton.Visible = false;
        }
    }

    protected void SpecialInstructionsCheckBox_CheckedChanged(object sender, EventArgs e)
    {
        if (SpecialInstructionsCheckBox.Checked == true)
            SpecialInstructionsTextBox.Visible = true;
        else
            SpecialInstructionsTextBox.Visible = false;
    }

    #endregion

    #region Error Handlers
    protected void ProductSearch_Error(object sender, ErrorMessageEventArgs e)
    {
        ProductSearchError(this, e);
    }
    #endregion

    #region Control Call Backs

    protected void ProductSearch_Selected(object sender, PurchaseOrderEventArgs e)
    {
        ProductID = e.PurchaseOrderID;

        Util.ClearControls(AddOrderDetailsPanel);

        AddOrderDetailsPanel.DataBind();

        AddOrderDetails(ProductID.Value);

        ChangeState += new EventHandler<EventArgs>(AddOrderState);
        ChangeState(this, e);
    }
    
    #endregion

    #region Page States

    public void CompleteOrderState(object sender, EventArgs args)
    {
        OrderHeaderPanel.Visible = true;
        AddOrderDetailsPanel.Visible = false;
        ProductSearchPanel.Visible = false;
        ContinueCheckBox.Checked = false;
        CalculateButton.Visible = true;
        AddOrderLineButton.Visible = false;

        SpecialInstructionsCheckBox.Checked = false;

        CancelPurchaseSearchPanel.Visible = false;
        OrderDetailsGridPanel.Visible = false;
    }

    public void InitOrderState(object sender, EventArgs args)
    {
        OrderHeaderPanel.Visible = false;
        AddOrderDetailsPanel.Visible = false;
        ProductSearchPanel.Visible = true;
        ContinueCheckBox.Checked = false;
        CalculateButton.Visible = true;
        AddOrderLineButton.Visible = false;

        SpecialInstructionsCheckBox.Checked = false;

        CancelPurchaseSearchPanel.Visible = true;


        if (OrderDetailsGridView.Rows.Count > 0)
        {
            OrderDetailsGridPanel.Visible = true;
        }
        else
        {
            OrderDetailsGridPanel.Visible = false;
        }
    }

    public void CancelOrderState(object sender, EventArgs args)
    {
        Util.ClearControls(this);

        OrderHeaderPanel.Visible = true;

        ProductSearchPanel.Visible = false;
        AddOrderDetailsPanel.Visible = false;
        ContinueCheckBox.Checked = false;

        CalculateButton.Visible = true;
        AddOrderLineButton.Visible = false;

        SpecialInstructionsCheckBox.Checked = false;

        CancelPurchaseSearchPanel.Visible = false;

        OrderDetailsGridPanel.Visible = false;
    }

    public void AddOrderState(object sender, EventArgs args)
    {
        OrderHeaderPanel.Visible = false;
        AddOrderDetailsPanel.Visible = false;
        AddOrderDetailsPanel.Visible = true;
        ProductSearchPanel.Visible = false;

        ContinueCheckBox.Checked = false;
        CalculateButton.Visible = true;
        AddOrderLineButton.Visible = false;
        CancelButton.Visible = true;

        CancelPurchaseSearchPanel.Visible = true;

        OrderDetailsGridPanel.Visible = false;
    }
    #endregion

    #region Object Data Source Events
    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        e.InputParameters[0] = OrderID;
    }
    #endregion

    #region Data Grid Events

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            GridViewRow drv = e.Row.DataItem as GridViewRow;
            OrderLine orderLine = e.Row.DataItem as OrderLine;

            decimal tempPrice = Math.Round(orderLine.Price * orderLine.NoOfUnits, 2);
            priceTotal += tempPrice;

            Label orderLinePriceLabel = e.Row.FindControl("OrderLinePriceLabel") as Label;
            orderLinePriceLabel.Text = String.Format("{0:c}", tempPrice);

            ProductUI productUI = new ProductUI();
            int? productID = DataBinder.Eval(e.Row.DataItem, "ProductID") as int?;

            Label productNameLabel = e.Row.FindControl("ProductNameLabel") as Label;
            Product product = productUI.GetProductByID(productID.Value);
            productNameLabel.Text = product.Description;

            Image img = e.Row.FindControl("SIImage") as Image;
            if (String.IsNullOrEmpty(orderLine.SpecialInstructions))
            {
                img.ImageUrl = "~/images/16-circle-green.png";
            }
            else
            {
                img.ImageUrl = "~/images/12-em-check.png";

            }
        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            if (this.OrderID != -1)
            {
                var exVatTotal = OrderHeaderUI.GetExVatTotal(this.OrderID.Value);
                Label priceLabel = (Label)e.Row.FindControl("priceLabelTotal");
                priceLabel.Text = exVatTotal.ToString("c");
            }
        }
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("Select"))
        {
            Int32 index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = this.OrderDetailsGridView.Rows[index];

            Label idLabel = row.FindControl("IDLabel") as Label;

            OrderLine orderLine = OrderLineUI.GetOrderLine(Convert.ToInt32(idLabel.Text));
            ProductUI productUI = new ProductUI();
            Product product = productUI.GetProductByID(orderLine.ProductID);

            Label productIDLabel = row.FindControl("ProductIDLabel") as Label;
            productIDLabel.Text = orderLine.ProductID.ToString();

            Label productNameLabel = row.FindControl("PanelProductNameLabel") as Label;
            productNameLabel.Text = product.Description;

            Label alphaIDLabel = row.FindControl("AlphaIDLabel") as Label;
            alphaIDLabel.Text = AlphaID;

            Label orderIDLabel = row.FindControl("OrderIDLabel") as Label;
            orderIDLabel.Text = orderLine.OrderID.ToString();

            TextBox qtyTextBox = row.FindControl("QtyTextBox") as TextBox;
            qtyTextBox.Text = orderLine.QtyPerUnit.ToString();

            TextBox noOfUnitsTextBox = row.FindControl("NoOfUnitsTextBox") as TextBox;
            noOfUnitsTextBox.Text = orderLine.NoOfUnits.ToString();

            TextBox discountTextBox = row.FindControl("DiscountTextBox") as TextBox;
            discountTextBox.Text = orderLine.Discount.ToString();

            TextBox priceTextBox = row.FindControl("PriceTextBox") as TextBox;
            priceTextBox.Text = String.Format("{0:c}", orderLine.Price);

            TextBox specialInstructionsTextBox = row.FindControl("SpecialInstructionsTextBox") as TextBox;
            specialInstructionsTextBox.Text = orderLine.SpecialInstructions;

            ModalPopupExtender extender = row.FindControl("ModalPopupExtender") as ModalPopupExtender;
            extender.Show();
        }
    }

    #endregion

    #region Private Methods

    private void Calculate()
    {
        if (PriceTextBox.Text == "0" || String.IsNullOrEmpty(PriceTextBox.Text))
        {
            int noOfUnits = Convert.ToInt32(NoOfUnitsTextBox.Text);
            Decimal val = Decimal.Parse(ProductPriceLabel.Text, System.Globalization.NumberStyles.Currency) * noOfUnits;

            TotalPriceValueLabel.Text = String.Format("{0:c}", Math.Round(val, 2));
            TotalPriceValueLabel.DataBind();
        }
        else
        {
            int noOfUnits = Convert.ToInt32(NoOfUnitsTextBox.Text);
            decimal val = decimal.Parse(PriceTextBox.Text, System.Globalization.NumberStyles.Currency) * noOfUnits;
            TotalPriceValueLabel.Text = String.Format("{0:c}", Math.Round(val, 2));
            TotalPriceValueLabel.DataBind();

            PriceListItem item = ViewState["PriceListItem"] as PriceListItem;
            if (item == null)
                return; // Not a Price list Item so no discount applies

            decimal currentPrice = decimal.Parse(PriceTextBox.Text, System.Globalization.NumberStyles.Currency);
            Decimal originalPrice = Decimal.Parse(ProductPriceLabel.Text, System.Globalization.NumberStyles.Currency);

            Decimal discount = item.Discount;
            Decimal tmp = (originalPrice / 100) * discount;

            Decimal newPrice = currentPrice + tmp;
            if (Math.Round(newPrice, 2) != Math.Round(originalPrice, 2))
            {
                PriceListDiscountLabel.Text = "0%";
            }
            else
            {

                PriceListDiscountLabel.Text = item.Discount.ToString() + '%';
            }
        }
    }

    private static void ValidateOrder(OrderHeader order)
    {
        if (order.DeliveryDate < order.OrderDate)
        {
            throw new ApplicationException("Delivery date cannot be prior to Order Date");
        }

        if (order.VatCode == null)
        {
            throw new ApplicationException("Order has not been assigned valid Vat No.");
        }
    }

    private static void ValidateOrderLine(TextBox qtyTextBox, TextBox noOfUnitsTextBox, TextBox discountTextBox, TextBox priceTextBox, out float discount, out int noOfUnits, out Decimal price, out int qtyPerUnit)
    {
        if (!float.TryParse(discountTextBox.Text, out discount))
            throw new ApplicationException("discount must be a number");


        if (!int.TryParse(noOfUnitsTextBox.Text, out noOfUnits))
            throw new ApplicationException("no of units must be a number");


        if (!decimal.TryParse(priceTextBox.Text, System.Globalization.NumberStyles.Currency, null, out price))
            throw new ApplicationException("price must be a number");


        if (!int.TryParse(qtyTextBox.Text, out qtyPerUnit))
            throw new ApplicationException("qty per unit must be a number");
    }

    private static Product GetProduct(int productId)
    {
        return new ProductUI().GetProductByID(productId);
    }

    #endregion
}