using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using BALayer;
using System.IO;

namespace QuanLyTiemQuanAo
{
    public partial class frmCustomer : DevExpress.XtraEditors.XtraForm, IConnectionForm
    {
        string ConnStr;
        DB_Customer dbc;
        DataTable dtCustomer = null;

        DB_CustomerType dbt;
        DataTable dtCustomerType = null;

        bool Them;

        public void SetConnection(string connectString)
        {
            ConnStr = connectString;
            dbc = new DB_Customer(ConnStr);
            dbt = new DB_CustomerType(ConnStr);
        }
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
                dtCustomerType = dbt.GetCustomerType();
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


                // Đưa dữ liệu lên DataGridView 
                dgvCustomer.DataSource = dtCustomer;
            }
            catch (SqlException e)
            {
                MessageBox.Show("Không lấy được nội dung trong table Customer. Lỗi rồi!!!" + e.Message);
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

        private void btn_Tim_Click(object sender, EventArgs e)
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
                       dt = dbc.FindCustomerByName(txtSearch.Text);
                       dgvCustomer.DataSource = dt;
                       break;
               }
            }
        }

        private void frmCustomer_Load(object sender, EventArgs e)
        {
            //Nội dung tìm khách hàng
            cbSearch.Items.Add("Mã khách hàng");
            cbSearch.Items.Add("Tên khách hàng");
            cbSearch.Text = cbSearch.Items[0].ToString();

            LoadData();
        }
    } 
}