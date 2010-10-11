using System;
using System.Collections.Generic;

using WcfFoundationService;

/// <summary>
/// Summary description for OrderListUI
/// </summary>
[System.ComponentModel.DataObject]
public class OfferUI
{
    public OfferUI()
    {
    }

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public List<Offer> GetAllOffers()
    {
        using (var proxy = new WcfFoundationService.FoundationServiceClient())
        {
            return proxy.GetAllOffers();
        }
    }

    public void SaveOffer(string name, DateTime validFrom, DateTime validTo)
    {
        using (var proxy = new WcfFoundationService.FoundationServiceClient())
        {
            if (proxy.OfferExistsByName(name))
                throw new ApplicationException("Offer " + name + " is already used");

            var offer = new Offer
                            {
                                ID = -1,
                                Name = name,
                                ValidFrom = validFrom,
                                ValidTo = validTo
                            };
            proxy.SaveOffer(offer);
        }
    }

    public void DeleteOffer(int id)
    {
        using (var proxy = new WcfFoundationService.FoundationServiceClient())
        {
            Offer Offer = proxy.GetOffer(id);
            proxy.DeleteOffer(Offer);
        }
    }

    public void UpdateOffer(int id, string name, DateTime validFrom, DateTime validTo)
    {
        using (var proxy = new WcfFoundationService.FoundationServiceClient())
        {
            var originalOffer = proxy.GetOffer(id);
            var updatedOffer = new Offer
                            {
                                ID = id,
                                Name = name,
                                ValidFrom = validFrom,
                                ValidTo = validTo
                            };
            proxy.UpdateOffer(updatedOffer, originalOffer);
        }
    }

    #region IDisposable Members

    #endregion

    ~OfferUI()
    {
    }
}
