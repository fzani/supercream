using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using WcfFoundationService;

public partial class Controls_MaintainSpecialInvoices : System.Web.UI.UserControl
{
    #region Private Event Handlers

    EventHandler<EventArgs> ChangeState;

    #endregion

    #region Public Event Handlers

    public event ErrorMessageEventHandler ModifySpecialInvoiceError;
    public event CancelEventHandler CancelHandler;

    #endregion

    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CustomerUI customerUI = new CustomerUI();
            List<Customer> customerList = customerUI.GetAll();

            this.CustomerDropDownList.Items.Add(new ListItem("-- Not Selected --", "-1"));
            foreach (Customer cs in customerList)
            {
                this.CustomerDropDownList.Items.Add(new ListItem(cs.Account + " " + cs.Name, cs.ID.ToString()));
            }

            this.ChangeState += new EventHandler<EventArgs>(this.InitialiseState);
            this.ChangeState(this, e);
        }
    }
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

    #region General event handlers

    protected void SearchButton_Click(object sender, EventArgs e)
    {
        DataBind();
    }

    protected void ClearButton_Click(object sender, EventArgs e)
    {
        Util.ClearControls(OrderSearchPanel);
        DataBind();
    }

    protected void OrderStatusDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {

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
                SpecialInvoiceID = this.SpecialInvoiceID

            };

            specialInvoiceLine = ui.Save(specialInvoiceLine);
            this.ChangeState += new EventHandler<EventArgs>(OrderSelectedState);
            this.ChangeState(this, e);

            this.AddSpecialInvoiceLinesGridViewPanel.DataBind();
        }
        catch (Exception ex)
        {
            ErrorMessageEventArgs args = new ErrorMessageEventArgs();
            args.AddErrorMessages(ex.Message);
            if (this.ModifySpecialInvoiceError != null)
            {
                this.ModifySpecialInvoiceError(this, args);
            }
        }
    }

    protected void CancelSpecialInvoiceLineButton_Click(object sender, EventArgs e)
    {
        try
        {
            SpecialInvoiceHeaderUI ui = new SpecialInvoiceHeaderUI();
            ui.DeleteSpecialInvoice(this.SpecialInvoiceID);

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
            if (this.ModifySpecialInvoiceError != null)
            {
                this.ModifySpecialInvoiceError(this, args);
            }
        }
    }    

    protected void SpecialInvoicesSearchGridView_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void AddOrderLineDetailsButton_Click(object sender, EventArgs e)
    {
        this.ChangeState += new EventHandler<EventArgs>(AddOrderLineState);
        this.ChangeState(this, e);
    }
    
    protected void CancelNewOrderButton_Click(object sender, EventArgs e)
    {
        this.ChangeState += new EventHandler<EventArgs>(CancelOrderState);
        this.ChangeState(this, e);
    }

    protected void CustomerDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void CancelSpecialInvoiceLineButton_Click1(object sender, EventArgs e)
    {
        DataBind();

        Util.ClearControls(AddSpecialInvoiceLineDetailsPanel);

        this.ChangeState += new EventHandler<EventArgs>(OrderSelectedState);
        this.ChangeState(this, e);
    }

    protected void CalculateButton_Click1(object sender, EventArgs e)
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
        }

        if (price != 0)
        {
            this.PriceChargeTextBox.Text = String.Format("{0:c}", Math.Round(price, 2, MidpointRounding.AwayFromZero));
        }
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
                SpecialInvoiceID = this.SpecialInvoiceID
            };

            ui.Update(specialInvoiceLine);

            DataBind();
        }
        catch (Exception ex)
        {
            ErrorMessageEventArgs args = new ErrorMessageEventArgs();
            args.AddErrorMessages(ex.Message);
            if (this.ModifySpecialInvoiceError != null)
            {
                this.ModifySpecialInvoiceError(this, args);
            }
        }
    }

    protected void InvoiceLineDeleteButton_Click(object sender, EventArgs e)
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

            ModalPopupExtender extender = row.FindControl("InvoiceDetailsPopupControlExtender") as ModalPopupExtender;
            extender.Show();
        }
    }

    protected void CompleteButton_Click(object sender, EventArgs e)
    {
        try
        {
            CustomerUI customerUI = new CustomerUI();
            Customer customer = customerUI.GetByID(Convert.ToInt32(CustomerDropDownList.SelectedValue));

            SpecialInvoiceHeaderUI ui = new SpecialInvoiceHeaderUI();

            SpecialInvoiceHeader specialInvoiceHeader = new SpecialInvoiceHeader
            {
                ID = this.SpecialInvoiceID,
                CustomerID = customer.ID,
                AlphaPrefixOrPostFix = 0,
                OrderStatus = (short)SP.Core.Enums.OrderStatus.Invoice,
                OrderDate = Convert.ToDateTime(OrderDateTextBox.Text),
                DeliveryDate = Convert.ToDateTime(DeliveryDateTextBox.Text),
                SpecialInstructions = OrderHeaderSpecialInstructionsTextBox.Text,
                InvoiceNo = this.InvoiceNoTextBox.Text
            };

            ui.Update(specialInvoiceHeader);

            Util.ClearControls(this);

            this.ChangeState += new EventHandler<EventArgs>(this.InitialiseState);
            this.ChangeState(this, e);

            if (this.CancelHandler != null)
            {
                this.CancelHandler(this, new EventArgs());
            }
        }
        catch (Exception ex)
        {
            ErrorMessageEventArgs args = new ErrorMessageEventArgs();
            args.AddErrorMessages(ex.Message);
            if (this.ModifySpecialInvoiceError != null)
            {
                this.ModifySpecialInvoiceError(this, args);
            }
        }
    }

    #endregion

    #region Object Data Source Events

    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        e.InputParameters[0] = String.Empty;
        e.InputParameters[1] = InvoiceNoTextBox.Text;

        e.InputParameters[2] = CustomerNameSearchTextBox.Text;

        e.InputParameters[3] = Util.ConvertToDateTime(DateFromTextBox.Text);
        e.InputParameters[4] = Util.ConvertToDateTime(DateToTextBox.Text);

        switch (Convert.ToInt32(OrderStatusDropDownList.SelectedValue))
        {
            case -1:
                e.InputParameters[5] = (short)SP.Core.Enums.OrderStatus.Invoice;
                break;
            case (short)SP.Core.Enums.OrderStatus.Invoice:
                e.InputParameters[5] = (short)SP.Core.Enums.OrderStatus.Invoice;
                break;
            case (short)SP.Core.Enums.OrderStatus.InvoicePrinted:
                e.InputParameters[5] = (short)SP.Core.Enums.OrderStatus.InvoicePrinted;
                break;
        }
    }

    protected void ObjectDataSource2_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        if (this.SpecialInvoiceID != 0)
        {
            e.InputParameters[0] = this.SpecialInvoiceID;
        }
    }

    #endregion

    #region Grid View Events

    protected void SpecialInvoicesSearchGridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            SpecialInvoiceHeader invoiceHeader = e.Row.DataItem as SpecialInvoiceHeader;
            CustomerUI customerUI = new CustomerUI();
            Customer customer = customerUI.GetByID(invoiceHeader.CustomerID);
            Label customerNameLabel = e.Row.FindControl("CustomerNameLabel") as Label;
            if (customerNameLabel != null)
            {
                customerNameLabel.Text = customer.Name;
            }
        }
    }

    protected void SpecialInvoicesSearchGridView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            this.SpecialInvoiceID = Convert.ToInt32(e.CommandArgument);
            SpecialInvoiceHeaderUI ui = new SpecialInvoiceHeaderUI();
            SpecialInvoiceHeader specialInvoiceHeader = ui.GetById(SpecialInvoiceID);

            CustomerDropDownList.SelectedValue = specialInvoiceHeader.CustomerID.ToString();
            InvoiceHeaderNoTextBox.Text = specialInvoiceHeader.InvoiceNo;
            OrderDateTextBox.Text = specialInvoiceHeader.OrderDate.ToShortDateString();
            DeliveryDateTextBox.Text = specialInvoiceHeader.DeliveryDate.ToShortDateString();
            OrderHeaderSpecialInstructionsTextBox.Text = specialInvoiceHeader.SpecialInstructions;

            this.ChangeState += new EventHandler<EventArgs>(this.OrderSelectedState);
            this.ChangeState(this, e);

            DataBind();
        }
    }

    #endregion

    #region Control States

    private void InitialiseState(object sender, EventArgs args)
    {
        this.SpecialInvoiceHeaderPanel.Visible = false;
        this.OrderSearchPanel.Visible = true;
        this.SpecialInvoicesSearchGridPanel.Visible = true;
        this.AddSpecialInvoiceLineDetailsPanel.Visible = false;
        SpecialInvoiceLinesGridViewPanel.Visible = false;
    }

    private void AddOrderLineState(object sender, EventArgs args)
    {
        this.SpecialInvoiceHeaderPanel.Visible = false;
        this.OrderSearchPanel.Visible = false;
        this.SpecialInvoicesSearchGridPanel.Visible = false;
        this.AddSpecialInvoiceLineDetailsPanel.Visible = true;
        SpecialInvoiceLinesGridViewPanel.Visible = false;
    }

    private void OrderLineState(object sender, EventArgs args)
    {
        this.SpecialInvoiceHeaderPanel.Visible = false;
        this.OrderSearchPanel.Visible = true;
        this.SpecialInvoicesSearchGridPanel.Visible = true;
        this.AddSpecialInvoiceLineDetailsPanel.Visible = false;
        SpecialInvoiceLinesGridViewPanel.Visible = false;
    }


    private void OrderSelectedState(object sender, EventArgs args)
    {
        this.SpecialInvoiceHeaderPanel.Visible = true;
        this.OrderSearchPanel.Visible = false;
        this.SpecialInvoicesSearchGridPanel.Visible = false;
        this.AddSpecialInvoiceLineDetailsPanel.Visible = false;
        SpecialInvoiceLinesGridViewPanel.Visible = true;
    }

    private void CancelOrderState(object sender, EventArgs args)
    {
        this.SpecialInvoiceHeaderPanel.Visible = false;
        this.OrderSearchPanel.Visible = true;
        this.SpecialInvoicesSearchGridPanel.Visible = true;
        this.AddSpecialInvoiceLineDetailsPanel.Visible = false;
        SpecialInvoiceLinesGridViewPanel.Visible = false;
    }

    private void OrderLineAddedState(object sender, EventArgs args)
    {
        this.SpecialInvoiceHeaderPanel.Visible = false;
        this.OrderSearchPanel.Visible = true;
        this.SpecialInvoicesSearchGridPanel.Visible = true;
        this.AddSpecialInvoiceLineDetailsPanel.Visible = false;
        SpecialInvoiceLinesGridViewPanel.Visible = false;

        Util.ClearControls(AddSpecialInvoiceLineDetailsPanel);
    }

    #endregion

    #region Private Methods

    #endregion
  
}
