using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SP.Mvp.Repository;

namespace SP.Mvp
{
    public class OfferUnitOfWork : IOfferUnitOfWork
    {
        public SP.Mvp.Offer Save(SP.Mvp.Offer offer)
        {
            using (var context = new BundledOffersDataContext())
            {
                IRepository<SP.Mvp.Offer> offerRepository = new LinqRepository<SP.Mvp.Offer>(context);
                offer = offerRepository.Save(offer, null);
                context.SubmitChanges();
                return offer;
            }
        }
    }
}
