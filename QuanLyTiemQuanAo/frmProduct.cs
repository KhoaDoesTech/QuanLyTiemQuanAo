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
    public partial class frmProduct : DevExpress.XtraEditors.XtraForm, IConnectionForm
    {
        string ConnStr;
        DB_Product dbp;
        DataTable dtProduct = null;

        DB_ProductType dbpt;
        DataTable dtProductType = null;

        // Mảng lưu ảnh
        MemoryStream ms;
        byte[] arrImage;
        bool Them;
        public void SetConnection(string connectString)
        {
            ConnStr = connectString;
            dbp = new DB_Product(ConnStr);
            dbpt = new DB_ProductType(ConnStr);
        }
        public frmProduct()
        {
            InitializeComponent();            
        }
        void LoadData()
        {
            try
            {
                // Vận chuyển dữ liệu vào DataTable dtProductType 
                dtProductType = new DataTable();
                dtProductType.Clear();
                dtProductType = dbpt.GetProductType();
                // Đưa dữ liệu lên ComboBox trong DataGridView
                (dgvProduct.Columns["product_type_id"] as
                DataGridViewComboBoxColumn).DataSource = dtProductType;
                (dgvProduct.Columns["product_type_id"] as
                DataGridViewComboBoxColumn).DisplayMember =
                "product_type_name";
                (dgvProduct.Columns["product_type_id"] as
                DataGridViewComboBoxColumn).ValueMember =
                "product_type_id";

                // Vận chuyển dữ liệu vào DataTable dtProduct
                dtProduct = new DataTable();
                dtProduct.Clear();
                dtProduct = dbp.GetProduct();                

                MoHienThi();
                KhoaTuongTac();

                // Đưa dữ liệu lên DataGridView 
                dgvProduct.DataSource = dtProduct;

                dgvProduct_CellClick(null, null);

            }
            catch (SqlException e)
            {
                MessageBox.Show("Không lấy được nội dung trong table Product. Lỗi rồi!!!" + e.Message);
            }
        }
        private void KhoaHienThi()
        {
            btnThem.Visible= false;
            btnSua.Visible= false;
            
            btnLuu.Visible= true;
            btnHuy.Visible= true;
            btnThoat.Visible= false;

            btnLayHinh.Enabled= true;

            
        }

        private void MoHienThi()
        {
            btnThem.Visible = true;
            btnSua.Visible = true;
            
            btnLuu.Visible = false;
            btnHuy.Visible = false;
            btnThoat.Visible = true;

            btnLayHinh.Enabled = false;
            dgvProduct.Enabled = true;
        }

        private void XoaTrong()
        {
            txt_product_name.ResetText();
            txt_size.ResetText();
            txt_color.ResetText();
            txt_unit_price.ResetText();
            txtSearch.ResetText();
        }
        private void MoTuongTac()
        {            
            txt_product_id.Enabled = false;
            cb_product_type_id.Enabled = true;
            txt_product_name.Enabled = true;
            txt_size.Enabled = true;
            txt_color.Enabled = true;
            txt_unit_price.Enabled = true;            
        }
        private void KhoaTuongTac()
        {
            txt_product_id.Enabled = false;
            cb_product_type_id.Enabled = false;
            txt_product_name.Enabled = false;
            txt_size.Enabled = false;
            txt_color.Enabled = false;
            txt_unit_price.Enabled = false;            
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            KhoaHienThi();
            txt_product_id.Text = dbp.GetDefaultProductID();
            XoaTrong();
            MoTuongTac();
            dgvProduct.Enabled = false;
            txt_product_name.Focus();
        }

        private void frmProduct_Load(object sender, EventArgs e)
        {
            // Nội dung tìm
            cbTim.Items.Add("Mã sản phẩm");
            cbTim.Items.Add("Tên sản phẩm");
            cbTim.Text = cbTim.Items[0].ToString();

            LoadData();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            MoHienThi();
            XoaTrong();
            KhoaTuongTac();
            dgvProduct_CellClick(null, null);
        }        

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kích hoạt biến Sửa 
            Them = false;
            MoTuongTac();
            dgvProduct_CellClick(null, null);
            KhoaHienThi();
            txt_product_name.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            bool f = false;
            if (Them)
            {
                string err = "";
                try
                {
                    f = dbp.InsertProduct(ref err, cb_product_type_id.SelectedValue.ToString(), txt_product_name.Text, txt_size.Text, txt_color.Text, arrImage, Convert.ToInt32(txt_unit_price.Text));
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
            else // Sửa ThanhPho
            {
                string err = "";
                try
                {
                    f = dbp.UpdateProduct(ref err, txt_product_id.Text, cb_product_type_id.SelectedValue.ToString(), txt_product_name.Text, txt_size.Text, txt_color.Text, arrImage, int.Parse(txt_unit_price.Text.Replace(".", "")));
                    if (f)
                    {
                        // Load lại dữ liệu trên DataGridView 
                        LoadData();
                        // Thông báo 
                        MessageBox.Show("Đã cap nhat xong!");
                    }
                    else
                    {
                        MessageBox.Show("Đã cap nhat chưa xong!\n\r" + "Lỗi:" + err);
                    }
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không cập nhật được. Lỗi rồi!");
                }
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
        private void dgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Đưa dữ liệu lên ComboBox
            cb_product_type_id.DataSource = dtProductType;
            cb_product_type_id.DisplayMember = "product_type_name";
            cb_product_type_id.ValueMember = "product_type_id";
            // Thứ tự dòng hiện hành 
            int r = dgvProduct.CurrentCell.RowIndex;
            // Chuyển thông tin lên panel
            txt_product_id.Text =
            dgvProduct.Rows[r].Cells[0].Value.ToString();            
            cb_product_type_id.SelectedValue =
            dgvProduct.Rows[r].Cells[1].Value.ToString();
            txt_product_name.Text =
            dgvProduct.Rows[r].Cells[2].Value.ToString();
            txt_size.Text =
            dgvProduct.Rows[r].Cells[3].Value.ToString();
            txt_color.Text =
            dgvProduct.Rows[r].Cells[4].Value.ToString();
            pic_picture.Image = (System.Drawing.Image)
            dgvProduct.Rows[r].Cells[5].FormattedValue;
            txt_unit_price.Text =
            dgvProduct.Rows[r].Cells[6].Value.ToString();
        }

        private void btnLayHinh_Click(object sender, EventArgs e)
        {
            OpenFileDialog odlgOpenFile = new OpenFileDialog();
            odlgOpenFile.InitialDirectory = "C:\\";
            odlgOpenFile.Title = "Open File";
            odlgOpenFile.Filter = "Image files (*.jpg)|*.jpg|All files (*.*)|*.*";
            if (odlgOpenFile.ShowDialog() == DialogResult.OK)
            {
                pic_picture.Image = System.Drawing.Image.FromFile(odlgOpenFile.FileName);
                //
                ms = new MemoryStream();
                pic_picture.Image.Save(ms, pic_picture.Image.RawFormat);
                arrImage = ms.GetBuffer();
                ms.Close();
            }
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

                int x = cbTim.SelectedIndex;
                switch (x)
                {
                    case 0:
                        dt = dbp.FindProductByID(txtSearch.Text);
                        dgvProduct.DataSource = dt;
                        break;
                    case 1:
                        dt = dbp.FindProductByName(txtSearch.Text);
                        dgvProduct.DataSource = dt;
                        break;
                }
            }
        }

        private void txtTim_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbTim_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}