using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Transactions;

using SP.Util;

using WcfFoundationService;

/// <summary>
/// Summary description for OrderListUI
/// </summary>
[System.ComponentModel.DataObject]
public class ProductUI : IDisposable
{
    private WcfFoundationService.FoundationServiceClient _proxy;

    public ProductUI()
    {
        _proxy = new WcfFoundationService.FoundationServiceClient();
    }

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public List<Product> GetAllProducts(string productCode, string productDescription)
    {
        List<Product> p = new List<Product>();
        if (String.IsNullOrEmpty(productCode) && String.IsNullOrEmpty(productDescription))
            p = _proxy.GetAllProducts() as List<Product>;
        else if (String.IsNullOrEmpty(productDescription))
        {
            p = _proxy.GetLikeProductCode(productCode) as List<Product>;
        }
        else
        {
            p = _proxy.GetLikeProductDescription(productDescription) as List<Product>;
        }
        return p;
    }

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public List<Product> GetAllProducts()
    {
        List<Product> p = new List<Product>();
        return _proxy.GetAllProducts();

    }

    public List<Product> GetProductsInPriceList(int id)
    {
        return _proxy.GetProductsInPriceList(id);
    }

    public List<Product> GetProductsOutOfPriceList(int id)
    {
        return _proxy.GetProductsOutOfProductList(id);
    }

    public void SaveProduct(Product product)
    {
        _proxy.SaveProduct(product);
    }

    public bool ProductCodeExists(string productCode)
    {
        return _proxy.ProductCodeExists(productCode);
    }

    public void DeleteProduct(int id)
    {
        using (TransactionScope ts = new TransactionScope())
        {
            Product code = _proxy.GetProduct(id);
            _proxy.DeleteProduct(code);
        }
    }

    public void UpdateProduct(Product newProduct)
    {
        using (TransactionScope ts = new TransactionScope())
        {
            Product origProduct = _proxy.GetProduct(newProduct.ID);
            Product updatedProduct = origProduct.Clone<Product>();
            updatedProduct.Description = newProduct.Description;
            updatedProduct.ID = newProduct.ID;
            updatedProduct.ProductCode = newProduct.ProductCode;
            updatedProduct.RRPPerItem = newProduct.RRPPerItem;
            updatedProduct.UnitPrice = newProduct.UnitPrice;
            updatedProduct.UnitQty = newProduct.UnitQty;          
            updatedProduct.VatExempt = newProduct.VatExempt;

            _proxy.UpdateProduct(updatedProduct, origProduct);
        }
    }

    public Product GetProductByID(int id)
    {
        return _proxy.GetProduct(id);
    }

    #region IDisposable Members

    public void Dispose()
    {
        _proxy.Close();
    }

    #endregion

    ~ProductUI()
    {
        if (_proxy != null)
            _proxy.Close();
    }
}
