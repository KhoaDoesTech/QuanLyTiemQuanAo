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
    public partial class frmProduct : Form
    {
        DB_Product dbProduct;
        DataTable dtProduct = null;
        public frmProduct()
        {
            InitializeComponent();
            dbProduct= new DB_Product();
        }

        void LoadData()
        {
            try
            {
                dtProduct = new DataTable();
                dtProduct.Clear();
                dtProduct = dbProduct.GetProduct();

                dgvPRODUCT.DataSource = dtProduct;
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong table KHACHHANG. Lỗi rồi!!!");
            }
        }

        private void FrmKhachHang_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dgvPRODUCT_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
