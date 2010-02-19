﻿/***************************************************************************************************
// -- Generated by AlteraxGen 09/02/2010 12:43:38
// Version 1.0
***************************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SP.Core.Domain
{
    [Serializable]
    public class SpecialInvoiceHeader : BaseEntity
    {       
        private int _CustomerID;
        private short _AlphaPrefixOrPostFix;
        private string _AlphaID;
        private DateTime _OrderDate;
        private DateTime _DeliveryDate;
        private short _OrderStatus;
        private string _SpecialInstructions;
        private string _InvoiceNo;

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

        public int CustomerID
        {
            get
            {
                return _CustomerID;
            }
            set
            {
                _CustomerID = value;
            }
        }

        public short AlphaPrefixOrPostFix
        {
            get
            {
                return _AlphaPrefixOrPostFix;
            }
            set
            {
                _AlphaPrefixOrPostFix = value;
            }
        }

        public string AlphaID
        {
            get
            {
                return _AlphaID;
            }
            set
            {
                _AlphaID = value;
            }
        }

        public DateTime OrderDate
        {
            get
            {
                return _OrderDate;
            }
            set
            {
                _OrderDate = value;
            }
        }

        public DateTime DeliveryDate
        {
            get
            {
                return _DeliveryDate;
            }
            set
            {
                _DeliveryDate = value;
            }
        }

        public short OrderStatus
        {
            get
            {
                return _OrderStatus;
            }
            set
            {
                _OrderStatus = value;
            }
        }

        public string SpecialInstructions
        {
            get
            {
                return _SpecialInstructions;
            }
            set
            {
                _SpecialInstructions = value;
            }
        }

        public string InvoiceNo
        {
            get
            {
                return _InvoiceNo;
            }
            set
            {
                _InvoiceNo = value;
            }
        }
    }
}