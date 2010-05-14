using System.Collections.Generic;
using SP.Core.Domain;

namespace SP.Data.LTS
{
    public interface ICreditNoteDao
    {
        List<OrderLine> GetOrderLinesForCreditNote(int orderId);
    }
}