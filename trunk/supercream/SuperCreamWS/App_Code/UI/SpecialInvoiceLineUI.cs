using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Transactions;

using SP.Util;

using WcfFoundationService;

/// <summary>
/// Summary description for SpecialInvoiceListUI
/// </summary>
[System.ComponentModel.DataObject]
public class SpecialInvoiceLineUI : IDisposable
{
    private WcfFoundationService.FoundationServiceClient _proxy;

    public SpecialInvoiceLineUI()
    {

    }

    public List<SpecialInvoiceLine> GetSpecialInvoiceLines(int id)
    {
        using (_proxy = new WcfFoundationService.FoundationServiceClient())
        {
            return _proxy.GetBySpecialInvoiceId(id);
        }
    }

    public SpecialInvoiceLine Save(SpecialInvoiceLine SpecialInvoiceLine)
    {
        using (_proxy = new WcfFoundationService.FoundationServiceClient())
        {
            return _proxy.SaveSpecialInvoiceLine(SpecialInvoiceLine);
        }
    }

    public void Update(SpecialInvoiceLine newSpecialInvoiceLine)
    {
        using (_proxy = new WcfFoundationService.FoundationServiceClient())
        {
            SpecialInvoiceLine origSpecialInvoiceLine = _proxy.GetSpecialInvoiceLine(newSpecialInvoiceLine.ID);
            SpecialInvoiceLine updatedSpecialInvoiceLine = origSpecialInvoiceLine.Clone<SpecialInvoiceLine>();
            updatedSpecialInvoiceLine.Description = newSpecialInvoiceLine.Description;
            updatedSpecialInvoiceLine.Discount = newSpecialInvoiceLine.Discount;
            updatedSpecialInvoiceLine.NoOfUnits = newSpecialInvoiceLine.NoOfUnits;

            //// updatedSpecialInvoiceLine.SpecialInvoiceID = origSpecialInvoiceLine.SpecialInvoiceHeader;
            updatedSpecialInvoiceLine.SpecialInvoiceID = newSpecialInvoiceLine.SpecialInvoiceID;
            updatedSpecialInvoiceLine.OrderLineStatus = origSpecialInvoiceLine.OrderLineStatus;
            updatedSpecialInvoiceLine.Price = newSpecialInvoiceLine.Price;
            updatedSpecialInvoiceLine.QtyPerUnit = newSpecialInvoiceLine.QtyPerUnit;
            updatedSpecialInvoiceLine.SpecialInstructions = newSpecialInvoiceLine.SpecialInstructions;

            _proxy.UpdateSpecialInvoiceLine(updatedSpecialInvoiceLine, origSpecialInvoiceLine);
        }
    }

    public SpecialInvoiceLine GetSpecialInvoiceLine(int id)
    {
        using (_proxy = new WcfFoundationService.FoundationServiceClient())
        {
            return _proxy.GetSpecialInvoiceLine(id);
        }
    }

    public void DeleteSpecialInvoiceLine(int id)
    {
        using (_proxy = new WcfFoundationService.FoundationServiceClient())
        {
            SpecialInvoiceLine line = _proxy.GetSpecialInvoiceLine(id);
            _proxy.DeleteSpecialInvoiceLine(line);
        }
    }

    Decimal CalculateDiscount(Decimal discount, Decimal unitPrice)
    {
        return Math.Round(unitPrice - ((unitPrice / 100) * discount), 2);
    }

    #region IDisposable Members

    public void Dispose()
    {
    }

    #endregion

    ~SpecialInvoiceLineUI()
    {
    }
}
