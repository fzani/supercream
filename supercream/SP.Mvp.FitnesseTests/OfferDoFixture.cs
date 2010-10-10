using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SP.Mvp;
using SP.Mvp.Repository;
using System.Configuration;

namespace SP.Mvp.FitnesseTests
{
    public class OfferDoFixture
    {
        public bool SaveOffer()
        {
            var bundledOffersDataContext = new BundledOffersDataContext(Connection.SuperCreamConnection);
            var linqRepository = new LinqRepository<Offer>(bundledOffersDataContext);

            var offer = new Offer()
                              {
                                  ID = -1,
                                  Name = "Test Offer",
                                  ValidFrom = DateTime.Now,
                                  ValidTo = DateTime.Now.AddYears(2)
                              };

            offer = linqRepository.Save(offer);

            bundledOffersDataContext.SubmitChanges();

            return offer.ID > 0;
        }
    }
}
