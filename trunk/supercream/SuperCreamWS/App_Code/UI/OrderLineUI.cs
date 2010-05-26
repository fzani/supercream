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

    public static OrderLine Save(OrderLine OrderLine)
    {
        using (var proxy = new WcfFoundationService.FoundationServiceClient())
        {
            return proxy.SaveOrderLine(OrderLine);
        }
    }

    public static void Update(OrderLine newOrderLine)
    {
        using (var proxy = new WcfFoundationService.FoundationServiceClient())
        {
            OrderLine origOrderLine = proxy.GetOrderLine(newOrderLine.ID);
            OrderLine updatedOrderLine = origOrderLine.Clone<OrderLine>();
            updatedOrderLine.Discount = newOrderLine.Discount;
            updatedOrderLine.NoOfUnits = newOrderLine.NoOfUnits;

            updatedOrderLine.OrderHeader = origOrderLine.OrderHeader;
            updatedOrderLine.OrderID = newOrderLine.OrderID;
            updatedOrderLine.OrderLineStatus = origOrderLine.OrderLineStatus;
            updatedOrderLine.Price = newOrderLine.Price;
            updatedOrderLine.RRPPerItem = origOrderLine.RRPPerItem;
            updatedOrderLine.ProductID = newOrderLine.ProductID;
            updatedOrderLine.QtyPerUnit = newOrderLine.QtyPerUnit;
            updatedOrderLine.SpecialInstructions = newOrderLine.SpecialInstructions;

            proxy.UpdateOrderLine(updatedOrderLine, origOrderLine);
        }
    }

    public List<OrderLine> GetOrderLines(int id)
    {
        using (_proxy = new WcfFoundationService.FoundationServiceClient())
        {
            return (id == -1) ? null : _proxy.GetOrderLinesByOrderID(id);
        }
    }

    public static OrderLine GetOrderLine(int id)
    {
        using (var proxy = new WcfFoundationService.FoundationServiceClient())
        {
            return proxy.GetOrderLine(id);
        }
    }

    public static void DeleteOrderLine(int id)
    {
        using (var proxy = new WcfFoundationService.FoundationServiceClient())
        {
            OrderLine line = proxy.GetOrderLine(id);
            proxy.DeleteOrderLine(line);
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
