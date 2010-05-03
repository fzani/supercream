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

    public List<OrderLine> OrderLines
    {
        get;
        set;
    }

    #endregion

    #region Page Load Event Handlers

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.OrderID = -1;
        }
    }

    #endregion

    #region GridView Event Handlers

    protected void OrderDetailsGridPanel_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
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

            OrderLine orderLine = OrderLineUI.GetOrderLine(Convert.ToInt32(idLabel.Text));
            ProductUI productUI = new ProductUI();
            Product product = productUI.GetProductByID(orderLine.ProductID);

            Panel panelMessage = row.FindControl("PanelMessage") as Panel;
            Label noOfUnitsLabel = row.FindControl("NoOfUnitsLabel") as Label;
            int qtyToCredit = Convert.ToInt32(noOfUnitsLabel.Text);

            DropDownList quantityToCreditDropDownList = panelMessage.FindControl("QuantityToCreditDropDownList") as DropDownList;

            for (int i = 0; i < qtyToCredit; i++)
            {
                quantityToCreditDropDownList.Items.Add(new ListItem((i + 1).ToString(), (i + 1).ToString()));
            }
            quantityToCreditDropDownList.SelectedValue = qtyToCredit.ToString();

            //Label productIDLabel = row.FindControl("ProductIDLabel") as Label;
            //productIDLabel.Text = orderLine.ProductID.ToString();

            //Label productNameLabel = row.FindControl("ProductNameLabel") as Label;
            //productNameLabel.Text = product.Description;

            //Label alphaIDLabel = row.FindControl("AlphaIDLabel") as Label;
            //alphaIDLabel.Text = AlphaID;

            //Label orderIDLabel = row.FindControl("OrderIDLabel") as Label;
            //orderIDLabel.Text = orderLine.OrderID.ToString();

            //TextBox qtyTextBox = row.FindControl("QtyTextBox") as TextBox;
            //qtyTextBox.Text = orderLine.QtyPerUnit.ToString();

            //TextBox noOfUnitsTextBox = row.FindControl("NoOfUnitsTextBox") as TextBox;
            //noOfUnitsTextBox.Text = orderLine.NoOfUnits.ToString();

            //TextBox discountTextBox = row.FindControl("DiscountTextBox") as TextBox;
            //discountTextBox.Text = orderLine.Discount.ToString();

            //TextBox priceTextBox = row.FindControl("PriceTextBox") as TextBox;
            //priceTextBox.Text = String.Format("{0:c}", orderLine.Price);

            //TextBox specialInstructionsTextBox = row.FindControl("SpecialInstructionsTextBox") as TextBox;
            //specialInstructionsTextBox.Text = orderLine.SpecialInstructions;

            ModalPopupExtender extender = row.FindControl("ModalPopupExtender") as ModalPopupExtender;
            extender.Show();
        }
    }

    protected void UpdateOrderCreditLineButton_Click(object sender, EventArgs e)
    {
        Button button = sender as Button;

        Int32 index = Convert.ToInt32(button.CommandArgument);
        GridViewRow row = this.OrderDetailsGridView.Rows[index];
        OrderLine line = row.DataItem as OrderLine;

        Panel panelMessage = row.FindControl("PanelMessage") as Panel;
        DropDownList quantityToCreditDropDownList = panelMessage.FindControl("QuantityToCreditDropDownList") as DropDownList;

        int noOfUnits = Convert.ToInt32(quantityToCreditDropDownList.SelectedValue.ToString());
        int orderLineId = Convert.ToInt32(this.OrderDetailsGridView.SelectedDataKey.Value);
        int credtNoteId = CreditNoteID;
        // Now check if order atline should be updated or deleted.
        // update or delete.
        // Then check if credit note line exists - if not create then 
        // write credit Note line and if neccessary remove order line
        // First Read Order line
        var orderLine = OrderLineUI.GetOrderLine(orderLineId);
        orderLine.NoOfUnits -= noOfUnits;
        if(orderLine.NoOfUnits == 0)
        {
            OrderLineUI.DeleteOrderLine(orderLineId);
        }
        else
        {
            OrderLineUI.Update(orderLine);
        }  

        if(OrderCreditNoteLineUI.CheckIfOrderCreditLineExists(credtNoteId, orderLineId))
        {
            OrderCreditNoteLine orderCreditNoteLine = OrderCreditNoteLineUI.GetCreditNoteLineByOrderIdAndOrderLineId(credtNoteId, orderLineId);
            orderCreditNoteLine.NoOfUnits += noOfUnits;
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
                                               NoOfUnits = noOfUnits,
                                               Discount = orderLine.Discount,
                                               Price = orderLine.Price
                                          };
            OrderCreditNoteLineUI.SaveOrderCreditNoteLine(orderCreditNoteLine);
        }
       
        this.DataBind();
    }

    protected void CreditNoteOrderDetailsGridPanel_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    #endregion

    #region Object Data Source Event Handlers

    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        e.InputParameters[0] = OrderID;
    }

    #endregion
}
