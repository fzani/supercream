using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SP.Core.Domain
{
    [Serializable]
    public class Product : BaseEntity
    {        
        private string _ProductCode;
        private string _Description;
        private int _UnitQty;
        private decimal _UnitPrice;
        private decimal _RRPPerItem;
        private VatCode _VatCode;
        private bool _VatExempt;

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

        public string ProductCode
        {
            get { return _ProductCode; }
            set { _ProductCode = value; }
        }

        public int UnitQty
        {
            get { return _UnitQty; }
            set { _UnitQty = value; }
        }

        public decimal UnitPrice
        {
            get { return _UnitPrice; }
            set { _UnitPrice = value; }
        }

        public string Description
        {
            get
            {
                return _Description;
            }
            set
            {
                _Description = value;
            }
        }

        public decimal RRPPerItem
        {
            get
            {
                return _RRPPerItem;
            }
            set
            {
                _RRPPerItem = value;
            }
        }       

        public bool VatExempt
        {
            get
            {
                return _VatExempt;
            }
            set
            {
                _VatExempt = value;
            }
        }
    }
}
