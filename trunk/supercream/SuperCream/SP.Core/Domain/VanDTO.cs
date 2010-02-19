using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SP.Core.Domain
{
    [Serializable]
    public class Van : BaseEntity
    {
        private string _Description;
        private OrderNotesStatus _OrderNotesStatus;
        private int _MaximumReccomendedParcelCount;

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

        public int MaximumReccomendedParcelCount
        {
            get
            {
                return _MaximumReccomendedParcelCount;
            }
            set
            {
                _MaximumReccomendedParcelCount = value;
            }
        }

        public OrderNotesStatus OrderNotesStatus
        {
            get
            {
                return _OrderNotesStatus;
            }
            set
            {
                _OrderNotesStatus = value;
                if (value != null)
                    _OrderNotesStatus.Van = this;
            }
        }
    }
}
