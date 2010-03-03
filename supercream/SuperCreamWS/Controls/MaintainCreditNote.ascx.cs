﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controls_MaintainCreditNote : System.Web.UI.UserControl
{
    #region Private Member Variables

    EventHandler<EventArgs> ChangeState;

    #endregion

    #region Public Events

    public event CancelEventHandler CancelEventHandler;

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
    }

    #endregion

    #region Call Back Handlers

    private void CreditNoteSearch_CreditNoteEventHandler(object sender, CreditNoteEventArgs e)
    {
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
