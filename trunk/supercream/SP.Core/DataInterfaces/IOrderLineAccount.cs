using System;
using System.Collections.Generic;
using System.Text;
using SP.Core.Domain;

namespace SP.Core.DataInterfaces
{
    public interface IOrderLineDao : IDao<OrderLine, int>
    {
        List<OrderLine> GetOrderLinesByOrderID(int id);
    }
}
