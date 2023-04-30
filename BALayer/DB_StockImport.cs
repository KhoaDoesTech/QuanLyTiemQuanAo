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
    public class DB_StockImport
    {
        DAL db = null;
        public DB_StockImport(string strConnect_local)
        {
            db = new DAL(strConnect_local);
        }
        public DataTable GetStockImport()
        {
            return db.ExecuteQueryDataTable("select * from StockImport");
        }
        public bool InsertStockImport(ref string err, string branch_id,
            string product_id, DateTime import_date, int import_money, int quantity)
        {
            return db.MyExecuteNonQuery("SP_Insert_StockImport",
                ref err,
                new SqlParameter("@branch_id", branch_id),
                new SqlParameter("@product_id", product_id),
                new SqlParameter("@import_date", import_date),
                new SqlParameter("@import_money", import_money),
                new SqlParameter("@quantity", quantity));
        }
        public bool UpdateStockImport(ref string err, string branch_id,
            string product_id, DateTime import_date, int import_money, int quantity)
        {
            return db.MyExecuteNonQuery("SP_Update_StockImport",
                ref err,
                new SqlParameter("@branch_id", branch_id),
                new SqlParameter("@product_id", product_id),
                new SqlParameter("@import_date", import_date),
                new SqlParameter("@import_money", import_money),
                new SqlParameter("@quantity", quantity));
        }
        public bool DeleteStockImport(ref string err, string branch_id,
            string product_id, DateTime import_date)
        {
            return db.MyExecuteNonQuery("SP_Delete_StockImport",
                ref err,
                new SqlParameter("@branch_id", branch_id),
                new SqlParameter("@product_id", product_id),
                new SqlParameter("@import_date", import_date));
        }
    }
}
