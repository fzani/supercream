using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SP.Core.Domain
{
    [Serializable]
    public class Phone : BaseEntity
    {
        private int? _ContactDetailID;
        private int? _PhoneTypeID;
        private string _Description;

        private ContactDetail _ContactDetail;

        private PhoneNoType _PhoneNoType;

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

        public int? ContactDetailID
        {
            get
            {
                return _ContactDetailID;
            }
            set
            {
                _ContactDetailID = value;
            }
        }

        public int? PhoneTypeID
        {
            get
            {
                return _PhoneTypeID;
            }
            set
            {
                _PhoneTypeID = value;
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

        public PhoneNoType PhoneNoType
        {
            get
            {
                return this._PhoneNoType;
            }
            set
            {
                _PhoneNoType = value;
            }
        }

        public ContactDetail ContactDetail
        {
            get 
            { 
                return _ContactDetail; 
            }
            set 
            { 
                _ContactDetail = value; 
            }
        }
    }
}
