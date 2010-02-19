using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SP.Core.Domain
{
    [Serializable]
    public class Address : BaseEntity
    {
        private short _AddressType;
        private string _AddressLines;
        private string _Town;
        private string _County;
        private string _PostCode;
        private string _MapReference;

        private FoundationFacility _FoundationFacility;
        private Account _Account;
        private int _AccountID;

        private OutletStore _outLetStore;
        private int outletID;

        public Address()
        {
        }

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

        public int OutletID
        {
            get { return outletID; }
            set { outletID = value; }
        }

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

        public string MapReference
        {
            get
            {
                return
                    _MapReference;
            }
            set
            {
                _MapReference = value;
            }
        }

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

        public FoundationFacility FoundationFacility
        {
            get
            {
                return this._FoundationFacility;
            }
            set
            {
                this._FoundationFacility = value;
                // this.FoundationFacilityID = value.ID;
            }
        }

        public OutletStore OutletStore
        {
            get
            {
                return this._outLetStore;
            }
            set
            {
                this._outLetStore = value;
            }
        }

        public int AccountID
        {
            get { return _AccountID; }
            set { _AccountID = value; }
        }

        public Account Account
        {
            get { return _Account; }
            set
            {
                _Account = value;
                if (_Account != null)
                    _Account.InvoiceAddressID = ID;
            }
        }

    }
}
