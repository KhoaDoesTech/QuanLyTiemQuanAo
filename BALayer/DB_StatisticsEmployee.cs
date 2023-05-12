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
            return db.ExecuteQueryDataTable("select * from StatisticsEmployee where branch_id ='" + branch_id + "'");
        }
        public int GetEmployeeQuantity()
        {
            return (int)db.MyExecuteScalar("select dbo.GetEmployeeQuantity()");
        }
        public int GetBranchEmployeeQuantity(string branch_id)
        {
            return (int)db.MyExecuteScalarNoQuery("select dbo.GetBranchEmployeeQuantity(@branch_id)",
                new SqlParameter("@branch_id", branch_id));
        }
        public DataTable GetBranchMostSoldEmployee(string branch_id, int month, int year)
        {
            return db.ExecuteNonQueryDataTable("select * from DBO.GetBranchMostSoldEmployee(@branch_id, @month, @year)",
                new SqlParameter("@branch_id", branch_id),
                new SqlParameter("@month", month),
                new SqlParameter("@year", year));
        }
        public DataTable GetMostSoldEmployee(int month, int year)
        {
            return db.ExecuteNonQueryDataTable("select * from DBO.GetMostSoldEmployee(@month, @year)",
                new SqlParameter("@month", month),
                new SqlParameter("@year", year));
        }
    }
}
