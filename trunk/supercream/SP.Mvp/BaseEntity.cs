using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SP.Mvp
{
    public abstract class BaseEntity
    {
        private int _ID;

        public virtual int ID
        {
            get
            {
                return _ID;
            }
            set
            {
                _ID = value;
            }
        }
    }
}
