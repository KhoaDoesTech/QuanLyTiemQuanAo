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
        public DataTable GetTime()
        {
            return db.ExecuteQueryDataTable("select * from DBO.");
        }
        public DataTable GetStatisticsEmployee()
        {
            return db.ExecuteQueryDataTable("select * from DBO.GetStatisticsEmployee()");
        }
        public int GetEmployeeQuantity()
        {
            return (int)db.MyExecuteScalar("select dbo.GetEmployeeQuantity()");
        }
        public DataTable GetMostSoldEmployee()
        {
            return db.ExecuteQueryDataTable("select * from DBO.GetMostSoldEmployee()");
        }
    }
}
