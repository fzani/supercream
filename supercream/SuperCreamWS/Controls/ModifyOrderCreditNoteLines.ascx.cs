using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using WcfFoundationService;
using AjaxControlToolkit;
using SP.Core.Enums;

public partial class Controls_ModifyOrderCreditNoteLines : System.Web.UI.UserControl
{
    #region Private Member Variables

    private decimal priceTotal;
    private decimal creditPriceTotal;

    #endregion

    #region Public Properties

    public int OrderID
    {
        get
        {
            return (int)ViewState["OrderID"];
        }

        set
        {
            ViewState["OrderID"] = value;
        }
    }

    public bool CreditNotePanelVisible
    {
        set
        {
            this.CreditLinesPanel.Visible = value;
        }
        get
        {
            return this.CreditLinesPanel.Visible;
        }
    }

    public int CreditNoteID
    {
        get
        {
            return (int)ViewState["CreditNoteID"];
        }

        set
        {
            ViewState["CreditNoteID"] = value;
        }
    }

    public string AlphaID
    {
        get
        {
            return ViewState["AlphaID"].ToString();
        }

        set
        {
            ViewState["AlphaID"] = value;
        }
    }

    public string Reference
    {
        get
        {
            if (ViewState["Reference"] == null)
            {
                return String.Empty;
            }
            else
            {
                return ViewState["Reference"].ToString();
            }
        }

        set
        {
            ViewState["Reference"] = value;
            if (!String.IsNullOrEmpty(value))
            {
                this.CreditNoteLabel.Text = this.Reference;
                this.CreditNoteLabel.DataBind();
            }
        }
    }

    public List<OrderLine> OrderLines
    {
        get;
        set;
    }

    #endregion

    #region Public Event Handlers

    public event ErrorMessageEventHandler ErrorMessageEventHandler;

    #endregion

    #region Page Load Event Handlers

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.OrderID = -1;
            this.CreditNoteID = -1;
        }      
    }

    #endregion

    #region GridView Event Handlers

    protected void OrderDetailsGridPanel_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // Dont forget to display an icon tick if existing credit notes apply for this order line.
            GridViewRow drv = e.Row.DataItem as GridViewRow;
            OrderLine orderLine = e.Row.DataItem as OrderLine;

            decimal tempPrice = Math.Round(orderLine.Price * orderLine.NoOfUnits, 2);
            priceTotal += tempPrice;

            Label orderLinePriceAfterDiscountLabel = e.Row.FindControl("OrderLinePriceAfterDiscountLabel") as Label;
            orderLinePriceAfterDiscountLabel.Text = Math.Round(orderLine.Price, 2).ToString();

            Label orderLinePriceLabel = e.Row.FindControl("OrderLinePriceLabel") as Label;
            orderLinePriceLabel.Text = String.Format("{0:c}", tempPrice);

            ProductUI productUI = new ProductUI();
            int? productID = DataBinder.Eval(e.Row.DataItem, "ProductID") as int?;

            Label productNameLabel = e.Row.FindControl("ProductNameLabel") as Label;
            Product product = productUI.GetProductByID(productID.Value);
            productNameLabel.Text = product.Description;

            Image img = e.Row.FindControl("CreditNoteExistsImage") as Image;
            if (OrderCreditNoteLineUI.CheckIfOrderLineAlreadyExistsForCreditNotes(orderLine.ID))
            {
                img.ImageUrl = "~/images/12-em-check.png";
                img.Visible = true;
                if (OrderCreditNoteLineUI.GetAvailableNoOfUnitsOnOrderLine(orderLine.ID) == 0)
                {
                    // all order lines have credit notes against them so do not allow to edit
                    var editImageButton = e.Row.FindControl("EditImage") as ImageButton;
                    editImageButton.Visible = false;
                }
                else
                {
                    var editImageButton = e.Row.FindControl("EditImage") as ImageButton;
                    editImageButton.Visible = true;
                }
            }
            else
            {
                img.ImageUrl = String.Empty;
                img.Visible = false;
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

            // To be done:- have to get available no of units to be added to credt note, note the number
            // of units must reflect any existing credit notes for this order line ....
            // done ...
            // suggest that order line does not show edit button if no of units is fully allocated.
            // to credit note lines.
            // done ...

            // also  indicate if existing credit notes have been placed against order line
            // done ...

            // Also suggest use cancel button to reverse credit note line (i.e remove it ...)

            OrderLine orderLine = OrderLineUI.GetOrderLine(Convert.ToInt32(idLabel.Text));
            ProductUI productUI = new ProductUI();
            Product product = productUI.GetProductByID(orderLine.ProductID);

            Panel panelMessage = row.FindControl("PanelMessage") as Panel;
            Label noOfUnitsLabel = row.FindControl("NoOfUnitsLabel") as Label;
            int qtyToCredit = OrderCreditNoteLineUI.GetAvailableNoOfUnitsOnOrderLine(orderLine.ID);

            DropDownList quantityToCreditDropDownList = panelMessage.FindControl("QuantityToCreditDropDownList") as DropDownList;
            quantityToCreditDropDownList.Items.Clear();
            for (int i = 0; i < qtyToCredit; i++)
            {
                quantityToCreditDropDownList.Items.Add(new ListItem((i + 1).ToString(), (i + 1).ToString()));
            }
            quantityToCreditDropDownList.SelectedValue = qtyToCredit.ToString();

            ModalPopupExtender extender = row.FindControl("ModalPopupExtender") as ModalPopupExtender;
            extender.Show();
        }
    }

    protected void UpdateOrderCreditLineButton_Click(object sender, EventArgs e)
    {
        Button button = sender as Button;

        int creditNoteLineId = Convert.ToInt32(this.CreditNoteLinesGridView.SelectedDataKey.Value);
        int credtNoteId = CreditNoteID;

        Int32 index = Convert.ToInt32(button.CommandArgument);
        GridViewRow row = this.CreditNoteLinesGridView.Rows[index];

        // First get no of units to add to credit note line.
        Panel panelMessage = row.FindControl("PanelMessage") as Panel;
        DropDownList quantityToCreditDropDownList = panelMessage.FindControl("QuantityToCreditDropDownList") as DropDownList;
        int selectedNoOfUnits = Convert.ToInt32(quantityToCreditDropDownList.SelectedValue.ToString());

        // Next create or updat credit note order Line           
        var orderLine = OrderCreditNoteLineUI.GetById(creditNoteLineId);
        if ((orderLine.NoOfUnits - selectedNoOfUnits) == 0)
        {
            OrderCreditNoteLineUI.DeleteOrderCreditNoteLine(creditNoteLineId);
        }
        else
        {
            OrderCreditNoteLine orderCreditNoteLine = OrderCreditNoteLineUI.GetCreditNoteLineByOrderIdAndOrderLineId(credtNoteId, orderLine.OrderLineID);
            orderCreditNoteLine.NoOfUnits -= selectedNoOfUnits;
            OrderCreditNoteLineUI.Update(orderCreditNoteLine);
        }

        this.DataBind();

    }

    protected void UpdateOrderLineButton_Click(object sender, EventArgs e)
    {
        try
        {
            Button button = sender as Button;

            int orderLineId = Convert.ToInt32(this.OrderDetailsGridView.SelectedDataKey.Value);
            int credtNoteId = CreditNoteID;

            Int32 index = Convert.ToInt32(button.CommandArgument);
            GridViewRow row = this.OrderDetailsGridView.Rows[index];
            OrderLine line = row.DataItem as OrderLine;

            // First get no of units to add to credit note line.
            Panel panelMessage = row.FindControl("PanelMessage") as Panel;
            DropDownList quantityToCreditDropDownList = panelMessage.FindControl("QuantityToCreditDropDownList") as DropDownList;
            int selectedNoOfUnits = Convert.ToInt32(quantityToCreditDropDownList.SelectedValue.ToString());

            // Next create or updat credit note order Line           
            var orderLine = OrderLineUI.GetOrderLine(orderLineId);

            OrderCreditNoteUI creditNoteUI = new OrderCreditNoteUI();
            InvoiceCreditNoteDetails invoiceCreditNoteDetails = creditNoteUI.GetInvoiceCreditNoteDetails(this.OrderID);
            // JC Here --------------------------------------------------------------------
            if (invoiceCreditNoteDetails.Balance - (selectedNoOfUnits * orderLine.Price) < 0)
            {
                throw new ApplicationException("Cannot add a Credit note that exceeds the value of Invoice");
            }

            if (OrderCreditNoteLineUI.CheckIfOrderCreditLineExists(credtNoteId, orderLineId))
            {
                OrderCreditNoteLine orderCreditNoteLine = OrderCreditNoteLineUI.GetCreditNoteLineByOrderIdAndOrderLineId(credtNoteId, orderLineId);
                orderCreditNoteLine.NoOfUnits += selectedNoOfUnits;
                OrderCreditNoteLineUI.Update(orderCreditNoteLine);
            }
            else
            {
                var orderCreditNoteLine = new OrderCreditNoteLine
                                              {
                                                  ID = -1,
                                                  OrderCreditNoteID = credtNoteId,
                                                  OrderLineID = orderLine.ID,
                                                  ProductID = orderLine.ProductID,
                                                  QtyPerUnit = orderLine.QtyPerUnit,
                                                  NoOfUnits = selectedNoOfUnits,
                                                  Discount = orderLine.Discount,
                                                  Price = orderLine.Price
                                              };
                OrderCreditNoteLineUI.SaveOrderCreditNoteLine(orderCreditNoteLine);
            }

            this.DataBind();
        }
        catch (Exception ex)
        {
            if (this.ErrorMessageEventHandler != null)
            {
                var errorMessageEventArgs = new ErrorMessageEventArgs();
                errorMessageEventArgs.AddErrorMessages(ex.Message);
                this.ErrorMessageEventHandler(this, errorMessageEventArgs);
            }
        }
    }

    protected void DeleteOrderCreditLineButton_Click(object sender, EventArgs e)
    {
        int creditNoteLineId = Convert.ToInt32(this.CreditNoteLinesGridView.SelectedDataKey.Value);
        OrderCreditNoteLineUI.DeleteOrderCreditNoteLine(creditNoteLineId);
        this.DataBind();
    }

    protected void CreditNoteLinesGridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // Dont forget to display an icon tick if existing credit notes apply for this order line.
            GridViewRow drv = e.Row.DataItem as GridViewRow;
            OrderCreditNoteLine orderLine = e.Row.DataItem as OrderCreditNoteLine;

            decimal tempPrice = Math.Round(orderLine.Price * orderLine.NoOfUnits, 2);
            creditPriceTotal += tempPrice;

            Label orderLinePriceAfterDiscountLabel = e.Row.FindControl("OrderLinePriceAfterDiscountLabel") as Label;
            orderLinePriceAfterDiscountLabel.Text = Math.Round(orderLine.Price, 2).ToString();

            Label orderLinePriceLabel = e.Row.FindControl("OrderLinePriceLabel") as Label;
            orderLinePriceLabel.Text = String.Format("{0:c}", tempPrice);

            ProductUI productUI = new ProductUI();
            int? productID = DataBinder.Eval(e.Row.DataItem, "ProductID") as int?;

            Label productNameLabel = e.Row.FindControl("ProductNameLabel") as Label;
            Product product = productUI.GetProductByID(productID.Value);
            productNameLabel.Text = product.Description;
        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label priceLabel = (Label)e.Row.FindControl("priceLabelTotal");
            priceLabel.Text = this.creditPriceTotal.ToString("c");
        }
    }

    protected void CreditNoteLinesGridView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("Select"))
        {
            Int32 index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = this.CreditNoteLinesGridView.Rows[index];

            Label idLabel = row.FindControl("IDLabel") as Label;

            // To be done:- have to get available no of units to be added to credt note, note the number
            // of units must reflect any existing credit notes for this order line ....
            // done ...
            // suggest that order line does not show edit button if no of units is fully allocated.
            // to credit note lines.
            // done ...

            // also  indicate if existing credit notes have been placed against order line
            // done ...

            // Also suggest use cancel button to reverse credit note line (i.e remove it ...)

            OrderCreditNoteLine orderLine = OrderCreditNoteLineUI.GetById(Convert.ToInt32(idLabel.Text));
            ProductUI productUI = new ProductUI();
            Product product = productUI.GetProductByID(orderLine.ProductID);

            Panel panelMessage = row.FindControl("PanelMessage") as Panel;
            Label noOfUnitsLabel = row.FindControl("NoOfUnitsLabel") as Label;
            int qtyToCredit = orderLine.NoOfUnits;

            DropDownList quantityToCreditDropDownList = panelMessage.FindControl("QuantityToCreditDropDownList") as DropDownList;
            quantityToCreditDropDownList.Items.Clear();
            for (int i = 0; i < qtyToCredit; i++)
            {
                quantityToCreditDropDownList.Items.Add(new ListItem((i + 1).ToString(), (i + 1).ToString()));
            }
            quantityToCreditDropDownList.SelectedValue = qtyToCredit.ToString();

            ModalPopupExtender extender = row.FindControl("ModalPopupExtender") as ModalPopupExtender;
            extender.Show();
        }
    }


    #endregion

    #region Object Data Source Event Handlers

    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        e.InputParameters[0] = OrderID;
    }

    protected void ObjectDataSource1_CreditNoteSelecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        e.InputParameters[0] = this.CreditNoteID;
    }

    #endregion
    protected void CreditNoteLinesGridView_DataBound(object sender, EventArgs e)
    {
        GridView grid = sender as GridView;
        if (grid.Rows.Count == 0)
        {
            this.CreditLinesPanel.Visible = false;
        }
        else
        {
            this.CreditLinesPanel.Visible = true;
        }
    }
}
