using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controls_MaintainCompletedInvoices : System.Web.UI.UserControl
{
    #region Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    #endregion

    #region Object Data Source Events

    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        DateTime outDateTime;

        e.InputParameters[0] = OrderNoSearchTextBox.Text;
        e.InputParameters[1] = InvoiceNoSearchTextBox.Text;

        e.InputParameters[2] = CustomerNameSearchTextBox.Text;

        e.InputParameters[3] = Util.ConvertToDateTime(DateFromTextBox.Text);
        e.InputParameters[4] = Util.ConvertToDateTime(DateToTextBox.Text);

        switch (Convert.ToInt32(InvoicesPrintedDropDownList.SelectedValue))
        {
            case -1:
                e.InputParameters[5] = (short)SP.Core.Enums.OrderStatus.Invoice;
                break;
            case (short)SP.Core.Enums.OrderStatus.Invoice:
                e.InputParameters[5] = (short)SP.Core.Enums.OrderStatus.Invoice;
                break;
            case (short)SP.Core.Enums.OrderStatus.InvoicePrinted:
                e.InputParameters[5] = (short)SP.Core.Enums.OrderStatus.InvoicePrinted;
                break;
        }
    }

    #endregion

    #region General Event Handlers     

    protected void SearchButton_Click(object sender, EventArgs e)
    {
        InvoiceDetailsListView.DataBind();
    }

    protected void ClearButton_Click(object sender, EventArgs e)
    {
        Util.ClearControls(InvoiceSearchCriteriaPanel);
        DataBind();
    }

    #endregion
}
