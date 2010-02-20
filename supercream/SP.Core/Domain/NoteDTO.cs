using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SP.Core.Domain
{
   [Serializable]
   public class Note : BaseEntity
   {
      private int?	_ParentNoteID;
      private DateTime	_DateNoteTaken;
      private string	_SpokeTo;
      private string	_NoteText;
      private Customer _Customer;

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

      public int? ParentNoteID
      {
         get
         {
            return _ParentNoteID;
         }
         set
         {
            _ParentNoteID = value;
         }
      }

      public DateTime DateNoteTaken
      {
         get
         {
            return _DateNoteTaken;
         }
         set
         {
            _DateNoteTaken = value;
         }
      }

      public string SpokeTo
      {
         get
         {
            return _SpokeTo;
         }
         set
         {
            _SpokeTo = value;
         }
      }

      public string NoteText
      {
         get
         {
            return _NoteText;
         }
         set
         {
            _NoteText = value;
         }
      }

      public Customer Customer
      {
          get { return _Customer; }
          set { _Customer = value; }
      }
   }
}
