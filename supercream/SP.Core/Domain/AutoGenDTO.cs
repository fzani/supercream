using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SP.Core.Domain
{
    [Serializable]
    public class AutoGen : BaseEntity
    {
        private string _GeneratedValue;

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

        public string GeneratedValue
        {
            get
            {
                return _GeneratedValue;
            }
            set
            {
                _GeneratedValue = value;
            }
        }
    }
}
