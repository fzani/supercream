using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using WcfFoundationService;
using AjaxControlToolkit;

using SP.Utils;
using System.Data;
using Microsoft.Reporting.WebForms;
using SP.Core.Enums;

public partial class Controls_MaintainDeliveryNote : System.Web.UI.UserControl
{
    #region Private Member Variables
    EventHandler<EventArgs> ChangeState;
    #endregion

    #region Public Event Handlers
    public event ErrorMessageEventHandler ErrorMessageEventHandler;
    #endregion

    #region Page Load event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ChangeState += new EventHandler<EventArgs>(PageLoadState);
            ChangeState(this, e);
        }
    }
    #endregion

    #region public Accesors
    public int? OrderID
    {
        get
        {
            return (ViewState["OrderID"] == null) ? -1 : (int)ViewState["OrderID"];
        }
        set
        {
            ViewState["OrderID"] = value;
        }
    }

    public int? OrderNoteStatusID
    {
        get
        {
            return (ViewState["OrderNoteStatusID"] == null) ? -1 : (int)ViewState["OrderNoteStatusID"];
        }
        set
        {
            ViewState["OrderNoteStatusID"] = value;
        }
    }
    #endregion

    #region General Event Handlers
    protected void SearchButton_Click(object sender, EventArgs e)
    {
        DeliveryNoteGridView.DataBind();
    }

    protected void ConfirmDeliveryNote_Click(object sender, EventArgs e)
    {
        try
        {
            OrderNotesStatus status = new OrderNotesStatus
            {
                ID = -1,
                AccountID = Convert.ToInt32(AccountDropDownList.SelectedValue),
                VanID = Convert.ToInt32(DeliveryVanDropDownList.SelectedValue),
                OutletStoreID = Convert.ToInt32(DeliveryDropDownList.SelectedValue),
                DeliveryNoteDatePrinted = Defaults.MinDateTime,
                DeliveryNotePrinted = false,
                InvoiceDatePrinted = Defaults.MinDateTime,
                InvoicePrinted = false,
                InvoiceDateReprinted = Defaults.MinDateTime,
                InvoiceProformaDatePrinted = Defaults.MinDateTime,
                InvoiceProformaPrinted = false,
                InvoiceReprinted = false,
                OrderID = OrderID.Value,
                PicklistDateGenerated = Defaults.MinDateTime,
                PicklistGenerated = false,
                DeliveryNoteDateCreated = Defaults.MinDateTime,
                InvoiceDateCreated = Defaults.MinDateTime,
                InvoicePaymentComplete = false,
                InvoiceProformaDateCreated = Defaults.MinDateTime
            };

            OrderNotesStatusUI ui = new OrderNotesStatusUI();
            ui.Save(status);

            var orderHeader = new OrderHeaderUI().GetById(OrderID.Value);

            AuditEventsUI.LogEvent("Created Delivery Note", orderHeader.DeliveryNoteNo, Page.ToString(),
                    AuditEventsUI.AuditEventType.Creating);

            ChangeState += new EventHandler<EventArgs>(PageLoadState);
            ChangeState(this, e);

            DataBind();
        }
        catch (Exception ex)
        {
            ErrorMessageEventArgs args = new ErrorMessageEventArgs();
            args.AddErrorMessages(ex.Message);
            ErrorMessageEventHandler(this, args);
        }
    }

    protected void ChangeDeliveryNoteDetailsButton_Click(object sender, EventArgs e)
    {
        try
        {
            OrderNotesStatus status = new OrderNotesStatus
            {
                ID = OrderNoteStatusID.Value,
                AccountID = Convert.ToInt32(AccountDropDownList.SelectedValue),
                VanID = Convert.ToInt32(DeliveryVanDropDownList.SelectedValue),
                OutletStoreID = Convert.ToInt32(this.DeliveryDropDownList.SelectedValue),
                DeliveryNoteDatePrinted = Defaults.MinDateTime,
                DeliveryNotePrinted = false,
                InvoiceDatePrinted = Defaults.MinDateTime,
                InvoicePrinted = false,
                InvoiceDateReprinted = Defaults.MinDateTime,
                InvoiceProformaDatePrinted = Defaults.MinDateTime,
                InvoiceProformaPrinted = false,
                InvoiceReprinted = false,
                OrderID = OrderID.Value,
                PicklistDateGenerated = Defaults.MinDateTime,
                PicklistGenerated = false,
                DeliveryNoteDateCreated = Defaults.MinDateTime,
                InvoiceDateCreated = Defaults.MinDateTime,
                InvoicePaymentComplete = false,
                InvoiceProformaDateCreated = Defaults.MinDateTime
            };
            OrderNotesStatusUI ui = new OrderNotesStatusUI();
            ui.Update(status);

            var orderHeader = new OrderHeaderUI().GetById(OrderID.Value);
            AuditEventsUI.LogEvent("Updated Delivery Note", orderHeader.DeliveryNoteNo, Page.ToString(),
                  AuditEventsUI.AuditEventType.Modifying);

            ChangeState += new EventHandler<EventArgs>(PageLoadState);
            ChangeState(this, e);
        }
        catch (Exception ex)
        {
            ErrorMessageEventArgs args = new ErrorMessageEventArgs();
            args.AddErrorMessages(ex.Message);
            ErrorMessageEventHandler(this, args);
        }
    }

    protected void CancelInvoiceButton_Click(object sender, EventArgs e)
    {
        try
        {
            OrderNotesStatusUI ui = new OrderNotesStatusUI();
            ui.DeleteOrderNote(OrderNoteStatusID.Value);

            OrderHeaderUI orderHeaderUI = new OrderHeaderUI();
            OrderHeader header = orderHeaderUI.GetWithVatCodeById(OrderID.Value);
            header.OrderStatus = (short)SP.Core.Enums.OrderStatus.Order;
            orderHeaderUI.UpdateForInvoice(header);

            var orderHeader = new OrderHeaderUI().GetById(OrderID.Value);
            AuditEventsUI.LogEvent("Cancelling Delivery Note", header.DeliveryNoteNo, Page.ToString(),
                  AuditEventsUI.AuditEventType.Deleting);

            ChangeState += new EventHandler<EventArgs>(PageLoadState);
            ChangeState(this, e);

            DataBind();
        }
        catch (Exception ex)
        {
            ErrorMessageEventArgs args = new ErrorMessageEventArgs();
            args.AddErrorMessages(ex.Message);
            ErrorMessageEventHandler(this, args);
        }
    }

    protected void ShowInvoiceButton_Click(object sender, EventArgs e)
    {
        this.InvoiceDateTextBox.Text = DateTime.Now.AddDays(1).ToString();
        ModalPopupExtenderCreateInvoice.Show();
    }

    protected void ConvertToInvoice_Click(object sender, EventArgs e)
    {
        try
        {
            var orderHeaderUi = new OrderHeaderUI();

            if (new OrderNotesStatusUI().OrderNoteExistsByOrderID(OrderID.Value))
            {
                UpdateOrderHeaderToInvoice(orderHeaderUi);
                UpdateInvoiceCreatedDateOnOrderNoteStatus();
            }
            else
            {
                orderHeaderUi.CreateInvoice(OrderID.Value, DateTime.Parse(InvoiceDateTextBox.Text));
            }

            var orderHeader = new OrderHeaderUI().GetById(OrderID.Value);
            AuditEventsUI.LogEvent("Convert to invoice", orderHeader.DeliveryNoteNo, Page.ToString(),
                  AuditEventsUI.AuditEventType.Modifying);

            ChangeState += new EventHandler<EventArgs>(PageLoadState);
            ChangeState(this, e);
            DataBind();
        }
        catch (Exception ex)
        {
            ErrorMessageEventArgs args = new ErrorMessageEventArgs();
            args.AddErrorMessages(ex.Message);
            ErrorMessageEventHandler(this, args);
        }
    }

    protected void CancelDeliveryButton_Click(object sender, EventArgs e)
    {
        ChangeState += new EventHandler<EventArgs>(PageLoadState);
        ChangeState(this, e);

        DataBind();
    }

    protected void ClearButton_Click(object sender, EventArgs e)
    {
        Util.ClearControls(DeliveryNoteSearchCriteriaPanel);
        DataBind();
    }

    protected void DeliveryDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DeliveryDropDownList.SelectedValue != "-1")
        {
            PopulateInvoice(e);
        }
        else
        {
            ChangeState += new EventHandler<EventArgs>(DeliveryNotSelected);
            ChangeState(this, e);
        }

        DataBind();
    }

    protected void DeliveryVanDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        DeliveryNoteRepeater.DataBind();
    }

    protected void DeliveryNotesDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        DeliveryNoteGridView.DataBind();
    }

    protected void PrintDeliveryNoteButton_Click(object sender, EventArgs e)
    {
        try
        {
            int orderID = this.OrderID.Value;
            int accountId = Convert.ToInt32(AccountDropDownList.SelectedValue);
            int outletStoreId = Convert.ToInt32(DeliveryDropDownList.SelectedValue);

            DataSet[] dataSets = new DataSet[5];

            IReportDataSets reportDataSets = new ReportDataSets();
            ReportDataSource[] reportDataSources = reportDataSets.GetReportDataSets(orderID, accountId, outletStoreId);

            PrintReport printReport = new PrintReport();
            printReport.Run("DeliveryNotePrint.rdlc", reportDataSources, PageMode.Portrait, Profile.PrinterName);
            OKModalPopupExtender.Show();

            OrderHeaderUI orderHeaderUI = new OrderHeaderUI();
            OrderHeader orderHeader = orderHeaderUI.GetWithVatCodeById(orderID);
            orderHeader.OrderStatus = (short)OrderStatus.DeliveryNotePrinted;
            orderHeaderUI.UpdateForInvoice(orderHeader);

            OrderNotesStatusUI ui = new OrderNotesStatusUI();
            OrderNotesStatus orderNoteStatus = ui.GetOrderNotesStatusByOrderID(orderID);
            orderNoteStatus.DeliveryNoteDatePrinted = DateTime.Now;
            orderNoteStatus.DeliveryNotePrinted = true;
            ui.Update(orderNoteStatus);
          
            AuditEventsUI.LogEvent("Printing invoice", orderHeader.DeliveryNoteNo, Page.ToString(),
                  AuditEventsUI.AuditEventType.Modifying);

            PrintDeliveryNoteButton.Visible = true;
            //// NewPrinting.Run(@"Report1.rdlc", "\\\\paris\\Samsung CLP-310 Series", ds.Tables[0], "SuperCreamDBDataSet_InvoiceHeader"); 
            // printReport.Run("InvoicePrint.rdl", dataSets, PageMode.Portrait);
        }
        catch (System.Exception ex)
        {
            PrintFailedPopupControlExtender.Show();
            Panel printPanel = FindControl("PrintPanelMessage") as Panel;
            TextBox errorTextBox = printPanel.FindControl("ErrorTextBox") as TextBox;
            if (ex.InnerException != null)
            {
                errorTextBox.Text = ex.InnerException.Message;
            }
            else
            {
                errorTextBox.Text = ex.Message;
            }
        }
    }

    #endregion

    #region Data Grid Events
    protected void DeliveryNoteGridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            OrderHeader orderHeader = e.Row.DataItem as OrderHeader;

            int customerID = orderHeader.CustomerID;

            CustomerUI ui = new CustomerUI();
            Customer customer = ui.GetByID(customerID);

            Image confirmedImage = e.Row.FindControl("ConfirmedImage") as Image;
            if (confirmedImage != null)
            {
                if (orderHeader.ID != -1)
                {
                    OrderNotesStatusUI orderNotesStatusUI = new OrderNotesStatusUI();
                    if (orderNotesStatusUI.OrderNoteExistsByOrderID(orderHeader.ID))
                    {
                        confirmedImage.Visible = true;
                    }
                    else
                    {
                        confirmedImage.Visible = false;
                    }
                }
            }

            Label customerNameLabel = e.Row.FindControl("CustomerNameLabel") as Label;
            customerNameLabel.Text = customer.Name;
        }
    }

    protected void DeliveryNoteGridView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            int id = Convert.ToInt32(e.CommandArgument);

            OrderHeaderUI orderHeaderUI = new OrderHeaderUI();
            OrderHeader orderHeader = orderHeaderUI.GetById(id);

            OrderID = orderHeader.ID;
            OrderHeaderNoLabel.Text = orderHeader.AlphaID;

            int customerID = orderHeader.CustomerID;

            CustomerUI customerUI = new CustomerUI();
            Customer customer = customerUI.GetByID(customerID);

            List<Account> accounts = customer.Account;

            Action<Account> accountAction =
                new Action<Account>(a => AccountDropDownList.Items.Add(new ListItem(a.AlphaID.ToString(), a.ID.ToString())));

            AccountDropDownList.Items.Clear();
            AccountDropDownList.Items.Add(new ListItem("-- No Item Selected --", "-1"));
            customer.Account.ForEach(accountAction);

            ChangeState += new EventHandler<EventArgs>(SelectedOrderState);
            ChangeState(this, e);

            List<OutletStore> outletStore = customer.OutletStore;

            Action<OutletStore> outletStoreAction =
                new Action<OutletStore>(a => DeliveryDropDownList.Items.Add(new ListItem(a.Name.ToString(), a.ID.ToString())));

            DeliveryDropDownList.Items.Clear();
            DeliveryDropDownList.Items.Add(new ListItem("-- No Item Selected --", "-1"));
            customer.OutletStore.ForEach(outletStoreAction);

            ChangeState += new EventHandler<EventArgs>(SelectedOrderState);
            ChangeState(this, e);

            OrderNotesStatusUI orderNotesStatusUI = new OrderNotesStatusUI();
            if (orderNotesStatusUI.OrderNoteExistsByOrderID(OrderID.Value))
            {
                ConfirmDelivery.Visible = false;
                ChangeDeliveryNoteDetailsButton.Visible = true;
                CancelDeliveryNoteButton.Visible = true;
                CreateInvoiceButton.Visible = true;

                // Now Select Delivery using Create OrderNotes record ...
                OrderNotesStatus orderNoteStatus = orderNotesStatusUI.GetOrderNotesStatusByOrderID(OrderID.Value);
                OrderNoteStatusID = orderNoteStatus.ID;
                if (orderNoteStatus.InvoicePrinted)
                {
                    PrintDeliveryNoteButton.Visible = false;
                    RePrintDeliveryButton.Visible = true;
                }
                else
                {
                    PrintDeliveryNoteButton.Visible = true;
                    RePrintDeliveryButton.Visible = false;
                }

                DeliveryDropDownList.SelectedValue = orderNoteStatus.OutletStoreID.ToString();
                DeliveryVanDropDownList.SelectedValue = orderNoteStatus.VanID.ToString();
                AccountDropDownList.SelectedValue = orderNoteStatus.AccountID.ToString();

                PopulateInvoice(e);
            }
            else
            {
                ConfirmDelivery.Visible = true;
                ChangeDeliveryNoteDetailsButton.Visible = false;
                PrintDeliveryNoteButton.Visible = false;
                RePrintDeliveryButton.Visible = false;
                CancelDeliveryNoteButton.Visible = false;
                CreateInvoiceButton.Visible = false;
            }

            DataBind();
        }
    }
    #endregion

    #region Page States
    public void PageLoadState(object sender, EventArgs args)
    {
        DeliveryNoteSearchCriteriaPanel.Visible = true;
        DeliveryNoteHeaderSearchGridPanel.Visible = true;

        DeliveryNoteEntryPanel.Visible = false;
        DisplayDeliveryNotePanel.Visible = false;
        OrderHeaderDetailsPanel.Visible = false;
        DeliveryNoteRepeater.Visible = false;
    }

    public void SelectedOrderState(object sender, EventArgs args)
    {
        DeliveryNoteSearchCriteriaPanel.Visible = false;
        DeliveryNoteHeaderSearchGridPanel.Visible = false;

        DeliveryNoteEntryPanel.Visible = true;
        DisplayDeliveryNotePanel.Visible = false;
        DeliveryNoteRepeater.Visible = false;
        OrderHeaderDetailsPanel.Visible = false;
    }

    public void DeliveryNotSelected(object sender, EventArgs args)
    {
        DeliveryNoteSearchCriteriaPanel.Visible = false;
        DeliveryNoteHeaderSearchGridPanel.Visible = false;

        DeliveryNoteEntryPanel.Visible = true;
        DisplayDeliveryNotePanel.Visible = false;
        DeliveryNoteRepeater.Visible = false;
        OrderHeaderDetailsPanel.Visible = false;
    }

    public void DeliverySelectedState(object sender, EventArgs args)
    {
        DeliveryNoteSearchCriteriaPanel.Visible = false;
        DeliveryNoteHeaderSearchGridPanel.Visible = false;

        DeliveryNoteEntryPanel.Visible = true;
        DisplayDeliveryNotePanel.Visible = true;
        DeliveryNoteRepeater.Visible = true;
        OrderHeaderDetailsPanel.Visible = true;
    }

    #endregion

    #region Object Data Source Events

    protected void DeliveryNoteObjectDataSource_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        e.InputParameters[0] = OrderNoSearchTextBox.Text;
        e.InputParameters[1] = String.Empty;
        e.InputParameters[2] = CustomerNameSearchTextBox.Text;
        if (!String.IsNullOrEmpty(DateFromTextBox.Text))
            e.InputParameters[3] = Convert.ToDateTime(DateFromTextBox.Text);
        else
            e.InputParameters[3] = String.Empty;

        if (!String.IsNullOrEmpty(DateToTextBox.Text))
            e.InputParameters[4] = Convert.ToDateTime(DateToTextBox.Text);
        else
            e.InputParameters[4] = String.Empty;

        switch (Convert.ToInt32(DeliveryNotesPrintedDropDownList.SelectedValue))
        {
            case -1:
                e.InputParameters[5] = (short)SP.Core.Enums.OrderStatus.DeliveryNote;
                e.InputParameters[6] = (short)SP.Core.Enums.OrderStatus.DeliveryNotePrinted;
                break;
            case (short)SP.Core.Enums.OrderStatus.DeliveryNote:
                e.InputParameters[5] = (short)SP.Core.Enums.OrderStatus.DeliveryNote;
                e.InputParameters[6] = (short)(-1);
                break;
            case (short)SP.Core.Enums.OrderStatus.DeliveryNotePrinted:
                e.InputParameters[5] = (short)(-1);
                e.InputParameters[6] = (short)SP.Core.Enums.OrderStatus.DeliveryNotePrinted;
                break;
        }
    }

    #endregion

    #region Invoice Repeater Event Handlers

    int totalRowCount = 0;

    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            totalRowCount++;

            OrderLine line = e.Item.DataItem as OrderLine;

            ProductUI ui = new ProductUI();
            Product p = ui.GetProductByID(line.ProductID);

            Label descriptionLabel = e.Item.FindControl("DescriptionLabel") as Label;
            descriptionLabel.Text = p.Description;

            Label rrpLabel = e.Item.FindControl("RRPLabel") as Label;
            rrpLabel.Text = String.Format("{0:c}", line.RRPPerItem);

            Label noOfUnitsLabel = e.Item.FindControl("NoOfUnitsLabel") as Label;
            int noOfUnits = Convert.ToInt32(noOfUnitsLabel.Text);

            Label specialInstructionsNameLabel = e.Item.FindControl("SpecialInstructionsNameLabel") as Label;
            TextBox specialInstructionsTextBox = e.Item.FindControl("SpecialInstructionsTextBox") as TextBox;

            if (!String.IsNullOrEmpty(line.SpecialInstructions))
            {

                specialInstructionsNameLabel.Visible = true;
                specialInstructionsTextBox.Visible = true;
                specialInstructionsTextBox.Text = line.SpecialInstructions;
            }
            else
            {
                specialInstructionsNameLabel.Visible = false;
                specialInstructionsTextBox.Visible = false;
            }
        }
        if (e.Item.ItemType == ListItemType.Footer)
        {
            Label totalItemsLabel = e.Item.FindControl("TotalItemsLabel") as Label;
            totalItemsLabel.Text = totalRowCount.ToString();

            if (OrderID != -1)
            {
                OrderHeaderUI headerUI = new OrderHeaderUI();
                OrderHeader orderHeader = headerUI.GetById(OrderID.Value);

                TextBox specialInstructionsTextBox = e.Item.FindControl("SpecialInstructionsHeaderTextBox") as TextBox;
                specialInstructionsTextBox.Text = orderHeader.SpecialInstructions;

                Label deliveryDateLabel = e.Item.FindControl("DeliveryDateLabel") as Label;
                deliveryDateLabel.Text = orderHeader.DeliveryDate.ToShortDateString();
            }

            totalRowCount = 0;
        }
    }
    #endregion

    #region Private Helpers

    private void UpdateOrderHeaderToInvoice(OrderHeaderUI orderHeaderUi)
    {
        if (OrderID.HasValue)
            orderHeaderUi.UpdateToInvoice(OrderID.Value, DateTime.Parse(InvoiceDateTextBox.Text));
    }

    private void UpdateInvoiceCreatedDateOnOrderNoteStatus()
    {
        var orderNotesStatusUI = new OrderNotesStatusUI();
        var orderNotesStatus = orderNotesStatusUI.GetOrderNotesStatusByOrderID(OrderID.Value);

        orderNotesStatus.InvoiceDateCreated = DateTime.Now;
        orderNotesStatusUI.Update(orderNotesStatus);
    }

    #endregion

    #region Util Methods
    void PopulateInvoice(EventArgs e)
    {
        ChangeState += new EventHandler<EventArgs>(DeliverySelectedState);
        ChangeState(this, e);

        // Deal with Order Header Details
        OrderHeaderUI orderHeaderUI = new OrderHeaderUI();
        OrderHeader orderHeader = orderHeaderUI.GetById(OrderID.Value);

        DateOfOrderLabel.Text = orderHeader.OrderDate.ToShortDateString();
        DeliveryNoteNoLabel.Text = orderHeader.DeliveryNoteNo;

        // Get Delivery Details
        int outletID = Convert.ToInt32(DeliveryDropDownList.SelectedValue);
        OutletStoreUI outletStoreUI = new OutletStoreUI();
        OutletStore outletStore = outletStoreUI.GetOutletStore(outletID);

        AddressUI addressUI = new AddressUI();
        outletStore.Address = addressUI.GetByID(outletStore.AddressID);

        CustomerCompanyNameLabel.Text = outletStore.Name;

        List<string> addressLines = SP.Util.Utils.ConvertAddressLinesFromXml(outletStore.Address.AddressLines);
        if (addressLines.Count > 0)
            CustomerAddressLine1Label.Text = addressLines[0];
        if (addressLines.Count > 1)
            CustomerAddressLine2Label.Text = addressLines[1];

        TownLabel.Text = outletStore.Address.Town;
        CountyLabel.Text = outletStore.Address.County;
        PostCodeLabel.Text = outletStore.Address.PostCode;

        FoundationFacilityUI ffUI = new FoundationFacilityUI();
        if (ffUI.Exists())
        {
            FoundationFacility ff = ffUI.Get();

            YourCompanyNameLabel.Text = ff.CompanyName;
            List<string> ycAddressLines = SP.Util.Utils.ConvertAddressLinesFromXml(ff.Address.AddressLines);
            if (ycAddressLines.Count > 0)
                YourAddressLine1Label.Text = ycAddressLines[0];
            if (ycAddressLines.Count > 1)
                YourAddressLine2Label.Text = ycAddressLines[1];

            YourAddressTownLabel.Text = ff.Address.Town;
            YourAddressCountyLabel.Text = ff.Address.County;
            YourAddressPostCodeLabel.Text = ff.Address.PostCode;
            YourAddressVatRegistrationNo.Text = ff.VatRegistrationNumber;
            OfficePhoneNumber1Label1.Text = ff.OfficePhoneNumber1;
            OfficePhoneNumber1Label2.Text = ff.OfficePhoneNumber2;
        }

        ChangeState += new EventHandler<EventArgs>(DeliverySelectedState);
        ChangeState(this, e);

        DeliveryNoteRepeater.Visible = true;
    }
    #endregion
}
