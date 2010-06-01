using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SP.Utils;
using WcfFoundationService;

public partial class Controls_NewSpecialInvoiceCreditNoteSearch : System.Web.UI.UserControl
{
    #region Private Member Variables

    EventHandler<EventArgs> ChangeState;

    #endregion

    #region Public Events

    public event InvoiceEventHandler InvoiceEventHandler;

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    #region General Event handlers

    protected void ClearButton_Click(object sender, EventArgs e)
    {
        Util.ClearControls(InvoiceSearchCriteriaPanel);
        DataBind();
    }

    protected void SearchButton_Click(object sender, EventArgs e)
    {
        InvoiceGridView.DataBind();
    }

    #endregion

    #region Data Grid Events

    protected void InvoiceGridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            SpecialInvoiceHeader specialInvoiceHeader = e.Row.DataItem as SpecialInvoiceHeader;

            int customerID = specialInvoiceHeader.CustomerID;

            CustomerUI ui = new CustomerUI();
            Customer customer = ui.GetByID(customerID);

            Label customerNameLabel = e.Row.FindControl("CustomerNameLabel") as Label;
            customerNameLabel.Text = customer.Name;
        }
    }

    protected void InvoiceGridView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            int id = Convert.ToInt32(e.CommandArgument);

            if (this.InvoiceEventHandler != null)
            {
                this.InvoiceEventHandler(this, new InvoiceEventEventArgs { OrderID = id });
            }
        }
    }

    #endregion

    #region Object Data Source Events

    protected void InvoiceObjectDataSource_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {      
        e.InputParameters[0] = InvoiceNoSearchTextBox.Text;

        e.InputParameters[1] = CustomerNameSearchTextBox.Text;
        if (!String.IsNullOrEmpty(DateFromTextBox.Text))
            e.InputParameters[2] = Convert.ToDateTime(DateFromTextBox.Text);
        else
            e.InputParameters[2] = String.Empty;

        if (!String.IsNullOrEmpty(DateToTextBox.Text))
            e.InputParameters[3] = Convert.ToDateTime(DateToTextBox.Text);
        else
            e.InputParameters[3] = String.Empty;

        e.InputParameters[4] = (short)SP.Core.Enums.OrderStatus.Invoice;
        e.InputParameters[5] = (short)SP.Core.Enums.OrderStatus.InvoicePrinted;

    }

    #endregion
}
