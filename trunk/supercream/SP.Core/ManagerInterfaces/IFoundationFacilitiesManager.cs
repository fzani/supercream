using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SP.Core.Domain;

namespace SP.Core.ManagerInterfaces
{
    public interface IFoundationFacilitiesManager
    {
        #region Accounts
        bool AlphaIDExists(string id);
        Account SaveAccount(Account account);
        List<Account> GetAllAccounts();
        List<Account> GetAccountsByCustomerId(int id);
        Account GetAccountByAlphaID(string id);
        Account GetAccount(int id);
        Account UpdateAccount(Account newAccount, Account origAccount);
        void DeleteAccount(Account cde);
        #endregion

        #region Address
        void DeleteAddress(Address address);
        Address GetAddress(int id);
        Address SaveAddress(Address address);
        Address UpdateAddress(Address newAddress, Address origAddress);
        #endregion

        #region AutoGen
        int Generate();
        #endregion

        #region AuditEvents

        void ArchiveAuditEvents();
        List<string> AuditEventDescriptions();
        void DeleteAuditEvents(AuditEvents auditevents);
        List<AuditEvents> GetAllAuditEvents(string description, string creator, DateTime createdDate);
        AuditEvents GetAuditEvents(int id);
        List<AuditEvents> GetAllAuditEventss();
        AuditEvents SaveAuditEvents(AuditEvents auditevents);
        AuditEvents UpdateAuditEvents(AuditEvents newAuditEvents, AuditEvents origAuditEvents);

        #endregion

        #region ContactDetails
        void DeleteContactDetail(ContactDetail contactDetail);
        ContactDetail GetContactDetailByID(int id);
        List<ContactDetail> GetContactDetailsByCustomer(int id);
        ContactDetail SaveContactDetail(ContactDetail contactDetail);
        ContactDetail SaveContactDetail(ContactDetail contactDetail, object DataContext);
        ContactDetail UpdateContactDetail(ContactDetail newContactDetail, ContactDetail origContactDetail);
        #endregion

        #region CreditNote

        bool CreditNoteExistsByOrderId(int orderId);
        InvoiceCreditNoteDetails GetInvoiceCreditDetails(int orderID);
        void DeleteCreditNote(CreditNote creditnote);
        CreditNote GetCreditNote(int id);
        List<CreditNote> GetAllCreditNotes();
        CreditNote SaveCreditNote(CreditNote creditnote);
        CreditNote UpdateCreditNote(CreditNote newCreditNote, CreditNote origCreditNote);
        decimal GetOustandingCreditNoteBalance(int orderNo, int creditNote, decimal vatRate);
        List<CreditNoteDetails> SearchCreditNotes(string orderNo, string invoiceNo, string customerName, DateTime dateFrom, DateTime dateTo);
        List<CreditNote> GetCreditNotesByOrderId(int creditNoteId);

        List<OrderLine> AvailableOrderLinesForCreditNote(int orderId);
        #endregion

        #region Customer
        bool CustomerExistsByName(string name);
        bool CustomerExistsWithNameLike(string name);
        void DeleteCustomer(int customerID);
        List<Account> GetAccountsByCustomerID(int id);
        List<Customer> GetCustomersByAccountNameLike(string name);
        List<Customer> GetAllCustomers();
        List<Customer> GetByTelehoneNoLike(string telephoneNo);
        Customer GetCustomerByID(int id);
        Customer GetCustomerByName(string name);
        List<Customer> GetCustomerByNameLike(string name);
        Customer GetCustomerWithContacts(int id);
        Customer GetCustomerWithOutletStores(int id1);

        Customer SaveCustomer(Customer customer);
        Customer UpdateCustomer(Customer newCustomer, Customer origCustomer);

        #endregion

        #region Foundation Facility
        FoundationFacility SaveFoundationFacility(FoundationFacility ff);
        bool FoundationFacilityExists();
        FoundationFacility GetFoundationFacility();
        FoundationFacility UpdateFoundationFacility(FoundationFacility newFoundationfacility, FoundationFacility origFoundationFacility);
        #endregion

        #region OrderCreditNote

        bool OrderCreditNoteExistsByOrderId(int orderId);
        List<OrderCreditNote> GetOrderCreditNotesByOrderId(int orderId);
        void DeleteOrderCreditNote(OrderCreditNote ordercreditnote);
        OrderCreditNote GetOrderCreditNote(int id);
        List<OrderCreditNote> GetAllOrderCreditNotes();
        OrderCreditNote SaveOrderCreditNote(OrderCreditNote orderCreditNote);
        OrderCreditNote UpdateOrderCreditNote(OrderCreditNote newOrderCreditNote, OrderCreditNote origOrderCreditNote);
        List<CreditNoteDetails> SearchOrderCreditNotes(string orderNo, string invoiceNo, string customerName, DateTime dateFrom, DateTime dateTo);
        InvoiceCreditNoteDetails GetOrderHeaderInvoiceCreditDetails(int orderNo);
        #endregion

        #region OrderCreditNoteLine

        List<OrderCreditNoteLine> GetOrderCreditNoteLinesByCreditNoteId(int creditNoteId);
        int GetAvailableNoOfUnitsOnOrderLine(int orderLineId);
        bool CheckIfOrderLineAlreadyExistsForCreditNotes(int orderLineId);
        OrderCreditNoteLine GetCreditNoteLineByOrderIdAndOrderLineId(int creditNoteid, int orderLineId);
        void DeleteOrderCreditNoteLine(OrderCreditNoteLine ordercreditnoteline);
        OrderCreditNoteLine GetOrderCreditNoteLine(int id);
        List<OrderCreditNoteLine> GetAllOrderCreditNoteLines();
        OrderCreditNoteLine SaveOrderCreditNoteLine(OrderCreditNoteLine ordercreditnoteline);
        OrderCreditNoteLine UpdateOrderCreditNoteLine(OrderCreditNoteLine newOrderCreditNoteLine, OrderCreditNoteLine origOrderCreditNoteLine);
        bool CheckIfCreditNoteLineExists(int creditNoteid, int orderLineId);
        decimal GetOrderCreditNoteLineAvailableTotal(int orderCreditNoteId);

        #endregion

        #region OrderHeader

        decimal GetOrderExVatTotal(int orderId);
        OrderHeader CreateInvoice(OrderHeader newOrderHeader, OrderHeader origOrderHeader);
        OrderHeader CreateInvoiceProforma(OrderHeader newOrderHeader, OrderHeader origOrderHeader);
        OrderHeader CreateDeliveryNote(OrderHeader newOrderHeader, OrderHeader origOrderHeader);
        void VoidOrder(int orderID, string reasonForVoiding);

        List<InvoiceWithStatus> GetInvoicesWithStatus(string orderNo, string invoiceNo, string customerName, DateTime dateFrom, DateTime dateTo, short orderStatus);
        bool OrderHeaderExists(string orderNo);
        bool InvoiceNoExists(string invoiceNo);
        void DeleteOrderHeader(SP.Core.Domain.OrderHeader orderHeader);
        SP.Core.Domain.OrderHeader GetOrderHeader(int id);
        SP.Core.Domain.OrderHeader GetOrderHeaderWithVatCode(int id);
        OrderHeader GetOrderHeaderByOrderNo(string orderNo);
        List<OrderHeader> GetOrderHeaderForSearch(string orderNo, string invoiceNo, string customerName, DateTime dateFrom, DateTime dateTo, short orderStatus);
        List<OrderHeader> GetOrderHeaderForSearchWithPrintedOrderStatuses(string orderNo, string invoiceNo, string customerName, DateTime dateFrom, DateTime dateTo, short actualOrderStatus, short printedOrderStatus);
        List<OrderHeader> SearchInvoices(string orderNo, string invoiceNo, string customerName, DateTime dateFrom,
                                         DateTime dateTo, short actualOrderStatus, short printedOrderStatus);
        List<SP.Core.Domain.OrderHeader> GetAllOrderHeaders();
        SP.Core.Domain.OrderHeader SaveOrderHeader(OrderHeader orderHeader);
        OrderHeader UpdateOrderHeader(OrderHeader newOrderHeader, OrderHeader origOrderHeader);
        void UpdatePaymentCompleted(int orderID, bool invoicePaymentComplete);
        #endregion

        #region OrderLine
        void DeleteOrderLine(SP.Core.Domain.OrderLine orderLine);
        SP.Core.Domain.OrderLine GetOrderLine(int id);
        List<OrderLine> GetOrderLinesByOrderID(int id);
        SP.Core.Domain.OrderLine SaveOrderLine(OrderLine orderLine);
        OrderLine UpdateOrderLine(OrderLine newOrderLine, OrderLine origOrderLine);
        #endregion

        #region OrderNotesStatus
        void DeleteOrderNotesStatus(OrderNotesStatus ordernotesstatus);
        OrderNotesStatus GetOrderNotesStatus(int id);
        List<OrderNotesStatus> GetAllOrderNotesStatuss();
        bool OrderNoteStatusByOrderIDExists(int orderID);
        OrderNotesStatus GetOrderNoteStatusByOrderId(int id);
        OrderNotesStatus SaveOrderNotesStatus(OrderNotesStatus ordernotesstatus);
        OrderNotesStatus UpdateOrderNotesStatus(OrderNotesStatus newOrderNotesStatus, OrderNotesStatus origOrderNotesStatus);
        List<VanDeliveryItem> InvoicesByDateAndVan(DateTime deliveryDate, int vanId);
        void UpdateVanForInvoice(int orderID, int vanID);
        List<VanInvoiceCount> GetVanInvoiceCount(DateTime deliveryDate);
        #endregion

        #region OutletStores
        void DeleteOutletStore(SP.Core.Domain.OutletStore store);
        SP.Core.Domain.OutletStore GetOutletStore(int id);
        SP.Core.Domain.OutletStore SaveOutletStore(OutletStore store);
        OutletStore UpdateOutletStore(OutletStore newOutletStore, OutletStore origOutletStore);
        #endregion

        #region Phone
        void DeletePhone(Phone phone);
        Phone GetPhoneById(int id);
        Phone SavePhone(Phone phone, object DataContext);
        Phone SavePhone(Phone phone);
        #endregion

        #region PhoneNoTypes
        PhoneNoType GetPhoneNoTypeById(int id);
        PhoneNoType GetPhoneNoTypeById(int id, object DataContext);
        #endregion

        #region PriceListHeader
        void DeletePriceList(PriceListHeader hdr);
        PriceListHeader SavePriceListHeader(PriceListHeader priceListHeader);
        List<PriceListHeader> GetAllPriceListHeaders();
        PriceListHeader GetPriceListHeaderByID(int id);
        PriceListHeader UpdatePriceListHeader(PriceListHeader newPriceListHeader, PriceListHeader origPriceListHeader);
        #endregion

        #region PriceListItem
        PriceListItem GetPriceListItemById(int id);
        PriceListItem GetPriceListItemByProductId(int priceListID, int productId);
        PriceListItem SavePriceListItem(PriceListItem priceListItem);
        void DeletePriceListItemByProductId(int priceListID, int productId);
        List<PriceListItem> GetPriceListItemByPriceListHeader(int id);
        void DeletePriceListItemByID(int priceListItem);
        PriceListItem UpdatePriceListItem(PriceListItem newProduct, PriceListItem origProduct);
        #endregion

        #region Product
        Product SaveProduct(Product product);
        void DeleteProduct(Product product);
        List<Product> GetAllProducts();
        Product GetProduct(int id);
        Product UpdateProduct(Product newProduct, Product origProduct);
        Product GetProductByProductCode(string code);
        bool ProductCodeExists(string productCode);
        List<Product> GetLikeProductCode(string productCode);
        List<Product> GetLikeProductDescription(string productDescription);
        List<Product> GetProductsInPriceList(int id);
        List<Product> GetProductsOutOfProductList(int id);

        #endregion

        #region StandardVatRate
        bool StandardVatRateExists();
        void DeleteStandardVatRate(StandardVatRate standardvatrate);
        StandardVatRate GetStandardVatRate();
        List<StandardVatRate> GetAllStandardVatRates();
        StandardVatRate SaveStandardVatRate(StandardVatRate standardvatrate);
        StandardVatRate UpdateStandardVatRate(StandardVatRate newStandardVatRate, StandardVatRate origStandardVatRate);
        #endregion

        #region Vat Codes
        void DeleteVatCode(SP.Core.Domain.VatCode cde);
        System.Collections.Generic.List<SP.Core.Domain.VatCode> GetAllVatCodes();
        VatCode SaveVatCode(SP.Core.Domain.VatCode cde);
        VatCode GetVatCode(int id);
        VatCode UpdateVatCode(VatCode newVatCode, VatCode origVatCode);
        bool VatCodeExists(string vatCode);
        bool ExemptCodeExists();
        #endregion

        #region SpecialInvoiceCreditNote
        void DeleteSpecialInvoiceCreditNote(SpecialInvoiceCreditNote specialinvoicecreditnote);
        SpecialInvoiceCreditNote GetSpecialInvoiceCreditNote(int id);
        List<SpecialInvoiceCreditNote> GetAllSpecialInvoiceCreditNotes();
        SpecialInvoiceCreditNote SaveSpecialInvoiceCreditNote(SpecialInvoiceCreditNote specialinvoicecreditnote);
        SpecialInvoiceCreditNote UpdateSpecialInvoiceCreditNote(SpecialInvoiceCreditNote newSpecialInvoiceCreditNote, SpecialInvoiceCreditNote origSpecialInvoiceCreditNote);

        List<SpecialInvoiceCreditNoteDetails> SearchSpecialInvoiceCreditNotes(
          string orderNo, string invoiceNo,
          string customerName,
          DateTime dateFrom,
          DateTime dateTo);

        List<SpecialInvoiceCreditNote> GetSpecialInvoiceCreditNotesByInvoiceId(int orderId);

        string GenerateSpecialInvoiceCreditNo();
        SpecialInvoiceCreditNoteBalance GetSpecialInvoiceCreditBalance(int specialInvoiceId);
        decimal GetSpecialInvoiceOustandingBalance(int orderNo, int creditNote, decimal vatRate);
        bool SpecialInvoiceCreditNoteExistsByOrderId(int orderId);
        bool ReferenceExists(string referenceNo);
        SpecialInvoiceCreditNote SpecialInvoieceGetByReferenceId(string reference);
        #endregion

        #region SpecialInvoiceHeader
        void DeleteSpecialInvoiceHeader(SpecialInvoiceHeader specialinvoiceheader);
        SpecialInvoiceHeader GetSpecialInvoiceHeader(int id);
        List<SpecialInvoiceHeader> GetSpecialHeaders(string orderNo,
          string invoiceNo,
          string customerName,
          DateTime dateFrom,
          DateTime dateTo,
          short orderStatus);
        List<SpecialInvoiceHeader> GetAllSpecialInvoiceHeaders();
        SpecialInvoiceHeader SaveSpecialInvoiceHeader(SpecialInvoiceHeader specialinvoiceheader);
        SpecialInvoiceHeader UpdateSpecialInvoiceHeader(SpecialInvoiceHeader newSpecialInvoiceHeader, SpecialInvoiceHeader origSpecialInvoiceHeader);
        #endregion

        #region SpecialInvoiceLine
        List<SpecialInvoiceLine> GetBySpecialInvoiceId(int id);
        void DeleteSpecialInvoiceLine(SpecialInvoiceLine SpecialInvoiceLine);
        SpecialInvoiceLine GetSpecialInvoiceLine(int id);
        List<SpecialInvoiceLine> GetAllSpecialInvoiceLines();
        SpecialInvoiceLine SaveSpecialInvoiceLine(SpecialInvoiceLine SpecialInvoiceLine);
        SpecialInvoiceLine UpdateSpecialInvoiceLine(SpecialInvoiceLine newSpecialInvoiceLine, SpecialInvoiceLine origSpecialInvoiceLine);
        #endregion

        #region Terms
        void DeleteTerm(SP.Core.Domain.Terms cde);
        System.Collections.Generic.List<Terms> GetAllTerms();
        Terms SaveTerm(Terms cde);
        Terms GetTerm(int id);
        Terms UpdateTerm(Terms newVatCode, Terms origVatCode);
        #endregion

        #region Van
        void DeleteVan(Van van);
        List<Van> GetAllVans();
        Van SaveVan(Van van);
        Van GetVan(int id);
        Van UpdateVan(Van newVan, Van origVan);
        #endregion
    }
}
