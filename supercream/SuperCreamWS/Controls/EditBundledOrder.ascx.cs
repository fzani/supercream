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
public partial class EditBundledOrder : MvpUserControl<BundledOffer>, IEditBundledOrderView
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public EditBundledOrder()
    {
        AutoDataBind = false;
    }

    public IEnumerable<SP.Mvp.Offer> GetOffers(int maximumRows, int startRowIndex)
    {
        OnGettingOffers(maximumRows, startRowIndex);
        return Model.Offers;
    }

    public int GetOffersCount()
    {
        OnGettingOffersTotalCount();
        return Model.TotalCount;
    }

    public void UpdateOffer(SP.Mvp.Offer offer, SP.Mvp.Offer originalOffer)
    {
        OnUpdatingOffer(offer, originalOffer);
    }

    public void InsertOffer(SP.Mvp.Offer offer)
    {
        OnInsertingOffer(offer);
    }

    public void DeleteOffer(SP.Mvp.Offer offer)
    {
        OnDeletingOffer(offer);
    }

    public event EventHandler<GettingOfferEventArgs> GettingOffers;
    private void OnGettingOffers(int maximumRows, int startRowIndex)
    {
        if (GettingOffers != null)
        {
            GettingOffers(this, new GettingOfferEventArgs(maximumRows, startRowIndex));
        }
    }

    public event EventHandler GettingOffersTotalCount;
    private void OnGettingOffersTotalCount()
    {
        if (GettingOffersTotalCount != null)
        {
            GettingOffersTotalCount(this, EventArgs.Empty);
        }
    }

    public event EventHandler<UpdateOfferEventArgs> UpdatingOffer;
    private void OnUpdatingOffer(SP.Mvp.Offer Offer, SP.Mvp.Offer originalOffer)
    {
        if (UpdatingOffer != null)
        {
            UpdatingOffer(this, new UpdateOfferEventArgs(Offer, originalOffer));
        }
    }

    public event EventHandler<EditOfferEventArgs> InsertingOffer;
    private void OnInsertingOffer(SP.Mvp.Offer offer)
    {
        if (InsertingOffer != null)
        {
            InsertingOffer(this, new EditOfferEventArgs(offer));
        }
    }

    public event EventHandler<EditOfferEventArgs> DeletingOffer;
    private void OnDeletingOffer(SP.Mvp.Offer offer)
    {
        if (DeletingOffer != null)
        {
            DeletingOffer(this, new EditOfferEventArgs(offer));
        }
    }
}
