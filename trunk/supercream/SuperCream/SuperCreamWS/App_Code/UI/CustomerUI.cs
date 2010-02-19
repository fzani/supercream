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
public class CustomerUI : IDisposable
{
    #region Private Member Variables
    private WcfFoundationService.FoundationServiceClient _proxy;
    #endregion

    #region Ctor's

    public CustomerUI()
    {
        _proxy = new WcfFoundationService.FoundationServiceClient();
    }

    #endregion

    #region Account Related Functions
    public List<Account> GetAccountsByCustomerID(int id)
    {
        return _proxy.GetAccountsByCustomerId(id);
    }

    #endregion

    #region Contact Related Functions

    public void DeleteContactDetail(int? customerID, int contactDetailID)
    {
        Customer customer = _proxy.GetCustomerWithContacts(customerID.Value);
        ContactDetail contactDetail = customer.ContactDetail.Find(q => (q.ID == contactDetailID));

        _proxy.DeleteContactDetail(contactDetail);
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

    #region Customer Related Functions

    public Customer GetByID(int id)
    {
        return _proxy.GetCustomerByID(id);
    }

    public bool NameExists(string name)
    {
        return _proxy.CustomerExistsByName(name);
    }

    public void DeleteCustomer(int id)
    {
        _proxy.DeleteCustomer(id);
    }

    public List<Customer> GetAll()
    {
        return _proxy.GetAllCustomers();
    }

    public List<Customer> GetByTelephoneNoLike(string telephoneNo)
    {
        return _proxy.GetByTelehoneNoLike(telephoneNo);
    }

    public List<Customer> GetAllCustomers(string customerName, string telephoneNo, string accountNo)
    {
        if (!String.IsNullOrEmpty(customerName))
            return _proxy.GetCustomerByNameLike(customerName);
        else if (!String.IsNullOrEmpty(accountNo))
            return _proxy.GetCustomersByAccountNameLike(accountNo);
        else if (!String.IsNullOrEmpty(telephoneNo))
            return _proxy.GetByTelehoneNoLike(telephoneNo);
        else
            return _proxy.GetAllCustomers();
    }

    public void Save(Customer code)
    {
        _proxy.SaveCustomerOutlet(code);
    }

    #endregion

    #region OutletStore Related Functions
    public Customer GetWithOutletStores(int id)
    {
        if (id != null && id > 0)
            return _proxy.GetCustomerWithOutletStores(id);
        else
            return null;
    }

    public OutletStore AddOutletStore(OutletStore ouletStore)
    {
        return _proxy.SaveOutletStore(ouletStore);
    }

    public void DeleteOutletStore(int? customerID, int outletStoreID)
    {
        Customer customer = _proxy.GetCustomerWithOutletStores(customerID.Value);
        OutletStore outletStore = customer.OutletStore.Find(q => (q.ID == outletStoreID));
        _proxy.DeleteOutletStore(outletStore);
    }

    public List<OutletStore> GetOutletStoresByCustomerID(int id)
    {
        if (id != null && id > 0)
        {
            Customer customer = _proxy.GetCustomerWithOutletStores(id);
            return customer.OutletStore;
        }
        else
            return null;
    }

    public Customer UpdateCustomer(Customer newCustomer)
    {
        Customer origCustomer = _proxy.GetCustomerWithOutletStores(newCustomer.ID);
        return _proxy.UpdateCustomer(newCustomer, origCustomer);
    }

    public OutletStore UpdateOutletStore(OutletStore newOutletStore)
    {
        Customer customer = _proxy.GetCustomerWithOutletStores(newOutletStore.CustomerID.Value);
        OutletStore origOutletStore = customer.OutletStore.Find(q => (q.ID == newOutletStore.ID));
        newOutletStore.Address.ID = origOutletStore.Address.ID;
        newOutletStore.AddressID = origOutletStore.AddressID;
        return _proxy.UpdateOutletStore(newOutletStore, origOutletStore);
    }

    #endregion

    #region Destructor Related Functions

    #region IDisposable Members

    public void Dispose()
    {
        _proxy.Close();
    }

    ~CustomerUI()
    {
        if (_proxy != null)
            _proxy.Close();
    }

    #endregion

    #endregion
}
