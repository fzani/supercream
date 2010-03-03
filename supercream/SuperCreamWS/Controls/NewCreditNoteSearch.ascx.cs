using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SP.Utils;
using WcfFoundationService;

public partial class Controls_NewCreditNoteSearch : System.Web.UI.UserControl
{
    #region Private Member Variables

    EventHandler<EventArgs> ChangeState;

    #endregion

    #region Public Events

    public event CancelEventHandler CancelEventHandler;
    public event CreditNoteEventHandler CreditNoteEventHandler;

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
            OrderHeader orderHeader = e.Row.DataItem as OrderHeader;

            int customerID = orderHeader.CustomerID;

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

            OrderHeaderUI orderHeaderUI = new OrderHeaderUI();
            OrderHeader orderHeader = orderHeaderUI.GetById(id);

            ////OrderID = orderHeader.ID;
            ////OrderHeaderNoLabel.Text = orderHeader.AlphaID;

            ////int customerID = orderHeader.CustomerID;

            ////CustomerUI customerUI = new CustomerUI();
            ////Customer customer = customerUI.GetByID(customerID);

            ////List<Account> accounts = customer.Account;

            ////Action<Account> accountAction =
            ////    new Action<Account>(a => AccountDropDownList.Items.Add(new ListItem(a.AlphaID.ToString(), a.ID.ToString())));

            ////    AccountDropDownList.Items.Clear();
            ////    AccountDropDownList.Items.Add(new ListItem("-- No Item Selected --", "-1"));
            ////    customer.Account.ForEach(accountAction);

            ////    ChangeState += new EventHandler<EventArgs>(SelectedOrderState);
            ////    ChangeState(this, e);

            ////    List<OutletStore> outletStore = customer.OutletStore;

            ////    Action<OutletStore> outletStoreAction =
            ////        new Action<OutletStore>(a => DeliveryDropDownList.Items.Add(new ListItem(a.Name.ToString(), a.ID.ToString())));

            ////    DeliveryDropDownList.Items.Clear();
            ////    DeliveryDropDownList.Items.Add(new ListItem("-- No Item Selected --", "-1"));
            ////    customer.OutletStore.ForEach(outletStoreAction);

            ////    OrderNotesStatusUI orderNotesStatusUI = new OrderNotesStatusUI();
            ////    if (orderNotesStatusUI.OrderNoteExistsByOrderID(OrderID.Value))
            ////    {
            ////        ConfirmInvoice.Visible = false;
            ////        ChangeInvoiceDetailsButton.Visible = true;
            ////        CancelInvoiceButton.Visible = true;

            ////        // Now Select Account using Create OrderNotes record ...
            ////        OrderNotesStatus orderNoteStatus = orderNotesStatusUI.GetOrderNotesStatusByOrderID(OrderID.Value);
            ////        OrderNoteStatusID = orderNoteStatus.ID;
            ////        if (orderNoteStatus.InvoicePrinted)
            ////        {
            ////            PrintInvoiceButton.Visible = false;
            ////            RePrintInvoiceButton.Visible = true;
            ////        }
            ////        else
            ////        {
            ////            PrintInvoiceButton.Visible = true;
            ////            RePrintInvoiceButton.Visible = false;
            ////        }

            ////        AccountDropDownList.SelectedValue = orderNoteStatus.AccountID.ToString();
            ////        DeliveryDropDownList.SelectedValue = orderNoteStatus.OutletStoreID.ToString();
            ////        DeliveryVanDropDownList.SelectedValue = orderNoteStatus.VanID.ToString();

            ////        PopulateInvoice(e);
            ////    }
            ////    else
            ////    {
            ////        ConfirmInvoice.Visible = true;
            ////        ChangeInvoiceDetailsButton.Visible = false;
            ////        PrintInvoiceButton.Visible = false;
            ////        RePrintInvoiceButton.Visible = false;
            ////        CancelInvoiceButton.Visible = false;
            ////    }

            ////    DataBind();
        }
    }
    #endregion

    #region Object Data Source Events

    protected void InvoiceObjectDataSource_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
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

        e.InputParameters[5] = (short)SP.Core.Enums.OrderStatus.Invoice;
        e.InputParameters[6] = (short)SP.Core.Enums.OrderStatus.InvoicePrinted;

    }

    #endregion
}
