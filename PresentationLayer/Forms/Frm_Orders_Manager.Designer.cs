namespace PresentationLayer
{
    partial class frm_orders_manager
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
            lb_frm_orders_manager_title = new Label();
            dgv_order = new DataGridView();
            btn_ordersSearch = new Button();
            dateTimePicker_orderTime = new DateTimePicker();
            lb_orderTime = new Label();
            groupBox_order = new GroupBox();
            groupBox_listRole = new GroupBox();
            lb_roleEmployee = new Label();
            lb_roleAdmin = new Label();
            ((System.ComponentModel.ISupportInitialize)dgv_order).BeginInit();
            groupBox_order.SuspendLayout();
            groupBox_listRole.SuspendLayout();
            SuspendLayout();
            // 
            // lb_frm_orders_manager_title
            // 
            lb_frm_orders_manager_title.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lb_frm_orders_manager_title.Location = new Point(396, 9);
            lb_frm_orders_manager_title.Name = "lb_frm_orders_manager_title";
            lb_frm_orders_manager_title.Size = new Size(368, 63);
            lb_frm_orders_manager_title.TabIndex = 17;
            lb_frm_orders_manager_title.Text = "Thống kê doanh thu";
            lb_frm_orders_manager_title.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dgv_order
            // 
            dgv_order.AllowUserToAddRows = false;
            dgv_order.AllowUserToDeleteRows = false;
            dgv_order.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_order.BorderStyle = BorderStyle.None;
            dgv_order.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_order.Dock = DockStyle.Fill;
            dgv_order.Location = new Point(3, 26);
            dgv_order.Name = "dgv_order";
            dgv_order.ReadOnly = true;
            dgv_order.RowHeadersWidth = 51;
            dgv_order.Size = new Size(1133, 449);
            dgv_order.TabIndex = 3;
            dgv_order.CellContentClick += dgv_order_CellContentClick;
            // 
            // btn_ordersSearch
            // 
            btn_ordersSearch.Font = new Font("Segoe UI", 10.2F, FontStyle.Italic);
            btn_ordersSearch.Location = new Point(1047, 75);
            btn_ordersSearch.Name = "btn_ordersSearch";
            btn_ordersSearch.Size = new Size(94, 27);
            btn_ordersSearch.TabIndex = 21;
            btn_ordersSearch.Text = "Tìm kiếm";
            btn_ordersSearch.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker_orderTime
            // 
            dateTimePicker_orderTime.Location = new Point(791, 75);
            dateTimePicker_orderTime.Name = "dateTimePicker_orderTime";
            dateTimePicker_orderTime.Size = new Size(250, 27);
            dateTimePicker_orderTime.TabIndex = 20;
            // 
            // lb_orderTime
            // 
            lb_orderTime.AutoSize = true;
            lb_orderTime.BackColor = Color.Transparent;
            lb_orderTime.Font = new Font("Segoe UI", 10.2F, FontStyle.Italic);
            lb_orderTime.Location = new Point(629, 77);
            lb_orderTime.Name = "lb_orderTime";
            lb_orderTime.Size = new Size(156, 23);
            lb_orderTime.TabIndex = 19;
            lb_orderTime.Text = "Ngày/ Tháng/ Năm";
            lb_orderTime.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // groupBox_order
            // 
            groupBox_order.Controls.Add(dgv_order);
            groupBox_order.Font = new Font("Segoe UI", 10.2F, FontStyle.Italic);
            groupBox_order.Location = new Point(12, 223);
            groupBox_order.Name = "groupBox_order";
            groupBox_order.Size = new Size(1139, 478);
            groupBox_order.TabIndex = 18;
            groupBox_order.TabStop = false;
            groupBox_order.Text = "Doanh thu : ";
            // 
            // groupBox_listRole
            // 
            groupBox_listRole.Controls.Add(lb_roleEmployee);
            groupBox_listRole.Controls.Add(lb_roleAdmin);
            groupBox_listRole.Font = new Font("Segoe UI", 10.2F, FontStyle.Italic);
            groupBox_listRole.Location = new Point(15, 75);
            groupBox_listRole.Name = "groupBox_listRole";
            groupBox_listRole.Size = new Size(393, 142);
            groupBox_listRole.TabIndex = 24;
            groupBox_listRole.TabStop = false;
            groupBox_listRole.Text = "Định nghĩa quyền : ";
            groupBox_listRole.Enter += groupBox_listRole_Enter;
            // 
            // lb_roleEmployee
            // 
            lb_roleEmployee.AutoSize = true;
            lb_roleEmployee.BackColor = Color.Transparent;
            lb_roleEmployee.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lb_roleEmployee.Location = new Point(6, 88);
            lb_roleEmployee.Name = "lb_roleEmployee";
            lb_roleEmployee.Size = new Size(94, 20);
            lb_roleEmployee.TabIndex = 26;
            lb_roleEmployee.Text = "Nhân viên : 2";
            lb_roleEmployee.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lb_roleAdmin
            // 
            lb_roleAdmin.AutoSize = true;
            lb_roleAdmin.BackColor = Color.Transparent;
            lb_roleAdmin.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lb_roleAdmin.Location = new Point(6, 40);
            lb_roleAdmin.Name = "lb_roleAdmin";
            lb_roleAdmin.Size = new Size(81, 20);
            lb_roleAdmin.TabIndex = 25;
            lb_roleAdmin.Text = "Quản trị : 1";
            lb_roleAdmin.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // frm_orders_manager
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MistyRose;
            ClientSize = new Size(1163, 713);
            Controls.Add(groupBox_listRole);
            Controls.Add(lb_frm_orders_manager_title);
            Controls.Add(btn_ordersSearch);
            Controls.Add(dateTimePicker_orderTime);
            Controls.Add(lb_orderTime);
            Controls.Add(groupBox_order);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frm_orders_manager";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý đơn hàng";
            Load += frm_orders_manager_Load;
            ((System.ComponentModel.ISupportInitialize)dgv_order).EndInit();
            groupBox_order.ResumeLayout(false);
            groupBox_listRole.ResumeLayout(false);
            groupBox_listRole.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lb_frm_orders_manager_title;
        private DataGridView dgv_order;
        private Button btn_ordersSearch;
        private DateTimePicker dateTimePicker_orderTime;
        private Label lb_orderTime;
        private GroupBox groupBox_order;
        private GroupBox groupBox_listRole;
        private Label lb_roleEmployee;
        private Label lb_roleAdmin;
    }
}