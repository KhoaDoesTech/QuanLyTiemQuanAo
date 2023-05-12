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
        public DataTable GetPurchaseOrder()
        {
            return db.ExecuteQueryDataTable("SELECT * FROM PurchaseOrder");
        }
        public string GetDefaultOrderID()
        {
            return (string)db.MyExecuteScalar("SELECT DBO.AutoIDPurchaseOrder()");
        }
        public bool InsertPurchaseOrder(ref string err, string customer_id,
            string branch_id, string employee_id, string event_id, DateTime order_date, int total_cost)
        {
            return db.MyExecuteNonQuery("SP_Insert_PurchaseOrder",
                ref err,
                new SqlParameter("@customer_id", customer_id),
                new SqlParameter("@branch_id", branch_id),
                new SqlParameter("@employee_id", employee_id),
                new SqlParameter("@event_id", event_id),
                new SqlParameter("@order_date", order_date),
                new SqlParameter("@total_cost", total_cost));
        }

        public bool InsertOrderDetail(ref string err, string order_id,
            string product_id, int quantity)
        {
            return db.MyExecuteNonQuery("SP_Insert_OrderDetail",
                ref err,
                new SqlParameter("@order_id", order_id),
                new SqlParameter("@product_id", product_id),
                new SqlParameter("@quantity", quantity));
        }
        public DataTable GetOrderDetail(string order_id)
        {
            return db.ExecuteNonQueryDataTable("select * from dbo.GetOrderDetail(@order_id)",
                new SqlParameter("@order_id", order_id));
        }
        public DataTable FindOrderByID(string order_id)
        {
            return db.ExecuteNonQueryDataTable("SELECT * FROM DBO.FindOrderByID(@order_id)",
                 new SqlParameter("@order_id", order_id));
        }
        public DataTable FindOrderByCustomer(string customer_id)
        {
            return db.ExecuteNonQueryDataTable("SELECT * FROM DBO.FindOrderByCustomer(@customer_id)",
                 new SqlParameter("@customer_id", customer_id));
        }
        public DataTable FindOrderByBranch(string branch_id)
        {
            return db.ExecuteNonQueryDataTable("SELECT * FROM DBO.FindOrderByBranch(@branch_id)",
                 new SqlParameter("@branch_id", branch_id));
        }
        public DataTable FindOrderByEmployee(string employee_id)
        {
            return db.ExecuteNonQueryDataTable("SELECT * FROM DBO.FindOrderByEmployee(@employee_id)",
                 new SqlParameter("@employee_id", employee_id));
        }
        public DataTable FindOrderByEvent(string event_id)
        {
            return db.ExecuteNonQueryDataTable("SELECT * FROM DBO.FindOrderByEvent(@event_id)",
                 new SqlParameter("@event_id", event_id));
        }
    }
}
