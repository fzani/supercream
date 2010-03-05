using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Threading;

using WcfFoundationService;

public partial class Admin_Van : System.Web.UI.Page
{
    EventHandler<EventArgs> ChangeState;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ChangeState += new EventHandler<EventArgs>(PageDefaultLoadState);
            ChangeState(this, e);

            DataBind();
        }

        ErrorViewControl.Visible = false;

    }

    protected void AddVanButton_Click(object sender, EventArgs e)
    {
        try
        {
            ChangeState += new EventHandler<EventArgs>(PageDefaultLoadState);

            VanUI ui = new VanUI();
            Van cd = new Van();

            cd.ID = -1;
            cd.Description = DescriptionTextBox.Text;
            cd.MaximumReccomendedParcelCount = Convert.ToInt32(this.MaximumRecommendedTextBox.Text);

            ui.SaveVan(cd);

            ChangeState(this, e);
        }
        catch (Exception ex)
        {
            ErrorViewControl.AddError(ex.InnerException.Message);
            ErrorViewControl.Visible = true;
        }
    }

    /***************************************************************************
    * Page Event States
    ***************************************************************************/
    private void PageDefaultLoadState(object sender, EventArgs args)
    {
        using (VatCodeUI ui = new VatCodeUI())
        {
            ErrorViewControl.Visible = false;
            Util.ClearFields(this.Page);
            DataBind();
        }
    }

    /***************************************************************************
    * Object Data Source Events
    ***************************************************************************/

    protected void VansObjectDataSource_Updating(object sender, ObjectDataSourceMethodEventArgs e)
    {
        Van updatedVan = e.InputParameters[0] as Van;
        //  int id = Convert.ToInt32(e.InputParameters[1]);

        //Van updatedVan = new Van
        //{
        //    ID = id,
        //    Description = description,
        //};

        using (VanUI ui = new VanUI())
        {
            ui.UpdateVan(updatedVan);
        }
    }

    protected void VanObjectDataSource_Deleted(object sender, ObjectDataSourceStatusEventArgs e)
    {
        Exception ex = e.Exception;
        if (ex != null)
            HandleException(ex, e);
    }

    protected void VanObjectDataSource_Selected(object sender, ObjectDataSourceStatusEventArgs e)
    {
        Exception ex = e.Exception;
        if (ex != null)
            HandleException(ex, e);
    }

    protected void VansObjectDataSource_Updated(object sender, ObjectDataSourceStatusEventArgs e)
    {

    }

    protected void VansGridView_RowUpdated(object sender, GridViewUpdatedEventArgs e)
    {
        Exception ex = e.Exception;
        if (ex != null)
        {
            HandleException(ex, e);
            e.KeepInEditMode = true;
        }
        else
        {
            ChangeState += new EventHandler<EventArgs>(PageDefaultLoadState);
            ChangeState(this, e);
            DataBind();
        }
    }

    /**************************************************************************
   * General Exception handlers
   ***************************************************************************/
    private void HandleException(Exception ex, ObjectDataSourceStatusEventArgs e)
    {
        e.ExceptionHandled = true;
        ErrorViewControl.AddError(ex.InnerException.Message);
        ErrorViewControl.Visible = true;

        DataBind();
    }

    private void HandleException(Exception ex, GridViewUpdatedEventArgs e)
    {
        e.ExceptionHandled = true;
        if (ex.InnerException != null)
            ErrorViewControl.AddError(ex.InnerException.Message);
        else ErrorViewControl.AddError(ex.Message);

        ErrorViewControl.Visible = true;
    }
}
