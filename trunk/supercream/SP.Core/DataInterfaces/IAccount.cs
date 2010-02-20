using System;
using System.Collections.Generic;
using System.Text;
using SP.Core.Domain;

namespace SP.Core.DataInterfaces
{
    public interface IAccountDao : IDao<Account, int>
    {
        List<Account> GetAccountsByCustomerId(int id);
        Account GetAccountsByAlphaID(string id);
        bool AlphaIDExists(string id);
    }
}
