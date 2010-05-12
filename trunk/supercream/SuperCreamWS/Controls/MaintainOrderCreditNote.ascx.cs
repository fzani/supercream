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
        this.OrderCreditNoteHeader.OrderCreditNoteContinueEventHandler += new App_Code.EventArgs.OrderCreditNoteContinueEventHandler(OrderCreditNoteHeader_OrderCreditNoteContinueEventHandler);
        this.OrderCreditNoteHeader.ErrorMessageEventHandler += new ErrorMessageEventHandler(OrderCreditNoteHeader_ErrorMessageEventHandler);
        this.OrderCreditNoteHeader.CancelEventHandler += new CancelEventHandler(OrderCreditNoteHeader_CancelEventHandler);
        this.ModifyOrderCreditNoteLines.ErrorMessageEventHandler += new ErrorMessageEventHandler(OrderCreditNoteHeader_ErrorMessageEventHandler);
    }

    #endregion

    #region Call Back Handlers

    private void CreditNoteSearch_CreditNoteEventHandler(object sender, CreditNoteEventArgs e)
    {
        this.ChangeState += new EventHandler<EventArgs>(this.OrderCreditNoteHeaderState);
        this.ChangeState(this, new EventArgs());

        this.OrderCreditNoteHeader.CreditNoteID = e.CreditNoteID;
    }

    private void OrderCreditNoteHeader_OrderCreditNoteContinueEventHandler(object sender, App_Code.EventArgs.OrderCreditNoteContinueEventArgs e)
    {
        this.ChangeState += new EventHandler<EventArgs>(this.ModifyOrderCreditNoteState);
        this.ModifyOrderCreditNoteLines.CreditNoteID = e.CreditNoteId;
        this.ModifyOrderCreditNoteLines.OrderID = e.OrderId;
        this.ModifyOrderCreditNoteLines.AlphaID = e.AlphaId;
        this.ModifyOrderCreditNoteLines.CreditNotePanelVisible = true;
        this.CancelButton.Text = "Continue";
        ModifyOrderCreditNoteLines.DataBind();
        this.ChangeState(this, new EventArgs());

    }

    private void OrderCreditNoteHeader_ErrorMessageEventHandler(object sender, ErrorMessageEventArgs e)
    {
        if (this.ErrorMessageEventHandler != null)
        {
            this.ErrorMessageEventHandler(sender, e);
        }
    }

    private void OrderCreditNoteHeader_CancelEventHandler(object sender, EventArgs e)
    {
        this.ChangeState += new EventHandler<EventArgs>(InitialiseCreditNoteState);
        this.ChangeState(this, new EventArgs());

        if (this.CancelEventHandler != null)
        {
            this.CancelEventHandler(this, new EventArgs());
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

    #region Page States

    private void InitialiseCreditNoteState(object sender, EventArgs args)
    {
        this.OrderCreditNoteHeader.Visible = false;
        this.CreditNoteSearch.Visible = true;
        this.ModifyOrderCreditNoteLines.Visible = false;
        this.CancelButton.Text = "Cancel";
    }

    private void OrderCreditNoteHeaderState(object sender, EventArgs args)
    {
        this.OrderCreditNoteHeader.Visible = true;
        this.CreditNoteSearch.Visible = false;
        this.ModifyOrderCreditNoteLines.Visible = false;
    }

    private void ModifyOrderCreditNoteState(object sender, EventArgs args)
    {
        this.OrderCreditNoteHeader.Visible = false;
        this.CreditNoteSearch.Visible = false;
        this.ModifyOrderCreditNoteLines.Visible = true;
    }

    #endregion
}
