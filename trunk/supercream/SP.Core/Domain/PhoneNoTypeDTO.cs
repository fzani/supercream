using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SP.Core.Domain
{
    [Serializable]
    public class PhoneNoType : BaseEntity
    {
        private string _Description;
        private Phone _Phone;

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

        public Phone Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }

    }
}
