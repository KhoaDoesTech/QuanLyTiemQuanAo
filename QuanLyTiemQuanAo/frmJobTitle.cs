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
    public partial class frmJobTitle : DevExpress.XtraEditors.XtraForm, IConnectionForm
    {
        string ConnStr;
        DB_JobTitle dbjt;
        DataTable dtJobTitle = null;

        bool Them;

        public void SetConnection(string connectString)
        {
            ConnStr = connectString;
            dbjt = new DB_JobTitle(ConnStr);
        }

        public frmJobTitle()
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

                (dgvJobTitle.Columns["role_name"] as
                DataGridViewComboBoxColumn).Items.Add("Staff");
                (dgvJobTitle.Columns["role_name"] as
                DataGridViewComboBoxColumn).Items.Add("sysadmin");

                cb_role_name.Items.Add("Staff");
                cb_role_name.Items.Add("sysadmin");

                MoHienThi();
                KhoaTuongTac();

                // Đưa dữ liệu lên DataGridView 
                dgvJobTitle.DataSource = dtJobTitle;

                dgvJobTitle_CellClick(null, null);

            }
            catch (SqlException e)
            {
                MessageBox.Show("Không lấy được nội dung trong table JobTitle. Lỗi rồi!!!" + e.Message);
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
            dgvJobTitle.Enabled = true;
        }

        private void XoaTrong()
        {
            txt_job_title_name.ResetText();
            txt_job_description.ResetText();
            txtSearch.ResetText();
        }

        private void MoTuongTac()
        {
            txt_job_title_id.Enabled = false;
            txt_job_title_name.Enabled = true;
            txt_job_description.Enabled = true;
            cb_role_name.Enabled = true;
        }
        private void KhoaTuongTac()
        {
            txt_job_title_id.Enabled = false;
            txt_job_title_name.Enabled = false;
            txt_job_description.Enabled = false;
            cb_role_name.Enabled = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            KhoaHienThi();
            txt_job_title_id.Text = dbjt.GetDefaultJobTitleID();
            XoaTrong();
            MoTuongTac();
            dgvJobTitle.Enabled = false;
            txt_job_title_id.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kích hoạt biến Sửa 
            Them = false;
            MoTuongTac();
            dgvJobTitle_CellClick(null, null);
            KhoaHienThi();
            txt_job_title_id.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            bool f = false;
            if (Them)
            {
                string err = "";
                try
                {
                    f = dbjt.InsertJobTitle(ref err, txt_job_title_name.Text,
                        txt_job_description.Text, cb_role_name.SelectedValue.ToString());
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
                    f = dbjt.UpdateJobTitle(ref err, txt_job_title_id.Text,
                        txt_job_title_name.Text,
                        txt_job_description.Text, cb_role_name.SelectedValue.ToString());
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
            dgvJobTitle_CellClick(null, null);
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

        private void dgvJobTitle_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Thứ tự dòng hiện hành 
            int r = dgvJobTitle.CurrentCell.RowIndex;
            // Chuyển thông tin lên panel 
            txt_job_title_id.Text =
            dgvJobTitle.Rows[r].Cells[0].Value.ToString();
            txt_job_title_name.Text =
            dgvJobTitle.Rows[r].Cells[1].Value.ToString();
            txt_job_description.Text =
            dgvJobTitle.Rows[r].Cells[2].Value.ToString();
            cb_role_name.Text =
            dgvJobTitle.Rows[r].Cells[3].Value.ToString();
        }
        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmJobTitle_Load(object sender, EventArgs e)
        {
            //Nội dung tìm loại khách hàng
            cbSearch.Items.Add("Mã chức danh công việc");
            cbSearch.Items.Add("Tên chức danh công việc");
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
                        dt = dbjt.FindJobTitleByID(txtSearch.Text);
                        dgvJobTitle.DataSource = dt;
                        break;
                    case 1:
                        dt = dbjt.FindJobTitleByName(txtSearch.Text);
                        dgvJobTitle.DataSource = dt;
                        break;
                }
            }

        }
    }
}