using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;

using SP.Core.Enums;
using SP.Util;

using WcfFoundationService;

public partial class Modify_CustomerContacts : System.Web.UI.Page
{
    EventHandler<EventArgs> ChangeState;

    #region public Accesors
    public int? CustomerID
    {
        get
        {
            return ViewState["ID"] as int?;
        }
        set
        {
            ViewState["ID"] = value;
        }
    }
    #endregion

    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!IsPostBack)
            {
                ChangeState += new EventHandler<EventArgs>(PageLoadState);

                PriceListHeaderUI pui = new PriceListHeaderUI();
                List<PriceListHeader> headerList = pui.GetAll();
                foreach (PriceListHeader priceListHeader in headerList)
                    CustomerContactPriceListDropDownList.Items.Add(new ListItem(priceListHeader.PriceListName, priceListHeader.ID.ToString()));

                ChangeState(this, e);
            }

            UrlParameterPasser p = new UrlParameterPasser();
            int id = Convert.ToInt32(p["ID"]);

            CustomerUI ui = new CustomerUI();
            Customer c = ui.GetWithContactDetails(id);

            CustomerID = id; // Serialise to View State
            int index = Convert.ToInt32(CustomerContactPriceListDropDownList.Items.FindByValue(c.PriceListHeaderID.ToString()).Value.ToString()) - 1;
            CustomerContactPriceListDropDownList.SelectedIndex = index;

            CustomerContactNameTextBox.Text = c.Name;

            DataBind();
        }
    }
    #endregion

    #region Button Handlers

    protected void AddCustomerButton_Click(object sender, EventArgs e)
    {
        try
        {
        }
        catch (Exception ex)
        {
            ErrorViewControl.AddError(ex.Message);
            ErrorViewControl.Visible = true;
        }
    }

    protected void AddNewCustomerButton_Click(object sender, EventArgs e)
    {
        try
        {

        }
        catch (Exception ex)
        {
            ErrorViewControl.AddError(ex.Message);
            ErrorViewControl.Visible = true;
        }
    }

    protected void AddNewContactButton_Click(object sender, EventArgs e)
    {
        ChangeState += new EventHandler<EventArgs>(AddNewContactState);
        ChangeState(this, e);
    }

    protected void AddContactButton_Click(object sender, EventArgs e)
    {
        try
        {
            int? customerID = CustomerID;

            ContactDetail contactDetail = new ContactDetail
            {
                ID = -1,
                CustomerID = customerID.Value,
                FirstName = this.FirstNameTextBox.Text,
                LastName = LastNameTextBox.Text,
                JobRole = JobRoleTextBox.Text,
                Title = TitleTextBox.Text,
                InitialNote = NotesTextBox.Text,
                Phone = new List<Phone>()
                {
                    new Phone
                    {
                        ID = -1,
                        PhoneTypeID = (short)SP.Core.Enums.PhoneNoTypes.HomePhoneNo,
                        Description = HomePhoneNoTextBox.Text
                    },
                    new Phone
                    {
                        ID = -1,
                        PhoneTypeID = (short)SP.Core.Enums.PhoneNoTypes.MobileNo,
                        Description = MobileNoTextBox.Text
                    },
                    new Phone
                    {
                        ID = -1,
                        PhoneTypeID = (short)SP.Core.Enums.PhoneNoTypes.DayTimeTelephoneNo,
                        Description = DayTimeTelephoneNoTextBox.Text
                    }
                }
            };

            CustomerUI ui = new CustomerUI();
            ui.SaveContactDetail(contactDetail);

            DataBind();

            ChangeState += new EventHandler<EventArgs>(AddedContactButtonState);
            ChangeState(this, e);
        }
        catch (Exception ex)
        {
            ErrorViewControl.AddError(ex.Message);
            ErrorViewControl.Visible = true;
        }
    }

    protected void CancelAddContactButton_Click(object sender, EventArgs e)
    {
        ChangeState += new EventHandler<EventArgs>(AddedContactButtonState);
        ChangeState(this, e);
    }

    protected void CustomerSaveButton_Click(object sender, EventArgs e)
    {
        try
        {
            //EventArgs ev = new EventArgs();
            //ChangeState += new EventHandler<EventArgs>(PageLoadState);

            CustomerUI ui = new CustomerUI();

            Customer customer = new Customer()
            {
                ID = CustomerID.Value,
                Name = CustomerContactNameTextBox.Text,
                PriceListHeaderID = Convert.ToInt32(CustomerContactPriceListDropDownList.SelectedValue)
            };

            ui.UpdateCustomer(customer);

            //  DataBind();

            Response.Redirect("Customer.aspx");
        }
        catch (Exception ex)
        {
            ErrorViewControl.AddError(ex.Message);
            ErrorViewControl.Visible = true;
        }
    }

    #endregion

    #region DataList Handlers

    protected void ContactDetailDataList_ItemCommand(object source, DataListCommandEventArgs e)
    {
        DataList fromList = (DataList)source;
        if (e.CommandName == "Select")
        {
            fromList.SelectedIndex = e.Item.ItemIndex;
            DataBind();
        }
        else if (e.CommandName == "UnSelect")
        {
            fromList.SelectedIndex = -1;
            DataBind();
        }
        else if (e.CommandName == "Delete")
        {
            fromList.SelectedIndex = e.Item.ItemIndex;
            CustomerUI ui = new CustomerUI();
            ui.DeleteContactDetail(CustomerID, Convert.ToInt32(e.CommandArgument));
            fromList.SelectedIndex = -1;
            DataBind();
        }
        else if (e.CommandName == "Update")
        {
            fromList.SelectedIndex = e.Item.ItemIndex;

            Panel ContactPanel = (Panel)e.Item.FindControl("SelectedPanel");

            Label idLabel = ContactPanel.FindControl("IDLabel") as Label;
            TextBox JobRoleTextBox = ContactPanel.FindControl("JobRoleTextBox") as TextBox;
            TextBox TitleTextBox = ContactPanel.FindControl("TitleTextBox") as TextBox;
            TextBox FirstNameTextBox = ContactPanel.FindControl("FirstNameTextBox") as TextBox;
            TextBox LastNameTextBox = ContactPanel.FindControl("LastNameTextBox") as TextBox;
            TextBox DayTimeTelephoneNoTextBox = ContactPanel.FindControl("DayTimeTelephoneNoTextBox") as TextBox;
            TextBox HomeTelephoneNoTextBox = ContactPanel.FindControl("HomeTelephoneNoTextBox") as TextBox;
            TextBox MobileTelephoneTextBox = ContactPanel.FindControl("MobileTelephoneTextBox") as TextBox;
            TextBox NotesTextBox = ContactPanel.FindControl("NotesTextBox") as TextBox;

            ContactDetail Detail = new ContactDetail
            {
                ID = Convert.ToInt32(idLabel.Text),
                CustomerID = CustomerID,
                JobRole = JobRoleTextBox.Text,
                Title = TitleTextBox.Text,
                FirstName = FirstNameTextBox.Text,
                LastName = LastNameTextBox.Text,
                InitialNote = NotesTextBox.Text,
                Phone = new List<Phone>
                {
                    new Phone
                    {
                        ID = -1,
                        Description = HomeTelephoneNoTextBox.Text,
                        ContactDetailID = Convert.ToInt32(idLabel.Text),
                        PhoneTypeID = (int)SP.Core.Enums.PhoneNoTypes.HomePhoneNo
                    },
                    new Phone
                    {
                        ID = -1,
                        Description = MobileTelephoneTextBox.Text,
                        ContactDetailID = Convert.ToInt32(idLabel.Text),
                        PhoneTypeID = (int)SP.Core.Enums.PhoneNoTypes.MobileNo
                    },
                    new Phone
                    {
                        ID = -1,
                        Description = DayTimeTelephoneNoTextBox.Text,
                        ContactDetailID = Convert.ToInt32(idLabel.Text),
                        PhoneTypeID = (int)SP.Core.Enums.PhoneNoTypes.DayTimeTelephoneNo
                    }
                }
            };

            CustomerUI ui = new CustomerUI();
            ui.UpdateContactDetails(Detail);

            fromList.SelectedIndex = -1;

            DataBind();
        }
    }

    protected void ContactDetailDataList_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {

        }

        if (e.Item.ItemType == ListItemType.SelectedItem)
        {
            // Reference the data bound to the DataListItem            
            ContactDetail ou = ((ContactDetail)e.Item.DataItem);

            Panel ContactPanel = (Panel)e.Item.FindControl("SelectedPanel");

            Label idLabel = ContactPanel.FindControl("IDLabel") as Label;
            idLabel.Text = ou.ID.ToString();

            TextBox JobRoleTextBox = ContactPanel.FindControl("JobRoleTextBox") as TextBox;
            JobRoleTextBox.Text = ou.JobRole;

            TextBox TitleTextBox = ContactPanel.FindControl("TitleTextBox") as TextBox;
            TitleTextBox.Text = ou.Title;

            TextBox FirstNameTextBox = ContactPanel.FindControl("FirstNameTextBox") as TextBox;
            FirstNameTextBox.Text = ou.FirstName;

            TextBox LastNameTextBox = ContactPanel.FindControl("LastNameTextBox") as TextBox;
            LastNameTextBox.Text = ou.LastName;

            int phoneType = Convert.ToInt32(SP.Core.Enums.PhoneNoTypes.DayTimeTelephoneNo);
            TextBox DayTimeTelephoneNoTextBox = ContactPanel.FindControl("DayTimeTelephoneNoTextBox") as TextBox;
            if (ou.Phone != null)
            {
                Phone p = ou.Phone.Find(o => (o.PhoneTypeID == phoneType));
                if (p != null)
                    DayTimeTelephoneNoTextBox.Text = p.Description;

            }

            phoneType = Convert.ToInt32(SP.Core.Enums.PhoneNoTypes.HomePhoneNo);
            TextBox HomeTelephoneNoTextBox = ContactPanel.FindControl("HomeTelephoneNoTextBox") as TextBox;
            if (ou.Phone != null)
            {
                Phone p = ou.Phone.SingleOrDefault(o => (o.PhoneTypeID == phoneType));
                if (p != null)
                    HomeTelephoneNoTextBox.Text = p.Description;
            }

            phoneType = Convert.ToInt32(SP.Core.Enums.PhoneNoTypes.MobileNo);
            TextBox MobileTelephoneTextBox = ContactPanel.FindControl("MobileTelephoneTextBox") as TextBox;
            if (ou.Phone != null)
            {
                Phone p = ou.Phone.SingleOrDefault(o => (o.PhoneTypeID == phoneType));
                if (p != null)
                    MobileTelephoneTextBox.Text = p.Description;
            }

            TextBox NotesTextBox = ContactPanel.FindControl("NotesTextBox") as TextBox;
            NotesTextBox.Text = ou.InitialNote;
        }
    }

    #endregion

    #region Page States
    private void PageLoadState(object src, EventArgs mea)
    {
        Util.ClearFields(this.Page);
        ErrorViewControl.Visible = false;

        AddContactPanel.Visible = false;
    }

    private void AddNewContactState(object src, EventArgs mea)
    {
        AddCustomerContactPanel.Visible = true;
        AddContactPanel.Visible = true;

        ErrorViewControl.Visible = false;
    }

    protected void AddedContactButtonState(object sender, EventArgs e)
    {
        AddCustomerContactPanel.Visible = true;
        AddContactPanel.Visible = false;

        ErrorViewControl.Visible = false;

        Util.ClearControls(AddContactPanel);
    }

    private void CancelAddNewContactState(object src, EventArgs mea)
    {
        AddCustomerContactPanel.Visible = true;
        AddContactPanel.Visible = false;
        ErrorViewControl.Visible = false;
        Util.ClearControls(AddContactPanel);
    }

    #endregion
}
