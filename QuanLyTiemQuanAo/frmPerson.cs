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
    public partial class frmPerson : DevExpress.XtraEditors.XtraForm, IConnectionForm
    {
        string ConnStr;
        string username;
        string password;
        DB_Personal dbp;
        DataTable dtPersonal = null;
        
        public frmPerson()
        {
            InitializeComponent();
        }
        public void SetConnection(string connectString)
        {
            ConnStr = connectString;
            dbp = new DB_Personal(ConnStr);
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(ConnStr);
            username = builder.UserID;
            password = builder.Password;            
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
                txt_job_title_name.Text = r[6].ToString();
                txt_branch_name.Text = r[7].ToString();
                txt_base_salary.Text = r[8].ToString();
            }
            catch (SqlException e)
            {
                MessageBox.Show("Không lấy được nội dung trong table KHACHHANG. Lỗi rồi!!!" + e.Message);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPerson_Load(object sender, EventArgs e)
        {
            txt_full_name.Enabled= false;
            txt_gender.Enabled= false;
            txt_birthday.Enabled = false;
            txt_phone.Enabled = false;
            txt_employee_address.Enabled = false;
            txt_email.Enabled = false;
            txt_job_title_name.Enabled = false;
            txt_branch_name.Enabled = false;
            txt_base_salary.Enabled = false;
            LoadData();
        }

        private void txt_full_name_TextChanged(object sender, EventArgs e)
        {

        }
    }
}