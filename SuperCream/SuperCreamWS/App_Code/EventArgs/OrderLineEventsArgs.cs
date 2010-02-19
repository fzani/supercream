using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using WcfFoundationService;

/// <summary>
/// Summary description for ProductSearchEventArgs
/// </summary>
/// 

public delegate void OrderLineEventHandler(object sender, OrderLineEventsArgs e);

public class OrderLineEventsArgs : EventArgs
{
    private OrderLine orderLine;

    public OrderLineEventsArgs()
    {
        OrderLine _orderLine = new OrderLine();
    }

    public OrderLine OrderLine
    {
        get { return orderLine; }
        set { orderLine = value; }
    }
}
