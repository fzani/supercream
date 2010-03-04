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
            ViewState["OrderID"] = value;
            this.SetCreditNoteSaveStatuses();
        }
    }

    #endregion

    #region Page Load Event Handler

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    private void SetCreditNoteSaveStatuses()
    {
        CreditNoteUI creditNoteUI = new CreditNoteUI();
        invoiceCreditNoteDetails = creditNoteUI.GetInvoiceCreditNoteDetails(OrderID.Value);

        this.TotalInvoiceAmountLabel.Text = invoiceCreditNoteDetails.TotalInvoiceAmount.ToString("c");
        this.InvoiceAmountCreditedLabel.Text = invoiceCreditNoteDetails.TotalAmountCredited.ToString("c");
    }

    #endregion

    #region General Event Hanadlers

    protected void SaveButton_Click(object sender, EventArgs e)
    {
        try
        {
            decimal creditAmout = String.IsNullOrEmpty(this.AmountToCreditTextBox.Text) ? new decimal(0.0) : Util.ConvertStringToDecimal(this.AmountToCreditTextBox.Text);
            CreditNoteUI ui = new CreditNoteUI();
            ui.SaveCreditNote(new CreditNote
            {
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
