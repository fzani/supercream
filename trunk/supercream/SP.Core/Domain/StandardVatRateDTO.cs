/***************************************************************************************************
// -- Generated by AlteraxGen 21/03/2010 09:07:05
// Version 1.0
***************************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SP.Core.Domain
{
   [Serializable]
   public class StandardVatRate : BaseEntity
   {     
      private int	_VatCodeID;

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

      public int VatCodeID
      {
         get
         {
            return _VatCodeID;
         }
         set
         {
            _VatCodeID = value;
         }
      }
   }
}
