using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using System.Threading;
using SP.Mvp;
using SP.Mvp.Repository;
using System.Configuration;
using SP.Util;

using WebFormsMvp;

namespace SP.Mvp.FitnesseTests
{
    public class OfferDoFixture
    {
        private List<Offer> _offers = new List<Offer>();
        private Offer _offer;

        public bool FindOfferById(int id)
        {
            var bundledOffersDataContext = new BundledOffersDataContext(Connection.SuperCreamConnection);
            var linqRepository = new LinqRepository<Offer>(bundledOffersDataContext);

            var offer = linqRepository.Find(id);

            return offer.ID > 0;
        }

        public bool FindAllOffers()
        {
            var bundledOffersDataContext = new BundledOffersDataContext(Connection.SuperCreamConnection);
            var linqRepository = new LinqRepository<Offer>(bundledOffersDataContext);

            var offers = linqRepository.FindAll();

            return offers.Count() > 0;
        }

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

        public bool UpdateOfferViaCommit(int id)
        {
            var bundledOffersDataContext = new BundledOffersDataContext(Connection.SuperCreamConnection);
            var linqRepository = new LinqRepository<Offer>(bundledOffersDataContext);

            var offer = linqRepository.Find(id);

            var offerName = "Johns Test Offer";

            offer.Name = offerName;

            bundledOffersDataContext.SubmitChanges();

            var updatedOffer = linqRepository.Find(id);

            return updatedOffer.Name == offerName;
        }

        public bool UpdateOffer(int id)
        {
            var originalDataContext = new BundledOffersDataContext(Connection.SuperCreamConnection);
            var newDataContext = new BundledOffersDataContext(Connection.SuperCreamConnection);

            var originalLinqRepository = new LinqRepository<Offer>(originalDataContext);
            var newLinqRepository = new LinqRepository<Offer>(newDataContext);

            var offer = originalLinqRepository.Find(id);

            var updatedOffer = new Offer
                                   {
                                       ID = offer.ID,
                                       Name = offer.Name,
                                       ValidFrom = offer.ValidFrom,
                                       ValidTo = offer.ValidTo
                                   };

            var offerName = "Johns XXX New Updated Offer";

            updatedOffer.Name = offerName;
            offer = newLinqRepository.Save(updatedOffer, offer);
            newDataContext.SubmitChanges();

            return offer.Name == offerName;
        }

        public bool DeleteOffer()
        {
            using (var deleteContext = new BundledOffersDataContext(Connection.SuperCreamConnection))
            {
                var deleteRepository = new LinqRepository<Offer>(deleteContext);
                var offer = GetOffer();
                deleteRepository.Delete(offer);
                deleteContext.SubmitChanges();
            }

            return true;
        }

        public bool FindAllAsync()
        {
            FindAsync();
            Thread.Sleep(200);

            return _offers.Count() > 0;
        }


        public bool FindByIdAsync(int id)
        {
            FindAsync(id);
            Thread.Sleep(1000);
            return _offer.ID > 0;
        }

        private void FindAsync(int id)
        {
            var context = new BundledOffersDataContext(Connection.SuperCreamConnection);
            var repository = new LinqRepository<Offer>(context);

            IAsyncResult result = repository.BeginFind(id, q =>
            {
                _offer = repository.EndFind(q);
            }, this);
            result.AsyncWaitHandle.WaitOne();
        }

        #region private Helpers

        private void FindAsync()
        {
            var context = new BundledOffersDataContext(Connection.SuperCreamConnection);
            var repository = new LinqRepository<Offer>(context);

            IAsyncResult result = repository.BeginFindAll(q =>
                                                              {
                                                                  _offers = repository.EndFindAll(q).ToList();
                                                              }, this);
            result.AsyncWaitHandle.WaitOne();
        }

        private SP.Mvp.Offer GetOffer()
        {
            using (var bundledOffersDataContext = new BundledOffersDataContext(Connection.SuperCreamConnection))
            {
                var linqRepository = new LinqRepository<Offer>(bundledOffersDataContext);
                int max = linqRepository.FindAll().Max(q => q.ID);
                return linqRepository.Find(max).Clone();
            }
        }

        #endregion
    }
}
