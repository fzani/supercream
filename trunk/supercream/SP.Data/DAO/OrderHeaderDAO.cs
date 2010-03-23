using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using System.Data;

using SP.Core.Domain;
using SP.Core.DataInterfaces;
using System.Data.Linq;
using System.Diagnostics;

namespace SP.Data.LTS
{
    public class OrderHeaderDao : AbstractLTSDao<OrderHeader, int>, IOrderHeaderDao
    {
        public override OrderHeader GetById(int id)
        {          
            return db.OrderHeader.Single<OrderHeader>(q => q.ID == id);
        }

        public OrderHeader GetOrderHeaderWithVatCode(int id)
        {
            DataLoadOptions dlo = new DataLoadOptions();
            dlo.LoadWith<OrderHeader>(o => o.VatCode);
            db.LoadOptions = dlo;

            return db.OrderHeader.Single<OrderHeader>(q => q.ID == id);
        }

        public bool InvoiceNoExists(string invoiceNo)
        {
            return (db.OrderHeader.SingleOrDefault<OrderHeader>(q => q.InvoiceNo == invoiceNo) == null) ? false : true;
        }

        public OrderHeader GetOrderHeader(string orderNo)
        {
            return db.OrderHeader.SingleOrDefault<OrderHeader>(q => q.AlphaID == orderNo);
        }

        public string GenerateOrderNo()
        {          
            return "ORD-" + (Convert.ToInt32(db.OrderHeader.Select(q => q.AlphaID.Substring(4, (q.AlphaID.Length - 4))).Max()) + 1);        
        }

        public string GenerateInvoiceNo()
        {
            List<OrderHeader> invoices =  db.OrderHeader.Where(q => q.InvoiceNo != null && q.InvoiceNo != "").ToList<OrderHeader>();
            return "INV-" + (Convert.ToInt32(invoices.Select(q => q.InvoiceNo.Substring(4, (q.InvoiceNo.Length - 4))).Max()) + 1).ToString();
        }

        public string GenerateInvoiceProformaNo()
        {
            List<OrderHeader> invoices = db.OrderHeader.Where(q => q.InvoiceProformaNo != null && q.InvoiceProformaNo != "").ToList<OrderHeader>();
            return "INP-" + (Convert.ToInt32(invoices.Select(q => q.InvoiceProformaNo.Substring(4, (q.InvoiceProformaNo.Length - 4))).Max()) + 1).ToString();
        }

        public string GenerateDeliveryNoteNo()
        {
            List<OrderHeader> invoices = db.OrderHeader.Where(q => q.DeliveryNoteNo != null && q.DeliveryNoteNo != "").ToList<OrderHeader>();
            return "DLV-" + (Convert.ToInt32(invoices.Select(q => q.DeliveryNoteNo.Substring(4, (q.DeliveryNoteNo.Length - 4))).Max()) + 1).ToString();
        }

        public List<OrderHeader> GetOrderHeaderForSearch(string orderNo, string invoiceNo, string customerName, DateTime dateFrom, DateTime dateTo, short orderStatus)
        {
            using (SqlConnection conn = new SqlConnection(db.Connection.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("[dbo].[GetOrderHeaders]", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter myParm1 = cmd.Parameters.Add("@OrderID", System.Data.SqlDbType.VarChar, 50);
                if (String.IsNullOrEmpty(orderNo))
                    myParm1.Value = DBNull.Value;
                else
                    myParm1.Value = orderNo;
                cmd.Parameters[0].IsNullable = true;

                SqlParameter myParm2 = cmd.Parameters.Add("@InvoiceNo", System.Data.SqlDbType.VarChar, 50);
                if (String.IsNullOrEmpty(invoiceNo))
                    myParm2.Value = DBNull.Value;
                else
                    myParm2.Value = invoiceNo;
                cmd.Parameters[0].IsNullable = true;

                cmd.Parameters.Add("@CustomerName", System.Data.SqlDbType.VarChar, 50);
                if (String.IsNullOrEmpty(customerName))
                    cmd.Parameters["@CustomerName"].Value = DBNull.Value;
                else
                    cmd.Parameters["@CustomerName"].Value = customerName;
                cmd.Parameters[1].IsNullable = true;

                cmd.Parameters.Add("@OrderStatus", System.Data.SqlDbType.SmallInt);
                cmd.Parameters["@OrderStatus"].Value = orderStatus;

                cmd.Parameters.Add("@DateFrom", System.Data.SqlDbType.DateTime, 20);
                cmd.Parameters["@DateFrom"].IsNullable = true;
                if (dateFrom == DateTime.MinValue)
                    cmd.Parameters["@DateFrom"].Value = DBNull.Value;
                else
                    cmd.Parameters["@DateFrom"].Value = dateFrom;

                cmd.Parameters.Add("@DateTo", System.Data.SqlDbType.DateTime, 20);
                cmd.Parameters["@DateTo"].IsNullable = true;
                if (dateTo == DateTime.MinValue)
                    cmd.Parameters["@DateTo"].Value = DBNull.Value;
                else
                    cmd.Parameters["@DateTo"].Value = dateTo;

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<OrderHeader>(o => o.VatCode);
                db.LoadOptions = dlo;

                return db.Translate<OrderHeader>(reader).ToList<OrderHeader>();
            }
        }

        public List<OrderHeader> GetOrderHeaderForSearchWithPrintedOrderStatuses(string orderNo, string invoiceNo, string customerName, DateTime dateFrom, DateTime dateTo, short actualOrderStatus, short printedOrderStatus)
        {
            using (SqlConnection conn = new SqlConnection(db.Connection.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("[dbo].[GetOrderHeadersByBothOrderStatuses]", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter myParm1 = cmd.Parameters.Add("@OrderID", System.Data.SqlDbType.VarChar, 50);
                if (String.IsNullOrEmpty(orderNo))
                    myParm1.Value = DBNull.Value;
                else
                    myParm1.Value = orderNo;
                cmd.Parameters[0].IsNullable = true;

                SqlParameter myParm2 = cmd.Parameters.Add("@InvoiceNo", System.Data.SqlDbType.VarChar, 50);
                if (String.IsNullOrEmpty(invoiceNo))
                    myParm2.Value = DBNull.Value;
                else
                    myParm2.Value = invoiceNo;
                cmd.Parameters[0].IsNullable = true;

                cmd.Parameters.Add("@CustomerName", System.Data.SqlDbType.VarChar, 50);
                if (String.IsNullOrEmpty(customerName))
                    cmd.Parameters["@CustomerName"].Value = DBNull.Value;
                else
                    cmd.Parameters["@CustomerName"].Value = customerName;
                cmd.Parameters[1].IsNullable = true;

                cmd.Parameters.Add("@ActualOrderStatus", System.Data.SqlDbType.SmallInt);
                cmd.Parameters["@ActualOrderStatus"].Value = actualOrderStatus;

                cmd.Parameters.Add("@PrintedOrderStatus", System.Data.SqlDbType.SmallInt);
                cmd.Parameters["@PrintedOrderStatus"].Value = printedOrderStatus;

                cmd.Parameters.Add("@DateFrom", System.Data.SqlDbType.DateTime, 20);
                cmd.Parameters["@DateFrom"].IsNullable = true;
                if (dateFrom == DateTime.MinValue)
                    cmd.Parameters["@DateFrom"].Value = DBNull.Value;
                else
                    cmd.Parameters["@DateFrom"].Value = dateFrom;

                cmd.Parameters.Add("@DateTo", System.Data.SqlDbType.DateTime, 20);
                cmd.Parameters["@DateTo"].IsNullable = true;
                if (dateTo == DateTime.MinValue)
                    cmd.Parameters["@DateTo"].Value = DBNull.Value;
                else
                    cmd.Parameters["@DateTo"].Value = dateTo;

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                return db.Translate<OrderHeader>(reader).ToList<OrderHeader>();
            }
        }

        public List<InvoiceWithStatus> GetInvoicesWithStatus(string orderNo, string invoiceNo, string customerName, DateTime dateFrom, DateTime dateTo, short orderStatus)
        {
            DataLoadOptions dlo = new DataLoadOptions();
            dlo.LoadWith<OrderHeader>(q => q.OrderLine);

            db.LoadOptions = dlo;
            db.Log = Console.Out;

            var orderHeaders = (from o in db.OrderHeader
                                join ons in db.OrderNotesStatus on o.ID equals ons.OrderID
                                join c in db.Customer on o.CustomerID equals c.ID
                                select new InvoiceWithStatus
                                {
                                    InvoicePaymentComplete = ons.InvoicePaymentComplete,
                                    InvoiceNo = o.InvoiceNo,
                                    OrderDate = o.OrderDate,
                                    OrderID = o.AlphaID,
                                    CustomerName = c.Name,
                                    OrderStatus = o.OrderStatus
                                });

            return FilterInvoices(orderHeaders,
                    orderNo,
                    invoiceNo,
                    customerName,
                    dateFrom,
                    dateTo,
                    orderStatus).ToList<InvoiceWithStatus>();
        }

        IQueryable<InvoiceWithStatus> FilterInvoices(IQueryable<InvoiceWithStatus> invoices,
            string orderNo,
            string invoiceNo,
            string customerName,
            DateTime dateFrom,
            DateTime dateTo,
            short orderStatus)
        {
            IQueryable<InvoiceWithStatus> filteredInvoices = invoices;
            if (!String.IsNullOrEmpty(orderNo))
            {
                filteredInvoices = filteredInvoices.Where<InvoiceWithStatus>(q => q.OrderID.Contains(orderNo));
            }

            if (!String.IsNullOrEmpty(invoiceNo))
            {
                filteredInvoices = filteredInvoices.Where<InvoiceWithStatus>(q => q.InvoiceNo.Contains(invoiceNo));
            }

            if (!String.IsNullOrEmpty(customerName))
            {
                filteredInvoices = filteredInvoices.Where<InvoiceWithStatus>(q => q.CustomerName.Contains(customerName));
            }

            if (dateFrom != DateTime.MinValue)
            {
                filteredInvoices = filteredInvoices.Where<InvoiceWithStatus>(q => q.OrderDate >= dateFrom);
            }

            if (dateTo != DateTime.MinValue)
            {
                filteredInvoices = filteredInvoices.Where<InvoiceWithStatus>(q => q.OrderDate <= dateTo);
            }

            if (orderStatus == 2)
            {
                filteredInvoices = filteredInvoices.Where<InvoiceWithStatus>((q => (q.OrderStatus == 2) || (q.OrderStatus == 3)));
            }
            else
            {
                filteredInvoices = filteredInvoices.Where<InvoiceWithStatus>(q => q.OrderStatus == 3);
            }

            return filteredInvoices;
        }

        public bool Exists(string orderNo)
        {
            return (db.OrderHeader.SingleOrDefault<OrderHeader>(q => q.AlphaID == orderNo) == null) ? false : true;
        }
    }
}
