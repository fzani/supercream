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
public class AccountUI : IDisposable
{
    private WcfFoundationService.FoundationServiceClient _proxy;

    public AccountUI()
    {
        _proxy = new WcfFoundationService.FoundationServiceClient();
    }

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public List<Account> GetAllAccounts()
    {
        return _proxy.GetAllAccounts() as List<Account>;
    }

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public List<Account> GetAllAccountsByCustomerID(int id)
    {
        return _proxy.GetAccountsByCustomerId(id) as List<Account>;
    }

    public Account GetAccountByAlphaID(string id)
    {
        return _proxy.GetAccountByAlphaID(id);
    }

    public bool AlphaIDExists(string id)
    {
        return (_proxy.AlphaIDExists(id)) ? true : false; 
    }

    public void SaveAccount(Account account)
    {
        if(_proxy.AlphaIDExists(account.AlphaID))
            throw new ApplicationException("Account no " + account.AlphaID + " is already used");    
        _proxy.SaveAccount(account);
       
    }

    public void DeleteAccount(int id)
    {
        using (TransactionScope ts = new TransactionScope())
        {
            Account account = _proxy.GetAccount(id);
            account.Address.Account = null;

            _proxy.DeleteAccount(account);
        }
    }

    public void UpdateAccount(int id, string code, string description, float percentagevalue)
    {
        using (TransactionScope ts = new TransactionScope())
        {
            Account origAccount = _proxy.GetAccount(id);
            Account newAccount = new Account
            {
            };
        }
    }

    public void UpdatePopupAccount(Account newAccount)
    {
        using (TransactionScope ts = new TransactionScope())
        {
            Account origAccount = _proxy.GetAccount(newAccount.ID);
            newAccount.ID = origAccount.ID;
            newAccount.InvoiceAddressID = origAccount.InvoiceAddressID;
            newAccount.Address.ID = origAccount.Address.ID;

            // Note :- have to remove cyclic reference fom orig Object
            origAccount.Address.Account = null;

            _proxy.UpdateAccount(newAccount, origAccount);
        }
    }

    public void UpdateAccount(Account newAccount)
    {
        using (TransactionScope ts = new TransactionScope())
        {
            Account origAccount = _proxy.GetAccount(newAccount.ID);
            _proxy.UpdateAccount(newAccount, origAccount);
        }
    }

    public bool ExemptAccountExist()
    {
        return _proxy.ExemptCodeExists();
    }

    public Account GetByID(int id)
    {
        return _proxy.GetAccount(id);
    }

    #region IDisposable Members

    public void Dispose()
    {
        _proxy.Close();
    }

    #endregion

    ~AccountUI()
    {
        if (_proxy != null)
            _proxy.Close();
    }
}
