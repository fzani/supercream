using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;

using AjaxControlToolkit;

using SP.Util;

using WcfFoundationService;

public partial class Admin_PriceList : System.Web.UI.Page
{
    #region Private Variables
    EventHandler<EventArgs> ChangeState;
    #endregion

    #region Accesors
    public int ProductID
    {
        get
        {
            if (ViewState["ProductID"] != null)
                return (int)ViewState["ProductID"];
            else
                return -1;
        }
        set
        {
            ViewState["ProductID"] = value;
        }
    }
    public int PriceListID
    {
        get
        {
            if (ViewState["PriceListID"] != null)
                return (int)ViewState["PriceListID"];
            else
                return -1;
        }
        set
        {
            ViewState["PriceListID"] = value;
        }
    }
    #endregion

    #region Page Handlers

    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ChangeState += new EventHandler<EventArgs>(PageLoadState);

            ProductUI pui = new ProductUI();

            ProductListFromListBox.DataSource = pui.GetAllProducts(null, null);

            ChangeState(this, e);

            DataBind();
        }
        else
            ErrorViewControl.Visible = false;
    }
    #endregion

    #region Page Events
    protected void DiscountTextBox_TextChanged(object sender, EventArgs e)
    {
        if (!String.IsNullOrEmpty(DiscountTextBox.Text))
        {
            Decimal originalPrice = Decimal.Parse(OriginalPriceLabel.Text, System.Globalization.NumberStyles.Currency);
            Decimal discount = Convert.ToDecimal(DiscountTextBox.Text);
            Decimal tmp = (originalPrice / 100) * discount;
            DiscountAppliedLabel.Text = String.Format("{0:c}", Math.Round((originalPrice - tmp), 2));
        }
        DiscountCheckBox.Checked = false;
    }
    #endregion

    #region Button Events
    protected void CreatePriceListButton_Click(object sender, EventArgs e)
    {
        try
        {
            EventArgs ev = new EventArgs();
            ChangeState += new EventHandler<EventArgs>(PageLoadState);

            CultureInfo ukCulture = new CultureInfo("en-GB");
            if (DateTime.Parse(DateEffectiveToTextBox.Text) < DateTime.Parse(DateEffectiveFromTextBox.Text))
                throw new ApplicationException("Date From cannot be passed the Date To");

            PriceListHeaderUI ui = new PriceListHeaderUI();
            PriceListHeader priceListHeader = new PriceListHeader
            {
                ID = -1,
                DateEffectiveFrom = DateTime.Parse(this.DateEffectiveFromTextBox.Text, ukCulture),
                PriceListName = this.NameTextBox.Text,
                DateEffectiveTo = DateTime.Parse(this.DateEffectiveFromTextBox.Text, ukCulture),
            };

            ui.SavePriceListHeader(priceListHeader);

            ChangeState(this, e);

            DataBind();
        }
        catch (Exception ex)
        {
            ErrorViewControl.AddError(ex.Message);
            ErrorViewControl.Visible = true;
        }
    }

    protected void AddNewPriceListButton_Click(object sender, EventArgs e)
    {
        try
        {
            EventArgs ev = new EventArgs();
            ChangeState += new EventHandler<EventArgs>(AddNewPriceListState);

            ChangeState(this, e);

            DataBind();
        }
        catch (Exception ex)
        {
            ErrorViewControl.AddError(ex.Message);
            ErrorViewControl.Visible = true;
        }
    }

    protected void AddPriceListButton_Click(object sender, EventArgs e)
    {
        EventArgs ev = new EventArgs();
        ChangeState += new EventHandler<EventArgs>(AddedPriceListState);

        ChangeState(this, e);

        DataBind();
    }

    protected void MaintainPriceListButton_Click(object sender, EventArgs e)
    {
        EventArgs ev = new EventArgs();
        ChangeState += new EventHandler<EventArgs>(MaintainPriceListState);

        ChangeState(this, e);
    }

    protected void SavePriceListItemButton_Click(object sender, EventArgs e)
    {
        EventArgs ev = new EventArgs();
        ChangeState += new EventHandler<EventArgs>(SelectMaintainPriceListState);

        PriceListItem item = new PriceListItem
        {
            ID = -1,
            Discount = Math.Round(Convert.ToDecimal(DiscountTextBox.Text), 2),
            ProductID = ProductID,
            PriceListID = PriceListID
        };
        PriceListItemUI ui = new PriceListItemUI();
        ui.Save(item);

        DataBind();

        ChangeState(this, e);
    }

    protected void SearchButton_Click(object sender, EventArgs e)
    {
        ChangeState += new EventHandler<EventArgs>(SearchProductState);
        ChangeState(this, e);
        DataBind();
    }

    protected void PriceListHeaderDataList_UpdateCommand(object source, EventArgs e)
    {
        try
        {
            ErrorViewControl.Visible = false; // reset error control
            Button btn = source as Button;

            GridViewRow row = this.PriceListGridView.Rows[Convert.ToInt32(btn.CommandArgument)];
            Panel messagePanel = row.FindControl("PanelMessage") as Panel;

            PriceListHeaderUI ui = new PriceListHeaderUI();
            int id = Convert.ToInt32((messagePanel.FindControl("ID") as Label).Text);

            TextBox priceListNameTextBox = messagePanel.FindControl("PriceListNameTextBox") as TextBox;
            if (String.IsNullOrEmpty(priceListNameTextBox.Text))
                throw new ApplicationException("Price List Header Name is a required name to update");

            TextBox dateEffectiveFromTextBox = row.FindControl("DateEffectiveFromTextBox") as TextBox;
            TextBox dateEffectiveToTextBox = row.FindControl("DateEffectiveToTextBox") as TextBox;

            DateTime effectiveFrom = Convert.ToDateTime(dateEffectiveFromTextBox.Text);
            DateTime effectiveTo = Convert.ToDateTime(dateEffectiveToTextBox.Text);

            PriceListHeader ph = new PriceListHeader
            {
                ID = id,
                PriceListName = priceListNameTextBox.Text,
                DateEffectiveFrom = effectiveFrom,
                DateEffectiveTo = effectiveTo
            };

            ui.Update(ph);

            DataBind();
        }
        catch (Exception ex)
        {
            ErrorViewControl.AddError(ex.Message);
            ErrorViewControl.Visible = true;
            ErrorViewControl.DataBind();
        }
    }

    protected void PriceListHeaderDataList_DeleteCommand(object source, EventArgs e)
    {
        try
        {
            ErrorViewControl.Visible = false; // reset error control         
            PriceListHeaderUI ui = new PriceListHeaderUI();

            Button btn = source as Button;
            int id = Convert.ToInt32(Convert.ToInt32(btn.CommandArgument));

            ui.DeleteID(id);

            DataBind();
        }
        catch (Exception ex)
        {
            ErrorViewControl.AddError(ex.Message);
            ErrorViewControl.Visible = true;
            ErrorViewControl.DataBind();
        }
    }

    #endregion

    #region ListBox events
    protected void MoveRightProductButton_Click(object sender, EventArgs e)
    {
        EventArgs ev = new EventArgs();
        ChangeState += new EventHandler<EventArgs>(MoveRightButtonState);

        while (ProductListFromListBox.Items.Count > 0 && ProductListFromListBox.SelectedItem != null)
        {
            ListItem selectedItem = ProductListFromListBox.SelectedItem;
            selectedItem.Selected = false;
            ProductListToListBox.Items.Add(selectedItem);
            ProductListFromListBox.Items.Remove(selectedItem);

            ProductUI ui = new ProductUI();
            Product product = ui.GetProductByID(Convert.ToInt32(selectedItem.Value));
            OriginalPriceLabel.Text = String.Format("{0:c}", product.UnitPrice);
            ProductID = product.ID;

            DataBind();

            ChangeState(this, e);
        }
    }

    protected void MoveLeftProductButton_Click(object sender, EventArgs e)
    {
        EventArgs ev = new EventArgs();
        ChangeState += new EventHandler<EventArgs>(MoveLeftButtonState);

        while (ProductListToListBox.Items.Count > 0 && ProductListToListBox.SelectedItem != null)
        {
            ListItem selectedItem = ProductListToListBox.SelectedItem;
            selectedItem.Selected = false;
            ProductListFromListBox.Items.Add(selectedItem);
            ProductListToListBox.Items.Remove(selectedItem);

            PriceListItemUI ui = new PriceListItemUI();
            ui.Delete(PriceListID, Convert.ToInt32(selectedItem.Value));

            ProductUI pui = new ProductUI();
            ProductListToListBox.DataSource = pui.GetProductsInPriceList(PriceListID);
            ProductListFromListBox.DataSource = pui.GetProductsOutOfPriceList(PriceListID);

            DataBind();
        }

        ChangeState(this, e);
    }
    #endregion

    #region PriceList Grid Events
    protected void PriceListGridView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Modify")
        {
            ChangeState += new EventHandler<EventArgs>(SelectMaintainPriceListState);
            ChangeState(this, e);

            int id = Convert.ToInt32(e.CommandArgument);

            PriceListID = id;

            ProductUI ui = new ProductUI();

            ProductListToListBox.DataSource = ui.GetProductsInPriceList(PriceListID);
            ProductListFromListBox.DataSource = ui.GetProductsOutOfPriceList(PriceListID);

            DataBind();
        }
        else if (e.CommandName == "SelectButton")
        {
            Int32 index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = this.PriceListGridView.Rows[index];

            Label idLabel = row.FindControl("ID") as Label;
            PriceListHeaderUI ui = new PriceListHeaderUI();
            PriceListHeader ph = ui.GetByID(Convert.ToInt32(idLabel.Text));

            Panel panelMessage = row.FindControl("PanelMessage") as Panel;
            TextBox priceListNameTextBox = panelMessage.FindControl("PriceListNameTextBox") as TextBox;
            priceListNameTextBox.Text = ph.PriceListName;

            TextBox dateEffectiveFromTextBox = row.FindControl("DateEffectiveFromTextBox") as TextBox;
            dateEffectiveFromTextBox.Text = ph.DateEffectiveFrom.ToShortDateString();

            TextBox dateEffectiveToTextBox = row.FindControl("DateEffectiveToTextBox") as TextBox;
            dateEffectiveToTextBox.Text = ph.DateEffectiveTo.ToShortDateString();

            ModalPopupExtender extender = row.FindControl("PopupControlExtender1") as ModalPopupExtender;
            extender.Show();

            ChangeState += new EventHandler<EventArgs>(MaintainPriceListState);
            ChangeState(this, e);
        }
    }
    #endregion

    #region Price List Item Handlers
    protected void PriceListItemDataList_ItemCommand(object source, DataListCommandEventArgs e)
    {
        DataList fromList = (DataList)source;
        if (e.CommandName == "Delete")
        {
            fromList.SelectedIndex = e.Item.ItemIndex;
            PriceListItemUI ui = new PriceListItemUI();
            ui.Delete(Convert.ToInt32(e.CommandArgument));
            fromList.SelectedIndex = -1;

            ProductUI pui = new ProductUI();

            ProductListToListBox.DataSource = pui.GetProductsInPriceList(PriceListID);
            ProductListFromListBox.DataSource = pui.GetProductsOutOfPriceList(PriceListID);

            DataBind();
        }
    }

    protected void PriceListItemDataList_EditCommand(object source, DataListCommandEventArgs e)
    {
        PriceListItemDataList.EditItemIndex = e.Item.ItemIndex;

        // Rebind the data to the DataList
        PriceListItemDataList.DataBind();
    }

    protected void PriceListItemDataList_CancelCommand(object source, DataListCommandEventArgs e)
    {
        PriceListItemDataList.EditItemIndex = -1;

        // Rebind the data to the DataList
        PriceListItemDataList.DataBind();
    }

    protected void PriceListItemDataList_UpdateCommand(object source, DataListCommandEventArgs e)
    {
        try
        {
            // Read in the Oid from the DataKeys collection
            int id = (int)PriceListItemDataList.DataKeys[e.Item.ItemIndex];

            Label ProductNameCodeLabel = e.Item.FindControl("ProductNameLabel") as Label;
            Label OriginalPriceLabel = e.Item.FindControl("OriginalPriceLabel") as Label;
            TextBox DiscountTextBox = e.Item.FindControl("DiscountTextBox") as TextBox;
            Label DiscountAppliedLabel = e.Item.FindControl("DiscountAppliedLabel") as Label;


            // Revert the DataList back to its pre-editing state
            PriceListItemDataList.EditItemIndex = -1;

            PriceListItem item = new PriceListItem
            {
                ID = id,
                Discount = Convert.ToDecimal(DiscountTextBox.Text)
            };

            PriceListItemUI pi = new PriceListItemUI();
            pi.UpdatePriceListItem(item);
            PriceListItemDataList.DataBind();
        }
        catch (Exception ex)
        {
            ErrorViewControl.AddError(ex.Message);
            ErrorViewControl.Visible = true;
        }
    }
    #endregion

    #region Object Data Source Events

    protected void ObjectDataSource2_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        e.InputParameters[0] = PriceListID;
    }

    #endregion

    #region Page States

    /*****************************************************************
     * Page States
     *****************************************************************/
    private void PageLoadState(object src, EventArgs mea)
    {
        ViewState["OutletStoreList"] = null;
        Util.ClearFields(this.Page);

        NewPriceListPanel.Visible = false;
        SetupPriceListPanel.Visible = false;
        SetupNewPriceListPanel.Visible = true;
        EnterPricePanel.Visible = false;
        AddPriceListPanel.Visible = false;
        PriceListDataGridPanel.Visible = false;
        ErrorViewControl.Visible = false;
        PriceListItemPanel.Visible = false;
        MoveRightProductButton.Visible = false;
        MoveLeftProductButton.Visible = false;
    }

    private void AddPriceListState(object src, EventArgs mea)
    {
        NewPriceListPanel.Visible = true;
        SetupPriceListPanel.Visible = true;

        SetupNewPriceListPanel.Visible = false;
        AddPriceListButton.Visible = false;
        AddPriceListPanel.Visible = false;
        EnterPricePanel.Visible = false;
        PriceListDataGridPanel.Visible = false;
        PriceListItemPanel.Visible = false;
        MoveRightProductButton.Visible = false;
        MoveLeftProductButton.Visible = false;
    }

    private void AddNewPriceListState(object src, EventArgs mea)
    {
        NewPriceListPanel.Visible = true;
        SetupNewPriceListPanel.Visible = true;

        SetupPriceListPanel.Visible = false;
        EnterPricePanel.Visible = false;
        AddPriceListButton.Visible = false;
        AddPriceListPanel.Visible = false;
        PriceListDataGridPanel.Visible = false;
        PriceListItemPanel.Visible = false;
        MoveRightProductButton.Visible = false;
        MoveLeftProductButton.Visible = false;
    }

    private void AddedPriceListState(object src, EventArgs mea)
    {
        SetupNewPriceListPanel.Visible = true;
        NewPriceListPanel.Visible = true;
        SetupPriceListPanel.Visible = true;
        AddPriceListButton.Visible = true;

        AddPriceListPanel.Visible = false;
        EnterPricePanel.Visible = false;
        PriceListDataGridPanel.Visible = false;
        Util.ClearControls(this.SetupPriceListPanel);
        PriceListItemPanel.Visible = false;
        MoveRightProductButton.Visible = false;
        MoveLeftProductButton.Visible = false;
    }

    private void MaintainPriceListState(object src, EventArgs e)
    {
        // XXXXXXXXXXXXXXXXXXXXXXXXXXXX
        SetupNewPriceListPanel.Visible = true;
        EnterPricePanel.Visible = false;
        PriceListDataGridPanel.Visible = true;

        NewPriceListPanel.Visible = false;
        AddPriceListPanel.Visible = false;
        SetupPriceListPanel.Visible = false;
        AddPriceListButton.Visible = false;
        PriceListItemPanel.Visible = false;
        MoveRightProductButton.Visible = false;
        MoveLeftProductButton.Visible = false;

    }

    private void MoveLeftButtonState(object src, EventArgs mea)
    {
        NewPriceListPanel.Visible = true;
        SetupPriceListPanel.Visible = false;
        AddPriceListPanel.Visible = true;
        PriceListDataGridPanel.Visible = true;
        PriceListItemPanel.Visible = true;

        SetupNewPriceListPanel.Visible = false;
        EnterPricePanel.Visible = false;



        MoveRightProductButton.Visible = true;
        MoveLeftProductButton.Visible = true;
        //  Util.ClearControls(this.SetupPriceListPanel);
    }

    private void MoveRightButtonState(object src, EventArgs mea)
    {
        NewPriceListPanel.Visible = true;
        EnterPricePanel.Visible = true;

        PriceListDataGridPanel.Visible = true;
        SetupPriceListPanel.Visible = false;
        SetupNewPriceListPanel.Visible = false;
        AddPriceListPanel.Visible = true;

        PriceListItemPanel.Visible = true;

        DiscountAppliedLabel.Text = "";
        DiscountTextBox.Text = "";
        MoveRightProductButton.Visible = false;
        MoveLeftProductButton.Visible = false;
        // Util.ClearControls(this.SetupPriceListPanel);
    }

    private void SelectMaintainPriceListState(object src, EventArgs e)
    {
        SetupNewPriceListPanel.Visible = true;
        PriceListDataGridPanel.Visible = true;
        AddPriceListPanel.Visible = true;
        PriceListItemPanel.Visible = true;

        NewPriceListPanel.Visible = false;

        SetupPriceListPanel.Visible = false;
        EnterPricePanel.Visible = false;
        AddPriceListButton.Visible = false;

        MoveRightProductButton.Visible = true;
        MoveLeftProductButton.Visible = true;
    }

    private void DisplayPriceListList(object src, EventArgs mea)
    {
        SetupPriceListPanel.Visible = false;
        NewPriceListPanel.Visible = false;
        SetupPriceListPanel.Visible = false;
        EnterPricePanel.Visible = false;
        PriceListDataGridPanel.Visible = false;

        SetupNewPriceListPanel.Visible = false;
        AddPriceListPanel.Visible = false;
        ErrorViewControl.Visible = false;
        PriceListItemPanel.Visible = false;

        MoveRightProductButton.Visible = false;
        MoveLeftProductButton.Visible = false;
    }

    private void SearchProductState(object src, EventArgs mea)
    {
        ErrorViewControl.Visible = false;
    }

    #endregion

    #endregion  
}
