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
public class SpecialInvoiceCreditNoteUI
{
    #region Ctor's

    #endregion

    #region Special Credit Note Related Functions

    public static SpecialInvoiceCreditNote GetSpecialInvoiceCreditNote(int id)
    {
        using (var proxy = new WcfFoundationService.FoundationServiceClient())
        {
            return proxy.GetSpecialInvoiceCreditNote(id);
        }
    }

    public static SpecialInvoiceCreditNote SaveCreditNote(SpecialInvoiceCreditNote specialInvoiceCreditNote)
    {
        using (var proxy = new WcfFoundationService.FoundationServiceClient())
        {
            return proxy.SaveSpecialInvoiceCreditNote(specialInvoiceCreditNote);
        }
    }

    public static SpecialInvoiceCreditNote UpdateCreditNotes(SpecialInvoiceCreditNote newCreditNote)
    {
        using (var proxy = new WcfFoundationService.FoundationServiceClient())
        {
            SpecialInvoiceCreditNote origCreditNote = proxy.GetSpecialInvoiceCreditNote(newCreditNote.ID);
            return proxy.UpdateSpecialInvoiceCreditNote(newCreditNote, origCreditNote);
        }
    }

    public static List<SpecialInvoiceCreditNoteDetails> SearchCreditNotes(string specialInvoiceNo, string invoiceno, string customername, DateTime datefrom,
       DateTime dateto)
    {
        using (var proxy = new WcfFoundationService.FoundationServiceClient())
        {
            return proxy.SearchSpecialInvoiceCreditNotes(specialInvoiceNo, invoiceno, customername, datefrom,
                 dateto);
        }
    }

    public static List<SpecialInvoiceCreditNote> GetSpecialInvoiceCreditNotesByInvoiceId(int specialInvoiceId)
    {
        using (var proxy = new WcfFoundationService.FoundationServiceClient())
        {
            return proxy.GetSpecialInvoiceCreditNotesByInvoiceId(specialInvoiceId);
        }
    }

    public static List<SpecialInvoiceCreditNote> GetAllSpecialInvoiceCreditNotes()
    {
        using (var proxy = new WcfFoundationService.FoundationServiceClient())
        {
            return proxy.GetAllSpecialInvoiceCreditNotes();
        }
    }

    public static bool SpecialInvoiceCreditNoteExistsByOrderId(int specialInvoiceNo)
    {
        using (var proxy = new WcfFoundationService.FoundationServiceClient())
        {
            return proxy.SpecialInvoiceCreditNoteExistsByOrderId(specialInvoiceNo);
        }
    }  

    public static void Delete(SpecialInvoiceCreditNote creditNote)
    {
        using (var proxy = new WcfFoundationService.FoundationServiceClient())
        {
            proxy.DeleteSpecialInvoiceCreditNote(creditNote);
        }
    }

    public static SpecialInvoiceCreditNoteDetails GetSpecialInvoiceCreditNoteDetails(int specialInvoiceId)
    {
        using (var proxy = new WcfFoundationService.FoundationServiceClient())
        {
            return proxy.GetSpecialInvoiceCreditDetails(specialInvoiceId);
        }
    }

    public static decimal GetSpecialInvoiceOustandingCreditBalance(int specialInvoiceNo, int creditNote, decimal vatRate)
    {
        using (var proxy = new WcfFoundationService.FoundationServiceClient())
        {
            return proxy.GetSpecialInvoiceOustandingBalance(specialInvoiceNo, creditNote, vatRate);
        }
    }

    #endregion
}
