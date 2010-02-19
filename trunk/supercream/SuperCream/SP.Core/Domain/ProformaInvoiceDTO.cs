using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SP.Core.Domain
{
   [Serializable]
   public class ProformaInvoice : BaseEntity
   {
 
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
   }
}
