using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Ordering_Orders : System.Web.UI.Page
{
    #region Private Variables
    EventHandler<EventArgs> ChangeState;
    #endregion

    #region Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ChangeState += new EventHandler<EventArgs>(PageLoadState);
            ChangeState(this, e);
        }
        else
        {
            ErrorViewControl.Visible = false;
            //NewOrder.ProductSearchError += ProductSearch_Error;
            //NewOrder.CancelHandler += new CancelEventHandler(NewOrder_CancelHandler);
            //ModifyOrder.ErrorMessageEventHandler += new ErrorMessageEventHandler(ModifyOrder_ErrorMessageEventHandler);
        }
    }

    #endregion

    #region Callbacks
    protected void ProductSearch_Error(object sender, ErrorMessageEventArgs e)
    {
        foreach (string errorMessage in e.ErrorMessages)
            ErrorViewControl.AddError(errorMessage);
        ErrorViewControl.Visible = true;
        ErrorViewControl.DataBind();
    }

    void ModifyOrder_ErrorMessageEventHandler(object sender, ErrorMessageEventArgs e)
    {
        foreach (string errorMessage in e.ErrorMessages)
            ErrorViewControl.AddError(errorMessage);
        ErrorViewControl.Visible = true;
        ErrorViewControl.DataBind();
    }

    void NewOrder_CancelHandler(object sender, EventArgs e)
    {
        //    NewOrder.OrderID = null; // Reset Order ID
        ChangeState += new EventHandler<EventArgs>(CancelOrderState);
        ChangeState(this, new EventArgs());
    }
    #endregion

    #region General Button Event Handlers
    protected void NewBundledOrderButton_Click(object sender, EventArgs e)
    {
        DataBind();

        try
        {
            //ChangeState += new EventHandler<EventArgs>(EnterNewProductState);
            //ChangeState(this, e);
            //NewOrder.ProductID = null;
            //NewOrder.OrderID = null;
            //ModifyOrder.Reset();
            //NewOrder.Reset();

            //////OrderHeaderUI ui = new OrderHeaderUI();
            //////NewOrder.AlphaID = ui.GenerateOrderNo();

            //DataBind();
        }
        catch (Exception ex)
        {
            ErrorViewControl.AddError(ex.Message);
            ErrorViewControl.Visible = true;
        }
    }

    protected void MaintainBundledOrdersButton_Click(object sender, EventArgs e)
    {
        ChangeState += new EventHandler<EventArgs>(ModifyOrderState);
        ChangeState(this, e);
        // NewOrder.Reset();
        DataBind();
    }
    #endregion

    #region Page States
    protected void PageLoadState(object sender, EventArgs e)
    {
        //NewOrder.Visible = false;
        //ModifyOrder.Visible = false;
    }

    protected void EnterNewProductState(object sender, EventArgs e)
    {
        //NewOrder.Visible = true;
        //ModifyOrder.Visible = false;
    }

    protected void ModifyOrderState(object sender, EventArgs e)
    {
        //NewOrder.Visible = false;
        //ModifyOrder.Visible = true;
    }

    protected void CancelOrderState(object sender, EventArgs e)
    {
        //Util.ClearControls(NewOrder);
        //NewOrder.Visible = false;
        //NewOrder.OrderDate = DateTime.Now;
    }
    #endregion    
}
