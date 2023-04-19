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
    public partial class frmProduct : DevExpress.XtraEditors.XtraForm, IConnectionForm
    {       
        DB_Product dbp;
        DataTable dtProduct = null;

        DB_ProductType dbpt;
        DataTable dtProductType = null;
        string ConnStr;
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
                // Đưa dữ liệu lên DataGridView 
                dgvProduct.DataSource = dtProduct;

            }
            catch (SqlException e)
            {
                MessageBox.Show("Không lấy được nội dung trong table KHACHHANG. Lỗi rồi!!!" + e.Message);
            }
        }
        private void KhoaHienThi()
        {
            btnThem.Visible= false;
            btnSua.Visible= false;
            btnXoa.Visible= false;
            btnLuu.Visible= true;
            btnHuy.Visible= true;
            btnThoat.Visible= false;
        }

        private void MoHienThi()
        {
            btnThem.Visible = true;
            btnSua.Visible = true;
            btnXoa.Visible = true;
            btnLuu.Visible = true;
            btnHuy.Visible = true;
            btnThoat.Visible = true;
            groupControl1.Enabled = false;
        }

        private void XoaTrong()
        {
            txt_product_id.ResetText();
            txt_product_name.ResetText();
            txt_size.ResetText();
            txt_color.ResetText();
            txt_unit_price.ResetText();
            txtSearch.ResetText();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            KhoaHienThi();
        }

        private void frmProduct_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            MoHienThi();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {

        }

        private void btnLayHinh_Click(object sender, EventArgs e)
        {

        }

        private void btnSua_Click(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {

        }

        private void cbSearch_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}