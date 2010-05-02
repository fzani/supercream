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

    #region Object Data Source Event Handlers

    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        e.InputParameters[0] = OrderID;
    }

    #endregion
}
