namespace QuanLyTiemQuanAo
{
    partial class frmJob
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnThem = new System.Windows.Forms.ToolStripButton();
            this.btnSua = new System.Windows.Forms.ToolStripButton();
            this.btnLuu = new System.Windows.Forms.ToolStripButton();
            this.btnHuy = new System.Windows.Forms.ToolStripButton();
            this.btnThoat = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel = new DevExpress.XtraEditors.GroupControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txt_branch_id = new System.Windows.Forms.TextBox();
            this.txt_job_title_id = new System.Windows.Forms.TextBox();
            this.txt_job_name = new System.Windows.Forms.TextBox();
            this.txt_job_id = new System.Windows.Forms.TextBox();
            this.txt_base_salary = new System.Windows.Forms.TextBox();
            this.cbSearch = new System.Windows.Forms.ComboBox();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.dgvJob = new System.Windows.Forms.DataGridView();
            this.job_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.job_title_id = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.branch_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.job_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.base_salary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnTim = new DevExpress.XtraEditors.SimpleButton();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panel)).BeginInit();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJob)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnThem,
            this.btnSua,
            this.btnLuu,
            this.btnHuy,
            this.btnThoat});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(898, 47);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnThem
            // 
            this.btnThem.Image = global::QuanLyTiemQuanAo.Properties.Resources.Add_32x32;
            this.btnThem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(50, 44);
            this.btnThem.Text = "Thêm";
            this.btnThem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Image = global::QuanLyTiemQuanAo.Properties.Resources.Edit_32x32;
            this.btnSua.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(38, 44);
            this.btnSua.Text = "Sửa";
            this.btnSua.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Image = global::QuanLyTiemQuanAo.Properties.Resources.Save_32x32;
            this.btnLuu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(37, 44);
            this.btnLuu.Text = "Lưu";
            this.btnLuu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Image = global::QuanLyTiemQuanAo.Properties.Resources.Undo_32x32;
            this.btnHuy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(60, 44);
            this.btnHuy.Text = "Bỏ qua";
            this.btnHuy.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Image = global::QuanLyTiemQuanAo.Properties.Resources.Action_Close_32x32;
            this.btnThoat.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(51, 44);
            this.btnThoat.Text = "Thoát";
            this.btnThoat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 47);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvJob);
            this.splitContainer1.Size = new System.Drawing.Size(898, 443);
            this.splitContainer1.SplitterDistance = 228;
            this.splitContainer1.TabIndex = 4;
            // 
            // panel
            // 
            this.panel.Controls.Add(this.layoutControl1);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(898, 228);
            this.panel.TabIndex = 1;
            this.panel.Text = "Thông tin công việc";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.simpleButton1);
            this.layoutControl1.Controls.Add(this.textBox1);
            this.layoutControl1.Controls.Add(this.txt_branch_id);
            this.layoutControl1.Controls.Add(this.txt_job_title_id);
            this.layoutControl1.Controls.Add(this.txt_job_name);
            this.layoutControl1.Controls.Add(this.txt_job_id);
            this.layoutControl1.Controls.Add(this.txt_base_salary);
            this.layoutControl1.Controls.Add(this.cbSearch);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(2, 28);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(786, 0, 812, 500);
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(894, 198);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // simpleButton1
            // 
            this.simpleButton1.ImageOptions.Image = global::QuanLyTiemQuanAo.Properties.Resources.Search_16x16;
            this.simpleButton1.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.simpleButton1.Location = new System.Drawing.Point(444, 71);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(438, 27);
            this.simpleButton1.StyleController = this.layoutControl1;
            this.simpleButton1.TabIndex = 188;
            this.simpleButton1.Text = "Tìm";
            this.simpleButton1.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(692, 41);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(190, 26);
            this.textBox1.TabIndex = 187;
            // 
            // txt_branch_id
            // 
            this.txt_branch_id.Location = new System.Drawing.Point(161, 70);
            this.txt_branch_id.Name = "txt_branch_id";
            this.txt_branch_id.Size = new System.Drawing.Size(279, 25);
            this.txt_branch_id.TabIndex = 184;
            // 
            // txt_job_title_id
            // 
            this.txt_job_title_id.Location = new System.Drawing.Point(161, 41);
            this.txt_job_title_id.Name = "txt_job_title_id";
            this.txt_job_title_id.Size = new System.Drawing.Size(279, 25);
            this.txt_job_title_id.TabIndex = 183;
            // 
            // txt_job_name
            // 
            this.txt_job_name.Location = new System.Drawing.Point(593, 12);
            this.txt_job_name.Name = "txt_job_name";
            this.txt_job_name.Size = new System.Drawing.Size(289, 25);
            this.txt_job_name.TabIndex = 181;
            // 
            // txt_job_id
            // 
            this.txt_job_id.Location = new System.Drawing.Point(161, 12);
            this.txt_job_id.Name = "txt_job_id";
            this.txt_job_id.Size = new System.Drawing.Size(279, 25);
            this.txt_job_id.TabIndex = 171;
            // 
            // txt_base_salary
            // 
            this.txt_base_salary.Location = new System.Drawing.Point(161, 99);
            this.txt_base_salary.Name = "txt_base_salary";
            this.txt_base_salary.Size = new System.Drawing.Size(279, 25);
            this.txt_base_salary.TabIndex = 186;
            // 
            // cbSearch
            // 
            this.cbSearch.FormattingEnabled = true;
            this.cbSearch.Location = new System.Drawing.Point(593, 41);
            this.cbSearch.Margin = new System.Windows.Forms.Padding(4);
            this.cbSearch.Name = "cbSearch";
            this.cbSearch.Size = new System.Drawing.Size(95, 24);
            this.cbSearch.TabIndex = 183;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.emptySpaceItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.layoutControlItem9});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(894, 198);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txt_job_id;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(432, 29);
            this.layoutControlItem1.Text = "Mã công việc";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(137, 16);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 116);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(874, 62);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txt_job_name;
            this.layoutControlItem2.Location = new System.Drawing.Point(432, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(442, 29);
            this.layoutControlItem2.Text = "Tên công việc";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(137, 16);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txt_job_title_id;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 29);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(432, 29);
            this.layoutControlItem3.Text = "Mã chức danh công việc";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(137, 16);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txt_branch_id;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 58);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(432, 29);
            this.layoutControlItem4.Text = "Mã chi nhánh";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(137, 16);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.cbSearch;
            this.layoutControlItem5.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.layoutControlItem5.CustomizationFormText = "Tìm kiếm";
            this.layoutControlItem5.Location = new System.Drawing.Point(432, 29);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(248, 30);
            this.layoutControlItem5.Text = "Tìm kiếm";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(137, 16);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.textBox1;
            this.layoutControlItem6.Location = new System.Drawing.Point(680, 29);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(194, 30);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.simpleButton1;
            this.layoutControlItem7.Location = new System.Drawing.Point(432, 59);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(442, 57);
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.txt_base_salary;
            this.layoutControlItem9.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.layoutControlItem9.CustomizationFormText = "Lương cơ bản";
            this.layoutControlItem9.Location = new System.Drawing.Point(0, 87);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(432, 29);
            this.layoutControlItem9.Text = "Lương cơ bản";
            this.layoutControlItem9.TextSize = new System.Drawing.Size(137, 16);
            // 
            // dgvJob
            // 
            this.dgvJob.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvJob.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.job_id,
            this.job_title_id,
            this.branch_id,
            this.job_name,
            this.base_salary});
            this.dgvJob.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvJob.Location = new System.Drawing.Point(0, 0);
            this.dgvJob.Name = "dgvJob";
            this.dgvJob.RowHeadersWidth = 51;
            this.dgvJob.RowTemplate.Height = 24;
            this.dgvJob.Size = new System.Drawing.Size(898, 211);
            this.dgvJob.TabIndex = 4;
            this.dgvJob.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvJob_CellClick);
            // 
            // job_id
            // 
            this.job_id.DataPropertyName = "job_id";
            this.job_id.HeaderText = "Mã công việc";
            this.job_id.MinimumWidth = 6;
            this.job_id.Name = "job_id";
            this.job_id.Width = 125;
            // 
            // job_title_id
            // 
            this.job_title_id.DataPropertyName = "job_title_id";
            this.job_title_id.HeaderText = "Mã chức danh công việc";
            this.job_title_id.MinimumWidth = 6;
            this.job_title_id.Name = "job_title_id";
            this.job_title_id.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.job_title_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.job_title_id.Width = 125;
            // 
            // branch_id
            // 
            this.branch_id.DataPropertyName = "branch_id";
            this.branch_id.HeaderText = "Mã chi nhánh";
            this.branch_id.MinimumWidth = 6;
            this.branch_id.Name = "branch_id";
            this.branch_id.Width = 125;
            // 
            // job_name
            // 
            this.job_name.DataPropertyName = "job_name";
            this.job_name.HeaderText = "Tên công việc";
            this.job_name.MinimumWidth = 150;
            this.job_name.Name = "job_name";
            this.job_name.Width = 150;
            // 
            // base_salary
            // 
            this.base_salary.DataPropertyName = "base_salary";
            this.base_salary.HeaderText = "Lương cơ bản";
            this.base_salary.MinimumWidth = 6;
            this.base_salary.Name = "base_salary";
            this.base_salary.Width = 125;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(759, 70);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearch.Multiline = true;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(171, 27);
            this.txtSearch.TabIndex = 184;
            // 
            // btnTim
            // 
            this.btnTim.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnTim.Location = new System.Drawing.Point(934, 70);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(95, 27);
            this.btnTim.TabIndex = 185;
            this.btnTim.Text = "Tìm";
            // 
            // frmJob
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 490);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmJob";
            this.Text = "frmJob";
            this.Load += new System.EventHandler(this.frmJob_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panel)).EndInit();
            this.panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJob)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnThem;
        private System.Windows.Forms.ToolStripButton btnSua;
        private System.Windows.Forms.ToolStripButton btnLuu;
        private System.Windows.Forms.ToolStripButton btnHuy;
        private System.Windows.Forms.ToolStripButton btnThoat;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvJob;
        private System.Windows.Forms.TextBox txtSearch;
        private DevExpress.XtraEditors.SimpleButton btnTim;
        private DevExpress.XtraEditors.GroupControl panel;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txt_branch_id;
        private System.Windows.Forms.TextBox txt_job_title_id;
        private System.Windows.Forms.TextBox txt_job_name;
        private System.Windows.Forms.TextBox txt_job_id;
        private System.Windows.Forms.TextBox txt_base_salary;
        private System.Windows.Forms.ComboBox cbSearch;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private System.Windows.Forms.DataGridViewTextBoxColumn job_id;
        private System.Windows.Forms.DataGridViewComboBoxColumn job_title_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn branch_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn job_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn base_salary;
    }
}