using System;
using System.Collections.Generic;

using WcfFoundationService;

/// <summary>
/// Summary description for OrderListUI
/// </summary>
[System.ComponentModel.DataObject]
public class OfferItemUI
{
    public OfferItemUI()
    {
    }

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public List<OfferItem> FindAll()
    {
        using (var proxy = new WcfFoundationService.FoundationServiceClient())
        {
            return proxy.GetAllOfferItems();
        }
    }

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public List<OfferItem> FindAllByOfferId(int id)
    {
        using (var proxy = new WcfFoundationService.FoundationServiceClient())
        {
            return null;
           // return proxy.GetOfferQualificationByOfferId(id);
        }
    }

    public void Save(OfferItem OfferItem)
    {
        using (var proxy = new WcfFoundationService.FoundationServiceClient())
        {
            OfferItem.ID = -1;
            proxy.SaveOfferItem(OfferItem);
        }
    }

    public void Delete(OfferItem OfferItem)
    {
        using (var proxy = new WcfFoundationService.FoundationServiceClient())
        {
            OfferItem deleteQualificationItem = proxy.GetOfferItem(OfferItem.ID);
            proxy.DeleteOfferItem(deleteQualificationItem);
        }
    }

    public void UpdateOfferItem(OfferItem OfferItem)
    {
        using (var proxy = new WcfFoundationService.FoundationServiceClient())
        {
            var originalOfferItem = proxy.GetOfferItem(OfferItem.ID);
            var updatedOfferItem = new OfferItem
                            {
                                ID = OfferItem.ID,
                                ProductId = OfferItem.ProductId,
                                OfferId = OfferItem.OfferId,
                                
                            };
            proxy.UpdateOfferItem(updatedOfferItem, originalOfferItem);
        }
    }

    #region IDisposable Members

    #endregion

    ~OfferItemUI()
    {
    }
}
