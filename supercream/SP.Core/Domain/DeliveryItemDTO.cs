using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SP.Core.Domain
{
   [Serializable]
   public class DeliveryItem : BaseEntity
   {
      private int	_VanID;
      private int	_InvoiceItemID;
      private string	_DriverName;
      private DateTime	_DeliveryDate;
      private DateTime	_NextDeliveryDate;
      private bool	_DeliveryComplete;

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

      public int VanID
      {
         get
         {
            return _VanID;
         }
         set
         {
            _VanID = value;
         }
      }

      public int InvoiceItemID
      {
         get
         {
            return _InvoiceItemID;
         }
         set
         {
            _InvoiceItemID = value;
         }
      }

      public string DriverName
      {
         get
         {
            return _DriverName;
         }
         set
         {
            _DriverName = value;
         }
      }

      public DateTime DeliveryDate
      {
         get
         {
            return _DeliveryDate;
         }
         set
         {
            _DeliveryDate = value;
         }
      }

      public DateTime NextDeliveryDate
      {
         get
         {
            return _NextDeliveryDate;
         }
         set
         {
            _NextDeliveryDate = value;
         }
      }

      public bool DeliveryComplete
      {
         get
         {
            return _DeliveryComplete;
         }
         set
         {
            _DeliveryComplete = value;
         }
      }
   }
}
