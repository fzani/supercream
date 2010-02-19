using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SP.Core.Domain
{
   [Serializable]
   public class InvoiceItem : BaseEntity
   {
      private int	_InvoiceID;
      private int	_OrderLineID;
      private string	_ProductDescription;
      private int	_NoOfUnits;
      private float	_QtyPerUnit;
      private decimal	_PricePerUnit;
      private decimal	_RRP;

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

      public int InvoiceID
      {
         get
         {
            return _InvoiceID;
         }
         set
         {
            _InvoiceID = value;
         }
      }

      public int OrderLineID
      {
         get
         {
            return _OrderLineID;
         }
         set
         {
            _OrderLineID = value;
         }
      }

      public string ProductDescription
      {
         get
         {
            return _ProductDescription;
         }
         set
         {
            _ProductDescription = value;
         }
      }

      public int NoOfUnits
      {
         get
         {
            return _NoOfUnits;
         }
         set
         {
            _NoOfUnits = value;
         }
      }

      public float QtyPerUnit
      {
         get
         {
            return _QtyPerUnit;
         }
         set
         {
            _QtyPerUnit = value;
         }
      }

      public decimal PricePerUnit
      {
         get
         {
            return _PricePerUnit;
         }
         set
         {
            _PricePerUnit = value;
         }
      }

      public decimal RRP
      {
         get
         {
            return _RRP;
         }
         set
         {
            _RRP = value;
         }
      }
   }
}
