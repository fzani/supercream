using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SP.Core.Domain
{
    [Serializable]
    public class FoundationFacility : BaseEntity
    {
        private string _CompanyName;
        private string _VatRegistrationNumber;
        private string _OfficePhoneNumber1;
        private string _OfficePhoneNumber2;
        private string _EMailAddress;

        private int _AddressID;
        Address _Address;

        public FoundationFacility()
        {
            _Address = new Address();
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
}
