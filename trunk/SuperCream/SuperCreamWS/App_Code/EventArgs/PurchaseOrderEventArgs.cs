using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using WcfFoundationService;

/// <summary>
/// Summary description for PurchaseOrderEventArgs
/// </summary>
/// 

public delegate void PurchaseOrderEventHandler(object sender, PurchaseOrderEventArgs e);

public class PurchaseOrderEventArgs : EventArgs
{
    public PurchaseOrderEventArgs()
    {
    }

    public int PurchaseOrderID { get; set; }
}



