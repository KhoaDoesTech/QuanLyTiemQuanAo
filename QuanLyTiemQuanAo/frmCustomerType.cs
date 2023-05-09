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
    public partial class frmCustomerType : DevExpress.XtraEditors.XtraForm, IConnectionForm
    {
        string ConnStr;
        DB_CustomerType dbt;
        DataTable dtCustomerType = null;

        bool Them;

        public void SetConnection(string connectString)
        {
            ConnStr = connectString;
            dbt = new DB_CustomerType(ConnStr);
        }
        public frmCustomerType()
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

                MoHienThi();
                KhoaTuongTac();

                // Đưa dữ liệu lên DataGridView 
                dgvCustomerType.DataSource = dtCustomerType;

                dgvCustomerType_CellClick(null, null);

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
            dgvCustomerType.Enabled = true;

        }

        private void XoaTrong()
        {
            txt_customer_type_name.ResetText();
            txt_units_purchased.ResetText();
        }
        private void MoTuongTac()
        {
            txt_customer_type_id.Enabled = false;
            txt_customer_type_name.Enabled = true;
            txt_units_purchased.Enabled = true;
        }
        private void KhoaTuongTac()
        {
            txt_customer_type_id.Enabled = false;
            txt_customer_type_name.Enabled = false;
            txt_units_purchased.Enabled = false;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            KhoaHienThi();
            txt_customer_type_id.Text = dbt.GetDefaultCustomerTypeID();
            XoaTrong();
            MoTuongTac();
            dgvCustomerType.Enabled = false;
            txt_customer_type_name.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kích hoạt biến Sửa 
            Them = false;
            MoTuongTac();
            dgvCustomerType_CellClick(null, null);
            KhoaHienThi();
            txt_customer_type_name.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            bool f = false;
            if (Them)
            {
                string err = "";
                try
                {
                    f = dbt.InsertCustomerType(ref err, txt_customer_type_name.Text,
                        Convert.ToInt32(txt_units_purchased.Text));
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
                    f = dbt.UpdateCustomerType(ref err, txt_customer_type_id.Text, txt_customer_type_name.Text,
                        Convert.ToInt32(txt_units_purchased.Text));
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
            dgvCustomerType_CellClick(null, null);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            // Khai báo biến traloi 
            DialogResult answer;
            // Hiện hộp thoại hỏi đáp 
            answer = MessageBox.Show("Chắc không?", "Trả lời",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            // Kiểm tra có nhắp chọn nút Ok không? 
            if (answer == DialogResult.OK) this.Close();
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

                int x = cbSearch.SelectedIndex;
                switch (x)
                {
                    case 0:
                        dt = dbt.FindCustomerTypeByID(txtSearch.Text);
                        dgvCustomerType.DataSource = dt;
                        break;
                    case 1:
                        dt = dbt.FindCustomerTypeByName(txtSearch.Text);
                        dgvCustomerType.DataSource = dt;
                        break;
                }
            }
        }

        private void frmCustomerType_Load(object sender, EventArgs e)
        {
            //Nội dung tìm loại khách hàng
            cbSearch.Items.Add("Loại khách hàng");
            cbSearch.Items.Add("Tên loại khách hàng");
            cbSearch.Text = cbSearch.Items[0].ToString();

            LoadData();
        }

        private void dgvCustomerType_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Thứ tự dòng hiện hành 
            int r = dgvCustomerType.CurrentCell.RowIndex;
            // Chuyển thông tin lên panel 
            txt_customer_type_id.Text =
            dgvCustomerType.Rows[r].Cells[0].Value.ToString();
            txt_customer_type_name.Text =
            dgvCustomerType.Rows[r].Cells[1].Value.ToString();
            txt_units_purchased.Text =
            dgvCustomerType.Rows[r].Cells[2].Value.ToString();
        }
    }
}