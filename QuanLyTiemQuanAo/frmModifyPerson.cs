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
    public partial class frmModifyPerson : DevExpress.XtraEditors.XtraForm, IConnectionForm
    {
        string username;
        string password;
        DB_Personal dbp;
        DataTable dtPersonal = null;

        string ConnStr;
        public void SetConnection(string connectString)
        {
            ConnStr = connectString;
            dbp = new DB_Personal(ConnStr);
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(ConnStr);
            username = builder.UserID;
            password = builder.Password;
        }
        public frmModifyPerson()
        {
            InitializeComponent();
        }
        void LoadData()
        {
            try
            {
                // Vận chuyển dữ liệu vào DataTable dtProduct
                dtPersonal = new DataTable();
                dtPersonal.Clear();
                dtPersonal = dbp.GetPersonInformation(username, password);
                DataRow r = dtPersonal.Rows[0];

                txt_full_name.Text = r[0].ToString();
                txt_gender.Text = r[1].ToString();
                txt_birthday.Text = r[2].ToString();
                txt_phone.Text = r[3].ToString();
                txt_employee_address.Text = r[4].ToString();
                txt_email.Text = r[5].ToString();
            }
            catch (SqlException e)
            {
                MessageBox.Show("Không lấy được nội dung trong table Employee. Lỗi rồi!!!" + e.Message);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            bool f = false;
            string err = "";
            try
            {
                f = dbp.UpdatePerson(ref err, txt_full_name.Text, txt_gender.Text,
                    txt_birthday.Text, txt_phone.Text,
                    txt_employee_address.Text, txt_email.Text);
            }
            catch (SqlException)
            {
                MessageBox.Show("Không cập nhật được. Lỗi rồi!");
            }
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

        private void frmModifyPerson_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}