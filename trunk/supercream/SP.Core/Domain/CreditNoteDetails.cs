using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SP.Core.Domain
{
    [Serializable]
    public class CreditNoteDetails
    {
        private int _OrderID;
        private string _OrderNo;
        private string _InvoiceNo;
        private DateTime _DateCreated;
        private string _CustomerName;

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

        public string OrderNo
        {
            get
            {
                return _OrderNo;
            }

            set
            {
                _OrderNo = value;
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

        public DateTime DateCreated
        {
            get
            {
                return _DateCreated;
            }
            set
            {
                _DateCreated = value;
            }
        }

        public string CustomerName
        {
            get
            {
                return
                    _CustomerName;
            }

            set
            {
                _CustomerName = value;
            }
        }
    }
}
