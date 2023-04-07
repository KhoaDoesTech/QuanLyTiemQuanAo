namespace QuanLyTiemQuanAo
{
    partial class frmProduct
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
            this.dgvPRODUCT = new System.Windows.Forms.DataGridView();
            this.product_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.category_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.product_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.product_size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.color = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unit_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPRODUCT)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPRODUCT
            // 
            this.dgvPRODUCT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPRODUCT.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.product_id,
            this.category_id,
            this.product_name,
            this.product_size,
            this.color,
            this.unit_price});
            this.dgvPRODUCT.Location = new System.Drawing.Point(0, 197);
            this.dgvPRODUCT.Name = "dgvPRODUCT";
            this.dgvPRODUCT.RowHeadersWidth = 51;
            this.dgvPRODUCT.RowTemplate.Height = 24;
            this.dgvPRODUCT.Size = new System.Drawing.Size(797, 193);
            this.dgvPRODUCT.TabIndex = 0;
            this.dgvPRODUCT.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPRODUCT_CellContentClick);
            // 
            // product_id
            // 
            this.product_id.DataPropertyName = "product_id";
            this.product_id.HeaderText = "Mã sản phẩm";
            this.product_id.MinimumWidth = 6;
            this.product_id.Name = "product_id";
            this.product_id.Width = 125;
            // 
            // category_id
            // 
            this.category_id.DataPropertyName = "category_id";
            this.category_id.HeaderText = "Mã loại sản phẩm";
            this.category_id.MinimumWidth = 6;
            this.category_id.Name = "category_id";
            this.category_id.Width = 125;
            // 
            // product_name
            // 
            this.product_name.DataPropertyName = "product_name";
            this.product_name.HeaderText = "Tên sản phẩm";
            this.product_name.MinimumWidth = 6;
            this.product_name.Name = "product_name";
            this.product_name.Width = 125;
            // 
            // product_size
            // 
            this.product_size.DataPropertyName = "product_size";
            this.product_size.HeaderText = "Size";
            this.product_size.MinimumWidth = 6;
            this.product_size.Name = "product_size";
            this.product_size.Width = 125;
            // 
            // color
            // 
            this.color.DataPropertyName = "color";
            this.color.HeaderText = "Màu sắc";
            this.color.MinimumWidth = 6;
            this.color.Name = "color";
            this.color.Width = 125;
            // 
            // unit_price
            // 
            this.unit_price.DataPropertyName = "unit_price";
            this.unit_price.HeaderText = "Giá";
            this.unit_price.MinimumWidth = 6;
            this.unit_price.Name = "unit_price";
            this.unit_price.Width = 125;
            // 
            // frmProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvPRODUCT);
            this.Name = "frmProduct";
            this.Text = "Khách hàng";
            this.Load += new System.EventHandler(this.FrmKhachHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPRODUCT)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPRODUCT;
        private System.Windows.Forms.DataGridViewTextBoxColumn product_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn category_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn product_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn product_size;
        private System.Windows.Forms.DataGridViewTextBoxColumn color;
        private System.Windows.Forms.DataGridViewTextBoxColumn unit_price;
    }
}