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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace QuanLyTiemQuanAo
{
    public partial class frmStatisticsCustomer : DevExpress.XtraEditors.XtraForm, IConnectionForm
    {
        DB_Branch dbb;
        DataTable dtBranch = null;

        DB_StatisticsCustomer dbsc;
        DataTable dtStatisticsCustomers = null;

        DB_Customer dbc;
        DataTable dtCustomer = null;

        DB_CustomerType dbt;
        DataTable dtCustomerType = null;

        string ConnStr;

        public void SetConnection(string connectString)
        {
            ConnStr = connectString;
            dbb = new DB_Branch(ConnStr);
            dbsc = new DB_StatisticsCustomer(ConnStr);
            dbc = new DB_Customer(ConnStr);
            dbt = new DB_CustomerType(ConnStr);
        }
        public frmStatisticsCustomer()
        {
            InitializeComponent();
        }
        void LoadData()
        {
            try
            {

                // Vận chuyển dữ liệu vào DataTable dtBranch
                dtBranch = new DataTable();
                dtBranch.Clear();
                dtBranch = dbb.GetBranch();
                //Đưa dữ liệu lên ComboBox Chi nhánh
                cb_Branch.DataSource = dtBranch;
                cb_Branch.DisplayMember = "branch_name";
                cb_Branch.ValueMember = "branch_id";
                cb_Branch.Text = "Tất cả";

               /*
                dtStatisticsCustomer = new DataTable();
                dtStatisticsCustomer.Clear();
                dtStatisticsCustomer = dbsc.GetStatisticsCustomer();
                dgvStatisticsCustomer.DataSource = dtStatisticsCustomer;

                // Đưa dữ liệu lên ComboBox cb_StatisticsCustomer
                cb_StatisticsCustomer.DataSource = dtCustomer;
                cb_StatisticsCustomer.DisplayMember = "customer_type_name";
                cb_StatisticsCustomer.ValueMember = "customer_type_id";

                cb_StatisticsCustomer.DataSource = dtCustomer;
                cb_StatisticsCustomer.DisplayMember = "gender";

                // Vận chuyển dữ liệu vào DataTable dtCustomerType
                dtCustomerType = new DataTable();
                dtCustomerType.Clear();
                dtCustomerType = dbt.GetCustomerType();
                // Vận chuyển dữ liệu vào DataTable dtCustomer
                dtCustomer = new DataTable();
                dtCustomer.Clear();
                dtCustomer = dbc.GetCustomer();

                // Đưa dữ liệu lên DataGridView 
                dgvStatisticsCustomer.DataSource = dtCustomer;
               */
            }
            catch
            {
                MessageBox.Show("Không lấy được nội dung trong table Customer. Lỗi rồi!!!");
            }
        }

        private void frmStatisticsCustomer_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            // Khai báo biến traloi 
            DialogResult traloi;
            // Hiện hộp thoại hỏi đáp 
            traloi = MessageBox.Show("Chắc không?", "Trả lời",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            // Kiểm tra có nhắp chọn nút Ok không? 
            if (traloi == DialogResult.OK) this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

        }
    }
}
       
