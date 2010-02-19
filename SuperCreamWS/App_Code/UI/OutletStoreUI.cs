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

using WcfFoundationService;

/// <summary>
/// Summary description for OrderListUI
/// </summary>
[System.ComponentModel.DataObject]
public class OutletStoreUI : IDisposable
{
    private WcfFoundationService.FoundationServiceClient _proxy;

    public OutletStoreUI()
    {
        _proxy = new WcfFoundationService.FoundationServiceClient();
    }

    public OutletStore GetOutletStore(int id)
    {
        return _proxy.GetOutletStoreByID(id);

    }
    public void SaveOutletStore(OutletStore OutletStore)
    {        
        _proxy.SaveOutletStore(OutletStore);

    }

    public void DeleteOutletStore(int id)
    {
        using (TransactionScope ts = new TransactionScope())
        {
            OutletStore OutletStore = _proxy.GetOutletStoreByID(id);
            OutletStore.Address.OutletStore = null;

            _proxy.DeleteOutletStore(OutletStore);
        }
    }

    public void UpdateOutletStore(int id, string code, string description, float percentagevalue)
    {
        using (TransactionScope ts = new TransactionScope())
        {
            OutletStore origOutletStore = _proxy.GetOutletStoreByID(id);
            OutletStore newOutletStore = new OutletStore
            {
            };
        }
    }
   

    #region IDisposable Members

    public void Dispose()
    {
        _proxy.Close();
    }

    #endregion

    ~OutletStoreUI()
    {
        if (_proxy != null)
            _proxy.Close();
    }
}
