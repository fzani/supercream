/***************************************************************************************************
// -- Generated by AlteraxGen 28/04/2010 22:21:37
// Version 1.0
***************************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SP.Core.Domain
{
    [Serializable]
    public class OrderCreditNote : BaseEntity
    {
        private int _OrderID;
        private string _Reason;
        private string _Reference;
        private DateTime _DueDate;
        private DateTime _DateCreated;
        private string _ReasonForVoiding;
        private bool _IsVoid;

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

        public int OrderID
        {
            get
            {
                return _OrderID;
            }
            set
            {
                _OrderID = value;
            }
        }

        public string Reason
        {
            get
            {
                return _Reason;
            }
            set
            {
                _Reason = value;
            }
        }

        public DateTime DateCreated
        {
            get
            {
                return _DateCreated;
            }
            set
            {
                _DateCreated = value;
            }
        }

        public string Reference
        {
            get
            {
                return _Reference;
            }
            set
            {
                _Reference = value;
            }
        }

        public DateTime DueDate
        {
            get
            {
                return _DueDate;
            }
            set
            {
                _DueDate = value;
            }
        }

        public string ReasonForVoiding
        {
            get
            {
                return _ReasonForVoiding;
            }

            set
            {
                _ReasonForVoiding = value;
            }
        }

        public bool IsVoid
        {
            get
            {
                return _IsVoid;
            }

            set
            {
                _IsVoid = value;
            }
        }
    }
}
