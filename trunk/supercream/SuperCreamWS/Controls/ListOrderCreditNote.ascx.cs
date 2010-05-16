using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using WcfFoundationService;

public partial class Controls_ListOrderCreditNote : System.Web.UI.UserControl
{
    #region Private Member Variables

    private int creditNoteId;
    private int orderId;

    #endregion

    #region Page Load Event

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    #endregion

    #region Public Properties

    public int CreditNoteId
    {
        get { return creditNoteId; }
        set { creditNoteId = value; }
    }

    public int OrderId
    {
        get { return orderId; }
        set { orderId = value; }
    }

    #endregion

    #region Object Data Source events

    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        e.InputParameters[0] = this.orderId;
    }

    #endregion

    #region List View Events

    protected void lvItemsTable_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        if (e.Item.ItemType == ListViewItemType.DataItem)
        {
            Repeater repeater = e.Item.FindControl("OrderCreditNoteDetailsRepeater") as Repeater;
            ListViewDataItem dataItem = (ListViewDataItem)e.Item;
            OrderCreditNote creditNote = dataItem.DataItem as OrderCreditNote;

            List<OrderCreditNoteLine> lines = OrderCreditNoteLineUI.GetOrderCreditNoteLines(creditNote.ID);
            repeater.DataSource = lines;
            if (lines.Count == 0)
            {
                repeater.Visible = false;
            }
            else
            {
                repeater.Visible = true;
            }
            repeater.DataBind();
        }
    }

    #endregion

    #region Repeater Events

    protected void OrderCreditNoteDetailsRepeater_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            RepeaterItem item = (RepeaterItem)e.Item;
            OrderCreditNoteLine line = item.DataItem as OrderCreditNoteLine;
            Label productNameLabel = e.Item.FindControl("ProductNameLabel") as Label;

            ProductUI productUi = new ProductUI();
            Product product = productUi.GetProductByID(line.ProductID);
            productNameLabel.Text = product.Description;
        }
    }

    #endregion
}
