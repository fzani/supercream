using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Text;
using Microsoft.Reporting.WebForms;
using System.Configuration;

namespace SP.Utils
{
    public class PrintReport : IDisposable, IPrintReport
    {
        private int currentPageIndex;
        private IList<Stream> streams;
        private PageMode pageMode;

        /// <summary>
        /// Initializes a new instance of the <see cref="PrintReport"/> class.
        /// </summary>
        public PrintReport()
        {
        }

        /// <summary>
        /// Create a local report for Report.rdlc, load the data,
        /// export the report to an .emf file, and print it.
        /// </summary>
        /// <param name="ReportName">Name of the report.</param>
        /// <param name="PrinterName">Name of the printer.</param>
        /// <param name="MyDataTable">My data table.</param>
        /// <param name="DSstring">The D sstring.</param>
        public void Run(string reportName, DataSet[] dataSets, PageMode pageMode)
        {
            LocalReport report = new LocalReport();
            report.ReportPath = reportName;

            report.DataSources.Clear();
            foreach (DataSet dataSet in dataSets)
            {
                report.DataSources.Add(new ReportDataSource(dataSet.DataSetName, dataSet.Tables[0]));
            }

            this.pageMode = pageMode;

            Export(report);

            this.currentPageIndex = 0;

            Print();
        }

        /// <summary>
        /// Create a local report for Report.rdlc, load the data,
        /// export the report to an .emf file, and print it.
        /// </summary>
        /// <param name="ReportName">Name of the report.</param>
        /// <param name="PrinterName">Name of the printer.</param>
        /// <param name="MyDataTable">My data table.</param>
        /// <param name="DSstring">The D sstring.</param>
        public void Run(string reportName, ReportDataSource[] reportDataSources, PageMode pageMode)
        {
            LocalReport report = new LocalReport();
            report.ReportPath = reportName;

            report.DataSources.Clear();
            foreach (ReportDataSource reportDataSource in reportDataSources)
            {
                report.DataSources.Add(reportDataSource);
            }

            this.pageMode = pageMode;

            Export(report);

            this.currentPageIndex = 0;

            Print();
        }

        /// <summary>
        /// Creates the stream.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="fileNameExtension">The file name extension.</param>
        /// <param name="encoding">The encoding.</param>
        /// <param name="mimeType">Type of the MIME.</param>
        /// <param name="willSeek">if set to <c>true</c> [will seek].</param>
        /// <returns>Stream</returns>
        private Stream CreateStream(string fileName, string fileNameExtension, Encoding encoding, string mimeType, bool willSeek)
        {
            string printerTempFilesLocation = System.Configuration.ConfigurationManager.AppSettings["PrinterTempFiles"];
            // Stream stream = new FileStream("C:\\Labels\\" + fileName + "." + fileNameExtension, FileMode.Create);
            Stream stream = new FileStream(printerTempFilesLocation + "\\" + fileName + "." + fileNameExtension, FileMode.Create);
            this.streams.Add(stream);

            return stream;
        }

        /// <summary>
        /// Exports the specified report.
        /// </summary>
        /// <param name="report">The report.</param>
        private void Export(LocalReport report)
        {
            string deviceInfo;

            if (pageMode == PageMode.Portrait)
            {
                deviceInfo =
                    "<DeviceInfo>" +
                    " <OutputFormat>EMF</OutputFormat>" +
                    " <PageWidth>21cm</PageWidth>" +
                    " <PageHeight>29.7cm</PageHeight>" +
                    " <MarginTop>0.2cm</MarginTop>" +
                    " <MarginLeft>0.2cm</MarginLeft>" +
                    " <MarginRight>0.2cm</MarginRight>" +
                    " <MarginBottom>0.2cm</MarginBottom>" +
                    "</DeviceInfo>";
            }
            else
            {
                deviceInfo =
                   "<DeviceInfo>" +
                   " <OutputFormat>EMF</OutputFormat>" +
                   " <PageWidth>29.7cm</PageWidth>" +
                   " <PageHeight>21cm</PageHeight>" +
                   " <MarginTop>0.2cm</MarginTop>" +
                   " <MarginLeft>0.2cm</MarginLeft>" +
                   " <MarginRight>0.2cm</MarginRight>" +
                   " <MarginBottom>0.2cm</MarginBottom>" +
                   "</DeviceInfo>";
            }

            Warning[] warnings; streams = new List<Stream>();

            report.Render("Image", deviceInfo, CreateStream, out warnings);

            foreach (Stream stream in this.streams)
                stream.Position = 0;

        }

        /// <summary>
        /// Prints the page.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="ev">The <see cref="System.Drawing.Printing.PrintPageEventArgs"/> instance containing the event data.</param>
        private void PrintPage(object sender, PrintPageEventArgs ev)
        {
            Metafile pageImage = new Metafile(this.streams[this.currentPageIndex]);
            ev.Graphics.DrawImage(pageImage, ev.PageBounds);

            this.currentPageIndex++;

            ev.HasMorePages = (this.currentPageIndex < this.streams.Count);
        }

        /// <summary>
        /// Prints the specified printer name.
        /// </summary>
        /// <param name="PrinterName">Name of the printer.</param>
        private void Print()
        {
            string printerName = System.Configuration.ConfigurationManager.AppSettings["ReportPrinterName"];
            if (this.streams == null || this.streams.Count == 0)
                return;

            PrintDocument printDocument = new PrintDocument();
            printDocument.PrinterSettings.PrinterName = printerName;
            printDocument.DefaultPageSettings.Landscape = (pageMode == PageMode.Landscape) ? true : false;

            if (!printDocument.PrinterSettings.IsValid)
            {
                string msg = String.Format(
                    "Can't find printer \"{0}\".", printerName);
                throw new ApplicationException(msg);
            }

            printDocument.PrintPage += new PrintPageEventHandler(PrintPage);
            printDocument.Print();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            if (this.streams != null)
            {
                foreach (Stream stream in this.streams)
                    stream.Close();

                this.streams = null;
            }
        }
    }
}
