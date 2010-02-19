using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SP.Core.Domain;
using SP.Core.DataInterfaces;

namespace SP.Data.LTS
{
   public class PhoneNoTypeDao : AbstractLTSDao<PhoneNoType, int>, IPhoneNoTypeDao
   {
       public PhoneNoTypeDao()
       {
       }

       public PhoneNoTypeDao(LTSDataContext db) : base(db)
       {
       }


       public override PhoneNoType GetById(int id)
       {
           return db.PhoneNoType.Single<PhoneNoType>(q => q.ID == id);
       }
	}
}
