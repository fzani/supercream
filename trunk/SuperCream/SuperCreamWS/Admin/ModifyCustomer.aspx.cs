using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;

using SP.Util;

using WcfFoundationService;

public partial class Modify_Customer : System.Web.UI.Page
{
    EventHandler<EventArgs> ChangeState;

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
            if (!IsPostBack)
            {
                ChangeState += new EventHandler<EventArgs>(PageLoadState);

                PriceListHeaderUI pui = new PriceListHeaderUI();
                List<PriceListHeader> headerList = pui.GetAll();
                foreach (PriceListHeader priceListHeader in headerList)
                    ModifyPriceListDropDownList.Items.Add(new ListItem(priceListHeader.PriceListName, priceListHeader.ID.ToString()));

                ChangeState(this, e);
            }

            UrlParameterPasser p = new UrlParameterPasser();
            int id = Convert.ToInt32(p["ID"]);

            CustomerUI ui = new CustomerUI();
            Customer c = ui.GetWithOutletStores(id);

            ModifyCustomerID = id; // Serialise to View State

            //foreach(OutletStore 
            ModifyNameTextBox.Text = c.Name;

            int index = Convert.ToInt32(ModifyPriceListDropDownList.Items.FindByValue(c.PriceListHeaderID.ToString()).Value.ToString()) - 1;
            ModifyPriceListDropDownList.SelectedIndex = index;

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

    protected void ModifyShopButton_Click(object sender, EventArgs e)
    {
        ChangeState += new EventHandler<EventArgs>(AddNewShopState);
        ChangeState(this, e);
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
                    PostCode = ModifiedPostCodeTextBox.Text
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

    protected void CancelModifiedShopButton_Click(object sender, EventArgs e)
    {
        ChangeState += new EventHandler<EventArgs>(AddedShopButtonState);
        ChangeState(this, e);
    }

    protected void CustomerSaveButton_Click(object sender, EventArgs e)
    {
        try
        {
            CustomerUI ui = new CustomerUI();

            Customer customer = new Customer()
            {
                ID = ModifyCustomerID.Value,
                Name = ModifyNameTextBox.Text,
                PriceListHeaderID = Convert.ToInt32(ModifyPriceListDropDownList.SelectedValue)
            };

            ui.UpdateCustomer(customer);

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
                    PostCode = postCodeTextBox.Text
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
            addressLine2TextBox.Text = addressLines[1];

            TextBox townTextBox = outletPanel.FindControl("TownTextBox") as TextBox;
            townTextBox.Text = ou.Address.Town;

            TextBox countyTextBox = outletPanel.FindControl("CountyTextBox") as TextBox;
            countyTextBox.Text = ou.Address.County;

            TextBox postCodeTextBox = outletPanel.FindControl("PostCodeTextBox") as TextBox;
            postCodeTextBox.Text = ou.Address.PostCode;

            TextBox openingHoursTextBox = outletPanel.FindControl("OpeningHoursTextBox") as TextBox;
            openingHoursTextBox.Text = ou.OpeningHoursNotes;

            TextBox notesTextBox = outletPanel.FindControl("NotesTextBox") as TextBox;
            notesTextBox.Text = ou.Note;
        }
    }

    #endregion

    #region Page States
    private void PageLoadState(object src, EventArgs mea)
    {
        Util.ClearFields(this.Page);
        ErrorViewControl.Visible = false;
        ModifyHeaderCustomerPanel.Visible = true;

        AddModifiedShopPanel.Visible = false;

    }

    private void AddNewShopState(object src, EventArgs mea)
    {
        ErrorViewControl.Visible = false;
        AddModifiedShopPanel.Visible = true;
        ModifyHeaderCustomerPanel.Visible = true;
    }

    protected void AddedShopButtonState(object sender, EventArgs e)
    {
        Util.ClearControls(AddModifiedShopPanel);
        ErrorViewControl.Visible = false;
        AddModifiedShopPanel.Visible = false;
        ModifyHeaderCustomerPanel.Visible = true;
    }

    private void CancelAddNewShopState(object src, EventArgs mea)
    {
        Util.ClearControls(AddModifiedShopPanel);
        ErrorViewControl.Visible = false;
        AddModifiedShopPanel.Visible = false;
        ModifyHeaderCustomerPanel.Visible = true;
    }

    #endregion
}
