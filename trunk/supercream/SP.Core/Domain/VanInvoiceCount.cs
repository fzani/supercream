using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SP.Core.Domain
{
    [Serializable]
    public class VanInvoiceCount
    {
        public string VanDescription { get; set; }
        public int InvoiceCount { get; set; }

        public VanInvoiceCount()
        {
        }
    }
}
