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

        void openViewForm(Type typeForm, int viewForm)
        {
            foreach (var frm in MdiChildren)
            {
                if (frm.GetType() == typeForm)
                {
                    frm.Activate();
                    return;
                }
            }
            Form f = (Form)Activator.CreateInstance(typeForm);
            if (f is IConnectionForm connectionForm)
            {
                connectionForm.SetConnection(ConnStr);
                f.Text = viewForm.ToString();
            }
            f.MdiParent = this;
            f.Show();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void barButtonItem27_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(typeof(frmPurchaseOrder));
        }

        private void barButtonItem14_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(typeof(frmEmployee));
        }

        private void barButtonItem18_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(typeof(frmMonthSummary));
        }

        private void barButtonItem15_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(typeof(frmJob));
        }

        private void barButtonItem16_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(typeof(frmJobTitle));
        }

        private void barButtonItem21_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(typeof(frmBranch));
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(typeof(frmProduct));
        }

        private void barButtonItem10_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(typeof(frmProductType));
        }

        private void barButtonItem22_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(typeof(frmEvent));
        }

        private void barButtonItem25_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(typeof(frmCustomer));
        }

        private void barButtonItem26_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(typeof(frmCustomerType));
        }

        private void btnXemThongTin_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(typeof(frmPerson));
        }
    }
}