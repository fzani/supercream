using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controls_SaveCreditNoteControl : System.Web.UI.UserControl
{
    #region Public Properies

    public int? InvoiceID
    {
        get
        {
            return ViewState["InvoiceID"] as int?;
        }

        set
        {
            ViewState["InvoiceID"] = value;
        }
    }

    #endregion

    #region Page Load Event Handler

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    #endregion
}
