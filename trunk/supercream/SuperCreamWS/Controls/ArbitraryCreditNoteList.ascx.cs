using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controls_ArbitraryCreditNoteList : System.Web.UI.UserControl
{
    #region Private Member Variables

    private int creditNoteId;

    #endregion

    #region Page Load Event

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    #endregion

    #region Public Properties

    public int CreditNoteId
    {
        get { return creditNoteId; }
        set { creditNoteId = value; }
    }

    #endregion

    #region Object Data Source events

    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        e.InputParameters[0] = this.CreditNoteId;
    }

    #endregion
}
