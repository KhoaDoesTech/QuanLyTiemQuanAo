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
using System.Security.Claims;

namespace QuanLyTiemQuanAo
{
    public partial class frmStatisticsProduct : DevExpress.XtraEditors.XtraForm, IConnectionForm
    {
        string ConnStr;
        DB_Branch dbb;
        DataTable dtBranch = null;

        DB_StatisticsProduct dbsp;
        DataTable dtStatisticsProduct = null;

        DB_Product dbp;
        DataTable dtProduct = null;

        DB_ProductType dbpt;
        DataTable dtProductType = null;

        DataView dtv = null;

        public void SetConnection(string connectString)
        {
            ConnStr = connectString;
            dbb = new DB_Branch(ConnStr);
            dbsp = new DB_StatisticsProduct(ConnStr);
            dbp = new DB_Product(ConnStr);
            dbpt = new DB_ProductType(ConnStr);
        }
        public frmStatisticsProduct()
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
                DataRow newRow = dtBranch.NewRow();
                newRow["branch_name"] = "Tất cả";
                newRow["branch_id"] = "Tất cả";
                dtBranch.Rows.InsertAt(newRow, 0);
                cb_branch.DataSource = dtBranch;
                cb_branch.DisplayMember = "branch_name";
                cb_branch.ValueMember = "branch_id";
                cb_branch.Text = "Tất cả";

                int month;
                for (month = 1; month <= 12; month++)
                {
                    cb_month.Items.Add(month);
                }

                int year;
                for (year = 2023; year <= 2025; year++)
                {
                    cb_year.Items.Add(year);
                }
                cb_year.Text = cb_year.Items[0].ToString();
                cb_month.Text = cb_month.Items[0].ToString();

                cbThuocTinh.Items.Add("Loại sản phẩm");
                cbThuocTinh.Items.Add("Kích thước");
                cbThuocTinh.Items.Add("Màu");
                cbThuocTinh.Text = cbThuocTinh.Items[0].ToString();

                dtStatisticsProduct = new DataTable();
                dtStatisticsProduct = dbsp.GetStatisticsProduct();

                // Đưa dữ liệu lên DataGridView 
                dgvProduct.DataSource = dtStatisticsProduct;
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong table Product. Lỗi rồi!!!");
            }
        }

        private void frmThongKeSanPham_Load(object sender, EventArgs e)
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
            // Kiểm tra có nhấp chọn nút Ok không? 
            if (traloi == DialogResult.OK) this.Close();
        }
    }
}