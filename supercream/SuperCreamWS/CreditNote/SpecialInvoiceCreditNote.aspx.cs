using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SpecialInvoiceCreditNote_CreditNote : System.Web.UI.Page
{

    #region Private Member Variables
    EventHandler<EventArgs> ChangeState;
    #endregion

    #region Page Load Event

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.ChangeState += new EventHandler<EventArgs>(PageLoadState);
            this.ChangeState(this, new EventArgs());
        }

        this.ErrorViewControl.Visible = false;

        this.NewSpecialInvoiceCreditNote.CancelEventHandler += new CancelEventHandler(NewCreditNote_CancelEventHandler);
        this.NewSpecialInvoiceCreditNote.ErrorMessageEventHandler += new ErrorMessageEventHandler(NewCreditNote_ErrorMessageEventHandler);
        this.NewSpecialInvoiceCreditNote.CompletedEventHandler += new CompletedEventHandler(NewCreditNote_CompletedEventHandler);

        this.MaintainSpecialInvoiceCreditNote.CancelEventHandler += new CancelEventHandler(NewCreditNote_CancelEventHandler);
        this.MaintainSpecialInvoiceCreditNote.ErrorMessageEventHandler += new ErrorMessageEventHandler(NewCreditNote_ErrorMessageEventHandler);
        this.MaintainSpecialInvoiceCreditNote.CompletedEventHandler += new CompletedEventHandler(NewCreditNote_CompletedEventHandler);
    }

    #endregion

    #region General Event Handlers

    void NewCreditNote_ErrorMessageEventHandler(object sender, ErrorMessageEventArgs e)
    {
        foreach (string errorMessage in e.ErrorMessages)
            ErrorViewControl.AddError(errorMessage);
        ErrorViewControl.Visible = true;
        ErrorViewControl.DataBind();
    }

    void NewCreditNote_CompletedEventHandler(object sender, EventArgs e)
    {
        Util.ClearControls(this.NewSpecialInvoiceCreditNote);

        this.ChangeState += new EventHandler<EventArgs>(this.PageLoadState);
        this.ChangeState(this, new EventArgs());
    }

    void NewCreditNote_CancelEventHandler(object sender, EventArgs e)
    {
        Util.ClearControls(this.NewSpecialInvoiceCreditNote);

        this.ChangeState += new EventHandler<EventArgs>(this.PageLoadState);
        this.ChangeState(this, new EventArgs());
    }

    protected void NewCreditNoteButton_Click(object sender, EventArgs e)
    {
        this.ChangeState += new EventHandler<EventArgs>(this.NewCreditNoteState);
        this.ChangeState(this, new EventArgs());

        this.DataBind();
    }

    protected void MaintainCreditNoteButton_Click(object sender, EventArgs e)
    {
        this.ChangeState += new EventHandler<EventArgs>(this.MaintainCreditNoteState);
        this.ChangeState(this, new EventArgs());

        this.DataBind();
    }

    #endregion

    #region Page States

    public void PageLoadState(object sender, EventArgs args)
    {
        this.NewSpecialInvoiceCreditNote.Visible = false;
        this.MaintainSpecialInvoiceCreditNote.Visible = false;
    }

    public void NewCreditNoteState(object sender, EventArgs args)
    {
        this.NewSpecialInvoiceCreditNote.Visible = true;
        this.MaintainSpecialInvoiceCreditNote.Visible = false;
    }

    public void MaintainCreditNoteState(object sender, EventArgs args)
    {
        this.NewSpecialInvoiceCreditNote.Visible = false;
        this.MaintainSpecialInvoiceCreditNote.Visible = true;
    }

    #endregion
}

