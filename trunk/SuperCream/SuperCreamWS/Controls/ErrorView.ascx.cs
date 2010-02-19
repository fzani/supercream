using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controls_ErrorView : System.Web.UI.UserControl
{
    List<ErrorMessage> errorList = new List<ErrorMessage>();

    protected void Page_Load(object sender, EventArgs e)
    {
        errorList = new List<ErrorMessage>();
    }

    public void AddError(string errorMessage)
    {
        ErrorMessage message = new ErrorMessage();
        message.Description = errorMessage;
        errorList.Add(message);
        ErrorMesssages.DataSource = errorList;              
    }
}
