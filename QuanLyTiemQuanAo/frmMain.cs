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
        public frmMain()
        {
            InitializeComponent();
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
            frmOrder frm = new frmOrder();
            frm.MdiParent = this;
            frm.Show();
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmEmployee frm = new frmEmployee();
            frm.MdiParent = this;
            frm.Show();
        }

        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmMonthSummary frm = new frmMonthSummary();
            frm.MdiParent = this;
            frm.Show();
        }

        private void barButtonItem6_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            frmOrder frm = new frmOrder();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}