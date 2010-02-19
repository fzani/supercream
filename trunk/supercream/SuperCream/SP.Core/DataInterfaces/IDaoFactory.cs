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
        ICustomerDao GetCustomerDao();
        IDeliveryItemDao GetDeliveryItemDao();
        IFoundationFacilityDao GetFoundationFacilityDao();
        IInvoiceHeaderDao GetInvoiceHeaderDao();
        IInvoiceItemDao GetInvoiceItemDao();
        INoteDao GetNoteDao();
        IOrderHeaderDao GetOrderHeaderDao();
        IOutletDao GetOutletDao();
        IOutletStoreDao GetOutletStoreDao();
        IPhoneDao GetPhoneDao();
        IPhoneNoTypeDao GetPhoneNoTypeDao();
        IPriceListHeaderDao GetPriceListHeaderDao();
        IProductDao GetProductDao();
        IProformaInvoiceDao GetProformaInvoiceDao();
        ISpecialInvoiceHeaderDao GetSpecialInvoiceHeaderDao();
        ISpecialInvoiceLineDao GetSpecialInvoiceLineDao();
        ITermsDao GetTermsDao();
        IVanDao GetVanDao();
        IVatCodeDao GetVatCodeDao();
    }

    #region Inline Interface Declarations

    #endregion
}
