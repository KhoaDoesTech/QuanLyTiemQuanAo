using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QuanLyTiemQuanAo
{
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        string ConnStr = @"Data Source=(local); Initial Catalog=QLTiemQuanAo; Integrated Security=True";
        SqlConnection conn = null;
        SqlCommand comm = null;
        
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            try
            {
                comm.Parameters.Clear();
                comm.CommandText = "Select dbo.CheckLogin(@username, @passcode)";
                comm.Parameters.AddWithValue("@username", txtUser.Text.Trim());
                comm.Parameters.AddWithValue("@passcode", txtPass.Text.Trim());
                comm.CommandType = CommandType.Text;
                bool result = (bool)comm.ExecuteScalar();
                if (result == true) 
                {
                    SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                    builder.DataSource = @"(local)";
                    builder.InitialCatalog = @"QLTiemQuanAo";
                    builder.UserID = txtUser.Text.Trim();
                    builder.Password = txtPass.Text.Trim();

                    string connectionString = builder.ConnectionString;
                    
                    frmMain home = new frmMain(connectionString);
                    this.Hide();
                    home.Show();            
                }
                else
                {
                    MessageBox.Show("Dang nhap khong thanh cong.", "Ket qua", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUser.ResetText();
                    txtPass.ResetText();
                    txtUser.Focus();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Chắc không?", "Trả lời",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK)
            {
                conn.Close();
                Application.Exit();
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            try
            {
                // Khởi động connection
                conn = new SqlConnection(ConnStr);
                if (conn.State == ConnectionState.Open) conn.Close();
                conn.Open();
                comm = new SqlCommand();
                comm.Connection = conn;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}