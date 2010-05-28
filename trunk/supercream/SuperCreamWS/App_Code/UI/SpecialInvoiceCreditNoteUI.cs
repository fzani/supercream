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

    public static SpecialInvoiceCreditNote GetCreditNote(int id)
    {
        using (var proxy = new WcfFoundationService.FoundationServiceClient())
        {
            return proxy.GetSpecialInvoiceCreditNote(id);
        }
    }

    public SpecialInvoiceCreditNote SaveCreditNote(SpecialInvoiceCreditNote specialInvoiceCreditNote)
    {
        using (var proxy = new WcfFoundationService.FoundationServiceClient())
        {
            return proxy.SaveSpecialInvoiceCreditNote(specialInvoiceCreditNote);
        }
    }
    public SpecialInvoiceCreditNote UpdateCreditNotes(SpecialInvoiceCreditNote newCreditNote)
    {
        using (var proxy = new WcfFoundationService.FoundationServiceClient())
        {
            SpecialInvoiceCreditNote origCreditNote = proxy.GetSpecialInvoiceCreditNote(newCreditNote.ID);
            return proxy.UpdateSpecialInvoiceCreditNote(newCreditNote, origCreditNote);
        }
    }

    //public List<CreditNoteDetails> SearchCreditNotes(string orderNo, string invoiceNo, string customerName, DateTime dateFrom,
    //   DateTime dateTo)
    //{
    //    using (var proxy = new WcfFoundationService.FoundationServiceClient())
    //    {
    //        return proxy.SearchCreditNotes(orderNo, invoiceNo, customerName, dateFrom,
    //             dateTo);
    //    }
    //}

    //public List<SpecialInvoiceCreditNote> GetCreditNotesByOrderId(int orderId)
    //{
    //    using (var proxy = new WcfFoundationService.FoundationServiceClient())
    //    {
    //        return proxy.GetCreditNotesByOrderId(orderId);
    //    }
    //}

    //public List<SpecialInvoiceCreditNote> GetAllCreditNotes()
    //{
    //    using (var proxy = new WcfFoundationService.FoundationServiceClient())
    //    {
    //        return proxy.GetAllCreditNotes();
    //    }
    //}

    //public static bool CreditNoteExists(int orderId)
    //{
    //    using (var proxy = new WcfFoundationService.FoundationServiceClient())
    //    {
    //        return proxy.CreditNoteExistsByOrderId(orderId);
    //    }
    //}

    //public InvoiceCreditNoteDetails GetInvoiceCreditNoteDetails(int orderId)
    //{
    //    using (var proxy = new WcfFoundationService.FoundationServiceClient())
    //    {
    //        return proxy.GetInvoiceCreditDetails(orderId);
    //    }
    //}

    public void Delete(SpecialInvoiceCreditNote creditNote)
    {
        using (var proxy = new WcfFoundationService.FoundationServiceClient())
        {
            proxy.DeleteSpecialInvoiceCreditNote(creditNote);
        }
    }

    //public decimal GetOustandingCreditBalance(int orderNo, int creditNote, decimal vatRate)
    //{
    //    using (var proxy = new WcfFoundationService.FoundationServiceClient())
    //    {
    //        return proxy.GetOustandingCreditNoteBalance(orderNo, creditNote, vatRate);
    //    }
    //}

    #endregion
}
