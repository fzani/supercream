using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Invoices_SpecialInvoiceReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            IReportDataSets reportDataSet = new SpecialInvoiceReportDataSets();
            int specialInvoiceId = 304;
            int accountId = 404;
            int outletStoreId = 200;

            Microsoft.Reporting.WebForms.ReportDataSource[] reportDataSets = reportDataSet.GetReportDataSets(specialInvoiceId, accountId, outletStoreId);
         
            SpecialInvoiceReportViewer.LocalReport.DataSources.Clear();
            SpecialInvoiceReportViewer.LocalReport.DataSources.Add(reportDataSets[0]);
            //if (reportDataSets.Tables[0].Rows.Count == 0)
            //{
            //    lblMessage.Text = "Sorry, no products under this category!";
            //}

            SpecialInvoiceReportViewer.LocalReport.Refresh();

        }
    }
}
 