using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SP.Core.Domain
{
    [Serializable]
    public class OrderHeader : BaseEntity
    {
        private int _CustomerID;
        private short _AlphaPrefixOrPostFix;
        private string _AlphaID;
        private DateTime _OrderDate;
        private short _OrderStatus;
        private string _SpecialInstructions;
        private string _InvoiceNo;
        private DateTime _DeliveryDate;
        private OrderNotesStatus _OrderNoteStatus;

        private List<OrderLine> _OrderLine;

        public OrderHeader()
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

        public int CustomerID
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

        public short AlphaPrefixOrPostFix
        {
            get
            {
                return _AlphaPrefixOrPostFix;
            }
            set
            {
                _AlphaPrefixOrPostFix = value;
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

        public DateTime OrderDate
        {
            get
            {
                return _OrderDate;
            }
            set
            {
                _OrderDate = value;
            }
        }

        public DateTime DeliveryDate
        {
            get
            {
                return _DeliveryDate;
            }
            set
            {
                _DeliveryDate = value;
            }
        }

        public short OrderStatus
        {
            get
            {
                return _OrderStatus;
            }
            set
            {
                _OrderStatus = value;
            }
        }

        public OrderNotesStatus OrderNoteStatus
        {
            get
            {
                return _OrderNoteStatus;
            }
            set
            {
                _OrderNoteStatus = value;
                if (_OrderNoteStatus != null)
                {
                    _OrderNoteStatus.OrderID = this.ID;
                    _OrderNoteStatus.OrderHeader = this;
                    
                }
            }
        }

        public string SpecialInstructions
        {
            get
            {
                return _SpecialInstructions;
            }
            set
            {
                _SpecialInstructions = value;
            }
        }

        public string InvoiceNo
        {
            get
            {
                return _InvoiceNo;
            }
            set
            {
                _InvoiceNo = value;
            }
        }

        public List<OrderLine> OrderLine
        {
            get
            {
                return _OrderLine;
            }
            set
            {
                _OrderLine = value;
                foreach (var orderLine in _OrderLine)
                {
                    orderLine.OrderID = this.ID;
                    orderLine.OrderHeader = this;
                }
            }
        }
    }
}