using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_AuditEvents : System.Web.UI.Page
{
    #region Page Load Event

    private int totalRows = 0;
    private int currentPage;

    protected void Page_Load(object sender, EventArgs e)
    {       
        if (!IsPostBack)
        {         
            try
            {
                SystemUserUI systemUserUI = new SystemUserUI();
               
                LoginIDDropDownList.Items.Add(new ListItem("-- No Item Selected --", "-1"));
                List<string> userList = systemUserUI.GetAllSystemUsers();
                foreach (string systemUser in userList)
                {
                    LoginIDDropDownList.Items.Add(new ListItem(systemUser));
                }
               
                AuditEventsUI aui = new AuditEventsUI();
                DescriptionDropDownList.Items.Add(new ListItem("-- No Item Selected --", "-1"));
                List<string> descriptionList = aui.AuditEventDescriptions();
                int i = 0;
                foreach (string description in descriptionList)
                {
                    DescriptionDropDownList.Items.Add(new ListItem(description,
                        (i++).ToString()));
                }
               
                DataBind();               
            }
            catch (Exception ex)
            {
                ErrorViewControl.Visible = true;
                if (ex.InnerException != null)
                    ErrorViewControl.AddError(ex.InnerException.Message);
                else
                    ErrorViewControl.AddError(ex.Message);

                ErrorViewControl.DataBind();
            }
        }
        else
            ErrorViewControl.Visible = false;
    }
    #endregion

    #region General Button Handlers
    protected void SearchButton_Click(object sender, EventArgs e)
    {
        try
        {
            ValidateDate();
            AuditEventsGridView.DataBind();
        }
        catch (Exception ex)
        {
            ErrorViewControl.Visible = true;
            ErrorViewControl.AddError(ex.Message);
            ErrorViewControl.DataBind();
        }
    }

    #endregion

    #region DropDown List Events
    protected void LoginIDDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        ValidateDate();
        AuditEventsGridView.DataBind();
    }

    protected void DescriptionDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        ValidateDate();
        AuditEventsGridView.DataBind();
    }
    #endregion

    #region Object Source Events
    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {             
        e.InputParameters[0] = (DescriptionDropDownList.SelectedValue == "-1") ? null : DescriptionDropDownList.SelectedItem.Text;
        e.InputParameters[1] = (LoginIDDropDownList.SelectedValue == "-1") ? null : LoginIDDropDownList.SelectedValue;
        e.InputParameters[2] = (String.IsNullOrEmpty(CreatedDateTextBox.Text)) ? DateTime.MinValue : Convert.ToDateTime(CreatedDateTextBox.Text);
    }
    #endregion

    #region Utils

    protected void ValidateDate()
    {
        if (CreatedDateTextBox.Text == "__/__/____")
            CreatedDateTextBox.Text = String.Empty;

        DateTime result;
        if (DateTime.TryParse(CreatedDateTextBox.Text, out result))
        {
            DateTime t = String.IsNullOrEmpty(CreatedDateTextBox.Text) ?
               SP.Utils.Defaults.MinDateTime : Convert.ToDateTime(CreatedDateTextBox.Text);
            if (t < SP.Utils.Defaults.MinDateTime)
                throw new ApplicationException("Cannot set Date prior to 1800");
        }
        else
        {
            if (!String.IsNullOrEmpty(CreatedDateTextBox.Text))
                throw new ApplicationException("Invalid Date");
        }
    }

    #endregion

    #region Grid View Events

    protected void AuditEventsGridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    }

    #endregion
}
