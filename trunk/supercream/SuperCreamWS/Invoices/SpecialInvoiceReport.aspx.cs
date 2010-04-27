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
            IReportDataSets IReportDataSet = new SuperCreamReportDataSets();

            SP.Util.UrlParameterPasser p = new SP.Util.UrlParameterPasser();
            int specialInvoiceId = Convert.ToInt32(p["id"]);
            int accountId = Convert.ToInt32(p["accountId"]);
            int outletStoreId = Convert.ToInt32(p["outletStore"]);

            Microsoft.Reporting.WebForms.ReportDataSource[] reportDataSets = IReportDataSet.GetReportDataSets(specialInvoiceId, accountId, outletStoreId);
         
            SpecialInvoiceReportViewer.LocalReport.DataSources.Clear();
            foreach (Microsoft.Reporting.WebForms.ReportDataSource reportDataSet in reportDataSets)
            {
                SpecialInvoiceReportViewer.LocalReport.DataSources.Add(reportDataSet);
            }           
            //if (reportDataSets.Tables[0].Rows.Count == 0)
            //{
            //    lblMessage.Text = "Sorry, no products under this category!";
            //}

            SpecialInvoiceReportViewer.LocalReport.Refresh();

        }
    }
}
 