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
public class ContactDetailUI : IDisposable
{
    #region Private Member Variables
    private WcfFoundationService.FoundationServiceClient _proxy;
    #endregion

    #region Ctor's

    public ContactDetailUI()
    {
        _proxy = new WcfFoundationService.FoundationServiceClient();
    }

    #endregion


    #region Contact Related Functions

    public ContactDetail GetContactDetail(int id)
    {
        return _proxy.GetContactDetailByID(id);
    }

    public ContactDetail SaveContactDetail(ContactDetail contactDetail)
    {
        return _proxy.SaveContactDetail(contactDetail);
    }

    public Customer GetWithContactDetails(int id)
    {
        Customer customer = _proxy.GetCustomerWithContacts(id);
        return customer;
    }

    public ContactDetail UpdateContactDetails(ContactDetail newContactDetail)
    {
        ContactDetail origContactDetail = _proxy.GetContactDetailByID(newContactDetail.ID);
        for (int i = 0; i < origContactDetail.Phone.Count; i++)
        {
            newContactDetail.Phone[i].PhoneNoType = origContactDetail.Phone[i].PhoneNoType;
            //  newContactDetail.Phone[i].PhoneTypeID = origContactDetail.Phone[i].PhoneTypeID;
            newContactDetail.Phone[i].ContactDetail = null;

            origContactDetail.Phone[i].ContactDetail = null;

            // Stuff back in ID
            Phone origPhone = origContactDetail.Phone.Find(q => q.PhoneTypeID == (int)newContactDetail.Phone[i].PhoneTypeID);
            newContactDetail.Phone[i].ID = origPhone.ID;
        }

        return _proxy.UpdateContactDetail(newContactDetail, origContactDetail);
    }

    public List<ContactDetail> GetContactDetailsByCustomerID(int id)
    {
        if (id != null && id > 0)
            return _proxy.GetContactDetailsByCustomer(id);
        else
            return null;
    }

    #endregion


    #region Destructor Related Functions

    #region IDisposable Members

    public void Dispose()
    {
        _proxy.Close();
    }

    ~ContactDetailUI()
    {
        if (_proxy != null)
            _proxy.Close();
    }

    #endregion

    #endregion
}
