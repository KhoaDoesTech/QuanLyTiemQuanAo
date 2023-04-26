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

namespace QuanLyTiemQuanAo
{
    public partial class frmProductType : DevExpress.XtraEditors.XtraForm, IConnectionForm
    {
        string ConnStr;
        DB_ProductType dbpt;
        DataTable dtProductType = null;

        bool Them;
        public frmProductType()
        {
            InitializeComponent();
        }
        public void SetConnection(string connectString)
        {
            ConnStr = connectString;            
            dbpt = new DB_ProductType(ConnStr);
        }
        void LoadData()
        {
            try
            {
                // Vận chuyển dữ liệu vào DataTable dtProduct
                dtProductType = new DataTable();
                dtProductType.Clear();
                dtProductType = dbpt.GetProductType();

                MoHienThi();
                KhoaTuongTac();

                // Đưa dữ liệu lên DataGridView 
                dgvProductType.DataSource = dtProductType;

                dgvProductType_CellClick(null, null);

            }
            catch (SqlException e)
            {
                MessageBox.Show("Không lấy được nội dung trong table KHACHHANG. Lỗi rồi!!!" + e.Message);
            }
        }
        private void KhoaHienThi()
        {
            btnThem.Visible = false;
            btnSua.Visible = false;
            btnThoat.Visible = false;

            btnLuu.Visible = true;
            btnHuy.Visible = true;            
        }

        private void MoHienThi()
        {
            btnThem.Visible = true;
            btnSua.Visible = true;
            btnThoat.Visible = true;

            btnLuu.Visible = false;
            btnHuy.Visible = false;
        }

        private void XoaTrong()
        {
            txt_product_type_id.ResetText();
            txt_product_type_name.ResetText();
            txt_class.ResetText();
            txt_gender.ResetText();
            txtSearch.ResetText();
        }
        private void MoTuongTac()
        {
            txt_product_type_id.Enabled = false;
            txt_product_type_name.Enabled = true;
            txt_class.Enabled = true;
            txt_gender.Enabled = true;
        }
        private void KhoaTuongTac()
        {
            txt_product_type_id.Enabled = false;
            txt_product_type_name.Enabled = false;
            txt_class.Enabled = false;
            txt_gender.Enabled = false;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            KhoaHienThi();
            XoaTrong();
            MoTuongTac();
            txt_product_type_name.Focus();
        }

        private void dgvProductType_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvProductType.CurrentCell.RowIndex;
            // Chuyển thông tin lên panel 
            txt_product_type_id.Text =
            dgvProductType.Rows[r].Cells[0].Value.ToString();
            txt_product_type_name.Text =
            dgvProductType.Rows[r].Cells[1].Value.ToString();
            txt_class.Text =
            dgvProductType.Rows[r].Cells[2].Value.ToString();
            txt_gender.Text =
            dgvProductType.Rows[r].Cells[3].Value.ToString();            
        }
        private void frmProductType_Load(object sender, EventArgs e)
        {
            // Nội dung tìm Loại sản phẩm
            cbSearch.Items.Add("Mã loại sản phẩm");
            cbSearch.Items.Add("Tên loại sản phẩm");
            cbSearch.Items.Add("Lớp sản phẩm");
            cbSearch.Items.Add("Giới tính");
            cbSearch.Text = cbSearch.Items[0].ToString();

            LoadData();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kích hoạt biến Sửa 
            Them = false;
            MoTuongTac();
            dgvProductType_CellClick(null, null);
            KhoaHienThi();
            txt_product_type_name.Focus();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            MoHienThi();
            XoaTrong();
            KhoaTuongTac();
            dgvProductType_CellClick(null, null);
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

        private void btnLuu_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(txtSearch.Text == "")
            {
                LoadData();
            }
            else
            {
                DataTable dt = new DataTable();
                //choose type to search
                dgvProductType.DataSource = dt;

                int x = cbSearch.SelectedIndex;
                switch (x)
                {
                    case 0:
                        dt = dbpt.FindProductTypeByID(txtSearch.Text);
                        dgvProductType.DataSource = dt;
                        break;
                    case 1:
                        dt = dbpt.FindProductTypeByName(txtSearch.Text);
                        dgvProductType.DataSource = dt;
                        break;
                    case 2:
                        dt = dbpt.FindProductTypeByClass(txtSearch.Text);
                        dgvProductType.DataSource = dt;
                        break;
                    case 3:
                        dt = dbpt.FindProductTypeByGender(txtSearch.Text);
                        dgvProductType.DataSource = dt;
                        break;
                }                
            }
        }

        private void cbSearch_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}