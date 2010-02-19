using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SP.Core.Domain
{
    [Serializable]
    public class Outlet : BaseEntity
    {
        private int?     _CustomerID;
        private int?  _AddressID;
      
        private string  _Name;
        private short   _OpeningHoursStart;
        private short   _OpeningHoursClose;
        private string  _Notes;
        
     //   private Address  _Address;
        private Customer  _Customer;

        public Outlet()
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

        public int? AddressID
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

        public short OpeningHoursStart
        {
            get
            {
                return _OpeningHoursStart;
            }
            set
            {
                _OpeningHoursStart = value;
            }
        }

        public short OpeningHoursClose
        {
            get
            {
                return _OpeningHoursClose;
            }
            set
            {
                _OpeningHoursClose = value;
            }
        }

        public string Notes
        {
            get
            {
                return _Notes;
            }
            set
            {
                _Notes = value;
            }
        }

        //public Address Address
        //{
        //    get
        //    {
        //        return _Address;
        //    }
        //    set
        //    {
        //        _Address = value;
        //        _Address.OutLet = this;
        //    }
        //}

        public Customer Customer
        {
            get 
            { 
                return this._Customer; 
            }
            set 
            { 
                this._Customer = value;
                //if (this.Customer != null)
                //    this.CustomerID = value.ID;
            }
        }
    }
}
