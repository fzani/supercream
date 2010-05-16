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

public struct creditNote
{
    static creditNote()
    {
        throw new NotImplementedException();
    }
}
/// <summary>
/// Summary description for OrderListUI
/// </summary>
[System.ComponentModel.DataObject]
public class CreditNoteUI : IDisposable
{
    #region Private Member Variables
    #endregion

    #region Ctor's

    public CreditNoteUI()
    {
    }

    #endregion

    #region Credit Note Related Functions

    public CreditNote GetCreditNote(int id)
    {
        using (var proxy = new WcfFoundationService.FoundationServiceClient())
        {
            return proxy.GetCreditNote(id);
        }
    }

    public CreditNote SaveCreditNote(CreditNote contactDetail)
    {
        using (var proxy = new WcfFoundationService.FoundationServiceClient())
        {
            return proxy.SaveCreditNote(contactDetail);
        }
    }
    public CreditNote UpdateCreditNotes(CreditNote newCreditNote)
    {
        using (var proxy = new WcfFoundationService.FoundationServiceClient())
        {
            CreditNote origCreditNote = proxy.GetCreditNote(newCreditNote.ID);
            return proxy.UpdateCreditNote(newCreditNote, origCreditNote);
        }
    }

    public List<CreditNoteDetails> SearchCreditNotes(string orderNo, string invoiceNo, string customerName, DateTime dateFrom,
       DateTime dateTo)
    {
        using (var proxy = new WcfFoundationService.FoundationServiceClient())
        {
            return proxy.SearchCreditNotes(orderNo, invoiceNo, customerName, dateFrom,
                 dateTo);
        }
    }

    public List<CreditNote> GetCreditNotesByOrderId(int orderId)
    {
        using (var proxy = new WcfFoundationService.FoundationServiceClient())
        {
            return proxy.GetCreditNotesByOrderId(orderId);
        }
    }

    public List<CreditNote> GetAllCreditNotes()
    {
        using (var proxy = new WcfFoundationService.FoundationServiceClient())
        {
            return proxy.GetAllCreditNotes();
        }
    }

    public bool CreditNoteExists(int orderId)
    {
        using (var proxy = new WcfFoundationService.FoundationServiceClient())
        {
            return proxy.CreditNoteExistsByOrderId(orderId);
        }
    }

    public InvoiceCreditNoteDetails GetInvoiceCreditNoteDetails(int orderId)
    {
        using (var proxy = new WcfFoundationService.FoundationServiceClient())
        {
            return proxy.GetInvoiceCreditDetails(orderId);
        }
    }

    public void Delete(CreditNote creditNote)
    {
        using (var proxy = new WcfFoundationService.FoundationServiceClient())
        {
            proxy.DeleteCreditNote(creditNote);
        }
    }

    public decimal GetOustandingCreditBalance(int orderNo, int creditNote, decimal vatRate)
    {
        using (var proxy = new WcfFoundationService.FoundationServiceClient())
        {
            return proxy.GetOustandingCreditNoteBalance(orderNo, creditNote, vatRate);
        }
    }

    #endregion

    #region Destructor Related Functions

    #region IDisposable Members

    public void Dispose()
    {

    }

    ~CreditNoteUI()
    {

    }

    #endregion

    #endregion
}
