using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controls_NewSpecialInvoiceCreditNote : System.Web.UI.UserControl
{
    #region Private Member Variables

    EventHandler<EventArgs> ChangeState;

    #endregion

    #region Public Events

    public event ErrorMessageEventHandler ErrorMessageEventHandler;
    public event CancelEventHandler CancelEventHandler;
    public event CompletedEventHandler CompletedEventHandler;

    #endregion

    #region Page Event Handler

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.ChangeState += new EventHandler<EventArgs>(this.InitialiseCreditNoteState);
            this.ChangeState(this, new EventArgs());
        }

        this.NewSpecialInvoiceCreditNoteSearch.InvoiceEventHandler += new InvoiceEventHandler(NewCreditNoteSearch_InvoiceEventHandler);
        this.SaveSpecialInvoiceCreditNoteControl.CompletedEventHandler += new CompletedEventHandler(Completed_InvoiceEventHandler);
        this.SaveSpecialInvoiceCreditNoteControl.ErrorMessageEventHandler += new ErrorMessageEventHandler(SaveCreditNoteControl_ErrorMessageEventHandler);
    }

    #endregion

    #region Call Back Handlers

    private void SaveCreditNoteControl_ErrorMessageEventHandler(object sender, ErrorMessageEventArgs e)
    {
        if (this.ErrorMessageEventHandler != null)
        {
            this.ErrorMessageEventHandler(sender, e);
        }
    }

    private void Completed_InvoiceEventHandler(object sender, EventArgs e)
    {
        if (this.CompletedEventHandler != null)
        {
            this.ChangeState += new EventHandler<EventArgs>(this.InitialiseCreditNoteState);
            this.ChangeState(this, new EventArgs());

            this.CompletedEventHandler(this, new EventArgs());
        }
    }

    private void NewCreditNoteSearch_InvoiceEventHandler(object sender, InvoiceEventEventArgs e)
    {
        this.SaveSpecialInvoiceCreditNoteControl.SpecialInvoiceID = e.OrderID;

        this.ChangeState += new EventHandler<EventArgs>(this.SaveCreditNoteState);
        this.ChangeState(this, new EventArgs());
    }

    #endregion

    #region General Events

    protected void CancelButton_Click(object sender, EventArgs e)
    {
        this.ChangeState += new EventHandler<EventArgs>(InitialiseCreditNoteState);
        this.ChangeState(this, new EventArgs());

        if (this.CancelEventHandler != null)
        {
            this.CancelEventHandler(this, new EventArgs());
        }
    }

    #endregion

    #region Page Event Handlers

    private void InitialiseCreditNoteState(object sender, EventArgs args)
    {
        this.SaveSpecialInvoiceCreditNoteControl.Visible = false;
        this.NewSpecialInvoiceCreditNoteSearch.Visible = true;
    }

    private void SaveCreditNoteState(object sender, EventArgs args)
    {
        this.SaveSpecialInvoiceCreditNoteControl.Visible = true;
        this.NewSpecialInvoiceCreditNoteSearch.Visible = false;
    }

    #endregion

}
