using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using WcfFoundationService;

/// <summary>
/// Summary description for PurchaseOrderEventArgs
/// </summary>
/// 

public delegate void SpecialInvoiceEventHandler(object sender, SpecialInvoiceEventArgs e);

public class SpecialInvoiceEventArgs : EventArgs
{
    public SpecialInvoiceEventArgs()
    {
    }
}



