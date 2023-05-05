using DBLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BALayer
{
    public class DB_Account
    {
        DAL db = null;
        public DB_Account(string strConnect_local)
        {
            db = new DAL(strConnect_local);
        }

        public DataTable GetAccount()
        {
            return db.ExecuteQueryDataTable("select * from Acccount");
        }

        public bool InsertAccount(ref string err, string username,
            string passcode)
        {
            return db.MyExecuteNonQuery("SP_Insert_Account",
                ref err,
                new SqlParameter("@username", username),
                new SqlParameter("@passcode", passcode));
        }
        public DataTable FindAccount(string employee_id)
        {
            return db.ExecuteNonQueryDataTable("SELECT * FROM DBO.FindAccount(@employee_id)",
                 new SqlParameter("@employee_id", employee_id));
        }
        public bool UpdateAccount(ref string err, string employee_id, string username,
            string passcode)
        {
            return db.MyExecuteNonQuery("SP_Update_Account",
                ref err,
                new SqlParameter("@employee_id", employee_id),
                new SqlParameter("@username", username),
                new SqlParameter("@passcode", passcode));
        }
    }
}
