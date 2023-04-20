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

namespace QuanLyTiemQuanAo
{
    public partial class frmOrder : DevExpress.XtraEditors.XtraForm
    {
        string ConnStr;
        public void SetConnection(string connectString)
        {
            ConnStr = connectString;
        }
        public frmOrder()
        {
            InitializeComponent();
        }

        private void dgvOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnTim_Click(object sender, EventArgs e)
        {

        }
    }
}