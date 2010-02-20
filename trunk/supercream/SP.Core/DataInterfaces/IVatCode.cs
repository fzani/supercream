using System;
using System.Collections.Generic;
using System.Text;
using SP.Core.Domain;

namespace SP.Core.DataInterfaces
{
    public interface IVatCodeDao : IDao<VatCode, int>
    {
        bool ExemptCodeExists();
        bool CodeExists(string vatCode);
        VatCode GetVatCodeByCode(string vatCode);
    }
}