using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SP.Core.Extensions
{
    public static class OrderStatusExtensions
    {
        public static bool IsOrderOrDeliveryNote(this SP.Core.Enums.OrderStatus orderStatus)
        {
            return (orderStatus == SP.Core.Enums.OrderStatus.DeliveryNote
                    || orderStatus == SP.Core.Enums.OrderStatus.DeliveryNotePrinted
                    || orderStatus == SP.Core.Enums.OrderStatus.Invoice
                    || orderStatus == SP.Core.Enums.OrderStatus.InvoicePrinted);
        }

        public static bool IsInvoice(this SP.Core.Enums.OrderStatus orderStatus)
        {
            return (orderStatus == SP.Core.Enums.OrderStatus.Invoice
                    || orderStatus == SP.Core.Enums.OrderStatus.InvoicePrinted);
        }
    }
}
