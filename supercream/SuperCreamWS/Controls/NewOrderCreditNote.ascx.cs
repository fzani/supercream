using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App_Code.EventArgs;

public partial class Controls_NewOrderCreditNote : System.Web.UI.UserControl
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

        this.NewCreditNoteSearch.InvoiceEventHandler += new InvoiceEventHandler(NewCreditNoteSearch_InvoiceEventHandler);
        this.OrderCreditNoteHeader.OrderCreditNoteContinueEventHandler += new OrderCreditNoteContinueEventHandler(NewCreditNoteSearch_ModifyOrderCreditNoteLines);      
        this.OrderCreditNoteHeader.ErrorMessageEventHandler += new ErrorMessageEventHandler(NewCreditNoteSearch_ErrorMessageEventHandler);
    }   

    #endregion

    #region Call Back Handlers

    private void NewCreditNoteSearch_InvoiceEventHandler(object sender, InvoiceEventEventArgs e)
    {
        this.OrderCreditNoteHeader.OrderID = e.OrderID;

        this.ChangeState += new EventHandler<EventArgs>((o, args) => this.ModifyOrderCreditNoteHeaderState(o, args));
        this.ChangeState(this, new EventArgs());
    }

    private void NewCreditNoteSearch_ModifyOrderCreditNoteLines(object sender, OrderCreditNoteContinueEventArgs e)
    {
        this.ModifyOrderCreditNoteLines.OrderID = e.OrderId;
        this.ModifyOrderCreditNoteLines.AlphaID = e.AlphaId;
        this.ModifyOrderCreditNoteLines.CreditNoteID = e.CreditNoteId;
        this.ModifyOrderCreditNoteLines.DataBind();

        this.ChangeState += new EventHandler<EventArgs>(this.ModifyOrderCreditNoteLinesState);
        this.ChangeState(this, new EventArgs());
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

    private void NewCreditNoteSearch_ErrorMessageEventHandler(object sender, ErrorMessageEventArgs e)
    {
        if (this.ErrorMessageEventHandler != null)
        {
            this.ErrorMessageEventHandler(sender, e);
        }
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
        this.NewCreditNoteSearch.Visible = true;
        this.OrderCreditNoteHeader.Visible = false;
        this.ModifyOrderCreditNoteLines.Visible = false;
        this.CancelButton.Text = "Cancel";
    }

    private void ModifyOrderCreditNoteHeaderState(object sender, EventArgs args)
    {
        this.NewCreditNoteSearch.Visible = false;
        this.OrderCreditNoteHeader.Visible = true;
        this.ModifyOrderCreditNoteLines.Visible = false;
        this.CancelButton.Text = "Cancel";
    }

    private void ModifyOrderCreditNoteLinesState(object sender, EventArgs args)
    {
        this.NewCreditNoteSearch.Visible = false;
        this.OrderCreditNoteHeader.Visible = false;
        this.ModifyOrderCreditNoteLines.Visible = true;
        this.CancelButton.Text = "Continue";
    }

    #endregion

}
