using DevExpress.XtraBars;
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
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        string ConnStr;
        public frmMain(string strConnect_local)
        {
            InitializeComponent();
            ConnStr = strConnect_local;
        }

        void openForm(Type typeForm)
        {
            foreach(var frm in MdiChildren)
            {
                if(frm.GetType() == typeForm)
                {
                    frm.Activate();
                    return;
                }
            }
            Form f = (Form)Activator.CreateInstance(typeForm);
            if (f is IConnectionForm connectionForm)
            {
                connectionForm.SetConnection(ConnStr);
            }
            f.MdiParent = this;
            f.Show();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(typeof(frmProduct));
        }

        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(typeof(frmOrder));
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(typeof(frmEmployee));
        }

        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(typeof(frmMonthSummary));
        }

        private void barButtonItem6_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            openForm(typeof(frmOrder));
        }

        private void barButtonItem10_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(typeof(frmProductType));
        }
    }
}