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
using System.Security.Claims;


namespace QuanLyTiemQuanAo
{
    public partial class frmStatisticsCustomer : DevExpress.XtraEditors.XtraForm, IConnectionForm
    {
        DB_Branch dbb;
        DataTable dtBranch = null;

        DB_StatisticsCustomer dbsc;
        DataTable dtStatisticsCustomer = null;
        string ConnStr;

        public void SetConnection(string connectString)
        {
            ConnStr = connectString;
            dbb = new DB_Branch(ConnStr);
            dbsc = new DB_StatisticsCustomer(ConnStr);
        }
        public frmStatisticsCustomer()
        {
            InitializeComponent();
        }
        void LoadData()
        {
            try
            {
                // Vận chuyển dữ liệu vào DataTable dtBranch
                dtBranch = new DataTable();
                dtBranch.Clear();
                dtBranch = dbb.GetBranch();
                //Đưa dữ liệu lên ComboBox Chi nhánh
                DataRow newRow = dtBranch.NewRow();
                newRow["branch_id"] = "Tất cả";
                newRow["branch_name"] = "Tất cả";
                dtBranch.Rows.InsertAt(newRow, 0);
                cb_Branch.DataSource = dtBranch;
                cb_Branch.DisplayMember = "branch_name";
                cb_Branch.ValueMember = "branch_id";
                cb_Branch.Text = "Tất cả";

                cb_Properties.Items.Add("Số đơn hàng");
                cb_Properties.Items.Add("Giới tính");
                cb_Properties.Items.Add("Độ tuổi");
                cb_Properties.Items.Add("Loại khách hàng");
                cb_Properties.Text = cb_Properties.Items[0].ToString();

                dtStatisticsCustomer = new DataTable();
                dtStatisticsCustomer = dbsc.GetStatisticsOrder();
                dgvCustomer.DataSource = dtStatisticsCustomer;
            }
            catch
            {
                MessageBox.Show("Không lấy được nội dung trong table Customer. Lỗi rồi!!!");
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

        private void frmStatisticsCustomer_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
       
