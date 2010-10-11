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

            DataBind();
        }
        else
        {
            ErrorViewControl.Visible = false;                    
        }
        EditBundledOrder.ErrorMessageEventHandler += new ErrorMessageEventHandler(EditBundledOrder_ErrorMessageEventHandler);
    }

    void EditBundledOrder_ErrorMessageEventHandler(object sender, ErrorMessageEventArgs e)
    {
        foreach (string error in e.ErrorMessages)
        {
            ErrorViewControl.AddError(error);
        }

        ErrorViewControl.DataBind();
        ErrorViewControl.Visible = true;
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

    protected void MaintainBundledOrdersButton_Click(object sender, EventArgs e)
    {
        ChangeState += new EventHandler<EventArgs>(ModifyBundledOrderState);
        ChangeState(this, e);
        // NewOrder.Reset();
        DataBind();
    }

    #endregion

    #region Page States

    protected void PageLoadState(object sender, EventArgs e)
    {

    }

    protected void EnterNewProductState(object sender, EventArgs e)
    {
        //NewOrder.Visible = true;
        //ModifyOrder.Visible = false;
    }

    protected void ModifyBundledOrderState(object sender, EventArgs e)
    {
        //MaintainBundledOrder.Visible = true;
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
