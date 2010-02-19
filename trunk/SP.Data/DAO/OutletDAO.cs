using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SP.Core.Domain;
using SP.Core.DataInterfaces;

namespace SP.Data.LTS
{
   public class OutletDao : AbstractLTSDao<Outlet, int>, IOutletDao
   {
       public override Outlet GetById(int id)
       {
           return db.Outlet.Single<Outlet>(q => q.ID == id);
       }
   }
}
