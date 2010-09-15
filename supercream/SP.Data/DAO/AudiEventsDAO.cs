using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using SP.Core.Domain;
using SP.Core.DataInterfaces;
using SP.Data.LTS;

namespace SP.Data.LTS
{
    public class AuditEventsDao : AbstractLTSDao<AuditEvents, int>, IAuditEventsDao
    {
        public AuditEventsDao()
        {
        }

        public AuditEventsDao(LTSDataContext ctx)
            : base(ctx)
        {
        }

        public override AuditEvents GetById(int id)
        {
            return db.AuditEvents.Single<AuditEvents>(q => q.ID == id);
        }

        public List<string> Descriptions()
        {
            return (from ae in db.AuditEvents
                    select ae.Description).Distinct().OrderBy(a => a).ToList<string>();
        }

        public List<AuditEvents> GetAllAuditEvents(string description, string creator, DateTime createdDate)
        {
            using (SqlConnection conn = new SqlConnection(db.Connection.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("[dbo].[GetActionEvents]", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter myParm1 = cmd.Parameters.Add("@DescriptionName", System.Data.SqlDbType.VarChar, 150);
                if (String.IsNullOrEmpty(description))
                    myParm1.Value = DBNull.Value;
                else
                    myParm1.Value = description;
                cmd.Parameters[0].IsNullable = true;


                cmd.Parameters.Add("@Creator", System.Data.SqlDbType.VarChar, 150);
                if (String.IsNullOrEmpty(creator))
                    cmd.Parameters["@Creator"].Value = DBNull.Value;
                else
                    cmd.Parameters["@Creator"].Value = creator;

                cmd.Parameters[1].IsNullable = true;
                cmd.Parameters.Add("@CreatedDate", System.Data.SqlDbType.DateTime, 20);
                cmd.Parameters["@CreatedDate"].IsNullable = true;
                if (createdDate == DateTime.MinValue)
                    cmd.Parameters["@CreatedDate"].Value = DBNull.Value;
                else
                    cmd.Parameters["@CreatedDate"].Value = createdDate;

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                return db.Translate<AuditEvents>(reader).ToList<AuditEvents>();
            }
        }

        public void ArchiveAuditEvents()
        {
            using (SqlConnection conn = new SqlConnection(db.Connection.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("[dbo].[ArchiveAuditEvents]", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();
                int n = cmd.ExecuteNonQuery();
            }
        }
    }
}

