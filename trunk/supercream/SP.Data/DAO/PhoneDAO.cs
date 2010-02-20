using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;

using SP.Core.Domain;
using SP.Core.DataInterfaces;

namespace SP.Data.LTS
{
   public class PhoneDao : AbstractLTSDao<Phone, int>, IPhoneDao
   {
       public override Phone GetById(int id)
       {
           DataLoadOptions dlo = new DataLoadOptions();
           dlo.LoadWith<Phone>(p => p.PhoneNoType);
           db.LoadOptions = dlo;

           return db.Phone.Single<Phone>(q => q.ID == id);
       }

       public Phone GetPhoneById(int id)
       {
           return db.Phone.Single<Phone>(q => q.ID == id);
       }
   }
}
