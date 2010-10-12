using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SP.Core;
using SP.Core.Domain;

public partial class EditBundledOrder : System.Web.UI.UserControl
{
    #region Public Events

    public event ErrorMessageEventHandler ErrorMessageEventHandler;
    public event DataBindEventHandler DataBindEventHandler;

    #endregion

    #region Page Load Event

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    #endregion

    #region Form Events

    protected void FormView1_ItemInserted(object sender, FormViewInsertedEventArgs e)
    {
        Exception ex = e.Exception;
        if (ex != null)
        {
            e.ExceptionHandled = true;
            HandleException(ex, e);
        }

        if (this.DataBindEventHandler != null)
        {
            DataBindEventHandler(this, new DataBindEventArgs());
        }
    }

    protected void FormView1_ItemUpdated(object sender, FormViewUpdatedEventArgs e)
    {
        Exception ex = e.Exception;
        if (ex != null)
        {
            e.ExceptionHandled = true;
            HandleException(ex, e);
        }

        if (this.DataBindEventHandler != null)
        {
            DataBindEventHandler(this, new DataBindEventArgs());
        }
    }
    protected void FormView1_ItemDeleted(object sender, FormViewDeletedEventArgs e)
    {
        Exception ex = e.Exception;
        if (ex != null)
        {
            e.ExceptionHandled = true;
            HandleException(ex, e);
        }

        if (this.DataBindEventHandler != null)
        {
            DataBindEventHandler(this, new DataBindEventArgs());
        }
    }

    #endregion

    #region Error Handling

    /**************************************************************************
    * General Exception handlers
    ***************************************************************************/
    private void HandleException(Exception ex, EventArgs e)
    {
        var errorMessageEventArgs = new ErrorMessageEventArgs();

        if (ex.InnerException != null)
        {
            errorMessageEventArgs.AddErrorMessages(ex.InnerException.Message);
        }
        else
        {
            errorMessageEventArgs.AddErrorMessages(ex.Message);
        }

        if (this.ErrorMessageEventHandler != null)
        {
            this.ErrorMessageEventHandler(this, errorMessageEventArgs);
        }
    }

    #endregion
}
