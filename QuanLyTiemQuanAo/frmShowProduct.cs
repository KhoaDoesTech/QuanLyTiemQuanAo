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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QuanLyTiemQuanAo
{
    public partial class frmShowProduct : DevExpress.XtraEditors.XtraForm, IConnectionForm
    {
        DB_Personal dbcn;
        DataTable dtPersonal = null;

        DB_Stock dbs;

        DB_Product dbp;
        DataTable dtProduct = null;
        string ConnStr;
        string username;
        string password;
        public void SetConnection(string connectString)
        {
            ConnStr = connectString;
            dbcn = new DB_Personal(ConnStr);
            dbp = new DB_Product(ConnStr);

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(ConnStr);
            username = builder.UserID;
            password = builder.Password;
        }
        // Khai báo biến kiểm tra việc Thêm hay Sửa dữ liệu 
        bool Them;
        public frmShowProduct()
        {
            InitializeComponent();
        }

        void LoadData()
        {
            try
            {
                // Vận chuyển dữ liệu vào DataTable dtProduct 
                dtProduct = new DataTable();
                dtProduct.Clear();
                dtProduct = dbp.GetProduct();
                // Đưa dữ liệu lên ComboBox trong DataGridView
                (dgvShowProduct.Columns["product_id"] as
                DataGridViewComboBoxColumn).DataSource = dtProduct;
                (dgvShowProduct.Columns["product_id"] as
                DataGridViewComboBoxColumn).DisplayMember =
                "product_name";
                (dgvShowProduct.Columns["product_id"] as
                DataGridViewComboBoxColumn).ValueMember =
                "product_id";

                dtPersonal = new DataTable();
                dtPersonal.Clear();
                dtPersonal = dbcn.GetPersonInformation(username, password);
                DataRow r = dtPersonal.Rows[0];

                // Vận chuyển dữ liệu vào DataTable dtEmployee
                dtProduct = new DataTable();
                dtProduct.Clear();
                dtProduct = dbp.ShowProduct(r[7].ToString());

                MoHienThi();

                // Đưa dữ liệu lên DataGridView 
                dgvShowProduct.DataSource = dtProduct;
            }
            catch (SqlException e)
            {
                MessageBox.Show("Không lấy được nội dung trong table Stock. Lỗi rồi!!!" + e.Message);
            }
        }
        private void KhoaHienThi()
        {
            btnThoat.Visible = false;
        }

        private void MoHienThi()
        {
            btnThoat.Visible = true;
            dgvShowProduct.Enabled = true;
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
                dt = dbs.FindProductByID(txtSearch.Text);
                dgvShowProduct.DataSource = dt;
            }
        }

        private void ShowProduct_Load(object sender, EventArgs e)
        {
            dtPersonal = new DataTable();
            dtPersonal.Clear();
            dtPersonal = dbcn.GetPersonInformation(username, password);
            DataRow r = dtPersonal.Rows[0];
            groupControl1.Text = "Chi nhánh: " + r[7].ToString();

            // Nội dung tìm
            cbSearch.Items.Add("Sản phẩm");
            cbSearch.Text = cbSearch.Items[0].ToString();

            LoadData();
        }
    }
}