using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;

using SP.Core.Domain;
using SP.Core.DataInterfaces;

namespace SP.Data.LTS
{
    public class CustomerDao : AbstractLTSDao<Customer, int>, ICustomerDao
    {
        public override Customer GetById(int id)
        {
            DataLoadOptions dlo = new DataLoadOptions();
            dlo.LoadWith<Customer>(a => a.ContactDetail);
            dlo.LoadWith<Customer>(c => c.Account);
            dlo.LoadWith<Customer>(c => c.OutletStore);         
            dlo.LoadWith<Account>(a => a.Address);
         
            db.LoadOptions = dlo;
            return db.Customer.Single<Customer>(q => q.ID == id);
        }

        public bool ExistsByName(string name)
        {
            Customer customer = db.Customer.SingleOrDefault<Customer>(q => q.Name == name);
            return (customer == null) ? false : true;

        }

        public bool ExistsWithNameLike(string name)
        {
            Customer customer = (from c in db.Customer
                                 where c.Name.Contains(name)
                                 select c).SingleOrDefault<Customer>();
            return (customer == null) ? false : true;
        }

        public Customer GetByName(string name)
        {
            return db.Customer.Single<Customer>(q => q.Name == name);
        }

        public List<Customer> GetByAccountNameLike(string name)
        {
            return (from a in db.Account
                    join c in db.Customer on a.CustomerID equals c.ID
                    where a.AlphaID.Contains(name)
                    select c).Distinct<Customer>().ToList<Customer>();
        }

        public List<Customer> GetByTelehoneNoLike(string telephoneNo)
        {
            return (from c in db.Customer
                    join cd in db.ContactDetail on c.ID equals cd.CustomerID
                    join ph in db.Phone on cd.ID equals ph.ContactDetailID
                    where ph.Description.Contains(telephoneNo)
                    orderby c.Name
                    select c).Distinct().ToList<Customer>();
        }

        public List<Customer> GetByNameLike(string name)
        {
            return (from c in db.Customer
                    where c.Name.Contains(name)
                    orderby c.Name
                    select c).ToList<Customer>();
        }

        public Customer GetWithContacts(int id)
        {
            DataLoadOptions dlo = new DataLoadOptions();
            dlo.LoadWith<Customer>(a => a.ContactDetail);
            dlo.LoadWith<ContactDetail>(c => c.Phone);
            dlo.LoadWith<Phone>(p => p.PhoneNoType);
            db.LoadOptions = dlo;
            return db.Customer.Single<Customer>(q => q.ID == id);
        }

        public Customer GetWithOutletStores(int id)
        {
            DataLoadOptions dlo = new DataLoadOptions();
            dlo.LoadWith<Customer>(a => a.OutletStore);
            dlo.LoadWith<OutletStore>(o => o.Address);
            db.LoadOptions = dlo;
            return db.Customer.Single<Customer>(q => q.ID == id);
        }

        public List<Account> GetAccountsByID(int id)
        {
            DataLoadOptions dlo = new DataLoadOptions();
            dlo.LoadWith<Customer>(a => a.Account);
            db.LoadOptions = dlo;
            Customer customer = db.Customer.Single<Customer>(q => q.ID == id);
            return customer.Account;
        }

        public void UpdateAlphaID(int id1, string alphaId1)
        {
            string cmd = String.Format(@"UPDATE [SuperCreamDB].[dbo].[Customer] SET [AlphaID] = '{0}' WHERE ID={1}", alphaId1, id1);
            db.ExecuteCommand(cmd);
        }
    }
}
