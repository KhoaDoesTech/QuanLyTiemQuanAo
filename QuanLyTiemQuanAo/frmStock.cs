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
    public partial class frmStock : DevExpress.XtraEditors.XtraForm, IConnectionForm
    {
        DB_Stock dbs;
        DataTable dtStock = null;

        DB_Branch dbb;
        DataTable dtBranch = null;

        DB_Product dbp;
        DataTable dtProduct = null;
        string ConnStr;
        public void SetConnection(string connectString)
        {
            ConnStr = connectString;
            dbs = new DB_Stock(ConnStr);
            dbb = new DB_Branch(ConnStr);
            dbp = new DB_Product(ConnStr);
        }
        // Khai báo biến kiểm tra việc Thêm hay Sửa dữ liệu 
        bool Them;
        public frmStock()
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
                // Đưa dữ liệu lên ComboBox trong DataGridView
                (dgvStock.Columns["branch_id"] as
                DataGridViewComboBoxColumn).DataSource = dtBranch;
                (dgvStock.Columns["branch_id"] as
                DataGridViewComboBoxColumn).DisplayMember =
                "branch_name";
                (dgvStock.Columns["branch_id"] as
                DataGridViewComboBoxColumn).ValueMember =
                "branch_id";

                // Vận chuyển dữ liệu vào DataTable dtProduct 
                dtProduct = new DataTable();
                dtProduct.Clear();
                dtProduct = dbp.GetProduct();
                // Đưa dữ liệu lên ComboBox trong DataGridView
                (dgvStock.Columns["product_id"] as
                DataGridViewComboBoxColumn).DataSource = dtProduct;
                (dgvStock.Columns["product_id"] as
                DataGridViewComboBoxColumn).DisplayMember =
                "product_name";
                (dgvStock.Columns["product_id"] as
                DataGridViewComboBoxColumn).ValueMember =
                "product_id";

                // Vận chuyển dữ liệu vào DataTable dtEmployee
                dtStock = new DataTable();
                dtStock.Clear();
                dtStock = dbs.GetStock();

                MoHienThi();

                // Đưa dữ liệu lên DataGridView 
                dgvStock.DataSource = dtStock;
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
            dgvStock.Enabled = true;
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
                switch (x)
                {
                    case 0:
                        dt = dbs.FindProductByBranch(txtSearch.Text);
                        dgvStock.DataSource = dt;
                        break;
                    case 1:
                        dt = dbs.FindProductByID(txtSearch.Text);
                        dgvStock.DataSource = dt;
                        break;
                }
            }
        }

        private void frmStock_Load(object sender, EventArgs e)
        {
            // Nội dung tìm
            cbSearch.Items.Add("Chi nhánh nhập");
            cbSearch.Items.Add("Sản phẩm");
            cbSearch.Text = cbSearch.Items[0].ToString();

            LoadData();
        }

        private void dgvStock_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}