using System;
using System.Collections.Generic;
using System.Text;
using SP.Core.Domain;

namespace SP.Core.DataInterfaces
{
    public interface IPriceListItemDao : IDao<PriceListItem, int>
    {
        List<PriceListItem> GetByPriceListHeader(int id);
        PriceListItem GetByProductId(int priceListID, int productId);
    }
}
