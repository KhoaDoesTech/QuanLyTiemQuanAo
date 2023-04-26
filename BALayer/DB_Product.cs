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
        public DataTable FindProductByName(string product_name)
        {
            return db.ExecuteNonQueryDataTable("SELECT * FROM DBO.FindProductByName(@product_name)",
                 new SqlParameter("@product_name", product_name));
        }

        public DataTable FindProductNameByName(string product_name)
        {
            return db.ExecuteNonQueryDataTable("SELECT * FROM DBO.FindProductNameByName(@product_name)",
                new SqlParameter("@product_name", product_name));
        }

        public DataTable FindProductNameByID(string product_id)
        {
            return db.ExecuteNonQueryDataTable("SELECT * FROM DBO.FindProductNameByID(@product_id)",
                new SqlParameter("@product_id", product_id));
        }
        public DataTable FindSizeByName(string product_name)
        {
            return db.ExecuteNonQueryDataTable("SELECT * FROM DBO.FindSizeByName(@product_name)",
                new SqlParameter("@product_name", product_name));
        }
        public DataTable FindColorByName(string product_name)
        {
            return db.ExecuteNonQueryDataTable("SELECT * FROM DBO.FindColorByName(@product_name)",
                new SqlParameter("@product_name", product_name));
        }

        public DataTable FindColorBySize(string size, string product_name)
        {
            return db.ExecuteNonQueryDataTable("SELECT * FROM DBO.FindColorBySize(@size, @product_name)",
                new SqlParameter("@size", size),
                new SqlParameter("@product_name", product_name));
        }

        public DataTable FindSizeByColor(string color, string product_name)
        {
            return db.ExecuteNonQueryDataTable("SELECT * FROM DBO.FindSizeByColor(@color, @product_name)",
                new SqlParameter("@color", color),
                new SqlParameter("@product_name", product_name));
        }

        public DataTable FindInfoProduct(string product_name, string size, string color, string branch_id)
        {
            return db.ExecuteNonQueryDataTable("SELECT * FROM DBO.FindInfoProduct(@product_name, @size, @color, @branch_id)",
                new SqlParameter("@product_name", product_name),
                new SqlParameter("@size", size),
                new SqlParameter("@color", color),
                new SqlParameter("@branch_id", branch_id));
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
