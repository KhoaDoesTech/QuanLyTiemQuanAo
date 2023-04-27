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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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

        DB_Product dbp;
        DataTable dtProduct = null;

        DB_PurchaseOrder dbpo;
        DataTable dtPurchaseOrder = null;

        bool Them;
        public void SetConnection(string connectString)
        {
            ConnStr = connectString;
            dbcn = new DB_Personal(ConnStr);
            dbct = new DB_CustomerType(ConnStr);
            dbc = new DB_Customer(ConnStr);
            dbp = new DB_Product(ConnStr);

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
                KhoaTuongTacDon();
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
            dtPersonal = dbcn.GetPersonInformation(username, password);
            DataRow r = dtPersonal.Rows[0];

            lb_nv.Text = "Nhân viên: " + r[0].ToString();
            lb_cn.Text = "- Chi nhánh: " + r[7].ToString();

            // Nội dung tìm khách hàng
            cbTim.Items.Add("Số điện thoại");
            cbTim.Items.Add("Mã khách hàng");
            cbTim.Text = cbTim.Items[0].ToString();

            // Nội dung tìm sản phẩm
            cbFind.Items.Add("Mã sản phẩm");
            cbFind.Items.Add("Tên sản phẩm");                      
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

        private void XoaTrongDon()
        {
            cb_product_name.ResetText();
            cb_size.ResetText();
            cb_color.ResetText();
            pic_picture.Refresh();
            txtTonKho.ResetText();
        }

        private void KhoaTuongTacDon()
        {
            txt_order_id.Enabled=false;
            txt_discount.Enabled=false;
            txtTongTien.Enabled=false;
            txtGiamGia.Enabled=false;
            txt_total_cost.Enabled=false;
            txtTonKho.Enabled=false;
        }


        private void dgvDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            bool f = false;

            if (Them)
            {
                string err = "";
                try
                {
                    DataTable dt = new DataTable();
                    dt = dbp.FindInfoProduct(cb_product_name.SelectedValue.ToString(),
                        cb_size.SelectedValue.ToString(), cb_color.SelectedValue.ToString(), dtPersonal.Rows[0][10].ToString());
                    dgvDetail.Rows.Add(cb_product_name, txt_quantity.Text,dt.Rows[0][5].ToString());
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
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy thứ tự record hiện hành 
                int r = dgvDetail.CurrentCell.RowIndex;
                // Lấy product_name của record hiện hành 
                string str_employee_id =
                dgvDetail.Rows[r].Cells[0].Value.ToString();
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
                    bool f = dbpo.DeleteOrderDetail(ref err, cb_product_name.SelectedValue.ToString());
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            dgvDetail.Rows.Clear();
            dgvDetail.Refresh();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if (txtTim.Text == "")
            {
                XoaTrongKhach();
            }
            else
            {
                XoaTrongKhach();
                DataRow r;
                DataTable dt;
                int x = cbTim.SelectedIndex;
                switch (x)
                {
                    case 0:
                        dt = dbc.FindCustomerByID(txtTim.Text);
                        r = dt.Rows[0];
                        txt_customer_type_id.Text = r[0].ToString();
                        txt_gender.Text = r[1].ToString();
                        txt_phone.Text = r[2].ToString();
                        txt_email.Text = r[3].ToString();
                        txt_full_name.Text = r[4].ToString();
                        dtp_birthday.Text = r[5].ToString();
                        break;
                    case 1:
                        dt = dbc.FindCustomerByName(txtTim.Text);
                        r = dt.Rows[0];
                        txt_customer_type_id.Text = r[0].ToString();
                        txt_gender.Text = r[1].ToString();
                        txt_phone.Text = r[2].ToString();
                        txt_email.Text = r[3].ToString();
                        txt_full_name.Text = r[4].ToString();
                        dtp_birthday.Text = r[5].ToString();
                        break;
                }
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {

        }     

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (txtFind.Text == "")
            {
                XoaTrongDon();
            }
            else
            {
                XoaTrongDon();
                DataTable dt = new DataTable();
                int x = cbFind.SelectedIndex;
                switch (x)
                {
                    case 0:
                        dt = dbp.FindProductNameByID(txtFind.Text);
                        cb_product_name.DataSource = dt;
                        cb_product_name.DisplayMember = "product_name";
                        cb_product_name.ValueMember = "product_name";
                        
                        break;
                    case 1:
                        dt = dbp.FindProductNameByName(txtFind.Text);
                        cb_product_name.DataSource = dt;
                        cb_product_name.DisplayMember = "product_name";
                        cb_product_name.ValueMember = "product_name";
                        break;
                }
            }
        }

        private void cb_product_name_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            dt = dbp.FindSizeByName(cb_product_name.SelectedValue.ToString());
            cb_size.DataSource = dt;
            cb_size.DisplayMember = "size";
            cb_size.ValueMember = "size";

            DataTable dtt = new DataTable();

            dtt = dbp.FindColorByName(cb_product_name.SelectedValue.ToString());
            cb_color.DataSource = dtt;
            cb_color.DisplayMember = "color";
            cb_color.ValueMember = "color";
        }

        private void cb_size_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            dt = dbp.FindColorBySize(cb_size.SelectedValue.ToString(), cb_product_name.SelectedValue.ToString());
            cb_color.DataSource = dt;
            cb_color.DisplayMember = "color";
            cb_color.ValueMember = "color";

            LayThongTin();
        }

        private void cb_color_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            dt = dbp.FindSizeByColor(cb_color.SelectedValue.ToString(), cb_product_name.SelectedValue.ToString());
            cb_size.DataSource = dt;
            cb_size.DisplayMember = "size";
            cb_size.ValueMember = "size";

            LayThongTin();
        }

        private void LayThongTin()
        {
            DataTable dt = new DataTable();

            dt = dbp.FindInfoProduct(cb_product_name.SelectedValue.ToString(), cb_size.SelectedValue.ToString(), cb_color.SelectedValue.ToString(), dtPersonal.Rows[0][10].ToString());

            byte[] imageData = (byte[])dt.Rows[0][4];
            if (imageData != null)
            {
                using (MemoryStream ms = new MemoryStream(imageData))
                {
                    pic_picture.Image = Image.FromStream(ms);
                }
            }
            else
            {
                pic_picture.Image = null;
            }

            txtTonKho.Text = dt.Rows[0][7].ToString();
        }

        private void dgvDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}