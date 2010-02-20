using System;
using System.Collections.Generic;
using System.Text;
using SP.Core.Domain;

namespace SP.Core.DataInterfaces
{
    public interface IPhoneDao : IDao<Phone, int>
    {
        Phone GetPhoneById(int id);
    }
}
