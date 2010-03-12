using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using SP.Utils;
using WcfFoundationService;
using Microsoft.Reporting.WebForms;
using SP.Core.Enums;

public partial class Controls_MaintainProformaInvoices : System.Web.UI.UserControl
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

    #region Public Accesors
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
        InvoiceGridView.DataBind();
    }

    protected void ConfirmInvoice_Click(object sender, EventArgs e)
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
                InvoicePaymentComplete = false,
                InvoicePrinted = false,
                InvoiceDateReprinted = Defaults.MinDateTime,
                InvoiceProformaDatePrinted = Defaults.MinDateTime,
                InvoiceProformaPrinted = false,
                InvoiceReprinted = false,
                OrderID = OrderID.Value,
                PicklistDateGenerated = Defaults.MinDateTime,
                PicklistGenerated = false,
                InvoiceDateCreated = Defaults.MinDateTime,
                InvoiceProformaDateCreated = DateTime.Now,
                DeliveryNoteDateCreated = Defaults.MinDateTime
            };

            OrderNotesStatusUI ui = new OrderNotesStatusUI();
            ui.Save(status);

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

    protected void ChangeInvoiceDetailsButton_Click(object sender, EventArgs e)
    {
        try
        {
            OrderNotesStatusUI ui = new OrderNotesStatusUI();
            OrderNotesStatus status = ui.GetOrderNotesStatus(OrderNoteStatusID.Value);
            status.AccountID = Convert.ToInt32(AccountDropDownList.SelectedValue);
            status.VanID = Convert.ToInt32(DeliveryVanDropDownList.SelectedValue);
            status.OutletStoreID = Convert.ToInt32(DeliveryDropDownList.SelectedValue);

            ui.Update(status);

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
            OrderHeader header = orderHeaderUI.GetById(OrderID.Value);
            header.OrderStatus = (short)SP.Core.Enums.OrderStatus.Order;
            header.InvoiceNo = String.Empty;
            orderHeaderUI.UpdateForInvoice(header);

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

    protected void CancelSelectInvoiceDetails_Click(object sender, EventArgs e)
    {
        ChangeState += new EventHandler<EventArgs>(PageLoadState);
        ChangeState(this, e);

        DataBind();
    }

    protected void InvoicesPrintedDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        InvoiceGridView.DataBind();
    }

    protected void PrintInvoiceButton_Click(object sender, EventArgs e)
    {
        try
        {
            int orderID = this.OrderID.Value;

            PrintInvoice(orderID);

            OrderHeaderUI orderHeaderUI = new OrderHeaderUI();
            OrderHeader orderHeader = orderHeaderUI.GetById(orderID);
            orderHeader.OrderStatus = (short)OrderStatus.PoformaInvoicePrinted;
            orderHeaderUI.UpdateForInvoice(orderHeader);

            OrderNotesStatusUI ui = new OrderNotesStatusUI();
            OrderNotesStatus orderNoteStatus = ui.GetOrderNotesStatusByOrderID(orderID);
            orderNoteStatus.InvoiceProformaDatePrinted = DateTime.Now;
            orderNoteStatus.InvoiceProformaPrinted = true;
            ui.Update(orderNoteStatus);

            PrintInvoiceButton.Visible = false;
            RePrintInvoiceButton.Visible = true;

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

    protected void RePrintInvoiceButton_Click(object sender, EventArgs e)
    {
        try
        {
            int orderID = this.OrderID.Value;

            PrintInvoice(orderID);

            OrderHeaderUI orderHeaderUI = new OrderHeaderUI();
            OrderHeader orderHeader = orderHeaderUI.GetById(orderID);
            orderHeader.OrderStatus = (short)OrderStatus.PoformaInvoicePrinted;
            orderHeaderUI.UpdateForInvoice(orderHeader);

            OrderNotesStatusUI ui = new OrderNotesStatusUI();
            OrderNotesStatus orderNoteStatus = ui.GetOrderNotesStatusByOrderID(orderID);
            orderNoteStatus.InvoiceProformaDatePrinted = DateTime.Now;
            orderNoteStatus.InvoiceReprinted = true;
            ui.Update(orderNoteStatus);

            PrintInvoiceButton.Visible = false;
            RePrintInvoiceButton.Visible = true;

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

    private void PrintInvoice(int orderID)
    {
        int accountId = Convert.ToInt32(AccountDropDownList.SelectedValue);
        int outletStoreId = Convert.ToInt32(DeliveryDropDownList.SelectedValue);

        DataSet[] dataSets = new DataSet[5];

        IReportDataSets reportDataSets = new ReportDataSets();
        ReportDataSource[] reportDataSources = reportDataSets.GetReportDataSets(orderID, accountId, outletStoreId);

        PrintReport printReport = new PrintReport();
        printReport.Run("InvoicePrint.rdlc", reportDataSources, PageMode.Portrait);
        OKModalPopupExtender.Show();
    }

    protected void ClearButton_Click(object sender, EventArgs e)
    {
        Util.ClearControls(InvoiceSearchCriteriaPanel);
        DataBind();
    }

    protected void AccountDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (AccountDropDownList.SelectedValue != "-1")
        {
            PopulateInvoice(e);
        }
        else
        {
            ChangeState += new EventHandler<EventArgs>(AccountNotSelected);
            ChangeState(this, e);
        }

        DataBind();
    }

    protected void DeliveryDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataBind();
    }

    protected void DeliveryVanDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        InvoiceRepeater.DataBind();
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

            Image confirmedImage = e.Row.FindControl("ConfirmedImage") as Image;
            OrderNotesStatusUI orderNoteStatusUI = new OrderNotesStatusUI();
            if (orderNoteStatusUI.OrderNoteExistsByOrderID(orderHeader.ID))
            {
                confirmedImage.Visible = true;
            }
            else
            {
                confirmedImage.Visible = false;
            }

            Image printedImage = e.Row.FindControl("PrintedImage") as Image;
            Image rePrintedImage = e.Row.FindControl("RePrintedImage") as Image;
            if (orderNoteStatusUI.OrderNoteExistsByOrderID(orderHeader.ID))
            {
                OrderNotesStatus orderNoteStatus = orderNoteStatusUI.GetOrderNotesStatusByOrderID(orderHeader.ID);
                if (orderNoteStatusUI.OrderNoteExistsByOrderID(orderHeader.ID))
                {
                    if (orderNoteStatus.InvoiceProformaPrinted)
                    {
                        printedImage.Visible = true;
                    }
                    else
                    {
                        printedImage.Visible = false;
                    }

                    if (orderNoteStatus.InvoiceReprinted)
                    {
                        rePrintedImage.Visible = true;
                    }
                    else
                    {
                        rePrintedImage.Visible = false;
                    }
                }
                else
                {
                    rePrintedImage.Visible = false;
                    printedImage.Visible = false;
                }
            }
            else
            {
                rePrintedImage.Visible = false;
                printedImage.Visible = false;
            }

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

            OrderID = orderHeader.ID;
            OrderHeaderNoLabel.Text = orderHeader.AlphaID;
            InvoiceHeaderNoLabel.Text = orderHeader.InvoiceNo;

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

            OrderNotesStatusUI orderNotesStatusUI = new OrderNotesStatusUI();
            if (orderNotesStatusUI.OrderNoteExistsByOrderID(OrderID.Value))
            {
                ConfirmInvoice.Visible = false;
                ChangeInvoiceDetailsButton.Visible = true;
                CancelInvoiceButton.Visible = true;

                // Now Select Account using Create OrderNotes record ...
                OrderNotesStatus orderNoteStatus = orderNotesStatusUI.GetOrderNotesStatusByOrderID(OrderID.Value);
                OrderNoteStatusID = orderNoteStatus.ID;
                if (orderNoteStatus.InvoicePrinted)
                {
                    PrintInvoiceButton.Visible = false;
                    RePrintInvoiceButton.Visible = true;
                }
                else
                {
                    PrintInvoiceButton.Visible = true;
                    RePrintInvoiceButton.Visible = false;
                }

                AccountDropDownList.SelectedValue = orderNoteStatus.AccountID.ToString();
                DeliveryDropDownList.SelectedValue = orderNoteStatus.OutletStoreID.ToString();
                DeliveryVanDropDownList.SelectedValue = orderNoteStatus.VanID.ToString();

                PopulateInvoice(e);
            }
            else
            {
                ConfirmInvoice.Visible = true;
                ChangeInvoiceDetailsButton.Visible = false;
                PrintInvoiceButton.Visible = false;
                RePrintInvoiceButton.Visible = false;
                CancelInvoiceButton.Visible = false;
            }
        }
        else if (e.CommandName == "DisplayCreditNotes")
        {
            CreditNoteModalPopupExtender.Show();
        }

        DataBind();
    }
    #endregion

    #region Page States
    public void PageLoadState(object sender, EventArgs args)
    {
        InvoiceEntryPanel.Visible = false;
        DisplayInvoicePanel.Visible = false;
        OrderHeaderDetailsPanel.Visible = false;

        this.InvoiceSearchCriteriaPanel.Visible = true;
        this.InvoiceHeaderSearchGridPanel.Visible = true;
    }

    public void SelectedOrderState(object sender, EventArgs args)
    {
        InvoiceEntryPanel.Visible = true;
        DisplayInvoicePanel.Visible = false;
        InvoiceRepeater.Visible = false;
        OrderHeaderDetailsPanel.Visible = false;

        this.InvoiceSearchCriteriaPanel.Visible = false;
        this.InvoiceHeaderSearchGridPanel.Visible = false;
    }

    public void AccountNotSelected(object sender, EventArgs args)
    {
        InvoiceEntryPanel.Visible = true;
        DisplayInvoicePanel.Visible = false;
        InvoiceRepeater.Visible = false;
        OrderHeaderDetailsPanel.Visible = false;

        this.InvoiceSearchCriteriaPanel.Visible = false;
        this.InvoiceHeaderSearchGridPanel.Visible = false;
    }

    public void AccountSelectedState(object sender, EventArgs args)
    {
        InvoiceEntryPanel.Visible = true;
        DisplayInvoicePanel.Visible = true;
        InvoiceRepeater.Visible = true;
        OrderHeaderDetailsPanel.Visible = true;

        this.InvoiceSearchCriteriaPanel.Visible = false;
        this.InvoiceHeaderSearchGridPanel.Visible = false;
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

        switch (Convert.ToInt32(InvoicesPrintedDropDownList.SelectedValue))
        {
            case -1:
                e.InputParameters[5] = (short)SP.Core.Enums.OrderStatus.ProformaInvoice;
                e.InputParameters[6] = (short)SP.Core.Enums.OrderStatus.PoformaInvoicePrinted;
                break;
            case (short)SP.Core.Enums.OrderStatus.Invoice:
                e.InputParameters[5] = (short)SP.Core.Enums.OrderStatus.ProformaInvoice;
                e.InputParameters[6] = (short)(-1);
                break;
            case (short)SP.Core.Enums.OrderStatus.InvoicePrinted:
                e.InputParameters[5] = (short)(-1);
                e.InputParameters[6] = (short)SP.Core.Enums.OrderStatus.PoformaInvoicePrinted;
                break;
        }
    }

    #endregion

    #region Invoice Repeater Event Handlers

    int totalRowCount = 0;
    Decimal netTotalPrice = 0;
    Decimal vatTotal = 0;
    Decimal totalUnits = 0;

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
            rrpLabel.Text = String.Format("{0:c}", p.RRPPerItem);

            Label vatExemptibleLabel = e.Item.FindControl("VatExemptibleLabel") as Label;
            if (p.VatExempt)
                vatExemptibleLabel.Text = "Y";
            else
                vatExemptibleLabel.Text = "N";

            Label noOfUnitsLabel = e.Item.FindControl("NoOfUnitsLabel") as Label;
            int noOfUnits = Convert.ToInt32(noOfUnitsLabel.Text);
            totalUnits += noOfUnits;

            Label pricePerUnitLabel = e.Item.FindControl("PricePerUnitLabel") as Label;
            Decimal pricePerUnit = Convert.ToDecimal(pricePerUnitLabel.Text);

            Label netPriceLabel = e.Item.FindControl("NetPriceLabel") as Label;
            Decimal totalPrice = Math.Round(pricePerUnit * noOfUnits, 2);

            if (totalPrice != 0 && (p.VatExempt == false))
            {
                Decimal vat = (totalPrice / 100) * Convert.ToDecimal(p.VatCode.PercentageValue);
                vatTotal += vat;
            }

            netPriceLabel.Text = totalPrice.ToString();
            netTotalPrice += totalPrice;

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
            totalItemsLabel.Text = this.totalUnits.ToString();

            Label totalLabel = e.Item.FindControl("TotalLabel") as Label;
            totalLabel.Text = String.Format("{0:c}", Math.Round(netTotalPrice, 2));

            Label deliveryVanLabel = e.Item.FindControl("DeliveryVanLabel") as Label;
            if (DeliveryVanDropDownList.SelectedValue != "-1")
                deliveryVanLabel.Text = DeliveryVanDropDownList.SelectedItem.Text;
            else
                deliveryVanLabel.Text = "";

            Label vatLabel = e.Item.FindControl("VatLabel") as Label;
            vatLabel.Text += String.Format("{0:c}", Math.Round(vatTotal, 2));

            Label netTotalLabel = e.Item.FindControl("NetTotalLabel") as Label;
            netTotalLabel.Text += String.Format("{0:c}", Math.Round(netTotalPrice + vatTotal, 2));

            if (AccountDropDownList.SelectedValue != "")
            {
                if (AccountDropDownList.SelectedIndex != 0)
                {
                    int accountID = Convert.ToInt32(AccountDropDownList.SelectedValue);
                    AccountUI accountUI = new AccountUI();
                    Account account = accountUI.GetByID(accountID);

                    TermsUI termsUI = new TermsUI();
                    Terms terms = termsUI.GetByID(account.TermTypeID.Value);

                    Label paymentTermsLabel = e.Item.FindControl("PaymentTermsLabel") as Label;
                    paymentTermsLabel.Text = terms.Description;
                }
            }

            OrderHeaderUI orderHeaderUI = new OrderHeaderUI();
            OrderHeader orderHeader = orderHeaderUI.GetById(OrderID.Value);

            Label deliveryDateLabel = e.Item.FindControl("DeliveryDateLabel") as Label;
            deliveryDateLabel.Text = orderHeader.DeliveryDate.ToShortDateString();

            netTotalPrice = 0;
            vatTotal = 0;
            netTotalPrice = 0;
            totalRowCount = 0;
        }
    }
    #endregion

    #region Util Methods

    private static DataSet GetInvoiceTotalsDS(int orderId)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["SuperCreamDBConnectionString"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();

        SqlCommand command = new SqlCommand();
        command.CommandType = System.Data.CommandType.StoredProcedure;
        command.CommandText = "rptGetOrderTotals";
        command.Connection = connection;

        SqlParameter orderParameterId = command.Parameters.Add("@OrderID", System.Data.SqlDbType.Int);
        orderParameterId.Value = orderId;

        DataSet dataSet = new DataSet("InvoiceTotalsSA");

        SqlDataAdapter adapter = new SqlDataAdapter(command);
        adapter.Fill(dataSet);
        return dataSet;
    }

    private static DataSet GetDeliveryAddressLinesDS(int outletStoreId)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["SuperCreamDBConnectionString"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();

        SqlCommand command = new SqlCommand();
        command.CommandType = System.Data.CommandType.StoredProcedure;
        command.CommandText = "rptGetDeliveryAddressLines";
        command.Connection = connection;

        SqlParameter outletStoreIdParmeter = command.Parameters.Add("@OutletStoreID", System.Data.SqlDbType.Int);
        outletStoreIdParmeter.Value = outletStoreId;

        DataSet dataSet = new DataSet("DeliveryAddressLinesDS");

        SqlDataAdapter adapter = new SqlDataAdapter(command);
        adapter.Fill(dataSet);
        return dataSet;
    }

    private static DataSet GetInvoiceAddressLinesDS(int accountId)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["SuperCreamDBConnectionString"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();

        SqlCommand command = new SqlCommand();
        command.CommandType = System.Data.CommandType.StoredProcedure;
        command.CommandText = "rptGetAddressLinesForInvoice";
        command.Connection = connection;

        SqlParameter accountIdParameter = command.Parameters.Add("@AccountID", System.Data.SqlDbType.Int);
        accountIdParameter.Value = accountId;

        DataSet dataSet = new DataSet("InvoiceAddressLinesDS");

        SqlDataAdapter adapter = new SqlDataAdapter(command);
        adapter.Fill(dataSet);
        return dataSet;
    }

    private static DataSet GetFoundationFacilityAddressLinesDS(int accountId)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["SuperCreamDBConnectionString"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();

        SqlCommand command = new SqlCommand();
        command.CommandType = System.Data.CommandType.StoredProcedure;
        command.CommandText = "rptGetFoundationFacilityAddressLines";
        command.Connection = connection;

        SqlParameter accountIdParameter = command.Parameters.Add("@AccountID", System.Data.SqlDbType.Int);
        accountIdParameter.Value = accountId;

        DataSet dataSet = new DataSet("FoundationFacilityAddressLines");

        SqlDataAdapter adapter = new SqlDataAdapter(command);
        adapter.Fill(dataSet);
        return dataSet;
    }

    private static DataSet GetInvoiceHeaderDS(int orderID, int accountNo, int outletStoreId)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["SuperCreamDBConnectionString"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();

        SqlCommand command = new SqlCommand();
        command.CommandType = System.Data.CommandType.StoredProcedure;
        command.CommandText = "rptDetailsGetInvoice";
        command.Connection = connection;

        SqlParameter orderIDParameter = command.Parameters.Add("@OrderID", System.Data.SqlDbType.Int);
        orderIDParameter.Value = orderID;

        SqlParameter accountIDParameter = command.Parameters.Add("@AccountID", System.Data.SqlDbType.Int);
        accountIDParameter.Value = accountNo;

        SqlParameter outletStoreIdParameter = command.Parameters.Add("@OutletStoreID", System.Data.SqlDbType.Int);
        outletStoreIdParameter.Value = outletStoreId;

        DataSet invoiceHeaderDataSet = new DataSet("InvoiceHeaderSA");

        SqlDataAdapter adapter = new SqlDataAdapter(command);
        adapter.Fill(invoiceHeaderDataSet);
        return invoiceHeaderDataSet;
    }

    void PopulateInvoice(EventArgs e)
    {
        ChangeState += new EventHandler<EventArgs>(AccountSelectedState);
        ChangeState(this, e);

        // Deal with Order Header Details
        OrderHeaderUI orderHeaderUI = new OrderHeaderUI();
        OrderHeader orderHeader = orderHeaderUI.GetById(OrderID.Value);

        DateOfOrderLabel.Text = orderHeader.OrderDate.ToShortDateString();
        InvoiceLabel.Text = orderHeader.InvoiceNo;

        // Get Account Details
        int accountID = Convert.ToInt32(AccountDropDownList.SelectedValue);
        AccountUI accountUI = new AccountUI();
        Account account = accountUI.GetByID(accountID);

        TermsUI termsUI = new TermsUI();
        Terms terms = termsUI.GetByID(account.TermTypeID.Value);
        PaymentTermsLabel.Text = terms.Description;

        CustomerCompanyNameLabel.Text = account.CompanyToInvoiceTo;

        List<string> addressLines = SP.Util.Utils.ConvertAddressLinesFromXml(account.Address.AddressLines);
        if (addressLines.Count > 0)
            CustomerAddressLine1Label.Text = addressLines[0];
        if (addressLines.Count > 1)
            CustomerAddressLine1Label.Text = addressLines[1];

        TownLabel.Text = account.Address.Town;
        CountyLabel.Text = account.Address.County;
        PostCodeLabel.Text = account.Address.PostCode;

        ContactDetailUI contactDetailUI = new ContactDetailUI();
        ContactDetail contactDetail = contactDetailUI.GetContactDetail(account.ContactDetailID);

        CustomerContactNameLabel.Text =
            "For the attention of : " + contactDetail.FirstName + ' ' + contactDetail.LastName;

        Phone phone = contactDetail.Phone.Find(q => q.PhoneTypeID == (int?)SP.Core.Enums.PhoneNoTypes.DayTimeTelephoneNo);
        CustomerContactTelephoneLabel.Text = "<b><i>Tel No: </i></b>" + phone.Description;

        FoundationFacilityUI ffUI = new FoundationFacilityUI();
        if (ffUI.Exists())
        {
            FoundationFacility ff = ffUI.Get();

            YourCompanyNameLabel.Text = ff.CompanyName;
            List<string> ycAddressLines = SP.Util.Utils.ConvertAddressLinesFromXml(ff.Address.AddressLines);
            if (ycAddressLines.Count > 0)
                YourAddressLine1Label.Text = ycAddressLines[0];
            if (ycAddressLines.Count > 1)
                YourAddressLine1Label.Text = ycAddressLines[1];

            YourAddressTownLabel.Text = ff.Address.Town;
            YourAddressCountyLabel.Text = ff.Address.County;
            YourAddressPostCodeLabel.Text = ff.Address.PostCode;
            YourAddressVatRegistrationNo.Text = ff.VatRegistrationNumber;
            OfficePhoneNumber1Label1.Text = ff.OfficePhoneNumber1;
            OfficePhoneNumber1Label2.Text = ff.OfficePhoneNumber2;
        }

        if (DeliveryDropDownList.SelectedValue != "-1")
        {
            OutletStoreUI outletStoreUI = new OutletStoreUI();
            OutletStore store = outletStoreUI.GetOutletStore(Convert.ToInt32(DeliveryDropDownList.SelectedValue));

            AddressUI addressUI = new AddressUI();
            Address outletAddress = addressUI.GetByID(store.AddressID);

            DeliveryCompanyNameLabel.Text = store.Name;
            DeliveryCountyLabel.Text = outletAddress.County;
            List<string> deliveryAddressLines = SP.Util.Utils.ConvertAddressLinesFromXml(outletAddress.AddressLines);
            DeliveryCustomerAddressLine1Label.Text = deliveryAddressLines[0];
            if (deliveryAddressLines.Count > 1)
            {
                DeliveryCustomerAddressLine2Label.Text = deliveryAddressLines[1];
            }

            DeliveryPostCodeLabel.Text = outletAddress.PostCode;
            DeliveryTownLabel.Text = outletAddress.Town;

            DeliveryMapReferenceLabel.Text = outletAddress.MapReference;
        }

        ChangeState += new EventHandler<EventArgs>(AccountSelectedState);
        ChangeState(this, e);

        InvoiceRepeater.Visible = true;
    }
    #endregion
}

