using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controls_CreditNoteSearch : System.Web.UI.UserControl
{
    #region Private Member Variables
    EventHandler<EventArgs> ChangeState;    
    #endregion

    #region Public Events

    public event CreditNoteEventHandler CreditNoteEventHandler;

    #endregion

    #region Page Load Event

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    #endregion

    #region Object Data Source Events

    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        e.InputParameters[0] = OrderNoSearchTextBox.Text;
        e.InputParameters[1] = InvoiceNoSearchTextBox.Text;
        e.InputParameters[2] = CustomerNameSearchTextBox.Text;
        if (!String.IsNullOrEmpty(DateFromTextBox.Text))
            e.InputParameters[3] = Convert.ToDateTime(DateFromTextBox.Text);
        else
            e.InputParameters[3] = String.Empty;

        if (!String.IsNullOrEmpty(DateToTextBox.Text))
            e.InputParameters[4] = Convert.ToDateTime(DateToTextBox.Text);
        else
            e.InputParameters[4] = String.Empty;       
    }

    #endregion

    #region General Event Handlers

    protected void SearchButton_Click(object sender, EventArgs e)
    {
        DataBind();
    }

    protected void ClearButton_Click(object sender, EventArgs e)
    {
        Util.ClearControls(CreditNoteSearchCriteriaPanel);
        DataBind();
    }

    #endregion

    #region CreditNote Grid Event Handelrs

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditCreditNote")
        {
            int creditNoteID = Convert.ToInt32(e.CommandArgument);
            if (this.CreditNoteEventHandler != null)
            {
                this.CreditNoteEventHandler(this, new CreditNoteEventArgs { CreditNoteID = creditNoteID });
            }
        }
    }

    #endregion
}
