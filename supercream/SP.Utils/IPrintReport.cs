using System.Data;
using Microsoft.Reporting.WebForms;

namespace SP.Utils
{
    interface IPrintReport
    {        
        /// <summary>
        /// Runs the specified report name.
        /// </summary>
        /// <param name="reportName">Name of the report.</param>
        /// <param name="printerName">Name of the printer.</param>
        /// <param name="dataSets">The data sets.</param>
        /// <param name="pageMode">The page mode.</param>
        void Run(string reportName, DataSet[] dataSets, PageMode pageMode, string printerName);
        void Run(string reportName, ReportDataSource[] reportDataSources, PageMode pageMode, string printerName);
    }
}
