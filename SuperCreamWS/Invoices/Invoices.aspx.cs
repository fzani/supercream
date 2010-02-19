using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Invoices_Invoices : System.Web.UI.Page
{
    #region Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        ErrorViewControl.Visible = false;
        MaintainInvoice1.ErrorMessageEventHandler += new ErrorMessageEventHandler(MaintainInvoice1_ErrorMessageEventHandler);
    }
    #endregion

    #region Call Back Handlers
    void MaintainInvoice1_ErrorMessageEventHandler(object sender, ErrorMessageEventArgs e)
    {
        foreach (string errorMessage in e.ErrorMessages)
            ErrorViewControl.AddError(errorMessage);
        ErrorViewControl.Visible = true;
        ErrorViewControl.DataBind();
    }
    #endregion
}
