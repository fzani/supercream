using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SP.Core.Domain
{
   [Serializable]
   public class Terms : BaseEntity
   {
      private string	_Description;
      private Account _Account;

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

      public string Description
      {
         get
         {
            return _Description;
         }
         set
         {
            _Description = value;
         }
      }

      public Account Account
      {
          get 
          { 
              return _Account; 
          }
          set 
          { 
              _Account = value; 
          }
      }
   }
}
