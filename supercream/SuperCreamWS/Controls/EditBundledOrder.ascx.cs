using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SP.Core;
using SP.Core.Domain;

//[PresenterBinding(typeof(EditBundledOrderPresenter), BindingMode = BindingMode.Default, ViewType = typeof(IView<Offer>))]
public partial class EditBundledOrder : System.Web.UI.UserControl
{
    public event ErrorMessageEventHandler ErrorMessageEventHandler;

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    public EditBundledOrder()
    {

    }

    protected void FormView1_ItemInserted(object sender, FormViewInsertedEventArgs e)
    {
        Exception ex = e.Exception;
        if (ex != null)
            HandleException(ex, e);
    }

    /**************************************************************************
    * General Exception handlers
    ***************************************************************************/
    private void HandleException(Exception ex, FormViewInsertedEventArgs e)
    {
        e.ExceptionHandled = true;
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
}
