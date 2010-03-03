using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CreditNote_CreditNote : System.Web.UI.Page
{

    #region Private Member Variables
    EventHandler<EventArgs> ChangeState;
    #endregion

    #region Page Load Event

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
        }

        this.ChangeState += new EventHandler<EventArgs>(PageLoadState);
        this.ChangeState(this, new EventArgs());

        this.NewCreditNote.CancelEventHandler += new CancelEventHandler(NewCreditNote_CancelEventHandler);

    } 

    #endregion

    #region General Event Handlers

    void NewCreditNote_CancelEventHandler(object sender, EventArgs e)
    {
        Util.ClearControls(this.NewCreditNote);

        this.ChangeState += new EventHandler<EventArgs>(this.PageLoadState);
        this.ChangeState(this, new EventArgs());
    }

    protected void NewCreditNoteButton_Click(object sender, EventArgs e)
    {
        this.ChangeState += new EventHandler<EventArgs>(this.NewCreditNoteState);
        this.ChangeState(this, new EventArgs());
    }
    
    protected void MaintainCreditNoteButton_Click(object sender, EventArgs e)
    {
        this.ChangeState += new EventHandler<EventArgs>(this.MaintainCreditNoteState);
        this.ChangeState(this, new EventArgs());
    }

    #endregion

    #region Page States

    public void PageLoadState(object sender, EventArgs args)
    {
        this.NewCreditNote.Visible = false;
        this.MaintainCreditNote.Visible = false;
    }

    public void NewCreditNoteState(object sender, EventArgs args)
    {
        this.NewCreditNote.Visible = true;
        this.MaintainCreditNote.Visible = false;
    }

    public void MaintainCreditNoteState(object sender, EventArgs args)
    {
        this.NewCreditNote.Visible = true;
        this.MaintainCreditNote.Visible = false;
    }

    #endregion
}

