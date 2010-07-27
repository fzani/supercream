using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_SetupPrinter : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (String.IsNullOrEmpty(Profile.PrinterName))
            {
                UpdateButton.Text = "Save";
            }
            else
            {
                this.PrinterNameTextBox.Text = Profile.PrinterName;
            }
        }
    }

    protected void UpdateButton_Click(object sender, EventArgs e)
    {
        Profile.PrinterName = this.PrinterNameTextBox.Text;
        Profile.Save();
        Response.Redirect("~/General/Default.aspx");
    }
}
