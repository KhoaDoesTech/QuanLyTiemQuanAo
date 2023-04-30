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
    public partial class frmStockImport : DevExpress.XtraEditors.XtraForm, IConnectionForm
    {
        DB_StockImport dbsi;
        DataTable dtStockImport = null;

        DB_Branch dbb;
        DataTable dtBranch = null;

        DB_Product dbp;
        DataTable dtProduct = null;
        string ConnStr;
        public void SetConnection(string connectString)
        {
            ConnStr = connectString;
            dbsi = new DB_StockImport(ConnStr);
            dbb = new DB_Branch(ConnStr);
            dbp = new DB_Product(ConnStr);
        }
        // Khai báo biến kiểm tra việc Thêm hay Sửa dữ liệu 
        bool Them;
        public frmStockImport()
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
                (dgvStockImport.Columns["branch_id"] as
                DataGridViewComboBoxColumn).DataSource = dtBranch;
                (dgvStockImport.Columns["branch_id"] as
                DataGridViewComboBoxColumn).DisplayMember =
                "branch_name";
                (dgvStockImport.Columns["branch_id"] as
                DataGridViewComboBoxColumn).ValueMember =
                "branch_id";

                // Vận chuyển dữ liệu vào DataTable dtProduct 
                dtProduct = new DataTable();
                dtProduct.Clear();
                dtProduct = dbp.GetProduct();
                // Đưa dữ liệu lên ComboBox trong DataGridView
                (dgvStockImport.Columns["product_id"] as
                DataGridViewComboBoxColumn).DataSource = dtProduct;
                (dgvStockImport.Columns["product_id"] as
                DataGridViewComboBoxColumn).DisplayMember =
                "product_name";
                (dgvStockImport.Columns["product_id"] as
                DataGridViewComboBoxColumn).ValueMember =
                "product_id";

                // Vận chuyển dữ liệu vào DataTable dtEmployee
                dtStockImport = new DataTable();
                dtStockImport.Clear();
                dtStockImport = dbsi.GetStockImport();

                MoHienThi();
                KhoaTuongTac();

                // Đưa dữ liệu lên DataGridView 
                dgvStockImport.DataSource = dtStockImport;

                dgvStockImport_CellClick(null, null);

            }
            catch (SqlException e)
            {
                MessageBox.Show("Không lấy được nội dung trong table StockImport. Lỗi rồi!!!" + e.Message);
            }
        }
        private void KhoaHienThi()
        {
            btnThem.Visible = false;
            btnSua.Visible = false;
            btnXoa.Visible = false;
            btnLuu.Visible = true;
            btnHuy.Visible = true;
            btnThoat.Visible = false;
        }

        private void MoHienThi()
        {
            btnThem.Visible = true;
            btnSua.Visible = true;
            btnXoa.Visible = true;
            btnLuu.Visible = false;
            btnHuy.Visible = false;
            btnThoat.Visible = true;
        }

        private void XoaTrong()
        {
            cb_branch_id.ResetText();
            cb_product_id.ResetText();
            dtp_import_date.ResetText();
            txt_import_price.ResetText();
            txt_quantity.ResetText();
        }
        private void MoTuongTac()
        {
            cb_branch_id.Enabled = false;
            cb_product_id.Enabled = true;
            dtp_import_date.Enabled = true;
            txt_import_price.Enabled = true;
            txt_quantity.Enabled = true;
        }
        private void KhoaTuongTac()
        {
            cb_branch_id.Enabled = false;
            cb_product_id.Enabled = false;
            dtp_import_date.Enabled = false;
            txt_import_price.Enabled = false;
            txt_quantity.Enabled = false;
        }

        private void dgvStockImport_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Đưa dữ liệu lên ComboBox
            cb_branch_id.DataSource = dtBranch;
            cb_branch_id.DisplayMember = "branch_name";
            cb_branch_id.ValueMember = "branch_id";
            // Thứ tự dòng hiện hành 
            int r = dgvStockImport.CurrentCell.RowIndex;
            // Chuyển thông tin lên panel 
            cb_branch_id.SelectedValue =
            dgvStockImport.Rows[r].Cells[0].Value.ToString();
            cb_product_id.SelectedValue =
            dgvStockImport.Rows[r].Cells[1].Value.ToString();
            dtp_import_date.Text =
            dgvStockImport.Rows[r].Cells[2].Value.ToString();
            txt_import_price.Text =
            dgvStockImport.Rows[r].Cells[3].Value.ToString();
            txt_quantity.Text =
            dgvStockImport.Rows[r].Cells[4].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            KhoaHienThi();
            XoaTrong();
            MoTuongTac();
            cb_branch_id.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kích hoạt biến Sửa 
            Them = false;
            MoTuongTac();
            dgvStockImport_CellClick(null, null);
            KhoaHienThi();
            cb_branch_id.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy thứ tự record hiện hành 
                int r = dgvStockImport.CurrentCell.RowIndex;
                // Lấy employee_id của record hiện hành 
                string str_employee_id =
                dgvStockImport.Rows[r].Cells[0].Value.ToString();
                // Viết câu lệnh SQL 
                // Hiện thông báo xác nhận việc xóa mẫu tin 
                // Khai báo biến answer 
                DialogResult answer;
                // Hiện hộp thoại hỏi đáp 
                answer = MessageBox.Show("Chắc xóa mẫu tin này không?", "Trả lời",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                // Kiểm tra có nhấp chọn nút Ok không? 
                string err = "";
                if (answer == DialogResult.Yes)
                {

                    // Thực hiện câu lệnh SQL 
                    bool f = dbsi.DeleteStockImport(ref err, cb_branch_id.Text, cb_product_id.Text,
                        DateTime.Parse(dtp_import_date.Text.ToString()));
                    if (f)
                    {
                        // Cập nhật lại DataGridView 
                        LoadData();
                        // Thông báo 
                        MessageBox.Show("Đã xóa xong!");
                    }
                    else
                    {
                        MessageBox.Show("Không xóa được!\n\r" + "Lỗi:" + err);
                    }
                }
                else
                {
                    // Thông báo 
                    MessageBox.Show("Không thực hiện việc xóa mẫu tin!");
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Không xóa được. Lỗi rồi!!!");
            }
            // Đóng kết nối
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            bool f = false;
            if (Them)
            {
                string err = "";
                try
                {
                    f = dbsi.InsertStockImport(ref err, cb_branch_id.Text,
                        cb_product_id.Text, DateTime.Parse(dtp_import_date.Text.ToString()),
                        Convert.ToInt32(txt_import_price.Text), Convert.ToInt32(txt_quantity.Text));
                    if (f)
                    {
                        // Load lại dữ liệu trên DataGridView 
                        LoadData();
                        // Thông báo 
                        MessageBox.Show("Đã thêm xong!");
                    }
                    else
                    {
                        MessageBox.Show("Đã thêm chưa xong!\n\r" + "Lỗi:" + err);
                    }
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không thêm được. Lỗi rồi!");
                }
            }
            if (!Them)
            {
                string err = "";
                try
                {
                    f = dbsi.UpdateStockImport(ref err, cb_branch_id.Text,
                        cb_product_id.Text, DateTime.Parse(dtp_import_date.Text.ToString()),
                        Convert.ToInt32(txt_import_price.Text), Convert.ToInt32(txt_quantity.Text));
                    if (f)
                    {
                        // Load lại dữ liệu trên DataGridView 
                        LoadData();
                        // Thông báo 
                        MessageBox.Show("Đã cập nhật xong!");
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật chưa xong!\n\r" + "Lỗi:" + err);
                    }
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không cập nhật được. Lỗi rồi!");
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            MoHienThi();
            XoaTrong();
            KhoaTuongTac();
            dgvStockImport_CellClick(null, null);
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

        private void frmStockImport_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}