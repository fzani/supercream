using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.Linq;
using System.Data.Linq.Mapping;

using SP.Core.Domain;
using SP.Core.ManagerInterfaces;
using SP.Core.DataInterfaces;
using SP.Data.LTS;

using System.Transactions;

using System.Configuration;

namespace SP.Worker
{
    public class FoundationFacilitiesManager : IFoundationFacilitiesManager
    {
        #region IAccount Members
        public Account SaveAccount(Account account)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IAccountDao accountCodeDao = factory.GetAccountDao();

            account = accountCodeDao.Save(account);
            accountCodeDao.CommitChanges();

            return account;
        }

        public List<Account> GetAllAccounts()
        {
            IDaoFactory factory = new LTSDaoFactory();
            IAccountDao accountCodeDao = factory.GetAccountDao();

            return accountCodeDao.GetAll().OrderBy(a => a.AlphaID).ToList<Account>();
        }

        public List<Account> GetAccountsByCustomerId(int id)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IAccountDao accountDao = factory.GetAccountDao();

            return accountDao.GetAccountsByCustomerId(id);
        }

        public Account GetAccountByAlphaID(string id)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IAccountDao accountDao = factory.GetAccountDao();

            return accountDao.GetAccountsByAlphaID(id);
        }

        public Account GetAccount(int id)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IAccountDao accountDao = factory.GetAccountDao();

            return accountDao.GetById(id);
        }

        public Account UpdateAccount(Account newAccount, Account origAccount)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IAccountDao accountCodeDao = factory.GetAccountDao();

            Address addr = newAccount.Address;
            IAddressDao addressDao = factory.GetAddressDao();
            origAccount.Address.Account = null;
            addressDao.Update(addr, origAccount.Address);

            newAccount.Address = null;
            origAccount.Address = null;
            Account facility = accountCodeDao.Update(newAccount, origAccount);

            return facility;
        }

        public void DeleteAccount(Account cde)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IAccountDao accountDao = factory.GetAccountDao();

            IAddressDao addressDao = factory.GetAddressDao();
            addressDao.Delete(cde.Address);

            cde.Address = null;
            accountDao.Delete(cde);
        }

        public bool AlphaIDExists(string id)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IAccountDao accountDao = factory.GetAccountDao();

            return accountDao.AlphaIDExists(id);
        }

        #endregion

        #region IAddress Members

        public void DeleteAddress(Address address)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IAddressDao addressDao = factory.GetAddressDao();

            addressDao.Delete(address);
        }

        public Address GetAddress(int id)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IAddressDao addressDao = factory.GetAddressDao();

            return addressDao.GetById(id);
        }

        public Address SaveAddress(Address address)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IAddressDao addressDao = factory.GetAddressDao();

            address = addressDao.Save(address);

            return address;
        }

        public Address UpdateAddress(Address newAddress, Address origAddress)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IAddressDao addressDao = factory.GetAddressDao();

            return addressDao.Update(newAddress, origAddress);
        }

        #endregion

        #region IAutoGen Members
        public int Generate()
        {
            IDaoFactory factory = new LTSDaoFactory();
            IAutogenDao autoGenDao = factory.GetAutoGenDao();

            return autoGenDao.Generate("GEN");
        }
        #endregion

        #region AuditEvents

        public void ArchiveAuditEvents()
        {
            IDaoFactory factory = new LTSDaoFactory();
            IAuditEventsDao auditEventsDao = factory.GetAuditEventsDao();

            auditEventsDao.ArchiveAuditEvents();
        }

        public List<string> AuditEventDescriptions()
        {
            IDaoFactory factory = new LTSDaoFactory();
            IAuditEventsDao auditEventsDao = factory.GetAuditEventsDao();

            return auditEventsDao.Descriptions();
        }

        public void DeleteAuditEvents(AuditEvents auditevents)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IAuditEventsDao auditEventsDao = factory.GetAuditEventsDao();

            auditEventsDao.Delete(auditevents);
        }

        public AuditEvents GetAuditEvents(int id)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IAuditEventsDao auditEventsDao = factory.GetAuditEventsDao();
            return auditEventsDao.GetById(id);
        }

        public List<AuditEvents> GetAllAuditEventss()
        {
            IDaoFactory factory = new LTSDaoFactory();
            IAuditEventsDao auditEventsDao = factory.GetAuditEventsDao();
            return auditEventsDao.GetAll();
        }

        public List<AuditEvents> GetAllAuditEvents(string description, string creator, DateTime createdDate)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IAuditEventsDao auditEventsDao = factory.GetAuditEventsDao();
            List<AuditEvents> auditEvents = auditEventsDao.GetAllAuditEvents(description, creator, createdDate);
            // Automatically Archive of > 1000 records
            if (auditEvents.Count > 1000)
            {
                ArchiveAuditEvents();
            }

            IAuditEventsDao newAuditEventsDao = factory.GetAuditEventsDao();
            return newAuditEventsDao.GetAllAuditEvents(description, creator, createdDate);
        }

        public AuditEvents SaveAuditEvents(AuditEvents auditevents)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IAuditEventsDao auditEventsDao = factory.GetAuditEventsDao();
            return auditEventsDao.Save(auditevents);
        }

        public AuditEvents UpdateAuditEvents(AuditEvents newAuditEvents, AuditEvents origAuditEvents)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IAuditEventsDao auditEventsDao = factory.GetAuditEventsDao();
            return auditEventsDao.Update(newAuditEvents, origAuditEvents);
        }

        #endregion

        #region IContactDetails

        public void DeleteContactDetail(ContactDetail contactDetail)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IContactDetailDao contactDetailDao = factory.GetContactDetailDao();

            contactDetailDao.Delete(contactDetail);
        }

        public ContactDetail GetContactDetailByID(int id)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IContactDetailDao contactDetailDao = factory.GetContactDetailDao();

            return contactDetailDao.GetById(id);
        }

        public List<ContactDetail> GetContactDetailsByCustomer(int id)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IContactDetailDao contactDetailDao = factory.GetContactDetailDao();

            return contactDetailDao.GetByCustomerId(id);
        }

        public ContactDetail SaveContactDetail(ContactDetail contactDetail)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IContactDetailDao contactDetailDao = factory.GetContactDetailDao();

            return contactDetailDao.Save(contactDetail);
        }

        public ContactDetail SaveContactDetail(ContactDetail contactDetail, object context)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IContactDetailDao contactDetailDao = factory.GetContactDetailDao();
            contactDetailDao.SetDataContext(context);

            return contactDetailDao.Save(contactDetail);
        }

        public ContactDetail UpdateContactDetail(ContactDetail newContactDetail, ContactDetail origContactDetail)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IContactDetailDao ContactDetailCodeDao = factory.GetContactDetailDao();

            for (int i = 0; i < newContactDetail.Phone.Count; i++)
            {
                // Cannot attach to same Entity so having to cludge as cannot do update through
                // Contact Detail for some reason ?????
                IPhoneDao phoneDao = factory.GetPhoneDao();
                phoneDao.Update(newContactDetail.Phone[i], origContactDetail.Phone[i]);
            }

            ContactDetail facility = ContactDetailCodeDao.Update(newContactDetail, origContactDetail);

            return facility;
        }
        #endregion

        #region CreditNote

        public bool CreditNoteExistsByOrderId(int orderId)
        {
            IDaoFactory factory = new LTSDaoFactory();
            ICreditNoteDao creditNoteDao = factory.GetCreditNoteDao();
            return creditNoteDao.CreditNoteExistsByOrderId(orderId);
        }

        public InvoiceCreditNoteDetails GetInvoiceCreditDetails(int orderId)
        {
            IDaoFactory factory = new LTSDaoFactory();
            ICreditNoteDao creditNoteDao = factory.GetCreditNoteDao();

            IOrderHeaderDao orderHeaderDao = factory.GetOrderHeaderDao();
            OrderHeader orderHeader = orderHeaderDao.GetById(orderId);

            decimal vatRatePercentage;
            IVatCodeDao vatCodeDao = factory.GetVatCodeDao();
            VatCode vatCode = vatCodeDao.GetById(orderHeader.VatCodeID);
            if (vatCode.VatExemptible == true)
            {
                vatRatePercentage = new decimal(0.0);
            }
            else
            {
                vatRatePercentage = Convert.ToDecimal(vatCode.PercentageValue);
            }

            return creditNoteDao.GetInvoiceCreditDetails(orderId, vatRatePercentage);
        }

        public void DeleteCreditNote(CreditNote creditnote)
        {
            IDaoFactory factory = new LTSDaoFactory();
            ICreditNoteDao creditNoteDao = factory.GetCreditNoteDao();

            creditNoteDao.Delete(creditnote);
        }

        public CreditNote GetCreditNote(int id)
        {
            IDaoFactory factory = new LTSDaoFactory();
            ICreditNoteDao creditNoteDao = factory.GetCreditNoteDao();
            return creditNoteDao.GetById(id);
        }

        public List<CreditNote> GetAllCreditNotes()
        {
            IDaoFactory factory = new LTSDaoFactory();
            ICreditNoteDao creditNoteDao = factory.GetCreditNoteDao();
            return creditNoteDao.GetAll();
        }

        public CreditNote SaveCreditNote(CreditNote creditnote)
        {
            IDaoFactory factory = new LTSDaoFactory();
            ICreditNoteDao creditNoteDao = factory.GetCreditNoteDao();

            ICreditNoteDao validateNoteDao = factory.GetCreditNoteDao();
            if (validateNoteDao.ReferenceExists(creditnote.Reference))
                throw new ApplicationException("Cannot add credit note Credit Reference is alreasy in use");
            creditnote.Reference = creditNoteDao.GenerateCreditNo();

            return creditNoteDao.Save(creditnote);
        }

        public CreditNote UpdateCreditNote(CreditNote newCreditNote, CreditNote origCreditNote)
        {
            IDaoFactory factory = new LTSDaoFactory();
            ICreditNoteDao creditNoteDao = factory.GetCreditNoteDao();
            ICreditNoteDao validateNoteDao = factory.GetCreditNoteDao();
            CreditNote originalCreditNote = validateNoteDao.GetByReferenceId(newCreditNote.Reference);
            if (originalCreditNote.ID != newCreditNote.ID)
                throw new ApplicationException("Cannot change Credit Reference is alreasy in use");
            return creditNoteDao.Update(newCreditNote, origCreditNote);
        }

        public List<CreditNoteDetails> SearchCreditNotes(string orderNo, string invoiceNo, string customerName, DateTime dateFrom, DateTime dateTo)
        {
            IDaoFactory factory = new LTSDaoFactory();
            ICreditNoteDao creditNoteDao = factory.GetCreditNoteDao();
            return creditNoteDao.SearchCreditNotes(orderNo, invoiceNo, customerName, dateFrom, dateTo);
        }

        public decimal GetOustandingCreditNoteBalance(int orderNo, int creditNote, decimal vatRate)
        {
            IDaoFactory factory = new LTSDaoFactory();
            ICreditNoteDao creditNoteDao = factory.GetCreditNoteDao();
            return creditNoteDao.GetOustandingCreditNoteBalance(orderNo, creditNote, vatRate);
        }

        public List<CreditNote> GetCreditNotesByOrderId(int creditNoteId)
        {
            IDaoFactory factory = new LTSDaoFactory();
            ICreditNoteDao creditNoteDao = factory.GetCreditNoteDao();
            return creditNoteDao.GetCreditNotesByOrderId(creditNoteId);
        }

        #endregion

        #region ICustomer Related Functions
        /***************************************************************************************************************
         * Customer Related Functions
         ***************************************************************************************************************/

        public void DeleteCustomer(int customerID)
        {
            LTSDataContext context = new LTSDataContext();
            DataLoadOptions dlo = new DataLoadOptions();
            dlo.LoadWith<Customer>(q => q.ContactDetail);
            dlo.LoadWith<Customer>(q => q.OutletStore);
            dlo.LoadWith<ContactDetail>(c => c.Phone);
            dlo.LoadWith<OutletStore>(c => c.Address);
            dlo.LoadWith<Phone>(p => p.PhoneNoType);
            context.LoadOptions = dlo;


            IDaoFactory factory = new LTSDaoFactory();
            ICustomerDao ffCustomerDao = factory.GetCustomerDao();
            ffCustomerDao.SetDataContext(context);

            ICustomerDao deletedffCustomerDao = factory.GetCustomerDao();

            Customer customer = ffCustomerDao.GetById(customerID);
            if (customer.ContactDetail != null)
            {
                foreach (ContactDetail contactDetail in customer.ContactDetail)
                {
                    if (contactDetail.Phone != null)
                    {
                        foreach (Phone p in contactDetail.Phone)
                        {
                            IPhoneDao phoneDao = factory.GetPhoneDao();
                            phoneDao.Delete(p);
                        }
                    }
                    IContactDetailDao ffContactDetailDao = factory.GetContactDetailDao();
                    ffContactDetailDao.Delete(contactDetail);
                }
            }

            if (customer.OutletStore != null)
            {
                foreach (OutletStore outletStore in customer.OutletStore)
                {
                    IAddressDao addressDao = factory.GetAddressDao();
                    Address address = addressDao.GetById(outletStore.AddressID);

                    IAddressDao deletedAddressDao = factory.GetAddressDao();
                    deletedAddressDao.Delete(address);

                    IOutletStoreDao ffOutletStoreDao = factory.GetOutletStoreDao();
                    ffOutletStoreDao.Delete(outletStore);
                }
            }

            deletedffCustomerDao.Delete(customer);
        }

        public List<Account> GetAccountsByCustomerID(int id)
        {
            IDaoFactory factory = new LTSDaoFactory();
            ICustomerDao customerDao = factory.GetCustomerDao();

            return customerDao.GetAccountsByID(id);
        }

        public List<Customer> GetAllCustomers()
        {
            IDaoFactory factory = new LTSDaoFactory();
            ICustomerDao ffDao = factory.GetCustomerDao();

            return ffDao.GetAll().OrderBy(s => s.Name).ToList<Customer>();
        }

        public Customer GetCustomerByName(string name)
        {
            IDaoFactory factory = new LTSDaoFactory();
            ICustomerDao ffDao = factory.GetCustomerDao();

            return ffDao.GetByName(name);
        }

        public List<Customer> GetByTelehoneNoLike(string telephoneNo)
        {
            IDaoFactory factory = new LTSDaoFactory();
            ICustomerDao ffDao = factory.GetCustomerDao();

            return ffDao.GetByTelehoneNoLike(telephoneNo).OrderBy(s => s.Name).ToList<Customer>();
        }


        public Customer GetCustomerByID(int id)
        {
            IDaoFactory factory = new LTSDaoFactory();
            ICustomerDao ffDao = factory.GetCustomerDao();

            return ffDao.GetById(id);
        }

        public List<Customer> GetCustomerByNameLike(string name)
        {
            IDaoFactory factory = new LTSDaoFactory();
            ICustomerDao ffDao = factory.GetCustomerDao();

            return ffDao.GetByNameLike(name);
        }

        public bool CustomerExistsByName(string name)
        {
            IDaoFactory factory = new LTSDaoFactory();
            ICustomerDao ffDao = factory.GetCustomerDao();

            return ffDao.ExistsByName(name);
        }

        public List<Customer> GetCustomersByAccountNameLike(string name)
        {
            IDaoFactory factory = new LTSDaoFactory();
            ICustomerDao ffDao = factory.GetCustomerDao();

            return ffDao.GetByAccountNameLike(name);
        }

        public bool CustomerExistsWithNameLike(string name)
        {
            IDaoFactory factory = new LTSDaoFactory();
            ICustomerDao ffDao = factory.GetCustomerDao();

            return ffDao.ExistsWithNameLike(name);
        }

        public Customer GetCustomerWithContacts(int id)
        {
            IDaoFactory factory = new LTSDaoFactory();
            ICustomerDao ffDao = factory.GetCustomerDao();

            return ffDao.GetWithContacts(id);
        }

        public Customer GetCustomerWithOutletStores(int id)
        {
            IDaoFactory factory = new LTSDaoFactory();
            ICustomerDao ffDao = factory.GetCustomerDao();

            return ffDao.GetWithOutletStores(id);
        }

        public bool ExemptCodeExists()
        {
            IDaoFactory factory = new LTSDaoFactory();
            IVatCodeDao ffDao = factory.GetVatCodeDao();
            return ffDao.ExemptCodeExists();
        }


        public Customer SaveCustomer(Customer customer)
        {
            IDaoFactory factory = new LTSDaoFactory();
            ICustomerDao ffDao = factory.GetCustomerDao();
            return ffDao.Save(customer);
        }

        public Customer UpdateCustomer(Customer newCustomer, Customer origCustomer)
        {
            IDaoFactory factory = new LTSDaoFactory();
            ICustomerDao customerDao = factory.GetCustomerDao();

            return customerDao.Update(newCustomer, origCustomer);
        }

        #endregion

        #region IFoundation Facility Related Functions

        public FoundationFacility SaveFoundationFacility(FoundationFacility ff)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IFoundationFacilityDao ffDao = factory.GetFoundationFacilityDao();

            ffDao.Save(ff);
            ffDao.CommitChanges();

            return ff;
        }

        public bool FoundationFacilityExists()
        {
            IDaoFactory factory = new LTSDaoFactory();
            IFoundationFacilityDao ffDao = factory.GetFoundationFacilityDao();
            return ffDao.Exists();
        }

        public FoundationFacility GetFoundationFacility()
        {
            IDaoFactory factory = new LTSDaoFactory();
            IFoundationFacilityDao ffDao = factory.GetFoundationFacilityDao();
            FoundationFacility facility = ffDao.Get();
            return facility;
        }

        public FoundationFacility UpdateFoundationFacility(FoundationFacility newFoundationfacility, FoundationFacility origFoundationFacility)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IFoundationFacilityDao ffDao = factory.GetFoundationFacilityDao();
            FoundationFacility facility = ffDao.Update(newFoundationfacility, origFoundationFacility);

            Address addr = newFoundationfacility.Address;

            IAddressDao addressDao = factory.GetAddressDao();
            addressDao.Update(addr, origFoundationFacility.Address);

            return facility;
        }

        #endregion

        #region Offer

        public bool OfferExistsByName(string name)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IOfferDao offerDao = factory.GetOfferDao();
            return offerDao.ExistsByName(name);
        }

        public void DeleteOffer(Offer offer)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IOfferDao offerDao = factory.GetOfferDao();

            offerDao.Delete(offer);
        }

        public Offer GetOffer(int id)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IOfferDao offerDao = factory.GetOfferDao();
            return offerDao.GetById(id);
        }

        public List<Offer> GetAllOffers()
        {
            IDaoFactory factory = new LTSDaoFactory();
            IOfferDao offerDao = factory.GetOfferDao();
            return offerDao.GetAll();
        }

        public Offer SaveOffer(Offer offer)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IOfferDao offerDao = factory.GetOfferDao();
            return offerDao.Save(offer);
        }

        public Offer UpdateOffer(Offer newOffer, Offer origOffer)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IOfferDao offerDao = factory.GetOfferDao();
            return offerDao.Update(newOffer, origOffer);
        }

        #endregion

        #region OfferItem

        public List<OfferItem> GetOfferItemsByOfferId(int offerId)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IOfferItemDao offerItemDao = factory.GetOfferItemDao();

            return offerItemDao.GetByOfferId(offerId);
        }

        public void DeleteOfferItem(OfferItem offeritem)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IOfferItemDao offerItemDao = factory.GetOfferItemDao();

            offerItemDao.Delete(offeritem);
        }

        public OfferItem GetOfferItem(int id)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IOfferItemDao offerItemDao = factory.GetOfferItemDao();
            return offerItemDao.GetById(id);
        }

        public List<OfferItem> GetAllOfferItems()
        {
            IDaoFactory factory = new LTSDaoFactory();
            IOfferItemDao offerItemDao = factory.GetOfferItemDao();
            return offerItemDao.GetAll();
        }

        public OfferItem SaveOfferItem(OfferItem offeritem)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IOfferItemDao offerItemDao = factory.GetOfferItemDao();
            if (offerItemDao.Exists(offeritem.OfferId, offeritem.ProductId))
                throw new ApplicationException("Product already exists for offer");

            return offerItemDao.Save(offeritem);
        }

        public OfferItem UpdateOfferItem(OfferItem newOfferItem, OfferItem origOfferItem)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IOfferItemDao offerItemDao = factory.GetOfferItemDao();
            return offerItemDao.Update(newOfferItem, origOfferItem);
        }

        #endregion

        #region OfferQualificationItem

        public List<OfferQualificationItem> GetOfferQualificationByOfferId(int id)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IOfferQualificationItemDao offerQualificationItemDao = factory.GetOfferQualificationItemDao();
            return offerQualificationItemDao.GetByOfferId(id);
        }

        public void DeleteOfferQualificationItem(OfferQualificationItem offerqualificationitem)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IOfferQualificationItemDao offerQualificationItemDao = factory.GetOfferQualificationItemDao();

            offerQualificationItemDao.Delete(offerqualificationitem);
        }

        public OfferQualificationItem GetOfferQualificationItem(int id)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IOfferQualificationItemDao offerQualificationItemDao = factory.GetOfferQualificationItemDao();
            return offerQualificationItemDao.GetById(id);
        }

        public List<OfferQualificationItem> GetAllOfferQualificationItems()
        {
            IDaoFactory factory = new LTSDaoFactory();
            IOfferQualificationItemDao offerQualificationItemDao = factory.GetOfferQualificationItemDao();
            return offerQualificationItemDao.GetAll();
        }

        public OfferQualificationItem SaveOfferQualificationItem(OfferQualificationItem offerqualificationitem)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IOfferQualificationItemDao offerQualificationItemDao = factory.GetOfferQualificationItemDao();
            if (offerQualificationItemDao.Exists(offerqualificationitem.OfferId, offerqualificationitem.ProductId))
                throw new ApplicationException("Product has already been added to this offer");

            return offerQualificationItemDao.Save(offerqualificationitem);
        }

        public OfferQualificationItem UpdateOfferQualificationItem(OfferQualificationItem newOfferQualificationItem, OfferQualificationItem origOfferQualificationItem)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IOfferQualificationItemDao offerQualificationItemDao = factory.GetOfferQualificationItemDao();
            return offerQualificationItemDao.Update(newOfferQualificationItem, origOfferQualificationItem);
        }

        #endregion

        #region OrderCreditNote

        public bool OrderCreditNoteExistsByOrderId(int orderId)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IOrderCreditNoteDao orderCreditNoteDao = factory.GetOrderCreditNoteDao();
            return orderCreditNoteDao.OrderCreditNoteExistsByOrderId(orderId);
        }

        public List<OrderCreditNote> GetOrderCreditNotesByOrderId(int orderId)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IOrderCreditNoteDao orderCreditNoteDao = factory.GetOrderCreditNoteDao();
            return orderCreditNoteDao.GetOrderCreditNotesByOrderId(orderId);
        }

        public InvoiceCreditNoteDetails GetOrderHeaderInvoiceCreditDetails(int orderNo)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IOrderCreditNoteDao creditNoteDao = factory.GetOrderCreditNoteDao();

            IOrderHeaderDao orderHeaderDao = factory.GetOrderHeaderDao();
            OrderHeader orderHeader = orderHeaderDao.GetById(orderNo);

            decimal vatRatePercentage;
            IVatCodeDao vatCodeDao = factory.GetVatCodeDao();
            VatCode vatCode = vatCodeDao.GetById(orderHeader.VatCodeID);
            if (vatCode.VatExemptible == false)
            {
                vatRatePercentage = Convert.ToDecimal(vatCode.PercentageValue);
            }
            else
            {
                vatRatePercentage = new decimal(0.0);
            }

            return creditNoteDao.GetInvoiceCreditDetails(orderNo, vatRatePercentage);
        }

        public List<CreditNoteDetails> SearchOrderCreditNotes(string orderNo, string invoiceNo, string customerName, DateTime dateFrom, DateTime dateTo)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IOrderCreditNoteDao creditNoteDao = factory.GetOrderCreditNoteDao();
            return creditNoteDao.SearchCreditNotes(orderNo, invoiceNo, customerName, dateFrom, dateTo);
        }

        public List<OrderLine> AvailableOrderLinesForCreditNote(int orderId)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IOrderCreditNoteDao creditNoteDao = factory.GetOrderCreditNoteDao();
            return creditNoteDao.AvailableOrderLinesForCreditNote(orderId);
        }

        public void DeleteOrderCreditNote(OrderCreditNote ordercreditnote)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IOrderCreditNoteDao orderCreditNoteDao = factory.GetOrderCreditNoteDao();

            IOrderCreditNoteLineDao orderCreditNoteLineDao = factory.GetOrderCreditNoteLineDao();
            List<OrderCreditNoteLine> orderCreditNoteLines =
                orderCreditNoteLineDao.GetOrderCreditNoteLinesByCreditNoteId(ordercreditnote.ID);
            foreach (var orderCreditNoteLine in orderCreditNoteLines)
            {
                IOrderCreditNoteLineDao ocl = factory.GetOrderCreditNoteLineDao();
                ocl.Delete(orderCreditNoteLine);
            }

            orderCreditNoteDao.Delete(ordercreditnote);
        }

        public OrderCreditNote GetOrderCreditNote(int id)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IOrderCreditNoteDao orderCreditNoteDao = factory.GetOrderCreditNoteDao();
            return orderCreditNoteDao.GetById(id);
        }

        public List<OrderCreditNote> GetAllOrderCreditNotes()
        {
            IDaoFactory factory = new LTSDaoFactory();
            IOrderCreditNoteDao orderCreditNoteDao = factory.GetOrderCreditNoteDao();
            return orderCreditNoteDao.GetAll();
        }

        public OrderCreditNote SaveOrderCreditNote(OrderCreditNote orderCreditNote)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IOrderCreditNoteDao orderCreditNoteDao = factory.GetOrderCreditNoteDao();
            IOrderCreditNoteDao validateNoteDao = factory.GetOrderCreditNoteDao();
            if (validateNoteDao.ReferenceExists(orderCreditNote.Reference))
                throw new ApplicationException("Cannot add credit note Credit Reference is alreasy in use");
            orderCreditNote.Reference = orderCreditNoteDao.GenerateCreditNo();

            return orderCreditNoteDao.Save(orderCreditNote);
        }

        public OrderCreditNote UpdateOrderCreditNote(OrderCreditNote newOrderCreditNote, OrderCreditNote origOrderCreditNote)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IOrderCreditNoteDao orderCreditNoteDao = factory.GetOrderCreditNoteDao();
            return orderCreditNoteDao.Update(newOrderCreditNote, origOrderCreditNote);
        }

        #endregion

        #region OrderCreditNoteLine

        public List<OrderCreditNoteLine> GetOrderCreditNoteLinesByCreditNoteId(int creditNoteId)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IOrderCreditNoteLineDao orderCreditNoteLineDao = factory.GetOrderCreditNoteLineDao();

            return orderCreditNoteLineDao.GetOrderCreditNoteLinesByCreditNoteId(creditNoteId);
        }

        public int GetAvailableNoOfUnitsOnOrderLine(int orderLineId)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IOrderCreditNoteLineDao orderCreditNoteLineDao = factory.GetOrderCreditNoteLineDao();

            return orderCreditNoteLineDao.GetAvailableNoOfUnitsOnOrderLine(orderLineId);
        }

        public bool CheckIfOrderLineAlreadyExistsForCreditNotes(int orderLineId)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IOrderCreditNoteLineDao orderCreditNoteLineDao = factory.GetOrderCreditNoteLineDao();

            return orderCreditNoteLineDao.CheckIfOrderLineAlreadyExists(orderLineId);
        }

        public OrderCreditNoteLine GetCreditNoteLineByOrderIdAndOrderLineId(int creditNoteid, int orderLineId)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IOrderCreditNoteLineDao orderCreditNoteLineDao = factory.GetOrderCreditNoteLineDao();

            return orderCreditNoteLineDao.GetCreditNoteLineByOrderIdAndOrderLineId(creditNoteid, orderLineId);
        }

        public bool CheckIfCreditNoteLineExists(int creditNoteid, int orderLineId)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IOrderCreditNoteLineDao orderCreditNoteLineDao = factory.GetOrderCreditNoteLineDao();

            return orderCreditNoteLineDao.CheckIfCreditNoteLineExists(creditNoteid, orderLineId);
        }

        public void DeleteOrderCreditNoteLine(OrderCreditNoteLine ordercreditnoteline)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IOrderCreditNoteLineDao orderCreditNoteLineDao = factory.GetOrderCreditNoteLineDao();

            orderCreditNoteLineDao.Delete(ordercreditnoteline);
        }

        public OrderCreditNoteLine GetOrderCreditNoteLine(int id)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IOrderCreditNoteLineDao orderCreditNoteLineDao = factory.GetOrderCreditNoteLineDao();
            return orderCreditNoteLineDao.GetById(id);
        }

        public List<OrderCreditNoteLine> GetAllOrderCreditNoteLines()
        {
            IDaoFactory factory = new LTSDaoFactory();
            IOrderCreditNoteLineDao orderCreditNoteLineDao = factory.GetOrderCreditNoteLineDao();
            return orderCreditNoteLineDao.GetAll();
        }

        public OrderCreditNoteLine SaveOrderCreditNoteLine(OrderCreditNoteLine ordercreditnoteline)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IOrderCreditNoteLineDao orderCreditNoteLineDao = factory.GetOrderCreditNoteLineDao();
            return orderCreditNoteLineDao.Save(ordercreditnoteline);
        }

        public OrderCreditNoteLine UpdateOrderCreditNoteLine(OrderCreditNoteLine newOrderCreditNoteLine, OrderCreditNoteLine origOrderCreditNoteLine)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IOrderCreditNoteLineDao orderCreditNoteLineDao = factory.GetOrderCreditNoteLineDao();
            return orderCreditNoteLineDao.Update(newOrderCreditNoteLine, origOrderCreditNoteLine);
        }

        public decimal GetOrderCreditNoteLineAvailableTotal(int orderCreditNoteId)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IOrderCreditNoteDao orderCreditNoteLineDao = factory.GetOrderCreditNoteDao();
            return orderCreditNoteLineDao.GetOrderCreditNoteLineAvailableTotal(orderCreditNoteId);
        }

        #endregion

        #region OrderHeader

        public List<InvoiceWithStatus> GetInvoicesWithStatus(string orderNo, string invoiceNo, string customerName, DateTime dateFrom, DateTime dateTo, short orderStatus)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IOrderHeaderDao dao = new OrderHeaderDao();
            return dao.GetInvoicesWithStatus(orderNo, invoiceNo, customerName, dateFrom, dateTo, orderStatus);
        }

        public void DeleteOrderHeader(OrderHeader orderHeader)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IOrderHeaderDao orderHeaderDao = factory.GetOrderHeaderDao();

            orderHeaderDao.Delete(orderHeader);
        }

        public bool InvoiceNoExists(string invoiceNo)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IOrderHeaderDao orderHeaderDao = factory.GetOrderHeaderDao();

            return orderHeaderDao.InvoiceNoExists(invoiceNo);
        }

        public bool OrderHeaderExists(string orderNo)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IOrderHeaderDao orderHeaderDao = factory.GetOrderHeaderDao();

            return orderHeaderDao.Exists(orderNo);
        }

        public OrderHeader GetOrderHeader(int id)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IOrderHeaderDao orderHeaderDao = factory.GetOrderHeaderDao();

            return orderHeaderDao.GetById(id);
        }

        public OrderHeader GetOrderHeaderWithVatCode(int id)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IOrderHeaderDao orderHeaderDao = factory.GetOrderHeaderDao();

            return orderHeaderDao.GetOrderHeaderWithVatCode(id);
        }

        public List<OrderHeader> GetAllOrderHeaders()
        {
            IDaoFactory factory = new LTSDaoFactory();
            IOrderHeaderDao orderHeaderDao = factory.GetOrderHeaderDao();

            return orderHeaderDao.GetAll().OrderByDescending(q => q.OrderDate).ThenBy(q => q.AlphaID).ToList<OrderHeader>();
        }

        public List<OrderHeader> SearchInvoices(string orderNo, string invoiceNo, string customerName, DateTime dateFrom, DateTime dateTo, short actualOrderStatus, short printedOrderStatus)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IOrderHeaderDao dao = new OrderHeaderDao();
            return dao.SearchInvoices(orderNo, invoiceNo, customerName, dateFrom, dateTo, actualOrderStatus, printedOrderStatus);
        }

        public OrderHeader GetOrderHeaderByOrderNo(string orderNo)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IOrderHeaderDao orderHeaderDao = factory.GetOrderHeaderDao();

            return orderHeaderDao.GetOrderHeader(orderNo);
        }

        public List<OrderHeader> GetOrderHeaderForSearch(string orderNo, string invoiceNo, string customerName, DateTime dateFrom, DateTime dateTo, short orderStatus)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IOrderHeaderDao orderHeaderDao = factory.GetOrderHeaderDao();

            return orderHeaderDao.GetOrderHeaderForSearch(orderNo, invoiceNo, customerName, dateFrom, dateTo, orderStatus);
        }

        public List<OrderHeader> GetOrderHeaderForSearchWithPrintedOrderStatuses(string orderNo, string invoiceNo, string customerName, DateTime dateFrom, DateTime dateTo, short actualOrderStatus, short printedOrderStatus)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IOrderHeaderDao orderHeaderDao = factory.GetOrderHeaderDao();

            return orderHeaderDao.GetOrderHeaderForSearchWithPrintedOrderStatuses(orderNo, invoiceNo, customerName, dateFrom, dateTo, actualOrderStatus, printedOrderStatus);
        }

        public OrderHeader SaveOrderHeader(OrderHeader orderHeader)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IOrderHeaderDao orderHeaderDao = factory.GetOrderHeaderDao();

            orderHeader.AlphaID = this.GenerateOrderNo();

            IVatCodeDao vatCodeDao = factory.GetVatCodeDao();
            vatCodeDao.SetDataContext(orderHeaderDao.GetDataContext());
            VatCode vatCode = vatCodeDao.GetById(orderHeader.VatCodeID);
            orderHeader.VatCode = vatCode;
            orderHeader.VatCodeID = vatCode.ID;

            orderHeader.LastModifiedDate = DateTime.Now;

            return orderHeaderDao.Save(orderHeader);
        }

        public OrderHeader CreateInvoice(OrderHeader newOrderHeader, OrderHeader origOrderHeader)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IOrderHeaderDao orderHeaderDao = factory.GetOrderHeaderDao();

            if (String.IsNullOrEmpty(origOrderHeader.InvoiceNo))
                newOrderHeader.InvoiceNo = this.GenerateInvoiceNo();

            IVatCodeDao vatCodeDao = factory.GetVatCodeDao();
            vatCodeDao.SetDataContext(orderHeaderDao.GetDataContext());
            VatCode vatCode = vatCodeDao.GetById(newOrderHeader.VatCodeID);

            newOrderHeader.VatCode = vatCode;
            origOrderHeader.VatCode = vatCode;

            newOrderHeader.LastModifiedDate = DateTime.Now;

            return orderHeaderDao.Update(newOrderHeader, origOrderHeader);
        }

        public OrderHeader CreateInvoiceProforma(OrderHeader newOrderHeader, OrderHeader origOrderHeader)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IOrderHeaderDao orderHeaderDao = factory.GetOrderHeaderDao();

            IVatCodeDao vatCodeDao = factory.GetVatCodeDao();
            vatCodeDao.SetDataContext(orderHeaderDao.GetDataContext());
            VatCode vatCode = vatCodeDao.GetById(newOrderHeader.VatCodeID);
            newOrderHeader.VatCode = vatCode;
            origOrderHeader.VatCode = vatCode;

            if (String.IsNullOrEmpty(origOrderHeader.InvoiceProformaNo))
                newOrderHeader.InvoiceProformaNo = this.GenerateInvoiceProformaNo();

            newOrderHeader.LastModifiedDate = DateTime.Now;

            return orderHeaderDao.Update(newOrderHeader, origOrderHeader);
        }

        public void VoidOrder(int orderID, string reasonForVoiding)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IOrderHeaderDao origOrderHeaderDao = factory.GetOrderHeaderDao();
            IOrderHeaderDao newOrderHeaderDao = factory.GetOrderHeaderDao();
            IOrderHeaderDao updateOrderHeaderDao = factory.GetOrderHeaderDao();

            OrderHeader originalOrder = origOrderHeaderDao.GetById(orderID);
            OrderHeader newOrderHeader = newOrderHeaderDao.GetById(orderID);

            IOrderHeaderDao orderHeaderDao = factory.GetOrderHeaderDao();

            IVatCodeDao vatCodeDao = factory.GetVatCodeDao();
            vatCodeDao.SetDataContext(orderHeaderDao.GetDataContext());
            VatCode vatCode = vatCodeDao.GetById(newOrderHeader.VatCodeID);

            newOrderHeader.VatCode = vatCode;
            originalOrder.VatCode = vatCode;

            newOrderHeader.OrderStatus = (short)SP.Core.Enums.OrderStatus.Void;
            newOrderHeader.ReasonForVoiding = reasonForVoiding;

            newOrderHeader.LastModifiedDate = DateTime.Now;

            updateOrderHeaderDao.Update(newOrderHeader, originalOrder);
        }

        public OrderHeader CreateDeliveryNote(OrderHeader newOrderHeader, OrderHeader origOrderHeader)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IOrderHeaderDao orderHeaderDao = factory.GetOrderHeaderDao();

            IVatCodeDao vatCodeDao = factory.GetVatCodeDao();
            vatCodeDao.SetDataContext(orderHeaderDao.GetDataContext());
            VatCode vatCode = vatCodeDao.GetById(newOrderHeader.VatCodeID);
            newOrderHeader.VatCode = vatCode;
            origOrderHeader.VatCode = vatCode;

            if (String.IsNullOrEmpty(origOrderHeader.DeliveryNoteNo))
                newOrderHeader.DeliveryNoteNo = this.GenerateDeliveryNoteNo();

            newOrderHeader.LastModifiedDate = DateTime.Now;

            return orderHeaderDao.Update(newOrderHeader, origOrderHeader);
        }

        public OrderHeader UpdateOrderHeader(OrderHeader newOrderHeader, OrderHeader origOrderHeader)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IOrderHeaderDao orderHeaderDao = factory.GetOrderHeaderDao();

            IVatCodeDao vatCodeDao = factory.GetVatCodeDao();
            vatCodeDao.SetDataContext(orderHeaderDao.GetDataContext());
            VatCode vatCode = vatCodeDao.GetById(newOrderHeader.VatCodeID);

            newOrderHeader.VatCode = vatCode;
            origOrderHeader.VatCode = vatCode;

            newOrderHeader.LastModifiedDate = DateTime.Now;

            return orderHeaderDao.Update(newOrderHeader, origOrderHeader);
        }

        public void UpdatePaymentCompleted(int orderID, bool invoicePaymentComplete)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IOrderNotesStatusDao orderNoteStatusDao = factory.GetOrderNotesStatusDao();

            orderNoteStatusDao.UpdatePaymentCompleted(orderID, invoicePaymentComplete);
        }
        #endregion

        #region OrderLine

        public void DeleteOrderLine(OrderLine orderLine)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IOrderLineDao orderLineDao = factory.GetOrderLineDao();

            orderLineDao.Delete(orderLine);
        }

        public OrderLine GetOrderLine(int id)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IOrderLineDao orderLineDao = factory.GetOrderLineDao();

            return orderLineDao.GetById(id);
        }

        public List<OrderLine> GetOrderLinesByOrderID(int id)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IOrderLineDao orderLineDao = factory.GetOrderLineDao();

            return orderLineDao.GetOrderLinesByOrderID(id);
        }

        public OrderLine SaveOrderLine(OrderLine orderLine)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IOrderHeaderDao orderHeaderDao = factory.GetOrderHeaderDao();
            IOrderLineDao orderLineDao = factory.GetOrderLineDao();
            IVatCodeDao vatCodeDao = factory.GetVatCodeDao();

            orderLineDao.SetDataContext(orderHeaderDao.GetDataContext());
            OrderHeader orderHeader = orderHeaderDao.GetById(orderLine.OrderID);
            vatCodeDao.SetDataContext(orderHeaderDao.GetDataContext());
            VatCode vatCode = vatCodeDao.GetById(orderHeader.VatCodeID);
            orderHeader.VatCode = vatCode;

            orderLine.OrderHeader = orderHeader;


            return orderLineDao.Save(orderLine);
        }

        public OrderLine UpdateOrderLine(OrderLine newOrderLine, OrderLine origOrderLine)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IOrderHeaderDao orderHeaderDao = factory.GetOrderHeaderDao();
            IOrderLineDao orderLineDao = factory.GetOrderLineDao();
            IVatCodeDao vatCodeDao = factory.GetVatCodeDao();
            orderLineDao.SetDataContext(orderHeaderDao.GetDataContext());
            origOrderLine.OrderHeader = orderHeaderDao.GetById(origOrderLine.OrderID);

            OrderHeader orderHeader = orderHeaderDao.GetById(origOrderLine.OrderID);
            vatCodeDao.SetDataContext(orderHeaderDao.GetDataContext());
            VatCode vatCode = vatCodeDao.GetById(orderHeader.VatCodeID);
            orderHeader.VatCode = vatCode;

            newOrderLine.OrderHeader = origOrderLine.OrderHeader;

            return orderLineDao.Update(newOrderLine, origOrderLine);
        }

        #endregion

        #region OrderNotesStatus
        public void DeleteOrderNotesStatus(OrderNotesStatus ordernotesstatus)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IOrderNotesStatusDao orderNotesStatusDao = factory.GetOrderNotesStatusDao();

            orderNotesStatusDao.Delete(ordernotesstatus);
        }

        public OrderNotesStatus GetOrderNotesStatus(int id)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IOrderNotesStatusDao orderNotesStatusDao = factory.GetOrderNotesStatusDao();
            return orderNotesStatusDao.GetById(id);
        }

        public OrderNotesStatus GetOrderNoteStatusByOrderId(int id)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IOrderNotesStatusDao orderNotesStatusDao = factory.GetOrderNotesStatusDao();
            return orderNotesStatusDao.GetByOrderId(id);
        }

        public bool OrderNoteStatusByOrderIDExists(int orderID)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IOrderNotesStatusDao orderNotesStatusDao = factory.GetOrderNotesStatusDao();
            return orderNotesStatusDao.OrderStatusByOrderIDExists(orderID);
        }

        public List<OrderNotesStatus> GetAllOrderNotesStatuss()
        {
            IDaoFactory factory = new LTSDaoFactory();
            IOrderNotesStatusDao orderNotesStatusDao = factory.GetOrderNotesStatusDao();
            return orderNotesStatusDao.GetAll();
        }

        public OrderNotesStatus SaveOrderNotesStatus(OrderNotesStatus ordernotesstatus)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IOrderNotesStatusDao orderNotesStatusDao = factory.GetOrderNotesStatusDao();
            return orderNotesStatusDao.Save(ordernotesstatus);
        }

        public OrderNotesStatus UpdateOrderNotesStatus(OrderNotesStatus newOrderNotesStatus, OrderNotesStatus origOrderNotesStatus)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IOrderNotesStatusDao orderNotesStatusDao = factory.GetOrderNotesStatusDao();
            return orderNotesStatusDao.Update(newOrderNotesStatus, origOrderNotesStatus);
        }

        public List<VanDeliveryItem> InvoicesByDateAndVan(DateTime deliveryDate, int vanId)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IOrderNotesStatusDao orderNotesStatusDao = factory.GetOrderNotesStatusDao();
            return orderNotesStatusDao.InvoicesByDateAndVan(deliveryDate, vanId);
        }

        public void UpdateVanForInvoice(int orderID, int vanID)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IOrderNotesStatusDao orderNotesStatusDao = factory.GetOrderNotesStatusDao();
            orderNotesStatusDao.UpdateVanForInvoice(orderID, vanID);
        }

        public List<VanInvoiceCount> GetVanInvoiceCount(DateTime deliveryDate)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IOrderNotesStatusDao orderNotesStatusDao = factory.GetOrderNotesStatusDao();
            return orderNotesStatusDao.GetVanInvoiceCount(deliveryDate);
        }

        #endregion

        #region IOutletStore Related Functions

        public void DeleteOutletStore(OutletStore store)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IOutletStoreDao OutletStoreCodeDao = factory.GetOutletStoreDao();

            OutletStoreCodeDao.Delete(store);
        }

        public SP.Core.Domain.OutletStore GetOutletStore(int id)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IOutletStoreDao OutletStoreCodeDao = factory.GetOutletStoreDao();

            return OutletStoreCodeDao.GetById(id);
        }

        public SP.Core.Domain.OutletStore SaveOutletStore(OutletStore store)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IOutletStoreDao OutletStoreCodeDao = factory.GetOutletStoreDao();

            return OutletStoreCodeDao.Save(store);
        }

        public OutletStore UpdateOutletStore(OutletStore newOutletStore, OutletStore origOutletStore)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IOutletStoreDao outletStoreDao = factory.GetOutletStoreDao();

            outletStoreDao.Update(newOutletStore, origOutletStore);

            return newOutletStore;
        }
        #endregion

        #region IPhone

        public Phone GetPhoneById(int id)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IPhoneDao ffDao = factory.GetPhoneDao();
            return ffDao.GetPhoneById(id);
        }

        public void DeletePhone(Phone phone)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IPhoneDao ffDao = factory.GetPhoneDao();
            ffDao.Delete(phone);
        }

        public Phone SavePhone(Phone phone)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IPhoneDao ffDao = factory.GetPhoneDao();
            return ffDao.Save(phone);
        }

        public Phone SavePhone(Phone phone, object DataContext)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IPhoneDao ffDao = factory.GetPhoneDao();
            LTSDataContext context = DataContext as LTSDataContext;
            ffDao.SetDataContext(context);

            return ffDao.Save(phone);
        }
        #endregion

        #region IPhoneNoType Members

        public PhoneNoType GetPhoneNoTypeById(int id)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IPhoneNoTypeDao phoneNoTypeDao = factory.GetPhoneNoTypeDao();

            return phoneNoTypeDao.GetById(id);
        }

        public PhoneNoType GetPhoneNoTypeById(int id, object context)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IPhoneNoTypeDao phoneNoTypeDao = factory.GetPhoneNoTypeDao();

            LTSDataContext dataContext = context as LTSDataContext;
            phoneNoTypeDao.SetDataContext(context);

            return phoneNoTypeDao.GetById(id);
        }

        #endregion

        #region IPriceListHeader

        public PriceListHeader GetPriceListHeaderByID(int id)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IPriceListHeaderDao ffDao = factory.GetPriceListHeaderDao();

            return ffDao.GetById(id);
        }

        public void DeletePriceList(PriceListHeader hdr)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IPriceListHeaderDao ffDao = factory.GetPriceListHeaderDao();

            ffDao.Delete(hdr);
        }

        public PriceListHeader SavePriceListHeader(PriceListHeader priceListHeader)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IPriceListHeaderDao ffDao = factory.GetPriceListHeaderDao();

            if (ffDao.PriceListExists(priceListHeader.PriceListName))
                throw new ApplicationException("Cannot add Price list header already exists");

            return ffDao.Save(priceListHeader);
        }

        public PriceListHeader UpdatePriceListHeader(PriceListHeader newPriceListHeader, PriceListHeader origPriceListHeader)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IPriceListHeaderDao ffDao = factory.GetPriceListHeaderDao();
            return ffDao.Update(newPriceListHeader, origPriceListHeader);
        }

        public List<PriceListHeader> GetAllPriceListHeaders()
        {
            IDaoFactory factory = new LTSDaoFactory();
            IPriceListHeaderDao ffDao = factory.GetPriceListHeaderDao();

            return ffDao.GetAll().OrderBy(q => q.PriceListName).ToList<PriceListHeader>();
        }
        #endregion

        #region IPriceListItem

        public void DeletePriceListItemByID(int priceListItem)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IPriceListItemDao ffDao = factory.GetPriceListItemDao();
            PriceListItem Item = ffDao.GetById(priceListItem);

            ffDao = factory.GetPriceListItemDao();
            ffDao.Delete(Item);
        }

        public PriceListItem GetPriceListItemById(int id)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IPriceListItemDao ffDao = factory.GetPriceListItemDao();
            return ffDao.GetById(id);
        }

        public PriceListItem GetPriceListItemByProductId(int priceListID, int productId)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IPriceListItemDao ffDao = factory.GetPriceListItemDao();
            return ffDao.GetByProductId(priceListID, productId);
        }

        public PriceListItem SavePriceListItem(PriceListItem priceListItem)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IPriceListItemDao ffDao = factory.GetPriceListItemDao();
            return ffDao.Save(priceListItem);
        }

        public PriceListItem UpdatePriceListItem(PriceListItem newProduct, PriceListItem origProduct)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IPriceListItemDao ffDao = factory.GetPriceListItemDao();
            return ffDao.Update(newProduct, origProduct);
        }

        public List<PriceListItem> GetPriceListItemByPriceListHeader(int id)
        {
            LTSDataContext context = new LTSDataContext();
            DataLoadOptions dlo = new DataLoadOptions();
            dlo.LoadWith<PriceListItem>(q => q.Product);
            context.LoadOptions = dlo;

            IDaoFactory factory = new LTSDaoFactory();
            IPriceListItemDao ffDao = factory.GetPriceListItemDao();
            ffDao.SetDataContext(context);

            return ffDao.GetByPriceListHeader(id);
        }

        public void DeletePriceListItemByProductId(int priceListID, int productId)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IPriceListItemDao priceListItemDao = factory.GetPriceListItemDao();

            PriceListItem pd = priceListItemDao.GetByProductId(priceListID, productId);
            if (pd != null)
            {
                IPriceListItemDao priceListItemDaoDelete = factory.GetPriceListItemDao();
                priceListItemDaoDelete.Delete(pd);
            }
        }

        #endregion

        #region IProducts Related Functions
        /***************************************************************************************************************
         * Customer Related Functions
         ***************************************************************************************************************/
        public Product SaveProduct(Product product)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IProductDao ffDao = factory.GetProductDao();
            return ffDao.Save(product);
        }

        public void DeleteProduct(Product product)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IProductDao productDao = factory.GetProductDao();

            productDao.Delete(product);
        }

        public List<Product> GetAllProducts()
        {
            IDaoFactory factory = new LTSDaoFactory();
            IProductDao productDao = factory.GetProductDao();

            return productDao.GetAll().OrderBy(p => p.ProductCode).ThenBy(p => p.Description).ToList<Product>();
        }

        public Product GetProduct(int id)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IProductDao productDao = factory.GetProductDao();

            return productDao.GetById(id);
        }

        public Product UpdateProduct(Product newProduct, Product origProduct)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IProductDao productDao = factory.GetProductDao();

            IProductDao originalProductDao = factory.GetProductDao();
            if (originalProductDao.ProductCodeExists(newProduct.ProductCode))
            {
                Product existingProduct = originalProductDao.GetByProductCode(newProduct.ProductCode);
                if (newProduct.ID != existingProduct.ID)
                {
                    throw new ApplicationException("Cannot update product code - poduct code already exists for another item");
                }
            }

            productDao.Update(newProduct, origProduct);

            return newProduct;
        }

        public Product GetProductByProductCode(string code)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IProductDao productDao = factory.GetProductDao();
            return productDao.GetByProductCode(code);
        }

        public bool ProductCodeExists(string productCode)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IProductDao productDao = factory.GetProductDao();
            return productDao.ProductCodeExists(productCode);
        }

        public List<Product> GetLikeProductCode(string productCode)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IProductDao productDao = factory.GetProductDao();
            return productDao.GetLikeProductCode(productCode);
        }
        public List<Product> GetLikeProductDescription(string productDescription)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IProductDao productDao = factory.GetProductDao();
            return productDao.GetLikeProductDescription(productDescription);
        }

        public List<Product> GetProductsInPriceList(int id)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IProductDao productDao = factory.GetProductDao();
            return productDao.GetProductsInPriceList(id);
        }

        public List<Product> GetProductsOutOfProductList(int id)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IProductDao productDao = factory.GetProductDao();
            return productDao.GetProductsOutOfProductList(id);
        }

        #endregion

        #region SpecialInvoiceCreditNote
        public void DeleteSpecialInvoiceCreditNote(SpecialInvoiceCreditNote specialinvoicecreditnote)
        {
            IDaoFactory factory = new LTSDaoFactory();
            ISpecialInvoiceCreditNoteDao specialInvoiceCreditNoteDao = factory.GetSpecialInvoiceCreditNoteDao();

            specialInvoiceCreditNoteDao.Delete(specialinvoicecreditnote);
        }

        public SpecialInvoiceCreditNote GetSpecialInvoiceCreditNote(int id)
        {
            IDaoFactory factory = new LTSDaoFactory();
            ISpecialInvoiceCreditNoteDao specialInvoiceCreditNoteDao = factory.GetSpecialInvoiceCreditNoteDao();
            return specialInvoiceCreditNoteDao.GetById(id);
        }

        public List<SpecialInvoiceCreditNote> GetAllSpecialInvoiceCreditNotes()
        {
            IDaoFactory factory = new LTSDaoFactory();
            ISpecialInvoiceCreditNoteDao specialInvoiceCreditNoteDao = factory.GetSpecialInvoiceCreditNoteDao();
            return specialInvoiceCreditNoteDao.GetAll();
        }

        public SpecialInvoiceCreditNote SaveSpecialInvoiceCreditNote(SpecialInvoiceCreditNote specialinvoicecreditnote)
        {
            IDaoFactory factory = new LTSDaoFactory();
            ISpecialInvoiceCreditNoteDao specialInvoiceCreditNoteDao = factory.GetSpecialInvoiceCreditNoteDao();
            ISpecialInvoiceCreditNoteDao validateNoteDao = factory.GetSpecialInvoiceCreditNoteDao();

            if (validateNoteDao.CheckIfReferenceExists(specialinvoicecreditnote.Reference))
                throw new ApplicationException("Cannot add Special Invoice Credit note - Credit Reference is already in use");
            specialinvoicecreditnote.Reference = specialInvoiceCreditNoteDao.GenerateSpecialInvoiceCreditNo();

            return specialInvoiceCreditNoteDao.Save(specialinvoicecreditnote);
        }

        public SpecialInvoiceCreditNote UpdateSpecialInvoiceCreditNote(SpecialInvoiceCreditNote newSpecialInvoiceCreditNote, SpecialInvoiceCreditNote origSpecialInvoiceCreditNote)
        {
            IDaoFactory factory = new LTSDaoFactory();
            ISpecialInvoiceCreditNoteDao specialInvoiceCreditNoteDao = factory.GetSpecialInvoiceCreditNoteDao();
            return specialInvoiceCreditNoteDao.Update(newSpecialInvoiceCreditNote, origSpecialInvoiceCreditNote);
        }

        public List<SpecialInvoiceCreditNoteDetails> SearchSpecialInvoiceCreditNotes(string specialInvoiceNo, string invoiceNo, string customerName, DateTime dateFrom, DateTime dateTo)
        {
            IDaoFactory factory = new LTSDaoFactory();
            ISpecialInvoiceCreditNoteDao creditNoteDao = factory.GetSpecialInvoiceCreditNoteDao();
            return creditNoteDao.SearchSpecialInvoiceCreditNotes(specialInvoiceNo, invoiceNo, customerName, dateFrom, dateTo);
        }

        public List<SpecialInvoiceCreditNote> GetSpecialInvoiceCreditNotesByInvoiceId(int specialInvoiceId)
        {
            IDaoFactory factory = new LTSDaoFactory();
            ISpecialInvoiceCreditNoteDao creditNoteDao = factory.GetSpecialInvoiceCreditNoteDao();
            return creditNoteDao.GetSpecialInvoiceCreditNotesByInvoiceId(specialInvoiceId);
        }

        public string GenerateSpecialInvoiceCreditNo()
        {
            IDaoFactory factory = new LTSDaoFactory();
            ISpecialInvoiceCreditNoteDao creditNoteDao = factory.GetSpecialInvoiceCreditNoteDao();
            return creditNoteDao.GenerateSpecialInvoiceCreditNo();
        }

        public SpecialInvoiceCreditNoteBalance GetSpecialInvoiceCreditBalance(int specialInvoiceNo)
        {
            IDaoFactory factory = new LTSDaoFactory();
            ISpecialInvoiceCreditNoteDao creditNoteDao = factory.GetSpecialInvoiceCreditNoteDao();

            ISpecialInvoiceHeaderDao specialInvoiceHeaderDao = factory.GetSpecialInvoiceHeaderDao();
            SpecialInvoiceHeader specialInvoiceHeader = specialInvoiceHeaderDao.GetById(specialInvoiceNo);

            decimal vatRatePercentage;
            IVatCodeDao vatCodeDao = factory.GetVatCodeDao();
            VatCode vatCode = vatCodeDao.GetById(specialInvoiceHeader.VatCodeID);
            if (vatCode.VatExemptible == true)
            {
                vatRatePercentage = new decimal(0.0);
            }
            else
            {
                vatRatePercentage = Convert.ToDecimal(vatCode.PercentageValue);
            }

            return creditNoteDao.GetSpecialInvoiceCreditBalance(specialInvoiceNo, vatRatePercentage);
        }

        public decimal GetSpecialInvoiceOustandingBalance(int specialInvoiceId, int creditNote, decimal vatRate)
        {
            IDaoFactory factory = new LTSDaoFactory();
            ISpecialInvoiceCreditNoteDao creditNoteDao = factory.GetSpecialInvoiceCreditNoteDao();
            return creditNoteDao.GetSpecialInvoiceOustandingBalance(specialInvoiceId, creditNote, vatRate);
        }

        public bool SpecialInvoiceCreditNoteExistsByOrderId(int specialInvoiceNo)
        {
            IDaoFactory factory = new LTSDaoFactory();
            ISpecialInvoiceCreditNoteDao creditNoteDao = factory.GetSpecialInvoiceCreditNoteDao();
            return creditNoteDao.SpecialInvoiceCreditNoteExistsByInvoiceId(specialInvoiceNo);
        }

        public bool ReferenceExists(string referenceNo)
        {
            IDaoFactory factory = new LTSDaoFactory();
            ISpecialInvoiceCreditNoteDao creditNoteDao = factory.GetSpecialInvoiceCreditNoteDao();
            return creditNoteDao.CheckIfReferenceExists(referenceNo);
        }

        public SpecialInvoiceCreditNote SpecialInvoieceGetByReferenceId(string reference)
        {
            IDaoFactory factory = new LTSDaoFactory();
            ISpecialInvoiceCreditNoteDao creditNoteDao = factory.GetSpecialInvoiceCreditNoteDao();
            return creditNoteDao.SpecialInvoiceGetByReferenceId(reference);
        }

        #endregion

        #region SpecialInvoiceHeader
        public List<SpecialInvoiceHeader> GetSpecialHeaders(string orderNo, string invoiceNo, string customerName, DateTime dateFrom, DateTime dateTo, short orderStatus)
        {
            IDaoFactory factory = new LTSDaoFactory();
            ISpecialInvoiceHeaderDao specialInvoiceHeaderDao = factory.GetSpecialInvoiceHeaderDao();
            return specialInvoiceHeaderDao.GetSpecialHeaders(
                orderNo, invoiceNo, customerName, dateFrom, dateTo, orderStatus);
        }

        public void DeleteSpecialInvoiceHeader(SpecialInvoiceHeader specialinvoiceheader)
        {
            IDaoFactory factory = new LTSDaoFactory();
            ISpecialInvoiceHeaderDao specialInvoiceHeaderDao = factory.GetSpecialInvoiceHeaderDao();

            specialInvoiceHeaderDao.Delete(specialinvoiceheader);
        }

        public SpecialInvoiceHeader GetSpecialInvoiceHeader(int id)
        {
            IDaoFactory factory = new LTSDaoFactory();
            ISpecialInvoiceHeaderDao specialInvoiceHeaderDao = factory.GetSpecialInvoiceHeaderDao();
            return specialInvoiceHeaderDao.GetById(id);
        }

        public List<SpecialInvoiceHeader> GetAllSpecialInvoiceHeaders()
        {
            IDaoFactory factory = new LTSDaoFactory();
            ISpecialInvoiceHeaderDao specialInvoiceHeaderDao = factory.GetSpecialInvoiceHeaderDao();
            return specialInvoiceHeaderDao.GetAll();
        }

        public SpecialInvoiceHeader SaveSpecialInvoiceHeader(SpecialInvoiceHeader specialinvoiceheader)
        {
            IDaoFactory factory = new LTSDaoFactory();
            ISpecialInvoiceHeaderDao specialInvoiceHeaderDao = factory.GetSpecialInvoiceHeaderDao();

            specialinvoiceheader.InvoiceNo = specialInvoiceHeaderDao.GenerateSpecialInvoiceNo();

            return specialInvoiceHeaderDao.Save(specialinvoiceheader);
        }

        public SpecialInvoiceHeader UpdateSpecialInvoiceHeader(SpecialInvoiceHeader newSpecialInvoiceHeader, SpecialInvoiceHeader origSpecialInvoiceHeader)
        {
            IDaoFactory factory = new LTSDaoFactory();
            ISpecialInvoiceHeaderDao specialInvoiceHeaderDao = factory.GetSpecialInvoiceHeaderDao();
            return specialInvoiceHeaderDao.Update(newSpecialInvoiceHeader, origSpecialInvoiceHeader);
        }

        #endregion

        #region SpecialInvoiceLine

        public List<SpecialInvoiceLine> GetBySpecialInvoiceId(int id)
        {
            IDaoFactory factory = new LTSDaoFactory();
            ISpecialInvoiceLineDao specialInvoiceLineDao = factory.GetSpecialInvoiceLineDao();

            return specialInvoiceLineDao.GetBySpecialInvoiceId(id);
        }

        public void DeleteSpecialInvoiceLine(SpecialInvoiceLine specialinvoicelines)
        {
            IDaoFactory factory = new LTSDaoFactory();
            ISpecialInvoiceLineDao specialInvoiceLineDao = factory.GetSpecialInvoiceLineDao();

            specialInvoiceLineDao.Delete(specialinvoicelines);
        }

        public SpecialInvoiceLine GetSpecialInvoiceLine(int id)
        {
            IDaoFactory factory = new LTSDaoFactory();
            ISpecialInvoiceLineDao specialInvoiceLineDao = factory.GetSpecialInvoiceLineDao();
            return specialInvoiceLineDao.GetById(id);
        }

        public List<SpecialInvoiceLine> GetAllSpecialInvoiceLines()
        {
            IDaoFactory factory = new LTSDaoFactory();
            ISpecialInvoiceLineDao specialInvoiceLineDao = factory.GetSpecialInvoiceLineDao();
            return specialInvoiceLineDao.GetAll();
        }

        public SpecialInvoiceLine SaveSpecialInvoiceLine(SpecialInvoiceLine specialinvoicelines)
        {
            IDaoFactory factory = new LTSDaoFactory();
            ISpecialInvoiceLineDao specialInvoiceLineDao = factory.GetSpecialInvoiceLineDao();
            return specialInvoiceLineDao.Save(specialinvoicelines);
        }

        public SpecialInvoiceLine UpdateSpecialInvoiceLine(SpecialInvoiceLine newSpecialInvoiceLine, SpecialInvoiceLine origSpecialInvoiceLine)
        {
            IDaoFactory factory = new LTSDaoFactory();
            ISpecialInvoiceLineDao specialInvoiceLineDao = factory.GetSpecialInvoiceLineDao();
            return specialInvoiceLineDao.Update(newSpecialInvoiceLine, origSpecialInvoiceLine);
        }

        #endregion

        #region StandardVatRate

        public bool StandardVatRateExists()
        {
            IDaoFactory factory = new LTSDaoFactory();
            IStandardVatRateDao standardVatRateDao = factory.GetStandardVatRateDao();

            return standardVatRateDao.Exists();
        }

        public void DeleteStandardVatRate(StandardVatRate standardvatrate)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IStandardVatRateDao standardVatRateDao = factory.GetStandardVatRateDao();

            standardVatRateDao.Delete(standardvatrate);
        }

        public StandardVatRate GetStandardVatRate()
        {
            IDaoFactory factory = new LTSDaoFactory();
            IStandardVatRateDao standardVatRateDao = factory.GetStandardVatRateDao();
            return standardVatRateDao.Get();
        }

        public List<StandardVatRate> GetAllStandardVatRates()
        {
            IDaoFactory factory = new LTSDaoFactory();
            IStandardVatRateDao standardVatRateDao = factory.GetStandardVatRateDao();
            return standardVatRateDao.GetAll();
        }

        public StandardVatRate SaveStandardVatRate(StandardVatRate standardvatrate)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IStandardVatRateDao standardVatRateDao = factory.GetStandardVatRateDao();

            if (standardVatRateDao.Exists())
            {
                StandardVatRate originalRate = standardVatRateDao.Get();
                standardvatrate.ID = originalRate.ID;

                IStandardVatRateDao newVatRateDao = factory.GetStandardVatRateDao();
                return newVatRateDao.Update(standardvatrate, originalRate);
            }
            else
            {
                return standardVatRateDao.Save(standardvatrate);
            }
        }

        public StandardVatRate UpdateStandardVatRate(StandardVatRate newStandardVatRate, StandardVatRate origStandardVatRate)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IStandardVatRateDao standardVatRateDao = factory.GetStandardVatRateDao();
            return standardVatRateDao.Update(newStandardVatRate, origStandardVatRate);
        }

        #endregion

        #region ITerm related Functions

        public void DeleteTerm(Terms term)
        {
            IDaoFactory factory = new LTSDaoFactory();
            ITermsDao termsDao = factory.GetTermsDao();

            termsDao.Delete(term);
        }

        public List<Terms> GetAllTerms()
        {
            IDaoFactory factory = new LTSDaoFactory();
            ITermsDao termsDao = factory.GetTermsDao();

            return termsDao.GetAll();
        }

        public Terms SaveTerm(Terms term)
        {
            IDaoFactory factory = new LTSDaoFactory();
            ITermsDao termsDao = factory.GetTermsDao();

            return termsDao.Save(term);
        }

        Terms IFoundationFacilitiesManager.GetTerm(int id)
        {
            IDaoFactory factory = new LTSDaoFactory();
            ITermsDao termsDao = factory.GetTermsDao();

            return termsDao.GetById(id);
        }

        public Terms UpdateTerm(Terms newTerm, Terms origTerm)
        {
            IDaoFactory factory = new LTSDaoFactory();
            ITermsDao termsDao = factory.GetTermsDao();

            return termsDao.Update(newTerm, origTerm);
        }

        #endregion

        #region IVatCode Members

        public SP.Core.Domain.VatCode SaveVatCode(SP.Core.Domain.VatCode cde)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IVatCodeDao vatCodeDao = factory.GetVatCodeDao();

            vatCodeDao.Save(cde);
            vatCodeDao.CommitChanges();

            return cde;
        }

        public SP.Core.Domain.VatCode UpdateVatCode(SP.Core.Domain.VatCode newVatCode, SP.Core.Domain.VatCode origVatCode)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IVatCodeDao existingVatCodeDao = factory.GetVatCodeDao();

            VatCode existingVatCode = existingVatCodeDao.GetVatCodeByCode(newVatCode.Code);
            if ((existingVatCode != null) && (existingVatCode.ID != newVatCode.ID))
                throw new ApplicationException("Cannot update Vat Code you are trying to change to a code that already exists");

            IVatCodeDao vatCodeDao = factory.GetVatCodeDao();
            vatCodeDao.Update(newVatCode, origVatCode);

            return newVatCode;
        }

        public SP.Core.Domain.VatCode GetVatCode(int id)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IVatCodeDao vatCodeDao = factory.GetVatCodeDao();

            return vatCodeDao.GetById(id);
        }

        public void DeleteVatCode(SP.Core.Domain.VatCode cde)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IVatCodeDao vatCodeDao = factory.GetVatCodeDao();

            vatCodeDao.Delete(cde);
        }

        public List<SP.Core.Domain.VatCode> GetAllVatCodes()
        {
            IDaoFactory factory = new LTSDaoFactory();
            IVatCodeDao vatCodeDao = factory.GetVatCodeDao();

            return vatCodeDao.GetAll();
        }

        public bool VatCodeExists(string vatCode)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IVatCodeDao vatCodeDao = factory.GetVatCodeDao();

            return vatCodeDao.CodeExists(vatCode);
        }

        #endregion

        #region IVan related Functions

        public void DeleteVan(Van van)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IVanDao vanDao = factory.GetVanDao();

            vanDao.Delete(van);
        }

        public List<Van> GetAllVans()
        {
            IDaoFactory factory = new LTSDaoFactory();
            IVanDao vanDao = factory.GetVanDao();

            return vanDao.GetAll();
        }

        public Van SaveVan(Van van)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IVanDao vanDao = factory.GetVanDao();

            return vanDao.Save(van);
        }

        public Van GetVan(int id)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IVanDao vanDao = factory.GetVanDao();

            return vanDao.GetById(id);
        }

        public Van UpdateVan(Van newVan, Van origVan)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IVanDao vanDao = factory.GetVanDao();

            return vanDao.Update(newVan, origVan);
        }

        #endregion

        #region Private Helper Methods

        public decimal GetOrderExVatTotal(int orderId)
        {
            IDaoFactory factory = new LTSDaoFactory();
            IOrderHeaderDao orderHeaderDao = factory.GetOrderHeaderDao();

            return orderHeaderDao.GetOrderExVatTotal(orderId);
        }

        private string GenerateOrderNo()
        {
            IDaoFactory factory = new LTSDaoFactory();
            IOrderHeaderDao orderHeaderDao = factory.GetOrderHeaderDao();

            return orderHeaderDao.GenerateOrderNo();
        }

        private string GenerateInvoiceNo()
        {
            IDaoFactory factory = new LTSDaoFactory();
            IOrderHeaderDao orderHeaderDao = factory.GetOrderHeaderDao();

            return orderHeaderDao.GenerateInvoiceNo();
        }

        private string GenerateInvoiceProformaNo()
        {
            IDaoFactory factory = new LTSDaoFactory();
            IOrderHeaderDao orderHeaderDao = factory.GetOrderHeaderDao();

            return orderHeaderDao.GenerateInvoiceProformaNo();
        }

        private string GenerateDeliveryNoteNo()
        {
            IDaoFactory factory = new LTSDaoFactory();
            IOrderHeaderDao orderHeaderDao = factory.GetOrderHeaderDao();

            return orderHeaderDao.GenerateDeliveryNoteNo();
        }

        private static decimal GetStandardVatRatePercentageValue()
        {
            IDaoFactory factory = new LTSDaoFactory();
            IStandardVatRateDao standardVatCodeDao = factory.GetStandardVatRateDao();

            StandardVatRate standardVatRate = standardVatCodeDao.Get();

            IVatCodeDao vatCodeDao = factory.GetVatCodeDao();
            VatCode vatCode = vatCodeDao.GetById(standardVatRate.VatCodeID);

            return Convert.ToDecimal(vatCode.PercentageValue);
        }

        #endregion
    }
}