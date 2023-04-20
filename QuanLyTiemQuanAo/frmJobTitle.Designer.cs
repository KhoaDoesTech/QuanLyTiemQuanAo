namespace QuanLyTiemQuanAo
{
    partial class frmJobTitle
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
            this.btnXoa = new System.Windows.Forms.ToolStripButton();
            this.btnLuu = new System.Windows.Forms.ToolStripButton();
            this.btnHuy = new System.Windows.Forms.ToolStripButton();
            this.btnThoat = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel = new DevExpress.XtraEditors.GroupControl();
            this.txt_job_title_name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnTim = new System.Windows.Forms.Button();
            this.cbSearch = new System.Windows.Forms.ComboBox();
            this.txt_job_title_id = new System.Windows.Forms.TextBox();
            this.txt_job_description = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvJobTitle = new System.Windows.Forms.DataGridView();
            this.job_title_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.job_title_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.job_description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panel)).BeginInit();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJobTitle)).BeginInit();
            this.SuspendLayout();
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
            this.toolStrip1.Size = new System.Drawing.Size(806, 47);
            this.toolStrip1.TabIndex = 2;
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
            this.splitContainer1.Panel2.Controls.Add(this.dgvJobTitle);
            this.splitContainer1.Size = new System.Drawing.Size(806, 434);
            this.splitContainer1.SplitterDistance = 167;
            this.splitContainer1.TabIndex = 3;
            // 
            // panel
            // 
            this.panel.Controls.Add(this.txt_job_title_name);
            this.panel.Controls.Add(this.label1);
            this.panel.Controls.Add(this.label9);
            this.panel.Controls.Add(this.txtSearch);
            this.panel.Controls.Add(this.btnTim);
            this.panel.Controls.Add(this.cbSearch);
            this.panel.Controls.Add(this.txt_job_title_id);
            this.panel.Controls.Add(this.txt_job_description);
            this.panel.Controls.Add(this.label4);
            this.panel.Controls.Add(this.label2);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(806, 167);
            this.panel.TabIndex = 3;
            this.panel.Text = "Thông tin chức danh công việc";
            // 
            // txt_job_title_name
            // 
            this.txt_job_title_name.Location = new System.Drawing.Point(181, 83);
            this.txt_job_title_name.Name = "txt_job_title_name";
            this.txt_job_title_name.Size = new System.Drawing.Size(191, 23);
            this.txt_job_title_name.TabIndex = 175;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 16);
            this.label1.TabIndex = 174;
            this.label1.Text = "Tên chức danh công việc";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(396, 51);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 16);
            this.label9.TabIndex = 173;
            this.label9.Text = "Tìm kiếm";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(568, 48);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearch.Multiline = true;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(145, 24);
            this.txtSearch.TabIndex = 172;
            // 
            // btnTim
            // 
            this.btnTim.Location = new System.Drawing.Point(720, 46);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(75, 32);
            this.btnTim.TabIndex = 170;
            this.btnTim.Text = "Tìm";
            this.btnTim.UseVisualStyleBackColor = true;
            // 
            // cbSearch
            // 
            this.cbSearch.FormattingEnabled = true;
            this.cbSearch.Location = new System.Drawing.Point(459, 48);
            this.cbSearch.Margin = new System.Windows.Forms.Padding(4);
            this.cbSearch.Name = "cbSearch";
            this.cbSearch.Size = new System.Drawing.Size(101, 24);
            this.cbSearch.TabIndex = 171;
            // 
            // txt_job_title_id
            // 
            this.txt_job_title_id.Location = new System.Drawing.Point(181, 46);
            this.txt_job_title_id.Name = "txt_job_title_id";
            this.txt_job_title_id.Size = new System.Drawing.Size(191, 23);
            this.txt_job_title_id.TabIndex = 169;
            // 
            // txt_job_description
            // 
            this.txt_job_description.Location = new System.Drawing.Point(181, 119);
            this.txt_job_description.Name = "txt_job_description";
            this.txt_job_description.Size = new System.Drawing.Size(191, 23);
            this.txt_job_description.TabIndex = 168;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 16);
            this.label4.TabIndex = 167;
            this.label4.Text = "Miêu tả công việc";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 16);
            this.label2.TabIndex = 166;
            this.label2.Text = "Mã chức danh công việc";
            // 
            // dgvJobTitle
            // 
            this.dgvJobTitle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvJobTitle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.job_title_id,
            this.job_title_name,
            this.job_description});
            this.dgvJobTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvJobTitle.Location = new System.Drawing.Point(0, 0);
            this.dgvJobTitle.Name = "dgvJobTitle";
            this.dgvJobTitle.RowHeadersWidth = 51;
            this.dgvJobTitle.RowTemplate.Height = 24;
            this.dgvJobTitle.Size = new System.Drawing.Size(806, 263);
            this.dgvJobTitle.TabIndex = 3;
            this.dgvJobTitle.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvJobTitle_CellClick);
            // 
            // job_title_id
            // 
            this.job_title_id.DataPropertyName = "job_title_id";
            this.job_title_id.HeaderText = "Mã chức danh công việc";
            this.job_title_id.MinimumWidth = 6;
            this.job_title_id.Name = "job_title_id";
            this.job_title_id.Width = 120;
            // 
            // job_title_name
            // 
            this.job_title_name.DataPropertyName = "job_title_name";
            this.job_title_name.HeaderText = "Tên chức danh công việc";
            this.job_title_name.MinimumWidth = 180;
            this.job_title_name.Name = "job_title_name";
            this.job_title_name.Width = 180;
            // 
            // job_description
            // 
            this.job_description.DataPropertyName = "job_description";
            this.job_description.HeaderText = "Miêu tả công việc";
            this.job_description.MinimumWidth = 450;
            this.job_description.Name = "job_description";
            this.job_description.Width = 450;
            // 
            // frmJobTitle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 481);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmJobTitle";
            this.Text = "frmJobTitle";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panel)).EndInit();
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJobTitle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnThem;
        private System.Windows.Forms.ToolStripButton btnSua;
        private System.Windows.Forms.ToolStripButton btnXoa;
        private System.Windows.Forms.ToolStripButton btnLuu;
        private System.Windows.Forms.ToolStripButton btnHuy;
        private System.Windows.Forms.ToolStripButton btnThoat;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvJobTitle;
        private DevExpress.XtraEditors.GroupControl panel;
        private System.Windows.Forms.TextBox txt_job_title_name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.ComboBox cbSearch;
        private System.Windows.Forms.TextBox txt_job_title_id;
        private System.Windows.Forms.TextBox txt_job_description;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn job_title_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn job_title_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn job_description;
    }
}