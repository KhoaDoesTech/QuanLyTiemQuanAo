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
    public partial class frmView : DevExpress.XtraEditors.XtraForm, IConnectionForm
    {        
        string ConnStr;
        DB_Stock dbs;
        DataTable dtStock = null;
        
        string username;
        string password;
        DB_Personal dbp;
        DataTable dtPersonal = null;

        int intDM;
        public frmView()
        {
            InitializeComponent();
        }
        public void SetConnection(string connectString)
        {
            ConnStr = connectString;
            dbs = new DB_Stock(connectString);
            dbp = new DB_Personal(ConnStr);
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(ConnStr);
            username = builder.UserID;
            password = builder.Password;
        }
        void LoadData()
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmView_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dtTable = new DataTable();
                // Xử lý danh mục 
                intDM = Convert.ToInt32(this.Text);
                switch (intDM)
                {
                    case 1:
                        this.Text = "Kho hàng";
                        dtTable = dbs.GetStock();
                        break;
                    case 2:
                        this.Text = "Sản phẩm";

                        break;
                    default:
                        break;
                }           
                dgvDANHMUC.DataSource = dtTable;
                // Thay đổi độ rộng cột 
                dgvDANHMUC.AutoResizeColumns();
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong table. Lỗi rồi!!!");

            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}