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
    public partial class frmEvent : DevExpress.XtraEditors.XtraForm, IConnectionForm
    {
        string ConnStr;
        DB_Event dbe;
        DataTable dtEvent = null;

        bool Them;

        public void SetConnection(string connectString)
        {
            ConnStr = connectString;
            dbe = new DB_Event(ConnStr);
        }
        public frmEvent()
        {
            InitializeComponent();
        }
        void LoadData()
        {
            try
            {
                // Vận chuyển dữ liệu vào DataTable dtEvent
                dtEvent = new DataTable();
                dtEvent.Clear();
                dtEvent = dbe.GetEvent();
                // Vận chuyển dữ liệu vào DataTable dtEvent
                dtEvent = new DataTable();
                dtEvent.Clear();
                dtEvent = dbe.GetEvent();

                MoHienThi();
                KhoaTuongTac();

                // Đưa dữ liệu lên DataGridView 
                dgvEvent.DataSource = dtEvent;

                dgvEvent_CellClick(null, null);
            }
            catch (SqlException e)
            {
                MessageBox.Show("Không lấy được nội dung trong table Event. Lỗi rồi!!!" + e.Message);
            }
        }
        private void KhoaHienThi()
        {
            btnThem.Visible = false;
            btnSua.Visible = false;

            btnLuu.Visible = true;
            btnHuy.Visible = true;
            btnThoat.Visible = false;
        }
        private void MoHienThi()
        {
            btnThem.Visible = true;
            btnSua.Visible = true;

            btnLuu.Visible = false;
            btnHuy.Visible = false;
            btnThoat.Visible = true;

        }
        private void XoaTrong()
        {
            txt_event_id.ResetText();
            txt_event_name.ResetText();
            dtp_date_start.ResetText();
            dtp_date_end.ResetText();
            txtSearch.ResetText();
        }
        private void MoTuongTac()
        {
            txt_event_id.Enabled = false;
            txt_event_name.Enabled = true;
            dtp_date_start.Enabled = true;
            dtp_date_end.Enabled = true;
        }
        private void KhoaTuongTac()
        {
            txt_event_id.Enabled = false;
            txt_event_name.Enabled = true;
            dtp_date_start.Enabled = true;
            dtp_date_end.Enabled = true;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            KhoaHienThi();
            XoaTrong();
            MoTuongTac();
            txt_event_name.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kích hoạt biến Sửa 
            Them = false;
            MoTuongTac();
            dgvEvent_CellClick(null, null);
            KhoaHienThi();
            txt_event_name.Focus();
        }

    

        private void btnLuu_Click(object sender, EventArgs e)
        {
            bool f = false;
            if (Them)
            {
                string err = "";
                try
                {
                    f = dbe.InsertEvent(ref err, txt_event_name.Text,
                        DateTime.Parse(dtp_date_start.Text.ToString()), DateTime.Parse(dtp_date_end.Text.ToString()));
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
            if (!Them)
            {
                string err = "";
                try
                {
                    f = dbe.UpdateEvent(ref err,txt_event_id.Text ,txt_event_name.Text,
                        DateTime.Parse(dtp_date_start.Text.ToString()), DateTime.Parse(dtp_date_end.Text.ToString()));
                    if (f)
                    {
                        // Load lại dữ liệu trên DataGridView 
                        LoadData();
                        // Thông báo 
                        MessageBox.Show("Đã cập nhật xong!");
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật chưa xong!\n\r" + "Lỗi:" + err);
                    }
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không cập nhật được. Lỗi rồi!");
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            MoHienThi();
            XoaTrong();
            KhoaTuongTac();
            dgvEvent_CellClick(null, null);
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
        private void dgvEvent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Thứ tự dòng hiện hành 
            int r = dgvEvent.CurrentCell.RowIndex;
            // Chuyển thông tin lên panel 
            txt_event_id.Text =
            dgvEvent.Rows[r].Cells[0].Value.ToString();
            txt_event_name.Text =
            dgvEvent.Rows[r].Cells[0].Value.ToString();
            dtp_date_start.Text =
            dgvEvent.Rows[r].Cells[4].Value.ToString();
            dtp_date_end.Text =
            dgvEvent.Rows[r].Cells[4].Value.ToString();
        }

        private void btn_Tim_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            //choose type to search
            dgvEvent.DataSource = dt;

            cbSearch.Items.Add("Mã sự kiện");
            cbSearch.Items.Add("Tên sự kiện");
            cbSearch.Text = cbSearch.Items[0].ToString();
            cbSearch.Text = cbSearch.Items[1].ToString();
            int x = cbSearch.SelectedIndex;
            switch (x)
            {
                case 1:
                    dt = dbe.FindEventByID(txtSearch.Text);
                    dgvEvent.DataSource = dt;
                    break;
                case 2:
                    dt = dbe.FindEventByName(txtSearch.Text);
                    dgvEvent.DataSource = dt;
                    break;
            }
        }
    }
}