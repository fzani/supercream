using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DeliveryNotes_DeliveryNotes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ErrorViewControl.Visible = false;
        MaintainDeliveryNote1.ErrorMessageEventHandler += new ErrorMessageEventHandler(MaintainDeliveryNote1_ErrorMessageEventHandler);
    }

    void MaintainDeliveryNote1_ErrorMessageEventHandler(object sender, ErrorMessageEventArgs e)
    {
        foreach (string errorMessage in e.ErrorMessages)
            ErrorViewControl.AddError(errorMessage);
        ErrorViewControl.Visible = true;
        ErrorViewControl.DataBind();
    }
}
