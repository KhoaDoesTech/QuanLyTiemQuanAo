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
    public class DB_StatisticsProduct
    {
        DAL db = null;
        public DB_StatisticsProduct(string strConnect_local)
        {
            db = new DAL(strConnect_local);
        }
        public DataTable GetStatisticsProduct(string branch_id)
        {
            return db.ExecuteNonQueryDataTable("select * from DBO.GetStatisticsProduct where branch_id ='" + branch_id + "'");
        }
        public DataTable GetStatisticsProduct()
        {
            return db.ExecuteQueryDataTable("select * from GetStatisticsProduct");
        }
        public DataTable GetTopSoldProductsByType(string branch_id, int month, int year)
        {
            return db.ExecuteNonQueryDataTable("select * from DBO.GetTopSoldProductsByType(@branch_id, @month, @year)",
                new SqlParameter("@month", month),
                new SqlParameter("@year", year));
        }
        public DataTable GetStatisticProduct()
        {
            return db.ExecuteNonQueryDataTable("select * from GetStatisticProduct()");
        }
    }
}
