using DBLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BALayer
{
    public class DB_Personal
    {
        DAL db = null;
        public DB_Personal(string strConnect_local)
        {
            db = new DAL(strConnect_local);
        }

        public DataTable GetPersonInformation(string username, string passcode)
        {
            return db.ExecuteNonQueryDataTable("SELECT * FROM DBO.GetPersonInformation(@username, @passcode)",
                new SqlParameter("@username", username),
                new SqlParameter("@passcode", passcode));
        }

        public DataTable GetPersonSummary(string username, string passcode)
        {
            return db.ExecuteNonQueryDataTable("SELECT * FROM DBO.GetPersonSummary(@username, @passcode)",
                new SqlParameter("@username", username),
                new SqlParameter("@passcode", passcode));
        }

        public bool CheckLogin(string username, string passcode)
        {
            return (bool)db.MyExecuteScalarNoQuery("SELECT DBO.CheckLogin(@username, @passcode)",
                    new SqlParameter("@username", username),
                    new SqlParameter("@passcode", passcode));
        }

        public bool UpdateAccounts(ref string err, string username, string passcodeold, string passcodenew)
        {
            return db.MyExecuteNonQuery("SP_Update_Accounts",
                ref err,
                new SqlParameter("@username", username),
                new SqlParameter("@passcodeold", passcodeold),
                new SqlParameter("@passcodenew", passcodenew));
        }

        public string GetRole(string username, string passcode)
        {
            return (string)db.MyExecuteScalarNoQuery("SELECT DBO.GetRole(@username, @passcode)",
                new SqlParameter("@username", username),
                new SqlParameter("@passcode", passcode));
        }

        public bool UpdatePerson(ref string err, string full_name, string gender, string birthday,
            string phone, string address, string email)
        {
            return db.MyExecuteNonQuery("SP_Update_Person",
                ref err,
                new SqlParameter("@full_name", full_name),
                new SqlParameter("@gender", gender),
                new SqlParameter("@birthday", birthday),
                new SqlParameter("@phone", phone),
                new SqlParameter("@address", address),
                new SqlParameter("@email", email));
        }

        public bool Logout(ref string err, string username)
        {
            return db.MyExecuteNonQuery("SP_Logout",
                ref err,
                new SqlParameter("@username", username));
        }
    }
}
