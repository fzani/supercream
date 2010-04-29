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

        public OrderCreditNoteContinueEventArgs(int orderId, string reason, DateTime dueDate)
        {
            orderId = orderId;
            this.dueDate = dueDate;
            this.reason = reason;

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
    }
}