/***************************************************************************************************
// -- Generated by AlteraxGen 28/04/2010 22:21:37
// Version 1.0
***************************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SP.Core.Domain;

namespace SP.Core.DataInterfaces
{
    public interface IOrderCreditNoteLineDao : IDao<OrderCreditNoteLine, int>
    {
        bool CheckIfCreditNoteLineExists(int creditNoteid, int orderLineId);
        OrderCreditNoteLine GetCreditNoteLineByOrderIdAndOrderLineId(int creditNoteid, int orderLineId);
        bool CheckIfOrderLineAlreadyExists(int orderLineId);
        int GetAvailableNoOfUnitsOnOrderLine(int orderLineId);
    }
}
