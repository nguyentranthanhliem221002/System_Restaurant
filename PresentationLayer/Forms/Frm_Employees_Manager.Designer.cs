namespace PresentationLayer.Forms
{
    partial class frm_employees_manager
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
            dgv_listEmployee = new DataGridView();
            btn_categorySearch = new Button();
            txt_employeeSearch = new TextBox();
            lb_employeeSearch = new Label();
            btn_employeeUpdate = new Button();
            btn_employeeFix = new Button();
            btn_employeeDelete = new Button();
            btn_employeeAdd = new Button();
            groupBox_listEmployee = new GroupBox();
            txt_employeeName = new TextBox();
            lb_employeeName = new Label();
            lb_frm_employees_manager_title = new Label();
            ((System.ComponentModel.ISupportInitialize)dgv_listEmployee).BeginInit();
            groupBox_listEmployee.SuspendLayout();
            SuspendLayout();
            // 
            // dgv_listEmployee
            // 
            dgv_listEmployee.AllowUserToAddRows = false;
            dgv_listEmployee.AllowUserToDeleteRows = false;
            dgv_listEmployee.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_listEmployee.BackgroundColor = SystemColors.Control;
            dgv_listEmployee.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_listEmployee.Dock = DockStyle.Fill;
            dgv_listEmployee.Location = new Point(3, 23);
            dgv_listEmployee.Name = "dgv_listEmployee";
            dgv_listEmployee.ReadOnly = true;
            dgv_listEmployee.RowHeadersWidth = 51;
            dgv_listEmployee.Size = new Size(1097, 433);
            dgv_listEmployee.TabIndex = 1;
            // 
            // btn_categorySearch
            // 
            btn_categorySearch.BackColor = Color.Aqua;
            btn_categorySearch.Location = new Point(833, 110);
            btn_categorySearch.Name = "btn_categorySearch";
            btn_categorySearch.Size = new Size(303, 43);
            btn_categorySearch.TabIndex = 54;
            btn_categorySearch.Text = "Search";
            btn_categorySearch.UseVisualStyleBackColor = false;
            // 
            // txt_employeeSearch
            // 
            txt_employeeSearch.Location = new Point(833, 77);
            txt_employeeSearch.Name = "txt_employeeSearch";
            txt_employeeSearch.Size = new Size(303, 27);
            txt_employeeSearch.TabIndex = 53;
            // 
            // lb_employeeSearch
            // 
            lb_employeeSearch.AutoSize = true;
            lb_employeeSearch.BackColor = Color.Transparent;
            lb_employeeSearch.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lb_employeeSearch.Location = new Point(753, 84);
            lb_employeeSearch.Name = "lb_employeeSearch";
            lb_employeeSearch.Size = new Size(74, 20);
            lb_employeeSearch.TabIndex = 52;
            lb_employeeSearch.Text = "Tìm loại : ";
            lb_employeeSearch.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btn_employeeUpdate
            // 
            btn_employeeUpdate.BackColor = Color.Coral;
            btn_employeeUpdate.Location = new Point(878, 641);
            btn_employeeUpdate.Name = "btn_employeeUpdate";
            btn_employeeUpdate.Size = new Size(258, 60);
            btn_employeeUpdate.TabIndex = 51;
            btn_employeeUpdate.Text = "Cập nhật";
            btn_employeeUpdate.UseVisualStyleBackColor = false;
            // 
            // btn_employeeFix
            // 
            btn_employeeFix.BackColor = Color.Silver;
            btn_employeeFix.ForeColor = SystemColors.ControlText;
            btn_employeeFix.Location = new Point(599, 641);
            btn_employeeFix.Name = "btn_employeeFix";
            btn_employeeFix.Size = new Size(258, 60);
            btn_employeeFix.TabIndex = 50;
            btn_employeeFix.Text = "Sửa";
            btn_employeeFix.UseVisualStyleBackColor = false;
            // 
            // btn_employeeDelete
            // 
            btn_employeeDelete.Location = new Point(317, 641);
            btn_employeeDelete.Name = "btn_employeeDelete";
            btn_employeeDelete.Size = new Size(258, 60);
            btn_employeeDelete.TabIndex = 49;
            btn_employeeDelete.Text = "Xóa";
            btn_employeeDelete.UseVisualStyleBackColor = true;
            // 
            // btn_employeeAdd
            // 
            btn_employeeAdd.BackColor = Color.Chartreuse;
            btn_employeeAdd.ForeColor = Color.Black;
            btn_employeeAdd.Location = new Point(36, 641);
            btn_employeeAdd.Name = "btn_employeeAdd";
            btn_employeeAdd.Size = new Size(258, 60);
            btn_employeeAdd.TabIndex = 48;
            btn_employeeAdd.Text = "Thêm";
            btn_employeeAdd.UseVisualStyleBackColor = false;
            // 
            // groupBox_listEmployee
            // 
            groupBox_listEmployee.Controls.Add(dgv_listEmployee);
            groupBox_listEmployee.Location = new Point(33, 176);
            groupBox_listEmployee.Name = "groupBox_listEmployee";
            groupBox_listEmployee.Size = new Size(1103, 459);
            groupBox_listEmployee.TabIndex = 47;
            groupBox_listEmployee.TabStop = false;
            groupBox_listEmployee.Text = "Danh nhân viên  :";
            // 
            // txt_employeeName
            // 
            txt_employeeName.Location = new Point(136, 73);
            txt_employeeName.Name = "txt_employeeName";
            txt_employeeName.Size = new Size(266, 27);
            txt_employeeName.TabIndex = 46;
            // 
            // lb_employeeName
            // 
            lb_employeeName.AutoSize = true;
            lb_employeeName.BackColor = Color.Transparent;
            lb_employeeName.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lb_employeeName.Location = new Point(33, 80);
            lb_employeeName.Name = "lb_employeeName";
            lb_employeeName.Size = new Size(72, 20);
            lb_employeeName.TabIndex = 45;
            lb_employeeName.Text = "Tên loại : ";
            lb_employeeName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lb_frm_employees_manager_title
            // 
            lb_frm_employees_manager_title.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lb_frm_employees_manager_title.Location = new Point(427, 9);
            lb_frm_employees_manager_title.Name = "lb_frm_employees_manager_title";
            lb_frm_employees_manager_title.Size = new Size(318, 63);
            lb_frm_employees_manager_title.TabIndex = 44;
            lb_frm_employees_manager_title.Text = "Quản lý nhân viên";
            lb_frm_employees_manager_title.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // frm_employees_manager
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1163, 713);
            Controls.Add(btn_categorySearch);
            Controls.Add(txt_employeeSearch);
            Controls.Add(lb_employeeSearch);
            Controls.Add(btn_employeeUpdate);
            Controls.Add(btn_employeeFix);
            Controls.Add(btn_employeeDelete);
            Controls.Add(btn_employeeAdd);
            Controls.Add(groupBox_listEmployee);
            Controls.Add(txt_employeeName);
            Controls.Add(lb_employeeName);
            Controls.Add(lb_frm_employees_manager_title);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frm_employees_manager";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý nhân viên";
            Load += frm_employees_manager_Load;
            ((System.ComponentModel.ISupportInitialize)dgv_listEmployee).EndInit();
            groupBox_listEmployee.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgv_listEmployee;
        private Button btn_categorySearch;
        private TextBox txt_employeeSearch;
        private Label lb_employeeSearch;
        private Button btn_employeeUpdate;
        private Button btn_employeeFix;
        private Button btn_employeeDelete;
        private Button btn_employeeAdd;
        private GroupBox groupBox_listEmployee;
        private TextBox txt_employeeName;
        private Label lb_employeeName;
        private Label lb_frm_employees_manager_title;
    }
}