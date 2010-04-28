using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using System.Data.Linq;

namespace SPWCFServer
{
    #region Service Contracts
    [ServiceContract]
    public interface IFoundationService
    {
        #region Account
        [OperationContract]
        Account SaveAccount(Account ac);

        [OperationContract]
        bool AlphaIDExists(string id);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        List<Account> GetAllAccounts();

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        List<Account> GetAccountsByCustomerId(int id);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        Account GetAccount(int id);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        Account GetAccountByAlphaID(string id);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        Account UpdateAccount(Account newAccount, Account origAccount);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        void DeleteAccount(Account cde);
        #endregion

        #region Address
        [OperationContract]
        [ReferencePreservingDataContractFormat]
        Address GetAddress(int id);
        #endregion

        #region Autogen
        [OperationContract]
        [ReferencePreservingDataContractFormat]
        int GenerateOrderNo();
        #endregion

        #region Customers
        [OperationContract]
        void DeleteCustomer(int customerID);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        List<Account> GetAccountsByCustomerID(int id);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        List<Customer> GetCustomersByAccountNameLike(string name);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        List<Customer> GetByTelehoneNoLike(string telephoneNo);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        List<Customer> GetAllCustomers();

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        bool CustomerExistsByName(string name);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        bool CustomerExistsWithNameLike(string name);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        Customer GetCustomerByName(string name);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        Customer GetCustomerByID(int id);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        List<Customer> GetCustomerByNameLike(string name);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        Customer GetCustomerWithContacts(int id);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        Customer GetCustomerWithOutletStores(int id);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        Customer SaveCustomerOutlet(Customer customer);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        Customer UpdateCustomer(Customer newCustomer, Customer origCustomer);

        #endregion

        #region CreditNote

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        bool CreditNoteExistsByOrderId(int orderId);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        void DeleteCreditNote(CreditNote creditNote);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        List<CreditNote> GetAllCreditNotes();

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        CreditNote GetCreditNote(int id);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        CreditNote SaveCreditNote(CreditNote creditNote);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        CreditNote UpdateCreditNote(CreditNote newCreditNote, CreditNote origCreditNote);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        List<CreditNoteDetails> SearchCreditNotes(string orderNo, string invoiceNo, string customerName, DateTime dateFrom, DateTime dateTo);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        InvoiceCreditNoteDetails GetInvoiceCreditDetails(int orderID);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        decimal GetOustandingCreditNoteBalance(int orderNo, int creditNote, decimal vatRate);

        #endregion

        #region Contacts

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        void DeleteContactDetail(ContactDetail contactDetail);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        ContactDetail GetContactDetailByID(int id);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        List<ContactDetail> GetContactDetailsByCustomer(int id);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        ContactDetail SaveContactDetail(ContactDetail contactDetail);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        ContactDetail UpdateContactDetail(ContactDetail newContactDetail, ContactDetail origContactDetail);

        #endregion

        #region Foundationfacilities
        // Foundation Facilities
        [OperationContract]
        [ReferencePreservingDataContractFormat]
        FoundationFacility SaveFoundationFacility(FoundationFacility foundationFacility);

        [OperationContract]
        bool FoundationFacilityExists();

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        FoundationFacility GetFoundationFacility();

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        FoundationFacility UpdateFoundationFacility(FoundationFacility newFoundationFacility, FoundationFacility origFoundationFacility);

        #endregion

        #region OutletStores
        [OperationContract]
        [ReferencePreservingDataContractFormat]
        void DeleteOutletStore(OutletStore store);
        [OperationContract]
        [ReferencePreservingDataContractFormat]
        OutletStore SaveOutletStore(OutletStore store);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        OutletStore GetOutletStoreByID(int id);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        OutletStore UpdateOutletStore(OutletStore newStore, OutletStore origStore);
        #endregion

        #region OrderCreditNote

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        void DeleteOrderCreditNote(OrderCreditNote orderCreditNote);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        List<OrderCreditNote> GetAllOrderCreditNotes();

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        OrderCreditNote GetOrderCreditNote(int id);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        OrderCreditNote SaveOrderCreditNote(OrderCreditNote orderCreditNote);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        OrderCreditNote UpdateOrderCreditNote(OrderCreditNote newOrderCreditNote, OrderCreditNote origOrderCreditNote);

        #endregion

        #region OrderCreditNoteLine

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        void DeleteOrderCreditNoteLine(OrderCreditNoteLine orderCreditNoteLine);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        List<OrderCreditNoteLine> GetAllOrderCreditNoteLines();

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        OrderCreditNoteLine GetOrderCreditNoteLine(int id);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        OrderCreditNoteLine SaveOrderCreditNoteLine(OrderCreditNoteLine orderCreditNoteLine);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        OrderCreditNoteLine UpdateOrderCreditNoteLine(OrderCreditNoteLine newOrderCreditNoteLine, OrderCreditNoteLine origOrderCreditNoteLine);

        #endregion

        #region Order Header

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        OrderHeader CreateInvoice(OrderHeader newOrderHeader, OrderHeader origOrderHeader);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        OrderHeader CreateInvoiceProforma(OrderHeader newOrderHeader, OrderHeader origOrderHeader);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        OrderHeader CreateDeliveryNote(OrderHeader newOrderHeader, OrderHeader origOrderHeader);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        void DeleteOrderHeader(OrderHeader orderHeader);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        OrderHeader GetOrderHeader(int id);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        OrderHeader GetOrderHeaderByIdWithVatCode(int id);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        OrderHeader GetOrderHeaderByOrderNo(string orderNo);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        List<OrderHeader> GetAllOrderHeaders();

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        bool InvoiceNoExists(string invoiceNo);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        List<OrderHeader> GetOrderHeaderForSearch(string orderNo, string invoiceNo, string customerName, DateTime dateFrom, DateTime dateTo, short orderStatus);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        List<OrderHeader> GetOrderHeaderForSearchWithPrintedOrderStatuses(string orderNo, string invoiceNo, string customerName, DateTime dateFrom, DateTime dateTo, short actualOrderStatus, short printedOrderStatus);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        OrderHeader SaveOrderHeader(OrderHeader orderHeader);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        OrderHeader UpdateOrderHeader(OrderHeader newOrderHeader, OrderHeader origOrderHeader);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        List<InvoiceWithStatus> GetInvoicesWithStatus(string orderNo, string invoiceNo,
            string customerName, DateTime dateFrom, DateTime dateTo, short orderStatus);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        void VoidOrder(int orderID, string reasonForVoiding);
        #endregion

        #region Order Line
        [OperationContract]
        [ReferencePreservingDataContractFormat]
        void DeleteOrderLine(OrderLine orderLine);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        OrderLine GetOrderLine(int id);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        List<OrderLine> GetOrderLinesByOrderID(int id);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        OrderLine SaveOrderLine(OrderLine orderLine);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        OrderLine UpdateOrderLine(OrderLine newOrderLine, OrderLine origOrderLine);
        #endregion

        #region OrderNotesStatus

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        void DeleteOrderNotesStatus(OrderNotesStatus orderNotesStatus);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        List<OrderNotesStatus> GetAllOrderNotesStatuss();

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        OrderNotesStatus GetOrderNoteStatusByOrderId(int id);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        OrderNotesStatus GetOrderNotesStatus(int id);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        bool OrderNoteStatusByOrderIDExists(int orderID);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        OrderNotesStatus SaveOrderNotesStatus(OrderNotesStatus orderNotesStatus);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        OrderNotesStatus UpdateOrderNotesStatus(OrderNotesStatus newOrderNotesStatus, OrderNotesStatus origOrderNotesStatus);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        void UpdatePaymentCompleted(int orderID, bool invoicePaymentComplete);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        List<OrderHeader> InvoicesByDateAndVan(DateTime deliveryDate, int vanId);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        void UpdateVanForInvoice(int orderID, int vanID);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        List<VanInvoiceCount> GetVanInvoiceCount(DateTime deliveryDate);

        #endregion

        #region PriceListHeader
        [OperationContract]
        [ReferencePreservingDataContractFormat]
        void DeletePriceListHeader(int id);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        List<PriceListHeader> GetAllPriceListHeaders();

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        PriceListHeader GetPriceListHeaderByID(int id);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        PriceListHeader SavePriceListHeader(PriceListHeader priceListHeader);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        PriceListHeader UpdatePriceListHeader(PriceListHeader newPriceListHeader, PriceListHeader origPriceListHeader);
        #endregion

        #region PricelistItem
        [OperationContract]
        [ReferencePreservingDataContractFormat]
        void DeletePriceListItemByID(int priceListItem);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        PriceListItem GetPriceListItemById(int id);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        PriceListItem GetPriceListItemByProductId(int priceListID, int productId);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        List<PriceListItem> GetPriceListItemByPriceListHeader(int id);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        void DeletePriceListItemByProductId(int priceListID, int productId);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        PriceListItem SavePriceListItem(PriceListItem priceListItem);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        PriceListItem UpdatePriceListItem(PriceListItem newProduct, PriceListItem origProduct);
        #endregion

        #region Products
        [OperationContract]
        Product SaveProduct(Product product);

        [OperationContract]
        void DeleteProduct(Product product);

        [OperationContract]
        List<Product> GetAllProducts();

        [OperationContract]
        Product GetProduct(int id);

        [OperationContract]
        Product UpdateProduct(Product newProduct, Product origProduct);

        [OperationContract]
        Product GetProductByProductCode(string code);

        [OperationContract]
        bool ProductCodeExists(string productCode);

        [OperationContract]
        List<Product> GetLikeProductCode(string productCode);

        [OperationContract]
        List<Product> GetLikeProductDescription(string productDescription);

        [OperationContract]
        List<Product> GetProductsInPriceList(int id);

        [OperationContract]
        List<Product> GetProductsOutOfProductList(int id);

        #endregion

        #region SpecialInvoiceHeader
        [OperationContract]
        [ReferencePreservingDataContractFormat]
        List<SpecialInvoiceHeader> GetSpecialHeaders(string orderNo, string invoiceNo, string customerName, DateTime dateFrom, DateTime dateTo, short orderStatus);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        void DeleteSpecialInvoiceHeader(SpecialInvoiceHeader specialInvoiceHeader);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        List<SpecialInvoiceHeader> GetAllSpecialInvoiceHeaders();

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        SpecialInvoiceHeader GetSpecialInvoiceHeader(int id);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        SpecialInvoiceHeader SaveSpecialInvoiceHeader(SpecialInvoiceHeader specialInvoiceHeader);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        SpecialInvoiceHeader UpdateSpecialInvoiceHeader(SpecialInvoiceHeader newSpecialInvoiceHeader, SpecialInvoiceHeader origSpecialInvoiceHeader);

        #endregion

        #region SpecialInvoiceLine
        [OperationContract]
        [ReferencePreservingDataContractFormat]
        List<SpecialInvoiceLine> GetBySpecialInvoiceId(int id);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        void DeleteSpecialInvoiceLine(SpecialInvoiceLine specialInvoiceLines);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        List<SpecialInvoiceLine> GetAllSpecialInvoiceLines();

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        SpecialInvoiceLine GetSpecialInvoiceLine(int id);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        SpecialInvoiceLine SaveSpecialInvoiceLine(SpecialInvoiceLine specialInvoiceLines);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        SpecialInvoiceLine UpdateSpecialInvoiceLine(SpecialInvoiceLine newSpecialInvoiceLines, SpecialInvoiceLine origSpecialInvoiceLines);

        #endregion

        #region StandardVatRate

        [OperationContract]
        bool StandardVatRateExists();

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        void DeleteStandardVatRate(StandardVatRate standardVatRate);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        List<StandardVatRate> GetAllStandardVatRates();

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        StandardVatRate GetStandardVatRate();

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        StandardVatRate SaveStandardVatRate(StandardVatRate standardVatRate);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        StandardVatRate UpdateStandardVatRate(StandardVatRate newStandardVatRate, StandardVatRate origStandardVatRate);

        #endregion

        #region Terms
        [OperationContract]
        Terms SaveTerm(Terms code);

        [OperationContract]
        Terms GetTerm(int id);

        [OperationContract]
        Terms UpdateTerm(Terms newCode, Terms origCode);

        [OperationContract]
        List<Terms> GetAllTerms();

        [OperationContract]
        void DeleteTerm(Terms cde);

        #endregion

        #region Vat Codes
        // Vat Codes
        [OperationContract]
        VatCode SaveVatCode(VatCode code);

        [OperationContract]
        VatCode GetVatCode(int id);

        [OperationContract]
        VatCode UpdateVatCode(VatCode newCode, VatCode origCode);

        [OperationContract]
        List<VatCode> GetAllVatCodes();

        [OperationContract]
        void DeleteVatCode(VatCode cde);

        [OperationContract]
        bool ExemptCodeExists();

        [OperationContract]
        bool VatCodeExists(string vatCode);
        #endregion

        #region Van
        [OperationContract]
        Van SaveVan(Van code);

        [OperationContract]
        Van GetVan(int id);

        [OperationContract]
        Van UpdateVan(Van newCode, Van origCode);

        [OperationContract]
        List<Van> GetAllVans();

        [OperationContract]
        void DeleteVan(Van cde);

        #endregion

    }
    #endregion

    #region Data Contracts
    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class Account
    {
        private int _id;
        private int? _InvoiceAddressID;
        private int _ContactDetailID;
        private int? _CustomerID;
        private int? _TermTypeID;
        private string _AlphaID;
        private string _CompanyToInvoiceTo;
        private Address _Address;
        private Customer _Customer;
        private Terms _Terms;

        [DataMember]
        public int ID
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        [DataMember]
        public int ContactDetailID
        {
            get
            {
                return _ContactDetailID;
            }
            set
            {
                _ContactDetailID = value;
            }
        }

        [DataMember]
        public int? InvoiceAddressID
        {
            get
            {
                return _InvoiceAddressID;
            }
            set
            {
                _InvoiceAddressID = value;
            }
        }

        [DataMember]
        public int? CustomerID
        {
            get
            {
                return _CustomerID;
            }
            set
            {
                _CustomerID = value;
            }
        }

        [DataMember]
        public int? TermTypeID
        {
            get
            {
                return _TermTypeID;
            }
            set
            {
                _TermTypeID = value;
            }
        }

        [DataMember]
        public string AlphaID
        {
            get
            {
                return _AlphaID;
            }
            set
            {
                _AlphaID = value;
            }
        }

        [DataMember]
        public string CompanyToInvoiceTo
        {
            get { return _CompanyToInvoiceTo; }
            set { _CompanyToInvoiceTo = value; }
        }

        [DataMember]
        public Customer Customer
        {
            get { return _Customer; }
            set { _Customer = value; }
        }

        [DataMember]
        public Address Address
        {
            get { return _Address; }
            set
            {
                _Address = value;
                _Address.AccountID = ID;
                _Address.Account = this;
            }
        }

        [DataMember]
        public Terms Terms
        {
            get { return _Terms; }
            set { _Terms = value; }
        }
    }

    [DataContract]
    public class Address
    {
        private int _id;
        private short _AddressType;
        private string _AddressLines;
        private string _Town;
        private string _County;
        private string _PostCode;
        private string _MapReference;

        private Account _Account;
        private int _AccountID;
        private int _OutletID;
        private OutletStore _OutletStore;

        private FoundationFacility _FoundationFacility;

        [DataMember]
        public int ID
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        [DataMember]
        public short AddressType
        {
            get
            {
                return _AddressType;
            }
            set
            {
                _AddressType = value;
            }
        }

        [DataMember]
        public string AddressLines
        {
            get
            {
                return _AddressLines;
            }
            set
            {
                _AddressLines = value;
            }
        }

        [DataMember]
        public string Town
        {
            get
            {
                return _Town;
            }
            set
            {
                _Town = value;
            }
        }

        [DataMember]
        public string County
        {
            get
            {
                return _County;
            }
            set
            {
                _County = value;
            }
        }

        [DataMember]
        public string PostCode
        {
            get
            {
                return _PostCode;
            }
            set
            {
                _PostCode = value;
            }
        }

        [DataMember]
        public string MapReference
        {
            get
            {
                return _MapReference;
            }
            set
            {
                _MapReference = value;
            }
        }

        [DataMember]
        public FoundationFacility FoundationFacility
        {
            get
            {
                return this._FoundationFacility;
            }
            set
            {
                this._FoundationFacility = value;
            }
        }

        [DataMember]
        public Account Account
        {
            get
            {
                return this._Account;
            }
            set
            {
                this._Account = value;
            }
        }

        [DataMember]
        public int AccountID
        {
            get
            {
                return this._AccountID;
            }
            set
            {
                this._AccountID = value;
            }
        }

        [DataMember]
        public int OutletID
        {
            get
            {
                return this._OutletID;
            }
            set
            {
                this._OutletID = value;
            }
        }

        [DataMember]
        public OutletStore OutletStore
        {
            get
            {
                return this._OutletStore;
            }
            set
            {
                this._OutletStore = value;
            }
        }

    }

    [DataContract]
    public class Customer
    {
        private int _id;
        private string _Name;
        private string _VatRegistrationNumber;
        private int _PriceListHeaderID;

        private List<OutletStore> _OutletStore;
        private List<Note> _Note;
        private List<ContactDetail> _ContactDetail;
        private List<Account> _Account;

        [DataMember]
        public int ID
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        [DataMember]
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
            }
        }

        [DataMember]
        public string VatRegistrationNumber
        {
            get
            {
                return _VatRegistrationNumber;
            }
            set
            {
                _VatRegistrationNumber = value;
            }
        }

        [DataMember]
        public int PriceListHeaderID
        {
            get { return _PriceListHeaderID; }
            set { _PriceListHeaderID = value; }
        }

        [DataMember]
        public List<Note> Note
        {
            get
            {
                return _Note;
            }
            set
            {
                _Note = value;
                //if (_Note != null)
                //{
                //    foreach (var note in _Note)
                //    {
                //        note.ParentNoteID = ID;
                //        note.Customer = this;
                //    }
                //}
            }
        }

        [DataMember]
        public List<ContactDetail> ContactDetail
        {
            get
            {
                return _ContactDetail;
            }
            set
            {
                _ContactDetail = value;
                //if (_ContactDetail != null)
                //{
                //    foreach (var contactDetail in _ContactDetail)
                //    {
                //        contactDetail.CustomerID = ID;
                //        contactDetail.Customer = this;
                //    }
                //}
            }
        }

        [DataMember]
        public List<Account> Account
        {
            get
            {
                return _Account;
            }
            set
            {
                _Account = value;
                //if (_Account != null)
                //{
                //    foreach (var account in _Account)
                //    {
                //        account.CustomerID = ID;
                //        account.Customer = this;
                //    }
                //}
            }
        }

        [DataMember]
        public List<OutletStore> OutletStore
        {
            get
            {
                return _OutletStore;
            }
            set
            {
                _OutletStore = value;
                //if (_OutletStore != null)
                //{
                //    foreach (var outlet in _OutletStore)
                //    {
                //        outlet.CustomerID = ID;
                //        outlet.Customer = this;
                //    }
                //}
            }
        }
    }

    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }

    [DataContract]
    public class ContactDetail
    {
        private int _id;
        private int? _CustomerID;
        private int _ShopID;
        private string _JobRole;
        private string _Title;
        private string _FirstName;
        private string _LastName;
        private string _EMailAddress;
        private string _InitialNote;

        private Customer _Customer;
        List<Phone> _Phone;

        [DataMember]
        public int ID
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        [DataMember]
        public int? CustomerID
        {
            get
            {
                return _CustomerID;
            }
            set
            {
                _CustomerID = value;
            }
        }

        [DataMember]
        public int ShopID
        {
            get
            {
                return _ShopID;
            }
            set
            {
                _ShopID = value;
            }
        }

        [DataMember]
        public string JobRole
        {
            get
            {
                return _JobRole;
            }
            set
            {
                _JobRole = value;
            }
        }

        [DataMember]
        public string Title
        {
            get
            {
                return _Title;
            }
            set
            {
                _Title = value;
            }
        }

        [DataMember]
        public string FirstName
        {
            get
            {
                return _FirstName;
            }
            set
            {
                _FirstName = value;
            }
        }

        [DataMember]
        public string LastName
        {
            get
            {
                return _LastName;
            }
            set
            {
                _LastName = value;
            }
        }

        [DataMember]
        public string EMailAddress
        {
            get
            {
                return _EMailAddress;
            }
            set
            {
                _EMailAddress = value;
            }
        }

        [DataMember]
        public string InitialNote
        {
            get
            {
                return _InitialNote;
            }
            set
            {
                _InitialNote = value;
            }
        }

        [DataMember]
        public Customer Customer
        {
            get { return _Customer; }
            set { _Customer = value; }
        }

        [DataMember]
        public List<Phone> Phone
        {
            get
            {
                return _Phone;
            }
            set
            {
                _Phone = value;
                foreach (var phone in _Phone)
                {
                    phone.ContactDetailID = ID;
                    phone.ContactDetail = this;
                }
            }
        }
    }

    [DataContract]
    public class CreditNote
    {
        private int _ID;
        private int _OrderID;
        private decimal _CreditAmount;
        private string _Reason;
        private DateTime _DateCreated;
        private string _Reference;
        private bool _VatExempt;
        private DateTime _DueDate;

        [DataMember]
        public int ID
        {
            get
            {
                return _ID;
            }
            set
            {
                _ID = value;
            }
        }

        [DataMember]
        public int OrderID
        {
            get
            {
                return _OrderID;
            }
            set
            {
                _OrderID = value;
            }
        }

        [DataMember]
        public decimal CreditAmount
        {
            get
            {
                return _CreditAmount;
            }
            set
            {
                _CreditAmount = value;
            }
        }

        [DataMember]
        public string Reason
        {
            get
            {
                return _Reason;
            }
            set
            {
                _Reason = value;
            }
        }

        [DataMember]
        public DateTime DateCreated
        {
            get
            {
                return _DateCreated;
            }

            set
            {
                _DateCreated = value;
            }
        }

        [DataMember]
        public string Reference
        {
            get
            {
                return _Reference;
            }

            set
            {
                _Reference = value;
            }
        }

        [DataMember]
        public bool VatExempt
        {
            get
            {
                return _VatExempt;
            }

            set
            {
                _VatExempt = value;
            }
        }

        [DataMember]
        public DateTime DueDate
        {
            get
            {
                return _DueDate;
            }

            set
            {
                _DueDate = value;
            }
        }
    }

    [DataContract]
    public class CreditNoteDetails
    {
        private int _CreditNoteID;
        private int _OrderID;
        private string _OrderNo;
        private string _InvoiceNo;
        private DateTime _DateCreated;
        private string _CustomerName;
        private string _Reference;
        private DateTime _DueDate;

        [DataMember]
        public int CreditNoteID
        {
            get
            {
                return _CreditNoteID;
            }

            set
            {
                _CreditNoteID = value;
            }
        }

        [DataMember]
        public int OrderID
        {
            get
            {
                return _OrderID;
            }
            set
            {
                _OrderID = value;
            }
        }

        [DataMember]
        public string OrderNo
        {
            get
            {
                return _OrderNo;
            }

            set
            {
                _OrderNo = value;
            }
        }

        [DataMember]
        public string InvoiceNo
        {
            get
            {
                return _InvoiceNo;
            }
            set
            {
                _InvoiceNo = value;
            }
        }

        [DataMember]
        public DateTime DateCreated
        {
            get
            {
                return _DateCreated;
            }
            set
            {
                _DateCreated = value;
            }
        }

        [DataMember]
        public string CustomerName
        {
            get
            {
                return
                    _CustomerName;
            }

            set
            {
                _CustomerName = value;
            }
        }

        [DataMember]
        public string Reference
        {
            get
            {
                return _Reference;
            }

            set
            {
                _Reference = value;
            }
        }

        [DataMember]
        public DateTime DueDate
        {
            get
            {
                return _DueDate;
            }

            set
            {
                _DueDate = value;
            }
        }
    }

    [DataContract]
    public class FoundationFacility
    {
        private int _id;
        private string _CompanyName;
        private string _VatRegistrationNumber;
        private string _OfficePhoneNumber1;
        private string _OfficePhoneNumber2;
        private string _EMailAddress;
        private int _AddressID;
        Address _Address;

        [DataMember]
        public int ID
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        [DataMember]
        public string CompanyName
        {
            get
            {
                return _CompanyName;
            }
            set
            {
                _CompanyName = value;
            }
        }

        [DataMember]
        public string VatRegistrationNumber
        {
            get
            {
                return _VatRegistrationNumber;
            }
            set
            {
                _VatRegistrationNumber = value;
            }
        }

        [DataMember]
        public string OfficePhoneNumber1
        {
            get
            {
                return _OfficePhoneNumber1;
            }
            set
            {
                _OfficePhoneNumber1 = value;
            }
        }

        [DataMember]
        public string OfficePhoneNumber2
        {
            get
            {
                return _OfficePhoneNumber2;
            }
            set
            {
                _OfficePhoneNumber2 = value;
            }
        }

        [DataMember]
        public string EMailAddress
        {
            get
            {
                return _EMailAddress;
            }
            set
            {
                _EMailAddress = value;
            }
        }

        [DataMember]
        public int AddressID
        {
            get
            {
                return _AddressID;
            }
            set
            {
                _AddressID = value;
            }
        }

        [DataMember]
        public Address Address
        {
            get
            {
                return _Address;
            }
            set
            {
                _Address = value;
                _Address.FoundationFacility = this;
            }
        }
    }

    [DataContract]
    public class InvoiceWithStatus
    {
        string _OrderID;
        string _InvoiceNo;
        string _CustomerName;
        short _OrderStatus;
        bool _InvoicePaymentComplete;
        DateTime _OrderDate;
        DateTime _InvoicePrintedDate;

        [DataMember]
        public string CustomerName
        {
            get { return _CustomerName; }
            set { _CustomerName = value; }
        }

        /// <summary>
        /// Gets or sets the order status.
        /// </summary>
        /// <value>The order status.</value>
        public short OrderStatus
        {
            get { return _OrderStatus; }
            set { _OrderStatus = value; }
        }

        [DataMember]
        public DateTime OrderDate
        {
            get { return _OrderDate; }
            set { _OrderDate = value; }
        }

        [DataMember]
        public bool InvoicePaymentComplete
        {
            get { return _InvoicePaymentComplete; }
            set { _InvoicePaymentComplete = value; }
        }

        [DataMember]
        public string OrderID
        {
            get { return _OrderID; }
            set { _OrderID = value; }
        }

        [DataMember]
        public string InvoiceNo
        {
            get { return _InvoiceNo; }
            set { _InvoiceNo = value; }
        }
    }

    [DataContract]
    public class InvoiceCreditNoteDetails
    {
        [DataMember]
        public int OrderID { get; set; }

        [DataMember]
        public decimal TotalInvoiceAmount { get; set; }

        [DataMember]
        public decimal TotalAmountCredited { get; set; }

        [DataMember]
        public decimal Balance { get; set; }
    }

    [DataContract]
    public class OrderCreditNote
    {
        private int _ID;
        private int _OrderID;
        private string _Reason;
        private DateTime _DateCreated;
        private string _Reference;
        private DateTime _DueDate;

        [DataMember]
        public int ID
        {
            get
            {
                return _ID;
            }
            set
            {
                _ID = value;
            }
        }

        [DataMember]
        public int OrderID
        {
            get
            {
                return _OrderID;
            }
            set
            {
                _OrderID = value;
            }
        }

        [DataMember]
        public string Reason
        {
            get
            {
                return _Reason;
            }
            set
            {
                _Reason = value;
            }
        }

        [DataMember]
        public DateTime DateCreated
        {
            get
            {
                return _DateCreated;
            }
            set
            {
                _DateCreated = value;
            }
        }

        [DataMember]
        public string Reference
        {
            get
            {
                return _Reference;
            }
            set
            {
                _Reference = value;
            }
        }

        [DataMember]
        public DateTime DueDate
        {
            get
            {
                return _DueDate;
            }
            set
            {
                _DueDate = value;
            }
        }
    }

    [DataContract]
    public class OrderCreditNoteLine
    {
        private int _ID;
        private int _OrderCreditNoteID;
        private int _OrderLineID;
        private int _ProductID;
        private int _QtyPerUnit;
        private int _NoOfUnits;
        private int _Discount;
        private decimal _Price;

        [DataMember]
        public int ID
        {
            get
            {
                return _ID;
            }
            set
            {
                _ID = value;
            }
        }

        [DataMember]
        public int OrderCreditNoteID
        {
            get
            {
                return _OrderCreditNoteID;
            }
            set
            {
                _OrderCreditNoteID = value;
            }
        }

        [DataMember]
        public int OrderLineID
        {
            get
            {
                return _OrderLineID;
            }
            set
            {
                _OrderLineID = value;
            }
        }

        [DataMember]
        public int ProductID
        {
            get
            {
                return _ProductID;
            }
            set
            {
                _ProductID = value;
            }
        }

        [DataMember]
        public int QtyPerUnit
        {
            get
            {
                return _QtyPerUnit;
            }
            set
            {
                _QtyPerUnit = value;
            }
        }

        [DataMember]
        public int NoOfUnits
        {
            get
            {
                return _NoOfUnits;
            }
            set
            {
                _NoOfUnits = value;
            }
        }

        [DataMember]
        public int Discount
        {
            get
            {
                return _Discount;
            }
            set
            {
                _Discount = value;
            }
        }

        [DataMember]
        public decimal Price
        {
            get
            {
                return _Price;
            }
            set
            {
                _Price = value;
            }
        }
    }

    [DataContract]
    public class OrderHeader
    {
        private int _ID;
        private int _VatCodeID;
        private VatCode _VatCode;
        private int _CustomerID;
        private short _AlphaPrefixOrPostFix;
        private string _AlphaID;
        private string _DeliveryNoteNo;
        private string _InvoiceNo;
        private string _InvoiceProformaNo;
        private short _OrderStatus;
        private string _ReasonForVoiding;
        private OrderNotesStatus _OrderNotesStatus;
        private DateTime _OrderDate;
        private DateTime _DeliveryDate;
        private string _SpecialInstructions;
        private List<OrderLine> _OrderLine;
        private DateTime _LastModifiedDate;

        [DataMember]
        public int ID
        {
            get
            {
                return _ID;
            }
            set
            {
                _ID = value;
            }
        }

        [DataMember]
        public int VatCodeID
        {
            get
            {
                return _VatCodeID;
            }

            set
            {
                _VatCodeID = value;
            }
        }

        [DataMember]
        public VatCode VatCode
        {
            get
            {
                return _VatCode;
            }

            set
            {
                if (value != null)
                {
                    VatCodeID = value.ID;
                    _VatCode = value;
                }
            }
        }

        [DataMember]
        public string InvoiceNo
        {
            get
            {
                return _InvoiceNo;
            }
            set
            {
                _InvoiceNo = value;
            }
        }

        [DataMember]
        public string InvoiceProformaNo
        {
            get
            {
                return _InvoiceProformaNo;
            }

            set
            {
                _InvoiceProformaNo = value;
            }
        }

        [DataMember]
        public string DeliveryNoteNo
        {
            get
            {
                return _DeliveryNoteNo;
            }
            set
            {
                _DeliveryNoteNo = value;
            }
        }

        [DataMember]
        public int CustomerID
        {
            get
            {
                return _CustomerID;
            }
            set
            {
                _CustomerID = value;
            }
        }

        [DataMember]
        public short AlphaPrefixOrPostFix
        {
            get
            {
                return _AlphaPrefixOrPostFix;
            }
            set
            {
                _AlphaPrefixOrPostFix = value;
            }
        }

        [DataMember]
        public string AlphaID
        {
            get
            {
                return _AlphaID;
            }
            set
            {
                _AlphaID = value;
            }
        }

        [DataMember]
        public DateTime OrderDate
        {
            get
            {
                return _OrderDate;
            }
            set
            {
                _OrderDate = value;
            }
        }

        [DataMember]
        public DateTime DeliveryDate
        {
            get
            {
                return _DeliveryDate;
            }
            set
            {
                _DeliveryDate = value;
            }
        }

        [DataMember]
        public string SpecialInstructions
        {
            get
            {
                return _SpecialInstructions;
            }
            set
            {
                _SpecialInstructions = value;
            }
        }

        [DataMember]
        public OrderNotesStatus OrderNotesStatus
        {
            get
            {
                return _OrderNotesStatus;
            }
            set
            {
                _OrderNotesStatus = value;
                if (_OrderNotesStatus != null)
                {
                    _OrderNotesStatus.OrderID = this.ID;

                }
            }
        }

        [DataMember]
        public short OrderStatus
        {
            get
            {
                return _OrderStatus;
            }
            set
            {
                _OrderStatus = value;
            }
        }

        [DataMember]
        public string ReasonForVoiding
        {
            get
            {
                return _ReasonForVoiding;
            }
            set
            {
                _ReasonForVoiding = value;
            }
        }

        [DataMember]
        public List<OrderLine> OrderLine
        {
            get
            {
                return _OrderLine;
            }
            set
            {
                _OrderLine = value;
                if (_OrderLine != null)
                {
                    foreach (var orderLine in _OrderLine)
                    {
                        orderLine.OrderID = this.ID;
                        orderLine.OrderHeader = this;
                    }
                }
            }
        }

        [DataMember]
        public DateTime LastModifiedDate
        {
            get
            {
                return _LastModifiedDate;
            }

            set
            {
                _LastModifiedDate = value;
            }
        }
    }

    [DataContract]
    public class OrderLine
    {
        private int _ID;
        private int _OrderID;
        private int _ProductID;
        private short _OrderLineStatus;
        private int _QtyPerUnit;
        private int _NoOfUnits;
        private float _Discount;
        private Decimal _Price;
        private string _SpecialInstructions;

        private OrderHeader _OrderHeader;

        [DataMember]
        public int ID
        {
            get
            {
                return _ID;
            }
            set
            {
                _ID = value;
            }
        }

        [DataMember]
        public int OrderID
        {
            get
            {
                return _OrderID;
            }
            set
            {
                _OrderID = value;
            }
        }

        [DataMember]
        public int ProductID
        {
            get
            {
                return _ProductID;
            }
            set
            {
                _ProductID = value;
            }
        }

        [DataMember]
        public short OrderLineStatus
        {
            get
            {
                return _OrderLineStatus;
            }
            set
            {
                _OrderLineStatus = value;
            }
        }

        [DataMember]
        public int QtyPerUnit
        {
            get
            {
                return _QtyPerUnit;
            }
            set
            {
                _QtyPerUnit = value;
            }
        }

        [DataMember]
        public int NoOfUnits
        {
            get
            {
                return _NoOfUnits;
            }
            set
            {
                _NoOfUnits = value;
            }
        }

        [DataMember]
        public float Discount
        {
            get
            {
                return _Discount;
            }
            set
            {
                _Discount = value;
            }
        }

        [DataMember]
        public Decimal Price
        {
            get
            {
                return _Price;
            }
            set
            {
                _Price = value;
            }
        }

        [DataMember]
        public string SpecialInstructions
        {
            get { return _SpecialInstructions; }
            set { _SpecialInstructions = value; }
        }

        [DataMember]
        public OrderHeader OrderHeader
        {
            get
            {
                return this._OrderHeader;
            }
            set
            {
                this._OrderHeader = value;
            }
        }
    }

    [DataContract]
    public class OrderNotesStatus
    {
        private int _ID;
        private int _OrderID;
        private int? _AccountID;
        private int? _VanID;
        private int _OutletStoreID;

        private bool _DeliveryNotePrinted;
        private bool _InvoicePrinted;
        private bool _InvoiceReprinted;
        private bool _InvoiceProformaPrinted;
        private bool _InvoicePaymentComplete;
        private bool _PicklistGenerated;
        private DateTime _DeliveryNoteDatePrinted;
        private DateTime _InvoiceProformaDatePrinted;
        private DateTime _InvoiceDatePrinted;
        private DateTime _InvoiceDateReprinted;
        private DateTime _PicklistDateGenerated;
        private Account _Account;
        private Van _Van;
        private DateTime _InvoiceDateCreated;
        private DateTime _InvoiceProformaDateCreated;
        private DateTime _DeliveryNoteDateCreated;

        [DataMember]
        public int ID
        {
            get
            {
                return _ID;
            }
            set
            {
                _ID = value;
            }
        }

        [DataMember]
        public int OrderID
        {
            get
            {
                return _OrderID;
            }
            set
            {
                _OrderID = value;
            }
        }

        [DataMember]
        public int? AccountID
        {
            get
            {
                return _AccountID;
            }
            set
            {
                _AccountID = value;
            }
        }

        [DataMember]
        public int OutletStoreID
        {
            get
            {
                return _OutletStoreID;
            }
            set
            {
                _OutletStoreID = value;
            }
        }

        [DataMember]
        public Account Account
        {
            get
            {
                return _Account;
            }
            set
            {
                _Account = value;
            }
        }

        [DataMember]
        public Van Van
        {
            get
            {
                return _Van;
            }
            set
            {
                _Van = value;
            }
        }

        [DataMember]
        public int? VanID
        {
            get
            {
                return _VanID;
            }
            set
            {
                _VanID = value;
            }
        }

        [DataMember]
        public bool DeliveryNotePrinted
        {
            get
            {
                return _DeliveryNotePrinted;
            }
            set
            {
                _DeliveryNotePrinted = value;
            }
        }

        [DataMember]
        public bool InvoicePrinted
        {
            get
            {
                return _InvoicePrinted;
            }
            set
            {
                _InvoicePrinted = value;
            }
        }

        [DataMember]
        public bool InvoiceReprinted
        {
            get
            {
                return _InvoiceReprinted;
            }
            set
            {
                _InvoiceReprinted = value;
            }
        }

        [DataMember]
        public bool InvoicePaymentComplete
        {
            get
            {
                return _InvoicePaymentComplete;
            }
            set
            {
                _InvoicePaymentComplete = value;
            }
        }

        [DataMember]
        public bool InvoiceProformaPrinted
        {
            get
            {
                return _InvoiceProformaPrinted;
            }
            set
            {
                _InvoiceProformaPrinted = value;
            }
        }

        [DataMember]
        public bool PicklistGenerated
        {
            get
            {
                return _PicklistGenerated;
            }
            set
            {
                _PicklistGenerated = value;
            }
        }

        [DataMember]
        public DateTime DeliveryNoteDatePrinted
        {
            get
            {
                return _DeliveryNoteDatePrinted;
            }
            set
            {
                _DeliveryNoteDatePrinted = value;
            }
        }

        [DataMember]
        public DateTime InvoiceProformaDatePrinted
        {
            get
            {
                return _InvoiceProformaDatePrinted;
            }
            set
            {
                _InvoiceProformaDatePrinted = value;
            }
        }

        [DataMember]
        public DateTime InvoiceDatePrinted
        {
            get
            {
                return _InvoiceDatePrinted;
            }
            set
            {
                _InvoiceDatePrinted = value;
            }
        }

        [DataMember]
        public DateTime InvoiceDateReprinted
        {
            get
            {
                return _InvoiceDateReprinted;
            }
            set
            {
                _InvoiceDateReprinted = value;
            }
        }

        [DataMember]
        public DateTime PicklistDateGenerated
        {
            get
            {
                return _PicklistDateGenerated;
            }
            set
            {
                _PicklistDateGenerated = value;
            }
        }

        [DataMember]
        public DateTime InvoiceDateCreated
        {
            get
            {
                return _InvoiceDateCreated;
            }

            set
            {
                _InvoiceDateCreated = value;
            }
        }

        [DataMember]
        public DateTime InvoiceProformaDateCreated
        {
            get
            {
                return _InvoiceProformaDateCreated;
            }

            set
            {
                _InvoiceProformaDateCreated = value;
            }
        }

        [DataMember]
        public DateTime DeliveryNoteDateCreated
        {
            get
            {
                return _DeliveryNoteDateCreated;
            }

            set
            {
                _DeliveryNoteDateCreated = value;
            }
        }
    }

    [DataContract]
    public class Note
    {
        private int _id;
        private int? _ParentNoteID;
        private DateTime _DateNoteTaken;
        private string _SpokeTo;
        private string _NoteText;
        private Customer _Customer;

        [DataMember]
        public int ID
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        [DataMember]
        public int? ParentNoteID
        {
            get
            {
                return _ParentNoteID;
            }
            set
            {
                _ParentNoteID = value;
            }
        }

        [DataMember]
        public DateTime DateNoteTaken
        {
            get
            {
                return _DateNoteTaken;
            }
            set
            {
                _DateNoteTaken = value;
            }
        }

        [DataMember]
        public string SpokeTo
        {
            get
            {
                return _SpokeTo;
            }
            set
            {
                _SpokeTo = value;
            }
        }

        [DataMember]
        public string NoteText
        {
            get
            {
                return _NoteText;
            }
            set
            {
                _NoteText = value;
            }
        }

        [DataMember]
        public Customer Customer
        {
            get { return _Customer; }
            set { _Customer = value; }
        }
    }

    [DataContract]
    public class OutletStore
    {
        private int _id;
        private int? _CustomerID;
        private int _AddressID;

        private string _Name;
        private string _OpeningHoursNotes;
        private string _Note;

        private Customer _Customer;
        private Address _Address;

        [DataMember]
        public int ID
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        [DataMember]
        public int? CustomerID
        {
            get
            {
                return _CustomerID;
            }
            set
            {
                _CustomerID = value;
            }
        }

        [DataMember]
        public int AddressID
        {
            get
            {
                return _AddressID;
            }
            set
            {
                _AddressID = value;
            }
        }

        [DataMember]
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
            }
        }

        [DataMember]
        public string OpeningHoursNotes
        {
            get
            {
                return _OpeningHoursNotes;
            }
            set
            {
                _OpeningHoursNotes = value;
            }
        }

        [DataMember]
        public string Note
        {
            get
            {
                return _Note;
            }
            set
            {
                _Note = value;
            }
        }

        [DataMember]
        public Customer Customer
        {
            get
            {
                return _Customer;
            }
            set
            {
                _Customer = value;
            }
        }

        [DataMember]
        public Address Address
        {
            get
            {
                return _Address;
            }

            set
            {
                _Address = value;
                //if (value != null)
                //{
                //    _Address = value;
                //    _Address.OutletID = ID;
                //    _Address.OutletStore = this;
                //}
            }
        }
    }

    [DataContract]
    public class Phone
    {
        private int _id;
        private int? _ContactDetailID;
        private int? _PhoneTypeID;
        private string _Description;

        private ContactDetail _ContactDetail;

        private PhoneNoType _PhoneNoType;

        [DataMember]
        public int ID
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        [DataMember]
        public int? ContactDetailID
        {
            get
            {
                return _ContactDetailID;
            }
            set
            {
                _ContactDetailID = value;
            }
        }

        [DataMember]
        public int? PhoneTypeID
        {
            get
            {
                return _PhoneTypeID;
            }
            set
            {
                _PhoneTypeID = value;
            }
        }

        [DataMember]
        public string Description
        {
            get
            {
                return _Description;
            }
            set
            {
                _Description = value;
            }
        }

        [DataMember]
        public PhoneNoType PhoneNoType
        {
            get
            {
                return this._PhoneNoType;
            }
            set
            {
                _PhoneNoType = value;
            }
        }

        [DataMember]
        public ContactDetail ContactDetail
        {
            get
            {
                return _ContactDetail;
            }
            set
            {
                _ContactDetail = value;
            }
        }
    }

    [DataContract]
    public class PhoneNoType
    {
        private int _id;
        private string _Description;

        [DataMember]
        public int ID
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        [DataMember]
        public string Description
        {
            get
            {
                return _Description;
            }
            set
            {
                _Description = value;
            }
        }
    }

    [DataContract]
    public class PriceListHeader
    {
        private int _ID;
        private int _ProductID;
        private string _PriceListName;
        private DateTime _DateEffectiveFrom;
        private DateTime _DateEffectiveTo;

        [DataMember]
        public int ID
        {
            get
            {
                return _ID;
            }
            set
            {
                _ID = value;
            }
        }

        [DataMember]
        public string PriceListName
        {
            get
            {
                return _PriceListName;
            }
            set
            {
                _PriceListName = value;
            }
        }

        [DataMember]
        public DateTime DateEffectiveFrom
        {
            get
            {
                return _DateEffectiveFrom;
            }
            set
            {
                _DateEffectiveFrom = value;
            }
        }

        [DataMember]
        public DateTime DateEffectiveTo
        {
            get
            {
                return _DateEffectiveTo;
            }
            set
            {
                _DateEffectiveTo = value;
            }
        }
    }

    [DataContract]
    public class PriceListItem
    {
        private int _id;
        private int _PriceListID;
        private int? _ProductID;
        private decimal _Discount;
        Product _product;

        [DataMember]
        public int ID
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        [DataMember]
        public int PriceListID
        {
            get
            {
                return _PriceListID;
            }
            set
            {
                _PriceListID = value;
            }
        }

        [DataMember]
        public int? ProductID
        {
            get
            {
                return _ProductID;
            }
            set
            {
                _ProductID = value;
            }
        }

        [DataMember]
        public decimal Discount
        {
            get
            {
                return _Discount;
            }
            set
            {
                _Discount = value;
            }
        }

        [DataMember]
        public Product Product
        {
            get { return _product; }
            set { _product = value; }
        }
    }

    [DataContract]
    public class Product
    {
        private int _ID;
        private string _ProductCode;
        private string _Description;
        private int _UnitQty;
        private decimal _UnitPrice;
        private decimal _RRPPerItem;
        private bool _VatExempt;

        [DataMember]
        public int ID
        {
            get
            {
                return _ID;
            }
            set
            {
                _ID = value;
            }
        }

        [DataMember]
        public string ProductCode
        {
            get { return _ProductCode; }
            set { _ProductCode = value; }
        }

        [DataMember]
        public int UnitQty
        {
            get { return _UnitQty; }
            set { _UnitQty = value; }
        }

        [DataMember]
        public decimal UnitPrice
        {
            get { return _UnitPrice; }
            set { _UnitPrice = value; }
        }

        [DataMember]
        public string Description
        {
            get
            {
                return _Description;
            }
            set
            {
                _Description = value;
            }
        }

        [DataMember]
        public decimal RRPPerItem
        {
            get
            {
                return _RRPPerItem;
            }
            set
            {
                _RRPPerItem = value;
            }
        }

        [DataMember]
        public bool VatExempt
        {
            get
            {
                return _VatExempt;
            }
            set
            {
                _VatExempt = value;
            }
        }
    }

    [DataContract]
    public class SpecialInvoiceHeader
    {
        private int _ID;
        private int _CustomerID;
        private int _AccountID;
        private int _OutletStoreID;
        private int _VatCodeID;
        private short _AlphaPrefixOrPostFix;
        private string _AlphaID;
        private DateTime _OrderDate;
        private DateTime _DeliveryDate;
        private short _OrderStatus;
        private string _SpecialInstructions;
        private string _InvoiceNo;
        private string _ReasonForVoiding;
        private DateTime _DatePrinted;
        private DateTime _DateReprinted;
        private DateTime _DateCreated;
        private DateTime _DateModified;

        [DataMember]
        public int ID
        {
            get
            {
                return _ID;
            }
            set
            {
                _ID = value;
            }
        }

        [DataMember]
        public int CustomerID
        {
            get
            {
                return _CustomerID;
            }
            set
            {
                _CustomerID = value;
            }
        }

        [DataMember]
        public int AccountID
        {
            get
            {
                return _AccountID;
            }

            set
            {
                _AccountID = value;
            }
        }

        [DataMember]
        public int OutletStoreID
        {
            get
            {
                return _OutletStoreID;
            }

            set
            {
                _OutletStoreID = value;
            }
        }

        [DataMember]
        public int VatCodeID
        {
            get
            {
                return _VatCodeID;
            }

            set
            {
                _VatCodeID = value;
            }
        }

        [DataMember]
        public short AlphaPrefixOrPostFix
        {
            get
            {
                return _AlphaPrefixOrPostFix;
            }
            set
            {
                _AlphaPrefixOrPostFix = value;
            }
        }

        [DataMember]
        public string AlphaID
        {
            get
            {
                return _AlphaID;
            }
            set
            {
                _AlphaID = value;
            }
        }

        [DataMember]
        public DateTime OrderDate
        {
            get
            {
                return _OrderDate;
            }
            set
            {
                _OrderDate = value;
            }
        }

        [DataMember]
        public DateTime DeliveryDate
        {
            get
            {
                return _DeliveryDate;
            }
            set
            {
                _DeliveryDate = value;
            }
        }

        [DataMember]
        public DateTime DatePrinted
        {
            get
            {
                return _DatePrinted;
            }

            set
            {
                _DatePrinted = value;
            }
        }

        [DataMember]
        public DateTime DateReprinted
        {
            get
            {
                return _DateReprinted;
            }

            set
            {
                _DateReprinted = value;
            }
        }

        [DataMember]
        public short OrderStatus
        {
            get
            {
                return _OrderStatus;
            }
            set
            {
                _OrderStatus = value;
            }
        }

        [DataMember]
        public string SpecialInstructions
        {
            get
            {
                return _SpecialInstructions;
            }
            set
            {
                _SpecialInstructions = value;
            }
        }

        [DataMember]
        public string InvoiceNo
        {
            get
            {
                return _InvoiceNo;
            }
            set
            {
                _InvoiceNo = value;
            }
        }

        [DataMember]
        public DateTime DateCreated
        {
            get
            {
                return _DateCreated;
            }

            set
            {
                _DateCreated = value;
            }
        }

        [DataMember]
        public DateTime DateModified
        {
            get
            {
                return _DateModified;
            }
            set
            {
                _DateModified = value;
            }
        }

        [DataMember]
        public string ReasonForVoiding
        {
            get
            {
                return _ReasonForVoiding;
            }
            set
            {
                _ReasonForVoiding = value;
            }
        }
    }

    [DataContract]
    public class SpecialInvoiceLine
    {
        private int _ID;
        private int _SpecialInvoiceID;
        private string _Description;
        private short _OrderLineStatus;
        private int _QtyPerUnit;
        private int _NoOfUnits;
        private decimal _Discount;
        private decimal _Price;
        private string _SpecialInstructions;
        private bool _VatExempt;

        [DataMember]
        public int ID
        {
            get
            {
                return _ID;
            }
            set
            {
                _ID = value;
            }
        }

        [DataMember]
        public int SpecialInvoiceID
        {
            get
            {
                return _SpecialInvoiceID;
            }
            set
            {
                _SpecialInvoiceID = value;
            }
        }

        [DataMember]
        public string Description
        {
            get
            {
                return _Description;
            }
            set
            {
                _Description = value;
            }
        }

        [DataMember]
        public short OrderLineStatus
        {
            get
            {
                return _OrderLineStatus;
            }
            set
            {
                _OrderLineStatus = value;
            }
        }

        [DataMember]
        public int QtyPerUnit
        {
            get
            {
                return _QtyPerUnit;
            }
            set
            {
                _QtyPerUnit = value;
            }
        }

        [DataMember]
        public int NoOfUnits
        {
            get
            {
                return _NoOfUnits;
            }
            set
            {
                _NoOfUnits = value;
            }
        }

        [DataMember]
        public decimal Discount
        {
            get
            {
                return _Discount;
            }
            set
            {
                _Discount = value;
            }
        }

        [DataMember]
        public decimal Price
        {
            get
            {
                return _Price;
            }
            set
            {
                _Price = value;
            }
        }

        [DataMember]
        public string SpecialInstructions
        {
            get
            {
                return _SpecialInstructions;
            }
            set
            {
                _SpecialInstructions = value;
            }
        }

        [DataMember]
        public bool VatExempt
        {
            get
            {
                return _VatExempt;
            }

            set
            {
                _VatExempt = value;
            }
        }
    }

    [DataContract]
    public class StandardVatRate
    {
        private int _ID;
        private int _VatCodeID;

        [DataMember]
        public int ID
        {
            get
            {
                return _ID;
            }
            set
            {
                _ID = value;
            }
        }

        [DataMember]
        public int VatCodeID
        {
            get
            {
                return _VatCodeID;
            }
            set
            {
                _VatCodeID = value;
            }
        }
    }

    [DataContract]
    public class Terms
    {
        private string _Description;
        private int _id;
        private Account _Account;

        [DataMember]
        public int ID
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        [DataMember]
        public string Description
        {
            get
            {
                return _Description;
            }
            set
            {
                _Description = value;
            }
        }

        [DataMember]
        public Account Account
        {
            get
            {
                return _Account;
            }
            set
            {
                _Account = value;
            }
        }
    }

    [DataContract]
    public class VatCode
    {
        private string _Code;
        private string _Description;
        private int _id;
        private float _PercentageValue;
        private bool _VatExemptible;

        [DataMember]
        public int ID
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        [DataMember]
        public string Code
        {
            get
            {
                return _Code;
            }
            set
            {
                _Code = value;
            }
        }

        [DataMember]
        public string Description
        {
            get
            {
                return _Description;
            }
            set
            {
                _Description = value;
            }
        }

        [DataMember]
        public float PercentageValue
        {
            get { return _PercentageValue; }
            set { _PercentageValue = value; }
        }

        [DataMember]
        public bool VatExemptible
        {
            get { return _VatExemptible; }
            set { _VatExemptible = value; }
        }

        [DataMember]
        public System.Data.Linq.Binary Version
        {
            get;
            set;
        }
    }

    [DataContract]
    public class Van
    {
        private string _Description;
        private int _id;
        private int _MaximumReccomendedParcelCount;

        [DataMember]
        public int ID
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        [DataMember]
        public string Description
        {
            get
            {
                return _Description;
            }
            set
            {
                _Description = value;
            }
        }

        [DataMember]
        public int MaximumReccomendedParcelCount
        {
            get
            {
                return _MaximumReccomendedParcelCount;
            }
            set
            {
                _MaximumReccomendedParcelCount = value;
            }
        }
    }

    [DataContract]
    public class VanInvoiceCount
    {
        [DataMember]
        public string VanDescription { get; set; }

        [DataMember]
        public int InvoiceCount { get; set; }
    }

    #endregion
}
