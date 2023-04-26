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
    }
}
