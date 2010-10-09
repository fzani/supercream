using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SP.Core.Domain;

namespace SP.Mvp
{
    public class BundledOffer
    {
        public int TotalCount { get; set; }
        public IEnumerable<SP.Mvp.Offer> Offers { get; set; }
    }
}
