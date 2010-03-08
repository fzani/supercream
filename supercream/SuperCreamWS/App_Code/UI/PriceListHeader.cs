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
public class PriceListHeaderUI : IDisposable
{
    private WcfFoundationService.FoundationServiceClient _proxy;

    public PriceListHeaderUI()
    {
        _proxy = new WcfFoundationService.FoundationServiceClient();
    }

    public List<PriceListHeader> GetAll()
    {
        return _proxy.GetAllPriceListHeaders();
    }

    public List<PriceListHeader> GetAllWithoutNoItems()
    {
        return _proxy.GetAllPriceListHeaders().FindAll(q => q.ID != 1);
    }

    public PriceListHeader GetByID(int id)
    {
        return _proxy.GetPriceListHeaderByID(id);
    }

    public void DeleteID(int id)
    {
        _proxy.DeletePriceListHeader(id);
    }

    public void Update(PriceListHeader newPriceListHeader)
    {
        using (_proxy = new WcfFoundationService.FoundationServiceClient())
        {
            PriceListHeader origpriceListHeader = _proxy.GetPriceListHeaderByID(newPriceListHeader.ID);
            PriceListHeader updatedPriceListHeader = origpriceListHeader.Clone<PriceListHeader>();
          
            updatedPriceListHeader.DateEffectiveFrom = newPriceListHeader.DateEffectiveFrom;
            updatedPriceListHeader.DateEffectiveTo = newPriceListHeader.DateEffectiveTo;
            updatedPriceListHeader.PriceListName = newPriceListHeader.PriceListName;

            _proxy.UpdatePriceListHeader(updatedPriceListHeader, origpriceListHeader);
        }
    }

    public PriceListHeader SavePriceListHeader(PriceListHeader priceListHeader)
    {
        using (_proxy = new WcfFoundationService.FoundationServiceClient())
        {
            return _proxy.SavePriceListHeader(priceListHeader);
        }
    }

    #region IDisposable Members

    public void Dispose()
    {
        _proxy.Close();
    }

    #endregion

    ~PriceListHeaderUI()
    {
        if (_proxy != null)
            _proxy.Close();
    }
}
