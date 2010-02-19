using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;

using SP.Core.Domain;
using SP.Core.DataInterfaces;

namespace SP.Data.LTS
{
    public class PriceListItemDao : AbstractLTSDao<PriceListItem, int>, IPriceListItemDao
    {
        public override PriceListItem GetById(int id)
        {
            return db.PriceListItem.Single<PriceListItem>(q => q.ID == id);
        }

        public PriceListItem GetByProductId(int priceListID, int productId)
        {
            return db.PriceListItem.SingleOrDefault<PriceListItem>(q => (q.ProductID == productId) && (q.PriceListID == priceListID));
        }

        public List<PriceListItem> GetByPriceListHeader(int id)
        {
            return db.PriceListItem.Where<PriceListItem>(q => q.PriceListID == id).ToList<PriceListItem>();
        }
    }
}
