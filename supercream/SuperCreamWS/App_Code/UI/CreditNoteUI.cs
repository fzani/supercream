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
    private WcfFoundationService.FoundationServiceClient _proxy;
    #endregion

    #region Ctor's

    public CreditNoteUI()
    {
    }

    #endregion

    #region Credit Note Related Functions

    public CreditNote GetCreditNote(int id)
    {
        using (_proxy = new WcfFoundationService.FoundationServiceClient())
        {
            return _proxy.GetCreditNote(id);
        }
    }

    public CreditNote SaveCreditNote(CreditNote contactDetail)
    {
        using (_proxy = new WcfFoundationService.FoundationServiceClient())
        {
            return _proxy.SaveCreditNote(contactDetail);
        }
    }
    public CreditNote UpdateCreditNotes(CreditNote newCreditNote)
    {
        using (_proxy = new WcfFoundationService.FoundationServiceClient())
        {
            CreditNote origCreditNote = _proxy.GetCreditNote(newCreditNote.ID);
            return _proxy.UpdateCreditNote(newCreditNote, origCreditNote);
        }
    }

    public List<CreditNoteDetails> SearchCreditNotes(string orderNo, string invoiceNo, string customerName, DateTime dateFrom,
       DateTime dateTo)
    {
        using (_proxy = new WcfFoundationService.FoundationServiceClient())
        {
            return _proxy.SearchCreditNotes(orderNo, invoiceNo, customerName, dateFrom,
                 dateTo);
        }
    }
  
    public List<CreditNote> GetCreditNotesByOrderId(int creditNoteId)      
    {
        using (var proxy = new WcfFoundationService.FoundationServiceClient())
        {
            return proxy.GetCreditNotesByOrderId(creditNoteId);
        }
    }

    public List<CreditNote> GetAllCreditNotes()
    {
        using (_proxy = new WcfFoundationService.FoundationServiceClient())
        {
            return _proxy.GetAllCreditNotes();
        }
    }

    public bool CreditNoteExists(int orderId)
    {
        using (_proxy = new WcfFoundationService.FoundationServiceClient())
        {
            return _proxy.CreditNoteExistsByOrderId(orderId);
        }
    }

    public InvoiceCreditNoteDetails GetInvoiceCreditNoteDetails(int orderId)
    {
        using (_proxy = new WcfFoundationService.FoundationServiceClient())
        {
            return _proxy.GetInvoiceCreditDetails(orderId);
        }
    }

    public void Delete(CreditNote creditNote)
    {
        using (_proxy = new WcfFoundationService.FoundationServiceClient())
        {
            _proxy.DeleteCreditNote(creditNote);
        }
    }

    public decimal GetOustandingCreditBalance(int orderNo, int creditNote, decimal vatRate)
    {
        using (_proxy = new WcfFoundationService.FoundationServiceClient())
        {
            return _proxy.GetOustandingCreditNoteBalance(orderNo, creditNote, vatRate);
        }
    }

    #endregion

    #region Destructor Related Functions

    #region IDisposable Members

    public void Dispose()
    {
        _proxy.Close();
    }

    ~CreditNoteUI()
    {
        if (_proxy != null)
            _proxy.Close();
    }

    #endregion

    #endregion
}
