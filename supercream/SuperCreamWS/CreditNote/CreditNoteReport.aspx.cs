using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CreditNote_CreditNoteReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        IReportDataSets IReportDataSet = new SuperCreamReportDataSets();

        SP.Util.UrlParameterPasser p = new SP.Util.UrlParameterPasser();
        int creditNoteId = Convert.ToInt32(p["creditNoteId"]);
        int accountId = Convert.ToInt32(p["accountId"]);

        Microsoft.Reporting.WebForms.ReportDataSource[] reportDataSets =
            IReportDataSet.GetArbitraryCreditNoteReportDataSets(creditNoteId, accountId);

        CreditNoteReportViewer.LocalReport.DataSources.Clear();
        foreach (Microsoft.Reporting.WebForms.ReportDataSource reportDataSet in reportDataSets)
        {
            CreditNoteReportViewer.LocalReport.DataSources.Add(reportDataSet);
        }
        //if (reportDataSets.Tables[0].Rows.Count == 0)
        //{
        //    lblMessage.Text = "Sorry, no products under this category!";
        //}

        CreditNoteReportViewer.LocalReport.Refresh();
    }
}
