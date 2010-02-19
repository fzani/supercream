using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.Linq;

using SP.Core.Domain;
using SP.Core.DataInterfaces;

namespace SP.Data.LTS
{
    public class OrderLineDao : AbstractLTSDao<OrderLine, int>, IOrderLineDao
    {
        public override OrderLine GetById(int id)
        {
            DataLoadOptions dlo = new DataLoadOptions();
            dlo.LoadWith<OrderLine>(a => a.OrderHeader);
            db.LoadOptions = dlo;
            return db.OrderLine.Single<OrderLine>(q => q.ID == id);
        }

        public List<OrderLine> GetOrderLinesByOrderID(int id)
        {
            return db.OrderLine.Where<OrderLine>(q => q.OrderID == id).ToList<OrderLine>();
        }
    }
}
