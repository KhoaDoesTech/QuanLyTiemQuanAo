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
        public DB_MonthSummary(string strConnect_local)
        {
            db = new DAL(strConnect_local);
        }

        public DataTable GetMonthSummary()
        {
            return db.ExecuteQueryDataTable("select * from MonthSummary");
        }

        public bool InsertMonthSummary(ref string err,
            int summary_month, int summary_year)
        {
            return db.MyExecuteNonQuery("SP_Insert_MonthSummary",
                ref err,
                new SqlParameter("@summary_month", summary_month),
                new SqlParameter("@summary_year", summary_year));
        }
        public DataTable FindMonthSummaryByID(string employee_id)
        {
            return db.ExecuteNonQueryDataTable("SELECT * FROM DBO.FindMonthSummaryByID(@employee_id)",
                 new SqlParameter("@employee_id", employee_id));
        }
        public DataTable FindMonthSummaryByMonth(int summary_month)
        {
            return db.ExecuteNonQueryDataTable("SELECT * FROM DBO.FindMonthSummaryByMonth(@summary_month)",
                 new SqlParameter("@summary_month", summary_month));
        }
        public DataTable FindMonthSummaryByYear(int summary_year)
        {
            return db.ExecuteNonQueryDataTable("SELECT * FROM DBO.FindMonthSummaryByYear(@summary_year)",
                 new SqlParameter("@summary_year", summary_year));
        }
        public bool UpdateMonthSummary(ref string err,
            string employee_id, int summary_month, int summary_year,
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
    }
}
