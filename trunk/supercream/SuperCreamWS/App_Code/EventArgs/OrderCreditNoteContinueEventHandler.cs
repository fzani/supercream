using System;

namespace App_Code.EventArgs
{
    /// <summary>
    /// Summary description for CancelEventArgs
    /// </summary>
    /// 

    public delegate void OrderCreditNoteContinueEventHandler(object sender, OrderCreditNoteContinueEventArgs e);

    public class OrderCreditNoteContinueEventArgs : System.EventArgs
    {
        private readonly int orderId;
        private readonly string reason;
        private readonly DateTime dueDate;
        private readonly string alphaId;
        private readonly int creditNoteId;
        private string reference;

        public OrderCreditNoteContinueEventArgs(int orderId, string reason, DateTime dueDate, string alphaId, int creditNoteId, string reference)
        {
            this.orderId = orderId;
            this.reference = reference;
            this.creditNoteId = creditNoteId;
            this.dueDate = dueDate;
            this.alphaId = alphaId;
            this.reason = reason;

        }
       
        public int CreditNoteId
        {
            get { return creditNoteId; }
        }

        public string AlphaId
        {
            get { return alphaId; }
        }

        public DateTime DueDate
        {
            get { return dueDate; }
        }

        public string Reason
        {
            get { return reason; }
        }

        public int OrderId
        {
            get { return orderId; }
        }

        public string Reference
        {
            get { return reference; }
        }
    }
}