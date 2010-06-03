using System;
using System.Collections.Generic;
using System.Text;
using SP.Core.Domain;

namespace SP.Core.DataInterfaces
{
    public interface IOrderHeaderDao : IDao<OrderHeader, int>
    {
        OrderHeader GetOrderHeaderWithVatCode(int id);
        bool Exists(string orderNo);
        bool InvoiceNoExists(string invoiceNo);
        OrderHeader GetOrderHeader(string orderNo);
        List<OrderHeader> GetOrderHeaderForSearch(string orderNo, string invoiceNo, string customerName, DateTime dateFrom, DateTime dateTo, short orderStatus);
        List<OrderHeader> GetOrderHeaderForSearchWithPrintedOrderStatuses(string orderNo, string invoiceNo, string customerName, DateTime dateFrom, DateTime dateTo, short actualOrderStatus, short printedOrderStatus);       
        List<InvoiceWithStatus> GetInvoicesWithStatus(string orderNo, string invoiceNo, string customerName, DateTime dateFrom, DateTime dateTo, short orderStatus);
        string GenerateOrderNo();
        string GenerateInvoiceNo();
        string GenerateDeliveryNoteNo();
        string GenerateInvoiceProformaNo();
        decimal GetOrderExVatTotal(int orderId);
    }
}
