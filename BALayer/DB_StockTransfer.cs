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
    public class DB_StockTransfer
    {
        DAL db = null;
        public DB_StockTransfer(string strConnect_local)
        {
            db = new DAL(strConnect_local);
        }
        public DataTable GetStockTransfer()
        {
            return db.ExecuteQueryDataTable("select * from StockTransfer");
        }
        public bool InsertStockTransfer(ref string err, string from_branch_id,
            string to_branch_id, string product_id, DateTime transfer_date, int quantity)
        {
            return db.MyExecuteNonQuery("SP_Insert_StockTransfer",
                ref err,
                new SqlParameter("@from_branch_id", from_branch_id),
                new SqlParameter("@to_branch_id", to_branch_id),
                new SqlParameter("@product_id", product_id),
                new SqlParameter("@transfer_date", transfer_date),
                new SqlParameter("@quantity", quantity));
        }
        public bool UpdateStockTransfer(ref string err, string from_branch_id,
            string to_branch_id, string product_id, DateTime transfer_date, int quantity)
        {
            return db.MyExecuteNonQuery("SP_Update_StockTransfer",
                ref err,
                new SqlParameter("@from_branch_id", from_branch_id),
                new SqlParameter("@to_branch_id", to_branch_id),
                new SqlParameter("@product_id", product_id),
                new SqlParameter("@transfer_date", transfer_date),
                new SqlParameter("@quantity", quantity));
        }
        public bool DeleteStockTransfer(ref string err, string from_branch_id,
            string to_branch_id, string product_id, DateTime transfer_date)
        {
            return db.MyExecuteNonQuery("SP_Delete_StockTransfer",
                ref err,
                new SqlParameter("@branfrom_branch_idch_id", from_branch_id),
                new SqlParameter("@to_branch_id", to_branch_id),
                new SqlParameter("@product_id", product_id),
                new SqlParameter("@transfer_date", transfer_date));
        }
        public DataTable FindProductByFromBranch(string from_branch_id)
        {
            return db.ExecuteNonQueryDataTable("SELECT * FROM DBO.FindProductByFromBranch(@from_branch_id)",
                 new SqlParameter("@from_branch_id", from_branch_id));
        }
        public DataTable FindProductByToBranch(string to_branch_id)
        {
            return db.ExecuteNonQueryDataTable("SELECT * FROM DBO.FindProductByToBranch(@to_branch_id)",
                 new SqlParameter("@to_branch_id", to_branch_id));
        }
        public DataTable FindProductByID(string product_id)
        {
            return db.ExecuteNonQueryDataTable("SELECT * FROM DBO.FindProductByID(@product_id)",
                 new SqlParameter("@product_id", product_id));
        }
    }
}
