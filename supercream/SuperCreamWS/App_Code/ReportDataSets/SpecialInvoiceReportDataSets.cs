using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.Reporting.WebForms;

/// <summary>
/// Summary description for ReportDataSets
/// </summary>
public class SpecialInvoiceReportDataSets : IReportDataSets
{
    #region Constructors
    /// <summary>
    /// Initializes a new instance of the <see cref="ReportDataSets"/> class.
    /// </summary>    
    public SpecialInvoiceReportDataSets()
    {
    }

    #endregion

    #region IReportDataSets Members

    public ReportDataSource[] GetReportDataSets(int specialInvoiceId, int accountId, int outletStoreId)
    {
        DataSet dsInvoiceTotals = GetInvoiceTotalsDS(specialInvoiceId);
        DataSet dsInvoiceDetails = GetInvoiceDetailsDS(specialInvoiceId, accountId, outletStoreId);
        DataSet dsInvoiceAddressLines = GetInvoiceAddressLinesDS(accountId);
        DataSet dsDeliveryAddressLines = GetDeliveryAddressLinesDS(outletStoreId);
        DataSet dsFoundationAddressLines = GetFoundationFacilityAddressLinesDS(outletStoreId);

        ReportDataSource[] reportDataSources = new ReportDataSource[5];

        reportDataSources[0] = new
           ReportDataSource("SuperCreamDBDataSet_rptGetSpecialInvoiceDetails",
             dsInvoiceDetails.Tables[0]);

        reportDataSources[1] = new
            ReportDataSource("SuperCreamDBDataSet_rptGetSpecialInvoiceTotals",
                dsInvoiceTotals.Tables[0]);

        reportDataSources[2] = new
            ReportDataSource("SuperCreamDBDataSet_rptGetAddressLinesForInvoice",
                dsInvoiceAddressLines.Tables[0]);

        reportDataSources[3] = new
            ReportDataSource("SuperCreamDBDataSet_rptGetDeliveryAddressLines",
                dsDeliveryAddressLines.Tables[0]);

        reportDataSources[4] = new
            ReportDataSource("SuperCreamDBDataSet_rptGetFoundationFacilityAddressLines",
                dsFoundationAddressLines.Tables[0]);

        return reportDataSources;
    }

    #endregion

    #region Private Helpers

    private static DataSet GetInvoiceTotalsDS(int orderId)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["SuperCreamDBConnectionString"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();

        SqlCommand command = new SqlCommand();
        command.CommandType = System.Data.CommandType.StoredProcedure;
        command.CommandText = "rptGetSpecialInvoiceTotals";
        command.Connection = connection;

        SqlParameter orderParameterId = command.Parameters.Add("@SpecialInvoiceID", System.Data.SqlDbType.Int);
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

    private static DataSet GetInvoiceDetailsDS(int specialInvoiceID, int accountNo, int outletStoreId)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["SuperCreamDBConnectionString"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();

        SqlCommand command = new SqlCommand();
        command.CommandType = System.Data.CommandType.StoredProcedure;
        command.CommandText = "rptGetSpecialInvoiceDetails";
        command.Connection = connection;

        SqlParameter orderIDParameter = command.Parameters.Add("@SpecialInvoiceID", System.Data.SqlDbType.Int);
        orderIDParameter.Value = specialInvoiceID;

        DataSet invoiceHeaderDataSet = new DataSet("InvoiceHeaderSA");

        SqlDataAdapter adapter = new SqlDataAdapter(command);
        adapter.Fill(invoiceHeaderDataSet);
        return invoiceHeaderDataSet;
    }

    #endregion
}
