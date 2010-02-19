using System;
using System.Collections.Generic;
using System.Text;
using SP.Core.Domain;

namespace SP.Core.DataInterfaces
{
    public interface IContactDetailDao : IDao<ContactDetail, int>
    {
        List<ContactDetail> GetByCustomerId(int id);
    }
}
