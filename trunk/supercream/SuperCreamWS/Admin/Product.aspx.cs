using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;

using SP.Util;
using WcfFoundationService;

public partial class Product_Admin : System.Web.UI.Page
{
    #region Private Member Variables
    EventHandler<EventArgs> ChangeState;

    public int ProductID
    {
        get
        {
            return (int)ViewState["ProductID"];
        }
        set
        {
            ViewState["ProductID"] = value;
        }
    }
    #endregion

    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ChangeState += new EventHandler<EventArgs>(PageLoadState);
            ChangeState(this, e);
        }
        else
            ErrorViewControl.Visible = false;
    }
    #endregion

    #region Button Events
    protected void AddProductCodeButton_Click(object sender, EventArgs e)
    {
        try
        {
            using (ProductUI ui = new ProductUI())
            {
                if (ui.ProductCodeExists(this.CodeTestBox.Text))
                    throw new ApplicationException("Cannot add Product - Product Code already exists");

                bool vatExempt = (VatExemptionRadioButtonList.SelectedItem.Text == "Yes") ? true : false;

                using (VatCodeUI vatCodeUI = new VatCodeUI())
                {
                    Product product = new Product()
                    {
                        ID = -1,
                        ProductCode = CodeTestBox.Text,
                        Description = DescriptionTextBox.Text,
                        UnitQty = Convert.ToInt32(UnitQuantityTextBox.Text),
                        UnitPrice = Decimal.Parse(UnitPriceTextBox.Text, System.Globalization.NumberStyles.Currency),
                        RRPPerItem = Decimal.Parse(RRPTextBox.Text, System.Globalization.NumberStyles.Currency),
                        VatExempt = vatExempt
                    };

                    AuditEventsUI.LogEvent("Creating Product", product.Description, Page.ToString(),
                        AuditEventsUI.AuditEventType.Creating);
                    ui.SaveProduct(product);
                }
            }
            ChangeState += new EventHandler<EventArgs>(PageLoadState);
            ChangeState(this, e);
        }
        catch (Exception ex)
        {
            ErrorViewControl.AddError(ex.Message);
            ErrorViewControl.DataBind();
            ErrorViewControl.Visible = true;
        }
    }

    protected void MaintainProductButton_Click(object sender, EventArgs e)
    {
        ChangeState += new EventHandler<EventArgs>(SelectProductState);
        ChangeState(this, e);
    }

    protected void ModifyProductCodeButton_Click(object sender, EventArgs e)
    {
        try
        {
            using (ProductUI ui = new ProductUI())
            {
                bool vatExempt = (ModifyVatExemptionRadioButtonList.SelectedItem.Text == "Yes") ? true : false;

                using (VatCodeUI vatCodeUI = new VatCodeUI())
                {
                    Product product = new Product();
                    product.ID = ProductID;
                    product.ProductCode = ModifyCodeTextBox.Text;
                    product.Description = ModifyDescriptionTextBox.Text;
                    product.UnitQty = Convert.ToInt32(ModifyUnitQuantityTextBox.Text);
                    product.UnitPrice = Decimal.Parse(ModifyUnitPriceTextBox.Text, System.Globalization.NumberStyles.Currency);
                    product.RRPPerItem = Decimal.Parse(ModifyRRPTextBox.Text, System.Globalization.NumberStyles.Currency);
                    product.VatExempt = vatExempt;

                    AuditEventsUI.LogEvent("Updating Product", product.Description, Page.ToString(),
                        AuditEventsUI.AuditEventType.Modifying);

                    ui.UpdateProduct(product);

                    ChangeState += new EventHandler<EventArgs>(PageLoadState);
                    ChangeState(this, e);
                }
            }
        }
        catch (Exception ex)
        {
            ErrorViewControl.AddError(ex.Message);
            ErrorViewControl.Visible = true;
            ErrorViewControl.DataBind();
        }
    }

    protected void NewProductButton_Click(object sender, EventArgs e)
    {
        VatCodeUI vatCodeUI = new VatCodeUI();
        List<VatCode> vatCodeList = vatCodeUI.GetAllVatCodes();

        ChangeState += new EventHandler<EventArgs>(AddNewProductState);
        ChangeState(this, e);
    }

    protected void SearchButton_Click(object sender, EventArgs e)
    {
        ChangeState += new EventHandler<EventArgs>(SearchProductState);
        ChangeState(this, e);

        ProductGridView.PageIndex = 0;
        ProductGridView.DataBind();
        DataBind();
    }

    protected void CancelProductCodeButton_Click(object sender, EventArgs e)
    {
        ProductCodeSearchTextBox.Text = "";
        ProductNameSearchTextBox.Text = "";

        ChangeState += new EventHandler<EventArgs>(CancelProductState);
        ChangeState(this, e);

        // ErrorViewControl.Visible = false;
    }

    protected void CancelNewProductCodeButton_Click1(object sender, EventArgs e)
    {
        Util.ClearControls(AddProductPanel);
        ChangeState += new EventHandler<EventArgs>(PageLoadState);
        ChangeState(this, e);

        // ErrorViewControl.Visible = false;
    }

    #endregion

    #region Grid Events

    protected void ProductGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        AuditEventsUI.LogEvent("Deleting Product", "Product", Page.ToString(),
                        AuditEventsUI.AuditEventType.Deleting);
        ErrorViewControl.Visible = false;
    }

    protected void ProductGridView_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {
        Exception ex = e.Exception;
        if (ex != null)
            HandleException(ex, e);

        DataBind();
    }

    protected void ProductGridView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "ModifyProduct")
        {
            ErrorViewControl.Visible = false;

            ChangeState += new EventHandler<EventArgs>(ModifyProductState);
            ChangeState(this, e);

            ProductUI productUI = new ProductUI();
            Product product = productUI.GetProductByID(Convert.ToInt32(Convert.ToInt32(e.CommandArgument)));

            ProductID = Convert.ToInt32(e.CommandArgument);

            ModifyCodeTextBox.Text = product.ProductCode;
            ModifyDescriptionTextBox.Text = product.Description;
            ModifyUnitQuantityTextBox.Text = product.UnitQty.ToString();

            ModifyUnitPriceTextBox.Text = String.Format("{0:c}", product.UnitPrice);
            ModifyRRPTextBox.Text = String.Format("{0:c}", product.RRPPerItem);
            ModifyVatExemptionRadioButtonList.SelectedIndex = (product.VatExempt == true) ? 0 : 1;

            VatCodeUI vatCodeUI = new VatCodeUI();
            List<VatCode> vatCodeList = vatCodeUI.GetAllVatCodes();
        }
        else if (e.CommandName == "Delete")
        {
            //ChangeState += new EventHandler<EventArgs>(SelectProductState);

            //ProductID = Convert.ToInt32(e.CommandArgument);

            //ProductUI productUI = new ProductUI();
            //productUI.DeleteProduct(ProductID);

            //ChangeState(this, e);

            //DataBind();
        }
    }

    protected void ProductGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        ProductGridView.PageIndex = e.NewPageIndex;
        ProductGridView.DataBind();
    }

    #endregion

    #region Utils
    private void HandleException(Exception ex, GridViewDeletedEventArgs e)
    {
        e.ExceptionHandled = true;
        ErrorViewControl.AddError(ex.InnerException.Message);
        ErrorViewControl.Visible = true;

        DataBind();
    }

    #endregion

    #region Page States

    private void PageLoadState(object src, EventArgs mea)
    {
        Util.ClearFields(this.Page);

        AddProductPanel.Visible = false;
        ModifyProductPanel.Visible = false;
        VatExemptionRadioButtonList.SelectedIndex = 1;
        ErrorViewControl.Visible = false;
        DataBind();
    }

    private void AddNewProductState(object src, EventArgs mea)
    {
        Util.ClearFields(this.Page);

        AddProductPanel.Visible = true;
        ModifyProductPanel.Visible = false;
        GridViewPanel.Visible = false;
    }

    private void ModifyProductState(object src, EventArgs mea)
    {
        Util.ClearFields(this.Page);

        AddProductPanel.Visible = false;
        ModifyProductPanel.Visible = true;
        GridViewPanel.Visible = false;
    }

    private void CancelProductState(object src, EventArgs mea)
    {
        Util.ClearControls(ModifyProductPanel);

        AddProductPanel.Visible = false;
        ModifyProductPanel.Visible = false;
        VatExemptionRadioButtonList.SelectedIndex = 1;
        GridViewPanel.Visible = true;
        ErrorViewControl.Visible = false;
    }

    private void SelectProductState(object src, EventArgs mea)
    {
        Util.ClearFields(this.Page);

        AddProductPanel.Visible = false;
        GridViewPanel.Visible = true;
        ProductGridView.PageIndex = 0;

        DataBind();
    }

    private void SearchProductState(object src, EventArgs mea)
    {
        Util.ClearControls(ModifyProductPanel);

        AddProductPanel.Visible = false;
        ModifyProductPanel.Visible = false;
        VatExemptionRadioButtonList.SelectedIndex = 1;
        ErrorViewControl.Visible = false;
    }
    #endregion

    #region Object Data Source Events
    /*************************************************************************************************************
     * Object Data Source Events
    ************************************************************************************************************/
    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        try
        {
            if ((!String.IsNullOrEmpty(ProductCodeSearchTextBox.Text)) && (!String.IsNullOrEmpty(ProductNameSearchTextBox.Text)))
                throw new ApplicationException("You cannot search on both Product Code and Decription");

            e.InputParameters[0] = ProductCodeSearchTextBox.Text;
            e.InputParameters[1] = ProductNameSearchTextBox.Text;
        }
        catch (Exception ex)
        {
            ErrorViewControl.AddError(ex.Message);
            ErrorViewControl.Visible = true;
            ErrorViewControl.DataBind();
        }
    }

    #endregion

}
