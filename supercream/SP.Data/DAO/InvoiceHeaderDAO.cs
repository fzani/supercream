using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SP.Core.Domain;
using SP.Core.DataInterfaces;

namespace SP.Data.LTS
{
   public class InvoiceHeaderDao : AbstractLTSDao<InvoiceHeader, int>, IInvoiceHeaderDao
   {
   }
}
