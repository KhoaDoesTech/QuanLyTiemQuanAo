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
    public partial class frmCurrentDiscount : DevExpress.XtraEditors.XtraForm, IConnectionForm
    {
        DB_Discount dbd;
        DataTable dtDiscount = null;

        DB_Event dbe;
        DataTable dtEvent = null;

        DB_CustomerType dbct;
        DataTable dtCustomerType = null;
        string ConnStr;
        public void SetConnection(string connectString)
        {
            ConnStr = connectString;
            dbe = new DB_Event(ConnStr);
            dbct = new DB_CustomerType(ConnStr);
            dbd = new DB_Discount(ConnStr);
        }
        public frmCurrentDiscount()
        {
            InitializeComponent();
        }

        void LoadData()
        {
            try
            {
                // Vận chuyển dữ liệu vào DataTable dtEvent 
                dtEvent = new DataTable();
                dtEvent.Clear();
                dtEvent = dbe.GetEvent();
                // Đưa dữ liệu lên ComboBox trong DataGridView
                (dgvCurrentDiscount.Columns["event_id"] as
                DataGridViewComboBoxColumn).DataSource = dtEvent;
                (dgvCurrentDiscount.Columns["event_id"] as
                DataGridViewComboBoxColumn).DisplayMember =
                "event_name";
                (dgvCurrentDiscount.Columns["event_id"] as
                DataGridViewComboBoxColumn).ValueMember =
                "event_id";

                // Vận chuyển dữ liệu vào DataTable dtCustomerType
                dtCustomerType = new DataTable();
                dtCustomerType.Clear();
                dtCustomerType = dbct.GetCustomerType();
                // Đưa dữ liệu lên ComboBox trong DataGridView
                (dgvCurrentDiscount.Columns["customer_type_id"] as
                DataGridViewComboBoxColumn).DataSource = dtCustomerType;
                (dgvCurrentDiscount.Columns["customer_type_id"] as
                DataGridViewComboBoxColumn).DisplayMember =
                "customer_type_name";
                (dgvCurrentDiscount.Columns["customer_type_id"] as
                DataGridViewComboBoxColumn).ValueMember =
                "customer_type_id";

                // Vận chuyển dữ liệu vào DataTable dtDiscount
                dtDiscount = new DataTable();
                dtDiscount.Clear();
                dtDiscount = dbd.GetCurrentDiscount(DateTime.Now);

                MoHienThi();

                // Đưa dữ liệu lên DataGridView 
                dgvCurrentDiscount.DataSource = dtDiscount;
            }
            catch (SqlException e)
            {
                MessageBox.Show("Không lấy được nội dung trong table Discount. Lỗi rồi!!!" + e.Message);
            }
        }
        private void KhoaHienThi()
        {
            btnThoat.Visible = false;
        }

        private void MoHienThi()
        {
            btnThoat.Visible = true;
            dgvCurrentDiscount.Enabled = true;
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
                        dt = dbd.FindDiscountByID(txtSearch.Text);
                        dgvCurrentDiscount.DataSource = dt;
                        break;
                    case 1:
                        dt = dbd.FindDiscountByDiscountPercent(Convert.ToInt32(txtSearch.Text));
                        dgvCurrentDiscount.DataSource = dt;
                        break;
                    case 2:
                        dt = dbd.FindDiscountByDiscountPrice(Convert.ToInt32(txtSearch.Text));
                        dgvCurrentDiscount.DataSource = dt;
                        break;
                }
            }
        }

        private void frmCurrentDiscount_Load(object sender, EventArgs e)
        {
            groupControl1.Text = "Thời gian hiện tại: " + DateTime.Now;

            // Nội dung tìm Nhân viên
            cbSearch.Items.Add("Mã sự kiện");
            cbSearch.Items.Add("Giảm theo phần trăm");
            cbSearch.Items.Add("Giảm theo giá");
            cbSearch.Text = cbSearch.Items[0].ToString();

            LoadData();
        }
    }
}