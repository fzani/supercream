using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SP.Core.Domain;
using SP.Core.DataInterfaces;

namespace SP.Data.LTS
{
   public class OutletStoreDao : AbstractLTSDao<OutletStore, int>, IOutletStoreDao
   {
       public override OutletStore GetById(int id)
       {
           return db.OutletStore.Single<OutletStore>(q => q.ID == id);
       }
   }
}
