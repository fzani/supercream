using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SP.Core.Domain
{
    public class InvoiceWithStatus
    {
        string _OrderID;
        string _InvoiceNo;
        bool _InvoicePaymentComplete;
        DateTime _OrderDate;
        DateTime _InvoicePrintedDate;
        string _CustomerName;
        short _OrderStatus;

        public short OrderStatus
        {
            get { return _OrderStatus; }
            set { _OrderStatus = value; }
        }

        public string CustomerName
        {
            get { return _CustomerName; }
            set { _CustomerName = value; }
        }

        public DateTime OrderDate
        {
            get { return _OrderDate; }
            set { _OrderDate = value; }
        }

        public bool InvoicePaymentComplete
        {
            get { return _InvoicePaymentComplete; }
            set { _InvoicePaymentComplete = value; }
        }

        public string OrderID
        {
            get { return _OrderID; }
            set { _OrderID = value; }
        }

        public string InvoiceNo
        {
            get { return _InvoiceNo; }
            set { _InvoiceNo = value; }
        }
    }
}
