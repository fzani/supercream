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
/// Summary description for OrderListUI
/// </summary>
[System.ComponentModel.DataObject]
public class OrderHeaderUI : IDisposable
{
    private WcfFoundationService.FoundationServiceClient _proxy;

    public OrderHeaderUI()
    {
    }

    public OrderHeader Save(OrderHeader OrderHeader)
    {
        using (_proxy = new WcfFoundationService.FoundationServiceClient())
        {
            return _proxy.SaveOrderHeader(OrderHeader);
        }
    }

    public OrderHeader GetById(int id)
    {
        if (id != -1)
        {
            using (_proxy = new WcfFoundationService.FoundationServiceClient())
            {
                return _proxy.GetOrderHeader(id);
            }
        }
        else
        {
            return null;
        }
    }

    public bool InvoiceNoExists(string invoiceNo)
    {
        using (_proxy = new WcfFoundationService.FoundationServiceClient())
        {
            return _proxy.InvoiceNoExists(invoiceNo);
        }
    }

    public OrderHeader GetByOrderNo(string orderNo)
    {
        using (_proxy = new WcfFoundationService.FoundationServiceClient())
        {
            return _proxy.GetOrderHeaderByOrderNo(orderNo);
        }
    }

    public string CreateInvoice(int orderNo)
    {
        using (_proxy = new WcfFoundationService.FoundationServiceClient())
        {
            OrderHeader origOrderHeader = _proxy.GetOrderHeader(orderNo);
            OrderHeader updatedOrderHeader = origOrderHeader.Clone<OrderHeader>();

            updatedOrderHeader.OrderStatus = (short)SP.Core.Enums.OrderStatus.Invoice;

            OrderHeader oh = _proxy.CreateInvoice(updatedOrderHeader, origOrderHeader);
            return oh.InvoiceNo;
        }
    }

    public string CreateInvoiceProforma(int orderNo)
    {
        using (_proxy = new WcfFoundationService.FoundationServiceClient())
        {
            OrderHeader origOrderHeader = _proxy.GetOrderHeader(orderNo);
            OrderHeader updatedOrderHeader = origOrderHeader.Clone<OrderHeader>();
         
            updatedOrderHeader.OrderStatus = (short)SP.Core.Enums.OrderStatus.ProformaInvoice;          

            OrderHeader oh = _proxy.CreateInvoiceProforma(updatedOrderHeader, origOrderHeader);
            return oh.InvoiceNo;
        }
    }

    public string CreateDeliveryNote(int orderNo)
    {
        using (_proxy = new WcfFoundationService.FoundationServiceClient())
        {
            OrderHeader origOrderHeader = _proxy.GetOrderHeader(orderNo);
            OrderHeader updatedOrderHeader = origOrderHeader.Clone<OrderHeader>();

            updatedOrderHeader.OrderStatus = (short)SP.Core.Enums.OrderStatus.DeliveryNote;

            OrderHeader oh = _proxy.CreateDeliveryNote(updatedOrderHeader, origOrderHeader);
            return oh.DeliveryNoteNo;
        }
    }

    public string UpdateInvoiceNo(int orderNo, string invoiceNo, SP.Core.Enums.OrderStatus invoiceType)
    {
        using (_proxy = new WcfFoundationService.FoundationServiceClient())
        {
            OrderHeader origOrderHeader = _proxy.GetOrderHeader(orderNo);
            OrderHeader updatedOrderHeader = origOrderHeader.Clone<OrderHeader>();

            updatedOrderHeader.AlphaID = origOrderHeader.AlphaID;
            updatedOrderHeader.CustomerID = origOrderHeader.CustomerID;
            updatedOrderHeader.ID = origOrderHeader.ID;
            updatedOrderHeader.OrderDate = origOrderHeader.OrderDate;
            updatedOrderHeader.OrderStatus = (short)invoiceType;
            updatedOrderHeader.InvoiceNo = invoiceNo;
            updatedOrderHeader.SpecialInstructions = origOrderHeader.SpecialInstructions;

            OrderHeader oh = _proxy.UpdateOrderHeader(updatedOrderHeader, origOrderHeader);
            return oh.InvoiceNo;
        }
    }

    public string UpdateDeliveryNote(int orderNo, string invoiceNo)
    {
        using (_proxy = new WcfFoundationService.FoundationServiceClient())
        {
            OrderHeader origOrderHeader = _proxy.GetOrderHeader(orderNo);
            OrderHeader updatedOrderHeader = origOrderHeader.Clone<OrderHeader>();

            updatedOrderHeader.AlphaID = origOrderHeader.AlphaID;
            updatedOrderHeader.CustomerID = origOrderHeader.CustomerID;
            updatedOrderHeader.ID = origOrderHeader.ID;
            updatedOrderHeader.OrderDate = origOrderHeader.OrderDate;
            updatedOrderHeader.OrderStatus = (short)SP.Core.Enums.OrderStatus.DeliveryNote;
            updatedOrderHeader.InvoiceNo = invoiceNo;
            updatedOrderHeader.SpecialInstructions = origOrderHeader.SpecialInstructions;

            OrderHeader oh = _proxy.UpdateOrderHeader(updatedOrderHeader, origOrderHeader);
            return oh.InvoiceNo;
        }
    }

    public string UpdateToInvoice(int orderNo)
    {
        using (_proxy = new WcfFoundationService.FoundationServiceClient())
        {
            OrderHeader origOrderHeader = _proxy.GetOrderHeader(orderNo);
            OrderHeader updatedOrderHeader = origOrderHeader.Clone<OrderHeader>();

            updatedOrderHeader.AlphaID = origOrderHeader.AlphaID;
            updatedOrderHeader.CustomerID = origOrderHeader.CustomerID;
            updatedOrderHeader.ID = origOrderHeader.ID;
            updatedOrderHeader.OrderDate = origOrderHeader.OrderDate;
            updatedOrderHeader.OrderStatus = (short)SP.Core.Enums.OrderStatus.Invoice;
            updatedOrderHeader.InvoiceNo = origOrderHeader.InvoiceNo;
            updatedOrderHeader.SpecialInstructions = origOrderHeader.SpecialInstructions;

            OrderHeader oh = _proxy.UpdateOrderHeader(updatedOrderHeader, origOrderHeader);
            return oh.InvoiceNo;
        }
    }

    public void VoidOrder(int orderID, string reasonForVoiding)
    {
        using (_proxy = new WcfFoundationService.FoundationServiceClient())
        {
            _proxy.VoidOrder(orderID, reasonForVoiding);
        }
    }

    public void Update(OrderHeader newOrderHeader)
    {
        using (_proxy = new WcfFoundationService.FoundationServiceClient())
        {
            OrderHeader origOrderHeader = _proxy.GetOrderHeader(newOrderHeader.ID);
            OrderHeader updatedOrderHeader = origOrderHeader.Clone<OrderHeader>();

            updatedOrderHeader.AlphaID = newOrderHeader.AlphaID;
            updatedOrderHeader.CustomerID = origOrderHeader.CustomerID;
            updatedOrderHeader.ID = newOrderHeader.ID;
            updatedOrderHeader.OrderDate = newOrderHeader.OrderDate;
            updatedOrderHeader.OrderStatus = (short)origOrderHeader.OrderStatus;
            updatedOrderHeader.SpecialInstructions = newOrderHeader.SpecialInstructions;

            _proxy.UpdateOrderHeader(updatedOrderHeader, origOrderHeader);
        }
    }

    public void UpdateForInvoice(OrderHeader newOrderHeader)
    {
        using (_proxy = new WcfFoundationService.FoundationServiceClient())
        {
            OrderHeader origOrderHeader = _proxy.GetOrderHeader(newOrderHeader.ID);
            _proxy.UpdateOrderHeader(newOrderHeader, origOrderHeader);
        }
    }

    public void DeleteOrderHeader(int id)
    {
        using (_proxy = new WcfFoundationService.FoundationServiceClient())
        {
            OrderHeader header = _proxy.GetOrderHeader(id);
            _proxy.DeleteOrderHeader(header);
        }
    }

    public List<OrderHeader> GetOrderHeaders()
    {
        using (_proxy = new WcfFoundationService.FoundationServiceClient())
        {
            return _proxy.GetAllOrderHeaders();
        }
    }

    /// <summary>
    /// Updates the invoice completion status.
    /// </summary>
    /// <param name="status">The status.</param>
    public void UpdateInvoiceCompletionStatus(InvoiceWithStatus status)
    {
        using (_proxy = new WcfFoundationService.FoundationServiceClient())
        {
            OrderHeader orderHeader = _proxy.GetOrderHeaderByOrderNo(status.OrderID);
            _proxy.UpdatePaymentCompleted(orderHeader.ID, status.InvoicePaymentComplete);
        }
    }

    public List<InvoiceWithStatus> GetInvoicesWithStatus(string orderNo, string invoiceNo, string customerName, DateTime dateFrom,
        DateTime dateTo, SP.Core.Enums.OrderStatus orderStatus)
    {
        using (_proxy = new WcfFoundationService.FoundationServiceClient())
        {
            return _proxy.GetInvoicesWithStatus(orderNo, invoiceNo, customerName, dateFrom,
                dateTo, Convert.ToInt16(orderStatus));
        }
    }

    public List<OrderHeader> GetOrderHeadersSearch(string orderHeader, string invoiceNo, string customerName, DateTime dateFrom, DateTime dateTo, short orderStatus)
    {
        using (_proxy = new WcfFoundationService.FoundationServiceClient())
        {
            return _proxy.GetOrderHeaderForSearch(orderHeader, invoiceNo, customerName, dateFrom, dateTo, orderStatus);
        }
    }

    public List<OrderHeader> GetOrderHeadersSearchWithPrintedStatuses(string orderHeader, string invoiceNo, string customerName, DateTime dateFrom, DateTime dateTo,
            short actualOrderStatus, short printedOrderStatus)
    {
        using (_proxy = new WcfFoundationService.FoundationServiceClient())
        {
            return _proxy.GetOrderHeaderForSearchWithPrintedOrderStatuses(orderHeader, invoiceNo, customerName, dateFrom, dateTo, actualOrderStatus, printedOrderStatus);
        }
    }

    public string GenerateOrderNo()
    {
        using (_proxy = new WcfFoundationService.FoundationServiceClient())
        {
            return _proxy.GenerateOrderReferenceNo();
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

    ~OrderHeaderUI()
    {
    }
}
