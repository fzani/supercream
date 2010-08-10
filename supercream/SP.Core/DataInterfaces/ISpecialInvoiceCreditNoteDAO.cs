/***************************************************************************************************
// -- Generated by AlteraxGen 28/05/2010 17:29:05
// Version 1.0
***************************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SP.Core.Domain;

namespace SP.Core.DataInterfaces
{
    public interface ISpecialInvoiceCreditNoteDao : IDao<SpecialInvoiceCreditNote, int>
    {
        List<SpecialInvoiceCreditNoteDetails> SearchSpecialInvoiceCreditNotes(
            string orderNo, string invoiceNo,
            string customerName,
            DateTime dateFrom,
            DateTime dateTo);

        List<SpecialInvoiceCreditNote> GetSpecialInvoiceCreditNotesByInvoiceId(int specialInvoiceId);

        string GenerateSpecialInvoiceCreditNo();
        decimal GetSpecialInvoiceOustandingBalance(int orderNo, int creditNote, decimal vatRate);
        bool SpecialInvoiceCreditNoteExistsByInvoiceId(int specialInvoiceId);
        bool ReferenceExists(string referenceNo);
        SpecialInvoiceCreditNote SpecialInvoiceGetByReferenceId(string reference);
        SpecialInvoiceCreditNoteBalance GetSpecialInvoiceCreditBalance(int specialInvoiceId, decimal vatRate);
    }
}