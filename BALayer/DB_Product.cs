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
    public class DB_Product
    {
        DAL db = null;
        public DB_Product (string strConnect_local)
        {
            db = new DAL (strConnect_local);
        }
        public DataTable GetProduct()
        {
            return db.ExecuteQueryDataTable("select * from Product");
        }
        public bool InsertProduct(ref string err, string product_type_id,
            string product_name, string size, string color, byte[] picture, int unit_price)
        {
            return db.MyExecuteNonQuery("SP_Insert_Product",
                ref err,
                new SqlParameter("@product_type_id", product_type_id),
                new SqlParameter("@product_name", product_name),
                new SqlParameter("@size", size),
                new SqlParameter("@color", color),
                new SqlParameter("@picture", picture),
                new SqlParameter("@unit_price", unit_price));
        }
        public DataTable FindProductByID(string product_id)
        {
            return db.ExecuteNonQueryDataTable("SELECT * FROM DBO.FindProductByID(@product_id)", 
                new SqlParameter("@product_id", product_id));
        }
        public DataTable FindCustomerByName(string full_name)
        {
            return db.ExecuteNonQueryDataTable("SELECT * FROM DBO.FindProductByID(@product_name)",
                 new SqlParameter("@product_name", full_name));
        }
        public bool UpdateProduct(ref string err, string product_id, string product_type_id,
            string product_name, string size, string color, byte[] picture, int unit_price)
        {
            return db.MyExecuteNonQuery("SP_Update_Product",
                ref err,
                new SqlParameter("@product_id", product_id),
                new SqlParameter("@product_type_id", product_type_id),
                new SqlParameter("@product_name", product_name),
                new SqlParameter("@size", size),
                new SqlParameter("@color", color),
                new SqlParameter("@picture", picture),
                new SqlParameter("@unit_price", unit_price));
        }
    }
}
