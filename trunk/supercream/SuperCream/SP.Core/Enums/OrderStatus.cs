using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SP.Core.Enums
{
    public enum OrderStatus : short
    {
        Order = 1,
        Invoice = 2,
        InvoicePrinted = 3,
        ProformaInvoice = 4,
        PoformaInvoicePrinted = 5,
        DeliveryNote = 6,
        DeliveryNotePrinted = 7
    }
}