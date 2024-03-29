﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SP.Core.Domain;

public partial class Controls_MaintainOfferQualiicationItems : System.Web.UI.UserControl
{
    #region Public Events

    public event ErrorMessageEventHandler ErrorMessageEventHandler;
    public event DataBindEventHandler DataBindEventHandler;

    #endregion

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

    protected void ListView1_ItemInserting(object sender, ListViewInsertEventArgs e)
    {
        DropDownList productDropDownList = e.Item.FindControl("ProductDropDownList") as DropDownList;
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

    protected void ListView1_ItemDeleting(object sender, ListViewDeleteEventArgs e)
    {
        // e.Values["ID"] = (Convert.ToInt32(OfferBundleDropDownList.SelectedValue));
    }

    #endregion

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
