using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;

using SP.Core.Domain;
using SP.Core.DataInterfaces;

namespace SP.Data.LTS
{
    public class AutoGenDao : AbstractLTSDao<AutoGen, int>, IAutogenDao
    {
        public override AutoGen GetById(int id)
        {
            LTSDataContext db = new LTSDataContext();
            DataLoadOptions dlo = new DataLoadOptions();
            dlo.LoadWith<Account>(a => a.Address);
            db.LoadOptions = dlo;
            return db.AutoGen.Single<AutoGen>(q => q.ID == id);
        }
    }
}
