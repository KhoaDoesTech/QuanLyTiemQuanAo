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
    public partial class frmEmployee : DevExpress.XtraEditors.XtraForm
    {
        DB_Employee dbe;
        DataTable dtEmployee = null;

        DB_Job dbj;
        DataTable dtJob = null;

        // Khai báo biến kiểm tra việc Thêm hay Sửa dữ liệu 
        bool Add;
        public frmEmployee()
        {
            InitializeComponent();
            dbe = new DB_Employee();
            dbj = new DB_Job();
        }

        void LoadData()
        {
            try
            {
                // Vận chuyển dữ liệu vào DataTable dtProductType 
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

                // Vận chuyển dữ liệu vào DataTable dtProduct
                dtEmployee = new DataTable();
                dtEmployee.Clear();
                dtEmployee = dbe.GetEmployee();
                // Đưa dữ liệu lên DataGridView 
                dgvEmployee.DataSource = dtEmployee;

                // Xóa trống các đối tượng trong Panel 
                this.txt_employee_id.ResetText();
                this.txt_full_name.ResetText();
                this.txt_gender.ResetText();
                this.dtp_birthday.ResetText();
                this.txt_phone.ResetText();
                this.txt_employee_address.ResetText();
                this.txt_email.ResetText();
                this.ckb_work_status.Checked = true;
                // Không cho thao tác trên các nút Lưu / Hủy
                this.btnLuu.Enabled = false;
                this.btnHuy.Enabled = false;
                // Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát 
                this.btnThem.Enabled = true;
                this.btnSua.Enabled = true;
                this.btnXoa.Enabled = true;
                this.btnThoat.Enabled = true;
                //
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
            btnLuu.Visible = true;
            btnHuy.Visible = true;
            btnThoat.Visible = true;
            panel.Enabled = false;
        }

        private void XoaTrong()
        {
            txt_employee_id.ResetText();
            txt_full_name.ResetText();
            txt_gender.ResetText();
            dtp_birthday.ResetText();
            txt_phone.ResetText();
            txt_employee_address.ResetText();
            txt_email.ResetText();
            txtSearch.ResetText();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

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
            this.txt_employee_id.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kích hoạt biến Sửa 
            Add = false;
            dgvEmployee_CellClick(null, null);
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
            this.txt_employee_id.Focus();
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
            if (Add)
            {
                string err = "";
                try
                {
                    f = dbe.InsertEmployee(ref err, txt_employee_id.Text, txt_employee_id.Text,
                        txt_full_name.Text, txt_gender.Text,
                        DateTime.Parse(dtp_birthday.Text), txt_phone.Text,
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
            if (!Add)
            {
                string err = "";
                try
                {
                    f = dbe.UpdateEmployee(ref err, txt_employee_id.Text, txt_employee_id.Text,
                        txt_full_name.Text, txt_gender.Text,
                        DateTime.Parse(dtp_birthday.Text), txt_phone.Text,
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
        private void dgvEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Thứ tự dòng hiện hành 
            int r = dgvEmployee.CurrentCell.RowIndex;
            // Chuyển thông tin lên panel 
            this.txt_employee_id.Text =
            dgvEmployee.Rows[r].Cells[0].Value.ToString();
            this.cb_job_id.Text =
            dgvEmployee.Rows[r].Cells[1].Value.ToString();
            this.txt_full_name.Text =
            dgvEmployee.Rows[r].Cells[2].Value.ToString();
            this.txt_gender.Text =
            dgvEmployee.Rows[r].Cells[3].Value.ToString();
            this.dtp_birthday.Text =
            dgvEmployee.Rows[r].Cells[4].Value.ToString();
            this.txt_phone.Text =
            dgvEmployee.Rows[r].Cells[5].Value.ToString();
            this.txt_employee_address.Text =
            dgvEmployee.Rows[r].Cells[6].Value.ToString();
            this.txt_email.Text =
            dgvEmployee.Rows[r].Cells[7].Value.ToString();
            this.ckb_work_status.Checked = Boolean.Parse(
            dgvEmployee.Rows[r].Cells[8].Value.ToString());
        }
    }
}