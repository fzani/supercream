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

    public void Save(OfferQualificationItem offerQualificationItem)
    {
        using (var proxy = new WcfFoundationService.FoundationServiceClient())
        {
            //if (proxy.OfferQualificationItemExistsByName(name))
            //    throw new ApplicationException("OfferQualificationItem " + name + " is already used");

            //var OfferQualificationItem = new OfferQualificationItem
            //                {
            //                    ID = -1,
            //                    Name = name,
            //                    ValidFrom = validFrom,
            //                    ValidTo = validTo
            //                };
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
