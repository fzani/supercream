using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using WcfFoundationService;

/// <summary>
/// Summary description for PurchaseOrderEventArgs
/// </summary>
/// 

public delegate void CreditNoteEventHandler(object sender, CreditNoteEventArgs e);

public class CreditNoteEventArgs : EventArgs
{
    public CreditNoteEventArgs()
    {
    }

    public int CreditNoteID { get; set; }   
}



