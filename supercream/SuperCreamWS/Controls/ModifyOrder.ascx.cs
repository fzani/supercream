using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using WcfFoundationService;
using AjaxControlToolkit;
using SP.Core.Enums;

public partial class Controls_ModifyOrder : System.Web.UI.UserControl
{
    #region Private Member Variables
    EventHandler<EventArgs> ChangeState;

    decimal priceTotal = 0;
    #endregion

    #region Public Event Handlers
    public event ErrorMessageEventHandler ErrorMessageEventHandler;
    public event PurchaseOrderEventHandler PurchaseOrderHandler;
    //   public event CancelEventHandler CancelHandler;
    #endregion

    #region Public Accesors
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

    public OrderStatus OrderStatus
    {
        get
        {
            return (ViewState["OrderState"] == null) ? OrderStatus.Order : (OrderStatus)ViewState["OrderState"];
        }
        set
        {
            ViewState["OrderState"] = value;
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

    #endregion

    #region Page Load Events
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ChangeState += new EventHandler<EventArgs>(PageLoadState);
            ChangeState(this, e);
        }

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

        OrderHeaderSearchGridPanel.Visible = true;

        OrderHeaderPanel.Visible = false;
        OrderSearchPanel.Visible = true;
        ProductSearchPanel.Visible = false;
        OrderDetailsGridPanel.Visible = false;
        AddOrderDetailsPanel.Visible = false;

        AddOrderLineButton.Visible = false;
        CalculateButton.Visible = true;
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

    #region Data Grid Events
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            GridViewRow drv = e.Row.DataItem as GridViewRow;
            //if (drv != null)
            //{
            OrderHeader orderHeader = e.Row.DataItem as OrderHeader;

            int customerID = orderHeader.CustomerID;

            CustomerUI ui = new CustomerUI();
            Customer customer = ui.GetByID(customerID);

            Label customerNameLabel = e.Row.FindControl("CustomerNameLabel") as Label;
            customerNameLabel.Text = customer.Name;

            OrderHeaderUI headerUI = new OrderHeaderUI();
            OrderHeader header = new OrderHeader();
            header = headerUI.GetById(orderHeader.ID);

            Label statusNameLabel = e.Row.FindControl("StatusNameLabel") as Label;
            if (header.OrderStatus == (short)SP.Core.Enums.OrderStatus.Invoice ||
                   header.OrderStatus == (short)SP.Core.Enums.OrderStatus.InvoicePrinted)
            {
                statusNameLabel.Text = "Invoice";
            }
            else if (header.OrderStatus == (short)SP.Core.Enums.OrderStatus.DeliveryNote ||
                   header.OrderStatus == (short)SP.Core.Enums.OrderStatus.DeliveryNotePrinted)
            {
                statusNameLabel.Text = "Delivery Note";
            }
            else if (header.OrderStatus == (short)SP.Core.Enums.OrderStatus.ProformaInvoice ||
                   header.OrderStatus == (short)SP.Core.Enums.OrderStatus.PoformaInvoicePrinted)
            {
                statusNameLabel.Text = "Invoice Proforma";
            }
        }
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            int id = Convert.ToInt32(e.CommandArgument);

            OrderHeaderUI orderHeaderUI = new OrderHeaderUI();
            OrderHeader orderHeader = orderHeaderUI.GetById(id);

            OrderID = orderHeader.ID;

            int customerID = orderHeader.CustomerID;

            CustomerUI customerUI = new CustomerUI();
            Customer customer = customerUI.GetByID(customerID);

            CustomerDropDownList.DataSource = customerUI.GetAll();
            CustomerDropDownList.DataBind();
            CustomerDropDownList.SelectedValue = customer.ID.ToString();

            OrderNoHeaderLabel.Text = orderHeader.AlphaID;
            OrderDateTextBox.Text = orderHeader.OrderDate.ToShortDateString();
            DeliveryDateTextBox.Text = orderHeader.DeliveryDate.ToShortDateString();

            this.OrderHeaderSpecialInstructionsTextBox.Text = orderHeader.SpecialInstructions;

            #region Order Statuses
            if (orderHeader.OrderStatus == (short)SP.Core.Enums.OrderStatus.Invoice)
            {
                OrderStatusTypeLabel.Text = "<h3>Status : <i>Invoiced</i></h3";
                OrderStatusNoLabel.Text = "<h3><i>Invoice No: " + orderHeader.InvoiceNo + "</i></h3>";
                OrderStatusTypeLabel.Visible = true;
                OrderStatusNoLabel.Visible = true;
            }
            else if (orderHeader.OrderStatus == (short)SP.Core.Enums.OrderStatus.InvoicePrinted)
            {
                OrderStatusTypeLabel.Text = "<h3>Status : <i>Invoice Printed</i></h3";
                OrderStatusNoLabel.Text = "<h3><i>Invoice No: " + orderHeader.InvoiceNo + "</i></h3>";
                OrderStatusTypeLabel.Visible = true;
                OrderStatusNoLabel.Visible = true;
            }
            else if (orderHeader.OrderStatus == (short)SP.Core.Enums.OrderStatus.ProformaInvoice)
            {
                OrderStatusTypeLabel.Text = "<h3>Status : <i>Invoiced Proforma</i></h3";
                OrderStatusTypeLabel.Visible = true;
                OrderStatusNoLabel.Visible = false;
            }
            else if (orderHeader.OrderStatus == (short)SP.Core.Enums.OrderStatus.InvoicePrinted)
            {
                OrderStatusTypeLabel.Text = "<h3>Status : <i>Invoice Proforma Printed</i></h3";
                OrderStatusTypeLabel.Visible = true;
                OrderStatusNoLabel.Visible = false;
            }
            else if (orderHeader.OrderStatus == (short)SP.Core.Enums.OrderStatus.DeliveryNote)
            {
                OrderStatusTypeLabel.Text = "<h3>Status : <i>Note Produced</i></h3";
                OrderStatusNoLabel.Text = "<h3><i>Delivery Note: " + orderHeader.DeliveryNoteNo + "</i></h3>";

                OrderStatusTypeLabel.Visible = true;
                OrderStatusNoLabel.Visible = true;
            }
            else if (orderHeader.OrderStatus == (short)SP.Core.Enums.OrderStatus.DeliveryNotePrinted)
            {
                OrderStatusTypeLabel.Text = "<h3>Status : <i>Note Produced</i></h3";
                OrderStatusTypeLabel.Visible = true;
                OrderStatusNoLabel.Visible = false;
            }
            else
            {
                OrderStatusTypeLabel.Visible = false;
                OrderStatusNoLabel.Visible = false;
            }
            #endregion

            #region Visibility on Buttons
            if (orderHeader.OrderStatus == (short)SP.Core.Enums.OrderStatus.Order)
            {
                CreateInvoiceButton.Visible = true;
                CreateProformaInvoiceButton.Visible = true;
                CreateDeliveryNoteButton.Visible = true;
                ConvertToInvoiceButton.Visible = false;
            }
            else if (orderHeader.OrderStatus == (short)SP.Core.Enums.OrderStatus.Invoice
                || orderHeader.OrderStatus == (short)SP.Core.Enums.OrderStatus.InvoicePrinted)
            {
                CreateInvoiceButton.Visible = false;
                CreateProformaInvoiceButton.Visible = false;
                CreateDeliveryNoteButton.Visible = false;
                ConvertToInvoiceButton.Visible = false;
            }

            else if (orderHeader.OrderStatus == (short)SP.Core.Enums.OrderStatus.ProformaInvoice
                || orderHeader.OrderStatus == (short)SP.Core.Enums.OrderStatus.PoformaInvoicePrinted)
            {
                CreateInvoiceButton.Visible = false;
                CreateProformaInvoiceButton.Visible = false;
                CreateDeliveryNoteButton.Visible = false;
                ConvertToInvoiceButton.Visible = true;
            }
            else if (orderHeader.OrderStatus == (short)SP.Core.Enums.OrderStatus.DeliveryNotePrinted
                || orderHeader.OrderStatus == (short)SP.Core.Enums.OrderStatus.DeliveryNote)
            {
                CreateInvoiceButton.Visible = false;
                CreateProformaInvoiceButton.Visible = false;
                CreateDeliveryNoteButton.Visible = false;
                ConvertToInvoiceButton.Visible = true;
            }
            #endregion

            ChangeState += new EventHandler<EventArgs>(SelectedOrderState);
            ChangeState(this, e);

            DataBind();
        }
    }

    protected void OrderDetailsGridPanel_RowDataBound(object sender, GridViewRowEventArgs e)
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
            Label priceLabel = (Label)e.Row.FindControl("priceLabelTotal");
            priceLabel.Text = priceTotal.ToString("c");
        }
    }

    protected void OrderDetailsGridPanel_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("Select"))
        {
            Int32 index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = this.OrderDetailsGridView.Rows[index];

            Label idLabel = row.FindControl("IDLabel") as Label;

            OrderLineUI orderLineUI = new OrderLineUI();
            OrderLine orderLine = orderLineUI.GetOrderLine(Convert.ToInt32(idLabel.Text));
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

    #region General Event Handlers

    protected void OrderStatusDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        OrderHeaderSearchGridPanel.DataBind();
    }

    protected void CancelOrderDetailsButton_Click(object sender, EventArgs e)
    {
        ChangeState += new EventHandler<EventArgs>(InitLoadState);
        ChangeState(this, e);
    }

    protected void DeleteOrderButton_Click(object sender, EventArgs e)
    {
        try
        {
            if (OrderID != -1 || OrderID != null)
            {
                OrderHeaderUI ui = new OrderHeaderUI();
                ui.DeleteOrderHeader(OrderID.Value);

                ChangeState += new EventHandler<EventArgs>(InitLoadState);
                ChangeState(this, e);
            }
        }
        catch (Exception ex)
        {
            ErrorMessageEventArgs args = new ErrorMessageEventArgs();
            args.AddErrorMessages(ex.Message);
            ErrorMessageEventHandler(this, args);
        }
    }

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
            if (!float.TryParse(discountTextBox.Text, out discount))
                throw new ApplicationException("discount must be a number");

            int noOfUnits;
            if (!int.TryParse(noOfUnitsTextBox.Text, out noOfUnits))
                throw new ApplicationException("no of units must be a number");

            Decimal price;
            if (!decimal.TryParse(priceTextBox.Text, System.Globalization.NumberStyles.Currency, null, out price))
                throw new ApplicationException("price must be a number");

            int qtyPerUnit;
            if (!int.TryParse(qtyTextBox.Text, out qtyPerUnit))
                throw new ApplicationException("qty per unit must be a number");

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

            OrderLineUI ui = new OrderLineUI();
            ui.Update(line);
            DataBind();

        }
        catch (Exception ex)
        {
            ErrorMessageEventArgs args = new ErrorMessageEventArgs();
            args.AddErrorMessages(ex.Message);
            ErrorMessageEventHandler(this, args);
        }
    }

    protected void DeleteButton_Click(object sender, EventArgs e)
    {
        try
        {
            OrderLineUI ui = new OrderLineUI();
            Button btn = sender as Button;
            if (btn.CommandName == "DeleteButton")
                ui.DeleteOrderLine(Convert.ToInt32(btn.CommandArgument));
            DataBind();
        }
        catch (Exception ex)
        {
            ErrorMessageEventArgs args = new ErrorMessageEventArgs();
            args.AddErrorMessages(ex.Message);
            ErrorMessageEventHandler(this, args);
        }
    }

    protected void CompleteOrderButton_Click(object sender, EventArgs e)
    {
        try
        {
            OrderHeaderUI ui = new OrderHeaderUI();
            OrderHeader oh = new OrderHeader
            {
                ID = this.OrderID.Value,
                OrderDate = Convert.ToDateTime(this.OrderDateTextBox.Text),
                OrderStatus = (short)SP.Core.Enums.OrderStatus.Order,
                AlphaID = this.OrderNoHeaderLabel.Text,
                SpecialInstructions = OrderHeaderSpecialInstructionsTextBox.Text
            };

            OrderHeader existingOrderHeader = ui.GetByOrderNo(OrderNoHeaderLabel.Text);
            if (existingOrderHeader.ID != this.OrderID.Value)
                throw new ApplicationException("Cannot Modify Order - Order No Exists for an existing Order");

            ui.Update(oh);

            ChangeState += new EventHandler<EventArgs>(CompleteOrderState);
            ChangeState(this, e);
            this.Visible = false;
        }
        catch (Exception ex)
        {
            ErrorMessageEventArgs arg = new ErrorMessageEventArgs();
            arg.AddErrorMessages(ex.Message);
            ErrorMessageEventHandler(this, arg);
        }
    }

    protected void Modify_OrderLineDetailsLinkButton_Click(object sender, EventArgs e)
    {
        ChangeState += new EventHandler<EventArgs>(this.ModifyOrderLineState);
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

            OrderHeaderUI orderHeaderUI = new OrderHeaderUI();
            OrderHeader header = orderHeaderUI.GetById(this.OrderID.Value);

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
                    Discount = discount,
                    SpecialInstructions = SpecialInstructionsTextBox.Text,
                    OrderLineStatus = (short)header.OrderStatus,
                };

                ui.Save(orderLine);

                CompleteOrderButton.Visible = true;

                DataBind();
            }
            ChangeState += new EventHandler<EventArgs>(AddOrderLineOrderState);
            ChangeState(this, e);
        }
        catch (Exception ex)
        {
            ErrorMessageEventArgs args = new ErrorMessageEventArgs();
            args.AddErrorMessages(ex.Message);
            ErrorMessageEventHandler(this, args);
        }
    }

    protected void CancelProductAddButton_Click(object sender, EventArgs e)
    {
        ChangeState += new EventHandler<EventArgs>(this.ModifyOrderLineState);
        ChangeState(this, e);
    }

    protected void CancelButton_Click(object sender, EventArgs e)
    {
        ChangeState += new EventHandler<EventArgs>(InitOrderState);
        ChangeState(this, e);
    }

    protected void SearchButton_Click(object sender, EventArgs e)
    {
        OrderHeaderSearchGridPanel.DataBind();
    }

    protected void ClearButton_Click(object sender, EventArgs e)
    {
        Util.ClearControls(OrderSearchPanel);
        DataBind();
    }

    protected void ShowInvoiceProformaButton_Click(object sender, EventArgs e)
    {
        Panel p = OrderHeaderPanel.FindControl("PanelMessage") as Panel;
        TextBox invTextBox = p.FindControl("InvoiceNoTextBox") as TextBox;
        AutoGenUI ui = new AutoGenUI();
        invTextBox.Text = "INV-" + (ui.Generate() + 256).ToString();

        this.OrderStatus = OrderStatus.ProformaInvoice;

        ModalPopupExtenderInvoice.Show();
    }

    protected void CreateInvoiceButton_Click(object sender, EventArgs e)
    {
        try
        {
            this.OrderStatus = OrderStatus.Invoice;

            OrderHeaderUI ui = new OrderHeaderUI();
            string invoiceNo = ui.CreateInvoice(OrderID.Value, InvoiceNoTextBox.Text, OrderStatus);

            OrderStatusTypeLabel.Text = "<h3>Status : <i>Invoiced</i></h3";
            OrderStatusNoLabel.Text = "<h3><i>Invoice No: " + invoiceNo + "</i></h3>";
            OrderStatusTypeLabel.Visible = true;
            OrderStatusNoLabel.Visible = true;

            CreateInvoiceButton.Visible = false;
            CreateProformaInvoiceButton.Visible = false;
            CreateDeliveryNoteButton.Visible = false;

            ChangeState += new EventHandler<EventArgs>(CompleteOrderState);
            ChangeState(this, e);
            DataBind();
        }
        catch (Exception ex)
        {
            ErrorMessageEventArgs args = new ErrorMessageEventArgs();
            args.AddErrorMessages(ex.Message);
            ErrorMessageEventHandler(this, args);
        }
    }

    protected void CreateDeliveryNoteButton_Click(object sender, EventArgs e)
    {
        try
        {
            this.OrderStatus = OrderStatus.DeliveryNote;

            OrderHeaderUI ui = new OrderHeaderUI();
            string deliveryNoteNo = ui.CreateDeliveryNote(OrderID.Value, InvoiceNoTextBox.Text, OrderStatus);

            OrderStatusTypeLabel.Text = "<h3>Status : <i>Delivery Note Produced</i></h3";
            OrderStatusNoLabel.Text = "<h3><i>Delivery Note: " + deliveryNoteNo + "</i></h3>";
            OrderStatusTypeLabel.Visible = true;
            OrderStatusNoLabel.Visible = true;

            CreateInvoiceButton.Visible = false;
            CreateProformaInvoiceButton.Visible = false;
            CreateDeliveryNoteButton.Visible = false;

            ChangeState += new EventHandler<EventArgs>(CompleteOrderState);
            ChangeState(this, e);
            DataBind();
        }
        catch (Exception ex)
        {
            ErrorMessageEventArgs args = new ErrorMessageEventArgs();
            args.AddErrorMessages(ex.Message);
            ErrorMessageEventHandler(this, args);
        }
    }

    protected void ConvertToInvoiceButton_Click(object sender, EventArgs e)
    {
        try
        {
            OrderHeaderUI ui = new OrderHeaderUI();

            string invoiceNo = ui.UpdateToInvoice(OrderID.Value);

            OrderNotesStatusUI orderNotesStatusUI = new OrderNotesStatusUI();
            if (orderNotesStatusUI.OrderNoteExistsByOrderID(OrderID.Value))
            {
                OrderNotesStatus orderNotesStatus = orderNotesStatusUI.GetOrderNotesStatusByOrderID(OrderID.Value);
                orderNotesStatus.InvoiceDateCreated = DateTime.Now;
                orderNotesStatusUI.Update(orderNotesStatus);
            }

            OrderStatusTypeLabel.Text = "<h3>Status : <i>Invoiced</i></h3";
            OrderStatusNoLabel.Text = "<h3><i>Invoice No: " + invoiceNo + "</i></h3>";
            OrderStatusTypeLabel.Visible = true;
            OrderStatusNoLabel.Visible = true;

            CreateInvoiceButton.Visible = false;
            CreateProformaInvoiceButton.Visible = false;
            CreateDeliveryNoteButton.Visible = false;

            ChangeState += new EventHandler<EventArgs>(CompleteOrderState);
            ChangeState(this, e);
            DataBind();
        }
        catch (Exception ex)
        {
            ErrorMessageEventArgs args = new ErrorMessageEventArgs();
            args.AddErrorMessages(ex.Message);
            ErrorMessageEventHandler(this, args);
        }
    }

    protected void CreateProformaInvoiceButton_Click(object sender, EventArgs e)
    {

    }

    protected void CalculateButton_Click(object sender, EventArgs e)
    {
        Calculate();
    }

    #endregion

    #region Object Data Source Events

    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        e.InputParameters[0] = OrderID;
    }

    protected void OrderLineObjectDataSource_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        e.InputParameters[0] = OrderNoSearchTextBox.Text;
        e.InputParameters[1] = String.Empty;
        e.InputParameters[2] = CustomerNameSearchTextBox.Text;
        if (!String.IsNullOrEmpty(DateFromTextBox.Text))
            e.InputParameters[3] = Convert.ToDateTime(DateFromTextBox.Text);
        else
            e.InputParameters[3] = String.Empty;

        if (!String.IsNullOrEmpty(DateToTextBox.Text))
            e.InputParameters[4] = Convert.ToDateTime(DateToTextBox.Text);
        else
            e.InputParameters[4] = String.Empty;
        e.InputParameters[5] = Convert.ToInt16(OrderStatusDropDownList.SelectedValue);
    }

    #endregion

    #region Page States

    public void PageLoadState(object sender, EventArgs args)
    {
        OrderHeaderSearchGridPanel.Visible = true;

        OrderHeaderPanel.Visible = false;
        OrderSearchPanel.Visible = true;
        ProductSearchPanel.Visible = false;
        OrderDetailsGridPanel.Visible = false;
        AddOrderDetailsPanel.Visible = false;
        OrderHeaderSearchGridPanel.Visible = true;

        AddOrderLineButton.Visible = false;
        CalculateButton.Visible = true;

        CompleteOrderButtonPanel.Visible = false;
    }

    public void InitLoadState(object sender, EventArgs args)
    {
        Util.ClearControls(this);
        OrderHeaderPanel.Visible = false;
        OrderSearchPanel.Visible = true;
        ProductSearchPanel.Visible = false;
        OrderDetailsGridPanel.Visible = true;
        AddOrderDetailsPanel.Visible = false;
        OrderHeaderSearchGridPanel.Visible = true;

        AddOrderLineButton.Visible = false;
        CalculateButton.Visible = true;

        CompleteOrderButtonPanel.Visible = false;

        this.Visible = false;
    }

    public void AddProductLineState(object sender, EventArgs args)
    {
        //  Util.ClearControls(this);
        OrderHeaderSearchGridPanel.Visible = true;
        OrderSearchPanel.Visible = true;

        OrderHeaderPanel.Visible = true;
        ProductSearchPanel.Visible = true;

        AddOrderLineButton.Visible = false;
        CalculateButton.Visible = true;
        AddOrderDetailsPanel.Visible = false;
        OrderDetailsGridPanel.Visible = false;

        CompleteOrderButtonPanel.Visible = false;

        // this.Visible = false;
    }

    public void InitOrderState(object sender, EventArgs args)
    {
        OrderHeaderSearchGridPanel.Visible = true;
        OrderSearchPanel.Visible = true;
        ProductSearchPanel.Visible = false;

        OrderHeaderPanel.Visible = false;
        AddOrderDetailsPanel.Visible = false;

        ContinueCheckBox.Checked = false;
        CalculateButton.Visible = false;
        AddOrderLineButton.Visible = false;
        OrderDetailsGridPanel.Visible = false;

        CompleteOrderButtonPanel.Visible = false;

        SpecialInstructionsCheckBox.Checked = false;
    }

    public void AddOrderLineOrderState(object sender, EventArgs args)
    {
        ProductSearchPanel.Visible = true;
        CalculateButton.Visible = true;
        CompleteOrderButtonPanel.Visible = true;
        OrderDetailsGridPanel.Visible = true;

        OrderSearchPanel.Visible = false;
        OrderHeaderSearchGridPanel.Visible = false;
        AddOrderDetailsPanel.Visible = false;
        OrderHeaderPanel.Visible = false;
        ContinueCheckBox.Checked = false;

        AddOrderLineButton.Visible = false;

        SpecialInstructionsCheckBox.Checked = false;
    }

    public void AddOrderState(object sender, EventArgs args)
    {
        OrderHeaderSearchGridPanel.Visible = false;
        CompleteOrderButtonPanel.Visible = true;
        CalculateButton.Visible = true;
        AddOrderDetailsPanel.Visible = true;

        OrderSearchPanel.Visible = false;
        ProductSearchPanel.Visible = false;
        OrderHeaderPanel.Visible = false;
        ContinueCheckBox.Checked = false;
        OrderDetailsGridPanel.Visible = false;

        AddOrderLineButton.Visible = false;
    }

    public void SelectedOrderState(object sender, EventArgs args)
    {
        OrderSearchPanel.Visible = false;
        OrderHeaderSearchGridPanel.Visible = false;

        AddOrderDetailsPanel.Visible = false;
        OrderDetailsGridPanel.Visible = false;
        ProductSearchPanel.Visible = false;

        AddOrderLineButton.Visible = false;
        CalculateButton.Visible = false;

        OrderHeaderPanel.Visible = true;
        CompleteOrderButtonPanel.Visible = true;
    }

    public void ModifyOrderLineState(object sender, EventArgs args)
    {
        OrderSearchPanel.Visible = false;
        OrderHeaderSearchGridPanel.Visible = false;

        OrderHeaderPanel.Visible = false;

        AddOrderDetailsPanel.Visible = false;

        ProductSearchPanel.Visible = true;
        OrderDetailsGridPanel.Visible = true;

        AddOrderLineButton.Visible = false;
        CalculateButton.Visible = false;
        CompleteOrderButtonPanel.Visible = true;
    }

    public void CompleteOrderState(object sender, EventArgs args)
    {
        OrderHeaderPanel.Visible = false;
        OrderSearchPanel.Visible = true;

        ProductSearchPanel.Visible = false;
        OrderDetailsGridPanel.Visible = false;
        OrderHeaderSearchGridPanel.Visible = true;
        AddOrderDetailsPanel.Visible = false;

        AddOrderLineButton.Visible = false;
        CalculateButton.Visible = true;
        CompleteOrderButtonPanel.Visible = false;
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
    #endregion
}
