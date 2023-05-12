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
    public class DB_StatisticsCustomer
    {
        DAL db = null;
        public DB_StatisticsCustomer(string strConnect_local)
        {
            db = new DAL(strConnect_local);
        }
        public DataTable GetStatisticsOrder()
        {
            return db.ExecuteNonQueryDataTable("select * from GetStatisticsOrder");
        }
    }
}
