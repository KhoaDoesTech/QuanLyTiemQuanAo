using DBLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlTypes;

namespace BALayer
{
    public class DB_Job
    {
        DAL db = null;
        public DB_Job(string strConnect_local)
        {
            db = new DAL(strConnect_local);
        }
        public DataTable GetJob()
        {
            return db.ExecuteQueryDataTable("select * from Job");
        }
        public bool InsertJob(ref string err, string job_title_id,
            string branch_id, string job_name, int base_salary)
        {
            return db.MyExecuteNonQuery("SP_Insert_Job",
                ref err,
                new SqlParameter("@job_title_id", job_title_id),
                new SqlParameter("@branch_id", branch_id),
                new SqlParameter("@job_name", job_name),
                new SqlParameter("@base_salary", base_salary));
        }
        public bool FindJob(ref string err, string job_title_id,
            string branch_id, string job_name, int base_salary)
        {
            return db.MyExecuteNonQuery("SP_Find_Job",
                ref err,
                new SqlParameter("@job_title_id", job_title_id),
                new SqlParameter("@branch_id", branch_id),
                new SqlParameter("@job_name", job_name),
                new SqlParameter("@base_salary", base_salary));
        }
    }
}
