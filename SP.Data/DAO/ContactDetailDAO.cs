using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;

using SP.Core.Domain;
using SP.Core.DataInterfaces;

namespace SP.Data.LTS
{
   public class ContactDetailDao : AbstractLTSDao<ContactDetail, int>, IContactDetailDao
   {
       public override ContactDetail GetById(int id)
       {
           DataLoadOptions dlo = new DataLoadOptions();
           dlo.LoadWith<ContactDetail>(c => c.Phone);
           dlo.LoadWith<Phone>(c => c.PhoneNoType);
           db.LoadOptions = dlo;
           return db.ContactDetail.Single<ContactDetail>(q => q.ID == id);
       }

       public List<ContactDetail> GetByCustomerId(int id)
       {
           DataLoadOptions dlo = new DataLoadOptions();
           dlo.LoadWith<ContactDetail>(c => c.Phone);
           dlo.LoadWith<Phone>(c => c.PhoneNoType);
           db.LoadOptions = dlo;

           return db.ContactDetail.Where<ContactDetail>(q => q.CustomerID == id).ToList<ContactDetail>();
       }
   }
}
