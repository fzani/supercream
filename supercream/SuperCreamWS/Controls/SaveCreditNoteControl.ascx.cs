using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
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

    public int? OrderID
    {
        get
        {
            return ViewState["OrderID"] as int?;
        }

        set
        {
            if (value != null)
            {
                ViewState["OrderID"] = value;
                this.SetCreditNoteForOrderSaveStatuses();
                this.CreditNoteID = null;
            }
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
            if (value != null)
            {
                ViewState["CreditNoteID"] = value;
                this.SetCreditNoteForCreditNoteSaveStatuses();
                this.OrderID = null;
            }
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

        this.TotalInvoiceAmountLabel.Text = totalInvoiceAmount.ToString("c");
        this.InvoiceAmountCreditedLabel.Text = invoiceAmountCredited.ToString("c");
        this.AmountAvailableToBeCreditedLabel.Text = (totalInvoiceAmount - invoiceAmountCredited).ToString("c");
    }

    private void SetCreditNoteForCreditNoteSaveStatuses()
    {
        ////CreditNoteUI creditNoteUI = new CreditNoteUI();
        ////invoiceCreditNoteDetails = creditNoteUI.GetInvoiceCreditNoteDetails(OrderID.Value);

        ////decimal totalInvoiceAmount = invoiceCreditNoteDetails.TotalInvoiceAmount;
        ////decimal invoiceAmountCredited = invoiceCreditNoteDetails.TotalAmountCredited;

        ////this.TotalInvoiceAmountLabel.Text = totalInvoiceAmount.ToString("c");
        ////this.InvoiceAmountCreditedLabel.Text = invoiceAmountCredited.ToString("c");
        ////this.AmountAvailableToBeCreditedLabel.Text = (totalInvoiceAmount - invoiceAmountCredited).ToString("c");
    }

    #endregion

    #region General Event Hanadlers

    protected void SaveButton_Click(object sender, EventArgs e)
    {
        try
        {
            decimal creditAmout = String.IsNullOrEmpty(this.AmountToCreditTextBox.Text) ? new decimal(0.0) : Util.ConvertStringToDecimal(this.AmountToCreditTextBox.Text);
            if ((Util.ConvertStringToDecimal(this.TotalInvoiceAmountLabel.Text) - Util.ConvertStringToDecimal(this.AmountToCreditTextBox.Text) - creditAmout) < 0)
                throw new ApplicationException("Cannot credit for more than the invoicable amount");

            CreditNoteUI ui = new CreditNoteUI();
            ui.SaveCreditNote(new CreditNote
            {
                ID = -1,
                OrderID = this.OrderID.Value,
                CreditAmount = creditAmout,
                DateCreated = DateTime.Now,
                Reason = this.ReasonTextBox.Text
            });

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

    #endregion
}
