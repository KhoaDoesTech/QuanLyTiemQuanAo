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
    public partial class frmHistoryPurchase : DevExpress.XtraEditors.XtraForm, IConnectionForm
    {
        DB_PurchaseOrder dbpo;
        DataTable dtPurchaseOrder = null;

        string ConnStr;
        public void SetConnection(string connectionString)
        {
            ConnStr = connectionString;
            dbpo = new DB_PurchaseOrder(ConnStr);
        }

        public frmHistoryPurchase()
        {
            InitializeComponent();
        }

        void LoadData()
        {
            try
            {
                // Vận chuyển dữ liệu vào DataTable dtEmployee
                dtPurchaseOrder = new DataTable();
                dtPurchaseOrder.Clear();
                dtPurchaseOrder = dbpo.GetPurchaseOrder();

                MoHienThi();

                // Đưa dữ liệu lên DataGridView 
                dgvPurchaseOrder.DataSource = dtPurchaseOrder;
            }
            catch (SqlException e)
            {
                MessageBox.Show("Không lấy được nội dung trong table PurchaseOrder. Lỗi rồi!!!" + e.Message);
            }
        }

        private void KhoaHienThi()
        {
            btnThoat.Visible = false;
        }
        private void MoHienThi()
        {
            btnThoat.Visible = true;
            dgvPurchaseOrder.Enabled = true;
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            // Khai báo biến answer 
            DialogResult answer;
            // Hiện hộp thoại hỏi đáp 
            answer = MessageBox.Show("Chắc không?", "Trả lời",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            // Kiểm tra có nhấp chọn nút Ok không? 
            if (answer == DialogResult.OK) this.Close();
        }

        private void frmHistoryPurchase_Load(object sender, EventArgs e)
        {
            // Nội dung tìm
            cbSearch.Items.Add("Mã đơn hàng");
            cbSearch.Items.Add("Mã khách hàng");
            cbSearch.Items.Add("Mã chi nhánh");
            cbSearch.Items.Add("Mã nhân viên");
            cbSearch.Items.Add("Mã sự kiện");
            cbSearch.Text = cbSearch.Items[0].ToString();

            LoadData();
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

                int x = cbSearch.SelectedIndex;
                switch (x)
                {
                    case 0:
                        dt = dbpo.FindOrderByID(txtSearch.Text);
                        dgvPurchaseOrder.DataSource = dt;
                        break;
                    case 1:
                        dt = dbpo.FindOrderByCustomer(txtSearch.Text);
                        dgvPurchaseOrder.DataSource = dt;
                        break;
                    case 2:
                        dt = dbpo.FindOrderByBranch(txtSearch.Text);
                        dgvPurchaseOrder.DataSource = dt;
                        break;
                    case 3:
                        dt = dbpo.FindOrderByEmployee(txtSearch.Text);
                        dgvPurchaseOrder.DataSource = dt;
                        break;
                    case 4:
                        dt = dbpo.FindOrderByEvent(txtSearch.Text);
                        dgvPurchaseOrder.DataSource = dt;
                        break;
                }
            }
        }

        private void dgvPurchaseOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Thứ tự dòng hiện hành 
            int r = dgvPurchaseOrder.CurrentCell.RowIndex;

            // Vận chuyển dữ liệu vào DataTable dtEmployee
            DataTable dtOrderDetail = new DataTable();
            dtOrderDetail.Clear();
            dtOrderDetail = dbpo.GetOrderDetail(dgvPurchaseOrder.Rows[r].Cells[0].Value.ToString());

            MoHienThi();

            // Đưa dữ liệu lên DataGridView 
            dgvOrderDetail.DataSource = dtOrderDetail;
        }
    }
}