using System;
using System.Collections.Generic;

using SP.Util;

using WcfFoundationService;

/// <summary>
/// Invoice Header UI
/// </summary>
[System.ComponentModel.DataObject]
public class SpecialInvoiceHeaderUI : IDisposable
{
    private WcfFoundationService.FoundationServiceClient _proxy;

    public SpecialInvoiceHeaderUI()
    {
    }

    public SpecialInvoiceHeader Save(SpecialInvoiceHeader specialInvoiceHeader)
    {
        using (_proxy = new WcfFoundationService.FoundationServiceClient())
        {
            return _proxy.SaveSpecialInvoiceHeader(specialInvoiceHeader);
        }
    }

    public SpecialInvoiceHeader GetById(int id)
    {
        using (_proxy = new WcfFoundationService.FoundationServiceClient())
        {
            return _proxy.GetSpecialInvoiceHeader(id);
        }
    }

    public void Update(SpecialInvoiceHeader newSpecialInvoice)
    {
        using (_proxy = new WcfFoundationService.FoundationServiceClient())
        {
            SpecialInvoiceHeader originalSpecialInvoice = _proxy.GetSpecialInvoiceHeader(newSpecialInvoice.ID);
            SpecialInvoiceHeader updatedSpecialInvoice = originalSpecialInvoice.Clone<SpecialInvoiceHeader>();

            updatedSpecialInvoice.AlphaID = newSpecialInvoice.AlphaID;
            updatedSpecialInvoice.CustomerID = newSpecialInvoice.CustomerID;
            updatedSpecialInvoice.AccountID = newSpecialInvoice.AccountID;
            updatedSpecialInvoice.OutletStoreID = newSpecialInvoice.OutletStoreID;
            updatedSpecialInvoice.ID = newSpecialInvoice.ID;
            updatedSpecialInvoice.OrderDate = newSpecialInvoice.OrderDate;
            updatedSpecialInvoice.DeliveryDate = newSpecialInvoice.DeliveryDate;
            updatedSpecialInvoice.OrderStatus = (short)originalSpecialInvoice.OrderStatus;
            updatedSpecialInvoice.SpecialInstructions = newSpecialInvoice.SpecialInstructions;
            updatedSpecialInvoice.DateModified = newSpecialInvoice.DateModified;

            _proxy.UpdateSpecialInvoiceHeader(updatedSpecialInvoice, originalSpecialInvoice);
        }
    }

    public void DeleteSpecialInvoice(int id)
    {
        using (_proxy = new WcfFoundationService.FoundationServiceClient())
        {
            SpecialInvoiceHeader header = _proxy.GetSpecialInvoiceHeader(id);
            _proxy.DeleteSpecialInvoiceHeader(header);
        }
    }

    public List<SpecialInvoiceHeader> GetSpecialInvoices()
    {
        using (_proxy = new WcfFoundationService.FoundationServiceClient())
        {
            return _proxy.GetAllSpecialInvoiceHeaders();
        }
    }

    public List<SpecialInvoiceHeader> GetSpecialInvoices(string orderNo,
           string invoiceNo,
           string customerName,
           DateTime dateFrom,
           DateTime dateTo,
           short orderStatus)
    {
        using (_proxy = new WcfFoundationService.FoundationServiceClient())
        {
            return _proxy.GetSpecialHeaders(orderNo,
                invoiceNo,
                customerName,
                dateFrom,
                dateTo,
                orderStatus);
        }
    }

    #region IDisposable Members

    public void Dispose()
    {
    }

    #endregion

    ~SpecialInvoiceHeaderUI()
    {
    }
}
