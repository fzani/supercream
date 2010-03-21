/***************************************************************************************************
// -- Generated by AlteraxGen 21/03/2010 09:12:11
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
    public class StandardVatRateDao : AbstractLTSDao<StandardVatRate, int>, IStandardVatRateDao
    {
        public StandardVatRateDao()
        {
        }

        public StandardVatRateDao(LTSDataContext ctx)
            : base(ctx)
        {
        }

        public override StandardVatRate GetById(int id)
        {
            return db.StandardVatRate.Single<StandardVatRate>(q => q.ID == id);
        }

        public StandardVatRate Get()
        {
            return db.StandardVatRate.FirstOrDefault<StandardVatRate>();
        }

        public bool Exists()
        {
            return db.StandardVatRate.FirstOrDefault<StandardVatRate>() == null ? false : true;
        }
    }
}
