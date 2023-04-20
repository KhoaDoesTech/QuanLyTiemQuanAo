namespace QuanLyTiemQuanAo
{
    partial class frmBranch
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
            this.txt_rent_amount = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_branch_name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnTim = new System.Windows.Forms.Button();
            this.cbSearch = new System.Windows.Forms.ComboBox();
            this.txt_branch_id = new System.Windows.Forms.TextBox();
            this.txt_max_stock = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvBranch = new System.Windows.Forms.DataGridView();
            this.branch_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.branch_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.max_stock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rent_amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panel)).BeginInit();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBranch)).BeginInit();
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
            this.toolStrip1.Size = new System.Drawing.Size(887, 47);
            this.toolStrip1.TabIndex = 1;
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
            this.splitContainer1.Panel2.Controls.Add(this.dgvBranch);
            this.splitContainer1.Size = new System.Drawing.Size(887, 448);
            this.splitContainer1.SplitterDistance = 173;
            this.splitContainer1.TabIndex = 2;
            // 
            // panel
            // 
            this.panel.Controls.Add(this.txt_rent_amount);
            this.panel.Controls.Add(this.label6);
            this.panel.Controls.Add(this.txt_branch_name);
            this.panel.Controls.Add(this.label1);
            this.panel.Controls.Add(this.label9);
            this.panel.Controls.Add(this.txtSearch);
            this.panel.Controls.Add(this.btnTim);
            this.panel.Controls.Add(this.cbSearch);
            this.panel.Controls.Add(this.txt_branch_id);
            this.panel.Controls.Add(this.txt_max_stock);
            this.panel.Controls.Add(this.label4);
            this.panel.Controls.Add(this.label2);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(887, 173);
            this.panel.TabIndex = 2;
            this.panel.Text = "Thông tin chi nhánh";
            // 
            // txt_rent_amount
            // 
            this.txt_rent_amount.Location = new System.Drawing.Point(487, 38);
            this.txt_rent_amount.Name = "txt_rent_amount";
            this.txt_rent_amount.Size = new System.Drawing.Size(191, 23);
            this.txt_rent_amount.TabIndex = 179;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(421, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 16);
            this.label6.TabIndex = 178;
            this.label6.Text = "Giá thuê";
            // 
            // txt_branch_name
            // 
            this.txt_branch_name.Location = new System.Drawing.Point(176, 75);
            this.txt_branch_name.Name = "txt_branch_name";
            this.txt_branch_name.Size = new System.Drawing.Size(191, 23);
            this.txt_branch_name.TabIndex = 175;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 174;
            this.label1.Text = "Tên chi nhánh";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(423, 78);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 16);
            this.label9.TabIndex = 173;
            this.label9.Text = "Tìm kiếm";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(595, 75);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearch.Multiline = true;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(145, 24);
            this.txtSearch.TabIndex = 172;
            // 
            // btnTim
            // 
            this.btnTim.Location = new System.Drawing.Point(747, 73);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(75, 32);
            this.btnTim.TabIndex = 170;
            this.btnTim.Text = "Tìm";
            this.btnTim.UseVisualStyleBackColor = true;
            // 
            // cbSearch
            // 
            this.cbSearch.FormattingEnabled = true;
            this.cbSearch.Location = new System.Drawing.Point(486, 75);
            this.cbSearch.Margin = new System.Windows.Forms.Padding(4);
            this.cbSearch.Name = "cbSearch";
            this.cbSearch.Size = new System.Drawing.Size(101, 24);
            this.cbSearch.TabIndex = 171;
            // 
            // txt_branch_id
            // 
            this.txt_branch_id.Location = new System.Drawing.Point(176, 38);
            this.txt_branch_id.Name = "txt_branch_id";
            this.txt_branch_id.Size = new System.Drawing.Size(191, 23);
            this.txt_branch_id.TabIndex = 169;
            // 
            // txt_max_stock
            // 
            this.txt_max_stock.Location = new System.Drawing.Point(176, 111);
            this.txt_max_stock.Name = "txt_max_stock";
            this.txt_max_stock.Size = new System.Drawing.Size(191, 23);
            this.txt_max_stock.TabIndex = 168;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(50, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 16);
            this.label4.TabIndex = 167;
            this.label4.Text = "Trữ lượng tối đa";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 16);
            this.label2.TabIndex = 166;
            this.label2.Text = "Mã chi nhánh";
            // 
            // dgvBranch
            // 
            this.dgvBranch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBranch.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.branch_id,
            this.branch_name,
            this.max_stock,
            this.rent_amount});
            this.dgvBranch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBranch.Location = new System.Drawing.Point(0, 0);
            this.dgvBranch.Name = "dgvBranch";
            this.dgvBranch.RowHeadersWidth = 51;
            this.dgvBranch.RowTemplate.Height = 24;
            this.dgvBranch.Size = new System.Drawing.Size(887, 271);
            this.dgvBranch.TabIndex = 2;
            this.dgvBranch.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBranch_CellClick);
            // 
            // branch_id
            // 
            this.branch_id.DataPropertyName = "branch_id";
            this.branch_id.HeaderText = "Mã chi nhánh";
            this.branch_id.MinimumWidth = 6;
            this.branch_id.Name = "branch_id";
            this.branch_id.Width = 125;
            // 
            // branch_name
            // 
            this.branch_name.DataPropertyName = "branch_name";
            this.branch_name.HeaderText = "Tên chi nhánh";
            this.branch_name.MinimumWidth = 200;
            this.branch_name.Name = "branch_name";
            this.branch_name.Width = 200;
            // 
            // max_stock
            // 
            this.max_stock.DataPropertyName = "max_stock";
            this.max_stock.HeaderText = "Trữ lượng tối đa";
            this.max_stock.MinimumWidth = 130;
            this.max_stock.Name = "max_stock";
            this.max_stock.Width = 130;
            // 
            // rent_amount
            // 
            this.rent_amount.DataPropertyName = "rent_amount";
            this.rent_amount.HeaderText = "Giá thuê";
            this.rent_amount.MinimumWidth = 200;
            this.rent_amount.Name = "rent_amount";
            this.rent_amount.Width = 200;
            // 
            // frmBranch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 495);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmBranch";
            this.Text = "Danh mục chi nhánh";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panel)).EndInit();
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBranch)).EndInit();
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
        private DevExpress.XtraEditors.GroupControl panel;
        private System.Windows.Forms.TextBox txt_rent_amount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_branch_name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.ComboBox cbSearch;
        private System.Windows.Forms.TextBox txt_branch_id;
        private System.Windows.Forms.TextBox txt_max_stock;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvBranch;
        private System.Windows.Forms.DataGridViewTextBoxColumn branch_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn branch_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn max_stock;
        private System.Windows.Forms.DataGridViewTextBoxColumn rent_amount;
    }
}