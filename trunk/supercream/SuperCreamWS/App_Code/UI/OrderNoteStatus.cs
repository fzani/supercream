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
public class OrderNotesStatusUI : IDisposable
{
    private WcfFoundationService.FoundationServiceClient _proxy;

    public OrderNotesStatusUI()
    {

    }

    public OrderNotesStatus Save(OrderNotesStatus OrderNotesStatus)
    {
        using (_proxy = new WcfFoundationService.FoundationServiceClient())
        {
            return _proxy.SaveOrderNotesStatus(OrderNotesStatus);
        }
    }

    public void Update(OrderNotesStatus newOrderNotesStatus)
    {
        using (_proxy = new WcfFoundationService.FoundationServiceClient())
        {
            OrderNotesStatus origOrderNotesStatus = _proxy.GetOrderNotesStatus(newOrderNotesStatus.ID);
            OrderNotesStatus updatedOrderNotesStatus = new OrderNotesStatus
            {
                InvoiceDatePrinted = newOrderNotesStatus.InvoiceDatePrinted,
                InvoiceDateReprinted = newOrderNotesStatus.InvoiceDateReprinted,
                InvoicePrinted = newOrderNotesStatus.InvoicePrinted,
                InvoiceProformaDatePrinted = newOrderNotesStatus.InvoiceProformaDatePrinted,          
                InvoicePaymentComplete = newOrderNotesStatus.InvoicePaymentComplete,
                InvoiceProformaPrinted = newOrderNotesStatus.InvoiceProformaPrinted,
                InvoiceReprinted = newOrderNotesStatus.InvoiceReprinted,
                OrderID = newOrderNotesStatus.OrderID,
                OutletStoreID = newOrderNotesStatus.OutletStoreID,
                PicklistDateGenerated = newOrderNotesStatus.PicklistDateGenerated,
                PicklistGenerated = newOrderNotesStatus.PicklistGenerated,
                VanID = newOrderNotesStatus.VanID,
                DeliveryNoteDateCreated = newOrderNotesStatus.DeliveryNoteDateCreated,
                InvoiceDateCreated = newOrderNotesStatus.InvoiceDateCreated,
                InvoiceProformaDateCreated = newOrderNotesStatus.InvoiceProformaDateCreated,
                DeliveryNoteDatePrinted = newOrderNotesStatus.DeliveryNoteDatePrinted,
                DeliveryNotePrinted = newOrderNotesStatus.DeliveryNotePrinted,
                AccountID = newOrderNotesStatus.AccountID,
                ID = newOrderNotesStatus.ID               
            };
            
            _proxy.UpdateOrderNotesStatus(updatedOrderNotesStatus, origOrderNotesStatus);
        }       
    }

    public OrderNotesStatus GetOrderNotesStatus(int id)
    {
        using (_proxy = new WcfFoundationService.FoundationServiceClient())
        {
            return _proxy.GetOrderNotesStatus(id);
        }
    }

    public OrderNotesStatus GetOrderNotesStatusByOrderID(int id)
    {
        using (_proxy = new WcfFoundationService.FoundationServiceClient())
        {
            return _proxy.GetOrderNoteStatusByOrderId(id);
        }
    }

    public bool OrderNoteExistsByOrderID(int orderID)
    {
        using (_proxy = new WcfFoundationService.FoundationServiceClient())
        {
            return _proxy.OrderNoteStatusByOrderIDExists(orderID);
        }
    }

    public List<OrderHeader> GetInvoicesByVanAndDate(DateTime deliveryDate, int vanId)
    {
        using (_proxy = new WcfFoundationService.FoundationServiceClient())
        {
            return _proxy.InvoicesByDateAndVan(deliveryDate, vanId);
        }
    }

    public List<VanInvoiceCount> GetInvoiceCounts(DateTime deliveryDate)
    {
        using (_proxy = new WcfFoundationService.FoundationServiceClient())
        {
            return _proxy.GetVanInvoiceCount(deliveryDate);
        }
    }

    public void UpdateVanForInvoice(int orderID, int vanId)
    {
        using (_proxy = new WcfFoundationService.FoundationServiceClient())
        {
            _proxy.UpdateVanForInvoice(orderID, vanId);
        }

    }

    public void DeleteOrderNote(int id)
    {
        using (_proxy = new WcfFoundationService.FoundationServiceClient())
        {
            using (TransactionScope ts = new TransactionScope())
            {
                OrderNotesStatus orderNotesStatus = _proxy.GetOrderNotesStatus(id);
                _proxy.DeleteOrderNotesStatus(orderNotesStatus);
            }
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

    ~OrderNotesStatusUI()
    {
    }
}
