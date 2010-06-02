﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SP.Util;
using WcfFoundationService;

public partial class Controls_SaveSpecialInvoiceCreditNoteControl : System.Web.UI.UserControl
{
    #region Public Event Handlers

    public event ErrorMessageEventHandler ErrorMessageEventHandler;
    public CompletedEventHandler CompletedEventHandler;

    #endregion

    #region Private Properties

    private SpecialInvoiceCreditNoteBalance specialInvoiceCreditNoteDetails;

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

    public int? SpecialInvoiceID
    {
        get
        {
            return ViewState["SpecialInvoiceID"] as int?;
        }

        set
        {
            ViewState["SpecialInvoiceID"] = value;
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
        this.specialInvoiceCreditNoteDetails = SpecialInvoiceCreditNoteUI.GetSpecialInvoiceCreditNoteBalance(SpecialInvoiceID.Value);

        decimal totalInvoiceAmount = specialInvoiceCreditNoteDetails.TotalInvoiceAmount;
        decimal invoiceAmountCredited = specialInvoiceCreditNoteDetails.TotalAmountCredited;
        this.DueDateTextBox.Text = DateTime.Now.AddDays(7).ToShortDateString();

        this.TotalInvoiceAmountLabel.Text = totalInvoiceAmount.ToString("c");
        this.InvoiceAmountCreditedLabel.Text = invoiceAmountCredited.ToString("c");
        this.AmountAvailableToBeCreditedLabel.Text = (totalInvoiceAmount - invoiceAmountCredited).ToString("c");
        AutoGenUI autoGenUI = new AutoGenUI();

        this.PrintButton.Visible = false;
    }

    private void SetCreditNoteForCreditNoteSaveStatuses()
    {
        SpecialInvoiceCreditNote creditNote = SpecialInvoiceCreditNoteUI.GetSpecialInvoiceCreditNote(CreditNoteID.Value);
        this.SpecialInvoiceID = creditNote.SpecialInvoiceID;
        this.specialInvoiceCreditNoteDetails = SpecialInvoiceCreditNoteUI.GetSpecialInvoiceCreditNoteBalance(creditNote.SpecialInvoiceID);

        this.creditNoteLabel.Text = creditNote.Reference;

        decimal totalInvoiceAmount = specialInvoiceCreditNoteDetails.TotalInvoiceAmount;
        decimal invoiceAmountCredited = specialInvoiceCreditNoteDetails.TotalAmountCredited;

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

    #region General Event Handlers

    protected void SaveButton_Click(object sender, EventArgs e)
    {
        try
        {
            SpecialInvoiceHeaderUI specialInvoiceHeaderUI = new SpecialInvoiceHeaderUI();
            SpecialInvoiceHeader specialInvoiceHeader = specialInvoiceHeaderUI.GetById(this.SpecialInvoiceID.Value);
            
            this.specialInvoiceCreditNoteDetails = SpecialInvoiceCreditNoteUI.GetSpecialInvoiceCreditNoteBalance(this.SpecialInvoiceID.Value);

            VatCodeUI vatCodeUI = new VatCodeUI();
            VatCode vatCode = vatCodeUI.GetByID(specialInvoiceHeader.VatCodeID);

            var currentCreditAmount = String.IsNullOrEmpty(this.AmountToCreditTextBox.Text) ? 
                new decimal(0.0) : Util.ConvertStringToDecimal(this.AmountToCreditTextBox.Text);

            // Get oustanding credit already applied
            decimal oustandingCreditedAmount;
            if (this.IsNewCreditNote.Value)
            {
                oustandingCreditedAmount =
                    SpecialInvoiceCreditNoteUI.GetSpecialInvoiceOustandingCreditBalance(this.SpecialInvoiceID.Value, -1, new decimal(vatCode.PercentageValue));
            }
            else
            {
                oustandingCreditedAmount =
                    SpecialInvoiceCreditNoteUI.GetSpecialInvoiceOustandingCreditBalance(this.SpecialInvoiceID.Value, this.CreditNoteID.Value, new decimal(vatCode.PercentageValue));
            }

            // Check that we are not crediting too much
            decimal totalAmountThatWillBeCredited = Util.ConvertStringToDecimal(this.TotalInvoiceAmountLabel.Text) -
                                  oustandingCreditedAmount -
                                  this.CalculateCreditAmount(currentCreditAmount, new decimal(vatCode.PercentageValue));
            if (totalAmountThatWillBeCredited < 0)
                throw new ApplicationException("Cannot credit for more than the invoicable amount");

            // Persist credit note details           
            if (this.IsNewCreditNote.Value)
            {
                SpecialInvoiceCreditNoteUI.SaveCreditNote(new SpecialInvoiceCreditNote
                {
                    ID = -1,
                    SpecialInvoiceID = this.SpecialInvoiceID.Value,
                    CreditAmount = currentCreditAmount,
                    DateCreated = DateTime.Now,
                    Reason = this.ReasonTextBox.Text,
                    VatExempt = this.VatExemptCheckBox.Checked,
                    DueDate = Convert.ToDateTime(this.DueDateTextBox.Text)
                });
            }
            else
            {
                SpecialInvoiceCreditNote creditNote = SpecialInvoiceCreditNoteUI.GetSpecialInvoiceCreditNote(CreditNoteID.Value);
                SpecialInvoiceCreditNoteUI.UpdateCreditNotes(new SpecialInvoiceCreditNote
                {
                    ID = CreditNoteID.Value,
                    SpecialInvoiceID = creditNote.SpecialInvoiceID,
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

        var orderNoteStatus = ui.GetOrderNotesStatusByOrderID(this.SpecialInvoiceID.Value);

        SP.Util.UrlParameterPasser p = new UrlParameterPasser("~/CreditNote/CreditNoteReport.aspx");
        p["creditNoteId"] = this.CreditNoteID.Value.ToString();
        p["accountId"] = orderNoteStatus.AccountID.ToString();
        p.PassParameters();
    }

    protected void DeleteButton_Click(object sender, EventArgs e)
    {
        if (CreditNoteID != null)
        {
            var creditNote = SpecialInvoiceCreditNoteUI.GetSpecialInvoiceCreditNote(this.CreditNoteID.Value);
            SpecialInvoiceCreditNoteUI.Delete(creditNote);

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
