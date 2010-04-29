using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controls_MaintainOrderCreditNote : System.Web.UI.UserControl
{
    #region Private Member Variables

    EventHandler<EventArgs> ChangeState;

    #endregion

    #region Public Events

    public event CancelEventHandler CancelEventHandler;
    public event ErrorMessageEventHandler ErrorMessageEventHandler;
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

        this.CreditNoteSearch.CreditNoteEventHandler += new CreditNoteEventHandler(CreditNoteSearch_CreditNoteEventHandler);      
        this.SaveCreditNoteControl.CompletedEventHandler += new CompletedEventHandler(Completed_InvoiceEventHandler);
        this.SaveCreditNoteControl.ErrorMessageEventHandler += new ErrorMessageEventHandler(SaveCreditNoteControl_ErrorMessageEventHandler);
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

    private void CreditNoteSearch_CreditNoteEventHandler(object sender, CreditNoteEventArgs e)
    {
        this.ChangeState += new EventHandler<EventArgs>(this.SaveCreditNoteState);
        this.ChangeState(this, new EventArgs());

        this.SaveCreditNoteControl.CreditNoteID = e.CreditNoteID;
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
        this.SaveCreditNoteControl.Visible = false;
        this.CreditNoteSearch.Visible = true;
    }

    private void SaveCreditNoteState(object sender, EventArgs args)
    {
        this.SaveCreditNoteControl.Visible = true;
        this.CreditNoteSearch.Visible = false;
    }

    #endregion
}
