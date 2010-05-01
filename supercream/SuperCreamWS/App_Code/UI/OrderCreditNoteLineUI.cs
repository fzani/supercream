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
    private WcfFoundationService.FoundationServiceClient _proxy;

    public OrderCreditNoteLineUI()
    {        
    }

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public List<OrderCreditNoteLine> GetAllCreditNotes()
    {
        using (_proxy = new WcfFoundationService.FoundationServiceClient())
        {
            return _proxy.GetAllOrderCreditNoteLines() as List<OrderCreditNoteLine>;
        }
    }

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public List<OrderLine> GetAvailableOrderLines(int orderId)
    {
        using (_proxy = new WcfFoundationService.FoundationServiceClient())
        {
            return _proxy.AvailableOrderLinesForCreditNote(orderId) as List<OrderLine>;
        }
    }


    public void SaveOrderCreditNoteLine(OrderCreditNoteLine OrderCreditNoteLine)
    {
        using (_proxy = new WcfFoundationService.FoundationServiceClient())
        {
            //if(_proxy.AlphaIDExists(OrderCreditNoteLine.AlphaID))
            //    throw new ApplicationException("OrderCreditNoteLine no " + OrderCreditNoteLine.AlphaID + " is already used");    
            _proxy.SaveOrderCreditNoteLine(OrderCreditNoteLine);
        }

    }

    public void DeleteOrderCreditNoteLine(int id)
    {
        using (_proxy = new WcfFoundationService.FoundationServiceClient())
        {
          //  _proxy.DeleteOrderCreditNoteLine(OrderCreditNoteLine);
        }
    }
   
    public void UpdatePopupOrderCreditNoteLine(OrderCreditNoteLine newOrderCreditNoteLine)
    {
        using (_proxy = new WcfFoundationService.FoundationServiceClient())
        {
            //OrderCreditNoteLine origOrderCreditNoteLine = _proxy.GetOrderCreditNoteLine(newOrderCreditNoteLine.ID);
            //newOrderCreditNoteLine.ID = origOrderCreditNoteLine.ID;           

            //// Note :- have to remove cyclic reference fom orig Object
            //origOrderCreditNoteLine.Address.OrderCreditNoteLine = null;

            //_proxy.UpdateOrderCreditNoteLine(newOrderCreditNoteLine, origOrderCreditNoteLine);
        }
    }    

    public OrderCreditNoteLine GetByID(int id)
    {
        using (_proxy = new WcfFoundationService.FoundationServiceClient())
        {
        return _proxy.GetOrderCreditNoteLine(id);
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
