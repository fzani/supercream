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

using WcfFoundationService;

/// <summary>
/// Summary description for OrderListUI
/// </summary>
[System.ComponentModel.DataObject]
public class OrderCreditNoteUI : IDisposable
{
    private WcfFoundationService.FoundationServiceClient _proxy;

    public OrderCreditNoteUI()
    {
    }

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public List<OrderCreditNote> GetAllCreditNotes()
    {
        using (_proxy = new WcfFoundationService.FoundationServiceClient())
        {
            return _proxy.GetAllOrderCreditNotes() as List<OrderCreditNote>;
        }
    }

    public OrderCreditNote SaveOrderCreditNote(OrderCreditNote OrderCreditNote)
    {
        using (_proxy = new WcfFoundationService.FoundationServiceClient())
        {
            //if(_proxy.AlphaIDExists(OrderCreditNote.AlphaID))
            //    throw new ApplicationException("OrderCreditNote no " + OrderCreditNote.AlphaID + " is already used");    
            return _proxy.SaveOrderCreditNote(OrderCreditNote);
        }
    }

    public void DeleteOrderCreditNote(int id)
    {
        using (_proxy = new WcfFoundationService.FoundationServiceClient())
        {
            //  _proxy.DeleteOrderCreditNote(OrderCreditNote);
        }
    }

    public static void UpdateOrderCreditNote(OrderCreditNote newOrderCreditNote)
    {
        using (var proxy = new WcfFoundationService.FoundationServiceClient())
        {
            OrderCreditNote origOrderCreditNote = proxy.GetOrderCreditNote(newOrderCreditNote.ID);
            newOrderCreditNote.ID = origOrderCreditNote.ID;           

            //// Note :- have to remove cyclic reference fom orig Object           
            proxy.UpdateOrderCreditNote(newOrderCreditNote, origOrderCreditNote);
        }
    }

    public OrderCreditNote GetByID(int id)
    {
        using (_proxy = new WcfFoundationService.FoundationServiceClient())
        {
            return _proxy.GetOrderCreditNote(id);
        }
    }

    public List<CreditNoteDetails> SearchOrderCreditNotes(string orderNo, string invoiceNo, string customerName, DateTime dateFrom, DateTime dateTo)
    {
        using (var proxy = new WcfFoundationService.FoundationServiceClient())
        {
            return proxy.SearchOrderCreditNotes(orderNo, invoiceNo, customerName, dateFrom, dateTo);
        }
    }

    public InvoiceCreditNoteDetails GetInvoiceCreditNoteDetails(int orderId)
    {
        using (var proxy = new WcfFoundationService.FoundationServiceClient())
        {
            return proxy.GetOrderHeaderInvoiceCreditDetails(orderId);
        }
    }

    #region IDisposable Members

    public void Dispose()
    {
    }

    #endregion

    ~OrderCreditNoteUI()
    {
    }
}
