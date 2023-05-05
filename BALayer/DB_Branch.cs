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
    public class DB_Branch
    {
        DAL db = null;
        public DB_Branch (string strConnect_local)
        {
            db = new DAL (strConnect_local);
        }
        public string GetDefaultBranchID()
        {
            return (string)db.MyExecuteScalar("SELECT DBO.AutoIDBranch()");
        }
        public DataTable GetBranch()
        {
            return db.ExecuteQueryDataTable("select * from Branch");
        }
        public bool InsertBranch(ref string err,
             string branch_name, int max_stock, int rent_amount)
        {
            return db.MyExecuteNonQuery("SP_Insert_Branch",
                ref err,                
                new SqlParameter("@branch_name", branch_name),
                new SqlParameter("@max_stock", max_stock),
                new SqlParameter("@rent_amount", rent_amount));
        }
        public DataTable FindBranchByID(string branch_id)
        {
            return db.ExecuteNonQueryDataTable("SELECT * FROM DBO.FindBranchByID(@branch_id)",
                new SqlParameter("@branch_id", branch_id));
        }
        public DataTable FindBranchByName(string branch_name)
        {
            return db.ExecuteNonQueryDataTable("SELECT * FROM DBO.FindBranchByName(@branch_name)",
                new SqlParameter("@branch_name", branch_name));
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
    }
}
