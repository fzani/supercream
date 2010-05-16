using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using WcfFoundationService;

public partial class Controls_ListArbitraryCreditNote : System.Web.UI.UserControl
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
    protected void lvItemsTable_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        if (e.Item.ItemType == ListViewItemType.DataItem)
        {
            ListViewDataItem dataItem = (ListViewDataItem)e.Item;
            decimal creditAmount = (decimal)DataBinder.Eval(dataItem.DataItem, "CreditAmount");

            CreditNote creditNote = dataItem.DataItem as CreditNote;
            OrderHeaderUI orderHeaderUi = new OrderHeaderUI();

            OrderHeader orderHeader = orderHeaderUi.GetById(creditNote.OrderID);
            VatCodeUI vatCodeUi = new VatCodeUI();
            VatCode vatCode = vatCodeUi.GetByID(orderHeader.VatCodeID);

            Label totalCreditAmountLabel = e.Item.FindControl("TotalCreditAmountLabel") as Label;

            if (vatCode.PercentageValue > 0)
            {
                totalCreditAmountLabel.Text = String.Format("{0:c}", Math.Round((creditAmount * new decimal((1 + (vatCode.PercentageValue / 100.0)))), 2));
            }
            else
            {
                totalCreditAmountLabel.Text = String.Format("{0:c}", creditAmount);
            }

            Label vatExemptLabel = e.Item.FindControl("VatExemptLabel") as Label;
            if (creditNote.VatExempt)
            {
                vatExemptLabel.Text = "Y";
            }
            else
            {
                vatExemptLabel.Text = "N";
            }
        }
    }
}
