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
public class TermsUI : IDisposable
{
    private WcfFoundationService.FoundationServiceClient _proxy;

    public TermsUI()
    {
        _proxy = new WcfFoundationService.FoundationServiceClient();
    }

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public List<Terms> GetAllTermss()
    {
        return _proxy.GetAllTerms() as List<Terms>;
    }

    public void SaveTerms(Terms Terms)
    {
        _proxy.SaveTerm(Terms);
    }

    public void UpdateTerms(Terms newTerms)
    {
        using (TransactionScope ts = new TransactionScope())
        {
            Terms origTerms = _proxy.GetTerm(newTerms.ID);
            _proxy.UpdateTerm(newTerms, origTerms);
        }
    }

    public Terms GetByID(int id)
    {
        return _proxy.GetTerm(id);
    }

    public void DeleteTerms(int id)
    {
        using (TransactionScope ts = new TransactionScope())
        {
            Terms Terms = _proxy.GetTerm(id);
            _proxy.DeleteTerm(Terms);
        }
    }

    public void DeleteTerms(Terms Terms)
    {
        using (TransactionScope ts = new TransactionScope())
        {
            Terms deletedTerms = _proxy.GetTerm(Terms.ID);
            _proxy.DeleteTerm(deletedTerms);
        }
    }

    #region IDisposable Members

    public void Dispose()
    {
        _proxy.Close();
    }

    #endregion

    ~TermsUI()
    {
        if (_proxy != null)
            _proxy.Close();
    }
}
