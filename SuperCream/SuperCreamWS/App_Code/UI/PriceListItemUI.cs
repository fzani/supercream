using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Transactions;

using SP.Util;

using WcfFoundationService;

/// <summary>
/// Summary description for OrderListUI
/// </summary>
[System.ComponentModel.DataObject]
public class PriceListItemUI : IDisposable
{
    private WcfFoundationService.FoundationServiceClient _proxy;

    public PriceListItemUI()
    {
        _proxy = new WcfFoundationService.FoundationServiceClient();
    }

    public PriceListItem Save(PriceListItem priceListItem)
    {
        return _proxy.SavePriceListItem(priceListItem);
    }

    public void UpdatePriceListItem(PriceListItem newPriceListItem)
    {
        PriceListItem origPriceListItem = _proxy.GetPriceListItemById(newPriceListItem.ID);
        newPriceListItem.PriceListID = origPriceListItem.PriceListID;
        newPriceListItem.ProductID = origPriceListItem.ProductID;

        _proxy.UpdatePriceListItem(newPriceListItem, origPriceListItem);
    }

    public PriceListItem GetPriceListItemByProductID(int priceList, int productID)
    {
        return _proxy.GetPriceListItemByProductId(priceList, productID);
    }

    public List<SP.Web.DTO.PriceListItem> GetPriceListItems(int id)
    {
        if (id > -1)
        {
            List<PriceListItem> priceListItem = _proxy.GetPriceListItemByPriceListHeader(id);
            List<SP.Web.DTO.PriceListItem> derivedPriceListItem = new List<SP.Web.DTO.PriceListItem>();
            foreach (PriceListItem itm in priceListItem)
            {
                SP.Web.DTO.PriceListItem p = new SP.Web.DTO.PriceListItem
                {
                    ID = itm.ID,
                    ProductName = itm.Product.Description,
                    OriginalPrice = itm.Product.UnitPrice,
                    Discount = itm.Discount,
                    DiscountApplied = CalculateDiscount(itm.Discount, itm.Product.UnitPrice)
                };
                derivedPriceListItem.Add(p);
            }
            return derivedPriceListItem;
        }
        return null;
    }

    public void Delete(int priceListID, int productID)
    {
        _proxy.DeletePriceListItemByProductId(priceListID, productID);
    }

    public void Delete(int PriceListItem)
    {
        _proxy.DeletePriceListItemByID(PriceListItem);
    }

    Decimal CalculateDiscount(Decimal discount, Decimal unitPrice)
    {
        return Math.Round(unitPrice - ((unitPrice / 100) * discount), 2);
    }

    #region IDisposable Members

    public void Dispose()
    {
        _proxy.Close();
    }

    #endregion

    ~PriceListItemUI()
    {
        if (_proxy != null)
            _proxy.Close();
    }
}
