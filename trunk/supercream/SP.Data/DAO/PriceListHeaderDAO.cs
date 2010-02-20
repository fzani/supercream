using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SP.Core.Domain;
using SP.Core.DataInterfaces;

namespace SP.Data.LTS
{
   public class PriceListHeaderDao : AbstractLTSDao<PriceListHeader, int>, IPriceListHeaderDao
   {
       public override PriceListHeader GetById(int id)
       {
           return db.PriceListHeader.Single<PriceListHeader>(q => q.ID == id);
       }
   }
}
