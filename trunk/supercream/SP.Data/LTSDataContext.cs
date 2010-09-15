using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Reflection;
using System.Linq.Expressions;
using System.ComponentModel;
using System.Configuration;
using System.Text;

using SP.Core;
using SP.Core.Domain;

namespace SP.Data.LTS
{
    public sealed class LTSDataContext : System.Data.Linq.DataContext
    {
        static XmlMappingSource map = XmlMappingSource.FromXml(System.IO.File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "\\App_Data\\SP.map"));
        // static XmlMappingSource map = XmlMappingSource.FromXml(System.IO.File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "\\SP.map"));
        static string connectionString = ConfigurationManager.ConnectionStrings["LTSDBConnection"].ToString();

        public LTSDataContext() :
            base(connectionString, map)
        {
        }

        public LTSDataContext(string connection)
            : base(connection, map)
        {
        }

        public LTSDataContext(string connection, XmlMappingSource map)
            : base(connection, map)
        {
        }

        public System.Data.Linq.Table<CreditNote> CreditNote
        {
            get
            {
                return this.GetTable<CreditNote>();
            }
        }

        public System.Data.Linq.Table<PriceListItem> PriceListItem
        {
            get
            {
                return this.GetTable<PriceListItem>();
            }
        }

        public System.Data.Linq.Table<Product> Product
        {
            get
            {
                return this.GetTable<Product>();
            }
        }

        public System.Data.Linq.Table<Terms> Terms
        {
            get
            {
                return this.GetTable<Terms>();
            }
        }

        public System.Data.Linq.Table<VatCode> VatCode
        {
            get
            {
                return this.GetTable<VatCode>();
            }
        }

        public System.Data.Linq.Table<Account> Account
        {
            get
            {
                return this.GetTable<Account>();
            }
        }

        public System.Data.Linq.Table<Address> Address
        {
            get
            {
                return this.GetTable<Address>();
            }
        }

        public System.Data.Linq.Table<AutoGen> AutoGen
        {
            get
            {
                return this.GetTable<AutoGen>();
            }
        }

        public System.Data.Linq.Table<AuditEvents> AuditEvents
        {
            get
            {
                return this.GetTable<AuditEvents>();
            }
        }

        public System.Data.Linq.Table<ContactDetail> ContactDetail
        {
            get
            {
                return this.GetTable<ContactDetail>();
            }
        }

        public System.Data.Linq.Table<Customer> Customer
        {
            get
            {
                return this.GetTable<Customer>();
            }
        }

        public System.Data.Linq.Table<DeliveryItem> DeliveryItem
        {
            get
            {
                return this.GetTable<DeliveryItem>();
            }
        }

        public System.Data.Linq.Table<FoundationFacility> FoundationFacility
        {
            get
            {
                return this.GetTable<FoundationFacility>();
            }
        }

        public System.Data.Linq.Table<InvoiceHeader> InvoiceHeader
        {
            get
            {
                return this.GetTable<InvoiceHeader>();
            }
        }

        public System.Data.Linq.Table<InvoiceItem> InvoiceItem
        {
            get
            {
                return this.GetTable<InvoiceItem>();
            }
        }

        public System.Data.Linq.Table<Note> Note
        {
            get
            {
                return this.GetTable<Note>();
            }
        }

        public System.Data.Linq.Table<OrderHeader> OrderHeader
        {
            get
            {
                return this.GetTable<OrderHeader>();
            }
        }

        public System.Data.Linq.Table<OrderLine> OrderLine
        {
            get
            {
                return this.GetTable<OrderLine>();
            }
        }

        public System.Data.Linq.Table<OrderCreditNote> OrderCreditNote
        {
            get
            {
                return this.GetTable<OrderCreditNote>();
            }
        }

        public System.Data.Linq.Table<OrderCreditNoteLine> OrderCreditNoteLine
        {
            get
            {
                return this.GetTable<OrderCreditNoteLine>();
            }
        }

        public System.Data.Linq.Table<OrderNotesStatus> OrderNotesStatus
        {
            get
            {
                return this.GetTable<OrderNotesStatus>();
            }
        }

        public System.Data.Linq.Table<Outlet> Outlet
        {
            get
            {
                return this.GetTable<Outlet>();
            }
        }

        public System.Data.Linq.Table<OutletStore> OutletStore
        {
            get
            {
                return this.GetTable<OutletStore>();
            }
        }

        public System.Data.Linq.Table<Phone> Phone
        {
            get
            {
                return this.GetTable<Phone>();
            }
        }

        public System.Data.Linq.Table<PhoneNoType> PhoneNoType
        {
            get
            {
                return this.GetTable<PhoneNoType>();
            }
        }

        public System.Data.Linq.Table<PriceListHeader> PriceListHeader
        {
            get
            {
                return this.GetTable<PriceListHeader>();
            }
        }

        public System.Data.Linq.Table<SpecialInvoiceCreditNote> SpecialInvoiceCreditNote
        {
            get
            {
                return this.GetTable<SpecialInvoiceCreditNote>();
            }
        }

        public System.Data.Linq.Table<SpecialInvoiceHeader> SpecialInvoiceHeader
        {
            get
            {
                return this.GetTable<SpecialInvoiceHeader>();
            }
        }

        public System.Data.Linq.Table<SpecialInvoiceLine> SpecialInvoiceLine
        {
            get
            {
                return this.GetTable<SpecialInvoiceLine>();
            }
        }

        public System.Data.Linq.Table<StandardVatRate> StandardVatRate
        {
            get
            {
                return this.GetTable<StandardVatRate>();
            }
        }

        public System.Data.Linq.Table<Van> Van
        {
            get
            {
                return this.GetTable<Van>();
            }
        }
    }
}
