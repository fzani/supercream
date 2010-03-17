using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SP.Core.Domain
{
    [Serializable]
    public class AutoGen : BaseEntity
    {      
        private string _Type;

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
            
        public string Type
        {
            get
            {
                return _Type;
            }
            set
            {
                _Type = value;
            }
        }
    }
}
