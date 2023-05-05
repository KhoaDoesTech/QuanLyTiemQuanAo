using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBLayer;
using System.Data;
using System.Data.SqlClient;

namespace BALayer
{
    public class DB_Event
    {
        DAL db = null;
        public DB_Event(string strConnect_local)
        {
            db = new DAL(strConnect_local);
        }
        public string GetDefaultEventID()
        {
            return (string)db.MyExecuteScalar("SELECT DBO.AutoIDEvent()");
        }
        public DataTable GetEvent()
        {
            return db.ExecuteQueryDataTable("select * from BranchEvent");
        }
        public bool InsertEvent(ref string err, string event_name,
                     DateTime date_start, DateTime date_end)
        {
            return db.MyExecuteNonQuery("SP_Insert_Event",
                ref err,
                new SqlParameter("@event_name", event_name),
                new SqlParameter("@date_start", date_start),
                new SqlParameter("@date_end", date_end));
        }
        public DataTable FindEventByID(string event_id)
        {
            return db.ExecuteNonQueryDataTable("SELECT * FROM DBO.FindEventByID(@event_id)",
                 new SqlParameter("@event_id", event_id));
        }
        public DataTable FindEventByName(string event_name)
        {
            return db.ExecuteNonQueryDataTable("SELECT * FROM DBO.FindEventByName(@event_name)",
                 new SqlParameter("@event_name", event_name));
        }
        public bool UpdateEvent(ref string err, string event_id, string event_name,
                     DateTime date_start, DateTime date_end)
        {
            return db.MyExecuteNonQuery("SP_Update_Event",
                ref err,
                new SqlParameter("@event_id",event_id),
                new SqlParameter("@event_name", event_name),
                new SqlParameter("@date_start", date_start),
                new SqlParameter("@date_end", date_end));
        }
    }
}
