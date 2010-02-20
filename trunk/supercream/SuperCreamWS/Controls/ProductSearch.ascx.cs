using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using WcfFoundationService;

public partial class Controls_ProductSearch : System.Web.UI.UserControl
{
    public event ErrorMessageEventHandler ProductSearchError;
    public event PurchaseOrderEventHandler PurchaseOrderHandler;

    #region Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    #endregion

    protected void SearchButton_Click(object sender, EventArgs e)
    {
        ErrorMessageEventArgs args = new ErrorMessageEventArgs();       
        DataBind();
    }

    protected void ProductSearchDataSource_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        try
        {
            if ((!String.IsNullOrEmpty(ProductCodeSearchTextBox.Text)) && (!String.IsNullOrEmpty(ProductNameSearchTextBox.Text)))
                throw new ApplicationException("You cannot search on both Product Code and Product Description");

            e.InputParameters[0] = ProductCodeSearchTextBox.Text;
            e.InputParameters[1] = ProductNameSearchTextBox.Text;
        }
        catch (Exception ex)
        {
            ErrorMessageEventArgs args = new ErrorMessageEventArgs();
            args.AddErrorMessages(ex.Message);
            ProductSearchError(this, args);

        }
    }
    protected void ProductSearchGridView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "AddProductToOrder")
        {
            //ChangeState += new EventHandler<EventArgs>(ModifyProductState);
            //ChangeState(this, e);

            ProductUI ui = new ProductUI();
            Product product = ui.GetProductByID(Convert.ToInt32(e.CommandArgument));

            // Now need to get Customer and then get Price List Item
            // to construct OrderEventLineArgs ??

            PurchaseOrderEventArgs args = new PurchaseOrderEventArgs
            {
                 PurchaseOrderID = product.ID
            };

            PurchaseOrderHandler(this, args);
        }
    }
}
