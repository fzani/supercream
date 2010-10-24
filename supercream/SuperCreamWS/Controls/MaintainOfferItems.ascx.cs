using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controls_MaintainOfferItems : System.Web.UI.UserControl
{
    #region Public Events

    public event ErrorMessageEventHandler ErrorMessageEventHandler;
    public event DataBindEventHandler DataBindEventHandler;

    #endregion

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

    protected void ListView1_ItemInserting(object sender, ListViewInsertEventArgs e)
    {
        var productDropDownList = e.Item.FindControl("ProductDropDownList") as DropDownList;
        if (productDropDownList != null)
        {
            e.Values["ProductId"] = (Convert.ToInt32(productDropDownList.SelectedValue));
        }

        e.Values["OfferId"] = (Convert.ToInt32(OfferBundleDropDownList.SelectedValue));

    }

    protected void ListView1_ItemUpdating(object sender, ListViewUpdateEventArgs e)
    {
        e.NewValues["OfferId"] = (Convert.ToInt32(OfferBundleDropDownList.SelectedValue));
    }

    protected void ListView1_ItemInserted(object sender, ListViewInsertedEventArgs e)
    {
        Exception ex = e.Exception;
        if (ex != null)
        {
            e.ExceptionHandled = true;
            HandleException(ex, e);
        }

        if (this.DataBindEventHandler != null)
        {
            DataBindEventHandler(this, new DataBindEventArgs());
        }
    }

    protected void ListView1_ItemDeleted(object sender, ListViewDeletedEventArgs e)
    {
        Exception ex = e.Exception;
        if (ex != null)
        {
            e.ExceptionHandled = true;
            HandleException(ex, e);
        }

        if (this.DataBindEventHandler != null)
        {
            DataBindEventHandler(this, new DataBindEventArgs());
        }
    }

    #region Error Handling

    /**************************************************************************
    * General Exception handlers
    ***************************************************************************/
    private void HandleException(Exception ex, EventArgs e)
    {
        var errorMessageEventArgs = new ErrorMessageEventArgs();

        if (ex.InnerException != null)
        {
            errorMessageEventArgs.AddErrorMessages(ex.InnerException.Message);
        }
        else
        {
            errorMessageEventArgs.AddErrorMessages(ex.Message);
        }

        if (this.ErrorMessageEventHandler != null)
        {
            this.ErrorMessageEventHandler(this, errorMessageEventArgs);
        }
    }

    #endregion
}


