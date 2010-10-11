using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SP.Mvp
{
    [Serializable]
    public class BundledOffer
    {
        public int TotalCount { get; set; }
        public IEnumerable<Offer> Offers { get; set; }
    }
}
