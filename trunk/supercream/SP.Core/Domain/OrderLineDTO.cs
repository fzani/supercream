using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SP.Core.Domain
{
    [Serializable]
    public class OrderLine : BaseEntity
    {
        private int _OrderID;
        private int _ProductID;
        private short _OrderLineStatus;
        private int _QtyPerUnit;
        private int _NoOfUnits;
        private float _Discount;
        private Decimal _Price;
        private string _SpecialInstructions;
        private decimal _RRPPerItem;

        private OrderHeader _OrderHeader;

        public OrderLine()
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

        public int OrderID
        {
            get
            {
                return _OrderID;
            }
            set
            {
                _OrderID = value;
            }
        }

        public int ProductID
        {
            get
            {
                return _ProductID;
            }
            set
            {
                _ProductID = value;
            }
        }

        public short OrderLineStatus
        {
            get
            {
                return _OrderLineStatus;
            }
            set
            {
                _OrderLineStatus = value;
            }
        }

        public int QtyPerUnit
        {
            get
            {
                return _QtyPerUnit;
            }
            set
            {
                _QtyPerUnit = value;
            }
        }

        public int NoOfUnits
        {
            get
            {
                return _NoOfUnits;
            }
            set
            {
                _NoOfUnits = value;
            }
        }

        public float Discount
        {
            get
            {
                return _Discount;
            }
            set
            {
                _Discount = value;
            }
        }

        public Decimal Price
        {
            get { return _Price; }
            set { _Price = value; }
        }

        public string SpecialInstructions
        {
            get { return _SpecialInstructions; }
            set { _SpecialInstructions = value; }
        }

        public OrderHeader OrderHeader
        {
            get
            {
                return this._OrderHeader;
            }
            set
            {
                this._OrderHeader = value;
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
    }
}
