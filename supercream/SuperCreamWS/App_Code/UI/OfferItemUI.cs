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
            return proxy.GetOfferItemByOfferId(id);
        }
    }

    public void Save(OfferItem offerItem)
    {
        using (var proxy = new WcfFoundationService.FoundationServiceClient())
        {
            offerItem.ID = -1;
            var product = new ProductUI().GetProductByID(offerItem.ProductId);

            offerItem.UnitPrice = product.UnitPrice;
            offerItem.VatExempt = product.VatExempt;
            var standardVatRate = new StandardVatCodeUI().GetStandardVatCode();
            offerItem.VatCodeId = standardVatRate.VatCodeID;
                
            proxy.SaveOfferItem(offerItem);
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

    public void UpdateOfferItem(OfferItem offerItem)
    {
        using (var proxy = new WcfFoundationService.FoundationServiceClient())
        {
            var originalOfferItem = proxy.GetOfferItem(offerItem.ID);

            var updatedOfferItem = new OfferItem
                            {
                                ID = offerItem.ID,
                                ProductId = originalOfferItem.ProductId,
                                OfferId = originalOfferItem.OfferId,
                                VatCodeId = originalOfferItem.VatCodeId,
                                VatExempt = originalOfferItem.VatExempt,
                                UnitPrice = originalOfferItem.UnitPrice,
                                NoOfUnits = offerItem.NoOfUnits
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
