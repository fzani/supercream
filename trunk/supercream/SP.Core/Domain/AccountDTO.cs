using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SP.Core.Domain
{
    [Serializable]
    public class Account : BaseEntity
    {
        private string _AlphaID;
        private int _ContactDetailID;
        private string _CompanyToInvoiceTo;

        private int? _InvoiceAddressID;
        private Address _Address;

        private Customer _Customer;
        private int? _CustomerID;

        private Terms _Terms;
        private int? _TermTypeID;

        private OrderNotesStatus _OrderNotesStatus;

        public override int ID
        {
            get
            {
                return base.ID;
            }
            set
            {
                base.ID = value;
            }
        }

        public int ContactDetailID
        {
            get { return _ContactDetailID; }
            set { _ContactDetailID = value; }
        }

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

        public string CompanyToInvoiceTo
        {
            get { return _CompanyToInvoiceTo; }
            set { _CompanyToInvoiceTo = value; }
        }

        public Customer Customer
        {
            get { return _Customer; }
            set { _Customer = value; }
        }

        public Address Address
        {
            get { return _Address; }
            set
            {
                _Address = value;
                if (_Address != null)
                    _Address.Account = this;
            }
        }

        public Terms Terms
        {
            get { return _Terms; }
            set { _Terms = value; }
        }

        public OrderNotesStatus OrderNotesStatus
        {
            get
            {
                return _OrderNotesStatus;
            }
            set
            {
                _OrderNotesStatus = value;
                if (value != null)
                    _OrderNotesStatus.Account = this;
            }
        }
    }
}
