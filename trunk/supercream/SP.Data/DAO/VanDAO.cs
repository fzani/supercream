using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SP.Core.Domain;
using SP.Core.DataInterfaces;

namespace SP.Data.LTS
{
    public class VanDao : AbstractLTSDao<Van, int>, IVanDao
    {
        public override Van GetById(int id)
        {
            return db.Van.SingleOrDefault<Van>(q => q.ID == id);
        }
    }
}
