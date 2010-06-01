using System;
using System.Linq;
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
            updatedSpecialInvoice.VatCodeID = newSpecialInvoice.VatCodeID;
            updatedSpecialInvoice.AccountID = newSpecialInvoice.AccountID;
            updatedSpecialInvoice.OutletStoreID = newSpecialInvoice.OutletStoreID;
            updatedSpecialInvoice.ID = newSpecialInvoice.ID;
            updatedSpecialInvoice.OrderDate = newSpecialInvoice.OrderDate;
            updatedSpecialInvoice.DeliveryDate = newSpecialInvoice.DeliveryDate;
            updatedSpecialInvoice.OrderStatus = (short)newSpecialInvoice.OrderStatus;
            updatedSpecialInvoice.SpecialInstructions = newSpecialInvoice.SpecialInstructions;
            updatedSpecialInvoice.ReasonForVoiding = newSpecialInvoice.ReasonForVoiding;
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

    public List<SpecialInvoiceHeader> GetSpecialInvoiceHeadersSearchWithPrintedStatuses(string invoiceNo, string customerName, DateTime dateFrom, DateTime dateTo,
           short actualOrderStatus, short printedOrderStatus)
    {
        using (var proxy = new WcfFoundationService.FoundationServiceClient())
        {
            string orderNo = String.Empty;

            if (actualOrderStatus == (short)SP.Core.Enums.OrderStatus.ProformaInvoice ||
                (printedOrderStatus == (short)SP.Core.Enums.OrderStatus.ProformaInvoice) ||
                (actualOrderStatus == (short)SP.Core.Enums.OrderStatus.Invoice) ||
                (printedOrderStatus == (short)SP.Core.Enums.OrderStatus.ProformaInvoice) ||
                (actualOrderStatus == (short)SP.Core.Enums.OrderStatus.DeliveryNote) ||
                (printedOrderStatus == (short)SP.Core.Enums.OrderStatus.DeliveryNotePrinted)
                )
            {
                var list = proxy.GetSpecialHeaders(orderNo,
                    invoiceNo, customerName, dateFrom, dateTo, actualOrderStatus).OrderByDescending(q => q.DateModified);
                return list.ToList<SpecialInvoiceHeader>();
            }
            else
            {
                return proxy.GetSpecialHeaders(orderNo, invoiceNo, customerName, dateFrom, dateTo, actualOrderStatus);
            }
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
