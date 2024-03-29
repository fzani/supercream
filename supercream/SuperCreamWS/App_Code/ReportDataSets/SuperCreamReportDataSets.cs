﻿using System;
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
public class SuperCreamReportDataSets : IReportDataSets
{
    #region Constructors
    /// <summary>
    /// Initializes a new instance of the <see cref="ReportDataSets"/> class.
    /// </summary>    
    public SuperCreamReportDataSets()
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

    public ReportDataSource[] GetSpecialInvoiceArbitraryCreditNoteReportDataSets(int creditNoteId, int accountId)
    {
        DataSet dsCreditNotes = GetSpecialInvoiceArbitraryCreditNoteDS(creditNoteId);
        DataSet dsFoundationAddressLines = GetFoundationFacilityAddressLinesDS(999); // Fake ID doesn't matter ignored ...
        DataSet dsInvoiceAddressLines = GetInvoiceAddressLinesDS(accountId);

        ReportDataSource[] reportDataSources = new ReportDataSource[3];

        reportDataSources[0] = new
           ReportDataSource("SuperCreamDBDataSet_rptGetSpecialInvoiceArbitraryCreditNote",
             dsCreditNotes.Tables[0]);

        reportDataSources[1] = new
           ReportDataSource("SuperCreamDBDataSet_rptGetFoundationFacilityAddressLines",
               dsFoundationAddressLines.Tables[0]);

        reportDataSources[2] = new
           ReportDataSource("SuperCreamDBDataSet_rptGetAddressLinesForInvoice",
               dsInvoiceAddressLines.Tables[0]);

        return reportDataSources;
    }

    public ReportDataSource[] GetArbitraryCreditNoteReportDataSets(int creditNoteId, int accountId)
    {
        DataSet dsCreditNotes = GetArbitraryCreditNoteDS(creditNoteId);
        DataSet dsFoundationAddressLines = GetFoundationFacilityAddressLinesDS(999); // Fake ID doesn't matter ignored ...
        DataSet dsInvoiceAddressLines = GetInvoiceAddressLinesDS(accountId);

        ReportDataSource[] reportDataSources = new ReportDataSource[3];

        reportDataSources[0] = new
           ReportDataSource("SuperCreamDBDataSet_rptGetArbitraryCreditNote",
             dsCreditNotes.Tables[0]);

        reportDataSources[1] = new
           ReportDataSource("SuperCreamDBDataSet_rptGetFoundationFacilityAddressLines",
               dsFoundationAddressLines.Tables[0]);

        reportDataSources[2] = new
           ReportDataSource("SuperCreamDBDataSet_rptGetAddressLinesForInvoice",
               dsInvoiceAddressLines.Tables[0]);

        return reportDataSources;
    }

    public ReportDataSource[] GetOrderCreditNoteReportDataSets(int creditNoteId, int accountId)
    {
        DataSet dsCreditNotes = GetOrderCreditNoteDS(creditNoteId);
        DataSet dsFoundationAddressLines = GetFoundationFacilityAddressLinesDS(999); // Fake ID doesn't matter ignored ...
        DataSet dsInvoiceAddressLines = GetInvoiceAddressLinesDS(accountId);
        DataSet dsOrderCreditNoteLines = GetOrderCreditNoteTotalsDS(creditNoteId);

        ReportDataSource[] reportDataSources = new ReportDataSource[4];

        reportDataSources[0] = new
           ReportDataSource("SuperCreamDBDataSet_rptGetOrderCreditNote",
             dsCreditNotes.Tables[0]);

        reportDataSources[1] = new
           ReportDataSource("SuperCreamDBDataSet_rptGetFoundationFacilityAddressLines",
               dsFoundationAddressLines.Tables[0]);

        reportDataSources[2] = new
           ReportDataSource("SuperCreamDBDataSet_rptGetAddressLinesForInvoice",
               dsInvoiceAddressLines.Tables[0]);

        reportDataSources[3] = new
           ReportDataSource("SuperCreamDBDataSet_rptGetOrderCreditNoteTotals",
               dsOrderCreditNoteLines.Tables[0]);

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

    private static DataSet GetOrderCreditNoteTotalsDS(int orderId)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["SuperCreamDBConnectionString"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();

        SqlCommand command = new SqlCommand();
        command.CommandType = System.Data.CommandType.StoredProcedure;
        command.CommandText = "rptGetOrderCreditNoteTotals";
        command.Connection = connection;

        SqlParameter orderParameterId = command.Parameters.Add("@CreditNoteId", System.Data.SqlDbType.Int);
        orderParameterId.Value = orderId;

        DataSet dataSet = new DataSet("OrderCreditNoteTotalsSA");

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

    private static DataSet GetArbitraryCreditNoteDS(int creditNoteId)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["SuperCreamDBConnectionString"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();

        SqlCommand command = new SqlCommand();
        command.CommandType = System.Data.CommandType.StoredProcedure;
        command.CommandText = "rptGetArbitraryCreditNote";
        command.Connection = connection;

        SqlParameter creditIdParameter = command.Parameters.Add("@CreditNoteID", System.Data.SqlDbType.Int);
        creditIdParameter.Value = creditNoteId;

        DataSet dataSet = new DataSet("CreditNoteDS");

        SqlDataAdapter adapter = new SqlDataAdapter(command);
        adapter.Fill(dataSet);
        return dataSet;
    }

    private static DataSet GetOrderCreditNoteDS(int creditNoteId)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["SuperCreamDBConnectionString"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();

        SqlCommand command = new SqlCommand();
        command.CommandType = System.Data.CommandType.StoredProcedure;
        command.CommandText = "rptGetOrderCreditNote";
        command.Connection = connection;

        SqlParameter creditIdParameter = command.Parameters.Add("@CreditNoteID", System.Data.SqlDbType.Int);
        creditIdParameter.Value = creditNoteId;

        DataSet dataSet = new DataSet("CreditNoteDS");

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

    private static DataSet GetSpecialInvoiceArbitraryCreditNoteDS(int creditNoteId)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["SuperCreamDBConnectionString"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();

        SqlCommand command = new SqlCommand();
        command.CommandType = System.Data.CommandType.StoredProcedure;
        command.CommandText = "rptGetSpecialInvoiceArbitraryCreditNote";
        command.Connection = connection;

        SqlParameter creditIdParameter = command.Parameters.Add("@CreditNoteID", System.Data.SqlDbType.Int);
        creditIdParameter.Value = creditNoteId;

        DataSet dataSet = new DataSet("CreditNoteDS");

        SqlDataAdapter adapter = new SqlDataAdapter(command);
        adapter.Fill(dataSet);
        return dataSet;
    }

    #endregion
}
