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
public class AutoGenUI : IDisposable
{
    private WcfFoundationService.FoundationServiceClient _proxy;

    public AutoGenUI()
    {
    }

    public int Generate()
    {
        using (_proxy = new WcfFoundationService.FoundationServiceClient())
        {
            return _proxy.GenerateOrderNo();
        }
    }

    #region IDisposable Members

    public void Dispose()
    {
    }

    #endregion

    ~AutoGenUI()
    {
    }
}
