using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;

using System.Data.Linq.SqlClient;

using SP.Core.Domain;
using SP.Core.DataInterfaces;

namespace SP.Data.LTS
{
    public class ProductDao : AbstractLTSDao<Product, int>, IProductDao
    {
        #region IProduct<Product,int> Members

        public override Product GetById(int id)
        {           
            DataLoadOptions dlo = new DataLoadOptions();
            dlo.LoadWith<Product>(p => p.VatCode);
            db.LoadOptions = dlo;
            return db.Product.Single<Product>(q => q.ID == id);
        }

        public Product GetByProductCode(string productCode)
        {
            LTSDataContext db = new LTSDataContext();
            return db.Product.Single<Product>(q => q.ProductCode == productCode);
        }

        public List<Product> GetLikeProductCode(string productCode)
        {
            LTSDataContext db = new LTSDataContext();

            return db.Product.Where(p => p.ProductCode.Contains(productCode)).OrderBy(p => p.ProductCode).ThenBy(p => p.Description).ToList<Product>();

            //List<Product> productList = (from p in db.Product
            //       where SqlMethods.Like(p.ProductCode, '%' + productCode + '%')
            //             select p).ToList<Product>();
            // return productList;
        }

        public List<Product> GetLikeProductDescription(string productDescription)
        {
            LTSDataContext db = new LTSDataContext();
            return db.Product.Where(p => p.Description.Contains(productDescription)).OrderBy(p => p.ProductCode).ThenBy(p => p.Description).ToList<Product>();
        }

        public bool ProductCodeExists(string productCode)
        {
            return ((from t in db.Product
                     where (t.ProductCode == productCode)
                     select t).Count() > 0) ? true : false;
        }

        public List<Product> GetProductsInPriceList(int id)
        {
            LTSDataContext ctx = new LTSDataContext();
            return ctx.ExecuteQuery<Product>("exec GetProductsInProductList {0}", id).ToList<Product>(); ;
        }

        public List<Product> GetProductsOutOfProductList(int id)
        {
            LTSDataContext ctx = new LTSDataContext();
            return ctx.ExecuteQuery<Product>("exec GetProductsOutOfProductList {0}", id).ToList<Product>(); ;
        }

        #endregion
    }
}
