using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using WcfFoundationService;

/// <summary>
/// Summary description for PurchaseOrderEventArgs
/// </summary>
/// 

public delegate void InvoiceEventHandler(object sender, InvoiceEventEventArgs e);

public class InvoiceEventEventArgs : EventArgs
{
    public InvoiceEventEventArgs()
    {
    }

    public int InvoiceID { get; set; }   
}



