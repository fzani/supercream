using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WcfFoundationService;
using AjaxControlToolkit;

public partial class Controls_NewSpecialInvoice : System.Web.UI.UserControl
{
    #region Private Event Handlers

    EventHandler<EventArgs> ChangeState;

    #endregion

    #region Public Event Handlers

    public event CancelEventHandler CancelHandler;
    public event CompletedEventHandler CompletedEventHandler;
    public event ErrorMessageEventHandler NewSpecialInvoiceError;

    #endregion

    #region public Properties

    public int SpecialInvoiceID
    {
        get
        {
            if (ViewState["SpecialInvoiceID"] != null)
            {
                return (int)ViewState["SpecialInvoiceID"];
            }
            else
            {
                return 0;
            }
        }
        set
        {
            ViewState["SpecialInvoiceID"] = value;
        }
    }

    #endregion

    #region Page Load Event

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CustomerUI customerUI = new CustomerUI();
            List<Customer> customerList = customerUI.GetAll();

            CustomerDropDownList.Items.Add(new ListItem("-- Not Selected --", "-1"));
            foreach (Customer cs in customerList)
            {
                CustomerDropDownList.Items.Add(new ListItem(cs.Account + " " + cs.Name, cs.ID.ToString()));
            }

            AccountDropDownList.Items.Add(new ListItem("-- Not Selected --", "-1"));
            OutletStoreDropDownList.Items.Add(new ListItem("-- Not Selected --", "-1"));

            this.ChangeState += new EventHandler<EventArgs>(this.InitialiseState);
            this.ChangeState(this, e);

        }

        this.InitialiseDates();

    }

    private void InitialiseDates()
    {
        this.OrderDateTextBox.Text = DateTime.Now.ToShortDateString();
        this.DeliveryDateTextBox.Text = DateTime.Now.AddDays(1).ToShortDateString();
    }

    #endregion

    #region General Events

    protected void CustomerDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (CustomerDropDownList.SelectedIndex != -1)
        {
            InitialiseDropDownLists();

            AccountUI accountUI = new AccountUI();
            List<Account> accounts = accountUI.GetAllAccountsByCustomerID(Convert.ToInt32(CustomerDropDownList.SelectedValue));
            foreach (Account account in accounts)
            {
                AccountDropDownList.Items.Add(new ListItem(account.AlphaID, account.ID.ToString()));
            }


            CustomerUI customerUI = new CustomerUI();
            List<OutletStore> outletStores = customerUI.GetOutletStoresByCustomerID(Convert.ToInt32(CustomerDropDownList.SelectedValue));
            foreach (OutletStore outletStore in outletStores)
            {
                OutletStoreDropDownList.Items.Add(new ListItem(outletStore.Name, outletStore.ID.ToString()));
            }
        }
        else
        {
            InitialiseDropDownLists();
        }
    }

    private void InitialiseDropDownLists()
    {
        AccountDropDownList.Items.Clear();
        OutletStoreDropDownList.Items.Clear();

        AccountDropDownList.Items.Add(new ListItem("-- Not Selected --", "-1"));
        OutletStoreDropDownList.Items.Add(new ListItem("-- Not Selected --", "-1"));
    }

    protected void InvoiceLineUpdateButton_Click(object sender, EventArgs e)
    {
        try
        {
            GridViewRow row = this.AddSpecialInvoiceLinesGridViewPanel.Rows[this.AddSpecialInvoiceLinesGridViewPanel.SelectedIndex];
            Panel messagePanel = row.FindControl("PanelMessage") as Panel;

            Label idLabel = row.FindControl("ID") as Label;

            SpecialInvoiceLineUI ui = new SpecialInvoiceLineUI();

            int id = Convert.ToInt32((messagePanel.FindControl("ID") as Label).Text);
            string description = (messagePanel.FindControl("LineDescriptionTextBox") as TextBox).Text;
            int qtyPerUnit = Convert.ToInt32((messagePanel.FindControl("QtyPerUnitTextBox") as TextBox).Text);
            int noOfUnits = Convert.ToInt32((messagePanel.FindControl("NoOfUnitsTextBox") as TextBox).Text);
            decimal price = Util.ConvertStringToDecimal((messagePanel.FindControl("PricePerUnitsTextBox") as TextBox).Text);
            decimal discount = Convert.ToDecimal((messagePanel.FindControl("DiscountTextBox") as TextBox).Text);
            bool vatExempt = (messagePanel.FindControl("VatExemptCheckBox") as CheckBox).Checked;

            string specialInstructions = (messagePanel.FindControl("SpecialInstructionsTextBox") as TextBox).Text;

            SpecialInvoiceLine specialInvoiceLine = new SpecialInvoiceLine
            {
                ID = Convert.ToInt32(idLabel.Text),
                Description = description,
                QtyPerUnit = qtyPerUnit,
                NoOfUnits = noOfUnits,
                Price = price,
                SpecialInstructions = specialInstructions,
                Discount = discount,
                OrderLineStatus = (short)SP.Core.Enums.OrderStatus.Invoice,
                SpecialInvoiceID = this.SpecialInvoiceID,
                VatExempt = vatExempt
            };

            ui.Update(specialInvoiceLine);

            DataBind();
        }
        catch (Exception ex)
        {
            ErrorMessageEventArgs args = new ErrorMessageEventArgs();
            args.AddErrorMessages(ex.Message);
            if (this.NewSpecialInvoiceError != null)
            {
                this.NewSpecialInvoiceError(this, args);
            }
        }
    }

    protected void InvoiceLineDeleteButton_Click(object sender, EventArgs e)
    {
        try
        {
            GridViewRow row = this.AddSpecialInvoiceLinesGridViewPanel.Rows[AddSpecialInvoiceLinesGridViewPanel.SelectedIndex];
            Panel messagePanel = row.FindControl("PanelMessage") as Panel;

            SpecialInvoiceLineUI ui = new SpecialInvoiceLineUI();
            int id = Convert.ToInt32((messagePanel.FindControl("ID") as Label).Text);

            ui.DeleteSpecialInvoiceLine(id);
            DataBind();

            if (this.AddSpecialInvoiceLinesGridViewPanel.Rows.Count == 0)
            {
                CancelSpecialInvoiceLineButton.Visible = true;
            }
        }
        catch (Exception ex)
        {
            ErrorMessageEventArgs args = new ErrorMessageEventArgs();
            args.AddErrorMessages(ex.Message);
            if (this.NewSpecialInvoiceError != null)
            {
                this.NewSpecialInvoiceError(this, args);
            }
        }
    }

    protected void AddOrderLineDetailsButton_Click(object sender, EventArgs e)
    {
        try
        {
            CustomerUI customerUI = new CustomerUI();
            Customer customer = customerUI.GetByID(Convert.ToInt32(CustomerDropDownList.SelectedValue));

            StandardVatCodeUI standardVatCodeUI = new StandardVatCodeUI();
            StandardVatRate standardVatRate = standardVatCodeUI.GetStandardVatCode();

            SpecialInvoiceHeaderUI ui = new SpecialInvoiceHeaderUI();

            SpecialInvoiceHeader specialInvoiceHeader = new SpecialInvoiceHeader
            {
                ID = -1,
                CustomerID = customer.ID,
                AccountID = Convert.ToInt32(this.AccountDropDownList.SelectedValue),
                OutletStoreID = Convert.ToInt32(this.OutletStoreDropDownList.SelectedValue),
                AlphaPrefixOrPostFix = 0,
                OrderStatus = (short)SP.Core.Enums.OrderStatus.Invoice,
                OrderDate = Convert.ToDateTime(OrderDateTextBox.Text),
                DeliveryDate = Convert.ToDateTime(DeliveryDateTextBox.Text),
                SpecialInstructions = OrderHeaderSpecialInstructionsTextBox.Text,
                DatePrinted = SP.Utils.Defaults.MinDateTime,
                DateReprinted = SP.Utils.Defaults.MinDateTime,
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now,
                VatCodeID = standardVatRate.VatCodeID
            };

            specialInvoiceHeader = ui.Save(specialInvoiceHeader);
            SpecialInvoiceID = specialInvoiceHeader.ID;

            SpecialInvoiceLabel.Text = specialInvoiceHeader.InvoiceNo;

            this.ChangeState += new EventHandler<EventArgs>(OrderLineState);
            this.ChangeState(this, e);
        }
        catch (Exception ex)
        {
            ErrorMessageEventArgs args = new ErrorMessageEventArgs();
            args.AddErrorMessages(ex.Message);
            if (this.NewSpecialInvoiceError != null)
            {
                this.NewSpecialInvoiceError(this, args);
            }
        }
    }

    protected void NoOfUnitsTextBox_TextChanged(object sender, EventArgs e)
    {
    }

    protected void CalculateButton_Click(object sender, EventArgs e)
    {
        int qtyPerUnit = 0;
        int noOfUnits = 0;
        decimal pricePerUnits = 0;
        decimal discount = 0;
        decimal price = 0;

        if (QtyPerUnitTextBox.Text.Length != 0)
            qtyPerUnit = Convert.ToInt32(this.QtyPerUnitTextBox.Text);

        if (NoOfUnitsTextBox.Text.Length != 0)
        {
            noOfUnits = Convert.ToInt32(this.NoOfUnitsTextBox.Text);
        }

        if (PricePerUnitsTextBox.Text.Length != 0)
        {
            // Create a CultureInfo object for another culture. Use
            // [Dutch - The Netherlands] unless the current culture
            // is Dutch language. In that case use [English - U.S.].

            pricePerUnits = Util.ConvertStringToDecimal(this.PricePerUnitsTextBox.Text);
        }

        if (DiscountTextBox.Text.Length != 0)
        {
            discount = Util.ConvertStringToDecimal(this.DiscountTextBox.Text);
        }

        if ((pricePerUnits != 0) && (noOfUnits != 0))
        {
            price = pricePerUnits * noOfUnits;
        }

        if ((price != 0) && (discount != 0))
        {
            price -= (price / 100) * discount;
            if (VatExemptCheckBox.Checked)
            {
                PriceIncludingVatLabel.Visible = false;
            }
            else
            {
                PriceIncludingVatLabel.Visible = true;
                var specialInvoiceHeader = SpecialInvoiceHeaderUI.GetById(SpecialInvoiceID);

                var vatcode = new VatCodeUI().GetByID(specialInvoiceHeader.VatCodeID);
                PriceIncludingVatLabel.Text =
                    String.Format("Price including Vat @({0:c})",
                                  Math.Round(
                                      ((price *
                                        (decimal)((decimal)1.0 + ((decimal)vatcode.PercentageValue / (decimal)100.0)))),
                                      2));
            }
        }

        if (price != 0)
        {
            this.PriceChargeTextBox.Text = String.Format("{0:c}", Math.Round(price, 2, MidpointRounding.AwayFromZero));
        }
    }

    protected void CancelNewOrderButton_Click(object sender, EventArgs e)
    {
        this.ChangeState += new EventHandler<EventArgs>(CancelOrderState);
        this.ChangeState(this, e);
        if (this.CancelHandler != null)
        {
            this.CancelHandler(this, e);
        }
    }

    protected void CompleteButton_Click(object sender, EventArgs e)
    {
        this.ChangeState += new EventHandler<EventArgs>(CancelOrderState);
        this.ChangeState(this, e);
        if (this.CancelHandler != null)
        {
            this.CancelHandler(this, e);
        }
    }

    protected void CancelSpecialInvoiceLineButton_Click(object sender, EventArgs e)
    {
        try
        {
            SpecialInvoiceHeaderUI ui = new SpecialInvoiceHeaderUI();

            this.ChangeState += new EventHandler<EventArgs>(CancelOrderState);
            this.ChangeState(this, e);
            if (this.CancelHandler != null)
            {
                this.CancelHandler(this, e);
            }
        }
        catch (Exception ex)
        {
            ErrorMessageEventArgs args = new ErrorMessageEventArgs();
            args.AddErrorMessages(ex.Message);
            if (this.NewSpecialInvoiceError != null)
            {
                this.NewSpecialInvoiceError(this, args);
            }
        }
    }

    protected void AddSpecialInvoiceLineButton_Click(object sender, EventArgs e)
    {
        try
        {
            decimal discount = 0;

            if (this.DiscountTextBox.Text.Length != 0)
                discount = Convert.ToDecimal(this.DiscountTextBox.Text);

            SpecialInvoiceLineUI ui = new SpecialInvoiceLineUI();
            SpecialInvoiceLine specialInvoiceLine = new SpecialInvoiceLine
            {
                ID = -1,
                Description = LineDescriptionTextBox.Text,
                Discount = discount,
                NoOfUnits = Convert.ToInt32(this.NoOfUnitsTextBox.Text),
                Price = Util.ConvertStringToDecimal(this.PricePerUnitsTextBox.Text),
                QtyPerUnit = Convert.ToInt32(this.QtyPerUnitTextBox.Text),
                SpecialInstructions = this.SpecialInstructionsTextBox.Text,
                OrderLineStatus = Convert.ToInt16(SP.Core.Enums.OrderLineStatus.Open),
                SpecialInvoiceID = this.SpecialInvoiceID,
                VatExempt = this.VatExemptCheckBox.Checked

            };

            specialInvoiceLine = ui.Save(specialInvoiceLine);
            this.ChangeState += new EventHandler<EventArgs>(OrderLineAddedState);
            this.ChangeState(this, e);

            this.AddSpecialInvoiceLinesGridViewPanel.DataBind();
        }
        catch (Exception ex)
        {
            ErrorMessageEventArgs args = new ErrorMessageEventArgs();
            args.AddErrorMessages(ex.Message);
            if (this.NewSpecialInvoiceError != null)
            {
                this.NewSpecialInvoiceError(this, args);
            }
        }
    }

    #endregion

    #region Object Data Source Events

    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        if (this.SpecialInvoiceID != 0)
        {
            e.InputParameters[0] = this.SpecialInvoiceID;
        }
    }

    #endregion

    #region Grid View Events

    protected void AddSpecialInvoiceLinesGridViewPanel_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            Int32 index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = this.AddSpecialInvoiceLinesGridViewPanel.Rows[index];

            Label idLabel = row.FindControl("ID") as Label;

            SpecialInvoiceLineUI ui = new SpecialInvoiceLineUI();
            SpecialInvoiceLine specialInvoiceLine = ui.GetSpecialInvoiceLine(Convert.ToInt32(idLabel.Text));

            Panel messagePanel = row.FindControl("PanelMessage") as Panel;

            TextBox descriptionTextBox = messagePanel.FindControl("LineDescriptionTextBox") as TextBox;
            descriptionTextBox.Text = specialInvoiceLine.Description;
            TextBox qtyPerUnitTextBox = messagePanel.FindControl("QtyPerUnitTextBox") as TextBox;
            qtyPerUnitTextBox.Text = specialInvoiceLine.QtyPerUnit.ToString();
            TextBox noOfUnitsTextBox = messagePanel.FindControl("NoOfUnitsTextBox") as TextBox;
            noOfUnitsTextBox.Text = specialInvoiceLine.NoOfUnits.ToString();
            TextBox priceTextBox = messagePanel.FindControl("PricePerUnitsTextBox") as TextBox;
            priceTextBox.Text = Util.ConvertDecimalToString(specialInvoiceLine.Price);
            TextBox discountTextBox = messagePanel.FindControl("DiscountTextBox") as TextBox;
            discountTextBox.Text = specialInvoiceLine.Discount.ToString();
            TextBox specialInstructionsTextBox = messagePanel.FindControl("SpecialInstructionsTextBox") as TextBox;
            specialInstructionsTextBox.Text = specialInvoiceLine.SpecialInstructions;
            CheckBox vatExemptCheckBox = messagePanel.FindControl("VatExemptCheckBox") as CheckBox;
            vatExemptCheckBox.Checked = specialInvoiceLine.VatExempt;

            Label priceChargeLabel = messagePanel.FindControl("PriceChargeLabel") as Label;
            if (specialInvoiceLine.VatExempt)
            {
                priceChargeLabel.Text = PriceExcludingVat(specialInvoiceLine.Price, specialInvoiceLine.NoOfUnits, specialInvoiceLine.Discount);
            }
            else
            {
                priceChargeLabel.Text = PriceIncludingVat(specialInvoiceLine.Price, specialInvoiceLine.NoOfUnits, specialInvoiceLine.Discount);
            }

            ModalPopupExtender extender = row.FindControl("InvoiceDetailsPopupControlExtender") as ModalPopupExtender;
            extender.Show();
        }
    }

    protected void AddSpecialInvoiceLinesGridViewPanel_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            SpecialInvoiceLine specialInvoiceLine = e.Row.DataItem as SpecialInvoiceLine;
            Label priceChangeLabel = e.Row.FindControl("priceLabel") as Label;

            decimal price = 0;
            if ((specialInvoiceLine.Price != 0) && (specialInvoiceLine.NoOfUnits != 0))
            {
                price = specialInvoiceLine.Price * specialInvoiceLine.NoOfUnits;
            }

            if ((price != 0) && (specialInvoiceLine.Discount != 0))
            {
                price -= (price / 100) * specialInvoiceLine.Discount;
            }

            if (price != 0)
            {
                priceChangeLabel.Text = String.Format("{0:c}", Math.Round(price, 2, MidpointRounding.AwayFromZero));
            }
        }
    }

    #endregion

    #region Control States
    public void InitialiseState(object sender, EventArgs args)
    {
        SpecialInvoiceHeaderPanel.Visible = true;
        AddSpecialInvoiceLineDetailsPanel.Visible = false;
        SpecialInvoiceLinesGridViewPanel.Visible = false;
        CancelSpecialInvoiceLineButton.Visible = true;
    }

    public void CancelOrderState(object sender, EventArgs args)
    {
        Util.ClearControls(this);
        PriceChargeTextBox.Text = String.Empty;

        SpecialInvoiceHeaderPanel.Visible = true;
        AddSpecialInvoiceLineDetailsPanel.Visible = false;
        SpecialInvoiceLinesGridViewPanel.Visible = false;
        CancelSpecialInvoiceLineButton.Visible = true;
    }

    public void OrderLineState(object sender, EventArgs args)
    {
        SpecialInvoiceHeaderPanel.Visible = false;
        AddSpecialInvoiceLineDetailsPanel.Visible = true;
        SpecialInvoiceLinesGridViewPanel.Visible = false;
        CancelSpecialInvoiceLineButton.Visible = true;
    }

    public void OrderLineAddedState(object sender, EventArgs args)
    {
        SpecialInvoiceHeaderPanel.Visible = false;
        AddSpecialInvoiceLineDetailsPanel.Visible = true;
        SpecialInvoiceLinesGridViewPanel.Visible = true;
        CancelSpecialInvoiceLineButton.Visible = false;

        PriceIncludingVatLabel.Text = String.Empty;
        PriceChargeTextBox.Text = String.Empty;

        Util.ClearControls(AddSpecialInvoiceLineDetailsPanel);
    }

    #endregion

    #region Private Helpers

    private string PriceExcludingVat(decimal exVatUnitPrice, decimal noOfUnits, decimal discount)
    {
        decimal price = exVatUnitPrice * noOfUnits;
        price -= (price / 100) * discount;
        var specialInvoiceHeader = SpecialInvoiceHeaderUI.GetById(SpecialInvoiceID);
        var vatCode = new VatCodeUI().GetByID(specialInvoiceHeader.VatCodeID);
        return String.Format("{0:c}", price);
    }

    private string PriceIncludingVat(decimal exVatUnitPrice, decimal noOfUnits, decimal discount)
    {
        decimal price = exVatUnitPrice * noOfUnits;
        price -= (price / 100) * discount;
        var specialInvoiceHeader = SpecialInvoiceHeaderUI.GetById(SpecialInvoiceID);
        var vatCode = new VatCodeUI().GetByID(specialInvoiceHeader.VatCodeID);
        return String.Format("{0:c}", Math.Round(price * ((decimal)1.0 + ((decimal)vatCode.PercentageValue / (decimal)100.0)), 2));
    }

    #endregion
}
