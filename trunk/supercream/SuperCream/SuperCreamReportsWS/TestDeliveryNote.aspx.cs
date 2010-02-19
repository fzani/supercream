using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Reporting.WebForms;

namespace SuperCreamReportsWS
{
    public partial class TestDeliveryNote : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private static DataSet GetInvoiceTotalsDS(int orderId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SuperCreamDBConnectionString"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "rptGetOrderTotals";
            command.Connection = connection;

            SqlParameter orderParameterId = command.Parameters.Add("@OrderID", System.Data.SqlDbType.Int);
            orderParameterId.Value = orderId;

            DataSet dataSet = new DataSet("InvoiceTotalsSA");

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(dataSet);
            return dataSet;
        }

        private static DataSet GetDeliveryAddressLinesDS(int outletStoreId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SuperCreamDBConnectionString"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "rptGetDeliveryAddressLines";
            command.Connection = connection;

            SqlParameter outletStoreIdParmeter = command.Parameters.Add("@OutletStoreID", System.Data.SqlDbType.Int);
            outletStoreIdParmeter.Value = outletStoreId;

            DataSet dataSet = new DataSet("DeliveryAddressLinesDS");

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(dataSet);
            return dataSet;
        }

        private static DataSet GetInvoiceAddressLinesDS(int accountId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SuperCreamDBConnectionString"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "rptGetAddressLinesForInvoice";
            command.Connection = connection;

            SqlParameter accountIdParameter = command.Parameters.Add("@AccountID", System.Data.SqlDbType.Int);
            accountIdParameter.Value = accountId;

            DataSet dataSet = new DataSet("InvoiceAddressLinesDS");

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(dataSet);
            return dataSet;
        }

        private static DataSet GetFoundationFacilityAddressLinesDS(int accountId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SuperCreamDBConnectionString"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "rptGetFoundationFacilityAddressLines";
            command.Connection = connection;

            SqlParameter accountIdParameter = command.Parameters.Add("@AccountID", System.Data.SqlDbType.Int);
            accountIdParameter.Value = accountId;

            DataSet dataSet = new DataSet("FoundationFacilityAddressLines");

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(dataSet);
            return dataSet;
        }

        private static DataSet GetInvoiceHeaderDS(int orderID, int accountNo, int outletStoreId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SuperCreamDBConnectionString"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "rptDetailsGetInvoice";
            command.Connection = connection;

            SqlParameter orderIDParameter = command.Parameters.Add("@OrderID", System.Data.SqlDbType.Int);
            orderIDParameter.Value = orderID;

            SqlParameter accountIDParameter = command.Parameters.Add("@AccountID", System.Data.SqlDbType.Int);
            accountIDParameter.Value = accountNo;

            SqlParameter outletStoreIdParameter = command.Parameters.Add("@OutletStoreID", System.Data.SqlDbType.Int);
            outletStoreIdParameter.Value = outletStoreId;

            DataSet invoiceHeaderDataSet = new DataSet("InvoiceHeaderSA");

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(invoiceHeaderDataSet);
            return invoiceHeaderDataSet;
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            ReportViewer1.Enabled = true;

            DataSet ds = GetInvoiceTotalsDS(30);
            DataSet ds1 = GetInvoiceHeaderDS(30, 135, 111);
            DataSet ds2 = GetInvoiceAddressLinesDS(135);
            DataSet ds3 = GetDeliveryAddressLinesDS(111);
            DataSet ds4 = GetFoundationFacilityAddressLinesDS(111);


            ReportDataSource datasource = new
            ReportDataSource("SuperCreamDBDataSet_rptGetOrderTotals",
                ds.Tables[0]);

            ReportDataSource datasource1 = new
            ReportDataSource("SuperCreamDBDataSet_rptDetailsGetInvoice",
             ds1.Tables[0]);

            ReportDataSource datasource2 = new
            ReportDataSource("SuperCreamDBDataSet_rptGetAddressLinesForInvoice",
               ds2.Tables[0]);

            ReportDataSource datasource3 = new
            ReportDataSource("SuperCreamDBDataSet_rptGetDeliveryAddressLines",
             ds3.Tables[0]);

            ReportDataSource datasource4 = new
            ReportDataSource("SuperCreamDBDataSet_rptGetFoundationFacilityAddressLines",
            ds4.Tables[0]);

            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(datasource);
            ReportViewer1.LocalReport.DataSources.Add(datasource1);
            ReportViewer1.LocalReport.DataSources.Add(datasource2);
            ReportViewer1.LocalReport.DataSources.Add(datasource3);
            ReportViewer1.LocalReport.DataSources.Add(datasource4);

            ReportViewer1.LocalReport.Refresh();

        }
    }
}
