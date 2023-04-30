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
using DevExpress.XtraEditors.TextEditController.Win32;

namespace QuanLyTiemQuanAo
{
    public partial class frmChangePass : DevExpress.XtraEditors.XtraForm, IConnectionForm
    {
        string ConnStr;
        string username;
        string password;
        DB_Personal dbp;
        DataTable dtPersonal = null;

        public frmChangePass()
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

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(dbp.CheckLogin(username, txt_passcodeold.Text.ToString()) && txt_passcodenew1.Text == txt_passcodenew2.Text)
            {
                string err = "";
                bool f = dbp.UpdateAccounts(ref err, username, txt_passcodeold.Text.ToString(), txt_passcodenew1.Text.ToString());
                if (f)
                {
                    MessageBox.Show("Đã thêm xong!");
                }
                else
                {
                    MessageBox.Show("Đã thêm chưa xong!\n\r" + "Lỗi:" + err);
                }
            }
            else
            {
                MessageBox.Show("Mật khẩu cũ hoặc mật khẩu mới không trùng hợp");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}