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

namespace QuanLyTiemQuanAo
{
    public partial class frmBranch : DevExpress.XtraEditors.XtraForm
    {
        DB_Branch dbms;
        DataTable dtBranch = null;
        // Khai báo biến kiểm tra việc Thêm hay Sửa dữ liệu 
        bool Add;
        public frmBranch()
        {
            InitializeComponent();
            dbms = new DB_Branch();
        }
        void LoadData()
        {
            try
            {
                // Vận chuyển dữ liệu vào DataTable dtProduct
                dtBranch = new DataTable();
                dtBranch.Clear();
                dtBranch = dbms.GetMonthSummary();
                // Đưa dữ liệu lên DataGridView 
                dgvBranch.DataSource = dtBranch;

                // Xóa trống các đối tượng trong Panel 
                this.txt_branch_id.ResetText();
                this.txt_branch_name.ResetText();
                this.txt_max_stock.ResetText();
                this.txt_rent_amount.ResetText();
                // Không cho thao tác trên các nút Lưu / Hủy
                this.btnLuu.Enabled = false;
                this.btnHuy.Enabled = false;
                this.panel.Enabled = false;
                // Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát 
                this.btnThem.Enabled = true;
                this.btnSua.Enabled = true;
                this.btnXoa.Enabled = true;
                this.btnThoat.Enabled = true;
                //
                dgvBranch_CellClick(null, null);

            }
            catch (SqlException e)
            {
                MessageBox.Show("Không lấy được nội dung trong table Branch. Lỗi rồi!!!" + e.Message);
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
            btnLuu.Visible = true;
            btnHuy.Visible = true;
            btnThoat.Visible = true;
            panel.Enabled = false;
        }

        private void XoaTrong()
        {
            txt_branch_id.ResetText();
            txt_branch_name.ResetText();
            txt_max_stock.ResetText();
            txt_rent_amount.ResetText();
            txtSearch.ResetText();
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            //Kích hoạt biến thêm
            Add = true;
            //Xóa trống các đối tượng
            XoaTrong();
            // Cho thao tác trên các nút Lưu / Hủy / Panel 
            this.btnLuu.Enabled = true;
            this.btnHuy.Enabled = true;
            this.panel.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát 
            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnThoat.Enabled = false;

            // Đưa con trỏ đến TextField txt_employee_id
            this.txt_branch_id.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kích hoạt biến Sửa 
            Add = false;
            dgvBranch_CellClick(null, null);
            // Cho thao tác trên các nút Lưu / Hủy / Panel
            this.btnLuu.Enabled = true;
            this.btnHuy.Enabled = true;
            this.panel.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát 
            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnThoat.Enabled = false;
            // Đưa con trỏ đến TextField txt_employee_id           
            this.txt_branch_id.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy thứ tự record hiện hành 
                int r = dgvBranch.CurrentCell.RowIndex;
                // Lấy employee_id của record hiện hành 
                string str_branch_id =
                dgvBranch.Rows[r].Cells[0].Value.ToString();
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
                    bool f = dbms.DeleteBranch(ref err, str_branch_id);
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
            if (Add)
            {
                string err = "";
                try
                {
                    f = dbms.InsertBranch(ref err, txt_branch_id.Text,
                        Convert.ToInt32(txt_branch_name.Text),
                        Convert.ToInt32(txt_max_stock.Text),
                        Convert.ToInt32(txt_rent_amount.Text));
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
            if (!Add)
            {
                string err = "";
                try
                {
                    f = dbms.UpdateBranch(ref err, txt_branch_id.Text,
                        Convert.ToInt32(txt_branch_name.Text),
                        Convert.ToInt32(txt_max_stock.Text),
                        Convert.ToInt32(txt_rent_amount.Text));
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
            // Xóa trống các đối tượng trong Panel 
            XoaTrong();
            // Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát 
            this.btnThem.Enabled = true;
            this.btnSua.Enabled = true;
            this.btnXoa.Enabled = true;
            this.btnThoat.Enabled = true;
            // Không cho thao tác trên các nút Lưu / Hủy / Panel
            this.btnLuu.Enabled = false;
            this.btnHuy.Enabled = false;
            this.panel.Enabled = false;
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

        private void dgvBranch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Thứ tự dòng hiện hành 
            int r = dgvBranch.CurrentCell.RowIndex;
            // Chuyển thông tin lên panel 
            this.txt_branch_id.Text =
            dgvBranch.Rows[r].Cells[0].Value.ToString();
            this.txt_branch_name.Text =
            dgvBranch.Rows[r].Cells[3].Value.ToString();
            this.txt_max_stock.Text =
            dgvBranch.Rows[r].Cells[4].Value.ToString();
            this.txt_rent_amount.Text =
            dgvBranch.Rows[r].Cells[5].Value.ToString();
        }
        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}