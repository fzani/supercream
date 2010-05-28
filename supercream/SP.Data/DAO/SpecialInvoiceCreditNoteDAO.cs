/***************************************************************************************************
// -- Generated by AlteraxGen 28/05/2010 17:29:05
// Version 1.0
***************************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SP.Core.Domain;
using SP.Core.DataInterfaces;

namespace SP.Data.LTS
{
   public class SpecialInvoiceCreditNoteDao : AbstractLTSDao<SpecialInvoiceCreditNote, int>, ISpecialInvoiceCreditNoteDao
   {
      public SpecialInvoiceCreditNoteDao()
      {
      }

      public SpecialInvoiceCreditNoteDao(LTSDataContext ctx)
         : base(ctx)
      {
      }

      public override SpecialInvoiceCreditNote GetById(int id)
      {
         return db.SpecialInvoiceCreditNote.Single<SpecialInvoiceCreditNote>(q => q.ID == id);
      }
   }
}
