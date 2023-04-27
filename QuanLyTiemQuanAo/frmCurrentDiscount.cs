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
    public partial class frmCurrentDiscount : DevExpress.XtraEditors.XtraForm
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
        }
        // Khai báo biến kiểm tra việc Thêm hay Sửa dữ liệu 
        bool Them;
        public frmCurrentDiscount()
        {
            InitializeComponent();
            dbe = new DB_Event(ConnStr);
            dbct = new DB_CustomerType(ConnStr);
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
                (dgvDiscount.Columns["event_id"] as
                DataGridViewComboBoxColumn).DataSource = dtEvent;
                (dgvDiscount.Columns["event_id"] as
                DataGridViewComboBoxColumn).DisplayMember =
                "event_name";
                (dgvDiscount.Columns["event_id"] as
                DataGridViewComboBoxColumn).ValueMember =
                "event_id";

                // Vận chuyển dữ liệu vào DataTable dtCustomerType
                dtCustomerType = new DataTable();
                dtCustomerType.Clear();
                dtCustomerType = dbct.GetCustomerType();
                // Đưa dữ liệu lên ComboBox trong DataGridView
                (dgvDiscount.Columns["customer_type_id"] as
                DataGridViewComboBoxColumn).DataSource = dtEvent;
                (dgvDiscount.Columns["customer_type_id"] as
                DataGridViewComboBoxColumn).DisplayMember =
                "customer_type_name";
                (dgvDiscount.Columns["customer_type_id"] as
                DataGridViewComboBoxColumn).ValueMember =
                "customer_type_id";

                MoHienThi();
                KhoaTuongTac();

                dgvCurrentDiscount_CellClick(null, null);

            }
            catch (SqlException e)
            {
                MessageBox.Show("Không lấy được nội dung trong table Employee. Lỗi rồi!!!" + e.Message);
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
            cb_event_id.ResetText();
            cb_customer_type_id.ResetText();
            txt_discount_percent.ResetText();
            txt_discount_price.ResetText();
        }
        private void MoTuongTac()
        {
            cb_event_id.Enabled = true;
            cb_customer_type_id.Enabled = true;
            txt_discount_percent.Enabled = true;
            txt_discount_price.Enabled = true;
        }
        private void KhoaTuongTac()
        {
            cb_event_id.Enabled = false;
            cb_customer_type_id.Enabled = false;
            txt_discount_percent.Enabled = false;
            txt_discount_price.Enabled = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            KhoaHienThi();
            XoaTrong();
            MoTuongTac();
            cb_event_id.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            bool f = false;
            if (Them)
            {
                string err = "";
                try
                {
                    f = dbd.InsertDiscount(ref err, Convert.ToInt32(discount_percent),
                        Convert.ToInt32(discount_price));
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
            dgvCurrentDiscount_CellClick(null, null);
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

        private void frmCurrentDiscount_Load(object sender, EventArgs e)
        {
            // Nội dung tìm Nhân viên
            cbSearch.Items.Add("Mã nhân viên");
            cbSearch.Items.Add("Tên nhân viên");
            cbSearch.Text = cbSearch.Items[0].ToString();

            LoadData();
        }

        private void dgvCurrentDiscount_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Đưa dữ liệu lên ComboBox
            cb_event_id.DataSource = dtEvent;
            cb_event_id.DisplayMember = "event_name";
            cb_event_id.ValueMember = "event_id";
            // Đưa dữ liệu lên ComboBox
            cb_customer_type_id.DataSource = dtCustomerType;
            cb_customer_type_id.DisplayMember = "customer_type_name";
            cb_customer_type_id.ValueMember = "customer_type_id";
            // Thứ tự dòng hiện hành 
            int r = dgvDiscount.CurrentCell.RowIndex;
            // Chuyển thông tin lên panel 
            cb_event_id.Text =
            dgvDiscount.Rows[r].Cells[0].Value.ToString();
            cb_customer_type_id.SelectedValue =
            dgvDiscount.Rows[r].Cells[1].Value.ToString();
            txt_discount_percent.Text =
            dgvDiscount.Rows[r].Cells[2].Value.ToString();
            txt_discount_price.Text =
            dgvDiscount.Rows[r].Cells[3].Value.ToString();
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
                dgvDiscount.DataSource = dt;

                int x = cbSearch.SelectedIndex;
                switch (x)
                {
                    case 0:
                        dt = dbd.FindDiscountByID(txtSearch.Text);
                        dgvDiscount.DataSource = dt;
                        break;
                    case 1:
                        dt = dbd.FindDiscountByDiscountPercent(Convert.ToInt32(txtSearch.Text));
                        dgvDiscount.DataSource = dt;
                        break;
                    case 2:
                        dt = dbd.FindDiscountByDiscountPrice(Convert.ToInt32(txtSearch.Text));
                        dgvDiscount.DataSource = dt;
                        break;
                }
            }
        }
    }
}