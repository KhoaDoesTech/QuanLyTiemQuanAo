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
    public partial class frmEmployee : DevExpress.XtraEditors.XtraForm, IConnectionForm
    {
        DB_Employee dbe;
        DataTable dtEmployee = null;

        DB_Job dbj;
        DataTable dtJob = null;
        string ConnStr;
        public void SetConnection(string connectString)
        {
            ConnStr = connectString;
            dbe = new DB_Employee(ConnStr);
            dbj = new DB_Job(ConnStr);
        }
        // Khai báo biến kiểm tra việc Thêm hay Sửa dữ liệu 
        bool Them;
        public frmEmployee()
        {
            InitializeComponent();
        }

        void LoadData()
        {
            try
            {
                // Vận chuyển dữ liệu vào DataTable dtJob 
                dtJob = new DataTable();
                dtJob.Clear();
                dtJob = dbj.GetJob();
                // Đưa dữ liệu lên ComboBox trong DataGridView
                (dgvEmployee.Columns["job_id"] as
                DataGridViewComboBoxColumn).DataSource = dtJob;
                (dgvEmployee.Columns["job_id"] as
                DataGridViewComboBoxColumn).DisplayMember =
                "job_name";
                (dgvEmployee.Columns["job_id"] as
                DataGridViewComboBoxColumn).ValueMember =
                "job_id";

                // Vận chuyển dữ liệu vào DataTable dtEmployee
                dtEmployee = new DataTable();
                dtEmployee.Clear();
                dtEmployee = dbe.GetEmployee();

                MoHienThi();
                KhoaTuongTac();

                // Đưa dữ liệu lên DataGridView 
                dgvEmployee.DataSource = dtEmployee;

                dgvEmployee_CellClick(null, null);

            }
            catch (SqlException e)
            {
                MessageBox.Show("Không lấy được nội dung trong table Employee. Lỗi rồi!!!" + e.Message);
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
            txt_employee_id.ResetText();
            txt_full_name.ResetText();
            cb_job_id.ResetText();
            txt_gender.ResetText();
            dtp_birthday.ResetText();
            txt_phone.ResetText();
            txt_employee_address.ResetText();
            txt_email.ResetText();
            ckb_work_status.ResetText();
            txtSearch.ResetText();
        }
        private void MoTuongTac()
        {
            txt_employee_id.Enabled = false;
            txt_full_name.Enabled = true;
            cb_job_id.Enabled = true;
            txt_gender.Enabled = true;
            dtp_birthday.Enabled = true;
            txt_phone.Enabled = true;
            txt_employee_address.Enabled = true;
            txt_email.Enabled = true;
            ckb_work_status.Enabled = true;
        }
        private void KhoaTuongTac()
        {
            txt_employee_id.Enabled = false;
            txt_full_name.Enabled = false;
            cb_job_id.Enabled = false;
            txt_gender.Enabled = false;
            dtp_birthday.Enabled = false;
            txt_phone.Enabled = false;
            txt_employee_address.Enabled = false;
            txt_email.Enabled = false;
            ckb_work_status.Enabled = false;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            KhoaHienThi();
            XoaTrong();
            MoTuongTac();
            txt_full_name.Focus();
            Them = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kích hoạt biến Sửa 
            Them = false;
            MoTuongTac();
            dgvEmployee_CellClick(null, null);
            KhoaHienThi();
            txt_full_name.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy thứ tự record hiện hành 
                int r = dgvEmployee.CurrentCell.RowIndex;
                // Lấy employee_id của record hiện hành 
                string str_employee_id =
                dgvEmployee.Rows[r].Cells[0].Value.ToString();
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
                    bool f = dbe.DeleteEmployee(ref err, str_employee_id);
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
                    f = dbe.InsertEmployee(ref err, cb_job_id.SelectedValue.ToString(),
                        txt_full_name.Text, txt_gender.Text,
                        DateTime.Parse(dtp_birthday.Text.ToString()), txt_phone.Text,
                        txt_employee_address.Text, txt_email.Text, ckb_work_status.Checked);
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
                    f = dbe.UpdateEmployee(ref err, txt_employee_id.Text, cb_job_id.SelectedValue.ToString(),
                        txt_full_name.Text, txt_gender.Text,
                        DateTime.Parse(dtp_birthday.Text.ToString()), txt_phone.Text,
                        txt_employee_address.Text, txt_email.Text, ckb_work_status.Checked);
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
            dgvEmployee_CellClick(null, null);
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
        private void dgvEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Đưa dữ liệu lên ComboBox
            cb_job_id.DataSource = dtJob;
            cb_job_id.DisplayMember = "job_name";
            cb_job_id.ValueMember = "job_id";
            // Thứ tự dòng hiện hành 
            int r = dgvEmployee.CurrentCell.RowIndex;
            // Chuyển thông tin lên panel 
            txt_employee_id.Text =
            dgvEmployee.Rows[r].Cells[0].Value.ToString();
            cb_job_id.SelectedValue =
            dgvEmployee.Rows[r].Cells[1].Value.ToString();
            txt_full_name.Text =
            dgvEmployee.Rows[r].Cells[2].Value.ToString();
            txt_gender.Text =
            dgvEmployee.Rows[r].Cells[3].Value.ToString();
            dtp_birthday.Text =
            dgvEmployee.Rows[r].Cells[4].Value.ToString();
            txt_phone.Text =
            dgvEmployee.Rows[r].Cells[5].Value.ToString();
            txt_employee_address.Text =
            dgvEmployee.Rows[r].Cells[6].Value.ToString();
            txt_email.Text =
            dgvEmployee.Rows[r].Cells[7].Value.ToString();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if(txtSearch.Text == "")
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
                        dt = dbe.FindEmployeeByID(txtSearch.Text);
                        dgvEmployee.DataSource = dt;
                        break;
                    case 1:
                        dt = dbe.FindEmployeeByName(txtSearch.Text);
                        dgvEmployee.DataSource = dt;
                        break;
                }
            }
        }

        private void frmEmployee_Load(object sender, EventArgs e)
        {
            // Nội dung tìm Nhân viên
            cbSearch.Items.Add("Mã nhân viên");
            cbSearch.Items.Add("Tên nhân viên");
            cbSearch.Text = cbSearch.Items[0].ToString();

            LoadData();
        }

        private void dgvEmployee_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            // Đưa dữ liệu lên ComboBox
            cb_job_id.DataSource = dtJob;
            cb_job_id.DisplayMember = "job_name";
            cb_job_id.ValueMember = "job_id";
            // Thứ tự dòng hiện hành 
            int r = dgvEmployee.CurrentCell.RowIndex;
            // Chuyển thông tin lên panel 
            txt_employee_id.Text =
            dgvEmployee.Rows[r].Cells[0].Value.ToString();
            cb_job_id.SelectedValue =
            dgvEmployee.Rows[r].Cells[1].Value.ToString();
            txt_full_name.Text =
            dgvEmployee.Rows[r].Cells[2].Value.ToString();
            txt_gender.Text =
            dgvEmployee.Rows[r].Cells[3].Value.ToString();
            dtp_birthday.Text =
            dgvEmployee.Rows[r].Cells[4].Value.ToString();
            txt_phone.Text =
            dgvEmployee.Rows[r].Cells[5].Value.ToString();
            txt_employee_address.Text =
            dgvEmployee.Rows[r].Cells[6].Value.ToString();
            txt_email.Text =
            dgvEmployee.Rows[r].Cells[7].Value.ToString();
        }
    }
}