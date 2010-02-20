using System;
using System.Collections.Generic;
using System.Text;
using SP.Core.Domain;

namespace SP.Core.DataInterfaces
{
    public interface ICustomerDao : IDao<Customer, int>
    {
        bool ExistsByName(string name);
        bool ExistsWithNameLike(string name);
        Customer GetByName(string name);

        List<Account> GetAccountsByID(int id);
        List<Customer> GetByAccountNameLike(string name);
        Customer GetWithContacts(int id);
        Customer GetWithOutletStores(int id1);
        List<Customer> GetByTelehoneNoLike(string telephoneNo);
        List<Customer> GetByNameLike(string name);

        void UpdateAlphaID(int id, string prepostfix);
    }
}
