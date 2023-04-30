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
    public class DB_Discount
    {
        DAL db = null;
        public DB_Discount(string strConnect_local)
        {
            db = new DAL(strConnect_local);
        }

        public DataTable GetDiscount()
        {
            return db.ExecuteQueryDataTable("select * from Discount");
        }
        
        public DataTable GetCurrentDiscount(DateTime day)
        {
            return db.ExecuteNonQueryDataTable("select * from DBO.CurrentDiscount(@day)",
                new SqlParameter("@day", day));
        }

        public bool InsertDiscount(ref string err, float discount_percent,
            int discount_price)
        {
            return db.MyExecuteNonQuery("SP_Insert_Discount",
                ref err,
                new SqlParameter("@discount_percent", discount_percent),
                new SqlParameter("@discount_price", discount_price));
        }
        public DataTable FindDiscountByID(string event_id)
        {
            return db.ExecuteNonQueryDataTable("SELECT * FROM DBO.FindDiscountByID(@event_id)",
                 new SqlParameter("@event_id", event_id));
        }
        public DataTable FindDiscountByDiscountPercent(float discount_percent)
        {
            return db.ExecuteNonQueryDataTable("SELECT * FROM DBO.FindDiscountByDiscountPercent(@discount_percent)",
                 new SqlParameter("@discount_percent", discount_percent));
        }
        public DataTable FindDiscountByDiscountPrice(int discount_price)
        {
            return db.ExecuteNonQueryDataTable("SELECT * FROM DBO.FindDiscountByDiscountPrice(@discount_price)",
                 new SqlParameter("@discount_price", discount_price));
        }
        public bool UpdateDiscount(ref string err, float discount_percent,
            int discount_price)
        {
            return db.MyExecuteNonQuery("SP_Update_Discount",
                ref err,
                new SqlParameter("@discount_percent", discount_percent),
                new SqlParameter("@discount_price", discount_price));
        }
    }
}
