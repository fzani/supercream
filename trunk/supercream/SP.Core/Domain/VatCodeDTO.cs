using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Runtime.Serialization;

using System.Data.Linq;

namespace SP.Core.Domain
{
    [Serializable]
    public class VatCode : BaseEntity
    {
        private string _Code;
        private string _Description;
        private float _PercentageValue;
        private bool _VatExemptible;

        public override int ID
        {
            get
            {
                return base.ID;
            }
            set
            {
                base.ID = value;
            }
        }

        public string Code
        {
            get
            {
                return _Code;
            }
            set
            {
                _Code = value;
            }
        }

        public string Description
        {
            get
            {
                return _Description;
            }
            set
            {
                _Description = value;
            }
        }

        public float PercentageValue
        {
            get { return _PercentageValue; }
            set { _PercentageValue = value; }
        }

        public bool VatExemptible
        {
            get { return _VatExemptible; }
            set { _VatExemptible = value; }
        }


        public System.Data.Linq.Binary Version
        {
            get;
            set;
        }
    }
}
