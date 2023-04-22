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
    public class DB_JobTitle
    {
        DAL db = null;
        public DB_JobTitle(string strConnect_local)
        {
            db = new DAL(strConnect_local);
        }
        public DataTable GetJobTitle()
        {
            return db.ExecuteQueryDataTable("select * from JobTitle");
        }
        public bool InsertJobTitle(ref string err, string job_title_id,
             string job_title_name, string job_description)
        {
            return db.MyExecuteNonQuery("SP_Insert_JobTitle",
                ref err,
                new SqlParameter("@job_title_id", job_title_id),
                new SqlParameter("@job_title_name", job_title_name),
                new SqlParameter("@job_description", job_description));
        }
        public DataTable FindJobTitletByID(string job_title_id)
        {
            return db.ExecuteNonQueryDataTable("SELECT * FROM DBO.FindJobTitleByID(@job_title_id)",
                 new SqlParameter("@job_title_id", job_title_id));
        }
        public DataTable FindJobTitleByName(string job_title_name)
        {
            return db.ExecuteNonQueryDataTable("SELECT * FROM DBO.FindJobTitleByName(@job_title_name)",
                 new SqlParameter("@job_title_name", job_title_name));
        }
        public bool UpdateJobTitle(ref string err, string job_title_id,
             string job_title_name, string job_description)
        {
            return db.MyExecuteNonQuery("SP_Update_JobTitle",
                ref err,
                new SqlParameter("@job_title_id", job_title_id),
                new SqlParameter("@job_title_name", job_title_name),
                new SqlParameter("@job_description", job_description));
        }
    }
}
