using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Microsoft.Reporting.WebForms;

/// <summary>
/// Summary description for IReportDataSets
/// </summary>
public interface IReportDataSets
{
    /// <summary>
    /// Gets the report data sets.
    /// </summary>
    /// <param name="orderId">The order id.</param>
    /// <param name="accountId">The account id.</param>
    /// <param name="outletStoreId">The outlet store id.</param>
    /// <returns></returns>
    ReportDataSource[] GetReportDataSets(int orderId, int accountId, int outletStoreId);
    ReportDataSource[] GetArbitraryCreditNoteReportDataSets(int creditNoteId);
}
