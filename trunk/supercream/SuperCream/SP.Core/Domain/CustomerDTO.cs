using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SP.Core.Domain
{
    [Serializable]
    public class Customer : BaseEntity
    {
        private string _Name;
        private string _VatRegistrationNumber;
        private int _PriceListHeaderID;

        private List<OutletStore> _OutletStore;
        private List<Note> _Note;
        private List<ContactDetail> _ContactDetail;
        private List<Account> _Account;

        public Customer()
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

        public List<Note> Note
        {
            get 
            { 
                return _Note; 
            }
            set 
            { 
                _Note = value;
                foreach (var note in _Note)
                {
                    note.ParentNoteID = ID;
                    note.Customer = this;
                }
            }
        }

        public List<ContactDetail> ContactDetail
        {
            get 
            { 
                return _ContactDetail; 
            }
            set 
            { 
                _ContactDetail = value;
                foreach (var contactDetail in _ContactDetail)
                {
                    contactDetail.CustomerID = ID;
                    contactDetail.Customer = this;
                }
            }
        }

        public int PriceListHeaderID
        {
            get { return _PriceListHeaderID; }
            set { _PriceListHeaderID = value; }
        }

        public List<Account> Account
        {
            get 
            { 
                return _Account; 
            }
            set 
            { 
                _Account = value;
                foreach (var account in _Account)
                {
                    account.CustomerID = ID;
                    account.Customer = this;
                }
            }
        }

        public List<OutletStore> OutletStore
        {
            get
            {
                return _OutletStore;
            }
            set
            {
                _OutletStore = value;
                //if (_Outlet != null)
                //{
                foreach (var outlet in _OutletStore)
                    {
                        outlet.CustomerID = ID;
                        outlet.Customer = this;
                    }
               // }
            }
        }
    }
}
