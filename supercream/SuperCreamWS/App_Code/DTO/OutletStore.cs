/// <summary>
/// Summary description for OutletStore
/// </summary>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SP.Web.DTO
{
    [Serializable]
    public class OutletStore
    {
        private string _Name;
        private string _OpeningHoursNotes;
        private string _Notes;

        private Address address;

        public OutletStore()
        {
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

        public string OpeningHoursNotes
        {
            get
            {
                return _OpeningHoursNotes;
            }
            set
            {
                _OpeningHoursNotes = value;
            }
        }

        public string Notes
        {
            get
            {
                return _Notes;
            }
            set
            {
                _Notes = value;
            }
        }

        public Address Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            }
        }
    }
}


