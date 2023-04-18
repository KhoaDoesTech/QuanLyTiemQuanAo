namespace QuanLyTiemQuanAo
{
    partial class frmMonthSummary
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
            this.btnThem = new System.Windows.Forms.ToolStripButton();
            this.btnSua = new System.Windows.Forms.ToolStripButton();
            this.btnXoa = new System.Windows.Forms.ToolStripButton();
            this.btnLuu = new System.Windows.Forms.ToolStripButton();
            this.btnHuy = new System.Windows.Forms.ToolStripButton();
            this.btnThoat = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel = new DevExpress.XtraEditors.GroupControl();
            this.cb_summary_month = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_salary = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cb_summary_year = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_products_sold = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnTim = new System.Windows.Forms.Button();
            this.cbSearch = new System.Windows.Forms.ComboBox();
            this.txt_employee_id = new System.Windows.Forms.TextBox();
            this.txt_bonus_salary = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvMonthSummary = new System.Windows.Forms.DataGridView();
            this.employee_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.summary_month = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.summary_year = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.products_sold = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bonus_salary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.salary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panel)).BeginInit();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonthSummary)).BeginInit();
            this.SuspendLayout();
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
            // btnXoa
            // 
            this.btnXoa.Image = global::QuanLyTiemQuanAo.Properties.Resources.Trash_32x32;
            this.btnXoa.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(39, 44);
            this.btnXoa.Text = "Xoá";
            this.btnXoa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
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
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnThem,
            this.btnSua,
            this.btnXoa,
            this.btnLuu,
            this.btnHuy,
            this.btnThoat});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(927, 47);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
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
            this.splitContainer1.Panel2.Controls.Add(this.dgvMonthSummary);
            this.splitContainer1.Size = new System.Drawing.Size(927, 468);
            this.splitContainer1.SplitterDistance = 263;
            this.splitContainer1.TabIndex = 3;
            // 
            // panel
            // 
            this.panel.Controls.Add(this.cb_summary_month);
            this.panel.Controls.Add(this.label3);
            this.panel.Controls.Add(this.txt_salary);
            this.panel.Controls.Add(this.label6);
            this.panel.Controls.Add(this.cb_summary_year);
            this.panel.Controls.Add(this.label5);
            this.panel.Controls.Add(this.txt_products_sold);
            this.panel.Controls.Add(this.label1);
            this.panel.Controls.Add(this.label9);
            this.panel.Controls.Add(this.txtSearch);
            this.panel.Controls.Add(this.btnTim);
            this.panel.Controls.Add(this.cbSearch);
            this.panel.Controls.Add(this.txt_employee_id);
            this.panel.Controls.Add(this.txt_bonus_salary);
            this.panel.Controls.Add(this.label4);
            this.panel.Controls.Add(this.label2);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(927, 263);
            this.panel.TabIndex = 1;
            this.panel.Text = "Thông tin sản phẩm";
            this.panel.Paint += new System.Windows.Forms.PaintEventHandler(this.groupControl1_Paint);
            // 
            // cb_summary_month
            // 
            this.cb_summary_month.FormattingEnabled = true;
            this.cb_summary_month.Location = new System.Drawing.Point(175, 95);
            this.cb_summary_month.Name = "cb_summary_month";
            this.cb_summary_month.Size = new System.Drawing.Size(125, 24);
            this.cb_summary_month.TabIndex = 181;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(65, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 16);
            this.label3.TabIndex = 180;
            this.label3.Text = "Tháng";
            // 
            // txt_salary
            // 
            this.txt_salary.Location = new System.Drawing.Point(585, 130);
            this.txt_salary.Name = "txt_salary";
            this.txt_salary.Size = new System.Drawing.Size(140, 23);
            this.txt_salary.TabIndex = 179;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(435, 133);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 16);
            this.label6.TabIndex = 178;
            this.label6.Text = "Lương tổng";
            // 
            // cb_summary_year
            // 
            this.cb_summary_year.FormattingEnabled = true;
            this.cb_summary_year.Location = new System.Drawing.Point(175, 130);
            this.cb_summary_year.Name = "cb_summary_year";
            this.cb_summary_year.Size = new System.Drawing.Size(125, 24);
            this.cb_summary_year.TabIndex = 177;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(65, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 16);
            this.label5.TabIndex = 176;
            this.label5.Text = "Năm";
            // 
            // txt_products_sold
            // 
            this.txt_products_sold.Location = new System.Drawing.Point(585, 58);
            this.txt_products_sold.Name = "txt_products_sold";
            this.txt_products_sold.Size = new System.Drawing.Size(140, 23);
            this.txt_products_sold.TabIndex = 175;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(433, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 16);
            this.label1.TabIndex = 174;
            this.label1.Text = "Số sản phẩm bán được";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(198, 177);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 16);
            this.label9.TabIndex = 173;
            this.label9.Text = "Tìm kiếm";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(370, 174);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearch.Multiline = true;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(145, 24);
            this.txtSearch.TabIndex = 172;
            // 
            // btnTim
            // 
            this.btnTim.Location = new System.Drawing.Point(522, 172);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(75, 32);
            this.btnTim.TabIndex = 170;
            this.btnTim.Text = "Tìm";
            this.btnTim.UseVisualStyleBackColor = true;
            // 
            // cbSearch
            // 
            this.cbSearch.FormattingEnabled = true;
            this.cbSearch.Location = new System.Drawing.Point(261, 174);
            this.cbSearch.Margin = new System.Windows.Forms.Padding(4);
            this.cbSearch.Name = "cbSearch";
            this.cbSearch.Size = new System.Drawing.Size(101, 24);
            this.cbSearch.TabIndex = 171;
            // 
            // txt_employee_id
            // 
            this.txt_employee_id.Location = new System.Drawing.Point(175, 60);
            this.txt_employee_id.Name = "txt_employee_id";
            this.txt_employee_id.Size = new System.Drawing.Size(125, 23);
            this.txt_employee_id.TabIndex = 169;
            // 
            // txt_bonus_salary
            // 
            this.txt_bonus_salary.Location = new System.Drawing.Point(585, 93);
            this.txt_bonus_salary.Name = "txt_bonus_salary";
            this.txt_bonus_salary.Size = new System.Drawing.Size(140, 23);
            this.txt_bonus_salary.TabIndex = 168;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(434, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 16);
            this.label4.TabIndex = 167;
            this.label4.Text = "Lương cộng thêm";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 16);
            this.label2.TabIndex = 166;
            this.label2.Text = "Mã nhân viên";
            // 
            // dgvMonthSummary
            // 
            this.dgvMonthSummary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMonthSummary.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.employee_id,
            this.summary_month,
            this.summary_year,
            this.products_sold,
            this.bonus_salary,
            this.salary});
            this.dgvMonthSummary.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgvMonthSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMonthSummary.Location = new System.Drawing.Point(0, 0);
            this.dgvMonthSummary.Name = "dgvMonthSummary";
            this.dgvMonthSummary.RowHeadersWidth = 51;
            this.dgvMonthSummary.RowTemplate.Height = 24;
            this.dgvMonthSummary.Size = new System.Drawing.Size(927, 201);
            this.dgvMonthSummary.TabIndex = 130;
            // 
            // employee_id
            // 
            this.employee_id.DataPropertyName = "work_status";
            this.employee_id.HeaderText = "Mã nhân viên";
            this.employee_id.MinimumWidth = 6;
            this.employee_id.Name = "employee_id";
            this.employee_id.Width = 115;
            // 
            // summary_month
            // 
            this.summary_month.DataPropertyName = "summary_month";
            this.summary_month.HeaderText = "Tháng";
            this.summary_month.MinimumWidth = 6;
            this.summary_month.Name = "summary_month";
            this.summary_month.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.summary_month.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.summary_month.Width = 75;
            // 
            // summary_year
            // 
            this.summary_year.DataPropertyName = "summary_year";
            this.summary_year.HeaderText = "Năm";
            this.summary_year.MinimumWidth = 6;
            this.summary_year.Name = "summary_year";
            this.summary_year.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.summary_year.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.summary_year.Width = 75;
            // 
            // products_sold
            // 
            this.products_sold.DataPropertyName = "products_sold";
            this.products_sold.HeaderText = "Số sản phẩm bán được";
            this.products_sold.MinimumWidth = 6;
            this.products_sold.Name = "products_sold";
            this.products_sold.Width = 175;
            // 
            // bonus_salary
            // 
            this.bonus_salary.DataPropertyName = "bonus_salary";
            this.bonus_salary.HeaderText = "Lương cộng thêm";
            this.bonus_salary.MinimumWidth = 6;
            this.bonus_salary.Name = "bonus_salary";
            this.bonus_salary.Width = 150;
            // 
            // salary
            // 
            this.salary.DataPropertyName = "salary";
            this.salary.HeaderText = "Lương tổng";
            this.salary.MinimumWidth = 6;
            this.salary.Name = "salary";
            this.salary.Width = 150;
            // 
            // frmMonthSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(927, 515);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmMonthSummary";
            this.Text = "Danh mục lương nhân viên";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panel)).EndInit();
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonthSummary)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripButton btnThem;
        private System.Windows.Forms.ToolStripButton btnSua;
        private System.Windows.Forms.ToolStripButton btnXoa;
        private System.Windows.Forms.ToolStripButton btnLuu;
        private System.Windows.Forms.ToolStripButton btnHuy;
        private System.Windows.Forms.ToolStripButton btnThoat;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevExpress.XtraEditors.GroupControl panel;
        private System.Windows.Forms.ComboBox cb_summary_month;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_salary;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cb_summary_year;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_products_sold;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.ComboBox cbSearch;
        private System.Windows.Forms.TextBox txt_employee_id;
        private System.Windows.Forms.TextBox txt_bonus_salary;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvMonthSummary;
        private System.Windows.Forms.DataGridViewTextBoxColumn employee_id;
        private System.Windows.Forms.DataGridViewComboBoxColumn summary_month;
        private System.Windows.Forms.DataGridViewComboBoxColumn summary_year;
        private System.Windows.Forms.DataGridViewTextBoxColumn products_sold;
        private System.Windows.Forms.DataGridViewTextBoxColumn bonus_salary;
        private System.Windows.Forms.DataGridViewTextBoxColumn salary;
    }
}