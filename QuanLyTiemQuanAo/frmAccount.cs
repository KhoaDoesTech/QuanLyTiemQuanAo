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
    public partial class frmAccount : DevExpress.XtraEditors.XtraForm
    {
        DB_Account dba;
        DataTable dtAccount = null;

        DB_Employee dbe;
        DataTable dtEmployee = null;

        string ConnStr;
        public void SetConnection(string connectString)
        {
            ConnStr = connectString;
        }
        // Khai báo biến kiểm tra việc Thêm hay Sửa dữ liệu 
        bool Them;
        public frmAccount()
        {
            InitializeComponent();
            dba = new DB_Account(ConnStr);
            dbe = new DB_Employee(ConnStr);
        }

        void LoadData()
        {
            try
            {
                // Vận chuyển dữ liệu vào DataTable dtEmployee 
                dtEmployee = new DataTable();
                dtEmployee.Clear();
                dtEmployee = dbe.GetEmployee();
                // Đưa dữ liệu lên ComboBox trong DataGridView
                (dgvAccount.Columns["employee_id"] as
                DataGridViewComboBoxColumn).DataSource = dtEmployee;
                (dgvAccount.Columns["employee_id"] as
                DataGridViewComboBoxColumn).DisplayMember =
                "full_name";
                (dgvAccount.Columns["employee_id"] as
                DataGridViewComboBoxColumn).ValueMember =
                "employee_id";

                MoHienThi();
                KhoaTuongTac();

                dgvAccount_CellClick(null, null);

            }
            catch (SqlException e)
            {
                MessageBox.Show("Không lấy được nội dung trong table Account. Lỗi rồi!!!" + e.Message);
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

            btnLuu.Visible = false;
            btnHuy.Visible = false;
            btnThoat.Visible = true;
        }

        private void XoaTrong()
        {
            cb_employee_id.ResetText();
            txt_username.ResetText();
            txt_passcode.ResetText();
        }
        private void MoTuongTac()
        {
            cb_employee_id.Enabled = true;
            txt_username.Enabled = true;
            txt_passcode.Enabled = true;
        }
        private void KhoaTuongTac()
        {
            cb_employee_id.Enabled = false;
            txt_username.Enabled = false;
            txt_passcode.Enabled = false;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            KhoaHienThi();
            XoaTrong();
            MoTuongTac();
            cb_employee_id.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kích hoạt biến Sửa 
            Them = false;
            MoTuongTac();
            dgvAccount_CellClick(null, null);
            KhoaHienThi();
            cb_employee_id.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            bool f = false;
            if (Them)
            {
                string err = "";
                try
                {
                    f = dba.InsertAccount(ref err, txt_username.Text, txt_passcode.Text);
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
            else
            {
                string err = "";
                try
                {
                    f = dba.UpdateAccount(ref err, txt_username.Text, txt_passcode.Text);
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
            dgvAccount_CellClick(null, null);
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

        private void frmAccount_Load(object sender, EventArgs e)
        {
            // Nội dung tìm Nhân viên
            cbSearch.Items.Add("Mã nhân viên");
            cbSearch.Text = cbSearch.Items[0].ToString();

            LoadData();
        }

        private void dgvAccount_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Đưa dữ liệu lên ComboBox
            cb_employee_id.DataSource = dtEmployee;
            cb_employee_id.DisplayMember = "full_name";
            cb_employee_id.ValueMember = "employee_id";
            // Thứ tự dòng hiện hành 
            int r = dgvAccount.CurrentCell.RowIndex;
            // Chuyển thông tin lên panel 
            cb_employee_id.SelectedValue =
            dgvAccount.Rows[r].Cells[0].Value.ToString();
            txt_username.Text =
            dgvAccount.Rows[r].Cells[1].Value.ToString();
            txt_passcode.Text =
            dgvAccount.Rows[r].Cells[2].Value.ToString();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                LoadData();
            }
            else
            {
                DataTable dt = new DataTable();
                //choose type to search
                dgvAccount.DataSource = dt;

                int x = cbSearch.SelectedIndex;
                dt = dba.FindAccount(txtSearch.Text);
                dgvAccount.DataSource = dt;
            }
        }
    }
}