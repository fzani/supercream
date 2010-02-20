using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SP.Core.Domain;
using SP.Core.DataInterfaces;

namespace SP.Data.LTS
{
    public class VatCodeDao : AbstractLTSDao<VatCode, int>, IVatCodeDao
    {
        public override VatCode GetById(int id)
        {
            return db.VatCode.SingleOrDefault<VatCode>(q => q.ID == id);
        }

        public bool ExemptCodeExists()
        {
            return ((from t in db.VatCode
                     where (t.VatExemptible == true)
                     select t).Count() > 0) ? true : false;
        }

        public bool CodeExists(string vatCode)
        {
            return ((from t in db.VatCode
                     where (t.Code == vatCode)
                     select t).Count() > 0) ? true : false;
        }

        public VatCode GetVatCodeByCode(string vatCode)
        {
            return db.VatCode.Where(q => q.Code == vatCode).SingleOrDefault<VatCode>();
        }
    }
}
