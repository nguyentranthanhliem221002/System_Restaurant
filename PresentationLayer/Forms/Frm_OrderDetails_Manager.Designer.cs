namespace PresentationLayer
{
    partial class frm_orderDetails_manager
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
            lb_tableNumber = new Label();
            tabControl_listCategory = new TabControl();
            groupBox_OrderDetail = new GroupBox();
            dgv_orderDetail = new DataGridView();
            Name = new DataGridViewTextBoxColumn();
            Price = new DataGridViewTextBoxColumn();
            Quantity = new DataGridViewTextBoxColumn();
            SubTotal = new DataGridViewTextBoxColumn();
            FoodId = new DataGridViewTextBoxColumn();
            button_saveOrderDetail = new Button();
            groupBox_OrderDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_orderDetail).BeginInit();
            SuspendLayout();
            // 
            // lb_tableNumber
            // 
            lb_tableNumber.AutoSize = true;
            lb_tableNumber.Location = new Point(639, 28);
            lb_tableNumber.Name = "lb_tableNumber";
            lb_tableNumber.Size = new Size(30, 20);
            lb_tableNumber.TabIndex = 0;
            lb_tableNumber.Text = "???";
            // 
            // tabControl_listCategory
            // 
            tabControl_listCategory.Location = new Point(0, -1);
            tabControl_listCategory.Name = "tabControl_listCategory";
            tabControl_listCategory.SelectedIndex = 0;
            tabControl_listCategory.Size = new Size(630, 608);
            tabControl_listCategory.TabIndex = 1;
            // 
            // groupBox_OrderDetail
            // 
            groupBox_OrderDetail.Controls.Add(dgv_orderDetail);
            groupBox_OrderDetail.Location = new Point(636, 51);
            groupBox_OrderDetail.Name = "groupBox_OrderDetail";
            groupBox_OrderDetail.Size = new Size(515, 552);
            groupBox_OrderDetail.TabIndex = 2;
            groupBox_OrderDetail.TabStop = false;
            groupBox_OrderDetail.Text = "Món ăn order : ";
            // 
            // dgv_orderDetail
            // 
            dgv_orderDetail.AllowUserToAddRows = false;
            dgv_orderDetail.AllowUserToDeleteRows = false;
            dgv_orderDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_orderDetail.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_orderDetail.Columns.AddRange(new DataGridViewColumn[] { Name, Price, Quantity, SubTotal, FoodId });
            dgv_orderDetail.Dock = DockStyle.Fill;
            dgv_orderDetail.Location = new Point(3, 23);
            dgv_orderDetail.Name = "dgv_orderDetail";
            dgv_orderDetail.ReadOnly = true;
            dgv_orderDetail.RowHeadersWidth = 51;
            dgv_orderDetail.Size = new Size(509, 526);
            dgv_orderDetail.TabIndex = 0;
            // 
            // Name
            // 
            Name.HeaderText = "Tên món";
            Name.MinimumWidth = 6;
            Name.Name = "Name";
            Name.ReadOnly = true;
            // 
            // Price
            // 
            Price.HeaderText = "Giá";
            Price.MinimumWidth = 6;
            Price.Name = "Price";
            Price.ReadOnly = true;
            // 
            // Quantity
            // 
            Quantity.HeaderText = "Số lượng";
            Quantity.MinimumWidth = 6;
            Quantity.Name = "Quantity";
            Quantity.ReadOnly = true;
            // 
            // SubTotal
            // 
            SubTotal.HeaderText = "Thành tiền";
            SubTotal.MinimumWidth = 6;
            SubTotal.Name = "SubTotal";
            SubTotal.ReadOnly = true;
            // 
            // FoodId
            // 
            FoodId.HeaderText = "FoodId";
            FoodId.MinimumWidth = 6;
            FoodId.Name = "FoodId";
            FoodId.ReadOnly = true;
            // 
            // button_saveOrderDetail
            // 
            button_saveOrderDetail.BackColor = Color.Brown;
            button_saveOrderDetail.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_saveOrderDetail.ForeColor = Color.Black;
            button_saveOrderDetail.Location = new Point(636, 609);
            button_saveOrderDetail.Name = "button_saveOrderDetail";
            button_saveOrderDetail.Size = new Size(515, 92);
            button_saveOrderDetail.TabIndex = 3;
            button_saveOrderDetail.Text = "Order";
            button_saveOrderDetail.UseVisualStyleBackColor = false;
            button_saveOrderDetail.Click += button_saveOrderDetail_Click;
            // 
            // frm_orderDetails_manager
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MistyRose;
            ClientSize = new Size(1163, 713);
            Controls.Add(button_saveOrderDetail);
            Controls.Add(lb_tableNumber);
            Controls.Add(groupBox_OrderDetail);
            Controls.Add(tabControl_listCategory);
            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý chi tiết đơn hàng";
            Load += frm_orderDetails_manager_Load;
            groupBox_OrderDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv_orderDetail).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lb_tableNumber;
        private TabControl tabControl_listCategory;
        private GroupBox groupBox_OrderDetail;
        private Button button_saveOrderDetail;
        private DataGridView dgv_orderDetail;
        private DataGridViewTextBoxColumn Name;
        private DataGridViewTextBoxColumn Price;
        private DataGridViewTextBoxColumn Quantity;
        private DataGridViewTextBoxColumn SubTotal;
        private DataGridViewTextBoxColumn FoodId;
    }
}