using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SP.Util;
using WcfFoundationService;

public partial class Controls_SaveCreditNoteControl : System.Web.UI.UserControl
{
    #region Public Event Handlers

    public event ErrorMessageEventHandler ErrorMessageEventHandler;
    public CompletedEventHandler CompletedEventHandler;

    #endregion

    #region Private Properties

    private InvoiceCreditNoteDetails invoiceCreditNoteDetails;

    #endregion

    #region Public Properies

    public bool? IsNewCreditNote
    {
        get
        {
            return ViewState["IsNewCreditNote"] as bool?;
        }

        set
        {
            ViewState["IsNewCreditNote"] = value;
        }

    }

    public int? OrderID
    {
        get
        {
            return ViewState["OrderID"] as int?;
        }

        set
        {
            ViewState["OrderID"] = value;
            this.SetCreditNoteForOrderSaveStatuses();
            this.IsNewCreditNote = true;
            this.DeleteButton.Visible = false;
        }
    }

    public int? CreditNoteID
    {
        get
        {
            return ViewState["CreditNoteID"] as int?;
        }

        set
        {
            ViewState["CreditNoteID"] = value;
            this.SetCreditNoteForCreditNoteSaveStatuses();
            this.IsNewCreditNote = false;
            this.DeleteButton.Visible = true;
        }
    }

    #endregion

    #region Page Load Event Handler

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    private void SetCreditNoteForOrderSaveStatuses()
    {
        CreditNoteUI creditNoteUI = new CreditNoteUI();
        invoiceCreditNoteDetails = creditNoteUI.GetInvoiceCreditNoteDetails(OrderID.Value);

        decimal totalInvoiceAmount = invoiceCreditNoteDetails.TotalInvoiceAmount;
        decimal invoiceAmountCredited = invoiceCreditNoteDetails.TotalAmountCredited;
        this.DueDateTextBox.Text = DateTime.Now.AddDays(7).ToShortDateString();

        this.TotalInvoiceAmountLabel.Text = totalInvoiceAmount.ToString("c");
        this.InvoiceAmountCreditedLabel.Text = invoiceAmountCredited.ToString("c");
        this.AmountAvailableToBeCreditedLabel.Text = (totalInvoiceAmount - invoiceAmountCredited).ToString("c");
        AutoGenUI autoGenUI = new AutoGenUI();

        this.PrintButton.Visible = false;
    }

    private void SetCreditNoteForCreditNoteSaveStatuses()
    {
        CreditNoteUI creditNoteUI = new CreditNoteUI();
        CreditNote creditNote = creditNoteUI.GetCreditNote(CreditNoteID.Value);
        this.OrderID = creditNote.OrderID;
        invoiceCreditNoteDetails = creditNoteUI.GetInvoiceCreditNoteDetails(creditNote.OrderID);

        this.creditNoteLabel.Text = creditNote.Reference;

        decimal totalInvoiceAmount = invoiceCreditNoteDetails.TotalInvoiceAmount;
        decimal invoiceAmountCredited = invoiceCreditNoteDetails.TotalAmountCredited;

        this.TotalInvoiceAmountLabel.Text = totalInvoiceAmount.ToString("c");
        this.InvoiceAmountCreditedLabel.Text = invoiceAmountCredited.ToString("c");
        this.AmountAvailableToBeCreditedLabel.Text = (totalInvoiceAmount - invoiceAmountCredited).ToString("c");
        this.DueDateTextBox.Text = creditNote.DueDate.ToShortDateString();

        this.AmountToCreditTextBox.Text = creditNote.CreditAmount.ToString("c");
        this.ReasonTextBox.Text = creditNote.Reason;
        this.VatExemptCheckBox.Checked = creditNote.VatExempt;

        this.PrintButton.Visible = true;
    }

    #endregion

    #region General Event Hanadlers

    protected void SaveButton_Click(object sender, EventArgs e)
    {
        try
        {
            OrderHeaderUI orderHeaderUI = new OrderHeaderUI();
            OrderHeader orderHeader = orderHeaderUI.GetById(this.OrderID.Value);

            CreditNoteUI creditNoteUI = new CreditNoteUI();
            invoiceCreditNoteDetails = creditNoteUI.GetInvoiceCreditNoteDetails(this.OrderID.Value);

            VatCodeUI vatCodeUI = new VatCodeUI();
            VatCode vatCode = vatCodeUI.GetByID(orderHeader.VatCodeID);

            var currentCreditAmount = String.IsNullOrEmpty(this.AmountToCreditTextBox.Text) ? new decimal(0.0) :
                String.IsNullOrEmpty(this.AmountToCreditTextBox.Text) ? new decimal(0.0) : Util.ConvertStringToDecimal(this.AmountToCreditTextBox.Text);

            // Get oustanding credit already applied
            decimal oustandingCreditedAmount;
            if (this.IsNewCreditNote.Value)
            {
                oustandingCreditedAmount =
                    creditNoteUI.GetOustandingCreditBalance(this.OrderID.Value, -1, new decimal(vatCode.PercentageValue));
            }
            else
            {
                oustandingCreditedAmount =
                    creditNoteUI.GetOustandingCreditBalance(this.OrderID.Value, this.CreditNoteID.Value, new decimal(vatCode.PercentageValue));
            }

            // Check that we are not crediting too much
            decimal totalAmountThatWillBeCredited = Util.ConvertStringToDecimal(this.TotalInvoiceAmountLabel.Text) -
                                  oustandingCreditedAmount -
                                  this.CalculateCreditAmount(currentCreditAmount, new decimal(vatCode.PercentageValue));
            if (totalAmountThatWillBeCredited < 0)
                throw new ApplicationException("Cannot credit for more than the invoicable amount");

            // Persist credit note details
            CreditNoteUI ui = new CreditNoteUI();
            if (this.IsNewCreditNote.Value)
            {
                ui.SaveCreditNote(new CreditNote
                {
                    ID = -1,
                    OrderID = this.OrderID.Value,
                    CreditAmount = currentCreditAmount,
                    DateCreated = DateTime.Now,
                    Reason = this.ReasonTextBox.Text,
                    VatExempt = this.VatExemptCheckBox.Checked,
                    DueDate = Convert.ToDateTime(this.DueDateTextBox.Text)
                });
            }
            else
            {
                CreditNote creditNote = ui.GetCreditNote(CreditNoteID.Value);
                ui.UpdateCreditNotes(new CreditNote
                {
                    ID = CreditNoteID.Value,
                    OrderID = creditNote.OrderID,
                    CreditAmount = currentCreditAmount,
                    DateCreated = DateTime.Now,
                    Reason = this.ReasonTextBox.Text,
                    Reference = creditNote.Reference,
                    VatExempt = this.VatExemptCheckBox.Checked,
                    DueDate = Convert.ToDateTime(this.DueDateTextBox.Text)
                });
            }

            if (this.CompletedEventHandler != null)
            {
                this.CompletedEventHandler(this, new EventArgs());
            }
        }
        catch (Exception ex)
        {
            if (this.ErrorMessageEventHandler != null)
            {
                ErrorMessageEventArgs arg = new ErrorMessageEventArgs();
                arg.AddErrorMessages(ex.Message);
                ErrorMessageEventHandler(this, arg);
            }
        }
    }

    protected void PrintButton_Click(object sender, EventArgs e)
    {
        OrderNotesStatusUI ui = new OrderNotesStatusUI();

        var orderNoteStatus = ui.GetOrderNotesStatusByOrderID(this.OrderID.Value);

        SP.Util.UrlParameterPasser p = new UrlParameterPasser("~/CreditNote/CreditNoteReport.aspx");
        p["creditNoteId"] = this.CreditNoteID.Value.ToString();
        p["accountId"] = orderNoteStatus.AccountID.ToString();
        p.PassParameters();
    }

    protected void DeleteButton_Click(object sender, EventArgs e)
    {
        if (CreditNoteID != null)
        {
            CreditNoteUI ui = new CreditNoteUI();
            CreditNote creditNote = ui.GetCreditNote(this.CreditNoteID.Value);
            ui.Delete(creditNote);

            if (this.CompletedEventHandler != null)
            {
                this.CompletedEventHandler(this, new EventArgs());
            }
        }
    }

    #endregion

    #region Private Helper
    private decimal CalculateCreditAmount(decimal creditAmount, decimal actualVatRate)
    {
        if (this.VatExemptCheckBox.Checked)
        {
            return creditAmount;
        }
        else
        {
            return creditAmount * ((actualVatRate / 100) + 1);
        }
    }

    #endregion

}
