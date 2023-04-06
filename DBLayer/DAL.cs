using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DBLayer
{
    public class DAL
    {
        string ConnStr = "Data Source=(local);Initial Catalog=QLTiemQuanAo;Integrated Security=SSPI;";
        SqlConnection conn = null;
        SqlCommand  comm = null;
        SqlDataAdapter da = null;

        public DAL() 
        {
            conn = new SqlConnection(ConnStr);
            comm = conn.CreateCommand();
        }
        public void OpenDB()
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();
            conn.Open();
        }
        public void CloseDB()
        {
            conn.Close();
        }
        // Insert, Delete, Update
        public bool MyExecuteNonQuery(string strSQL, CommandType ct, ref string error, params SqlParameter[] param)
        {
            bool check = false;
            OpenDB();

            comm.Parameters.Clear();
            comm.CommandText = strSQL;
            comm.CommandType = ct;
            foreach (SqlParameter p in param)
                comm.Parameters.Add(p);

            try
            {
                comm.ExecuteNonQuery();
                check = true;
            }
            catch (SqlException ex)
            {
                error = ex.Message;
            }
            finally
            {
                CloseDB();
            }
            return check;
        }
        // Select
        public DataTable ExecuteQueryDataTable(string strSQL, CommandType ct, params SqlParameter[] param)
        {
            OpenDB();

            comm.CommandText = strSQL;
            comm.CommandType = ct;
            foreach (SqlParameter p in param)
                comm.Parameters.Add(p);

            da = new SqlDataAdapter(comm);
            DataTable dt = new DataTable();
            da.Fill(dt);

            CloseDB();
            return dt;
        }
    }
}
