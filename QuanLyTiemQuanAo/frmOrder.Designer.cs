namespace QuanLyTiemQuanAo
{
    partial class frmOrder
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
            this.panelPurchaseOrder = new DevExpress.XtraEditors.PanelControl();
            this.txt_total_cost = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.dtp_order_date = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.txt_event_id = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txt_branch_id = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_employee_id = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPO_order_id = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panelOrderDetail = new DevExpress.XtraEditors.PanelControl();
            this.panelCustomer = new DevExpress.XtraEditors.PanelControl();
            this.label16 = new System.Windows.Forms.Label();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.label15 = new System.Windows.Forms.Label();
            this.txt_email = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cb_customer_type_id = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtp_birthday = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_phone = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtC_customer_id = new System.Windows.Forms.TextBox();
            this.txt_full_name = new System.Windows.Forms.TextBox();
            this.txt_gender = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.cb_customer_id = new System.Windows.Forms.ComboBox();
            this.cb_product_id = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtOD_order_id = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txt_quantity = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.dgvOrder = new System.Windows.Forms.DataGridView();
            this.product_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.product_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.color = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelPurchaseOrder)).BeginInit();
            this.panelPurchaseOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelOrderDetail)).BeginInit();
            this.panelOrderDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelCustomer)).BeginInit();
            this.panelCustomer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrder)).BeginInit();
            this.SuspendLayout();
            // 
            // panelPurchaseOrder
            // 
            this.panelPurchaseOrder.Controls.Add(this.cb_customer_id);
            this.panelPurchaseOrder.Controls.Add(this.label16);
            this.panelPurchaseOrder.Controls.Add(this.txt_total_cost);
            this.panelPurchaseOrder.Controls.Add(this.label14);
            this.panelPurchaseOrder.Controls.Add(this.dtp_order_date);
            this.panelPurchaseOrder.Controls.Add(this.label13);
            this.panelPurchaseOrder.Controls.Add(this.txt_event_id);
            this.panelPurchaseOrder.Controls.Add(this.label12);
            this.panelPurchaseOrder.Controls.Add(this.txt_branch_id);
            this.panelPurchaseOrder.Controls.Add(this.label11);
            this.panelPurchaseOrder.Controls.Add(this.txt_employee_id);
            this.panelPurchaseOrder.Controls.Add(this.label10);
            this.panelPurchaseOrder.Controls.Add(this.label9);
            this.panelPurchaseOrder.Controls.Add(this.txtPO_order_id);
            this.panelPurchaseOrder.Controls.Add(this.label6);
            this.panelPurchaseOrder.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelPurchaseOrder.Location = new System.Drawing.Point(0, 279);
            this.panelPurchaseOrder.Name = "panelPurchaseOrder";
            this.panelPurchaseOrder.Size = new System.Drawing.Size(511, 440);
            this.panelPurchaseOrder.TabIndex = 6;
            // 
            // txt_total_cost
            // 
            this.txt_total_cost.Font = new System.Drawing.Font("Tahoma", 11F);
            this.txt_total_cost.Location = new System.Drawing.Point(224, 371);
            this.txt_total_cost.Name = "txt_total_cost";
            this.txt_total_cost.Size = new System.Drawing.Size(247, 30);
            this.txt_total_cost.TabIndex = 181;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Tahoma", 11F);
            this.label14.Location = new System.Drawing.Point(30, 378);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(90, 23);
            this.label14.TabIndex = 180;
            this.label14.Text = "Tổng tiền";
            // 
            // dtp_order_date
            // 
            this.dtp_order_date.CalendarFont = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_order_date.Font = new System.Drawing.Font("Tahoma", 11F);
            this.dtp_order_date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_order_date.Location = new System.Drawing.Point(224, 320);
            this.dtp_order_date.Name = "dtp_order_date";
            this.dtp_order_date.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtp_order_date.Size = new System.Drawing.Size(247, 30);
            this.dtp_order_date.TabIndex = 171;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 11F);
            this.label13.Location = new System.Drawing.Point(30, 327);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(122, 23);
            this.label13.TabIndex = 170;
            this.label13.Text = "Ngày lập đơn";
            // 
            // txt_event_id
            // 
            this.txt_event_id.Font = new System.Drawing.Font("Tahoma", 11F);
            this.txt_event_id.Location = new System.Drawing.Point(224, 224);
            this.txt_event_id.Name = "txt_event_id";
            this.txt_event_id.Size = new System.Drawing.Size(247, 30);
            this.txt_event_id.TabIndex = 179;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 11F);
            this.label12.Location = new System.Drawing.Point(30, 231);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(73, 23);
            this.label12.TabIndex = 178;
            this.label12.Text = "Sự kiện";
            // 
            // txt_branch_id
            // 
            this.txt_branch_id.Font = new System.Drawing.Font("Tahoma", 11F);
            this.txt_branch_id.Location = new System.Drawing.Point(224, 75);
            this.txt_branch_id.Name = "txt_branch_id";
            this.txt_branch_id.Size = new System.Drawing.Size(247, 30);
            this.txt_branch_id.TabIndex = 177;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 11F);
            this.label11.Location = new System.Drawing.Point(30, 82);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(96, 23);
            this.label11.TabIndex = 176;
            this.label11.Text = "Chi nhánh";
            // 
            // txt_employee_id
            // 
            this.txt_employee_id.Font = new System.Drawing.Font("Tahoma", 11F);
            this.txt_employee_id.Location = new System.Drawing.Point(224, 173);
            this.txt_employee_id.Name = "txt_employee_id";
            this.txt_employee_id.Size = new System.Drawing.Size(247, 30);
            this.txt_employee_id.TabIndex = 175;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 11F);
            this.label10.Location = new System.Drawing.Point(30, 180);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(164, 23);
            this.label10.TabIndex = 174;
            this.label10.Text = "Nhân viên lập đơn";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 11F);
            this.label9.Location = new System.Drawing.Point(30, 129);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(111, 23);
            this.label9.TabIndex = 172;
            this.label9.Text = "Khách hàng";
            // 
            // txtPO_order_id
            // 
            this.txtPO_order_id.Font = new System.Drawing.Font("Tahoma", 11F);
            this.txtPO_order_id.Location = new System.Drawing.Point(224, 273);
            this.txtPO_order_id.Name = "txtPO_order_id";
            this.txtPO_order_id.Size = new System.Drawing.Size(247, 30);
            this.txtPO_order_id.TabIndex = 171;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 11F);
            this.label6.Location = new System.Drawing.Point(30, 273);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 23);
            this.label6.TabIndex = 170;
            this.label6.Text = "Mã đơn hàng";
            // 
            // panelOrderDetail
            // 
            this.panelOrderDetail.Controls.Add(this.txt_quantity);
            this.panelOrderDetail.Controls.Add(this.label20);
            this.panelOrderDetail.Controls.Add(this.txtOD_order_id);
            this.panelOrderDetail.Controls.Add(this.label19);
            this.panelOrderDetail.Controls.Add(this.cb_product_id);
            this.panelOrderDetail.Controls.Add(this.label18);
            this.panelOrderDetail.Controls.Add(this.label17);
            this.panelOrderDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOrderDetail.Location = new System.Drawing.Point(511, 279);
            this.panelOrderDetail.Name = "panelOrderDetail";
            this.panelOrderDetail.Size = new System.Drawing.Size(475, 440);
            this.panelOrderDetail.TabIndex = 8;
            // 
            // panelCustomer
            // 
            this.panelCustomer.Controls.Add(this.label15);
            this.panelCustomer.Controls.Add(this.txt_email);
            this.panelCustomer.Controls.Add(this.label7);
            this.panelCustomer.Controls.Add(this.cb_customer_type_id);
            this.panelCustomer.Controls.Add(this.label5);
            this.panelCustomer.Controls.Add(this.dtp_birthday);
            this.panelCustomer.Controls.Add(this.label8);
            this.panelCustomer.Controls.Add(this.txt_phone);
            this.panelCustomer.Controls.Add(this.label1);
            this.panelCustomer.Controls.Add(this.txtC_customer_id);
            this.panelCustomer.Controls.Add(this.txt_full_name);
            this.panelCustomer.Controls.Add(this.txt_gender);
            this.panelCustomer.Controls.Add(this.label4);
            this.panelCustomer.Controls.Add(this.label3);
            this.panelCustomer.Controls.Add(this.label2);
            this.panelCustomer.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCustomer.Location = new System.Drawing.Point(0, 0);
            this.panelCustomer.Name = "panelCustomer";
            this.panelCustomer.Size = new System.Drawing.Size(986, 279);
            this.panelCustomer.TabIndex = 4;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold);
            this.label16.ForeColor = System.Drawing.Color.Red;
            this.label16.Location = new System.Drawing.Point(137, 15);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(269, 27);
            this.label16.TabIndex = 171;
            this.label16.Text = "THÔNG TIN ĐƠN HÀNG";
            // 
            // panelControl4
            // 
            this.panelControl4.Controls.Add(this.dgvOrder);
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelControl4.Location = new System.Drawing.Point(986, 0);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(784, 719);
            this.panelControl4.TabIndex = 3;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold);
            this.label15.ForeColor = System.Drawing.Color.Red;
            this.label15.Location = new System.Drawing.Point(337, 22);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(295, 27);
            this.label15.TabIndex = 200;
            this.label15.Text = "THÔNG TIN KHÁCH HÀNG";
            // 
            // txt_email
            // 
            this.txt_email.Font = new System.Drawing.Font("Tahoma", 11F);
            this.txt_email.Location = new System.Drawing.Point(197, 215);
            this.txt_email.Name = "txt_email";
            this.txt_email.Size = new System.Drawing.Size(264, 30);
            this.txt_email.TabIndex = 199;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 11F);
            this.label7.Location = new System.Drawing.Point(25, 222);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 23);
            this.label7.TabIndex = 198;
            this.label7.Text = "Email";
            // 
            // cb_customer_type_id
            // 
            this.cb_customer_type_id.Font = new System.Drawing.Font("Tahoma", 11F);
            this.cb_customer_type_id.FormattingEnabled = true;
            this.cb_customer_type_id.Location = new System.Drawing.Point(197, 128);
            this.cb_customer_type_id.Name = "cb_customer_type_id";
            this.cb_customer_type_id.Size = new System.Drawing.Size(264, 30);
            this.cb_customer_type_id.TabIndex = 197;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 11F);
            this.label5.Location = new System.Drawing.Point(25, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(148, 23);
            this.label5.TabIndex = 196;
            this.label5.Text = "Loại khách hàng";
            // 
            // dtp_birthday
            // 
            this.dtp_birthday.CalendarFont = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_birthday.Font = new System.Drawing.Font("Tahoma", 11F);
            this.dtp_birthday.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_birthday.Location = new System.Drawing.Point(721, 167);
            this.dtp_birthday.Name = "dtp_birthday";
            this.dtp_birthday.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtp_birthday.Size = new System.Drawing.Size(224, 30);
            this.dtp_birthday.TabIndex = 195;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 11F);
            this.label8.Location = new System.Drawing.Point(565, 177);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 23);
            this.label8.TabIndex = 194;
            this.label8.Text = "Ngày sinh";
            // 
            // txt_phone
            // 
            this.txt_phone.Font = new System.Drawing.Font("Tahoma", 11F);
            this.txt_phone.Location = new System.Drawing.Point(720, 126);
            this.txt_phone.Name = "txt_phone";
            this.txt_phone.Size = new System.Drawing.Size(225, 30);
            this.txt_phone.TabIndex = 193;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11F);
            this.label1.Location = new System.Drawing.Point(564, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 23);
            this.label1.TabIndex = 192;
            this.label1.Text = "Số điện thoại";
            // 
            // txtC_customer_id
            // 
            this.txtC_customer_id.Font = new System.Drawing.Font("Tahoma", 11F);
            this.txtC_customer_id.Location = new System.Drawing.Point(197, 86);
            this.txtC_customer_id.Name = "txtC_customer_id";
            this.txtC_customer_id.Size = new System.Drawing.Size(264, 30);
            this.txtC_customer_id.TabIndex = 191;
            // 
            // txt_full_name
            // 
            this.txt_full_name.Font = new System.Drawing.Font("Tahoma", 11F);
            this.txt_full_name.Location = new System.Drawing.Point(197, 174);
            this.txt_full_name.Name = "txt_full_name";
            this.txt_full_name.Size = new System.Drawing.Size(264, 30);
            this.txt_full_name.TabIndex = 190;
            // 
            // txt_gender
            // 
            this.txt_gender.Font = new System.Drawing.Font("Tahoma", 11F);
            this.txt_gender.Location = new System.Drawing.Point(721, 86);
            this.txt_gender.Name = "txt_gender";
            this.txt_gender.Size = new System.Drawing.Size(224, 30);
            this.txt_gender.TabIndex = 189;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 11F);
            this.label4.Location = new System.Drawing.Point(565, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 23);
            this.label4.TabIndex = 188;
            this.label4.Text = "Giới tính";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 11F);
            this.label3.Location = new System.Drawing.Point(25, 180);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 23);
            this.label3.TabIndex = 187;
            this.label3.Text = "Họ và tên";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 11F);
            this.label2.Location = new System.Drawing.Point(25, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 23);
            this.label2.TabIndex = 186;
            this.label2.Text = "Mã khách hàng";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold);
            this.label17.ForeColor = System.Drawing.Color.Red;
            this.label17.Location = new System.Drawing.Point(120, 15);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(242, 27);
            this.label17.TabIndex = 201;
            this.label17.Text = "CHI TIẾT ĐƠN HÀNG";
            // 
            // cb_customer_id
            // 
            this.cb_customer_id.Font = new System.Drawing.Font("Tahoma", 11F);
            this.cb_customer_id.FormattingEnabled = true;
            this.cb_customer_id.Location = new System.Drawing.Point(224, 121);
            this.cb_customer_id.Name = "cb_customer_id";
            this.cb_customer_id.Size = new System.Drawing.Size(247, 30);
            this.cb_customer_id.TabIndex = 198;
            // 
            // cb_product_id
            // 
            this.cb_product_id.Font = new System.Drawing.Font("Tahoma", 11F);
            this.cb_product_id.FormattingEnabled = true;
            this.cb_product_id.Location = new System.Drawing.Point(165, 122);
            this.cb_product_id.Name = "cb_product_id";
            this.cb_product_id.Size = new System.Drawing.Size(269, 30);
            this.cb_product_id.TabIndex = 200;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Tahoma", 11F);
            this.label18.Location = new System.Drawing.Point(31, 129);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(96, 23);
            this.label18.TabIndex = 199;
            this.label18.Text = "Sản phẩm";
            // 
            // txtOD_order_id
            // 
            this.txtOD_order_id.Font = new System.Drawing.Font("Tahoma", 11F);
            this.txtOD_order_id.Location = new System.Drawing.Point(165, 75);
            this.txtOD_order_id.Name = "txtOD_order_id";
            this.txtOD_order_id.Size = new System.Drawing.Size(269, 30);
            this.txtOD_order_id.TabIndex = 200;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Tahoma", 11F);
            this.label19.Location = new System.Drawing.Point(34, 82);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(93, 23);
            this.label19.TabIndex = 199;
            this.label19.Text = "Đơn hàng";
            // 
            // txt_quantity
            // 
            this.txt_quantity.Font = new System.Drawing.Font("Tahoma", 11F);
            this.txt_quantity.Location = new System.Drawing.Point(165, 173);
            this.txt_quantity.Name = "txt_quantity";
            this.txt_quantity.Size = new System.Drawing.Size(269, 30);
            this.txt_quantity.TabIndex = 203;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Tahoma", 11F);
            this.label20.Location = new System.Drawing.Point(34, 180);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(85, 23);
            this.label20.TabIndex = 202;
            this.label20.Text = "Số lượng";
            // 
            // dgvOrder
            // 
            this.dgvOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrder.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.product_id,
            this.product_name,
            this.size,
            this.quantity,
            this.color});
            this.dgvOrder.Location = new System.Drawing.Point(0, 0);
            this.dgvOrder.Name = "dgvOrder";
            this.dgvOrder.RowHeadersWidth = 51;
            this.dgvOrder.RowTemplate.Height = 24;
            this.dgvOrder.Size = new System.Drawing.Size(784, 598);
            this.dgvOrder.TabIndex = 0;
            // 
            // product_id
            // 
            this.product_id.DataPropertyName = "product_id";
            this.product_id.HeaderText = "Mã sản phẩm";
            this.product_id.MinimumWidth = 6;
            this.product_id.Name = "product_id";
            this.product_id.Width = 125;
            // 
            // product_name
            // 
            this.product_name.DataPropertyName = "product_name";
            this.product_name.HeaderText = "Tên sản phẩm";
            this.product_name.MinimumWidth = 6;
            this.product_name.Name = "product_name";
            this.product_name.Width = 175;
            // 
            // size
            // 
            this.size.DataPropertyName = "size";
            this.size.HeaderText = "Size";
            this.size.MinimumWidth = 6;
            this.size.Name = "size";
            this.size.Width = 75;
            // 
            // quantity
            // 
            this.quantity.DataPropertyName = "quantity";
            this.quantity.HeaderText = "SL";
            this.quantity.MinimumWidth = 6;
            this.quantity.Name = "quantity";
            this.quantity.Width = 75;
            // 
            // color
            // 
            this.color.DataPropertyName = "color";
            this.color.HeaderText = "Màu";
            this.color.MinimumWidth = 6;
            this.color.Name = "color";
            this.color.Width = 125;
            // 
            // frmOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1770, 719);
            this.Controls.Add(this.panelOrderDetail);
            this.Controls.Add(this.panelPurchaseOrder);
            this.Controls.Add(this.panelCustomer);
            this.Controls.Add(this.panelControl4);
            this.Controls.Add(this.panelControl3);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmOrder";
            this.Text = "Hóa đơn";
            ((System.ComponentModel.ISupportInitialize)(this.panelPurchaseOrder)).EndInit();
            this.panelPurchaseOrder.ResumeLayout(false);
            this.panelPurchaseOrder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelOrderDetail)).EndInit();
            this.panelOrderDetail.ResumeLayout(false);
            this.panelOrderDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelCustomer)).EndInit();
            this.panelCustomer.ResumeLayout(false);
            this.panelCustomer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.PanelControl panelPurchaseOrder;
        private DevExpress.XtraEditors.PanelControl panelOrderDetail;
        private DevExpress.XtraEditors.PanelControl panelCustomer;
        private System.Windows.Forms.DateTimePicker dtp_order_date;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txt_event_id;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txt_branch_id;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txt_employee_id;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtPO_order_id;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_total_cost;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label16;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txt_email;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cb_customer_type_id;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtp_birthday;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_phone;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtC_customer_id;
        private System.Windows.Forms.TextBox txt_full_name;
        private System.Windows.Forms.TextBox txt_gender;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cb_customer_id;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtOD_order_id;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox cb_product_id;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txt_quantity;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.DataGridView dgvOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn product_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn product_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn size;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn color;
    }
}