using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SP.Core.Domain
{
   [Serializable]
   public class OutletStore : BaseEntity
   {
      private int?	_CustomerID;
      private int	_AddressID;

      private string	_Name;
      private string	_OpeningHoursNotes;
      private string	_Note;

      private Customer _Customer;
      private Address _Address;

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

      public int? CustomerID
      {
         get
         {
            return _CustomerID;
         }
         set
         {
            _CustomerID = value;
         }
      }

      public int AddressID
      {
         get
         {
            return _AddressID;
         }
         set
         {
            _AddressID = value;
         }
      }

      public string Name
      {
         get
         {
            return _Name;
         }
         set
         {
            _Name = value;
         }
      }

      public string OpeningHoursNotes
      {
         get
         {
            return _OpeningHoursNotes;
         }
         set
         {
            _OpeningHoursNotes = value;
         }
      }

      public string Note
      {
         get
         {
            return _Note;
         }
         set
         {
            _Note = value;
         }
      }

      public Customer Customer
      {
          get 
          { 
              return _Customer; 
          }
          set 
          { 
              _Customer = value; 
          }
      }

      public Address Address
      {
          get 
          { 
              return _Address; 
          }
          
          set 
          { 
              _Address = value;
              _Address.OutletID = ID;
              _Address.OutletStore = this;
          }
      }
   }
}
