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
    public class DB_MonthSummary
    {
        DAL db = null;
        public DB_MonthSummary()
        {
            db = new DAL();
        }
        public DataTable GetMonthSummary()
        {
            return db.ExecuteQueryDataTable("select * from MonthSummary");
        }
        public bool InsertMonthSummary(ref string err, string employee_id,
            int summary_month, int summary_year,
            int products_sold, int bonus_salary, int salary)
        {
            return db.MyExecuteNonQuery("SP_Insert_MonthSummary",
                ref err,
                new SqlParameter("@employee_id", employee_id),
                new SqlParameter("@summary_month", summary_month),
                new SqlParameter("@summary_year", summary_year),
                new SqlParameter("@products_sold", products_sold),
                new SqlParameter("@bonus_salary", bonus_salary),
                new SqlParameter("@salary", salary));
        }
        public bool FindMonthSummary(ref string err, string employee_id,
            int summary_month, int summary_year,
            int products_sold, int bonus_salary, int salary)
        {
            return db.MyExecuteNonQuery("SP_Find_MonthSummary",
                ref err,
                new SqlParameter("@employee_id", employee_id),
                new SqlParameter("@summary_month", summary_month),
                new SqlParameter("@summary_year", summary_year),
                new SqlParameter("@products_sold", products_sold),
                new SqlParameter("@bonus_salary", bonus_salary),
                new SqlParameter("@salary", salary));
        }
        public bool UpdateMonthSummary(ref string err, string employee_id,
            int summary_month, int summary_year,
            int products_sold, int bonus_salary, int salary)
        {
            return db.MyExecuteNonQuery("SP_Update_MonthSummary",
                ref err,
                new SqlParameter("@employee_id", employee_id),
                new SqlParameter("@summary_month", summary_month),
                new SqlParameter("@summary_year", summary_year),
                new SqlParameter("@products_sold", products_sold),
                new SqlParameter("@bonus_salary", bonus_salary),
                new SqlParameter("@salary", salary));
        }
        public bool DeleteMonthSummary(ref string err, string employee_id)
        {
            return db.MyExecuteNonQuery("SP_Delete_MonthSummary", ref err,
                new SqlParameter("@employee_id", employee_id));
        }
    }
}
