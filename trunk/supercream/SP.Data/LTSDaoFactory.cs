using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SP.Core.DataInterfaces;
using SP.Core.Domain;
using SP.Core;

namespace SP.Data.LTS
{
    public class LTSDaoFactory : IDaoFactory
    {
        #region IDaoFactory Members

        public IAddressDao GetAddressDao()
        {
            return new AddressDao();
        }

        public IAutogenDao GetAutoGenDao()
        {
            return new AutoGenDao();
        }

        public IAuditEventsDao GetAuditEventsDao()
        {
            return new AuditEventsDao();
        }

        public ICreditNoteDao GetCreditNoteDao()
        {
            return new CreditNoteDao();
        }

        public IOrderLineDao GetOrderLineDao()
        {
            return new OrderLineDao();
        }

        public IPriceListItemDao GetPriceListItemDao()
        {
            return new PriceListItemDao();
        }

        public IPhoneNoTypeDao GetPhoneNoTypeDao()
        {
            return new PhoneNoTypeDao();
        }

        public IPhoneDao GetPhoneDao()
        {
            return new PhoneDao();
        }

        public IAccountDao GetAccountDao()
        {
            return new AccountDao();
        }

        public IContactDetailDao GetContactDetailDao()
        {
            return new ContactDetailDao();
        }

        public ICustomerDao GetCustomerDao()
        {
            return new CustomerDao();
        }

        public IDeliveryItemDao GetDeliveryItemDao()
        {
            return new DeliveryItemDao();
        }

        public IFoundationFacilityDao GetFoundationFacilityDao()
        {
            return new FoundationFacilityDao();
        }

        public IInvoiceHeaderDao GetInvoiceHeaderDao()
        {
            return new InvoiceHeaderDao();
        }

        public IInvoiceItemDao GetInvoiceItemDao()
        {
            return new InvoiceItemDao();
        }

        public INoteDao GetNoteDao()
        {
            return new NoteDao();
        }

        public IOrderCreditNoteDao GetOrderCreditNoteDao()
        {
            return new OrderCreditNoteDao();
        }

        public IOfferDao GetOfferDao()
        {
            return new OfferDao();
        }

        public IOfferItemDao GetOfferItemDao()
        {
            return new OfferItemDao();
        }

        public IOfferQualificationItemDao GetOfferQualificationItemDao()
        {
            return new OfferQualificationItemDao();
        }

        public IOrderCreditNoteLineDao GetOrderCreditNoteLineDao()
        {
            return new OrderCreditNoteLineDao();
        }

        public IOrderHeaderDao GetOrderHeaderDao()
        {
            return new OrderHeaderDao();
        }

        public IOrderNotesStatusDao GetOrderNotesStatusDao()
        {
            return new OrderNotesStatusDao();
        }

        public IOutletDao GetOutletDao()
        {
            return new OutletDao();
        }

        public IOutletStoreDao GetOutletStoreDao()
        {
            return new OutletStoreDao();
        }

        public IPriceListHeaderDao GetPriceListHeaderDao()
        {
            return new PriceListHeaderDao();
        }

        public IProductDao GetProductDao()
        {
            return new ProductDao();
        }

        public IProformaInvoiceDao GetProformaInvoiceDao()
        {
            return new ProformaInvoiceDao();
        }

        public ISpecialInvoiceCreditNoteDao GetSpecialInvoiceCreditNoteDao()
        {
            return new SpecialInvoiceCreditNoteDao();
        }

        public ISpecialInvoiceHeaderDao GetSpecialInvoiceHeaderDao()
        {
            return new SpecialInvoiceHeaderDao();
        }

        public ISpecialInvoiceLineDao GetSpecialInvoiceLineDao()
        {
            return new SpecialInvoiceLineDao();
        }

        public IStandardVatRateDao GetStandardVatRateDao()
        {
            return new StandardVatRateDao();
        }

        public ITermsDao GetTermsDao()
        {
            return new TermsDao();
        }

        public IVatCodeDao GetVatCodeDao()
        {
            return new VatCodeDao();
        }

        public IVanDao GetVanDao()
        {
            return new VanDao();
        }

        #endregion
    }
}
