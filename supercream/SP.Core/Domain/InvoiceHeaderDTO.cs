using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SP.Core.Domain
{
   [Serializable]
   public class InvoiceHeader : BaseEntity
   {
      private int	_AccountID;
      private int	_InvoiceTermsID;
      private short	_InvoiceType;
      private short	_AlphaPrefixOrPostFix;
      private string	_AlphaID;
      private DateTime	_InvoiceDate;
      private string	_SpecialInstructions;

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

      public int AccountID
      {
         get
         {
            return _AccountID;
         }
         set
         {
            _AccountID = value;
         }
      }

      public int InvoiceTermsID
      {
         get
         {
            return _InvoiceTermsID;
         }
         set
         {
            _InvoiceTermsID = value;
         }
      }

      public short InvoiceType
      {
         get
         {
            return _InvoiceType;
         }
         set
         {
            _InvoiceType = value;
         }
      }

      public short AlphaPrefixOrPostFix
      {
         get
         {
            return _AlphaPrefixOrPostFix;
         }
         set
         {
            _AlphaPrefixOrPostFix = value;
         }
      }

      public string AlphaID
      {
         get
         {
            return _AlphaID;
         }
         set
         {
            _AlphaID = value;
         }
      }

      public DateTime InvoiceDate
      {
         get
         {
            return _InvoiceDate;
         }
         set
         {
            _InvoiceDate = value;
         }
      }

      public string SpecialInstructions
      {
         get
         {
            return _SpecialInstructions;
         }
         set
         {
            _SpecialInstructions = value;
         }
      }
   }
}
