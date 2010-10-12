using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SP.Core.Domain;

public partial class Controls_MaintainOfferQualiicationItems : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    #region List Item Events

    protected void ListView1_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        if (e.Item.ItemType == ListViewItemType.DataItem)
        {
            var productDescriptionLanel = e.Item.FindControl("ProductDescriptionLabel") as Label;
            if (productDescriptionLanel != null)
            {
                var productUI = new ProductUI();

                //  ListViewDataItem item = (ListViewDataItem)e.Item;

                var offerQualificationItem =
                    (((ListViewDataItem)e.Item).DataItem) as WcfFoundationService.OfferQualificationItem;

                var product = productUI.GetProductByID(offerQualificationItem.ProductId);
                productDescriptionLanel.Text = product.Description;
            }

            //if (e.Item.ItemType == ListViewItemType.InsertItem)
            //{
            //    var productDescriptionDropDownList = e.Item.FindControl("ProductDropDownList") as DropDownList;
            //    if (productDescriptionDropDownList != null)
            //    {
            //        var products = new ProductUI().GetAllProducts();
            //        var action = new Action<WcfFoundationService.Product>(
            //            q => productDescriptionDropDownList.Items.Add(new ListItem(q.Description, q.ID.ToString()))
            //            );

            //        products.ForEach(action);                                        
            //    }
            //}
        }

    }

    #endregion
   
}
