using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PriceListItem
/// </summary>
/// 
namespace SP.Web.DTO
{
    public class PriceListItem
    {
        public PriceListItem()
        {
        }

        public int ID
        {
            get;
            set;
        }

        public string ProductName
        {
            get;
            set;
        }

        public Decimal OriginalPrice
        {
            get;
            set;
        }

        public Decimal Discount
        {
            get;
            set;
        }

        public Decimal DiscountApplied
        {
            get;
            set;
        }
    }
}
