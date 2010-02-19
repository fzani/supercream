using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SP.Util;

using WcfFoundationService;

public partial class Admin_Customer : System.Web.UI.Page
{
    #region Private Variables
    EventHandler<EventArgs> ChangeState;
    #endregion

    #region Page Handlers

    #region public Accesors
    public int? ModifyCustomerID
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
            ChangeState += new EventHandler<EventArgs>(PageLoadState);

            PriceListHeaderUI ui = new PriceListHeaderUI();
            List<PriceListHeader> headerList = ui.GetAll();
            foreach (PriceListHeader p in headerList)
                PriceListDropDownList.Items.Add(new ListItem(p.PriceListName, p.ID.ToString()));

            PriceListHeaderUI pui = new PriceListHeaderUI();
            List<PriceListHeader> headerModifiedList = pui.GetAll();
            foreach (PriceListHeader priceListHeader in headerModifiedList)
                ModifyPriceListDropDownList.Items.Add(new ListItem(priceListHeader.PriceListName, priceListHeader.ID.ToString()));

            ChangeState(this, e);
        }
    }
    #endregion

    #region Button Events

    protected void AddContactButton_Click(object sender, EventArgs e)
    {
        try
        {
            int? customerID = ModifyCustomerID;

            ContactDetail contactDetail = new ContactDetail
            {
                ID = -1,
                CustomerID = customerID.Value,
                FirstName = this.FirstNameTextBox.Text,
                LastName = LastNameTextBox.Text,
                JobRole = JobRoleTextBox.Text,
                Title = TitleTextBox.Text,
                EMailAddress = EMailAddressTextBox.Text,
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

    protected void AddCustomerButton_Click(object sender, EventArgs e)
    {
        try
        {
            EventArgs ev = new EventArgs();
            ChangeState += new EventHandler<EventArgs>(AddCustomerState);

            ChangeState(this, e);
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
            EventArgs ev = new EventArgs();
            ChangeState += new EventHandler<EventArgs>(AddNewCustomerState);

            ChangeState(this, e);

            DataBind();
        }
        catch (Exception ex)
        {
            ErrorViewControl.AddError(ex.Message);
            ErrorViewControl.Visible = true;
        }
    }

    protected void AddShopButton_Click(object sender, EventArgs e)
    {
        EventArgs ev = new EventArgs();
        ChangeState += new EventHandler<EventArgs>(AddedShopState);

        List<SP.Web.DTO.OutletStore> storeList;
        if (ViewState["OutletStoreList"] == null)
            storeList = new List<SP.Web.DTO.OutletStore>();
        else
            storeList = ViewState["OutletStoreList"] as List<SP.Web.DTO.OutletStore>;

        SP.Web.DTO.OutletStore newStore = new SP.Web.DTO.OutletStore();
        newStore.Name = ShopNameTextBox.Text;
        newStore.OpeningHoursNotes = OpeningHoursTextBox.Text;
        newStore.Notes = NotesTextBox.Text;
        SP.Web.DTO.Address address = new SP.Web.DTO.Address
        {
            ID = -1,
            AddressType = (short)SP.Core.Enums.AddressType.Delivery,
            AddressLines = Utils.ConvertAddressLinesToXml(AddressLine1TextBox, AddressLine2TextBox),
            Town = TownTextBox.Text,
            County = CountyTextBox.Text,
            PostCode = PostCodeTextBox.Text,
            MapReference = MapReferenceTextBox.Text
        };

        newStore.Address = address;

        storeList.Add(newStore);
        ViewState["OutletStoreList"] = storeList;

        ShopNameTextBox.Text = String.Empty;
        OpeningHoursTextBox.Text = String.Empty;
        NotesTextBox.Text = String.Empty;

        OutletStoreGridView.Visible = true;
        OutletStoreGridView.DataSource = storeList;

        ChangeState(this, e);

        DataBind();
    }

    protected void AddModifiedShopButton_Click(object sender, EventArgs e)
    {
        try
        {
            int? customerID = ModifyCustomerID;

            OutletStore outletStore = new OutletStore
            {
                ID = -1,
                Name = ModifiedShopNameTextBox.Text,
                CustomerID = customerID,
                OpeningHoursNotes = ModifiedOpeningHoursTextBox.Text,
                Note = ModifiedNotesTextBox.Text,
                Address = new Address
                {
                    ID = -1,
                    AddressType = (short)SP.Core.Enums.AddressType.Delivery,
                    AddressLines = Utils.ConvertAddressLinesToXml(ModifiedAddressLine1TextBox, ModifiedAddressLine2TextBox),
                    Town = ModifiedTownTextBox.Text,
                    County = ModifiedCountyTextBox.Text,
                    PostCode = ModifiedPostCodeTextBox.Text,
                    MapReference = ModifiedMapReferenceTextBox.Text
                }
            };

            CustomerUI ui = new CustomerUI();
            ui.AddOutletStore(outletStore);

            DataBind();

            ChangeState += new EventHandler<EventArgs>(AddedShopButtonState);
            ChangeState(this, e);
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

    protected void CancelAddContactButton_Click(object sender, EventArgs e)
    {
        ChangeState += new EventHandler<EventArgs>(CancelAddContactButtonState);
        ChangeState(this, e);
    }

    protected void CancelModifiedShopButton_Click(object sender, EventArgs e)
    {
        ChangeState += new EventHandler<EventArgs>(AddedShopButtonState);
        ChangeState(this, e);
    }

    protected void CancelShopButton_Click(object sender, EventArgs e)
    {
        EventArgs ev = new EventArgs();
        ChangeState += new EventHandler<EventArgs>(PageLoadState);
        Util.ClearControls(AddShopPanel);
        ChangeState(this, e);
    }

    protected void CustomerSaveButton_Click(object sender, EventArgs e)
    {
        try
        {
            EventArgs ev = new EventArgs();
            ChangeState += new EventHandler<EventArgs>(PageLoadState);

            CustomerUI ui = new CustomerUI();

            if (ui.NameExists(NameTextBox.Text))
                throw new ApplicationException("Name already exists");

            Customer c = new Customer()
            {
                ID = -1,
                Name = NameTextBox.Text,
                PriceListHeaderID = Convert.ToInt32(PriceListDropDownList.SelectedValue)
            };

            if (ViewState["OutletStoreList"] != null)
            {
                c.OutletStore = new List<WcfFoundationService.OutletStore>();
                List<SP.Web.DTO.OutletStore> storeList = ViewState["OutletStoreList"] as List<SP.Web.DTO.OutletStore>;
                foreach (SP.Web.DTO.OutletStore store in storeList)
                {
                    WcfFoundationService.OutletStore outletStore = new WcfFoundationService.OutletStore
                    {
                        ID = -1,
                        Name = store.Name,
                        Note = store.Notes,
                        OpeningHoursNotes = store.OpeningHoursNotes,
                        Address = new Address
                        {
                            ID = -1,
                            AccountID = -1,
                            AddressType = store.Address.AddressType,
                            AddressLines = store.Address.AddressLines,
                            Town = store.Address.Town,
                            County = store.Address.County,
                            PostCode = store.Address.PostCode,
                            MapReference = store.Address.MapReference
                        }
                    };
                    c.OutletStore.Add(outletStore);
                }
            }

            ui.Save(c);

            ChangeState(this, e);

            DataBind();
        }
        catch (Exception ex)
        {
            ErrorViewControl.AddError(ex.Message);
            ErrorViewControl.Visible = true;
        }
    }

    protected void ContactDetailObjectDataSource_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        e.InputParameters[0] = ModifyCustomerID;
    }

    protected void CustomerUpdateButton_Click(object sender, EventArgs e)
    {
        try
        {
            EventArgs ev = new EventArgs();
            ChangeState += new EventHandler<EventArgs>(PageLoadState);
            CustomerUI ui = new CustomerUI();

            Customer customer = new Customer()
            {
                ID = ModifyCustomerID.Value,
                Name = ModifyNameTextBox.Text,
                PriceListHeaderID = Convert.ToInt32(ModifyPriceListDropDownList.SelectedValue)
            };

            ui.UpdateCustomer(customer);

            ChangeState(this, e);
        }
        catch (Exception ex)
        {
            ErrorViewControl.AddError(ex.Message);
            ErrorViewControl.Visible = true;
        }
    }

    protected void CustomerContactUpdateButton_Click(object sender, EventArgs e)
    {
        try
        {
            EventArgs ev = new EventArgs();
            ChangeState += new EventHandler<EventArgs>(PageLoadState);

            CustomerUI ui = new CustomerUI();

            Customer customer = new Customer()
            {
                ID = ModifyCustomerID.Value,
                Name = CustomerContactNameTextBox.Text,
                PriceListHeaderID = Convert.ToInt32(CustomerContactPriceListDropDownList.SelectedValue)
            };

            ui.UpdateCustomer(customer);

            ui.UpdateCustomer(customer);

            ChangeState(this, e);
        }
        catch (Exception ex)
        {
            ErrorViewControl.AddError(ex.Message);
            ErrorViewControl.Visible = true;
        }
    }

    protected void MaintainCustomersButton_Click(object sender, EventArgs e)
    {
        EventArgs ev = new EventArgs();
        ChangeState += new EventHandler<EventArgs>(DisplayCustomerList);

        try
        {
            CustomerListGridView.Visible = true;
            CustomerListGridViewPanel.Visible = true;
            ChangeState(this, e);
            DataBind();
        }
        catch (Exception ex)
        {
            ErrorViewControl.AddError(ex.Message);
            ErrorViewControl.Visible = true;
        }
    }

    protected void ModifyShopButton_Click(object sender, EventArgs e)
    {
        ChangeState += new EventHandler<EventArgs>(AddingModifiedShopState);
        ChangeState(this, e);
    }

    protected void SearchButton_Click(object sender, EventArgs e)
    {
        ChangeState += new EventHandler<EventArgs>(SearchProductState);
        ChangeState(this, e);
        DataBind();
    }

    #endregion

    #region Outlet Grid Events
    protected void OutletStoreGridView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            EventArgs ev = new EventArgs();
            ChangeState += new EventHandler<EventArgs>(DeletedOutletState);
            ChangeState(this, e);
        }
    }
    protected void OutletStoreGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        List<SP.Web.DTO.OutletStore> storeList = ViewState["OutletStoreList"] as List<SP.Web.DTO.OutletStore>;

        storeList.RemoveAt(e.RowIndex);

        if (storeList.Count == 0)
            ShopBasketPanel.Visible = false;

        ViewState["OutletStoreList"] = storeList;

        OutletStoreGridView.DataSource = storeList;
        DataBind();
    }
    #endregion

    #region Customer Grid Events
    protected void CustomerListGridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.DataItem != null)
            {
                Customer c = e.Row.DataItem as Customer;

                CustomerUI ui = new CustomerUI();
                List<Account> accounts = ui.GetAccountsByCustomerID(c.ID);

                BulletedList list = e.Row.FindControl("AccountNoBulletedList") as BulletedList;
                list.DataSource = accounts;
                list.DataBind();
            //    DataBind();

            }
        }
    }

    protected void CustomerListGridView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "ModifyCustomer")
        {
            EventArgs ev = new EventArgs();
            ChangeState += new EventHandler<EventArgs>(EditShopState);

            int id = Convert.ToInt32(e.CommandArgument);

            CustomerUI ui = new CustomerUI();
            Customer c = ui.GetWithOutletStores(id);

            ModifyCustomerID = id; // Serialise to View State

            //foreach(OutletStore 
            ModifyNameTextBox.Text = c.Name;

            int value = Convert.ToInt32(ModifyPriceListDropDownList.Items.FindByValue(c.PriceListHeaderID.ToString()).Value.ToString());
            ModifyPriceListDropDownList.SelectedValue = value.ToString();

            ChangeState(this, e);

            DataBind();

        }
        else if (e.CommandName == "ModifyCustomerContact")
        {
            //Int32 index = Convert.ToInt32(e.CommandArgument);
            //GridViewRow row = this.CustomerListGridView.Rows[index];

            EventArgs ev = new EventArgs();
            ChangeState += new EventHandler<EventArgs>(ModifyCustomerContact);

            PriceListHeaderUI pui = new PriceListHeaderUI();
            List<PriceListHeader> headerList = pui.GetAll();
            foreach (PriceListHeader priceListHeader in headerList)
                CustomerContactPriceListDropDownList.Items.Add(new ListItem(priceListHeader.PriceListName, priceListHeader.ID.ToString()));

            int id = Convert.ToInt32(e.CommandArgument);
            ModifyCustomerID = id;

            CustomerUI ui = new CustomerUI();
            Customer c = ui.GetWithContactDetails(id);

            int index = Convert.ToInt32(CustomerContactPriceListDropDownList.Items.FindByValue(c.PriceListHeaderID.ToString()).Value.ToString());
            CustomerContactPriceListDropDownList.SelectedValue = index.ToString();

            CustomerContactNameTextBox.Text = c.Name;

            DataBind();

            ChangeState(this, e);

            //UrlParameterPasser p = new UrlParameterPasser("ModifyCustomerContacts.aspx");
            //p["ID"] = e.CommandArgument.ToString();
            //p.PassParameters();
        }
        else if (e.CommandName == "DeleteCustomer")
        {
            CustomerUI ui = new CustomerUI();
            ui.DeleteCustomer(Convert.ToInt32(e.CommandArgument.ToString()));
            DataBind();
        }
    }
    #endregion

    #region DataList Handlers

    #region Outlist Store Data List Handlers
    protected void OutletStoreDataList_ItemCommand(object source, DataListCommandEventArgs e)
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
            ui.DeleteOutletStore(ModifyCustomerID, Convert.ToInt32(e.CommandArgument));
            fromList.SelectedIndex = -1;

            DataBind();
        }
        else if (e.CommandName == "Update")
        {
            fromList.SelectedIndex = e.Item.ItemIndex;

            Panel outletPanel = (Panel)e.Item.FindControl("SelectedPanel");

            Label idLabel = outletPanel.FindControl("IDLabel") as Label;
            TextBox shopNameTextBox = outletPanel.FindControl("ShopNameTextBox") as TextBox;
            TextBox addressLine1TextBox = outletPanel.FindControl("AddressLine1TextBox") as TextBox;
            TextBox addressLine2TextBox = outletPanel.FindControl("AddressLine2TextBox") as TextBox;
            TextBox openingHoursTextBox = outletPanel.FindControl("OpeningHoursTextBox") as TextBox;
            TextBox countyTextBox = outletPanel.FindControl("CountyTextBox") as TextBox;
            TextBox townTextBox = outletPanel.FindControl("TownTextBox") as TextBox;
            TextBox postCodeTextBox = outletPanel.FindControl("PostCodeTextBox") as TextBox;
            TextBox MapReferenceTextBox = outletPanel.FindControl("MapReferenceTextBox") as TextBox;
            TextBox notesTextBox = outletPanel.FindControl("NotesTextBox") as TextBox;

            OutletStore store = new OutletStore
            {
                ID = Convert.ToInt32(idLabel.Text),
                CustomerID = ModifyCustomerID,
                Name = shopNameTextBox.Text,
                OpeningHoursNotes = openingHoursTextBox.Text,
                Note = notesTextBox.Text,
                Address = new Address
                {
                    AddressLines = Utils.ConvertAddressLinesToXml(addressLine1TextBox, addressLine2TextBox),
                    Town = townTextBox.Text,
                    County = countyTextBox.Text,
                    PostCode = postCodeTextBox.Text,
                    MapReference = MapReferenceTextBox.Text
                }
            };

            CustomerUI ui = new CustomerUI();
            ui.UpdateOutletStore(store);

            fromList.SelectedIndex = -1;

            DataBind();
        }
    }

    protected void OutletStoreDataList_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {

        }

        if (e.Item.ItemType == ListItemType.SelectedItem)
        {
            // Reference the data bound to the DataListItem            
            OutletStore ou = ((OutletStore)e.Item.DataItem);

            //CustomerUI ui = new CustomerUI();
            //Customer customer = ui.GetWithOutletStores(id);
            //OutletStore outletStore = customer.OutletStore.Find(o => o.ID == ou.ID);

            Panel outletPanel = (Panel)e.Item.FindControl("SelectedPanel");

            Label idLabel = outletPanel.FindControl("IDLabel") as Label;
            idLabel.Text = ou.ID.ToString();

            TextBox shopNameTextBox = outletPanel.FindControl("ShopNameTextBox") as TextBox;
            shopNameTextBox.Text = ou.Name;

            List<string> addressLines = Utils.ConvertAddressLinesFromXml(ou.Address.AddressLines);

            TextBox addressLine1TextBox = outletPanel.FindControl("AddressLine1TextBox") as TextBox;
            addressLine1TextBox.Text = addressLines[0];

            TextBox addressLine2TextBox = outletPanel.FindControl("AddressLine2TextBox") as TextBox;
            if (addressLines.Count > 1)
                addressLine2TextBox.Text = addressLines[1];

            TextBox townTextBox = outletPanel.FindControl("TownTextBox") as TextBox;
            townTextBox.Text = ou.Address.Town;

            TextBox countyTextBox = outletPanel.FindControl("CountyTextBox") as TextBox;
            countyTextBox.Text = ou.Address.County;

            TextBox postCodeTextBox = outletPanel.FindControl("PostCodeTextBox") as TextBox;
            postCodeTextBox.Text = ou.Address.PostCode;

            TextBox mapReferenceTextBox = outletPanel.FindControl("MapReferenceTextBox") as TextBox;
            mapReferenceTextBox.Text = ou.Address.MapReference;

            TextBox openingHoursTextBox = outletPanel.FindControl("OpeningHoursTextBox") as TextBox;
            openingHoursTextBox.Text = ou.OpeningHoursNotes;

            TextBox notesTextBox = outletPanel.FindControl("NotesTextBox") as TextBox;
            notesTextBox.Text = ou.Note;
        }
    }
    #endregion

    #region Contact Details DataList Handlers

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
            ui.DeleteContactDetail(ModifyCustomerID, Convert.ToInt32(e.CommandArgument));
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
            TextBox EMailAddressTextBox = ContactPanel.FindControl("EMailAddressTextBox") as TextBox;

            ContactDetail Detail = new ContactDetail
            {
                ID = Convert.ToInt32(idLabel.Text),
                CustomerID = ModifyCustomerID,
                JobRole = JobRoleTextBox.Text,
                Title = TitleTextBox.Text,
                FirstName = FirstNameTextBox.Text,
                LastName = LastNameTextBox.Text,
                InitialNote = NotesTextBox.Text,
                EMailAddress = EMailAddressTextBox.Text,
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

            TextBox EMailAddressTextBox = ContactPanel.FindControl("EMailAddressTextBox") as TextBox;
            EMailAddressTextBox.Text = ou.EMailAddress;

            TextBox NotesTextBox = ContactPanel.FindControl("NotesTextBox") as TextBox;
            NotesTextBox.Text = ou.InitialNote;
        }
    }
    #endregion

    #endregion

    #region Object Data Source Events
    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        try
        {
            int i = 0;

            if (!String.IsNullOrEmpty(CustomerNameSearchTextBox.Text)) i++;
            if (!String.IsNullOrEmpty(TelephoneNoSearchTextBox.Text)) i++;
            if (!String.IsNullOrEmpty(AccountNoTextBox.Text)) i++;
            
            if(i > 1)
                throw new ApplicationException("You cannot search on more than one item");

            e.InputParameters[0] = CustomerNameSearchTextBox.Text;
            e.InputParameters[1] = TelephoneNoSearchTextBox.Text;
            e.InputParameters[2] = AccountNoTextBox.Text;
        }
        catch (Exception ex)
        {
            ErrorViewControl.AddError(ex.Message);
            ErrorViewControl.Visible = true;
        }
    }

    protected void ShopDataListObjectDataSource_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        e.InputParameters[0] = ModifyCustomerID;
    }
    #endregion

    #endregion

    #region Page States

    private void PageLoadState(object src, EventArgs mea)
    {
        ViewState["OutletStoreList"] = null;
        Util.ClearFields(this.Page);

        CustomerMenuPanel.Visible = true;
        AddCustomerPanel.Visible = false;


        AddShopPanel.Visible = false;
        ShopBasketPanel.Visible = false;

        CustomerSaveButton.Visible = false;
        CustomerListGridView.Visible = false;
        CustomerListGridViewPanel.Visible = false;
        ErrorViewControl.Visible = false;
        ModifyShopBasketPanel.Visible = false;
        ModifyCustomerPanel.Visible = false;

        AddCustomerContactPanel.Visible = false;
        AddContactPanel.Visible = false;
        ContactDataListPanel.Visible = false;
    }

    #region Adding Customer Panels
    private void AddCustomerState(object src, EventArgs mea)
    {
        CustomerMenuPanel.Visible = true;
        AddCustomerPanel.Visible = true;
        AddShopPanel.Visible = true;


        AddCustomerButton.Visible = false;
        CustomerSaveButton.Visible = false;
        CustomerListGridView.Visible = false;
        CustomerListGridViewPanel.Visible = false;
        ShopBasketPanel.Visible = false;
        ModifyShopBasketPanel.Visible = false;
        ModifyCustomerPanel.Visible = false;

        AddCustomerContactPanel.Visible = false;
        AddContactPanel.Visible = false;
        ContactDataListPanel.Visible = false;
    }

    private void AddNewCustomerState(object src, EventArgs mea)
    {
        CustomerMenuPanel.Visible = true;
        AddCustomerPanel.Visible = true;

        ShopBasketPanel.Visible = false;
        AddShopPanel.Visible = false;
        CustomerSaveButton.Visible = false;
        AddCustomerButton.Visible = true;
        CustomerListGridView.Visible = false;
        CustomerListGridViewPanel.Visible = false;
        ModifyShopBasketPanel.Visible = false;
        ModifyCustomerPanel.Visible = false;

        AddCustomerContactPanel.Visible = false;
        AddContactPanel.Visible = false;
        ContactDataListPanel.Visible = false;
    }

    private void AddedShopState(object src, EventArgs mea)
    {
        CustomerMenuPanel.Visible = true;

        AddCustomerPanel.Visible = true;
        AddShopPanel.Visible = true;

        CustomerSaveButton.Visible = true;
        CustomerListGridView.Visible = false;
        CustomerListGridViewPanel.Visible = false;
        ShopBasketPanel.Visible = true;
        Util.ClearControls(this.AddShopPanel);
        ModifyShopBasketPanel.Visible = false;
        ModifyCustomerPanel.Visible = false;

        AddCustomerContactPanel.Visible = false;
        AddContactPanel.Visible = false;
        ContactDataListPanel.Visible = false;
    }

    protected void DeletedOutletState(object sender, EventArgs e)
    {
        CustomerMenuPanel.Visible = true;
        AddCustomerPanel.Visible = true;
        AddShopPanel.Visible = true;
        CustomerSaveButton.Visible = true;
        ShopBasketPanel.Visible = true;


        CustomerListGridView.Visible = false;
        CustomerListGridViewPanel.Visible = false;

        ModifyShopBasketPanel.Visible = false;
        ModifyCustomerPanel.Visible = false;

        AddCustomerContactPanel.Visible = false;
        AddContactPanel.Visible = false;
        ContactDataListPanel.Visible = false;

        Util.ClearControls(this.AddShopPanel);

        Util.ClearControls(AddModifiedShopPanel);
    }

    private void CancelAddNewShopState(object src, EventArgs mea)
    {
        CustomerMenuPanel.Visible = true;
        AddCustomerPanel.Visible = false;
        AddShopPanel.Visible = false;
        ShopBasketPanel.Visible = false;

        CustomerSaveButton.Visible = false;
        CustomerListGridView.Visible = false;
        CustomerListGridViewPanel.Visible = false;
        ModifyShopBasketPanel.Visible = true;
        ErrorViewControl.Visible = false;

        ErrorViewControl.Visible = false;
        AddModifiedShopPanel.Visible = false;
        ModifyCustomerPanel.Visible = true;

        AddCustomerContactPanel.Visible = false;
        AddContactPanel.Visible = false;
        ContactDataListPanel.Visible = false;

        Util.ClearControls(AddModifiedShopPanel);
    }
    #endregion

    #region Modify Customer Shop States
    private void DisplayCustomerList(object src, EventArgs mea)
    {
        CustomerMenuPanel.Visible = true;
        CustomerListGridView.Visible = true;
        CustomerListGridViewPanel.Visible = true;

        AddShopPanel.Visible = false;
        AddCustomerPanel.Visible = false;
        AddShopPanel.Visible = false;
        ShopBasketPanel.Visible = false;
        ModifyShopBasketPanel.Visible = false;

        CustomerSaveButton.Visible = false;
        ErrorViewControl.Visible = false;
        ModifyCustomerPanel.Visible = false;

        AddCustomerContactPanel.Visible = false;
        AddContactPanel.Visible = false;

        Util.ClearControls(AddCustomerPanel);
    }

    private void EditShopState(object src, EventArgs mea)
    {
        CustomerMenuPanel.Visible = true;
        ModifyCustomerPanel.Visible = true;
        ModifyShopBasketPanel.Visible = true;

        CustomerListGridViewPanel.Visible = false;
        CustomerListGridView.Visible = false;
        AddModifiedShopPanel.Visible = false;
        AddCustomerPanel.Visible = false;

        AddShopPanel.Visible = false;
        ShopBasketPanel.Visible = false;

        AddCustomerContactPanel.Visible = false;

        CustomerSaveButton.Visible = false;

        ErrorViewControl.Visible = false;
        AddContactPanel.Visible = false;
    }

    private void AddingModifiedShopState(object src, EventArgs mea)
    {
        CustomerMenuPanel.Visible = true;
        ModifyCustomerPanel.Visible = true;
        ModifyShopBasketPanel.Visible = true;
        AddModifiedShopPanel.Visible = true;

        CustomerListGridViewPanel.Visible = false;
        CustomerListGridView.Visible = false;
        AddCustomerPanel.Visible = false;

        AddShopPanel.Visible = false;
        ShopBasketPanel.Visible = false;

        CustomerSaveButton.Visible = false;

        AddCustomerContactPanel.Visible = false;
        AddContactPanel.Visible = false;

        ErrorViewControl.Visible = false;
    }

    protected void AddedShopButtonState(object sender, EventArgs e)
    {
        CustomerMenuPanel.Visible = true;
        AddCustomerPanel.Visible = false;
        AddShopPanel.Visible = false;
        ShopBasketPanel.Visible = false;

        CustomerSaveButton.Visible = false;
        CustomerListGridView.Visible = false;
        CustomerListGridViewPanel.Visible = false;
        ErrorViewControl.Visible = false;
        ModifyShopBasketPanel.Visible = true;

        ErrorViewControl.Visible = false;
        AddModifiedShopPanel.Visible = false;
        ModifyCustomerPanel.Visible = true;

        AddCustomerContactPanel.Visible = false;
        AddContactPanel.Visible = false;

        Util.ClearControls(AddModifiedShopPanel);
    }

    #endregion

    #region Customer Contact Page States

    protected void ModifyCustomerContact(object sender, EventArgs e)
    {
        CustomerMenuPanel.Visible = true;
        AddCustomerContactPanel.Visible = true;

        AddCustomerPanel.Visible = false;
        AddShopPanel.Visible = false;
        ShopBasketPanel.Visible = false;

        CustomerSaveButton.Visible = false;
        CustomerListGridView.Visible = false;
        CustomerListGridViewPanel.Visible = false;
        ErrorViewControl.Visible = false;
        ModifyShopBasketPanel.Visible = false;

        ErrorViewControl.Visible = false;
        AddModifiedShopPanel.Visible = false;
        ModifyCustomerPanel.Visible = false;
        AddContactPanel.Visible = false;
        ContactDataListPanel.Visible = true;

        //    Util.ClearFields(this.Page);
    }

    protected void AddNewContactState(object sender, EventArgs e)
    {
        ViewState["OutletStoreList"] = null;
        //  Util.ClearFields(this.Page);

        CustomerMenuPanel.Visible = true;
        AddCustomerPanel.Visible = false;

        AddShopPanel.Visible = false;
        ShopBasketPanel.Visible = false;

        CustomerSaveButton.Visible = false;
        CustomerListGridView.Visible = false;
        CustomerListGridViewPanel.Visible = false;
        ErrorViewControl.Visible = false;
        ModifyShopBasketPanel.Visible = false;
        ModifyCustomerPanel.Visible = false;


        AddCustomerContactPanel.Visible = true;
        AddContactPanel.Visible = true;
        ContactDataListPanel.Visible = true;
    }

    protected void AddedContactButtonState(object sender, EventArgs e)
    {
        ViewState["OutletStoreList"] = null;
        //    Util.ClearFields(this.Page);

        CustomerMenuPanel.Visible = true;
        AddCustomerPanel.Visible = false;


        AddShopPanel.Visible = false;
        ShopBasketPanel.Visible = false;

        CustomerSaveButton.Visible = false;
        CustomerListGridView.Visible = false;
        CustomerListGridViewPanel.Visible = false;
        ErrorViewControl.Visible = false;
        ModifyShopBasketPanel.Visible = false;
        ModifyCustomerPanel.Visible = false;

        AddCustomerContactPanel.Visible = true;
        AddContactPanel.Visible = false;
        ContactDataListPanel.Visible = true;
    }

    protected void CancelAddContactButtonState(object sender, EventArgs e)
    {
        ViewState["OutletStoreList"] = null;

        CustomerMenuPanel.Visible = true;
        AddCustomerPanel.Visible = false;


        AddShopPanel.Visible = false;
        ShopBasketPanel.Visible = false;

        CustomerSaveButton.Visible = false;
        CustomerListGridView.Visible = false;
        CustomerListGridViewPanel.Visible = false;
        ErrorViewControl.Visible = false;
        ModifyShopBasketPanel.Visible = false;
        ModifyCustomerPanel.Visible = false;

        AddCustomerContactPanel.Visible = true;
        AddContactPanel.Visible = false;
        ContactDataListPanel.Visible = true;

        Util.ClearControls(AddContactPanel);
    }

    #endregion

    private void SearchProductState(object src, EventArgs mea)
    {
        ErrorViewControl.Visible = false;
    }

    #endregion
}
