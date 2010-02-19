using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Invoices_SpecialInvoices : System.Web.UI.Page
{
    #region Private Variables
    EventHandler<EventArgs> ChangeState;
    #endregion

    #region Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.ChangeState += new EventHandler<EventArgs>(PageLoadState);
            this.ChangeState(this, e);
        }
        else
        {
            this.ErrorViewControl.Visible = false;
            ////ModifyOrder.ErrorMessageEventHandler += new ErrorMessageEventHandler(ModifyOrder_ErrorMessageEventHandler);
        }

        this.NewSpecialInvoice.CancelHandler += ((send, args) =>
        {
            this.ChangeState += new EventHandler<EventArgs>(CancelOrderState);
            this.ChangeState(this, new EventArgs());
        });

        this.MaintainSpecialInvoices.CancelHandler += ((send, args) =>
        {
            this.ChangeState += new EventHandler<EventArgs>(CancelOrderState);
            this.ChangeState(this, new EventArgs());
        });

        this.NewSpecialInvoice.NewSpecialInvoiceError += new ErrorMessageEventHandler(ModifyOrder_ErrorMessageEventHandler);
        this.MaintainSpecialInvoices.ModifySpecialInvoiceError += new ErrorMessageEventHandler(ModifyOrder_ErrorMessageEventHandler);
    }

    #endregion

    #region Callbacks

    void ModifyOrder_ErrorMessageEventHandler(object sender, ErrorMessageEventArgs e)
    {
        foreach (string errorMessage in e.ErrorMessages)
            this.ErrorViewControl.AddError(errorMessage);
        this.ErrorViewControl.Visible = true;
        this.ErrorViewControl.DataBind();
    }

    #endregion

    #region General Button Event Handlers
    protected void NewInvoiceButton_Click(object sender, EventArgs e)
    {
        DataBind();

        try
        {
            this.ChangeState += new EventHandler<EventArgs>(EnterNewProductState);
            this.ChangeState(this, e);
            //NewOrder.ProductID = null;
            //NewOrder.OrderID = null;
            //ModifyOrder.Reset();
            //NewOrder.Reset();

            AutoGenUI ui = new AutoGenUI();
            this.NewSpecialInvoice.InvoiceNo = "INV-SP-" + ui.Generate().ToString();

            DataBind();
        }
        catch (Exception ex)
        {
            this.ErrorViewControl.AddError(ex.Message);
            this.ErrorViewControl.Visible = true;
        }
    }

    protected void MaintainInvoiceButton_Click(object sender, EventArgs e)
    {
        ChangeState += new EventHandler<EventArgs>(ModifyOrderState);
        ChangeState(this, e);
        //NewOrder.Reset();
        DataBind();
    }
    #endregion

    #region Page States
    protected void PageLoadState(object sender, EventArgs e)
    {
        this.NewSpecialInvoice.Visible = false;
        this.MaintainSpecialInvoices.Visible = false;
    }

    protected void EnterNewProductState(object sender, EventArgs e)
    {
        this.NewSpecialInvoice.Visible = true;
        this.MaintainSpecialInvoices.Visible = false;
    }

    protected void ModifyOrderState(object sender, EventArgs e)
    {
        this.NewSpecialInvoice.Visible = false;
        this.MaintainSpecialInvoices.Visible = true;
    }

    protected void CancelOrderState(object sender, EventArgs e)
    {
        // Util.ClearControls(NewOrder);
        this.NewSpecialInvoice.Visible = false;
        this.MaintainSpecialInvoices.Visible = false;
    }
    #endregion
}
