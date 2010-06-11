using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;

using SP.Util;
using SP.Core.Enums;

using System.Threading;

using WcfFoundationService;

public partial class Admin_Account : System.Web.UI.Page
{
    #region private variables
    EventHandler<EventArgs> ChangeState;
    #endregion

    #region Page Events

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ChangeState += new EventHandler<EventArgs>(PageLoadState);
            ChangeState(this, e);

            CustomerUI customerUI = new CustomerUI();
            List<Customer> customerList = customerUI.GetAll();

            CustomerDropDownList.Items.Add(new ListItem("-- Not Selected --", "-1"));
            foreach (Customer cs in customerList)
            {
                CustomerDropDownList.Items.Add(new ListItem(cs.Account + " " + cs.Name, cs.ID.ToString()));
            }

            TermsUI termsUI = new TermsUI();
            List<Terms> termsList = termsUI.GetAllTermss();
            PaymentTermsDropDownList.Items.Add(new ListItem("-- Not Selected --", "-1"));
            foreach (Terms ts in termsList)
            {
                PaymentTermsDropDownList.Items.Add(new ListItem(ts.Description, ts.ID.ToString()));
            }

            ForTheAttentionOfDropDownList.Items.Add(new ListItem("-- Not Selected --", "-1"));
        }
        else
        {
            ErrorViewControl.Visible = false;
        }
    }

    protected void AddAccountButton_Click(object sender, EventArgs e)
    {
        try
        {
            ChangeState += new EventHandler<EventArgs>(PageLoadState);
            AccountUI ui = new AccountUI();

            Account acc = new Account
            {
                ID = -1,
                CustomerID = Convert.ToInt32(CustomerDropDownList.SelectedValue),
                TermTypeID = Convert.ToInt32(PaymentTermsDropDownList.SelectedValue),
                AlphaID = AccountNoTextBox.Text,
                CompanyToInvoiceTo = CompanyToInvoiceToTextBox.Text,
                ContactDetailID = Convert.ToInt32(ForTheAttentionOfDropDownList.SelectedValue),
                Address = new Address
                {
                    ID = -1,
                    AccountID = -1,
                    AddressType = 0,
                    AddressLines = Utils.ConvertAddressLinesToXml(InvoiceAddressLine1TextBox, InvoiceAddressLine2TextBox),
                    Town = InvoiceTownTextBox.Text,
                    County = InvoiceCountyTextBox.Text,
                    PostCode = InvoicePostCodeTextBox.Text,
                }
            };

            ui.SaveAccount(acc);

            ChangeState(this, e);

            DataBind();
        }
        catch (Exception ex)
        {
            ErrorViewControl.AddError(ex.Message);
            ErrorViewControl.Visible = true;
            ErrorViewControl.DataBind();
        }
    }

    protected void CustomerDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        ChangeState += new EventHandler<EventArgs>(AddAccountState);
        ChangeState(this, e);

        ForTheAttentionOfDropDownList.Items.Clear();
        ForTheAttentionOfDropDownList.Items.Add(new ListItem("-- Not Selected --", "-1"));

        if (CustomerDropDownList.SelectedIndex != 0)
        {
            CompanyToInvoiceToTextBox.Text = CustomerDropDownList.SelectedItem.Text;
            CustomerUI cui = new CustomerUI();

            List<ContactDetail> cList = (from c in cui.GetContactDetailsByCustomerID(Convert.ToInt32(CustomerDropDownList.SelectedValue))
                                         select new ContactDetail
                                         {
                                             ID = c.ID,
                                             FirstName = c.FirstName + " " + c.LastName,
                                             EMailAddress = c.EMailAddress,
                                             JobRole = c.JobRole,
                                             Title = c.Title,
                                             LastName = c.LastName
                                         }
                                                   ).ToList<ContactDetail>();

            ContactDetail contactDetail = new ContactDetail
            {
                ID = -1,
                FirstName = "-- Not Selected --"
            };
            cList.Insert(0, contactDetail);

            ForTheAttentionOfDropDownList.DataSource = cList;
        }
        else
            Util.ClearControls(SetupAccountPanel);

        if (AccountGridView.Rows.Count > 0)
            UpdateInvoicePanel.Visible = true;
        else
            UpdateInvoicePanel.Visible = false;

        DataBind();
    }

    public string ConcatNames(object firstName, object lastName)
    {
        return firstName as string + " " + lastName as string;
    }

    protected void AccountGridView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("Select"))
        {
            Int32 index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = this.AccountGridView.Rows[index];

            Label idLabel = row.FindControl("ID") as Label;

            AccountUI ui = new AccountUI();
            Account account = ui.GetByID(Convert.ToInt32(idLabel.Text));

            DropDownList forTheAttentionOfDropDownList = row.FindControl("ForTheAttentionOfDropDownList") as DropDownList;
            CustomerUI cui = new CustomerUI();

            List<ContactDetail> cList = (from c in cui.GetContactDetailsByCustomerID(Convert.ToInt32(CustomerDropDownList.SelectedValue))
                                         select new ContactDetail
                                         {
                                             ID = c.ID,
                                             FirstName = c.FirstName + " " + c.LastName,
                                             EMailAddress = c.EMailAddress,
                                             JobRole = c.JobRole,
                                             Title = c.Title,
                                             LastName = c.LastName
                                         }
                                                   ).ToList<ContactDetail>();

            ContactDetail contactDetail = new ContactDetail
            {
                ID = -1,
                FirstName = "-- Not Selected --"
            };
            cList.Insert(0, contactDetail);

            forTheAttentionOfDropDownList.DataSource = cList;
            forTheAttentionOfDropDownList.DataBind();
            if (forTheAttentionOfDropDownList.Items.FindByValue(account.ContactDetailID.ToString()) != null)
                forTheAttentionOfDropDownList.SelectedValue = account.ContactDetailID.ToString();

            DropDownList paymentDropDownList = row.FindControl("PaymentTermsDropDownList") as DropDownList;
            if (paymentDropDownList != null)
            {
                TermsUI termsUI = new TermsUI();
                List<Terms> termsList = termsUI.GetAllTermss();
                paymentDropDownList.Items.Add(new ListItem("-- Not Selected --", "-1"));
                foreach (Terms ts in termsList)
                {
                    paymentDropDownList.Items.Add(new ListItem(ts.Description, ts.ID.ToString()));
                }
                paymentDropDownList.SelectedValue = account.TermTypeID.ToString();
            }

            TextBox companyToInvoiceToTextBox = row.FindControl("CompanyToInvoiceToTextBox") as TextBox;
            companyToInvoiceToTextBox.Text = account.CompanyToInvoiceTo;

            TextBox accountNoTextBox = row.FindControl("AccountNoTextBox") as TextBox;
            accountNoTextBox.Text = account.AlphaID;

            List<string> addressLnes = Utils.ConvertAddressLinesFromXml(account.Address.AddressLines);
            TextBox invoiceAddressLine1TextBox = row.FindControl("InvoiceAddressLine1TextBox") as TextBox;
            invoiceAddressLine1TextBox.Text = addressLnes[0];

            TextBox invoiceAddressLine2TextBox = row.FindControl("InvoiceAddressLine2TextBox") as TextBox;
            if (addressLnes.Count > 1)
                invoiceAddressLine2TextBox.Text = addressLnes[1];

            TextBox invoiceTownTextBox = row.FindControl("InvoiceTownTextBox") as TextBox;
            invoiceTownTextBox.Text = account.Address.Town;

            TextBox invoiceCountyTextBox = row.FindControl("InvoiceCountyTextBox") as TextBox;
            invoiceCountyTextBox.Text = account.Address.County;

            TextBox invoicePostCodeTextBox = row.FindControl("InvoicePostCodeTextBox") as TextBox;
            invoicePostCodeTextBox.Text = account.Address.PostCode;

            //TextBox invoiceTelephoneNoTextBox = row.FindControl("InvoiceTelephoneNoTextBox") as TextBox;
            //invoiceTelephoneNoTextBox.Text = account.p;

            ModalPopupExtender extender = row.FindControl("PopupControlExtender1") as ModalPopupExtender;
            extender.Show();
        }
    }

    protected void ModalPopupUpdateAccountButton_Click(object sender, EventArgs e)
    {
        try
        {
            ErrorViewControl.Visible = false; // reset error control
            GridViewRow row = this.AccountGridView.Rows[AccountGridView.SelectedIndex];
            Panel messagePanel = row.FindControl("PanelMessage") as Panel;

            AccountUI ui = new AccountUI();

            DropDownList paymentTermsDropDownList = messagePanel.FindControl("PaymentTermsDropDownList") as DropDownList;
            DropDownList forTheAttentionOfDropDownList = messagePanel.FindControl("ForTheAttentionOfDropDownList") as DropDownList;

            int id = Convert.ToInt32((messagePanel.FindControl("ID") as Label).Text);
            string paymentTerm = paymentTermsDropDownList.SelectedValue;
            string accountNo = (messagePanel.FindControl("AccountNoTextBox") as TextBox).Text;
            string invoiceAddressLine1 = (messagePanel.FindControl("InvoiceAddressLine1TextBox") as TextBox).Text;
            string invoiceAddressLine2 = (messagePanel.FindControl("InvoiceAddressLine2TextBox") as TextBox).Text;
            string invoiceTown = (messagePanel.FindControl("InvoiceTownTextBox") as TextBox).Text;
            string invoiceCounty = (messagePanel.FindControl("InvoiceCountyTextBox") as TextBox).Text;
            string invoicePostCode = (messagePanel.FindControl("InvoicePostCodeTextBox") as TextBox).Text;
            string companyToInvoiceTo = (messagePanel.FindControl("CompanyToInvoiceToTextBox") as TextBox).Text;
            string forTheAttentionOf = forTheAttentionOfDropDownList.SelectedValue;

            if (ui.AlphaIDExists(accountNo) && (ui.GetByID(id).AlphaID != accountNo))
            {
                throw new ApplicationException("Cannot change Account No Code to another code that already exists");
            }

            Account account = new Account
            {
                ID = id,
                AlphaID = accountNo,
                ContactDetailID = Convert.ToInt32(forTheAttentionOf),
                TermTypeID = Convert.ToInt32(paymentTerm),
                CustomerID = Convert.ToInt32(CustomerDropDownList.SelectedValue),
                CompanyToInvoiceTo = companyToInvoiceTo,
                Address = new Address
                {
                    AddressLines = Utils.ConvertAddressLinesToXml(invoiceAddressLine1, invoiceAddressLine2),
                    AddressType = (short)AddressType.Invoice,
                    Town = invoiceTown,
                    County = invoiceCounty,
                    PostCode = invoicePostCode
                }
            };

            ui.UpdatePopupAccount(account);
            DataBind();
        }
        catch (Exception ex)
        {
            ErrorViewControl.AddError(ex.Message);
            ErrorViewControl.Visible = true;
        }
    }

    protected void ModalPopupDeleteAccountButton_Click(object sender, EventArgs e)
    {
        try
        {
            ErrorViewControl.Visible = false; // reset error control
            GridViewRow row = this.AccountGridView.Rows[AccountGridView.SelectedIndex];
            Panel messagePanel = row.FindControl("PanelMessage") as Panel;

            AccountUI ui = new AccountUI();
            int id = Convert.ToInt32((messagePanel.FindControl("ID") as Label).Text);

            ui.DeleteAccount(id);

            DataBind();
        }
        catch (Exception ex)
        {
            ErrorViewControl.AddError(ex.Message);
            ErrorViewControl.Visible = true;
        }
    }

    #endregion

    #region Object Data Source Events
    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        if (!String.IsNullOrEmpty(CustomerDropDownList.SelectedValue))
            e.InputParameters[0] = Convert.ToInt32(CustomerDropDownList.SelectedValue);
    }
    #endregion

    #region Page States
    private void PageLoadState(object src, EventArgs mea)
    {
        Util.ClearFields(this.Page);

        ErrorViewControl.Visible = false;
        UpdateInvoicePanel.Visible = false;
    }

    private void AddAccountState(object src, EventArgs mea)
    {
        SetupAccountPanel.Visible = true;
    }

    #endregion

    #region Utils
    private void HandleException(Exception ex, ObjectDataSourceStatusEventArgs e)
    {
        e.ExceptionHandled = true;
        ErrorViewControl.AddError(ex.InnerException.Message);
        ErrorViewControl.Visible = true;

        DataBind();
    }
    #endregion
    protected void ObjectDataSource1_Selected(object sender, ObjectDataSourceStatusEventArgs e)
    {

    }
    protected void AccountGridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        GridView gv = (GridView)sender;
        if (gv.Rows.Count > 0)
            UpdateInvoicePanel.Visible = true;
        else
            UpdateInvoicePanel.Visible = false;
    }
    protected void ForTheAttentionOfDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ForTheAttentionOfDropDownList.SelectedValue == "-1")
        {
            ContactLabel.Visible = false;
            ContactNoLabel.Visible = false;
        }
        else
        {
            ContactLabel.Visible = true;
            ContactNoLabel.Visible = true;

            ContactDetailUI ui = new ContactDetailUI();
            ContactDetail c = ui.GetContactDetail(Convert.ToInt32(ForTheAttentionOfDropDownList.SelectedValue));
            ContactNoLabel.Text = c.Phone[2].Description.ToString();
        }
    }
}
