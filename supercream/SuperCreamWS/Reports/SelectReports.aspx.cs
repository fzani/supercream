using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using ReportsWS;

public partial class Reports_SelectReports : System.Web.UI.Page
{
    #region Page Event Handler

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string superCreamReportsPath =
                System.Configuration.ConfigurationManager.AppSettings["SuperCreamReportsPath"];

            ReportsWS.ReportingService2005 rs = new ReportsWS.ReportingService2005();
            rs.Credentials = System.Net.CredentialCache.DefaultCredentials;
            CatalogItem[] catalogItems;
            catalogItems = rs.ListChildren("/" + superCreamReportsPath, true);
            catalogItems.OrderBy(q => q.Name.Substring(0, 2));

            string strDisplay;
            foreach (var reportItem in catalogItems.Where(
                q => !q.Name.Contains("InvoicePrint") &&
                    !q.Name.Contains("ProformaInvoice") &&
                    !q.Name.Contains("DeliveryNote") &&
                    !q.Name.Contains("SpecialInvoiceReport")
                ))
            {
                // Form the string to display and add it to the list box               
                var item = new ListItem
                               {
                                   Value = reportItem.Path,
                                   Text = reportItem.Name
                               };
                ReportsDropDownList.Items.Add(item);
            }
        }
    }

    #endregion

    #region General Event Handlers

    protected void OnClick_SelectButton(object sender, EventArgs e)
    {
        string reportingServicesUrl = System.Configuration.ConfigurationManager.AppSettings["SuperCreamReportUrl"];
        string reportPath = ReportsDropDownList.SelectedValue.ToString();

        Response.Redirect(reportingServicesUrl + "/Pages/ReportViewer.aspx?" + reportPath + "&rs:Command=Render");
    }

    #endregion
}
