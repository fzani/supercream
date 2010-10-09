using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SP.Mvp;
using WebFormsMvp;


public class EditBundledOrderPresenter : Presenter<IEditBundledOrderView>
{
    public EditBundledOrderPresenter()
        : this(null)
    {

    }

    public EditBundledOrderPresenter(IEditBundledOrderView view)
        : this(view, null)
    {
        // subscribe to the view's events :
        // in this case the Load event
        View.Load += View_Load;
    }

    public EditBundledOrderPresenter(IEditBundledOrderView view, IRepository<SP.Mvp.Offer> offerRepository)
        : base(view)
    {

    }

    public override void ReleaseView()
    {
        // clean up the delegate by detaching it
        View.Load -= View_Load;
    }

    // the core logic of the app where the Model is instantiated, fetched
    // and binded to the view
    private void View_Load(object sender, EventArgs e)
    {

    }
}

