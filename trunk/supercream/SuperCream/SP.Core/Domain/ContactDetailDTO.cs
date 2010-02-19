using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SP.Core.Domain
{
    [Serializable]
    public class ContactDetail : BaseEntity
    {
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

        public Customer Customer
        {
            get { return _Customer; }
            set { _Customer = value; }
        }

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
}
