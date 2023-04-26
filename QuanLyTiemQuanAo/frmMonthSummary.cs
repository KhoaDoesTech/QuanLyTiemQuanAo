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
    public partial class frmMonthSummary : DevExpress.XtraEditors.XtraForm
    {
        DB_MonthSummary dbms;
        DataTable dtMonthSummary = null;
        // Khai báo biến kiểm tra việc Thêm hay Sửa dữ liệu 
        bool Them;

        string ConnStr;
        public void SetConnection(string connectString)
        {
            ConnStr = connectString;
        }

        public frmMonthSummary()
        {
            InitializeComponent();
            dbms = new DB_MonthSummary(ConnStr);
        }
        void LoadData()
        {
            try
            {
                // Vận chuyển dữ liệu vào DataTable dtProduct
                dtMonthSummary = new DataTable();
                dtMonthSummary.Clear();
                dtMonthSummary = dbms.GetMonthSummary();

                MoHienThi();
                KhoaTuongTac();

                // Đưa dữ liệu lên DataGridView 
                dgvMonthSummary.DataSource = dtMonthSummary;

                dgvMonthSummary_CellClick(null, null);

            }
            catch (SqlException e)
            {
                MessageBox.Show("Không lấy được nội dung trong table MonthSummary. Lỗi rồi!!!" + e.Message);
            }
        }

        private void KhoaHienThi()
        {
            btnThem.Visible = false;
            

            btnLuu.Visible = true;
            btnHuy.Visible = true;
            btnThoat.Visible = false;
        }

        private void MoHienThi()
        {
            btnThem.Visible = true;
            

            btnLuu.Visible = false;
            btnHuy.Visible = false;
            btnThoat.Visible = true;
        }

        private void XoaTrong()
        {
            txt_employee_id.ResetText();
            cb_summary_month.ResetText();
            cb_summary_year.ResetText();
            txt_products_sold.ResetText();
            txt_bonus_salary.ResetText();
            txt_salary.ResetText();
            txtSearch.ResetText();
        }
        private void MoTuongTac()
        {
            txt_employee_id.Enabled = false;
            cb_summary_month.Enabled = true;
            cb_summary_year.Enabled = true;
            txt_products_sold.Enabled = true;
            txt_bonus_salary.Enabled = true;
            txt_salary.Enabled = true;
        }
        private void KhoaTuongTac()
        {
            txt_employee_id.Enabled = false;
            cb_summary_month.Enabled = false;
            cb_summary_year.Enabled = false;
            txt_products_sold.Enabled = false;
            txt_bonus_salary.Enabled = false;
            txt_salary.Enabled = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            KhoaHienThi();
            XoaTrong();
            MoTuongTac();
            txt_employee_id.Focus();
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            bool f = false;
            if (Them)
            {
                string err = "";
                try
                {
                    f = dbms.InsertMonthSummary(ref err, cb_summary_month.SelectedIndex + 1,
                        cb_summary_year.SelectedIndex + 2003);
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
            /*if (!Them)
            {
                string err = "";
                try
                {
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
            }*/
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            MoHienThi();
            XoaTrong();
            KhoaTuongTac();
            dgvMonthSummary_CellClick(null, null);
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
        private void dgvMonthSummary_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Thứ tự dòng hiện hành 
            int r = dgvMonthSummary.CurrentCell.RowIndex;
            // Chuyển thông tin lên panel 
            txt_employee_id.Text =
            dgvMonthSummary.Rows[r].Cells[0].Value.ToString();
            cb_summary_month.SelectedValue =
            dgvMonthSummary.Rows[r].Cells[1].Value.ToString();
            cb_summary_year.Text =
            dgvMonthSummary.Rows[r].Cells[2].Value.ToString();
            txt_products_sold.Text =
            dgvMonthSummary.Rows[r].Cells[3].Value.ToString();
            txt_bonus_salary.Text =
            dgvMonthSummary.Rows[r].Cells[4].Value.ToString();
            txt_salary.Text =
            dgvMonthSummary.Rows[r].Cells[6].Value.ToString();
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            //choose type to search
            dgvMonthSummary.DataSource = dt;

            cbSearch.Items.Add("Mã nhân viên");
            cbSearch.Items.Add("Tháng");
            cbSearch.Items.Add("Năm");
            cbSearch.Text = cbSearch.Items[0].ToString();
            cbSearch.Text = cbSearch.Items[1].ToString();
            cbSearch.Text = cbSearch.Items[2].ToString();
            int x = cbSearch.SelectedIndex;
            switch (x)
            {
                case 1:
                    dt = dbms.FindMonthSummaryByID(txtSearch.Text);
                    dgvMonthSummary.DataSource = dt;
                    break;
                case 2:
                    dt = dbms.FindMonthSummaryByMonth(Convert.ToInt32(txtSearch.Text));
                    dgvMonthSummary.DataSource = dt;
                    break;
                case 3:
                    dt = dbms.FindMonthSummaryByYear(Convert.ToInt32(txtSearch.Text));
                    dgvMonthSummary.DataSource = dt;
                    break;
            }
        }

        private void frmMonthSummary_Load(object sender, EventArgs e)
        {

        }
    }
}