using System;
using System.Collections.Generic;
using System.Text;
using SP.Core.Domain;

namespace SP.Core.DataInterfaces
{
    public interface IProductDao : IDao<Product, int>
    {
        Product GetByProductCode(string productCode);
        bool ProductCodeExists(string productCode);
        List<Product> GetLikeProductCode(string productCode);
        List<Product> GetLikeProductDescription(string productDescription);
        List<Product> GetProductsInPriceList(int id);
        List<Product> GetProductsOutOfProductList(int id);
    }
}
