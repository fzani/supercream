using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;

using SP.Core.Domain;
using SP.Core.DataInterfaces;

namespace SP.Data.LTS
{
   public class AccountDao : AbstractLTSDao<Account, int>, IAccountDao
   {
       public override Account GetById(int id)
       {
           LTSDataContext db = new LTSDataContext();
           DataLoadOptions dlo = new DataLoadOptions();
           dlo.LoadWith<Account>(a => a.Address);
           db.LoadOptions = dlo;
           return db.Account.Single<Account>(q => q.ID == id);
       }

       public bool AlphaIDExists(string id)
       {
           LTSDataContext db = new LTSDataContext();
           return (db.Account.SingleOrDefault<Account>(q => q.AlphaID == id) == null) ? false : true;
       }

       public Account GetAccountsByAlphaID(string id)
       {
           LTSDataContext db = new LTSDataContext();
           return db.Account.Single<Account>(q => q.AlphaID == id);
       }

       public List<Account> GetAccountsByCustomerId(int id)
       {
           LTSDataContext db = new LTSDataContext();
           return db.Account.Where<Account>(q => q.CustomerID == id).ToList<Account>();
       }
   }
}
