using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.SqlClient;

using SP.Core.Domain;
using SP.Core.ManagerInterfaces;
using SP.Worker;
using SP.Data.LTS;
using SP.Util;

namespace SPWCFServer
{
    public class FoundationService : IFoundationService
    {
        #region IAccount Members
        public Account SaveAccount(Account account)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();

                SP.Core.Domain.Account coreAccount =
                    ObjectExtension.CloneProperties<SPWCFServer.Account, SP.Core.Domain.Account>(account);

                SP.Core.Domain.Address coreAddress =
                    ObjectExtension.CloneProperties<SPWCFServer.Address, SP.Core.Domain.Address>(account.Address);

                coreAccount.Address = coreAddress;

                coreAccount = mgr.SaveAccount(coreAccount);

                return ObjectExtension.CloneProperties<SP.Core.Domain.Account, SPWCFServer.Account>(coreAccount);
            }
            catch (Exception ex)
            {
                // Log full Exception to be done ...
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public bool AlphaIDExists(string id)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();
                return mgr.AlphaIDExists(id);

            }
            catch (Exception ex)
            {
                // Log full Exception to be done ...
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public List<Account> GetAllAccounts()
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();
                List<SP.Core.Domain.Account> accountList = mgr.GetAllAccounts();

                return ObjectExtension.CloneList<SP.Core.Domain.Account, SPWCFServer.Account>(accountList);
            }
            catch (Exception ex)
            {
                // Log full Exception to be done ...
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public List<Account> GetAccountsByCustomerId(int id)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();
                return ObjectExtension.CloneList<SP.Core.Domain.Account, SPWCFServer.Account>(mgr.GetAccountsByCustomerId(id));
            }
            catch (Exception ex)
            {
                // Log full Exception to be done ...
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public Account GetAccount(int id)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();

                SP.Core.Domain.Account coreAccount = mgr.GetAccount(id);
                Account account = ObjectExtension.CloneProperties<SP.Core.Domain.Account, SPWCFServer.Account>(coreAccount);

                account.Address = (coreAccount.Address != null) ?
                    ObjectExtension.CloneProperties<SP.Core.Domain.Address, SPWCFServer.Address>(coreAccount.Address) : null;
                return account;

            }
            catch (Exception ex)
            {
                // Log full Exception to be done ...
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public Account GetAccountByAlphaID(string id)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();

                SP.Core.Domain.Account coreAccount = mgr.GetAccountByAlphaID(id);
                Account account = ObjectExtension.CloneProperties<SP.Core.Domain.Account, SPWCFServer.Account>(coreAccount);

                account.Address = (coreAccount.Address != null) ?
                    ObjectExtension.CloneProperties<SP.Core.Domain.Address, SPWCFServer.Address>(coreAccount.Address) : null;
                return account;

            }
            catch (Exception ex)
            {
                // Log full Exception to be done ...
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public Account UpdateAccount(Account newAccount, Account origAccount)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();

                SP.Core.Domain.Account coreNewAccount = ObjectExtension.CloneProperties<SPWCFServer.Account, SP.Core.Domain.Account>(newAccount);
                SP.Core.Domain.Address coreNewAddress = ObjectExtension.CloneProperties<SPWCFServer.Address, SP.Core.Domain.Address>(newAccount.Address);
                coreNewAccount.Address = coreNewAddress;
                coreNewAccount.Address.Account = coreNewAccount;

                SP.Core.Domain.Account coreOrigAccount = ObjectExtension.CloneProperties<SPWCFServer.Account, SP.Core.Domain.Account>(origAccount);
                SP.Core.Domain.Address coreOrigAddress = ObjectExtension.CloneProperties<SPWCFServer.Address, SP.Core.Domain.Address>(origAccount.Address);
                coreOrigAccount.Address = coreOrigAddress;
                coreOrigAccount.Address.Account = coreOrigAccount;

                coreNewAccount = mgr.UpdateAccount(coreNewAccount, coreOrigAccount);

                newAccount = ObjectExtension.CloneProperties<SP.Core.Domain.Account, SPWCFServer.Account>(coreNewAccount);

                return newAccount;


                //return ObjectExtension.CloneProperties<SP.Core.Domain.Account, SPWCFServer.Account>
                //    (mgr.UpdateAccount(ObjectExtension.CloneProperties<SPWCFServer.Account, SP.Core.Domain.Account>(newAccount),
                //        ObjectExtension.CloneProperties<SPWCFServer.Account, SP.Core.Domain.Account>(origAccount)));
            }
            catch (Exception ex)
            {
                // Log full Exception to be done ...
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public void DeleteAccount(Account cde)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();
                SP.Core.Domain.Account coreAccount = ObjectExtension.CloneProperties<SPWCFServer.Account, SP.Core.Domain.Account>(cde);
                SP.Core.Domain.Address coreAddress = ObjectExtension.CloneProperties<SPWCFServer.Address, SP.Core.Domain.Address>(cde.Address);
                coreAccount.Address = coreAddress;
                mgr.DeleteAccount(coreAccount);
            }
            catch (SqlException)
            {
                throw new FaultException("SPWCF Service error : " + "Cannot delete description. It is likely that the description has outstanding Accounts still linked to it");
            }
            catch (Exception ex)
            {
                // Log full Exception to be done ...
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        #endregion

        #region Address
        public Address GetAddress(int id)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();

                SP.Core.Domain.Address coreAddress = mgr.GetAddress(id);
                return ObjectExtension.CloneProperties<SP.Core.Domain.Address, SPWCFServer.Address>(coreAddress);
            }
            catch (Exception ex)
            {
                // Log full Exception to be done ...
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        #endregion

        #region IAutogen
        public int GenerateOrderNo()
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();
                return mgr.Generate();

            }
            catch (SqlException)
            {
                throw new FaultException("SPWCF Service error : " + "Cannot delete description. It is likely that the description has outstanding Accounts still linked to it");
            }
            catch (Exception ex)
            {
                // Log full Exception to be done ...
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }
        #endregion

        #region IContactDetailMembers

        public void DeleteContactDetail(ContactDetail contactDetail)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();
                foreach (Phone phone in contactDetail.Phone)
                {
                    SP.Core.Domain.Phone t = ObjectExtension.CloneProperties<SPWCFServer.Phone, SP.Core.Domain.Phone>(phone);
                    // SP.Core.Domain.Phone p = mgr.GetPhoneById(phone.ID);
                    mgr.DeletePhone(t);
                }

                mgr.DeleteContactDetail(ObjectExtension.CloneProperties<SPWCFServer.ContactDetail, SP.Core.Domain.ContactDetail>(contactDetail));

            }
            catch (SqlException)
            {
                throw new FaultException("SPWCF Service error : " + "Cannot delete description. It is likely that the description has outstanding Accounts still linked to it");
            }
            catch (Exception ex)
            {
                // Log full Exception to be done ...
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public ContactDetail GetContactDetailByID(int id)
        {
            IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();

            SP.Core.Domain.ContactDetail coreContactDetail = mgr.GetContactDetailByID(id);

            List<Phone> phoneList =
                    ObjectExtension.CloneList<SP.Core.Domain.Phone, SPWCFServer.Phone>(coreContactDetail.Phone);

            for (int j = 0; j < phoneList.Count; j++)
            {
                phoneList[j].PhoneNoType =
                    ObjectExtension.CloneProperties<SP.Core.Domain.PhoneNoType,
                        SPWCFServer.PhoneNoType>(coreContactDetail.Phone[j].PhoneNoType);
                phoneList[j].PhoneTypeID = phoneList[j].PhoneNoType.ID;
            }

            ContactDetail contactDetail = ObjectExtension.CloneProperties<SP.Core.Domain.ContactDetail, SPWCFServer.ContactDetail>(coreContactDetail);
            contactDetail.Phone = phoneList;

            return contactDetail;

        }

        public List<ContactDetail> GetContactDetailsByCustomer(int id)
        {
            IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();

            List<SP.Core.Domain.ContactDetail> coreContactDetailList = mgr.GetContactDetailsByCustomer(id);

            List<ContactDetail> contactDetailList =
                ObjectExtension.CloneList<SP.Core.Domain.ContactDetail, SPWCFServer.ContactDetail>(coreContactDetailList);

            for (int i = 0; i < contactDetailList.Count; i++)
            {
                List<Phone> phoneList =
                    ObjectExtension.CloneList<SP.Core.Domain.Phone, SPWCFServer.Phone>(coreContactDetailList[i].Phone);

                for (int j = 0; j < phoneList.Count; j++)
                {
                    phoneList[j].PhoneNoType =
                        ObjectExtension.CloneProperties<SP.Core.Domain.PhoneNoType,
                            SPWCFServer.PhoneNoType>(coreContactDetailList[i].Phone[j].PhoneNoType);
                    phoneList[j].PhoneTypeID = phoneList[j].PhoneNoType.ID;
                }
                contactDetailList[i].Phone = phoneList;
            }

            return contactDetailList;

        }

        public ContactDetail SaveContactDetail(ContactDetail contactDetail)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();

                LTSDataContext context = new LTSDataContext();

                SP.Core.Domain.ContactDetail coreContactDetail =
                   ObjectExtension.CloneProperties<SPWCFServer.ContactDetail, SP.Core.Domain.ContactDetail>(contactDetail);

                // Fix up Phone Back References
                List<SP.Core.Domain.Phone> corePhoneList =
                   ObjectExtension.CloneList<SPWCFServer.Phone, SP.Core.Domain.Phone>(contactDetail.Phone);

                for (int i = 0; i < corePhoneList.Count; i++)
                {
                    corePhoneList[i].ContactDetailID = coreContactDetail.ID;
                    corePhoneList[i].ContactDetail = coreContactDetail;
                    corePhoneList[i].PhoneTypeID = contactDetail.Phone[i].PhoneTypeID;

                    SP.Core.Domain.PhoneNoType phoneNoType = mgr.GetPhoneNoTypeById(corePhoneList[i].PhoneTypeID.Value, context);
                    corePhoneList[i].PhoneNoType = phoneNoType;
                    phoneNoType.Phone = corePhoneList[i];
                }
                coreContactDetail.Phone = corePhoneList;

                coreContactDetail = mgr.SaveContactDetail(coreContactDetail, context);

                // Having to fudge this back in at mo. Not quite sure why yet !!!
                SP.Core.Domain.Phone pFixPhone = coreContactDetail.Phone[2];
                corePhoneList[2] = mgr.SavePhone(pFixPhone, context);

                contactDetail = ObjectExtension.CloneProperties<SP.Core.Domain.ContactDetail, SPWCFServer.ContactDetail>(coreContactDetail);
                contactDetail.Phone = ObjectExtension.CloneList<SP.Core.Domain.Phone, SPWCFServer.Phone>(coreContactDetail.Phone);
                return contactDetail;
            }
            catch (Exception ex)
            {
                // Log full Exception to be done ...
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public ContactDetail UpdateContactDetail(ContactDetail newContactDetail, ContactDetail origContactDetail)
        {
            IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();

            SP.Core.Domain.ContactDetail newCoreContactDetails = ObjectExtension.CloneProperties<SPWCFServer.ContactDetail, SP.Core.Domain.ContactDetail>(newContactDetail);
            newCoreContactDetails.Phone = new List<SP.Core.Domain.Phone>();
            for (int i = 0; i < newContactDetail.Phone.Count; i++)
            {
                newCoreContactDetails.Phone.Add(ObjectExtension.CloneProperties<SPWCFServer.Phone, SP.Core.Domain.Phone>(newContactDetail.Phone[i]));
                newCoreContactDetails.Phone[i].ContactDetail = newCoreContactDetails;
                newCoreContactDetails.Phone[i].ContactDetailID = newCoreContactDetails.ID;

                newCoreContactDetails.Phone[i].PhoneNoType = ObjectExtension.CloneProperties<SPWCFServer.PhoneNoType, SP.Core.Domain.PhoneNoType>(newContactDetail.Phone[i].PhoneNoType);

                newCoreContactDetails.Phone[i].PhoneNoType.Phone = newCoreContactDetails.Phone[i];
                newCoreContactDetails.Phone[i].PhoneTypeID = newCoreContactDetails.Phone[i].PhoneNoType.ID;
            }

            SP.Core.Domain.ContactDetail origCoreContactDetails = ObjectExtension.CloneProperties<SPWCFServer.ContactDetail, SP.Core.Domain.ContactDetail>(origContactDetail);
            origCoreContactDetails.Phone = new List<SP.Core.Domain.Phone>();
            for (int i = 0; i < origContactDetail.Phone.Count; i++)
            {
                origCoreContactDetails.Phone.Add(ObjectExtension.CloneProperties<SPWCFServer.Phone, SP.Core.Domain.Phone>(origContactDetail.Phone[i]));
                origCoreContactDetails.Phone[i].ContactDetail = origCoreContactDetails;
                origCoreContactDetails.Phone[i].ContactDetailID = origCoreContactDetails.ID;

                origCoreContactDetails.Phone[i].PhoneNoType = ObjectExtension.CloneProperties<SPWCFServer.PhoneNoType, SP.Core.Domain.PhoneNoType>(origContactDetail.Phone[i].PhoneNoType);
                origCoreContactDetails.Phone[i].PhoneNoType.Phone = origCoreContactDetails.Phone[i];
                origCoreContactDetails.Phone[i].PhoneTypeID = origCoreContactDetails.Phone[i].PhoneNoType.ID;
            }

            newCoreContactDetails = mgr.UpdateContactDetail(newCoreContactDetails, origCoreContactDetails);

            return ObjectExtension.CloneProperties<SP.Core.Domain.ContactDetail, SPWCFServer.ContactDetail>(newCoreContactDetails);

        }

        #endregion

        #region CreditNote

        public bool CreditNoteExistsByOrderId(int orderId)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();
                return mgr.CreditNoteExistsByOrderId(orderId);
            }
            catch (Exception ex)
            {
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public InvoiceCreditNoteDetails GetInvoiceCreditDetails(int orderID)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();
                SP.Core.Domain.InvoiceCreditNoteDetails invoiceDetails = mgr.GetInvoiceCreditDetails(orderID);
                return ObjectExtension.CloneProperties<SP.Core.Domain.InvoiceCreditNoteDetails, SPWCFServer.InvoiceCreditNoteDetails>(invoiceDetails);
            }
            catch (Exception ex)
            {
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public void DeleteCreditNote(CreditNote creditNote)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();
                mgr.DeleteCreditNote(ObjectExtension.CloneProperties<SPWCFServer.CreditNote, SP.Core.Domain.CreditNote>(creditNote));
            }
            catch (SqlException)
            {
                throw new FaultException("SPWCF Service error : " + "Cannot delete, it is likely that there are dependent items still linked to it");
            }
            catch (Exception ex)
            {
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public List<CreditNote> GetAllCreditNotes()
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();
                List<SP.Core.Domain.CreditNote> creditNoteList = mgr.GetAllCreditNotes();
                return ObjectExtension.CloneList<SP.Core.Domain.CreditNote, SPWCFServer.CreditNote>(creditNoteList);
            }
            catch (Exception ex)
            {
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public CreditNote GetCreditNote(int id)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();
                SP.Core.Domain.CreditNote creditNote = mgr.GetCreditNote(id);
                return ObjectExtension.CloneProperties<SP.Core.Domain.CreditNote, SPWCFServer.CreditNote>(creditNote);
            }
            catch (Exception ex)
            {
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public CreditNote SaveCreditNote(CreditNote creditNote)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();
                SP.Core.Domain.CreditNote coreCreditNote =
                   ObjectExtension.CloneProperties<SPWCFServer.CreditNote, SP.Core.Domain.CreditNote>(creditNote);
                coreCreditNote = mgr.SaveCreditNote(coreCreditNote);
                return ObjectExtension.CloneProperties<SP.Core.Domain.CreditNote, SPWCFServer.CreditNote>(coreCreditNote);
            }
            catch (Exception ex)
            {
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public CreditNote UpdateCreditNote(CreditNote newCreditNote, CreditNote origCreditNote)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();

                return ObjectExtension.CloneProperties<SP.Core.Domain.CreditNote, SPWCFServer.CreditNote>
                   (mgr.UpdateCreditNote(ObjectExtension.CloneProperties<SPWCFServer.CreditNote, SP.Core.Domain.CreditNote>(newCreditNote),
                      ObjectExtension.CloneProperties<SPWCFServer.CreditNote, SP.Core.Domain.CreditNote>(origCreditNote)));
            }
            catch (Exception ex)
            {
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public List<CreditNoteDetails> SearchCreditNotes(string orderNo, string invoiceNo, string customerName, DateTime dateFrom, DateTime dateTo)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();
                List<SP.Core.Domain.CreditNoteDetails> creditNoteList = mgr.SearchCreditNotes(orderNo, invoiceNo, customerName, dateFrom, dateTo);
                return ObjectExtension.CloneList<SP.Core.Domain.CreditNoteDetails, SPWCFServer.CreditNoteDetails>(creditNoteList);
            }
            catch (Exception ex)
            {
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public List<CreditNote> GetCreditNotesByOrderId(int creditNoteId)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();
                List<SP.Core.Domain.CreditNote> creditNoteList = mgr.GetCreditNotesByOrderId(creditNoteId);
                return creditNoteList.CloneList<SP.Core.Domain.CreditNote, CreditNote>();
            }
            catch (Exception ex)
            {
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public decimal GetOustandingCreditNoteBalance(int orderNo, int creditNote, decimal vatRate)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();
                return mgr.GetOustandingCreditNoteBalance(orderNo, creditNote, vatRate);
            }
            catch (Exception ex)
            {
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        #endregion

        #region ICustomer Members

        public void DeleteCustomer(int customerID)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();
                mgr.DeleteCustomer(customerID);

            }
            catch (Exception ex)
            {
                // Log full Exception to be done ...
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public bool CustomerExistsByName(string name)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();
                return mgr.CustomerExistsByName(name);

            }
            catch (Exception ex)
            {
                // Log full Exception to be done ...
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public Customer GetCustomerByName(string name)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();

                SP.Core.Domain.Customer customer = mgr.GetCustomerByName(name);
                return ObjectExtension.CloneProperties<SP.Core.Domain.Customer, SPWCFServer.Customer>(customer);

            }
            catch (Exception ex)
            {
                // Log full Exception to be done ...
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public bool CustomerExistsWithNameLike(string name)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();
                return mgr.CustomerExistsWithNameLike(name);

            }
            catch (Exception ex)
            {
                // Log full Exception to be done ...
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }


        public List<Account> GetAccountsByCustomerID(int id)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();
                return ObjectExtension.CloneList<SP.Core.Domain.Account, SPWCFServer.Account>(mgr.GetAccountsByCustomerId(id));
            }
            catch (Exception ex)
            {
                // Log full Exception to be done ...
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }


        public List<Customer> GetAllCustomers()
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();
                return ObjectExtension.CloneList<SP.Core.Domain.Customer, SPWCFServer.Customer>(mgr.GetAllCustomers());
            }
            catch (Exception ex)
            {
                // Log full Exception to be done ...
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public List<Customer> GetByTelehoneNoLike(string telephoneNo)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();
                return ObjectExtension.CloneList<SP.Core.Domain.Customer, SPWCFServer.Customer>(mgr.GetByTelehoneNoLike(telephoneNo));
            }
            catch (Exception ex)
            {
                // Log full Exception to be done ...
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public List<Customer> GetCustomersByAccountNameLike(string name)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();

                List<SP.Core.Domain.Customer> customerList = mgr.GetCustomersByAccountNameLike(name);
                return ObjectExtension.CloneList<SP.Core.Domain.Customer, SPWCFServer.Customer>(customerList);

            }
            catch (Exception ex)
            {
                // Log full Exception to be done ...
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public List<Customer> GetCustomerByNameLike(string name)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();

                List<SP.Core.Domain.Customer> customerList = mgr.GetCustomerByNameLike(name);
                return ObjectExtension.CloneList<SP.Core.Domain.Customer, SPWCFServer.Customer>(customerList);

            }
            catch (Exception ex)
            {
                // Log full Exception to be done ...
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public Customer GetCustomerByID(int id)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();

                SP.Core.Domain.Customer coreCustomer = mgr.GetCustomerByID(id);

                Customer customer =
                    ObjectExtension.CloneProperties<SP.Core.Domain.Customer, SPWCFServer.Customer>(coreCustomer);

                customer.OutletStore = new List<OutletStore>();
                Action<SP.Core.Domain.OutletStore> outletAction =
                    new Action<SP.Core.Domain.OutletStore>(a =>
                        customer.OutletStore.Add(ObjectExtension.CloneProperties<SP.Core.Domain.OutletStore,
                        SPWCFServer.OutletStore>(a))
                        );
                coreCustomer.OutletStore.ForEach(outletAction);

                foreach (SP.Core.Domain.OutletStore st in coreCustomer.OutletStore)
                {
                    st.Address = mgr.GetAddress(st.AddressID);
                }

                customer.Account = new List<Account>();
                Action<SP.Core.Domain.Account> accountAction =
                    new Action<SP.Core.Domain.Account>(a => customer.Account.Add(ObjectExtension.CloneProperties<SP.Core.Domain.Account,
                        SPWCFServer.Account>(a))
                        );

                customer.ContactDetail = new List<ContactDetail>();
                Action<SP.Core.Domain.ContactDetail> contactDetailAction =
                    new Action<SP.Core.Domain.ContactDetail>(a => customer.ContactDetail.Add(ObjectExtension.CloneProperties<SP.Core.Domain.ContactDetail,
                        SPWCFServer.ContactDetail>(a))
                        );

                coreCustomer.Account.ForEach(accountAction);
                coreCustomer.ContactDetail.ForEach(contactDetailAction);

                for (int i = 0; i < coreCustomer.OutletStore.Count; i++)
                {
                    customer.OutletStore[i].Address = ObjectExtension.CloneProperties<SP.Core.Domain.Address,
                        SPWCFServer.Address>(coreCustomer.OutletStore[i].Address);
                }

                return customer;
            }
            catch (Exception ex)
            {
                // Log full Exception to be done ...
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }


        public Customer GetCustomerWithContacts(int id)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();

                SP.Core.Domain.Customer coreCustomer = mgr.GetCustomerWithContacts(id);
                Customer Customer = ObjectExtension.CloneProperties<SP.Core.Domain.Customer, SPWCFServer.Customer>(coreCustomer);

                Customer.ContactDetail = (coreCustomer.ContactDetail != null) ?
                    ObjectExtension.CloneList<SP.Core.Domain.ContactDetail, SPWCFServer.ContactDetail>(coreCustomer.ContactDetail) : null;

                for (int i = 0; i < Customer.ContactDetail.Count; i++)
                {
                    Customer.ContactDetail[i].Phone =
                        ObjectExtension.CloneList<SP.Core.Domain.Phone, SPWCFServer.Phone>(coreCustomer.ContactDetail[i].Phone);

                    for (int j = 0; j < Customer.ContactDetail[i].Phone.Count; j++) // phone in Customer.ContactDetail[i].Phone)
                    {
                        // Get Rid of Cyclic Details
                        Customer.ContactDetail[i].Phone[j].ContactDetail = null;
                        // Customer.ContactDetail[i].Phone[j].PhoneTypeID = coreCustomer.ContactDetail[i].Phone[j].PhoneTypeID.Value;
                    }
                }

                return Customer;

            }
            catch (Exception ex)
            {
                // Log full Exception to be done ...
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public Customer GetCustomerWithOutletStores(int id)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();

                SP.Core.Domain.Customer coreCustomer = mgr.GetCustomerWithOutletStores(id);
                Customer Customer = ObjectExtension.CloneProperties<SP.Core.Domain.Customer, SPWCFServer.Customer>(coreCustomer);

                Customer.OutletStore = (coreCustomer.OutletStore != null) ?
                    ObjectExtension.CloneList<SP.Core.Domain.OutletStore, SPWCFServer.OutletStore>(coreCustomer.OutletStore) : null;

                for (int i = 0; i < Customer.OutletStore.Count; i++)
                {
                    // SP.Core.Domain.Address address = mgr.GetAddress(Customer.OutletStore[i].AddressID);
                    Customer.OutletStore[i].Address = ObjectExtension.CloneProperties<SP.Core.Domain.Address,
                        SPWCFServer.Address>(mgr.GetAddress(Customer.OutletStore[i].AddressID));
                    // Customer.OutletStore[i].Address = newAddress;
                }

                return Customer;

            }
            catch (Exception ex)
            {
                // Log full Exception to be done ...
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public Customer SaveCustomerOutlet(Customer customer)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();

                #region Save Customer with outlet to database
                // Create Core Customer with Outlet to save to Database
                SP.Core.Domain.Customer coreCustomer =
                    ObjectExtension.CloneProperties<SPWCFServer.Customer, SP.Core.Domain.Customer>(customer);

                if (customer.OutletStore != null)
                {
                    coreCustomer.OutletStore = ObjectExtension.CloneList<SPWCFServer.OutletStore, SP.Core.Domain.OutletStore>(customer.OutletStore);
                    foreach (SP.Core.Domain.OutletStore os in coreCustomer.OutletStore)
                    {
                        os.Customer = coreCustomer;
                        os.CustomerID = coreCustomer.ID;
                    }
                }

                coreCustomer = mgr.SaveCustomer(coreCustomer);
                #endregion

                #region Deal with addresses which are not connnected in LINQ
                if (customer.OutletStore != null)
                {
                    for (int i = 0; i < customer.OutletStore.Count; i++)
                    {
                        SP.Core.Domain.Address coreAddress =
                              ObjectExtension.CloneProperties<SPWCFServer.Address, SP.Core.Domain.Address>(customer.OutletStore[i].Address);
                        mgr.SaveAddress(coreAddress);
                        // Need to now update Outlet Store with Address ID now ...
                        SP.Core.Domain.OutletStore tmpOutletStore = mgr.GetOutletStore(coreCustomer.OutletStore[i].ID);
                        tmpOutletStore.Address = new SP.Core.Domain.Address();  // Careful - Clone will have assigned Adress to null here 
                        // and cause potential crash so lets nsure Address is assigned
                        // to something ... 
                        SP.Core.Domain.OutletStore newOutletStore = ObjectExtension.Clone<SP.Core.Domain.OutletStore>(tmpOutletStore);
                        tmpOutletStore.AddressID = coreAddress.ID; // Have also to stuff AddressID back in
                        // Perform update
                        coreCustomer.OutletStore[i] = mgr.UpdateOutletStore(tmpOutletStore, newOutletStore);
                    }
                }
                #endregion

                #region Recreate return object with updated foreign keys
                if (coreCustomer.OutletStore != null)
                {
                    customer = ObjectExtension.CloneProperties<SP.Core.Domain.Customer, SPWCFServer.Customer>(coreCustomer);
                    customer.OutletStore = new List<OutletStore>();
                    for (int i = 0; i < coreCustomer.OutletStore.Count; i++)
                    {
                        customer.OutletStore.Add(ObjectExtension.CloneProperties<SP.Core.Domain.OutletStore, SPWCFServer.OutletStore>(coreCustomer.OutletStore[i]));
                        customer.OutletStore[i].Address = (ObjectExtension.CloneProperties<SP.Core.Domain.Address, SPWCFServer.Address>(coreCustomer.OutletStore[i].Address));
                        customer.OutletStore.Add(ObjectExtension.CloneProperties<SP.Core.Domain.OutletStore, SPWCFServer.OutletStore>(coreCustomer.OutletStore[i]));
                    }
                }
                #endregion

                return customer;
            }
            catch (Exception ex)
            {
                // Log full Exception to be done ...
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public Customer UpdateCustomer(Customer newCustomer, Customer origCustomer)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();

                newCustomer.OutletStore = null;
                origCustomer.OutletStore = null;

                return ObjectExtension.CloneProperties<SP.Core.Domain.Customer, SPWCFServer.Customer>
                    (mgr.UpdateCustomer(ObjectExtension.CloneProperties<SPWCFServer.Customer, SP.Core.Domain.Customer>(newCustomer),
                        ObjectExtension.CloneProperties<SPWCFServer.Customer, SP.Core.Domain.Customer>(origCustomer)));
            }
            catch (Exception ex)
            {
                // Log full Exception to be done ...
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public bool ExemptCodeExists()
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();
                return mgr.ExemptCodeExists();
            }
            catch (Exception ex)
            {
                // Log full Exception to be done ...
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        #endregion

        #region IFoundationService Members

        public FoundationFacility SaveFoundationFacility(FoundationFacility foundationFacility)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();

                SP.Core.Domain.FoundationFacility coreFoundationFacility = ObjectExtension.CloneProperties<SPWCFServer.FoundationFacility, SP.Core.Domain.FoundationFacility>(foundationFacility);
                SP.Core.Domain.Address coreAddress = ObjectExtension.CloneProperties<SPWCFServer.Address, SP.Core.Domain.Address>(foundationFacility.Address);

                // Wire up inner references, not handled by Clone Properties
                coreFoundationFacility.Address = coreAddress;
                coreFoundationFacility.AddressID = coreAddress.ID;
                coreAddress.FoundationFacility = coreFoundationFacility;

                coreFoundationFacility = mgr.SaveFoundationFacility(coreFoundationFacility);

                foundationFacility = ObjectExtension.CloneProperties<SP.Core.Domain.FoundationFacility, SPWCFServer.FoundationFacility>(coreFoundationFacility);
                foundationFacility.Address = ObjectExtension.CloneProperties<SP.Core.Domain.Address, SPWCFServer.Address>(coreFoundationFacility.Address);

                foundationFacility.AddressID = coreFoundationFacility.AddressID;
                foundationFacility.Address.FoundationFacility = foundationFacility;

                return foundationFacility;
            }
            catch (SqlException)
            {
                throw new FaultException("SPWCF Service error : " + "Cannot delete description. It is likely that the description has outstanding Accounts still linked to it");
            }
            catch (Exception ex)
            {
                // Log full Exception to be done ...
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public bool FoundationFacilityExists()
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();
                return mgr.FoundationFacilityExists();
            }
            catch (SqlException)
            {
                throw new FaultException("SPWCF Service error : " + "Cannot delete description. It is likely that the description has outstanding Accounts still linked to it");
            }
            catch (Exception ex)
            {
                // Log full Exception to be done ...
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public FoundationFacility GetFoundationFacility()
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();
                SP.Core.Domain.FoundationFacility corefacility = mgr.GetFoundationFacility();

                FoundationFacility facility = ObjectExtension.CloneProperties<SP.Core.Domain.FoundationFacility, SPWCFServer.FoundationFacility>(corefacility);
                facility.Address =
                    ObjectExtension.CloneProperties<SP.Core.Domain.Address, SPWCFServer.Address>(corefacility.Address);
                facility.Address.FoundationFacility = facility;
                return facility;

            }
            catch (SqlException)
            {
                throw new FaultException("SPWCF Service error : " + "Cannot delete description. It is likely that the description has outstanding Accounts still linked to it");
            }
            catch (Exception ex)
            {
                // Log full Exception to be done ...
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public FoundationFacility UpdateFoundationFacility(FoundationFacility newFoundationFacility, FoundationFacility origFoundationFacility)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();

                SP.Core.Domain.FoundationFacility coreNewFoundationFacility = ObjectExtension.CloneProperties<SPWCFServer.FoundationFacility, SP.Core.Domain.FoundationFacility>(newFoundationFacility);
                SP.Core.Domain.Address coreNewAddress = ObjectExtension.CloneProperties<SPWCFServer.Address, SP.Core.Domain.Address>(newFoundationFacility.Address);
                coreNewFoundationFacility.Address = coreNewAddress;
                coreNewFoundationFacility.Address.FoundationFacility = coreNewFoundationFacility;


                SP.Core.Domain.FoundationFacility coreOrigFoundationFacility = ObjectExtension.CloneProperties<SPWCFServer.FoundationFacility, SP.Core.Domain.FoundationFacility>(origFoundationFacility);
                SP.Core.Domain.Address coreOrigAddress = ObjectExtension.CloneProperties<SPWCFServer.Address, SP.Core.Domain.Address>(origFoundationFacility.Address);
                coreOrigFoundationFacility.Address = coreOrigAddress;
                coreOrigFoundationFacility.Address.FoundationFacility = coreOrigFoundationFacility;

                coreNewFoundationFacility = mgr.UpdateFoundationFacility(coreNewFoundationFacility, coreOrigFoundationFacility);

                newFoundationFacility = ObjectExtension.CloneProperties<SP.Core.Domain.FoundationFacility, SPWCFServer.FoundationFacility>(coreNewFoundationFacility);

                return newFoundationFacility;

                //return ObjectExtension.CloneProperties<SP.Core.Domain.Terms, SPWCFServer.Terms>
                //    (mgr.UpdateTerm(ObjectExtension.CloneProperties<SPWCFServer.Terms, SP.Core.Domain.Terms>(newTerm),
                //        ObjectExtension.CloneProperties<SPWCFServer.Terms, SP.Core.Domain.Terms>(origTerm)));
            }
            catch (Exception ex)
            {
                // Log full Exception to be done ...
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }
        #endregion

        #region OrderCreditNote

        public bool OrderCreditNoteExistsByOrderId(int orderId)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();
                return mgr.OrderCreditNoteExistsByOrderId(orderId);
            }
            catch (Exception ex)
            {
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public List<OrderCreditNote> GetOrderCreditNotesByOrderId(int orderId)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();
                List<SP.Core.Domain.OrderCreditNote> orderCreditNoteList = mgr.GetOrderCreditNotesByOrderId(orderId);
                return orderCreditNoteList.CloneList<SP.Core.Domain.OrderCreditNote, SPWCFServer.OrderCreditNote>();
            }
            catch (Exception ex)
            {
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public InvoiceCreditNoteDetails GetOrderHeaderInvoiceCreditDetails(int orderNo)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();
                SP.Core.Domain.InvoiceCreditNoteDetails invoiceDetails = mgr.GetOrderHeaderInvoiceCreditDetails(orderNo);
                return ObjectExtension.CloneProperties<SP.Core.Domain.InvoiceCreditNoteDetails, SPWCFServer.InvoiceCreditNoteDetails>(invoiceDetails);
            }
            catch (Exception ex)
            {
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public List<CreditNoteDetails> SearchOrderCreditNotes(string orderNo, string invoiceNo, string customerName, DateTime dateFrom, DateTime dateTo)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();
                var orderCreditNoteList = mgr.SearchOrderCreditNotes(orderNo, invoiceNo, customerName, dateFrom, dateTo);
                return orderCreditNoteList.CloneList<SP.Core.Domain.CreditNoteDetails, SPWCFServer.CreditNoteDetails>();
            }
            catch (Exception ex)
            {
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public List<OrderLine> AvailableOrderLinesForCreditNote(int orderId)
        {
            try
            {
                var mgr = new FoundationFacilitiesManager();
                List<SP.Core.Domain.OrderLine> orderCreditNoteList = mgr.AvailableOrderLinesForCreditNote(orderId);
                return ObjectExtension.CloneList<SP.Core.Domain.OrderLine, SPWCFServer.OrderLine>(orderCreditNoteList);
            }
            catch (Exception ex)
            {
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public void DeleteOrderCreditNote(OrderCreditNote orderCreditNote)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();
                mgr.DeleteOrderCreditNote(ObjectExtension.CloneProperties<SPWCFServer.OrderCreditNote, SP.Core.Domain.OrderCreditNote>(orderCreditNote));
            }
            catch (SqlException)
            {
                throw new FaultException("SPWCF Service error : " + "Cannot delete, it is likely that there are dependent items still linked to it");
            }
            catch (Exception ex)
            {
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public List<OrderCreditNote> GetAllOrderCreditNotes()
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();
                List<SP.Core.Domain.OrderCreditNote> orderCreditNoteList = mgr.GetAllOrderCreditNotes();
                return ObjectExtension.CloneList<SP.Core.Domain.OrderCreditNote, SPWCFServer.OrderCreditNote>(orderCreditNoteList);
            }
            catch (Exception ex)
            {
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public OrderCreditNote GetOrderCreditNote(int id)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();
                SP.Core.Domain.OrderCreditNote orderCreditNote = mgr.GetOrderCreditNote(id);
                return ObjectExtension.CloneProperties<SP.Core.Domain.OrderCreditNote, SPWCFServer.OrderCreditNote>(orderCreditNote);
            }
            catch (Exception ex)
            {
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public OrderCreditNote SaveOrderCreditNote(OrderCreditNote orderCreditNote)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();
                SP.Core.Domain.OrderCreditNote coreOrderCreditNote =
                   ObjectExtension.CloneProperties<SPWCFServer.OrderCreditNote, SP.Core.Domain.OrderCreditNote>(orderCreditNote);
                coreOrderCreditNote = mgr.SaveOrderCreditNote(coreOrderCreditNote);
                return ObjectExtension.CloneProperties<SP.Core.Domain.OrderCreditNote, SPWCFServer.OrderCreditNote>(coreOrderCreditNote);
            }
            catch (Exception ex)
            {
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public OrderCreditNote UpdateOrderCreditNote(OrderCreditNote newOrderCreditNote, OrderCreditNote origOrderCreditNote)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();

                return ObjectExtension.CloneProperties<SP.Core.Domain.OrderCreditNote, SPWCFServer.OrderCreditNote>
                   (mgr.UpdateOrderCreditNote(ObjectExtension.CloneProperties<SPWCFServer.OrderCreditNote, SP.Core.Domain.OrderCreditNote>(newOrderCreditNote),
                      ObjectExtension.CloneProperties<SPWCFServer.OrderCreditNote, SP.Core.Domain.OrderCreditNote>(origOrderCreditNote)));
            }
            catch (Exception ex)
            {
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        #endregion

        #region OrderCreditNoteLine

        public List<OrderCreditNoteLine> GetOrderCreditNoteLinesByCreditNoteId(int creditNoteId)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();
                List<SP.Core.Domain.OrderCreditNoteLine> orderCreditNoteLineList = mgr.GetOrderCreditNoteLinesByCreditNoteId(creditNoteId);
                return ObjectExtension.CloneList<SP.Core.Domain.OrderCreditNoteLine, SPWCFServer.OrderCreditNoteLine>(orderCreditNoteLineList);
            }
            catch (Exception ex)
            {
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public int GetAvailableNoOfUnitsOnOrderLine(int orderLineId)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();
                return mgr.GetAvailableNoOfUnitsOnOrderLine(orderLineId);
            }
            catch (SqlException)
            {
                throw new FaultException("SPWCF Service error : " + "Cannot delete, it is likely that there are dependent items still linked to it");
            }
            catch (Exception ex)
            {
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public bool CheckIfOrderLineAlreadyExistsForCreditNotes(int orderLineId)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();
                return mgr.CheckIfOrderLineAlreadyExistsForCreditNotes(orderLineId);
            }
            catch (SqlException)
            {
                throw new FaultException("SPWCF Service error : " + "Cannot delete, it is likely that there are dependent items still linked to it");
            }
            catch (Exception ex)
            {
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public OrderCreditNoteLine GetCreditNoteLineByOrderIdAndOrderLineId(int creditNoteid, int orderLineId)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();
                return ObjectExtension.CloneProperties<SP.Core.Domain.OrderCreditNoteLine, SPWCFServer.OrderCreditNoteLine>(mgr.GetCreditNoteLineByOrderIdAndOrderLineId(creditNoteid, orderLineId));
            }
            catch (SqlException)
            {
                throw new FaultException("SPWCF Service error : " + "Cannot delete, it is likely that there are dependent items still linked to it");
            }
            catch (Exception ex)
            {
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public bool CheckIfCreditNoteLineExists(int creditNoteid, int orderLineId)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();
                return mgr.CheckIfCreditNoteLineExists(creditNoteid, orderLineId);
            }
            catch (SqlException)
            {
                throw new FaultException("SPWCF Service error : " + "Cannot delete, it is likely that there are dependent items still linked to it");
            }
            catch (Exception ex)
            {
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public void DeleteOrderCreditNoteLine(OrderCreditNoteLine orderCreditNoteLine)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();
                mgr.DeleteOrderCreditNoteLine(ObjectExtension.CloneProperties<SPWCFServer.OrderCreditNoteLine, SP.Core.Domain.OrderCreditNoteLine>(orderCreditNoteLine));
            }
            catch (SqlException)
            {
                throw new FaultException("SPWCF Service error : " + "Cannot delete, it is likely that there are dependent items still linked to it");
            }
            catch (Exception ex)
            {
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public List<OrderCreditNoteLine> GetAllOrderCreditNoteLines()
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();
                List<SP.Core.Domain.OrderCreditNoteLine> orderCreditNoteLineList = mgr.GetAllOrderCreditNoteLines();
                return ObjectExtension.CloneList<SP.Core.Domain.OrderCreditNoteLine, SPWCFServer.OrderCreditNoteLine>(orderCreditNoteLineList);
            }
            catch (Exception ex)
            {
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public OrderCreditNoteLine GetOrderCreditNoteLine(int id)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();
                SP.Core.Domain.OrderCreditNoteLine orderCreditNoteLine = mgr.GetOrderCreditNoteLine(id);
                return ObjectExtension.CloneProperties<SP.Core.Domain.OrderCreditNoteLine, SPWCFServer.OrderCreditNoteLine>(orderCreditNoteLine);
            }
            catch (Exception ex)
            {
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public OrderCreditNoteLine SaveOrderCreditNoteLine(OrderCreditNoteLine orderCreditNoteLine)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();
                SP.Core.Domain.OrderCreditNoteLine coreOrderCreditNoteLine =
                   ObjectExtension.CloneProperties<SPWCFServer.OrderCreditNoteLine, SP.Core.Domain.OrderCreditNoteLine>(orderCreditNoteLine);
                coreOrderCreditNoteLine = mgr.SaveOrderCreditNoteLine(coreOrderCreditNoteLine);
                return ObjectExtension.CloneProperties<SP.Core.Domain.OrderCreditNoteLine, SPWCFServer.OrderCreditNoteLine>(coreOrderCreditNoteLine);
            }
            catch (Exception ex)
            {
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public OrderCreditNoteLine UpdateOrderCreditNoteLine(OrderCreditNoteLine newOrderCreditNoteLine, OrderCreditNoteLine origOrderCreditNoteLine)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();

                return ObjectExtension.CloneProperties<SP.Core.Domain.OrderCreditNoteLine, SPWCFServer.OrderCreditNoteLine>
                   (mgr.UpdateOrderCreditNoteLine(ObjectExtension.CloneProperties<SPWCFServer.OrderCreditNoteLine, SP.Core.Domain.OrderCreditNoteLine>(newOrderCreditNoteLine),
                      ObjectExtension.CloneProperties<SPWCFServer.OrderCreditNoteLine, SP.Core.Domain.OrderCreditNoteLine>(origOrderCreditNoteLine)));
            }
            catch (Exception ex)
            {
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        #endregion

        #region OrderHeader

        public List<InvoiceWithStatus> GetInvoicesWithStatus(string orderNo, string invoiceNo, string customerName, DateTime dateFrom, DateTime dateTo, short orderStatus)
        {

            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();

                List<SP.Core.Domain.InvoiceWithStatus> invoicesWithStatus = mgr.GetInvoicesWithStatus(orderNo, invoiceNo, customerName, dateFrom, dateTo, orderStatus);
                return ObjectExtension.CloneList<SP.Core.Domain.InvoiceWithStatus, SPWCFServer.InvoiceWithStatus>(invoicesWithStatus);

            }
            catch (Exception ex)
            {
                // Log full Exception to be done ...
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public void DeleteOrderHeader(OrderHeader orderHeader)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();

                Action<SP.Core.Domain.OrderLine> a = new Action<SP.Core.Domain.OrderLine>(q => mgr.DeleteOrderLine(q));
                mgr.GetOrderLinesByOrderID(orderHeader.ID).ForEach(a);

                if (mgr.OrderNoteStatusByOrderIDExists(orderHeader.ID))
                {
                    SP.Core.Domain.OrderNotesStatus orderNoteStatus = mgr.GetOrderNoteStatusByOrderId(orderHeader.ID);
                    mgr.DeleteOrderNotesStatus(orderNoteStatus);
                }

                mgr.DeleteOrderHeader(ObjectExtension.CloneProperties<SPWCFServer.OrderHeader, SP.Core.Domain.OrderHeader>(orderHeader));
            }
            catch (SqlException)
            {
                throw new FaultException("SPWCF Service error : " + "Cannot delete Order Header is likely that the Order has outstanding items still linked to it");
            }
            catch (Exception ex)
            {
                // Log full Exception to be done ...
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public OrderHeader GetOrderHeader(int id)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();

                SP.Core.Domain.OrderHeader orderHeader = mgr.GetOrderHeader(id);
                OrderHeader order = ObjectExtension.CloneProperties<SP.Core.Domain.OrderHeader, SPWCFServer.OrderHeader>(orderHeader);
                // order.VatCode = ObjectExtension.CloneProperties<SP.Core.Domain.VatCode, SPWCFServer.VatCode>(orderHeader.VatCode);
                return order;

            }
            catch (Exception ex)
            {
                // Log full Exception to be done ...
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public OrderHeader GetOrderHeaderByIdWithVatCode(int id)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();

                SP.Core.Domain.OrderHeader orderHeader = mgr.GetOrderHeaderWithVatCode(id);
                OrderHeader order = ObjectExtension.CloneProperties<SP.Core.Domain.OrderHeader, SPWCFServer.OrderHeader>(orderHeader);
                order.VatCode = ObjectExtension.CloneProperties<SP.Core.Domain.VatCode, SPWCFServer.VatCode>(orderHeader.VatCode);
                return order;

            }
            catch (Exception ex)
            {
                // Log full Exception to be done ...
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public bool InvoiceNoExists(string invoiceNo)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();
                return mgr.InvoiceNoExists(invoiceNo);
            }
            catch (Exception ex)
            {
                // Log full Exception to be done ...
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public OrderHeader GetOrderHeaderByOrderNo(string orderNo)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();

                SP.Core.Domain.OrderHeader orderHeader = mgr.GetOrderHeaderByOrderNo(orderNo);
                return ObjectExtension.CloneProperties<SP.Core.Domain.OrderHeader, SPWCFServer.OrderHeader>(orderHeader);

            }
            catch (Exception ex)
            {
                // Log full Exception to be done ...
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public List<OrderHeader> GetAllOrderHeaders()
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();

                List<SP.Core.Domain.OrderHeader> orderHeader = mgr.GetAllOrderHeaders();
                return ObjectExtension.CloneList<SP.Core.Domain.OrderHeader, SPWCFServer.OrderHeader>(orderHeader);

            }
            catch (Exception ex)
            {
                // Log full Exception to be done ...
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public List<OrderHeader> GetOrderHeaderForSearch(string orderNo, string invoiceNo, string customerName, DateTime dateFrom, DateTime dateTo, short orderStatus)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();

                List<SP.Core.Domain.OrderHeader> orderHeaders =
                    mgr.GetOrderHeaderForSearch(orderNo, invoiceNo, customerName, dateFrom, dateTo, orderStatus).OrderByDescending(o => o.OrderDate).ThenByDescending(o => o.AlphaID).ToList<SP.Core.Domain.OrderHeader>();

                List<OrderHeader> returnOrders = new List<OrderHeader>();
                foreach (SP.Core.Domain.OrderHeader orderHeader in orderHeaders)
                {
                    OrderHeader tempOrderHeader = ObjectExtension.CloneProperties<SP.Core.Domain.OrderHeader, OrderHeader>(orderHeader);
                    tempOrderHeader.VatCode = ObjectExtension.CloneProperties<SP.Core.Domain.VatCode, VatCode>(orderHeader.VatCode);
                    returnOrders.Add(tempOrderHeader);
                }
                return returnOrders;
            }
            catch (Exception ex)
            {
                // Log full Exception to be done ...
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public List<OrderHeader> GetOrderHeaderForSearchWithPrintedOrderStatuses(string orderNo, string invoiceNo, string customerName, DateTime dateFrom, DateTime dateTo, short actualOrderStatus, short printedOrderStatus)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();

                List<SP.Core.Domain.OrderHeader> orderHeader = mgr.GetOrderHeaderForSearchWithPrintedOrderStatuses(orderNo, invoiceNo, customerName, dateFrom, dateTo, actualOrderStatus, printedOrderStatus).OrderByDescending(o => o.OrderDate).ThenByDescending(o => o.AlphaID).ToList<SP.Core.Domain.OrderHeader>();
                return ObjectExtension.CloneList<SP.Core.Domain.OrderHeader, SPWCFServer.OrderHeader>(orderHeader);
            }
            catch (Exception ex)
            {
                // Log full Exception to be done ...
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public OrderHeader SaveOrderHeader(OrderHeader orderHeader)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();

                SP.Core.Domain.OrderHeader coreOrderHeader =
                    ObjectExtension.CloneProperties<SPWCFServer.OrderHeader, SP.Core.Domain.OrderHeader>(orderHeader);

                coreOrderHeader = mgr.SaveOrderHeader(coreOrderHeader);

                return ObjectExtension.CloneProperties<SP.Core.Domain.OrderHeader, SPWCFServer.OrderHeader>(coreOrderHeader);
            }
            catch (Exception ex)
            {
                // Log full Exception to be done ...
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public OrderHeader UpdateOrderHeader(OrderHeader newOrderHeader, OrderHeader origOrderHeader)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();

                return ObjectExtension.CloneProperties<SP.Core.Domain.OrderHeader, SPWCFServer.OrderHeader>
                    (mgr.UpdateOrderHeader(ObjectExtension.CloneProperties<SPWCFServer.OrderHeader, SP.Core.Domain.OrderHeader>(newOrderHeader),
                        ObjectExtension.CloneProperties<SPWCFServer.OrderHeader, SP.Core.Domain.OrderHeader>(origOrderHeader)));
            }
            catch (Exception ex)
            {
                // Log full Exception to be done ...
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public OrderHeader CreateInvoice(OrderHeader newOrderHeader, OrderHeader origOrderHeader)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();

                return ObjectExtension.CloneProperties<SP.Core.Domain.OrderHeader, SPWCFServer.OrderHeader>
                    (mgr.CreateInvoice(ObjectExtension.CloneProperties<SPWCFServer.OrderHeader, SP.Core.Domain.OrderHeader>(newOrderHeader),
                        ObjectExtension.CloneProperties<SPWCFServer.OrderHeader, SP.Core.Domain.OrderHeader>(origOrderHeader)));
            }
            catch (Exception ex)
            {
                // Log full Exception to be done ...
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public OrderHeader CreateInvoiceProforma(OrderHeader newOrderHeader, OrderHeader origOrderHeader)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();

                return ObjectExtension.CloneProperties<SP.Core.Domain.OrderHeader, SPWCFServer.OrderHeader>
                    (mgr.CreateInvoiceProforma(ObjectExtension.CloneProperties<SPWCFServer.OrderHeader, SP.Core.Domain.OrderHeader>(newOrderHeader),
                        ObjectExtension.CloneProperties<SPWCFServer.OrderHeader, SP.Core.Domain.OrderHeader>(origOrderHeader)));
            }
            catch (Exception ex)
            {
                // Log full Exception to be done ...
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public OrderHeader CreateDeliveryNote(OrderHeader newOrderHeader, OrderHeader origOrderHeader)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();

                return ObjectExtension.CloneProperties<SP.Core.Domain.OrderHeader, SPWCFServer.OrderHeader>
                    (mgr.CreateDeliveryNote(ObjectExtension.CloneProperties<SPWCFServer.OrderHeader, SP.Core.Domain.OrderHeader>(newOrderHeader),
                        ObjectExtension.CloneProperties<SPWCFServer.OrderHeader, SP.Core.Domain.OrderHeader>(origOrderHeader)));
            }
            catch (Exception ex)
            {
                // Log full Exception to be done ...
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public void VoidOrder(int orderID, string reasonForVoiding)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();
                mgr.VoidOrder(orderID, reasonForVoiding);
            }
            catch (Exception ex)
            {
                // Log full Exception to be done ...
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        #endregion

        #region OrderLine

        public void DeleteOrderLine(OrderLine orderLine)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();
                mgr.DeleteOrderLine(ObjectExtension.CloneProperties<SPWCFServer.OrderLine, SP.Core.Domain.OrderLine>(orderLine));
            }
            catch (SqlException)
            {
                throw new FaultException("SPWCF Service error : " + "Cannot delete Order Line is likely that the Order has outstanding items still linked to it");
            }
            catch (Exception ex)
            {
                // Log full Exception to be done ...
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public OrderLine GetOrderLine(int id)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();

                SP.Core.Domain.OrderLine orderLine = mgr.GetOrderLine(id);
                return ObjectExtension.CloneProperties<SP.Core.Domain.OrderLine, SPWCFServer.OrderLine>(orderLine);

            }
            catch (Exception ex)
            {
                // Log full Exception to be done ...
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public List<OrderLine> GetOrderLinesByOrderID(int id)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();

                List<SP.Core.Domain.OrderLine> orderLines = mgr.GetOrderLinesByOrderID(id);
                return ObjectExtension.CloneList<SP.Core.Domain.OrderLine, SPWCFServer.OrderLine>(orderLines);

            }
            catch (Exception ex)
            {
                // Log full Exception to be done ...
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public OrderLine SaveOrderLine(OrderLine orderLine)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();

                SP.Core.Domain.OrderLine coreOrderLine =
                    ObjectExtension.CloneProperties<SPWCFServer.OrderLine, SP.Core.Domain.OrderLine>(orderLine);

                //SP.Core.Domain.OrderHeader coreOrderHeader = mgr.GetOrderHeader(orderLine.OrderID);
                //coreOrderLine.OrderHeader = coreOrderHeader;

                coreOrderLine = mgr.SaveOrderLine(coreOrderLine);

                return ObjectExtension.CloneProperties<SP.Core.Domain.OrderLine, SPWCFServer.OrderLine>(coreOrderLine);
            }
            catch (Exception ex)
            {
                // Log full Exception to be done ...
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public OrderLine UpdateOrderLine(OrderLine newOrderLine, OrderLine origOrderLine)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();

                return ObjectExtension.CloneProperties<SP.Core.Domain.OrderLine, SPWCFServer.OrderLine>
                    (mgr.UpdateOrderLine(ObjectExtension.CloneProperties<SPWCFServer.OrderLine, SP.Core.Domain.OrderLine>(newOrderLine),
                        ObjectExtension.CloneProperties<SPWCFServer.OrderLine, SP.Core.Domain.OrderLine>(origOrderLine)));
            }
            catch (Exception ex)
            {
                // Log full Exception to be done ...
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }
        #endregion

        #region OrderNotesStatus

        public void DeleteOrderNotesStatus(OrderNotesStatus orderNotesStatus)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();
                mgr.DeleteOrderNotesStatus(ObjectExtension.CloneProperties<SPWCFServer.OrderNotesStatus, SP.Core.Domain.OrderNotesStatus>(orderNotesStatus));
            }
            catch (SqlException)
            {
                throw new FaultException("SPWCF Service error : " + "Cannot delete, it is likely that there are dependent items still linked to it");
            }
            catch (Exception ex)
            {
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public void UpdatePaymentCompleted(int orderID, bool invoicePaymentComplete)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();
                mgr.UpdatePaymentCompleted(orderID, invoicePaymentComplete);
            }
            catch (SqlException)
            {
                throw new FaultException("SPWCF Service error : " + "Cannot update payment completed");
            }
            catch (Exception ex)
            {
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public List<OrderNotesStatus> GetAllOrderNotesStatuss()
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();
                List<SP.Core.Domain.OrderNotesStatus> orderNotesStatusList = mgr.GetAllOrderNotesStatuss();
                return ObjectExtension.CloneList<SP.Core.Domain.OrderNotesStatus, SPWCFServer.OrderNotesStatus>(orderNotesStatusList).ToList<OrderNotesStatus>();
            }
            catch (Exception ex)
            {
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public OrderNotesStatus GetOrderNotesStatus(int id)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();
                SP.Core.Domain.OrderNotesStatus orderNotesStatus = mgr.GetOrderNotesStatus(id);
                return ObjectExtension.CloneProperties<SP.Core.Domain.OrderNotesStatus, SPWCFServer.OrderNotesStatus>(orderNotesStatus);
            }
            catch (Exception ex)
            {
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public OrderNotesStatus GetOrderNoteStatusByOrderId(int id)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();
                SP.Core.Domain.OrderNotesStatus orderNotesStatus = mgr.GetOrderNoteStatusByOrderId(id);
                return ObjectExtension.CloneProperties<SP.Core.Domain.OrderNotesStatus, SPWCFServer.OrderNotesStatus>(orderNotesStatus);
            }
            catch (Exception ex)
            {
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public bool OrderNoteStatusByOrderIDExists(int orderID)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();
                return mgr.OrderNoteStatusByOrderIDExists(orderID);
            }
            catch (Exception ex)
            {
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public OrderNotesStatus SaveOrderNotesStatus(OrderNotesStatus orderNotesStatus)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();
                SP.Core.Domain.OrderNotesStatus coreOrderNotesStatus =
                   ObjectExtension.CloneProperties<SPWCFServer.OrderNotesStatus, SP.Core.Domain.OrderNotesStatus>(orderNotesStatus);
                coreOrderNotesStatus = mgr.SaveOrderNotesStatus(coreOrderNotesStatus);
                return ObjectExtension.CloneProperties<SP.Core.Domain.OrderNotesStatus, SPWCFServer.OrderNotesStatus>(coreOrderNotesStatus);
            }
            catch (Exception ex)
            {
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public OrderNotesStatus UpdateOrderNotesStatus(OrderNotesStatus newOrderNotesStatus, OrderNotesStatus origOrderNotesStatus)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();

                return ObjectExtension.CloneProperties<SP.Core.Domain.OrderNotesStatus, SPWCFServer.OrderNotesStatus>
                   (mgr.UpdateOrderNotesStatus(ObjectExtension.CloneProperties<SPWCFServer.OrderNotesStatus, SP.Core.Domain.OrderNotesStatus>(newOrderNotesStatus),
                      ObjectExtension.CloneProperties<SPWCFServer.OrderNotesStatus, SP.Core.Domain.OrderNotesStatus>(origOrderNotesStatus)));
            }
            catch (Exception ex)
            {
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public List<OrderHeader> InvoicesByDateAndVan(DateTime deliveryDate, int vanId)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();
                List<SP.Core.Domain.OrderHeader> orderNotesStatusList = mgr.InvoicesByDateAndVan(deliveryDate, vanId);
                return ObjectExtension.CloneList<SP.Core.Domain.OrderHeader, SPWCFServer.OrderHeader>(orderNotesStatusList).ToList<OrderHeader>();
            }
            catch (Exception ex)
            {
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public List<VanInvoiceCount> GetVanInvoiceCount(DateTime deliveryDate)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();
                List<SP.Core.Domain.VanInvoiceCount> vanInvoiceCountList = mgr.GetVanInvoiceCount(deliveryDate);
                return ObjectExtension.CloneList<SP.Core.Domain.VanInvoiceCount, SPWCFServer.VanInvoiceCount>(vanInvoiceCountList).ToList<VanInvoiceCount>();
            }
            catch (Exception ex)
            {
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public void UpdateVanForInvoice(int orderID, int vanID)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();
                mgr.UpdateVanForInvoice(orderID, vanID);
            }
            catch (Exception ex)
            {
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        #endregion

        #region IOutlet Members

        public OutletStore GetOutletStoreByID(int id)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();
                SP.Core.Domain.OutletStore orderNotesStatus = mgr.GetOutletStore(id);
                return ObjectExtension.CloneProperties<SP.Core.Domain.OutletStore, SPWCFServer.OutletStore>(orderNotesStatus);
            }
            catch (Exception ex)
            {
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public void DeleteOutletStore(OutletStore store)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();
                mgr.DeleteAddress(ObjectExtension.CloneProperties<SPWCFServer.Address, SP.Core.Domain.Address>(store.Address));
                store.Address = null;
                mgr.DeleteOutletStore(ObjectExtension.CloneProperties<SPWCFServer.OutletStore, SP.Core.Domain.OutletStore>(store));

            }
            catch (SqlException)
            {
                throw new FaultException("SPWCF Service error : " + "Cannot delete description. It is likely that the description has outstanding Accounts still linked to it");
            }
            catch (Exception ex)
            {
                // Log full Exception to be done ...
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public OutletStore SaveOutletStore(OutletStore store)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();

                SP.Core.Domain.OutletStore coreOutletStore =
                    ObjectExtension.CloneProperties<SPWCFServer.OutletStore, SP.Core.Domain.OutletStore>(store);

                SP.Core.Domain.Address coreAddress =
                    ObjectExtension.CloneProperties<SPWCFServer.Address, SP.Core.Domain.Address>(store.Address);

                coreAddress = mgr.SaveAddress(coreAddress);
                coreOutletStore.AddressID = coreAddress.ID;
                coreOutletStore = mgr.SaveOutletStore(coreOutletStore);

                store = ObjectExtension.CloneProperties<SP.Core.Domain.OutletStore, SPWCFServer.OutletStore>(coreOutletStore);
                store.Address = ObjectExtension.CloneProperties<SP.Core.Domain.Address, SPWCFServer.Address>(coreAddress);
                return store;
            }
            catch (Exception ex)
            {
                // Log full Exception to be done ...
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public OutletStore UpdateOutletStore(OutletStore newStore, OutletStore origStore)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();

                SP.Core.Domain.OutletStore coreOutletStore = ObjectExtension.CloneProperties<SPWCFServer.OutletStore, SP.Core.Domain.OutletStore>(newStore);
                SP.Core.Domain.OutletStore origCoreOutletStore = ObjectExtension.CloneProperties<SPWCFServer.OutletStore, SP.Core.Domain.OutletStore>(origStore);

                SP.Core.Domain.Address coreAddress = ObjectExtension.CloneProperties<SPWCFServer.Address, SP.Core.Domain.Address>(newStore.Address);
                SP.Core.Domain.Address origCoreAddress = mgr.GetAddress(coreAddress.ID);
                coreAddress = mgr.UpdateAddress(coreAddress, origCoreAddress);

                // coreOutletStore.Address = null;

                coreOutletStore = mgr.UpdateOutletStore(coreOutletStore, origCoreOutletStore);
                coreOutletStore.Address = coreAddress;

                newStore = ObjectExtension.CloneProperties<SP.Core.Domain.OutletStore, SPWCFServer.OutletStore>(coreOutletStore);
                newStore.Address = ObjectExtension.CloneProperties<SP.Core.Domain.Address, SPWCFServer.Address>(coreOutletStore.Address);

                return newStore;

            }
            catch (Exception ex)
            {
                // Log full Exception to be done ...
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        #endregion

        #region IPriceListHeader

        public void DeletePriceListHeader(int id)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();
                List<SP.Core.Domain.PriceListItem> priceListItems = mgr.GetPriceListItemByPriceListHeader(id);
                foreach (SP.Core.Domain.PriceListItem pi in priceListItems)
                {
                    mgr.DeletePriceListItemByID(pi.ID);
                }

                SP.Core.Domain.PriceListHeader ph = mgr.GetPriceListHeaderByID(id);
                mgr.DeletePriceList(ph);
            }
            catch (Exception ex)
            {
                // Log full Exception to be done ...
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public List<PriceListHeader> GetAllPriceListHeaders()
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();
                List<SP.Core.Domain.PriceListHeader> priceListHeader = mgr.GetAllPriceListHeaders();

                return ObjectExtension.CloneList<SP.Core.Domain.PriceListHeader, SPWCFServer.PriceListHeader>(priceListHeader);
            }
            catch (Exception ex)
            {
                // Log full Exception to be done ...
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public PriceListHeader GetPriceListHeaderByID(int id)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();

                SP.Core.Domain.PriceListHeader priceListHeader = mgr.GetPriceListHeaderByID(id);
                return ObjectExtension.CloneProperties<SP.Core.Domain.PriceListHeader, SPWCFServer.PriceListHeader>(priceListHeader);

            }
            catch (Exception ex)
            {
                // Log full Exception to be done ...
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public PriceListHeader SavePriceListHeader(PriceListHeader priceListHeader)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();

                SP.Core.Domain.PriceListHeader corePriceListHeader =
                    ObjectExtension.CloneProperties<SPWCFServer.PriceListHeader, SP.Core.Domain.PriceListHeader>(priceListHeader);

                return ObjectExtension.CloneProperties<SP.Core.Domain.PriceListHeader, SPWCFServer.PriceListHeader>(mgr.SavePriceListHeader(corePriceListHeader));
            }
            catch (Exception ex)
            {
                // Log full Exception to be done ...
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public PriceListHeader UpdatePriceListHeader(PriceListHeader newPriceListHeader, PriceListHeader origPriceListHeader)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();

                return ObjectExtension.CloneProperties<SP.Core.Domain.PriceListHeader, SPWCFServer.PriceListHeader>
                    (mgr.UpdatePriceListHeader(ObjectExtension.CloneProperties<SPWCFServer.PriceListHeader, SP.Core.Domain.PriceListHeader>(newPriceListHeader),
                        ObjectExtension.CloneProperties<SPWCFServer.PriceListHeader, SP.Core.Domain.PriceListHeader>(origPriceListHeader)));
            }
            catch (Exception ex)
            {
                // Log full Exception to be done ...
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        #endregion

        #region IPriceListItem

        public void DeletePriceListItemByID(int priceListItem)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();
                mgr.DeletePriceListItemByID(priceListItem);
            }
            catch (Exception ex)
            {
                // Log full Exception to be done ...
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public void DeletePriceListItemByProductId(int priceListID, int productId)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();
                mgr.DeletePriceListItemByProductId(priceListID, productId);
            }
            catch (Exception ex)
            {
                // Log full Exception to be done ...
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public PriceListItem SavePriceListItem(PriceListItem priceListItem)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();

                SP.Core.Domain.PriceListItem corePriceListItem =
                    ObjectExtension.CloneProperties<SPWCFServer.PriceListItem, SP.Core.Domain.PriceListItem>(priceListItem);

                return ObjectExtension.CloneProperties<SP.Core.Domain.PriceListItem, SPWCFServer.PriceListItem>(mgr.SavePriceListItem(corePriceListItem));
            }
            catch (Exception ex)
            {
                // Log full Exception to be done ...
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public List<PriceListItem> GetPriceListItemByPriceListHeader(int id)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();

                List<SP.Core.Domain.PriceListItem> corePriceListItem = mgr.GetPriceListItemByPriceListHeader(id);
                List<PriceListItem> newPriceListItem = ObjectExtension.CloneList<SP.Core.Domain.PriceListItem, SPWCFServer.PriceListItem>(corePriceListItem);
                for (int i = 0; i < corePriceListItem.Count; i++)
                {
                    newPriceListItem[i].Product =
                        ObjectExtension.CloneProperties<SP.Core.Domain.Product, SPWCFServer.Product>(corePriceListItem[i].Product);
                }
                return newPriceListItem.OrderBy(q => q.Product.Description).ToList<PriceListItem>();
            }
            catch (Exception ex)
            {
                // Log full Exception to be done ...
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public PriceListItem GetPriceListItemByProductId(int priceListID, int productId)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();

                SP.Core.Domain.PriceListItem priceListItem = mgr.GetPriceListItemByProductId(priceListID, productId);
                return ObjectExtension.CloneProperties<SP.Core.Domain.PriceListItem, SPWCFServer.PriceListItem>(priceListItem);
            }
            catch (Exception ex)
            {
                // Log full Exception to be done ...
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public PriceListItem GetPriceListItemById(int id)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();

                SP.Core.Domain.PriceListItem priceListItem = mgr.GetPriceListItemById(id);
                return ObjectExtension.CloneProperties<SP.Core.Domain.PriceListItem, SPWCFServer.PriceListItem>(priceListItem);

            }
            catch (Exception ex)
            {
                // Log full Exception to be done ...
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public PriceListItem UpdatePriceListItem(PriceListItem newPriceListItem, PriceListItem origPriceListItem)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();

                return ObjectExtension.CloneProperties<SP.Core.Domain.PriceListItem, SPWCFServer.PriceListItem>
                    (mgr.UpdatePriceListItem(ObjectExtension.CloneProperties<SPWCFServer.PriceListItem, SP.Core.Domain.PriceListItem>(newPriceListItem),
                        ObjectExtension.CloneProperties<SPWCFServer.PriceListItem, SP.Core.Domain.PriceListItem>(origPriceListItem)));
            }
            catch (Exception ex)
            {
                // Log full Exception to be done ...
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        #endregion

        #region IProduct Members

        public Product SaveProduct(Product product)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();

                SP.Core.Domain.Product coreProduct =
                    ObjectExtension.CloneProperties<SPWCFServer.Product, SP.Core.Domain.Product>(product);

                coreProduct = mgr.SaveProduct(coreProduct);

                product =
                    ObjectExtension.CloneProperties<SP.Core.Domain.Product, SPWCFServer.Product>(coreProduct);

                return product;
            }
            catch (Exception ex)
            {
                // Log full Exception to be done ...
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public void DeleteProduct(Product product)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();

                SP.Core.Domain.Product p = mgr.GetProduct(product.ID);
                mgr.DeleteProduct(p);
            }
            catch (SqlException)
            {
                throw new FaultException("SPWCF Service error : " + "Cannot delete Product. It is likely that the Product has outstanding Price List Items or Orders still linked to it");
            }
            catch (Exception ex)
            {
                // Log full Exception to be done ...
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public List<Product> GetAllProducts()
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();

                List<SP.Core.Domain.Product> productList = mgr.GetAllProducts();
                return ObjectExtension.CloneList<SP.Core.Domain.Product, SPWCFServer.Product>(productList);
            }
            catch (Exception ex)
            {
                // Log full Exception to be done ...
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public Product GetProduct(int id)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();

                SP.Core.Domain.Product codeProduct = mgr.GetProduct(id);
                return ObjectExtension.CloneProperties<SP.Core.Domain.Product, SPWCFServer.Product>(codeProduct);
            }
            catch (Exception ex)
            {
                // Log full Exception to be done ...
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public Product UpdateProduct(Product newProduct, Product origProduct)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();

                return ObjectExtension.CloneProperties<SP.Core.Domain.Product, SPWCFServer.Product>
                    (mgr.UpdateProduct(ObjectExtension.CloneProperties<SPWCFServer.Product, SP.Core.Domain.Product>(newProduct),
                        ObjectExtension.CloneProperties<SPWCFServer.Product, SP.Core.Domain.Product>(origProduct)));
            }
            catch (Exception ex)
            {
                // Log full Exception to be done ...
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public Product GetProductByProductCode(string productCode)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();

                SP.Core.Domain.Product product = mgr.GetProductByProductCode(productCode);
                return ObjectExtension.CloneProperties<SP.Core.Domain.Product, SPWCFServer.Product>(product);
            }
            catch (Exception ex)
            {
                // Log full Exception to be done ...
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public bool ProductCodeExists(string productCode)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();
                return mgr.ProductCodeExists(productCode);
            }
            catch (Exception ex)
            {
                // Log full Exception to be done ...
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public List<Product> GetLikeProductCode(string productCode)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();

                List<SP.Core.Domain.Product> productList = mgr.GetLikeProductCode(productCode);
                return ObjectExtension.CloneList<SP.Core.Domain.Product, SPWCFServer.Product>(productList);
            }
            catch (Exception ex)
            {
                // Log full Exception to be done ...
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public List<Product> GetLikeProductDescription(string productDescription)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();

                List<SP.Core.Domain.Product> productList = mgr.GetLikeProductDescription(productDescription);
                return ObjectExtension.CloneList<SP.Core.Domain.Product, SPWCFServer.Product>(productList);
            }
            catch (Exception ex)
            {
                // Log full Exception to be done ...
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public List<Product> GetProductsInPriceList(int id)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();

                List<SP.Core.Domain.Product> productList = mgr.GetProductsInPriceList(id);
                return ObjectExtension.CloneList<SP.Core.Domain.Product, SPWCFServer.Product>(productList);
            }
            catch (Exception ex)
            {
                // Log full Exception to be done ...
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public List<Product> GetProductsOutOfProductList(int id)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();

                List<SP.Core.Domain.Product> productList = mgr.GetProductsOutOfProductList(id);
                return ObjectExtension.CloneList<SP.Core.Domain.Product, SPWCFServer.Product>(productList);
            }
            catch (Exception ex)
            {
                // Log full Exception to be done ...
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        #endregion

        #region IVatCode Members

        public VatCode SaveVatCode(VatCode vatCode)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();

                SP.Core.Domain.VatCode coreVatCode =
                    ObjectExtension.CloneProperties<SPWCFServer.VatCode, SP.Core.Domain.VatCode>(vatCode);

                coreVatCode = mgr.SaveVatCode(coreVatCode);

                return ObjectExtension.CloneProperties<SP.Core.Domain.VatCode, SPWCFServer.VatCode>(coreVatCode);
            }
            catch (Exception ex)
            {
                // Log full Exception to be done ...
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public VatCode UpdateVatCode(VatCode newVatCode, VatCode origVatCode)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();

                return ObjectExtension.CloneProperties<SP.Core.Domain.VatCode, SPWCFServer.VatCode>
                    (mgr.UpdateVatCode(ObjectExtension.CloneProperties<SPWCFServer.VatCode, SP.Core.Domain.VatCode>(newVatCode),
                        ObjectExtension.CloneProperties<SPWCFServer.VatCode, SP.Core.Domain.VatCode>(origVatCode)));
            }
            catch (Exception ex)
            {
                // Log full Exception to be done ...
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public List<VatCode> GetAllVatCodes()
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();
                List<SP.Core.Domain.VatCode> vatCodeList = mgr.GetAllVatCodes();

                return ObjectExtension.CloneList<SP.Core.Domain.VatCode, SPWCFServer.VatCode>(vatCodeList);
            }
            catch (Exception ex)
            {
                // Log full Exception to be done ...
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public VatCode GetVatCode(int id)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();

                SP.Core.Domain.VatCode vatCode = mgr.GetVatCode(id);
                return ObjectExtension.CloneProperties<SP.Core.Domain.VatCode, SPWCFServer.VatCode>(vatCode);

            }
            catch (Exception ex)
            {
                // Log full Exception to be done ...
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public void DeleteVatCode(VatCode cde)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();
                mgr.DeleteVatCode(ObjectExtension.CloneProperties<SPWCFServer.VatCode, SP.Core.Domain.VatCode>(cde));
            }
            catch (SqlException)
            {
                throw new FaultException("SPWCF Service error : " + "Cannot delete Vat Code is likely that the Vat Code has outstanding Products still linked to it");
            }
            catch (Exception ex)
            {
                // Log full Exception to be done ...
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public bool VatCodeExists(string vatCode)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();
                return mgr.VatCodeExists(vatCode);
            }
            catch (SqlException)
            {
                throw new FaultException("SPWCF Service error : " + "Cannot delete Vat Code. It is likely that the vatCode has outstanding Products still linked to it");
            }
            catch (Exception ex)
            {
                // Log full Exception to be done ...
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        #endregion

        #region SpecialInvoiceCreditNote

        public void DeleteSpecialInvoiceCreditNote(SpecialInvoiceCreditNote specialInvoiceCreditNote)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();
                mgr.DeleteSpecialInvoiceCreditNote(ObjectExtension.CloneProperties<SPWCFServer.SpecialInvoiceCreditNote, SP.Core.Domain.SpecialInvoiceCreditNote>(specialInvoiceCreditNote));
            }
            catch (SqlException)
            {
                throw new FaultException("SPWCF Service error : " + "Cannot delete, it is likely that there are dependent items still linked to it");
            }
            catch (Exception ex)
            {
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public List<SpecialInvoiceCreditNote> GetAllSpecialInvoiceCreditNotes()
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();
                List<SP.Core.Domain.SpecialInvoiceCreditNote> specialInvoiceCreditNoteList = mgr.GetAllSpecialInvoiceCreditNotes();
                return ObjectExtension.CloneList<SP.Core.Domain.SpecialInvoiceCreditNote, SPWCFServer.SpecialInvoiceCreditNote>(specialInvoiceCreditNoteList);
            }
            catch (Exception ex)
            {
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public SpecialInvoiceCreditNote GetSpecialInvoiceCreditNote(int id)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();
                SP.Core.Domain.SpecialInvoiceCreditNote specialInvoiceCreditNote = mgr.GetSpecialInvoiceCreditNote(id);
                return ObjectExtension.CloneProperties<SP.Core.Domain.SpecialInvoiceCreditNote, SPWCFServer.SpecialInvoiceCreditNote>(specialInvoiceCreditNote);
            }
            catch (Exception ex)
            {
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public SpecialInvoiceCreditNote SaveSpecialInvoiceCreditNote(SpecialInvoiceCreditNote specialInvoiceCreditNote)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();
                SP.Core.Domain.SpecialInvoiceCreditNote coreSpecialInvoiceCreditNote =
                   ObjectExtension.CloneProperties<SPWCFServer.SpecialInvoiceCreditNote, SP.Core.Domain.SpecialInvoiceCreditNote>(specialInvoiceCreditNote);
                coreSpecialInvoiceCreditNote = mgr.SaveSpecialInvoiceCreditNote(coreSpecialInvoiceCreditNote);
                return ObjectExtension.CloneProperties<SP.Core.Domain.SpecialInvoiceCreditNote, SPWCFServer.SpecialInvoiceCreditNote>(coreSpecialInvoiceCreditNote);
            }
            catch (Exception ex)
            {
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public SpecialInvoiceCreditNote UpdateSpecialInvoiceCreditNote(SpecialInvoiceCreditNote newSpecialInvoiceCreditNote, SpecialInvoiceCreditNote origSpecialInvoiceCreditNote)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();

                return ObjectExtension.CloneProperties<SP.Core.Domain.SpecialInvoiceCreditNote, SPWCFServer.SpecialInvoiceCreditNote>
                   (mgr.UpdateSpecialInvoiceCreditNote(ObjectExtension.CloneProperties<SPWCFServer.SpecialInvoiceCreditNote, SP.Core.Domain.SpecialInvoiceCreditNote>(newSpecialInvoiceCreditNote),
                      ObjectExtension.CloneProperties<SPWCFServer.SpecialInvoiceCreditNote, SP.Core.Domain.SpecialInvoiceCreditNote>(origSpecialInvoiceCreditNote)));
            }
            catch (Exception ex)
            {
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        #endregion

        #region SpecialInvoiceHeader

        public List<SpecialInvoiceHeader> GetSpecialHeaders(string orderNo, string invoiceNo, string customerName, DateTime dateFrom, DateTime dateTo, short orderStatus)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();
                List<SP.Core.Domain.SpecialInvoiceHeader> specialInvoiceHeaderList = mgr.GetSpecialHeaders(
                    orderNo,
                    invoiceNo,
                    customerName,
                    dateFrom,
                    dateTo,
                    orderStatus);
                return ObjectExtension.CloneList<SP.Core.Domain.SpecialInvoiceHeader, SPWCFServer.SpecialInvoiceHeader>(specialInvoiceHeaderList);
            }
            catch (Exception ex)
            {
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public void DeleteSpecialInvoiceHeader(SpecialInvoiceHeader specialInvoiceHeader)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();
                mgr.DeleteSpecialInvoiceHeader(ObjectExtension.CloneProperties<SPWCFServer.SpecialInvoiceHeader, SP.Core.Domain.SpecialInvoiceHeader>(specialInvoiceHeader));
            }
            catch (SqlException)
            {
                throw new FaultException("SPWCF Service error : " + "Cannot delete, it is likely that there are dependent items still linked to it");
            }
            catch (Exception ex)
            {
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public List<SpecialInvoiceHeader> GetAllSpecialInvoiceHeaders()
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();
                List<SP.Core.Domain.SpecialInvoiceHeader> specialInvoiceHeaderList = mgr.GetAllSpecialInvoiceHeaders();
                return ObjectExtension.CloneList<SP.Core.Domain.SpecialInvoiceHeader, SPWCFServer.SpecialInvoiceHeader>(specialInvoiceHeaderList);
            }
            catch (Exception ex)
            {
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public SpecialInvoiceHeader GetSpecialInvoiceHeader(int id)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();
                SP.Core.Domain.SpecialInvoiceHeader specialInvoiceHeader = mgr.GetSpecialInvoiceHeader(id);
                return ObjectExtension.CloneProperties<SP.Core.Domain.SpecialInvoiceHeader, SPWCFServer.SpecialInvoiceHeader>(specialInvoiceHeader);
            }
            catch (Exception ex)
            {
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public SpecialInvoiceHeader SaveSpecialInvoiceHeader(SpecialInvoiceHeader specialInvoiceHeader)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();
                SP.Core.Domain.SpecialInvoiceHeader coreSpecialInvoiceHeader =
                   ObjectExtension.CloneProperties<SPWCFServer.SpecialInvoiceHeader, SP.Core.Domain.SpecialInvoiceHeader>(specialInvoiceHeader);
                coreSpecialInvoiceHeader = mgr.SaveSpecialInvoiceHeader(coreSpecialInvoiceHeader);
                return ObjectExtension.CloneProperties<SP.Core.Domain.SpecialInvoiceHeader, SPWCFServer.SpecialInvoiceHeader>(coreSpecialInvoiceHeader);
            }
            catch (Exception ex)
            {
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public SpecialInvoiceHeader UpdateSpecialInvoiceHeader(SpecialInvoiceHeader newSpecialInvoiceHeader, SpecialInvoiceHeader origSpecialInvoiceHeader)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();

                return ObjectExtension.CloneProperties<SP.Core.Domain.SpecialInvoiceHeader, SPWCFServer.SpecialInvoiceHeader>
                   (mgr.UpdateSpecialInvoiceHeader(ObjectExtension.CloneProperties<SPWCFServer.SpecialInvoiceHeader, SP.Core.Domain.SpecialInvoiceHeader>(newSpecialInvoiceHeader),
                      ObjectExtension.CloneProperties<SPWCFServer.SpecialInvoiceHeader, SP.Core.Domain.SpecialInvoiceHeader>(origSpecialInvoiceHeader)));
            }
            catch (Exception ex)
            {
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        #endregion

        #region SpecialInvoiceLine

        public List<SpecialInvoiceLine> GetBySpecialInvoiceId(int id)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();
                List<SP.Core.Domain.SpecialInvoiceLine> specialInvoiceLinesList = mgr.GetBySpecialInvoiceId(id);
                return ObjectExtension.CloneList<SP.Core.Domain.SpecialInvoiceLine, SPWCFServer.SpecialInvoiceLine>(specialInvoiceLinesList);
            }
            catch (Exception ex)
            {
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public void DeleteSpecialInvoiceLine(SpecialInvoiceLine specialInvoiceLines)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();
                mgr.DeleteSpecialInvoiceLine(ObjectExtension.CloneProperties<SPWCFServer.SpecialInvoiceLine, SP.Core.Domain.SpecialInvoiceLine>(specialInvoiceLines));
            }
            catch (SqlException)
            {
                throw new FaultException("SPWCF Service error : " + "Cannot delete, it is likely that there are dependent items still linked to it");
            }
            catch (Exception ex)
            {
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public List<SpecialInvoiceLine> GetAllSpecialInvoiceLines()
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();
                List<SP.Core.Domain.SpecialInvoiceLine> specialInvoiceLinesList = mgr.GetAllSpecialInvoiceLines();
                return ObjectExtension.CloneList<SP.Core.Domain.SpecialInvoiceLine, SPWCFServer.SpecialInvoiceLine>(specialInvoiceLinesList);
            }
            catch (Exception ex)
            {
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public SpecialInvoiceLine GetSpecialInvoiceLine(int id)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();
                SP.Core.Domain.SpecialInvoiceLine specialInvoiceLines = mgr.GetSpecialInvoiceLine(id);
                return ObjectExtension.CloneProperties<SP.Core.Domain.SpecialInvoiceLine, SPWCFServer.SpecialInvoiceLine>(specialInvoiceLines);
            }
            catch (Exception ex)
            {
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public SpecialInvoiceLine SaveSpecialInvoiceLine(SpecialInvoiceLine specialInvoiceLines)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();
                SP.Core.Domain.SpecialInvoiceLine coreSpecialInvoiceLine =
                   ObjectExtension.CloneProperties<SPWCFServer.SpecialInvoiceLine, SP.Core.Domain.SpecialInvoiceLine>(specialInvoiceLines);
                coreSpecialInvoiceLine = mgr.SaveSpecialInvoiceLine(coreSpecialInvoiceLine);
                return ObjectExtension.CloneProperties<SP.Core.Domain.SpecialInvoiceLine, SPWCFServer.SpecialInvoiceLine>(coreSpecialInvoiceLine);
            }
            catch (Exception ex)
            {
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public SpecialInvoiceLine UpdateSpecialInvoiceLine(SpecialInvoiceLine newSpecialInvoiceLine, SpecialInvoiceLine origSpecialInvoiceLine)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();

                return ObjectExtension.CloneProperties<SP.Core.Domain.SpecialInvoiceLine, SPWCFServer.SpecialInvoiceLine>
                   (mgr.UpdateSpecialInvoiceLine(ObjectExtension.CloneProperties<SPWCFServer.SpecialInvoiceLine, SP.Core.Domain.SpecialInvoiceLine>(newSpecialInvoiceLine),
                      ObjectExtension.CloneProperties<SPWCFServer.SpecialInvoiceLine, SP.Core.Domain.SpecialInvoiceLine>(origSpecialInvoiceLine)));
            }
            catch (Exception ex)
            {
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        #endregion

        #region StandardVatRate

        public bool StandardVatRateExists()
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();
                return mgr.StandardVatRateExists();
            }
            catch (SqlException)
            {
                throw new FaultException("SPWCF Service error : " + "Cannot delete, it is likely that there are dependent items still linked to it");
            }
            catch (Exception ex)
            {
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public void DeleteStandardVatRate(StandardVatRate standardVatRate)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();
                mgr.DeleteStandardVatRate(ObjectExtension.CloneProperties<SPWCFServer.StandardVatRate, SP.Core.Domain.StandardVatRate>(standardVatRate));
            }
            catch (SqlException)
            {
                throw new FaultException("SPWCF Service error : " + "Cannot delete, it is likely that there are dependent items still linked to it");
            }
            catch (Exception ex)
            {
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public List<StandardVatRate> GetAllStandardVatRates()
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();
                List<SP.Core.Domain.StandardVatRate> standardVatRateList = mgr.GetAllStandardVatRates();
                return ObjectExtension.CloneList<SP.Core.Domain.StandardVatRate, SPWCFServer.StandardVatRate>(standardVatRateList);
            }
            catch (Exception ex)
            {
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public StandardVatRate GetStandardVatRate()
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();
                SP.Core.Domain.StandardVatRate standardVatRate = mgr.GetStandardVatRate();
                return ObjectExtension.CloneProperties<SP.Core.Domain.StandardVatRate, SPWCFServer.StandardVatRate>(standardVatRate);
            }
            catch (Exception ex)
            {
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public StandardVatRate SaveStandardVatRate(StandardVatRate standardVatRate)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();
                SP.Core.Domain.StandardVatRate coreStandardVatRate =
                   ObjectExtension.CloneProperties<SPWCFServer.StandardVatRate, SP.Core.Domain.StandardVatRate>(standardVatRate);
                coreStandardVatRate = mgr.SaveStandardVatRate(coreStandardVatRate);
                return ObjectExtension.CloneProperties<SP.Core.Domain.StandardVatRate, SPWCFServer.StandardVatRate>(coreStandardVatRate);
            }
            catch (Exception ex)
            {
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public StandardVatRate UpdateStandardVatRate(StandardVatRate newStandardVatRate, StandardVatRate origStandardVatRate)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();

                return ObjectExtension.CloneProperties<SP.Core.Domain.StandardVatRate, SPWCFServer.StandardVatRate>
                   (mgr.UpdateStandardVatRate(ObjectExtension.CloneProperties<SPWCFServer.StandardVatRate, SP.Core.Domain.StandardVatRate>(newStandardVatRate),
                      ObjectExtension.CloneProperties<SPWCFServer.StandardVatRate, SP.Core.Domain.StandardVatRate>(origStandardVatRate)));
            }
            catch (Exception ex)
            {
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        #endregion

        #region ITerm Members

        public void DeleteTerm(Terms term)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();
                mgr.DeleteTerm(ObjectExtension.CloneProperties<SPWCFServer.Terms, SP.Core.Domain.Terms>(term));

            }
            catch (SqlException)
            {
                throw new FaultException("SPWCF Service error : " + "Cannot delete description. It is likely that the description has outstanding Accounts still linked to it");
            }
            catch (Exception ex)
            {
                // Log full Exception to be done ...
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public List<Terms> GetAllTerms()
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();

                List<SP.Core.Domain.Terms> termsList = mgr.GetAllTerms();
                return ObjectExtension.CloneList<SP.Core.Domain.Terms, SPWCFServer.Terms>(termsList);
            }
            catch (Exception ex)
            {
                // Log full Exception to be done ...
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public Terms GetTerm(int id)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();

                SP.Core.Domain.Terms terms = mgr.GetTerm(id);
                return ObjectExtension.CloneProperties<SP.Core.Domain.Terms, SPWCFServer.Terms>(terms);
            }
            catch (Exception ex)
            {
                // Log full Exception to be done ...
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public Terms SaveTerm(Terms term)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();

                SP.Core.Domain.Terms coreTerm =
                   ObjectExtension.CloneProperties<SPWCFServer.Terms, SP.Core.Domain.Terms>(term);

                coreTerm = mgr.SaveTerm(coreTerm);

                return ObjectExtension.CloneProperties<SP.Core.Domain.Terms, SPWCFServer.Terms>(coreTerm);

            }
            catch (Exception ex)
            {
                // Log full Exception to be done ...
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public Terms UpdateTerm(Terms newTerm, Terms origTerm)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();

                return ObjectExtension.CloneProperties<SP.Core.Domain.Terms, SPWCFServer.Terms>
                    (mgr.UpdateTerm(ObjectExtension.CloneProperties<SPWCFServer.Terms, SP.Core.Domain.Terms>(newTerm),
                        ObjectExtension.CloneProperties<SPWCFServer.Terms, SP.Core.Domain.Terms>(origTerm)));
            }
            catch (Exception ex)
            {
                // Log full Exception to be done ...
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        #endregion

        #region IVan Members

        public Van SaveVan(Van van)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();

                SP.Core.Domain.Van coreVan =
                   ObjectExtension.CloneProperties<SPWCFServer.Van, SP.Core.Domain.Van>(van);

                coreVan = mgr.SaveVan(coreVan);

                return ObjectExtension.CloneProperties<SP.Core.Domain.Van, SPWCFServer.Van>(coreVan);

            }
            catch (Exception ex)
            {
                // Log full Exception to be done ...
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public Van GetVan(int id)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();

                SP.Core.Domain.Van van = mgr.GetVan(id);
                return ObjectExtension.CloneProperties<SP.Core.Domain.Van, SPWCFServer.Van>(van);
            }
            catch (Exception ex)
            {
                // Log full Exception to be done ...
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public Van UpdateVan(Van newCode, Van origCode)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();

                return ObjectExtension.CloneProperties<SP.Core.Domain.Van, SPWCFServer.Van>
                    (mgr.UpdateVan(ObjectExtension.CloneProperties<SPWCFServer.Van, SP.Core.Domain.Van>(newCode),
                        ObjectExtension.CloneProperties<SPWCFServer.Van, SP.Core.Domain.Van>(origCode)));
            }
            catch (Exception ex)
            {
                // Log full Exception to be done ...
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public List<Van> GetAllVans()
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();

                List<SP.Core.Domain.Van> vanList = mgr.GetAllVans();
                return ObjectExtension.CloneList<SP.Core.Domain.Van, SPWCFServer.Van>(vanList);
            }
            catch (Exception ex)
            {
                // Log full Exception to be done ...
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }

        public void DeleteVan(Van van)
        {
            try
            {
                IFoundationFacilitiesManager mgr = new FoundationFacilitiesManager();
                mgr.DeleteVan(ObjectExtension.CloneProperties<SPWCFServer.Van, SP.Core.Domain.Van>(van));

            }
            catch (SqlException)
            {
                throw new FaultException("SPWCF Service error : " + "Cannot delete description. It is likely that the description has outstanding Accounts still linked to it");
            }
            catch (Exception ex)
            {
                // Log full Exception to be done ...
                throw new FaultException("SPWCF Service error : " + ex.Message);
            }
        }
        #endregion
    }
}

