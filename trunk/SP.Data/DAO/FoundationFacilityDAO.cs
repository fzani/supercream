using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using SP.Core.Domain;
using SP.Core.DataInterfaces;

namespace SP.Data.LTS
{
    public class FoundationFacilityDao : AbstractLTSDao<FoundationFacility, int>, IFoundationFacilityDao
    {
        public override FoundationFacility GetById(int id)
        {
            return db.FoundationFacility.Single<FoundationFacility>(q => q.ID == id);
        }

        public bool Exists()
        {
            try
            {
                FoundationFacility foundationFacility = db.FoundationFacility.First<FoundationFacility>();
                return (foundationFacility != null) ? true : false;
            }
            catch (Exception ex)
            {
                if (ex.Message == "Sequence contains no elements")
                    return false;
                else
                    throw;
            }
        }

        // There should only ever be one FoundationFacility
        public FoundationFacility Get()
        {
            db = new LTSDataContext();
            DataLoadOptions dlo = new DataLoadOptions();
            dlo.LoadWith<FoundationFacility>(r => r.Address);
            db.LoadOptions = dlo;

            return db.FoundationFacility.First<FoundationFacility>();
        }
    }
}
