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
using DevExpress.ClipboardSource.SpreadsheetML;
using static DevExpress.Data.Helpers.ExpressiveSortInfo;
using DevExpress.XtraEditors.TextEditController.Win32;

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

        DB_Discount dbd;
        DataTable dtDiscount = null;

        DB_Stock dbs;
        DataTable dtStock = null;

        bool Them;
        bool khach;
        public void SetConnection(string connectString)
        {
            ConnStr = connectString;
            dbcn = new DB_Personal(ConnStr);
            dbct = new DB_CustomerType(ConnStr);
            dbc = new DB_Customer(ConnStr);
            dbp = new DB_Product(ConnStr);
            dbd = new DB_Discount(ConnStr);
            dbpo = new DB_PurchaseOrder(ConnStr);
            dbs = new DB_Stock(ConnStr);

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
                dtDiscount = dbd.GetCurrentDiscount(DateTime.Parse(dtp_order_date.Text.ToString()));
                cb_event.DataSource = dtDiscount;
                cb_event.DisplayMember = "event_name";
                cb_event.ValueMember = "event_id";

                MoTuongTacKhach();
                XoaTrongKhach();
                KhoaTuongTacDon();

                txt_order_id.Text = dbpo.GetDefaultOrderID();
                if (dtDiscount.Rows[0][2].ToString() != null)
                {
                    txt_discount.Text = dtDiscount.Rows[0][2].ToString();                    
                }
                else
                {
                    txt_discount.Text = dtDiscount.Rows[0][3].ToString();
                }                
            }
            catch (SqlException e)
            {
                MessageBox.Show("Không lấy được nội dung. Lỗi rồi!!!" + e.Message);
            }
        }

        private void TinhTien()
        {
            int total = 0;

            for (int i = 0; i < dgvDetail.Rows.Count; i++)
            {
                DataGridViewRow r = dgvDetail.Rows[i];
                object value = r.Cells[3].Value;
                if (value != null)
                {
                    total = total + int.Parse(value.ToString());
                }
            }
            txtTongTien.Text = total.ToString();

            int z = cb_event.SelectedIndex;
            if (!string.IsNullOrEmpty(dtDiscount.Rows[z][2].ToString()))
            {
                txt_discount.Text = dtDiscount.Rows[z][2].ToString();
                txtGiamGia.Text = (Convert.ToInt32(txtTongTien.Text) * Convert.ToDouble(txt_discount.Text)).ToString();
            }

            if (!string.IsNullOrEmpty(dtDiscount.Rows[z][3].ToString()))
            {
                txt_discount.Text = dtDiscount.Rows[z][3].ToString();
                txtGiamGia.Text = txt_discount.Text;
            }

            txt_total_cost.Text = (Convert.ToInt32(txtTongTien.Text) - Convert.ToDouble(txtGiamGia.Text)).ToString();
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
            try
            {
                DataTable dt = new DataTable();
                dt = dbp.FindInfoProduct(cb_product_name.SelectedValue.ToString(),
                    cb_size.SelectedValue.ToString(), cb_color.SelectedValue.ToString(), dtPersonal.Rows[0][10].ToString());
                dgvDetail.Rows.Add(cb_product_name.SelectedValue.ToString(), txt_quantity.Text, dt.Rows[0][5].ToString(),
                    (Convert.ToInt32(dt.Rows[0][5]) * Convert.ToInt32(txt_quantity.Text)).ToString(), cb_size.Text, cb_color.Text);
                TinhTien();

                string err = "";
                f = dbs.SellProduct(ref err, dtPersonal.Rows[0][10].ToString(), dt.Rows[0][0].ToString(), Convert.ToInt32(txt_quantity.Text));
                if (f)
                {
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            bool f = false;
            try
            {
                int r = dgvDetail.CurrentCell.RowIndex;

                DataGridViewRow row = dgvDetail.Rows[r];
                DataTable dt = new DataTable();
                dt = dbp.FindInfoProduct(row.Cells[0].Value.ToString(),
                    row.Cells[4].Value.ToString(), row.Cells[5].Value.ToString(), dtPersonal.Rows[0][10].ToString());

                string err = "";
                f = dbs.UndoSellProduct(ref err, dtPersonal.Rows[0][10].ToString(), dt.Rows[0][0].ToString(), Convert.ToInt32(row.Cells[1].Value.ToString()));
                if (f)
                {
                    dgvDetail.Rows.Remove(row);
                    TinhTien();
                    MessageBox.Show("Đã thêm xong!");
                }
                else
                {
                    MessageBox.Show("Đã thêm chưa xong!\n\r" + "Lỗi:" + err);
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Không xóa được. Lỗi rồi!!!");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {            
            bool f = false;
            try
            {
                for (int i = 0; i <= dgvDetail.Rows.Count; i++)
                {
                    DataGridViewRow row = dgvDetail.Rows[0];
                    DataTable dt = new DataTable();
                    dt = dbp.FindInfoProduct(row.Cells[0].Value.ToString(),
                        row.Cells[4].Value.ToString(), row.Cells[5].Value.ToString(), dtPersonal.Rows[0][10].ToString());

                    string err = "";
                    f = dbs.UndoSellProduct(ref err, dtPersonal.Rows[0][10].ToString(), dt.Rows[0][0].ToString(), Convert.ToInt32(row.Cells[1].Value.ToString()));
                    if (f)
                    {
                        dgvDetail.Rows.Remove(row);
                        
                        MessageBox.Show("Đã thêm xong!");
                    }
                    else
                    {
                        MessageBox.Show("Đã thêm chưa xong!\n\r" + "Lỗi:" + err);
                    }
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Không xóa được. Lỗi rồi!!!");
            }
            TinhTien();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if (txtTim.Text == "")
            {
                XoaTrongKhach();
                MoTuongTacKhach();
                khach = false;
            }
            else
            {
                XoaTrongKhach();
                KhoaTuongTacKhach();
                DataRow r;
                int x = cbTim.SelectedIndex;
                khach = true;
                switch (x)
                {
                    case 0:
                        dtCustomer = dbc.FindCustomerByPhone(txtTim.Text);
                        if (dtCustomer.Rows.Count == 0)
                        {
                            MoTuongTacKhach();
                            khach = false; 
                            break;
                        }
                        r = dtCustomer.Rows[0];
                        txt_customer_id.Text = r[0].ToString();
                        txt_customer_type_id.Text = r[1].ToString();
                        txt_full_name.Text = r[2].ToString();
                        txt_gender.Text = r[3].ToString();
                        dtp_birthday.Value = Convert.ToDateTime(r[4]);
                        txt_phone.Text = r[5].ToString();
                        txt_email.Text = r[6].ToString();                                 
                        break;
                    case 1:
                        dtCustomer = dbc.FindCustomerByID(txtTim.Text);
                        if (dtCustomer.Rows.Count == 0)
                        {
                            MoTuongTacKhach();
                            khach = false;
                            break;
                        }
                        r = dtCustomer.Rows[0];
                        txt_customer_id.Text = r[0].ToString();
                        txt_customer_type_id.Text = r[1].ToString();
                        txt_full_name.Text = r[2].ToString();
                        txt_gender.Text = r[3].ToString();
                        dtp_birthday.Value = Convert.ToDateTime(r[4]);
                        txt_phone.Text = r[5].ToString();
                        txt_email.Text = r[6].ToString();
                        break;
                }
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (khach == false)
            {
                bool c = false;
                string error = "";
                c = dbc.InsertCustomer(ref error,
                        txt_full_name.Text, txt_gender.Text,
                        DateTime.Parse(dtp_birthday.Text), txt_phone.Text, txt_email.Text);
                if (c)
                {
                    MessageBox.Show("Đã thêm xong!");
                }
                else
                {
                    MessageBox.Show("Đã thêm chưa xong!\n\r" + "Lỗi:" + error);
                }
            }

            bool f = false;
            string err = "";
            f = dbpo.InsertPurchaseOrder(ref err,
                    txt_customer_id.Text, dtPersonal.Rows[0][10].ToString(), dtPersonal.Rows[0][9].ToString(), cb_event.SelectedValue.ToString(),
                    DateTime.Parse(dtp_order_date.Text), Convert.ToInt32(txt_total_cost.Text));
            if (f)
            {
                MessageBox.Show("Đã thêm xong!");
            }
            else
            {
                MessageBox.Show("Đã thêm chưa xong!\n\r" + "Lỗi:" + err);
            }

            bool z = false;
            for (int i = 0; i < dgvDetail.Rows.Count; i++)
            {
                DataGridViewRow row = dgvDetail.Rows[0];
                DataTable dt = new DataTable();
                dt = dbp.FindInfoProduct(row.Cells[0].Value.ToString(),
                    row.Cells[4].Value.ToString(), row.Cells[5].Value.ToString(), dtPersonal.Rows[0][10].ToString());

                string er = "";
                z = dbpo.InsertOrderDetail(ref er, txt_order_id.Text.ToString(), dt.Rows[0][0].ToString(), Convert.ToInt32(row.Cells[1].Value.ToString()));
                if (z)
                {
                    dgvDetail.Rows.Remove(row);

                    MessageBox.Show("Đã thêm xong!");
                }
                else
                {
                    MessageBox.Show("Đã thêm chưa xong!\n\r" + "Lỗi:" + er);
                }
            }

            LoadData();
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
            //DataTable dt = new DataTable();

            //dt = dbp.FindColorBySize(cb_size.SelectedValue.ToString(), cb_product_name.SelectedValue.ToString());
            //cb_color.DataSource = dt;
            //cb_color.DisplayMember = "color";
            //cb_color.ValueMember = "color";

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

        private void dtp_order_date_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cb_event_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int i = cb_event.SelectedIndex;
            if (!string.IsNullOrEmpty(dtDiscount.Rows[i][2].ToString()))
            {
                txt_discount.Text = dtDiscount.Rows[i][2].ToString();
            }

            if (!string.IsNullOrEmpty(dtDiscount.Rows[i][3].ToString()))
            {
                txt_discount.Text = dtDiscount.Rows[i][3].ToString();
            }
            TinhTien();
        }
    }
}