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
    public class DB_ProductType
    {
        DAL db = null;

        public DB_ProductType(string strConnect_local) 
        {
            db = new DAL(strConnect_local);
        }
        public DataTable GetProductType()
        {
            return db.ExecuteQueryDataTable("SELECT * FROM ProductType");
        }
        public DataTable FindProductTypeByID(string product_type_id)
        {
            return db.ExecuteNonQueryDataTable("SELECT * FROM DBO.FindProductTypeByID(@product_type_id)",
                new SqlParameter("@product_type_id", product_type_id));
        }
        public DataTable FindProductTypeByName(string product_type_name)
        {
            return db.ExecuteNonQueryDataTable("SELECT * FROM DBO.FindProductTypeByName(@product_type_name)",
                new SqlParameter("@product_type_name", product_type_name));
        }
        public DataTable FindProductTypeByClass(string product_class)
        {
            return db.ExecuteNonQueryDataTable("SELECT * FROM DBO.FindProductTypeByClass(@class)",
                new SqlParameter("@class", product_class));
        }
        public DataTable FindProductTypeByGender(string gender)
        {
            return db.ExecuteNonQueryDataTable("SELECT * FROM DBO.FindProductTypeByGender(@gender)",
                new SqlParameter("@gender", gender));
        }

        public bool UpdateProductType(ref string err, string product_type_id,
             string product_type_name, string product_class, string gender)
        {
            return db.MyExecuteNonQuery("SP_Update_ProductType",
                ref err,
                new SqlParameter("@product_type_id", product_type_id),
                new SqlParameter("@product_type_name", product_type_name),
                new SqlParameter("@class", product_class),
                new SqlParameter("@gender", gender));
        }

        public bool InsertProductType(ref string err,
             string product_type_name, string product_class, string gender)
        {
            return db.MyExecuteNonQuery("SP_Insert_ProductType",
                ref err,
                new SqlParameter("@product_type_name", product_type_name),
                new SqlParameter("@class", product_class),
                new SqlParameter("@gender", gender));
        }
    }
}
