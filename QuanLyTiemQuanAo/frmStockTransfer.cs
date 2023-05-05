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
    public partial class frmStockTransfer : DevExpress.XtraEditors.XtraForm
    {
        DB_StockTransfer dbst;
        DataTable dtStockTransfer = null;

        DB_Branch dbb;
        DataTable dtBranch = null;

        DB_Product dbp;
        DataTable dtProduct = null;
        string ConnStr;
        public void SetConnection(string connectString)
        {
            ConnStr = connectString;
            dbst = new DB_StockTransfer(ConnStr);
            dbb = new DB_Branch(ConnStr);
            dbp = new DB_Product(ConnStr);
        }
        // Khai báo biến kiểm tra việc Thêm hay Sửa dữ liệu 
        bool Them;
        public frmStockTransfer()
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
                (dgvStockTransfer.Columns["from_branch_id"] as
                DataGridViewComboBoxColumn).DataSource = dtBranch;
                (dgvStockTransfer.Columns["from_branch_id"] as
                DataGridViewComboBoxColumn).DisplayMember =
                "branch_name";
                (dgvStockTransfer.Columns["from_branch_id"] as
                DataGridViewComboBoxColumn).ValueMember =
                "branch_id";

                // Vận chuyển dữ liệu vào DataTable dtBranch 
                dtBranch = new DataTable();
                dtBranch.Clear();
                dtBranch = dbb.GetBranch();
                // Đưa dữ liệu lên ComboBox trong DataGridView
                (dgvStockTransfer.Columns["to_branch_id"] as
                DataGridViewComboBoxColumn).DataSource = dtBranch;
                (dgvStockTransfer.Columns["to_branch_id"] as
                DataGridViewComboBoxColumn).DisplayMember =
                "branch_name";
                (dgvStockTransfer.Columns["to_branch_id"] as
                DataGridViewComboBoxColumn).ValueMember =
                "branch_id";

                // Vận chuyển dữ liệu vào DataTable dtProduct 
                dtProduct = new DataTable();
                dtProduct.Clear();
                dtProduct = dbp.GetProduct();
                // Đưa dữ liệu lên ComboBox trong DataGridView
                (dgvStockTransfer.Columns["product_id"] as
                DataGridViewComboBoxColumn).DataSource = dtProduct;
                (dgvStockTransfer.Columns["product_id"] as
                DataGridViewComboBoxColumn).DisplayMember =
                "product_name";
                (dgvStockTransfer.Columns["product_id"] as
                DataGridViewComboBoxColumn).ValueMember =
                "product_id";

                // Vận chuyển dữ liệu vào DataTable dtEmployee
                dtStockTransfer = new DataTable();
                dtStockTransfer.Clear();
                dtStockTransfer = dbst.GetStockTransfer();

                MoHienThi();
                KhoaTuongTac();

                // Đưa dữ liệu lên DataGridView 
                dgvStockTransfer.DataSource = dtStockTransfer;

                dgvStockTransfer_CellClick(null, null);

            }
            catch (SqlException e)
            {
                MessageBox.Show("Không lấy được nội dung trong table StockTransfer. Lỗi rồi!!!" + e.Message);
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
            dgvStockTransfer.Enabled = true;
        }

        private void XoaTrong()
        {
            cb_from_branch_id.ResetText();
            cb_to_branch_id.ResetText();
            cb_product_id.ResetText();
            dtp_transfer_date.ResetText();
            txt_quantity.ResetText();
        }
        private void MoTuongTac()
        {
            cb_from_branch_id.Enabled = false;
            cb_to_branch_id.Enabled = true;
            cb_product_id.Enabled = true;
            dtp_transfer_date.Enabled = true;
            txt_quantity.Enabled = true;
        }
        private void KhoaTuongTac()
        {
            cb_from_branch_id.Enabled = false;
            cb_to_branch_id.Enabled = false;
            cb_product_id.Enabled = false;
            dtp_transfer_date.Enabled = false;
            txt_quantity.Enabled = false;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            KhoaHienThi();
            XoaTrong();
            MoTuongTac();
            dgvStockTransfer.Enabled = false;
            cb_from_branch_id.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kích hoạt biến Sửa 
            Them = false;
            MoTuongTac();
            dgvStockTransfer_CellClick(null, null);
            KhoaHienThi();
            cb_from_branch_id.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy thứ tự record hiện hành 
                int r = dgvStockTransfer.CurrentCell.RowIndex;
                // Lấy employee_id của record hiện hành 
                string str_employee_id =
                dgvStockTransfer.Rows[r].Cells[0].Value.ToString();
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
                    bool f = dbst.DeleteStockTransfer(ref err, cb_from_branch_id.SelectedValue.ToString(),
                        cb_from_branch_id.SelectedValue.ToString(), cb_product_id.SelectedValue.ToString(),
                        DateTime.Parse(dtp_transfer_date.Text.ToString()));
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
                    f = dbst.InsertStockTransfer(ref err, cb_from_branch_id.SelectedValue.ToString(),
                        cb_to_branch_id.SelectedValue.ToString(), cb_product_id.SelectedValue.ToString(),
                        DateTime.Parse(dtp_transfer_date.Text.ToString()), Convert.ToInt32(txt_quantity.Text));
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
                    f = dbst.UpdateStockTransfer(ref err, cb_from_branch_id.SelectedValue.ToString(),
                        cb_to_branch_id.SelectedValue.ToString(), cb_product_id.SelectedValue.ToString(),
                        DateTime.Parse(dtp_transfer_date.Text.ToString()), Convert.ToInt32(txt_quantity.Text));
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
            dgvStockTransfer_CellClick(null, null);
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

        private void frmStockTransfer_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void dgvStockTransfer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Đưa dữ liệu lên ComboBox
            cb_from_branch_id.DataSource = dtBranch;
            cb_from_branch_id.DisplayMember = "branch_name";
            cb_from_branch_id.ValueMember = "branch_id";
            // Đưa dữ liệu lên ComboBox
            cb_to_branch_id.DataSource = dtBranch;
            cb_to_branch_id.DisplayMember = "branch_name";
            cb_to_branch_id.ValueMember = "branch_id";
            // Thứ tự dòng hiện hành 
            int r = dgvStockTransfer.CurrentCell.RowIndex;
            // Chuyển thông tin lên panel 
            cb_from_branch_id.SelectedValue =
            dgvStockTransfer.Rows[r].Cells[0].Value.ToString();
            cb_to_branch_id.SelectedValue =
            dgvStockTransfer.Rows[r].Cells[1].Value.ToString();
            cb_product_id.SelectedValue =
            dgvStockTransfer.Rows[r].Cells[2].Value.ToString();
            dtp_transfer_date.Text =
            dgvStockTransfer.Rows[r].Cells[3].Value.ToString();
            txt_quantity.Text =
            dgvStockTransfer.Rows[r].Cells[4].Value.ToString();
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
                        dt = dbst.FindProductByFromBranch(txtSearch.Text);
                        dgvStockTransfer.DataSource = dt;
                        break;
                    case 1:
                        dt = dbst.FindProductByToBranch(txtSearch.Text);
                        dgvStockTransfer.DataSource = dt;
                        break;
                    case 2:
                        dt = dbst.FindProductByID(txtSearch.Text);
                        dgvStockTransfer.DataSource = dt;
                        break;
                }
            }
        }
    }
}