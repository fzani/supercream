using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SP.Core.Domain;
using SP.Core.DataInterfaces;

namespace SP.Data.LTS
{
    public class AddressDao : AbstractLTSDao<Address, int>, IAddressDao
    {
        public override Address GetById(int id)
        {
            return db.Address.Single<Address>(q => q.ID == id);
        }
    }
}
