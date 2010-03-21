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
public class StandardVatCodeUI : IDisposable
{
    public StandardVatCodeUI()
    {
    }

    public void SaveStandardVatCode(StandardVatRate code)
    {
        using (WcfFoundationService.FoundationServiceClient proxy = new WcfFoundationService.FoundationServiceClient())
        {
            proxy.SaveStandardVatRate(code);
        }
    }

    public StandardVatRate GetStandardVatCode()
    {
        using (WcfFoundationService.FoundationServiceClient proxy = new WcfFoundationService.FoundationServiceClient())
        {
            return proxy.GetStandardVatRate();
        }
    }

    public bool Exists()
    {
        using (WcfFoundationService.FoundationServiceClient proxy = new WcfFoundationService.FoundationServiceClient())
        {
            return proxy.StandardVatRateExists();
        }
    }

    #region IDisposable Members

    public void Dispose()
    {
    }

    #endregion
}
