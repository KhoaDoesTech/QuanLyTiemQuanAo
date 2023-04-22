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
    public partial class frmBranch : DevExpress.XtraEditors.XtraForm, IConnectionForm
    {
        string ConnStr;
        DB_Branch dbms;
        DataTable dtBranch = null;
        // Khai báo biến kiểm tra việc Thêm hay Sửa dữ liệu 
        bool Add;
        public void SetConnection(string connectString)
        {
            ConnStr = connectString;
            dbms = new DB_Branch(ConnStr);
        }

        public frmBranch()
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
                dtBranch = dbms.GetBranch();


                // Xóa trống các đối tượng trong Panel 
                this.txt_branch_id.ResetText();
                this.txt_branch_name.ResetText();
                this.txt_max_stock.ResetText();
                this.txt_rent_amount.ResetText();


                MoHienThi();
                KhoaTuongTac();

                // Đưa dữ liệu lên DataGridView 
                dgvBranch.DataSource = dtBranch;
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
            btnLuu.Visible = true;
            btnHuy.Visible = true;
            btnThoat.Visible = false;
        }

        private void MoHienThi()
        {
            btnThem.Visible = true;
            btnSua.Visible = true;
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
        private void MoTuongTac()
        {
            txt_branch_id.Enabled = false;
            txt_branch_name.Enabled = true;
            txt_max_stock.Enabled = true;
            txt_rent_amount.Enabled = true;
        }
        private void KhoaTuongTac()
        {
            txt_branch_id.Enabled = false;
            txt_branch_name.Enabled = false;
            txt_max_stock.Enabled = false;
            txt_rent_amount.Enabled = false;
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            KhoaHienThi();
            XoaTrong();
            MoTuongTac();
            this.txt_branch_id.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kích hoạt biến Sửa 
            Add = false;
            MoTuongTac();
            dgvBranch_CellClick(null, null);
            KhoaHienThi();         
            this.txt_branch_id.Focus();
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
                        txt_branch_name.Text,
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
                        txt_branch_name.Text,
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
            MoHienThi();
            XoaTrong();
            KhoaTuongTac();
            dgvBranch_CellClick(null, null);
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
            dgvBranch.Rows[r].Cells[1].Value.ToString();
            this.txt_max_stock.Text =
            dgvBranch.Rows[r].Cells[2].Value.ToString();
            this.txt_rent_amount.Text =
            dgvBranch.Rows[r].Cells[3].Value.ToString();
        }
        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void frmBranch_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void btnTim_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = dbms.FindBranchByID(txtSearch.Text);
            dgvBranch.DataSource = dt;
        }


    }
}