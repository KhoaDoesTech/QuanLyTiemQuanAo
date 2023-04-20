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
    public class DB_Branch
    {
        DAL db = null;
        public DB_Branch()
        {
            db = new DAL();
        }
        public DataTable GetBranch()
        {
            return db.ExecuteQueryDataTable("select * from Branch");
        }
        public bool InsertBranch(ref string err, string branch_id,
             string branch_name, int max_stock, int rent_amount)
        {
            return db.MyExecuteNonQuery("SP_Insert_Branch",
                ref err,
                new SqlParameter("@branch_id", branch_id),
                new SqlParameter("@branch_name", branch_name),
                new SqlParameter("@max_stock", max_stock),
                new SqlParameter("@rent_amount", rent_amount));
        }
        public bool FindBranch(ref string err, string branch_id,
             string branch_name, int max_stock, int rent_amount)
        {
            return db.MyExecuteNonQuery("SP_Find_Branch",
                ref err,
                new SqlParameter("@branch_id", branch_id),
                new SqlParameter("@branch_name", branch_name),
                new SqlParameter("@max_stock", max_stock),
                new SqlParameter("@rent_amount", rent_amount));
        }
        public bool UpdateBranch(ref string err, string branch_id,
             string branch_name, int max_stock, int rent_amount)
        {
            return db.MyExecuteNonQuery("SP_Update_Branch",
                ref err,
                new SqlParameter("@branch_id", branch_id),
                new SqlParameter("@branch_name", branch_name),
                new SqlParameter("@max_stock", max_stock),
                new SqlParameter("@rent_amount", rent_amount));
        }
        public bool DeleteBranch(ref string err, string branch_id)
        {
            return db.MyExecuteNonQuery("SP_Delete_Branch", ref err,
                new SqlParameter("@branch_id", branch_id));
        }

    }
}
