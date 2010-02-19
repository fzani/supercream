using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SP.Core.Domain
{
   [Serializable]
   public class PriceListHeader : BaseEntity
   {
      private string	_PriceListName;
      private DateTime	_DateEffectiveFrom;
      private DateTime	_DateEffectiveTo;

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

      public string PriceListName
      {
         get
         {
             return _PriceListName;
         }
         set
         {
             _PriceListName = value;
         }
      }

      public DateTime DateEffectiveFrom
      {
         get
         {
            return _DateEffectiveFrom;
         }
         set
         {
            _DateEffectiveFrom = value;
         }
      }

      public DateTime DateEffectiveTo
      {
         get
         {
            return _DateEffectiveTo;
         }
         set
         {
            _DateEffectiveTo = value;
         }
      }
   }
}
