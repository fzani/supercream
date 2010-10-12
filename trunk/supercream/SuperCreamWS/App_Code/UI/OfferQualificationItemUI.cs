using System;
using System.Collections.Generic;

using WcfFoundationService;

/// <summary>
/// Summary description for OrderListUI
/// </summary>
[System.ComponentModel.DataObject]
public class OfferQualificationItemUI
{
    public OfferQualificationItemUI()
    {
    }

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public List<OfferQualificationItem> FindAll()
    {
        using (var proxy = new WcfFoundationService.FoundationServiceClient())
        {
            return proxy.GetAllOfferQualificationItems();
        }
    }

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public List<OfferQualificationItem> FindAllByOfferId(int id)
    {
        using (var proxy = new WcfFoundationService.FoundationServiceClient())
        {
            return proxy.GetOfferQualificationByOfferId(id);
        }
    }

    public void Save(OfferQualificationItem offerQualificationItem)
    {
        using (var proxy = new WcfFoundationService.FoundationServiceClient())
        {
            offerQualificationItem.ID = -1;
            proxy.SaveOfferQualificationItem(offerQualificationItem);
        }
    }

    public void Delete(OfferQualificationItem offerQualificationItem)
    {
        using (var proxy = new WcfFoundationService.FoundationServiceClient())
        {
            OfferQualificationItem OfferQualificationItem = proxy.GetOfferQualificationItem(offerQualificationItem.ID);
            proxy.DeleteOfferQualificationItem(offerQualificationItem);
        }
    }

    public void UpdateOfferQualificationItem(OfferQualificationItem offerQualificationItem)
    {
        using (var proxy = new WcfFoundationService.FoundationServiceClient())
        {
            //var originalOfferQualificationItem = proxy.GetOfferQualificationItem(id);
            //var updatedOfferQualificationItem = new OfferQualificationItem
            //                {
            //                    ID = id,
            //                    Name = name,
            //                    ValidFrom = validFrom,
            //                    ValidTo = validTo
            //                };
            //proxy.UpdateOfferQualificationItem(updatedOfferQualificationItem, originalOfferQualificationItem);
        }
    }

    #region IDisposable Members

    #endregion

    ~OfferQualificationItemUI()
    {
    }
}
