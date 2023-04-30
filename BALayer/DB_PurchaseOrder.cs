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
    public class DB_PurchaseOrder
    {
        DAL db = null;
        public DB_PurchaseOrder(string strConnect_local)
        {
            db = new DAL(strConnect_local);
        }
        public string GetDefaultOrderID()
        {
            return (string)db.MyExecuteScalar("SELECT DBO.AutoIDPurchaseOrder()");
        }
        public bool UpdatePurchaseOrder(ref string err, string branch_id,
            string product_name, string employee_id, string event_id, DateTime order_date, int total_cost)
        {
            return db.MyExecuteNonQuery("SP_Update_OrderDetail",
                ref err,
                new SqlParameter("@branch_id", branch_id),
                new SqlParameter("@product_name", product_name),
                new SqlParameter("@employee_id", employee_id),
                new SqlParameter("@event_id", event_id),
                new SqlParameter("@order_date", order_date),
                new SqlParameter("@total_cost", total_cost));
        }
        public bool DeleteOrderDetail(ref string err, string product_name)
        {
            return db.MyExecuteNonQuery("SP_Delete_OrderDetail",
                ref err,
                new SqlParameter("@product_name", product_name));
        }
        public int GetTotalCost()
        {
            return (int)db.MyExecuteScalar("select dbo.GetTotalCost()");
        }
    }
}
