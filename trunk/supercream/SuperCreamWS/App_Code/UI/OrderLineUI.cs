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
public class OrderLineUI : IDisposable
{
    private WcfFoundationService.FoundationServiceClient _proxy;

    public OrderLineUI()
    {

    }

    public OrderLine Save(OrderLine OrderLine)
    {
        using (_proxy = new WcfFoundationService.FoundationServiceClient())
        {
            return _proxy.SaveOrderLine(OrderLine);
        }
    }

    public void Update(OrderLine newOrderLine)
    {
        using (_proxy = new WcfFoundationService.FoundationServiceClient())
        {
            OrderLine origOrderLine = _proxy.GetOrderLine(newOrderLine.ID);
            OrderLine updatedOrderLine = origOrderLine.Clone<OrderLine>();
            updatedOrderLine.Discount = newOrderLine.Discount;
            updatedOrderLine.NoOfUnits = newOrderLine.NoOfUnits;

            updatedOrderLine.OrderHeader = origOrderLine.OrderHeader;
            updatedOrderLine.OrderID = newOrderLine.OrderID;
            updatedOrderLine.OrderLineStatus = origOrderLine.OrderLineStatus;
            updatedOrderLine.Price = newOrderLine.Price;
            updatedOrderLine.ProductID = newOrderLine.ProductID;
            updatedOrderLine.QtyPerUnit = newOrderLine.QtyPerUnit;
            updatedOrderLine.SpecialInstructions = newOrderLine.SpecialInstructions;

            _proxy.UpdateOrderLine(updatedOrderLine, origOrderLine);
        }
    }

    public List<OrderLine> GetOrderLines(int id)
    {
        using (_proxy = new WcfFoundationService.FoundationServiceClient())
        {
            return (id == -1) ? null : _proxy.GetOrderLinesByOrderID(id);
        }
    }

    public OrderLine GetOrderLine(int id)
    {
        using (_proxy = new WcfFoundationService.FoundationServiceClient())
        {
            return _proxy.GetOrderLine(id);
        }
    }

    public void DeleteOrderLine(int id)
    {
        using (_proxy = new WcfFoundationService.FoundationServiceClient())
        {
            OrderLine line = _proxy.GetOrderLine(id);
            _proxy.DeleteOrderLine(line);
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

    ~OrderLineUI()
    {
    }
}
