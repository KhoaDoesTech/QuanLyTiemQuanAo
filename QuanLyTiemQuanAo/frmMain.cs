using DevExpress.XtraBars;
using DevExpress.XtraLayout.Utils;
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

            ribbonPageGroup1.Visible = true;
            ribbonPage2.Visible = true;
            ribbonPage3.Visible = true;
            ribbonPage4.Visible = true;
            ribbonPage5.Visible = true;
            barButtonItem45.Visibility = BarItemVisibility.Always;
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
            //ribbonPage3.Visible = true;
            //ribbonPage2.Visible = true;
            //ribbonPage4.Visible = true;
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

        private void barButtonItem33_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(typeof(frmBussiness));
        }

        private void barButtonItem29_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(typeof(frmCurrentDiscount));
        }

        private void barButtonItem23_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(typeof(frmDiscount));
        }

        private void barButtonItem34_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(typeof(frmStatisticsEmployee));
        }

        private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(typeof(frmStock));
        }

        private void barButtonItem28_ItemClick(object sender, ItemClickEventArgs e)
        {
            openViewForm(typeof(frmView), 2);
        }

        private void barButtonItem8_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(typeof(frmStockImport));
        }

        private void barButtonItem9_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(typeof(frmStockTransfer));
        }

        private void barButtonItem19_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(typeof(frmAccount));
        }

        private void barButtonItem24_ItemClick(object sender, ItemClickEventArgs e)
        {
            //openForm(typeof(frmHistoryPurchase));
        }

        private void btnSuaThongTin_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(typeof(frmModifyPerson));
        }

        private void btnSuaMatKhau_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(typeof(frmChangePass));
        }

        private void barButtonItem35_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(typeof(frmStatisticsCustomer));
        }

        private void barButtonItem36_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barButtonItem43_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barButtonItem44_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(typeof(frmLogin));
        }

        private void barButtonItem45_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmLogin login = new frmLogin();
            this.Hide();
            login.Show();
        }
    }
}