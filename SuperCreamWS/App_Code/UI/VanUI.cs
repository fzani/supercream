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
public class VanUI : IDisposable
{
    private WcfFoundationService.FoundationServiceClient _proxy;

    public VanUI()
    {
        _proxy = new WcfFoundationService.FoundationServiceClient();
    }

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public List<Van> GetAllVans()
    {
        return _proxy.GetAllVans() as List<Van>;
    }

    public void SaveVan(Van van)
    {
        _proxy.SaveVan(van);
    }

    public void UpdateVan(Van newVan)
    {
        using (TransactionScope ts = new TransactionScope())
        {
            Van origVan = _proxy.GetVan(newVan.ID);
            _proxy.UpdateVan(newVan, origVan);
        }
    }


    public void DeleteVan(int id)
    {
        using (TransactionScope ts = new TransactionScope())
        {
            Van van = _proxy.GetVan(id);
            _proxy.DeleteVan(van);
        }
    }

    public void DeleteVan(Van van)
    {
        using (TransactionScope ts = new TransactionScope())
        {
            Van deletedVan = _proxy.GetVan(van.ID);
            _proxy.DeleteVan(deletedVan);
        }
    }

    #region IDisposable Members

    public void Dispose()
    {
        _proxy.Close();
    }

    #endregion

    ~VanUI()
    {
        if(_proxy != null)
            _proxy.Close();
    }
}
