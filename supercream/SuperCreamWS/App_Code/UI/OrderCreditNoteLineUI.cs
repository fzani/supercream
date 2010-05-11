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
public class OrderCreditNoteLineUI : IDisposable
{
    public OrderCreditNoteLineUI()
    {
    }

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public static List<OrderCreditNoteLine> GetAllCreditNotes()
    {
        using (var proxy = new WcfFoundationService.FoundationServiceClient())
        {
            return proxy.GetAllOrderCreditNoteLines() as List<OrderCreditNoteLine>;
        }
    }

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public static List<OrderCreditNoteLine> GetOrderCreditNoteLines(int creditNoteId)
    {
        using (var proxy = new WcfFoundationService.FoundationServiceClient())
        {
            return proxy.GetOrderCreditNoteLinesByCreditNoteId(creditNoteId) as List<OrderCreditNoteLine>;
        }
    }

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public static List<OrderLine> GetAvailableOrderLines(int orderId)
    {
        using (var proxy = new WcfFoundationService.FoundationServiceClient())
        {
            if (orderId > -1)
            {
                return proxy.AvailableOrderLinesForCreditNote(orderId) as List<OrderLine>;
            }
            else
            {
                return null;
            }
        }
    }

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public static List<OrderLine> GetCreditNoteLines(int creditNoteId)
    {
        return null;
    }

    public static void SaveOrderCreditNoteLine(OrderCreditNoteLine OrderCreditNoteLine)
    {
        using (var proxy = new WcfFoundationService.FoundationServiceClient())
        {
            proxy.SaveOrderCreditNoteLine(OrderCreditNoteLine);
        }

    }

    public static void DeleteOrderCreditNoteLine(int id)
    {
        using (var proxy = new WcfFoundationService.FoundationServiceClient())
        {
            OrderCreditNoteLine line = proxy.GetOrderCreditNoteLine(id);
            proxy.DeleteOrderCreditNoteLine(line);
        }
    }

    public static void Update(OrderCreditNoteLine newOrderCreditNoteLine)
    {
        using (var proxy = new WcfFoundationService.FoundationServiceClient())
        {
            OrderCreditNoteLine origOrderCreditNoteLine = proxy.GetOrderCreditNoteLine(newOrderCreditNoteLine.ID);
            newOrderCreditNoteLine.ID = origOrderCreditNoteLine.ID;

            proxy.UpdateOrderCreditNoteLine(newOrderCreditNoteLine, origOrderCreditNoteLine);
        }
    }

    public static OrderCreditNoteLine GetById(int id)
    {
        using (var proxy = new WcfFoundationService.FoundationServiceClient())
        {
            return proxy.GetOrderCreditNoteLine(id);
        }
    }

    public static OrderCreditNoteLine GetCreditNoteLineByOrderIdAndOrderLineId(int creditNoteId, int orderLineId)
    {
        using (var proxy = new WcfFoundationService.FoundationServiceClient())
        {
            return proxy.GetCreditNoteLineByOrderIdAndOrderLineId(creditNoteId, orderLineId);
        }
    }

    public static bool CheckIfOrderCreditLineExists(int creditNoteId, int orderLineId)
    {
        using (var proxy = new WcfFoundationService.FoundationServiceClient())
        {
            return proxy.CheckIfCreditNoteLineExists(creditNoteId, orderLineId);
        }
    }

    public static bool CheckIfOrderLineAlreadyExistsForCreditNotes(int orderLineId)
    {
        using (var proxy = new WcfFoundationService.FoundationServiceClient())
        {
            return proxy.CheckIfOrderLineAlreadyExistsForCreditNotes(orderLineId);
        }
    }

    public static int GetAvailableNoOfUnitsOnOrderLine(int orderLineId)
    {
        using (var proxy = new WcfFoundationService.FoundationServiceClient())
        {
            return proxy.GetAvailableNoOfUnitsOnOrderLine(orderLineId);
        }
    }

    #region IDisposable Members

    public void Dispose()
    {
    }

    #endregion

    ~OrderCreditNoteLineUI()
    {
    }
}
