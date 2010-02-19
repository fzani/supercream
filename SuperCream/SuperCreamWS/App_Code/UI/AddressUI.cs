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
public class AddressUI : IDisposable
{
    private WcfFoundationService.FoundationServiceClient _proxy;

    public AddressUI()
    {
        _proxy = new WcfFoundationService.FoundationServiceClient();
    }   

    public Address GetByID(int id)
    {
        return _proxy.GetAddress(id);
    }

    #region IDisposable Members

    public void Dispose()
    {
        _proxy.Close();
    }

    #endregion

    ~AddressUI()
    {
        if (_proxy != null)
            _proxy.Close();
    }
}
