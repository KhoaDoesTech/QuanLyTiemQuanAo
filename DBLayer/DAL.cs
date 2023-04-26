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
        string ConnStr;
        SqlConnection conn = null;
        SqlCommand  comm = null;
        SqlDataAdapter da = null;
        
        public DAL(string ConnString) 
        {
            ConnStr = ConnString;            
        }
        public void OpenDB()
        {
            conn = new SqlConnection(ConnStr);
            comm = conn.CreateCommand();
            if (conn.State == ConnectionState.Open)
                conn.Close();
            conn.Open();
        }
        public void CloseDB()
        {
            if (da != null)
            {
                da.Dispose();
                da = null;
            }

            if (comm != null)
            {
                comm.Dispose();
                comm = null;
            }

            if (conn != null)
            {
                conn.Close();
                conn.Dispose(); 
                conn = null;
            }
        }

        // Insert, Delete, Update
        public bool MyExecuteNonQuery(string strSQL, ref string error, params SqlParameter[] param)
        {
            bool check = false;
            OpenDB();

            comm.Parameters.Clear();
            comm.CommandText = strSQL;
            comm.CommandType = CommandType.StoredProcedure;
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

        public bool MyExecuteQuery(string strSQL, ref string error)
        {
            bool check = false;
            OpenDB();

            comm.Parameters.Clear();
            comm.CommandText = strSQL;
            comm.CommandType = CommandType.Text;

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
        public DataTable ExecuteQueryDataTable(string strSQL)
        {
            OpenDB();
            
            comm.CommandText = strSQL;
            comm.CommandType = CommandType.Text;
            
            da = new SqlDataAdapter(comm);
            DataTable dt = new DataTable();
            da.Fill(dt);

            CloseDB();
            return dt;
        }

        public DataTable ExecuteNonQueryDataTable(string strSQL, params SqlParameter[] param) 
        {
            OpenDB();

            comm.CommandText = strSQL;
            comm.CommandType = CommandType.Text;

            foreach (SqlParameter p in param)
                comm.Parameters.AddWithValue(p.ParameterName, p.Value);

            da = new SqlDataAdapter(comm);
            DataTable dt = new DataTable();
            da.Fill(dt);

            CloseDB();
            return dt;
        }

        public object MyExecuteScalar(string strSQL)
        {
            OpenDB();

            comm.CommandText = strSQL;
            comm.CommandType = CommandType.Text;

            object result = comm.ExecuteScalar();

            CloseDB();
            return result;
        }
    }
}
