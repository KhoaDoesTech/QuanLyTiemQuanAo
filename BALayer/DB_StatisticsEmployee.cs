using DBLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BALayer
{
    public class DB_StatisticsEmployee
    {
        DAL db = null;
        public DB_StatisticsEmployee(string strConnect_local)
        {
            db = new DAL(strConnect_local);
        }
        public DataTable GetStatisticsEmployee(string branch_id)
        {
            return db.ExecuteNonQueryDataTable("select * from DBO.GetStatisticsEmployee(@branch_id)",
                new SqlParameter("@branch_id", branch_id));
        }
        public int GetEmployeeQuantity()
        {
            return (int)db.MyExecuteScalar("select dbo.GetEmployeeQuantity()");
        }
        public DataTable GetMostSoldEmployee(string branch_id, int month, int year)
        {
            return db.ExecuteNonQueryDataTable("select * from DBO.GetMostSoldEmployee(@branch_id, @month, @year)",
                new SqlParameter("@branch_id", branch_id),
                new SqlParameter("@month", month),
                new SqlParameter("@year", year));
        }
    }
}
