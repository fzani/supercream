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

        public int Generate(string type)
        {
            LTSDataContext db = new LTSDataContext();
            SP.Core.Domain.AutoGen newAutoGen;

            SP.Core.Domain.AutoGen originalAutoGen = db.AutoGen.Where(q => q.Type == type).SingleOrDefault<SP.Core.Domain.AutoGen>();
            if (originalAutoGen != null)
            {
                newAutoGen = new AutoGen
                {
                    ID = originalAutoGen.ID + 1,                   
                    Type = originalAutoGen.Type
                };
                this.Update(newAutoGen, originalAutoGen);
            }
            else
            {
                newAutoGen = new AutoGen
                {
                    ID = originalAutoGen.ID + 1,                   
                    Type = originalAutoGen.Type
                };
                this.Save(newAutoGen);
            }

            return newAutoGen.ID; ;
        }
    }
}
