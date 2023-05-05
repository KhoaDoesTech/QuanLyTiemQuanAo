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
    public partial class frmJob : DevExpress.XtraEditors.XtraForm, IConnectionForm
    {
        string ConnStr;
        DB_Job dbj;
        DataTable dtJob = null;

        DB_JobTitle dbjt;
        DataTable dtJobTitle = null;

        // Khai báo biến kiểm tra việc Thêm hay Sửa dữ liệu 
        bool Them;
        public void SetConnection(string connectString)
        {
            ConnStr = connectString;
            dbj = new DB_Job(ConnStr);
            dbjt = new DB_JobTitle(ConnStr);
        }

        public frmJob()
        {
            InitializeComponent();
        }
        void LoadData()
        {
            try
            {
                // Vận chuyển dữ liệu vào DataTable dtJobTitle 
                dtJobTitle = new DataTable();
                dtJobTitle.Clear();
                dtJobTitle = dbjt.GetJobTitle();
                // Đưa dữ liệu lên ComboBox trong DataGridView
                (dgvJob.Columns["job_title_id"] as
                DataGridViewComboBoxColumn).DataSource = dtJobTitle;
                (dgvJob.Columns["job_title_id"] as
                DataGridViewComboBoxColumn).DisplayMember = "job_title_name";
                (dgvJob.Columns["job_title_id"] as
                DataGridViewComboBoxColumn).ValueMember = "job_title_id";

                // Vận chuyển dữ liệu vào DataTable dtJob
                dtJob = new DataTable();
                dtJob.Clear();
                dtJob = dbj.GetJob();

                MoHienThi();
                KhoaTuongTac();

                // Đưa dữ liệu lên DataGridView 
                dgvJob.DataSource = dtJob;

                dgvJob_CellClick(null, null);

            }
            catch (SqlException e)
            {
                MessageBox.Show("Không lấy được nội dung trong table Job. Lỗi rồi!!!" + e.Message);
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
            dgvJob.Enabled = true;
        }

        private void XoaTrong()
        {
            txt_job_id.ResetText();
            txt_job_title_id.ResetText();
            txt_branch_id.ResetText();
            txt_job_name.ResetText();
            txt_base_salary.ResetText();
            txtSearch.ResetText();
        }
        private void MoTuongTac()
        {
            txt_branch_id.Enabled = false;
            txt_job_title_id.Enabled = true;
            txt_branch_id.Enabled = true;
            txt_job_name.Enabled = true;
            txt_base_salary.Enabled = true;
        }
        private void KhoaTuongTac()
        {
            txt_job_id.Enabled = false;
            txt_job_title_id.Enabled = false;
            txt_branch_id.Enabled = false;
            txt_job_name.Enabled = false;
            txt_base_salary.Enabled = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            KhoaHienThi();
            XoaTrong();
            MoTuongTac();
            dgvJob.Enabled = false;
            txt_job_id.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kích hoạt biến Sửa 
            Them = false;
            MoTuongTac();
            dgvJob_CellClick(null, null);
            KhoaHienThi();
            txt_job_id.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            bool f = false;
            if (Them)
            {
                string err = "";
                try
                {
                    f = dbj.InsertJob(ref err, txt_job_title_id.Text,
                        txt_branch_id.Text,
                        txt_job_name.Text,
                        Convert.ToInt32(txt_base_salary.Text));
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
                    f = dbj.UpdateJob(ref err, txt_job_id.Text,
                        txt_job_title_id.Text,
                        txt_branch_id.Text,
                        txt_job_name.Text,
                        Convert.ToInt32(txt_base_salary.Text));
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
            dgvJob_CellClick(null, null);
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

        private void dgvJob_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Thứ tự dòng hiện hành 
            int r = dgvJob.CurrentCell.RowIndex;
            // Chuyển thông tin lên panel 
            txt_job_id.Text =
            dgvJob.Rows[r].Cells[0].Value.ToString();
            txt_job_title_id.Text =
            dgvJob.Rows[r].Cells[1].Value.ToString();
            txt_branch_id.Text =
            dgvJob.Rows[r].Cells[2].Value.ToString();
            txt_job_name.Text =
            dgvJob.Rows[r].Cells[3].Value.ToString();
            txt_base_salary.Text =
            dgvJob.Rows[r].Cells[4].Value.ToString();
        }
        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmJob_Load(object sender, EventArgs e)
        {
            //Nội dung tìm công việc
            cbSearch.Items.Add("Mã công việc");
            cbSearch.Items.Add("Tên công việc");
            cbSearch.Text = cbSearch.Items[0].ToString();
            LoadData();
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
                        dt = dbj.FindJobByID(txtSearch.Text);
                        dgvJob.DataSource = dt;
                        break;
                    case 1:
                        dt = dbj.FindJobByName(txtSearch.Text);
                        dgvJob.DataSource = dt;
                        break;
                }
            }
        }
    }
}