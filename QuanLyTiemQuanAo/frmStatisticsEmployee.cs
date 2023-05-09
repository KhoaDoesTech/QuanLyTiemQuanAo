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
using System.IO;
using System.Security.Claims;

namespace QuanLyTiemQuanAo
{
    public partial class frmStatisticsEmployee : DevExpress.XtraEditors.XtraForm, IConnectionForm
    {
        DB_Branch dbb;
        DataTable dtBranch = null;

        DB_StatisticsEmployee dbse;
        DataTable dtStatisticsEmployee = null;
        string ConnStr;

        public void SetConnection(string connectString)
        {
            ConnStr = connectString;
            dbb = new DB_Branch(ConnStr);
            dbse = new DB_StatisticsEmployee(ConnStr);
        }
        public frmStatisticsEmployee()
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
                //Đưa dữ liệu lên ComboBox Chi nhánh
                cb_Branch.DataSource = dtBranch;
                cb_Branch.DisplayMember = "branch_name";
                cb_Branch.ValueMember = "branch_id";
                cb_Branch.Text = "Tất cả";

                int month;
                for (month = 1; month <= 12; month++)
                {
                    cb_Month.Items.Add(month);
                }                
                int year;
                for (year = 2020; year <= 2023; year++)
                {
                    cb_Year.Items.Add(year);
                }
                cb_Year.Text = cb_Year.Items[0].ToString();
                cb_Month.Text = cb_Month.Items[0].ToString();
            }
            catch
            {
                MessageBox.Show("Không lấy được nội dung trong table Employee. Lỗi rồi!!!");
            }
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            // Khai báo biến traloi 
            DialogResult traloi;
            // Hiện hộp thoại hỏi đáp 
            traloi = MessageBox.Show("Chắc không?", "Trả lời",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            // Kiểm tra có nhắp chọn nút Ok không? 
            if (traloi == DialogResult.OK) this.Close();
        }

        private void frmStatisticsEmployee_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void groupControl2_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void cb_Year_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DataTable dtStatistics = new DataTable();
            dtStatistics.Clear();
            dtStatistics = dbse.GetMostSoldEmployee(cb_Branch.SelectedValue.ToString(), Convert.ToInt32(cb_Month.Text.ToString()), Convert.ToInt32(cb_Year.Text.ToString()));

            dgvMost.DataSource = dtStatistics;
        }

        private void cb_Month_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cb_Month_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DataTable dtStatistics = new DataTable();
            dtStatistics.Clear();
            dtStatistics = dbse.GetMostSoldEmployee(cb_Branch.SelectedValue.ToString(), Convert.ToInt32(cb_Month.Text.ToString()), Convert.ToInt32(cb_Year.Text.ToString()));

            dgvMost.DataSource = dtStatistics;
        }

        private void cb_Year_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cb_Branch_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DataTable dtStatistics = new DataTable();
            dtStatistics.Clear();
            dtStatistics = dbse.GetMostSoldEmployee(cb_Branch.SelectedValue.ToString(), Convert.ToInt32(cb_Month.Text.ToString()), Convert.ToInt32(cb_Year.Text.ToString()));

            dgvMost.DataSource = dtStatistics;

            dtStatisticsEmployee = new DataTable();
            dtStatisticsEmployee.Clear();
            dtStatisticsEmployee = dbse.GetStatisticsEmployee(cb_Branch.SelectedValue.ToString());
            dgvEmployeeQuantity.DataSource = dtStatisticsEmployee;

            groupControl2.Text = "Số lượng nhân viên: " + dbse.GetEmployeeQuantity().ToString();
        }
    }
}