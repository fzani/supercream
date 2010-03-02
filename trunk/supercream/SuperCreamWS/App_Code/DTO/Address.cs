using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Address.
/// </summary>
namespace SP.Web.DTO
{
    [Serializable]
    public class Address
    {
        private int _id;
        private short _AddressType;
        private string _AddressLines;
        private string _Town;
        private string _County;
        private string _PostCode;
        private string _MapReference;       

        public Address()
        {
        }

        public int ID
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        public short AddressType
        {
            get
            {
                return _AddressType;
            }
            set
            {
                _AddressType = value;
            }
        }

        public string AddressLines
        {
            get
            {
                return _AddressLines;
            }
            set
            {
                _AddressLines = value;
            }
        }

        public string Town
        {
            get
            {
                return _Town;
            }
            set
            {
                _Town = value;
            }
        }

        public string County
        {
            get
            {
                return _County;
            }
            set
            {
                _County = value;
            }
        }

        public string PostCode
        {
            get
            {
                return _PostCode;
            }
            set
            {
                _PostCode = value;
            }
        }

        public string MapReference
        {
            get 
            { 
                return _MapReference; 
            }
            set 
            { 
                _MapReference = value; 
            }
        }
    }
}
