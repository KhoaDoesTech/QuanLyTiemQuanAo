using BALayer;
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

namespace QuanLyTiemQuanAo
{
    public partial class frmCustomer : DevExpress.XtraEditors.XtraForm, IConnectionForm
    {
        DB_Personal dbcn;
        DataTable dtPersonal = null;

        DB_Branch dbb;
        DataTable dtBranch = null;

        DB_Customer dbc;
        DataTable dtCustomer = null;

        DB_CustomerType dbct;
        DataTable dtCustomerType = null;
        string ConnStr;
        string username;
        string password;
        public void SetConnection(string connectString)
        {
            ConnStr = connectString;
            dbcn = new DB_Personal(ConnStr);
            dbb = new DB_Branch(ConnStr);
            dbc = new DB_Customer(ConnStr);
            dbct = new DB_CustomerType(ConnStr);

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(ConnStr);
            username = builder.UserID;
            password = builder.Password;
        }
        // Khai báo biến kiểm tra việc Thêm hay Sửa dữ liệu 
        bool Them;
        public frmCustomer()
        {
            InitializeComponent();
        }

        void LoadData()
        {
            try
            {
                // Vận chuyển dữ liệu vào DataTable dtCustomerType
                dtCustomerType = new DataTable();
                dtCustomerType.Clear();
                dtCustomerType = dbct.GetCustomerType();
                // Đưa dữ liệu lên ComboBox trong DataGridView
                (dgvCustomer.Columns["customer_type_id"] as
                DataGridViewComboBoxColumn).DataSource = dtCustomerType;
                (dgvCustomer.Columns["customer_type_id"] as
                DataGridViewComboBoxColumn).DisplayMember =
                "customer_type_name";
                (dgvCustomer.Columns["customer_type_id"] as
                DataGridViewComboBoxColumn).ValueMember =
                "customer_type_id";

                // Vận chuyển dữ liệu vào DataTable dtCustomer
                dtCustomer = new DataTable();
                dtCustomer.Clear();
                dtCustomer = dbc.GetCustomer();

                MoHienThi();

                // Đưa dữ liệu lên DataGridView 
                dgvCustomer.DataSource = dtCustomer;
            }
            catch (SqlException e)
            {
                MessageBox.Show("Không lấy được nội dung trong table Customer. Lỗi rồi!!!" + e.Message);
            }
        }
        private void KhoaHienThi()
        {
            btnThoat.Visible = false;
        }

        private void MoHienThi()
        {
            btnThoat.Visible = true;
            dgvCustomer.Enabled = true;
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                LoadData();
            }
            else
            {
                DataTable dt = new DataTable();

                int x = cbSearch.SelectedIndex;
                switch (x)
                {
                    case 0:
                        dt = dbc.FindCustomerByID(txtSearch.Text);
                        dgvCustomer.DataSource = dt;
                        break;
                    case 1:
                        dt = dbc.FindCustomerByPhone(txtSearch.Text);
                        dgvCustomer.DataSource = dt;
                        break;
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            // Khai báo biến answer 
            DialogResult answer;
            // Hiện hộp thoại hỏi đáp 
            answer = MessageBox.Show("Chắc không?", "Trả lời",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            // Kiểm tra có nhấp chọn nút Ok không? 
            if (answer == DialogResult.OK) this.Close();
        }

        private void frmCustomer_Load(object sender, EventArgs e)
        {
            // Nội dung tìm
            cbSearch.Items.Add("Mã khách hàng");
            cbSearch.Items.Add("Số điện thoại");
            cbSearch.Text = cbSearch.Items[0].ToString();

            LoadData();
        }
    }
}