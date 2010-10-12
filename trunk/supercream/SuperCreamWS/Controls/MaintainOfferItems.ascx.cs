using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controls_MaintainOfferItems : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ListView1_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        if (e.Item.ItemType == ListViewItemType.DataItem)
        {
            var productDescriptionLabel = e.Item.FindControl("ProductDescriptionLabel") as Label;
            if (productDescriptionLabel != null)
            {
                var productUi = new ProductUI();

                var offerItem =
                    (((ListViewDataItem)e.Item).DataItem) as WcfFoundationService.OfferItem;

                if (offerItem != null)
                {
                    var product = productUi.GetProductByID(offerItem.ProductId);
                    productDescriptionLabel.Text = product.Description;
                }
            }
        }
    }
}
