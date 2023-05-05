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
    public class DB_CustomerType
    {
        DAL db = null;
        public DB_CustomerType(string strConnect_local)
        {
            db = new DAL(strConnect_local);
        }
        public string GetDefaultCustomerTypeID()
        {
            return (string)db.MyExecuteScalar("SELECT DBO.AutoIDCustomerType()");
        }
        public DataTable GetCustomerType()
        {
            return db.ExecuteQueryDataTable("select * from CustomerType");
        }
        public bool InsertCustomerType(ref string err, string customer_type_name, int units_purchased)

        {
            return db.MyExecuteNonQuery("SP_Insert_CustomerType",
                ref err,
                new SqlParameter("customer_type_name", customer_type_name),
                new SqlParameter("units_purchased", units_purchased));
        }
        public DataTable FindCustomerTypeByID(string customer_type_id)
        {
            return db.ExecuteNonQueryDataTable("SELECT * FROM DBO.FindCustomerByID(@customer_type_id)",
                 new SqlParameter("@customer_type_id", customer_type_id));
        }
        public DataTable FindCustomerTypeByName(string customer_type_name)
        {
            return db.ExecuteNonQueryDataTable("SELECT * FROM DBO.FindCustomerTypeByName(@customer_type_name)",
                 new SqlParameter("@customer_type_name", customer_type_name));
        }
        public bool UpdateCustomerType(ref string err, string customer_type_id, string customer_type_name, int units_purchased)

        {
            return db.MyExecuteNonQuery("SP_Update_CustomerType",
                ref err,
                new SqlParameter("@customer_type_id", customer_type_id),
                new SqlParameter("customer_type_name", customer_type_name),
                new SqlParameter("units_purchased", units_purchased));
        }
    }
}
