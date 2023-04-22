using BALayer;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QuanLyTiemQuanAo
{
    public partial class frmPurchaseOrder : DevExpress.XtraEditors.XtraForm, IConnectionForm
    {
        string ConnStr;
        string username;
        string password;

        DB_Personal dbcn;
        DataTable dtPersonal = null;

        DB_CustomerType dbct;
        DataTable dtCustomerType = null;

        DB_Customer dbc;
        DataTable dtCustomer = null;
        public void SetConnection(string connectString)
        {
            ConnStr = connectString;
            dbcn = new DB_Personal(ConnStr);
            dbct = new DB_CustomerType(ConnStr);
            dbc = new DB_Customer(ConnStr);

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(ConnStr);
            username = builder.UserID;
            password = builder.Password;
        }
        public frmPurchaseOrder()
        {
            InitializeComponent();
        }

        void LoadData()
        {
            try
            {
                MoTuongTacKhach();
                XoaTrongKhach();
            }
            catch (SqlException e)
            {
                MessageBox.Show("Không lấy được nội dung. Lỗi rồi!!!" + e.Message);
            }
        }

        private void frmPurchaseOrder_Load(object sender, EventArgs e)
        {
            dtPersonal = new DataTable();
            dtPersonal.Clear();
            dtPersonal = dbcn.FindProductTypeByGender(username, password);
            DataRow r = dtPersonal.Rows[0];

            lb_nv.Text = "Nhân viên: " + r[0].ToString();
            lb_cn.Text = "- Chi nhánh: " + r[7].ToString();

            // Nội dung tìm khách hàng
            cbTim.Items.Add("Số điện thoại");
            cbTim.Items.Add("Mã khách hàng");
            cbTim.Text = cbTim.Items[0].ToString();

            // Nội dung tìm sản phẩm
            cbFind.Items.Add("Tên sản phẩm");
            cbFind.Items.Add("Mã sản phẩm");
            cbFind.Items.Add("Loại sản phẩm");
            cbFind.Text = cbFind.Items[0].ToString();

            LoadData();
        }

        private void MoTuongTacKhach()
        {
            txt_customer_id.Enabled = false;
            txt_customer_type_id.Enabled = false;

            txt_gender.Enabled = true;
            txt_phone.Enabled = true;
            txt_email.Enabled = true;
            txt_full_name.Enabled = true;
            dtp_birthday.Enabled = true;
        }

        private void KhoaTuongTacKhach()
        {
            txt_customer_id.Enabled = false;
            txt_customer_type_id.Enabled = false;

            txt_gender.Enabled = false;
            txt_phone.Enabled = false;
            txt_email.Enabled = false;
            txt_full_name.Enabled = false;
            dtp_birthday.Enabled = false;
        }

        private void XoaTrongKhach()
        {
            txt_customer_id.Text = dbc.GetDefaultCustomerID();
            txt_customer_type_id.Text = "Bình thường";

            txt_gender.ResetText();
            txt_phone.ResetText();
            txt_email.ResetText();
            txt_full_name.ResetText();
            dtp_birthday.ResetText();
        }

        private void dgvDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {

        }

        private void btnSua_Click(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dgvDetail.Rows.Clear();
            dgvDetail.Refresh();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if(txtTim.Text == "")
            {
                MoTuongTacKhach();
                XoaTrongKhach();
            }    
            else
            {
                KhoaTuongTacKhach();
            }         

        }
    }
}