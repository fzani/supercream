
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SP.Mvp
{
    [Serializable]
    public class MyOffer
    {
        private string _Name;
        private DateTime _ValidFrom;
        private DateTime _ValidTo;
        private int _ID;

        public int ID
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

        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
            }
        }

        public DateTime ValidFrom
        {
            get
            {
                return _ValidFrom;
            }
            set
            {
                _ValidFrom = value;
            }
        }

        public DateTime ValidTo
        {
            get
            {
                return _ValidTo;
            }
            set
            {
                _ValidTo = value;
            }
        }
    }
}


