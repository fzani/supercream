using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SP.Core.Domain
{
    [Serializable]
    public class VanDeliveryItem : BaseEntity
    {
        private string _item;

        public VanDeliveryItem()
        {
        }

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

        public string Item
        {
            get
            {
                return _item;
            }
            set
            {
                _item = value;
            }
        }
    }
}
