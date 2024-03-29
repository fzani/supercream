﻿/***************************************************************************************************
// -- Generated by AlteraxGen 03/03/2010 11:19:47
// Version 1.0
***************************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SP.Core.Domain
{
    [Serializable]
    public class CreditNote : BaseEntity
    {        
        private int _OrderID;
        private decimal _CreditAmount;
        private string _Reason;
        private DateTime _DateCreated;
        private string _Reference;
        private bool _VatExempt;
        private DateTime _DueDate;
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

        public decimal CreditAmount
        {
            get
            {
                return _CreditAmount;
            }
            set
            {
                _CreditAmount = value;
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

        public bool VatExempt
        {
            get
            {
                return _VatExempt;
            }

            set
            {
                _VatExempt = value;
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
