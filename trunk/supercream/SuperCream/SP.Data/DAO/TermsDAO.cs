using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SP.Core.Domain;
using SP.Core.DataInterfaces;

namespace SP.Data.LTS
{
    public class TermsDao : AbstractLTSDao<Terms, int>, ITermsDao
    {
        #region IDao<Terms,int> Members

        public override Terms GetById(int id)
        {
            LTSDataContext db = new LTSDataContext();
            return db.Terms.Single<Terms>(q => q.ID == id);
        }

        #endregion
    }
}
