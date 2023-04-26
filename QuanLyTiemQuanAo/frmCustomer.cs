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

namespace QuanLyTiemQuanAo
{
    public partial class frmCustomer : DevExpress.XtraEditors.XtraForm, IConnectionForm
    {
        string ConnStr;
        DB_Customer dbc;
        DataTable dtCustomer = null;

        DB_CustomerType dbt;
        DataTable dtCustomerType = null;

        bool Them;

        public void SetConnection(string connectString)
        {
            ConnStr = connectString;
            dbc = new DB_Customer(ConnStr);
            dbt = new DB_CustomerType(ConnStr);
        }
        public frmCustomer()
        {
            InitializeComponent();
        }
        void LoadData()
        {
            try
            {
                // Vận chuyển dữ liệu vào DataTable dtCustomerType 
                dtCustomerType = new DataTable();
                dtCustomerType.Clear();
                dtCustomerType = dbt.GetCustomerType();
                // Đưa dữ liệu lên ComboBox trong DataGridView
                (dgvCustomer.Columns["customer_type_id"] as
                DataGridViewComboBoxColumn).DataSource = dtCustomerType;
                (dgvCustomer.Columns["customer_type_id"] as
                DataGridViewComboBoxColumn).DisplayMember =
                "customer_type_name";
                (dgvCustomer.Columns["customer_type_id"] as
                DataGridViewComboBoxColumn).ValueMember =
                "customer_type_id";

                // Vận chuyển dữ liệu vào DataTable dtCustomer
                dtCustomer = new DataTable();
                dtCustomer.Clear();
                dtCustomer = dbc.GetCustomer();

                MoHienThi();
                KhoaTuongTac();

                // Đưa dữ liệu lên DataGridView 
                dgvCustomer.DataSource = dtCustomer;

                dgvCustomer_CellClick(null, null);
            }
            catch (SqlException e)
            {
                MessageBox.Show("Không lấy được nội dung trong table Customer. Lỗi rồi!!!" + e.Message);
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
            txt_customer_id.ResetText();
            txt_full_name.ResetText();
            txt_gender.ResetText();
            dtp_birthday.ResetText();
            txt_phone.ResetText();
            txt_email.ResetText();
            txtSearch.ResetText();
        }
        private void MoTuongTac()
        {
            txt_customer_id.Enabled = false;
            cb_customer_type_id.Enabled = true;
            txt_full_name.Enabled = true;
            dtp_birthday.Enabled = true;   
            txt_gender.Enabled = true;
            txt_phone.Enabled = true;
            txt_email.Enabled = true;
        }
        private void KhoaTuongTac()
        {
            txt_customer_id.Enabled = false;
            cb_customer_type_id.Enabled = false;
            txt_full_name.Enabled = false;
            dtp_birthday.Enabled = true;
            txt_gender.Enabled = false;
            txt_phone.Enabled = false;
            txt_email.Enabled = true;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            KhoaHienThi();
            XoaTrong();
            MoTuongTac();
            txt_full_name.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kích hoạt biến Sửa 
            Them = false;
            MoTuongTac();
            dgvCustomer_CellClick(null, null);
            KhoaHienThi();
            txt_full_name.Focus();
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            bool f = false;
            if (Them)
            {
                string err = "";
                try
                {
                    f = dbc.InsertCustomer(ref err,cb_customer_type_id.SelectedValue.ToString(),
                        txt_full_name.Text, txt_gender.Text,
                        DateTime.Parse(dtp_birthday.Text), txt_phone.Text, txt_email.Text);
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
                    f = dbc.UpdateCustomer(ref err,txt_customer_id.Text, cb_customer_type_id.SelectedValue.ToString(),
                        txt_full_name.Text, txt_gender.Text,
                        DateTime.Parse(dtp_birthday.Text), txt_phone.Text, txt_email.Text);
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
            dgvCustomer_CellClick(null, null);
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
        private void dgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Đưa dữ liệu lên ComboBox
            cb_customer_type_id.DataSource = dtCustomerType;
            cb_customer_type_id.DisplayMember = "customer_type_name";
            cb_customer_type_id.ValueMember = "customer_type_id";
            // Thứ tự dòng hiện hành 
            int r = dgvCustomer.CurrentCell.RowIndex;
            // Chuyển thông tin lên panel 
            txt_customer_id.Text =
            dgvCustomer.Rows[r].Cells[0].Value.ToString();
            cb_customer_type_id.Text =
            dgvCustomer.Rows[r].Cells[1].Value.ToString();
            txt_full_name.Text =
            dgvCustomer.Rows[r].Cells[2].Value.ToString();
            txt_gender.Text =
            dgvCustomer.Rows[r].Cells[3].Value.ToString();
            dtp_birthday.Text =
            dgvCustomer.Rows[r].Cells[4].Value.ToString();
            txt_phone.Text =
            dgvCustomer.Rows[r].Cells[5].Value.ToString();
            txt_email.Text =
            dgvCustomer.Rows[r].Cells[6].Value.ToString();
        }

        private void btn_Tim_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                LoadData();
            }
            else
            {
               DataTable dt = new DataTable();
               //choose type to search
               dgvCustomer.DataSource = dt;

               int x = cbSearch.SelectedIndex;
               switch (x)
               {
                   case 0:
                       dt = dbc.FindCustomerByID(txtSearch.Text);
                       dgvCustomer.DataSource = dt;
                       break;
                   case 1:
                       dt = dbc.FindCustomerByName(txtSearch.Text);
                       dgvCustomer.DataSource = dt;
                       break;
               }
            }
        }

        private void frmCustomer_Load(object sender, EventArgs e)
        {
            //Nội dung tìm khách hàng
            cbSearch.Items.Add("Mã khách hàng");
            cbSearch.Items.Add("Tên khách hàng");
            cbSearch.Text = cbSearch.Items[0].ToString();

            LoadData();
        }
    } 
}