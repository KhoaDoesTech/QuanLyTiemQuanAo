using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBLayer;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel.Design;

namespace BALayer
{
    public class DB_Customer
    {
        DAL db = null;
        public DB_Customer(string strConnect_local)
        {
            db = new DAL(strConnect_local);
        }
        public string GetDefaultCustomerID()
        {
            return (string)db.MyExecuteScalar("SELECT DBO.AutoIDCustomer()");
        }
        public DataTable GetCustomer()
        {
            return db.ExecuteQueryDataTable("select * from Customer");
        }
        public bool InsertCustomer(ref string err,
            string full_name, string gender, DateTime birthday, string phone,string email)

        {
            return db.MyExecuteNonQuery("SP_Insert_Customer",
                ref err,
                new SqlParameter("@full_name", full_name),
                new SqlParameter("@gender", gender),
                new SqlParameter("@birthday", birthday),
                new SqlParameter("@phone", phone),
                new SqlParameter("@email", email));
        }
        public DataTable FindCustomerByID(string customer_id)
        {
            return db.ExecuteNonQueryDataTable("SELECT * FROM DBO.FindCustomerByID(@customer_id)",
                 new SqlParameter("@customer_id", customer_id));
        }
        public DataTable FindCustomerByName(string full_name)
        {
            return db.ExecuteNonQueryDataTable("SELECT * FROM DBO.FindCustomerByName(@full_name)",
                 new SqlParameter("@full_name", full_name));
        }
        public DataTable FindCustomerByPhone(string phone)
        {
            return db.ExecuteNonQueryDataTable("SELECT * FROM DBO.FindCustomerByPhone(@phone)",
                 new SqlParameter("@phone", phone));
        }
        public bool UpdateCustomer(ref string err, string customer_id, string customer_type_id,
            string full_name, string gender, DateTime birthday, string phone,
            string email)
        {
            return db.MyExecuteNonQuery("SP_Update_Customer",
                ref err,
                new SqlParameter("@customer_id", customer_id),
                new SqlParameter("@full_name", full_name),
                new SqlParameter("@gender", gender),
                new SqlParameter("@birthday", birthday),
                new SqlParameter("@phone", phone),
                new SqlParameter("@email", email));
        }
    }
}
