using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SP.Core.Domain;
using SP.Mvp;
using WebFormsMvp;

using SP.Core.Domain;

public interface IEditBundledOrderView : IView<BundledOffer>
{
    event EventHandler<GettingOfferEventArgs> GettingOffers;
    event EventHandler GettingOffersTotalCount;
    event EventHandler<UpdateOfferEventArgs> UpdatingOffer;
    event EventHandler<EditOfferEventArgs> InsertingOffer;
    event EventHandler<EditOfferEventArgs> DeletingOffer;
}

public class GettingOfferEventArgs : EventArgs
{
    public int MaximumRows { get; private set; }
    public int StartRowIndex { get; private set; }

    public GettingOfferEventArgs(int maximumRows, int startRowIndex)
    {
        MaximumRows = maximumRows;
        StartRowIndex = startRowIndex;
    }
}

public class UpdateOfferEventArgs : EventArgs
{
    public SP.Mvp.Offer Offer { get; private set; }
    public SP.Mvp.Offer OriginalOffer { get; private set; }

    public UpdateOfferEventArgs(SP.Mvp.Offer offer, SP.Mvp.Offer originalOffer)
    {
        Offer = offer;
        OriginalOffer = originalOffer;
    }
}

public class EditOfferEventArgs : EventArgs
{
    public SP.Mvp.Offer Offer { get; private set; }

    public EditOfferEventArgs(SP.Mvp.Offer offer)
    {
        Offer = offer;
    }
}

