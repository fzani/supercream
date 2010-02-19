using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SP.Core.Domain
{
    [Serializable]
    public class PriceListItem : BaseEntity
    {
        private int _PriceListID;
        private int? _ProductID;
        private decimal _Discount;
        private Product _Product;

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

        public int PriceListID
        {
            get
            {
                return _PriceListID;
            }
            set
            {
                _PriceListID = value;
            }
        }

        public int? ProductID
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

        public decimal Discount
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

        public Product Product
        {
            get { return _Product; }
            set { _Product = value; }
        }
    }
}
