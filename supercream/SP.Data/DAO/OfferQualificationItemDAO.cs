/***************************************************************************************************
// -- Generated by AlteraxGen 30/09/2010 20:22:56
// Version 1.0
***************************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SP.Core.Domain;
using SP.Core.DataInterfaces;

namespace SP.Data.LTS
{
    public class OfferQualificationItemDao : AbstractLTSDao<OfferQualificationItem, int>, IOfferQualificationItemDao
    {
        public OfferQualificationItemDao()
        {
        }

        public OfferQualificationItemDao(LTSDataContext ctx)
            : base(ctx)
        {
        }

        public override OfferQualificationItem GetById(int id)
        {
            return db.OfferQualificationItem.Single<OfferQualificationItem>(q => q.ID == id);
        }

        public List<OfferQualificationItem> GetByOfferId(int id)
        {
            return db.OfferQualificationItem.Where(q => q.OfferId == id).ToList();
        }


        public bool Exists(int offerId, int productId)
        {
            return (db.OfferItem.Where(q => ((q.OfferId == offerId) && (q.ProductId == productId))).SingleOrDefault() == null) ? false : true;
        }
    }
}
