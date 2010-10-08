using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SP.Core;
using SP.Core.Domain;
using SP.Mvp;
using WebFormsMvp;
using WebFormsMvp.Web;

//[PresenterBinding(typeof(EditBundledOrderPresenter), BindingMode = BindingMode.Default, ViewType = typeof(IView<Offer>))]
public partial class EditBundledOrder : MvpUserControl<Offer>, IEditBundledOrderView
{
    protected void Page_Load(object sender, EventArgs e)
    {     
    }
}
