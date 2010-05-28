using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SP.Core.Domain;

namespace SP.Core.DataInterfaces
{
    public interface IDaoFactory
    {
        IAddressDao GetAddressDao();
        IAutogenDao GetAutoGenDao();
        IOrderLineDao GetOrderLineDao();
        IOrderNotesStatusDao GetOrderNotesStatusDao();
        IPriceListItemDao GetPriceListItemDao();
        IAccountDao GetAccountDao();
        IContactDetailDao GetContactDetailDao();
        ICreditNoteDao GetCreditNoteDao();
        ICustomerDao GetCustomerDao();
        IDeliveryItemDao GetDeliveryItemDao();
        IFoundationFacilityDao GetFoundationFacilityDao();
        IInvoiceHeaderDao GetInvoiceHeaderDao();
        IInvoiceItemDao GetInvoiceItemDao();
        INoteDao GetNoteDao();
        IOrderHeaderDao GetOrderHeaderDao();
        IOrderCreditNoteDao GetOrderCreditNoteDao();
        IOrderCreditNoteLineDao GetOrderCreditNoteLineDao();
        IOutletDao GetOutletDao();
        IOutletStoreDao GetOutletStoreDao();
        IPhoneDao GetPhoneDao();
        IPhoneNoTypeDao GetPhoneNoTypeDao();
        IPriceListHeaderDao GetPriceListHeaderDao();
        IProductDao GetProductDao();
        IProformaInvoiceDao GetProformaInvoiceDao();
        ISpecialInvoiceCreditNoteDao GetSpecialInvoiceCreditNoteDao();
        ISpecialInvoiceHeaderDao GetSpecialInvoiceHeaderDao();
        ISpecialInvoiceLineDao GetSpecialInvoiceLineDao();
        IStandardVatRateDao GetStandardVatRateDao();
        ITermsDao GetTermsDao();
        IVanDao GetVanDao();
        IVatCodeDao GetVatCodeDao();
    }

    #region Inline Interface Declarations

    #endregion
}
