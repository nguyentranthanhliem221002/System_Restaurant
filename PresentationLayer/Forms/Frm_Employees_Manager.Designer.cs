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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            dgv_lisUser = new DataGridView();
            btn_userSearch = new Button();
            txt_userSearch = new TextBox();
            lb_userSearch = new Label();
            btn_userUpdate = new Button();
            btn_userFix = new Button();
            btn_userDelete = new Button();
            btn_userAdd = new Button();
            groupBox_listEmployee = new GroupBox();
            lb_frm_employees_manager_title = new Label();
            radioButton_optionEmployee = new RadioButton();
            radioButton_optionAdmin = new RadioButton();
            groupBox1 = new GroupBox();
            groupBox_infoUser = new GroupBox();
            dateTimePicker_userDateStart = new DateTimePicker();
            txt_userFullName = new TextBox();
            lb_userDateStart = new Label();
            lb_userFullName = new Label();
            txt_userEmail = new TextBox();
            lb_userNumberPhone = new Label();
            lb_userEmail = new Label();
            txt_userNumberPhone = new TextBox();
            groupBox_user = new GroupBox();
            lb_userPasswordHash = new Label();
            txt_userPasswordHash = new TextBox();
            lb_userUserName = new Label();
            txt_userUserName = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgv_lisUser).BeginInit();
            groupBox_listEmployee.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox_infoUser.SuspendLayout();
            groupBox_user.SuspendLayout();
            SuspendLayout();
            // 
            // dgv_lisUser
            // 
            dgv_lisUser.AllowUserToAddRows = false;
            dgv_lisUser.AllowUserToDeleteRows = false;
            dgv_lisUser.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10.2F, FontStyle.Italic);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgv_lisUser.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgv_lisUser.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10.2F, FontStyle.Italic);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgv_lisUser.DefaultCellStyle = dataGridViewCellStyle2;
            dgv_lisUser.Dock = DockStyle.Fill;
            dgv_lisUser.Location = new Point(3, 26);
            dgv_lisUser.Name = "dgv_lisUser";
            dgv_lisUser.ReadOnly = true;
            dgv_lisUser.RowHeadersWidth = 51;
            dgv_lisUser.Size = new Size(1090, 268);
            dgv_lisUser.TabIndex = 1;
            // 
            // btn_userSearch
            // 
            btn_userSearch.BackColor = Color.Aqua;
            btn_userSearch.Font = new Font("Segoe UI", 10.2F, FontStyle.Italic);
            btn_userSearch.Location = new Point(813, 164);
            btn_userSearch.Name = "btn_userSearch";
            btn_userSearch.Size = new Size(318, 49);
            btn_userSearch.TabIndex = 54;
            btn_userSearch.Text = "Search";
            btn_userSearch.UseVisualStyleBackColor = false;
            btn_userSearch.Click += btn_userSearch_Click;
            // 
            // txt_userSearch
            // 
            txt_userSearch.Location = new Point(813, 126);
            txt_userSearch.Name = "txt_userSearch";
            txt_userSearch.Size = new Size(317, 30);
            txt_userSearch.TabIndex = 53;
            // 
            // lb_userSearch
            // 
            lb_userSearch.AutoSize = true;
            lb_userSearch.BackColor = Color.Transparent;
            lb_userSearch.Font = new Font("Segoe UI", 10.2F, FontStyle.Italic);
            lb_userSearch.Location = new Point(813, 85);
            lb_userSearch.Name = "lb_userSearch";
            lb_userSearch.Size = new Size(83, 23);
            lb_userSearch.TabIndex = 52;
            lb_userSearch.Text = "Tìm loại : ";
            lb_userSearch.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btn_userUpdate
            // 
            btn_userUpdate.BackColor = Color.Coral;
            btn_userUpdate.Font = new Font("Segoe UI", 10.2F, FontStyle.Italic);
            btn_userUpdate.Location = new Point(875, 641);
            btn_userUpdate.Name = "btn_userUpdate";
            btn_userUpdate.Size = new Size(258, 60);
            btn_userUpdate.TabIndex = 51;
            btn_userUpdate.Text = "Cập nhật";
            btn_userUpdate.UseVisualStyleBackColor = false;
            btn_userUpdate.Click += btn_userUpdate_Click;
            // 
            // btn_userFix
            // 
            btn_userFix.BackColor = Color.Silver;
            btn_userFix.Font = new Font("Segoe UI", 10.2F, FontStyle.Italic);
            btn_userFix.ForeColor = SystemColors.ControlText;
            btn_userFix.Location = new Point(596, 641);
            btn_userFix.Name = "btn_userFix";
            btn_userFix.Size = new Size(258, 60);
            btn_userFix.TabIndex = 50;
            btn_userFix.Text = "Sửa";
            btn_userFix.UseVisualStyleBackColor = false;
            btn_userFix.Click += btn_userFix_Click;
            // 
            // btn_userDelete
            // 
            btn_userDelete.Font = new Font("Segoe UI", 10.2F, FontStyle.Italic);
            btn_userDelete.Location = new Point(318, 641);
            btn_userDelete.Name = "btn_userDelete";
            btn_userDelete.Size = new Size(258, 60);
            btn_userDelete.TabIndex = 49;
            btn_userDelete.Text = "Xóa";
            btn_userDelete.UseVisualStyleBackColor = true;
            btn_userDelete.Click += btn_userDelete_Click;
            // 
            // btn_userAdd
            // 
            btn_userAdd.BackColor = Color.Chartreuse;
            btn_userAdd.Font = new Font("Segoe UI", 10.2F, FontStyle.Italic);
            btn_userAdd.ForeColor = Color.Black;
            btn_userAdd.Location = new Point(37, 641);
            btn_userAdd.Name = "btn_userAdd";
            btn_userAdd.Size = new Size(258, 60);
            btn_userAdd.TabIndex = 48;
            btn_userAdd.Text = "Thêm";
            btn_userAdd.UseVisualStyleBackColor = false;
            btn_userAdd.Click += btn_userAdd_Click;
            // 
            // groupBox_listEmployee
            // 
            groupBox_listEmployee.Controls.Add(dgv_lisUser);
            groupBox_listEmployee.Font = new Font("Segoe UI", 10.2F, FontStyle.Italic);
            groupBox_listEmployee.Location = new Point(37, 338);
            groupBox_listEmployee.Name = "groupBox_listEmployee";
            groupBox_listEmployee.Size = new Size(1096, 297);
            groupBox_listEmployee.TabIndex = 47;
            groupBox_listEmployee.TabStop = false;
            groupBox_listEmployee.Text = "Danh nhân viên  :";
            // 
            // lb_frm_employees_manager_title
            // 
            lb_frm_employees_manager_title.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lb_frm_employees_manager_title.Location = new Point(480, 10);
            lb_frm_employees_manager_title.Name = "lb_frm_employees_manager_title";
            lb_frm_employees_manager_title.Size = new Size(358, 72);
            lb_frm_employees_manager_title.TabIndex = 44;
            lb_frm_employees_manager_title.Text = "Quản lý nhân viên";
            lb_frm_employees_manager_title.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // radioButton_optionEmployee
            // 
            radioButton_optionEmployee.AutoSize = true;
            radioButton_optionEmployee.Checked = true;
            radioButton_optionEmployee.Font = new Font("Segoe UI", 10.2F, FontStyle.Italic);
            radioButton_optionEmployee.Location = new Point(167, 49);
            radioButton_optionEmployee.Name = "radioButton_optionEmployee";
            radioButton_optionEmployee.Size = new Size(107, 27);
            radioButton_optionEmployee.TabIndex = 61;
            radioButton_optionEmployee.TabStop = true;
            radioButton_optionEmployee.Text = "Nhân viên";
            radioButton_optionEmployee.UseVisualStyleBackColor = true;
            // 
            // radioButton_optionAdmin
            // 
            radioButton_optionAdmin.AutoSize = true;
            radioButton_optionAdmin.Font = new Font("Segoe UI", 10.2F, FontStyle.Italic);
            radioButton_optionAdmin.Location = new Point(27, 49);
            radioButton_optionAdmin.Name = "radioButton_optionAdmin";
            radioButton_optionAdmin.Size = new Size(93, 27);
            radioButton_optionAdmin.TabIndex = 62;
            radioButton_optionAdmin.Text = "Quản trị";
            radioButton_optionAdmin.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radioButton_optionEmployee);
            groupBox1.Controls.Add(radioButton_optionAdmin);
            groupBox1.Font = new Font("Segoe UI", 10.2F, FontStyle.Italic);
            groupBox1.Location = new Point(813, 219);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(317, 108);
            groupBox1.TabIndex = 64;
            groupBox1.TabStop = false;
            groupBox1.Text = "Quyền: ";
            // 
            // groupBox_infoUser
            // 
            groupBox_infoUser.Controls.Add(dateTimePicker_userDateStart);
            groupBox_infoUser.Controls.Add(txt_userFullName);
            groupBox_infoUser.Controls.Add(lb_userDateStart);
            groupBox_infoUser.Controls.Add(lb_userFullName);
            groupBox_infoUser.Controls.Add(txt_userEmail);
            groupBox_infoUser.Controls.Add(lb_userNumberPhone);
            groupBox_infoUser.Controls.Add(lb_userEmail);
            groupBox_infoUser.Controls.Add(txt_userNumberPhone);
            groupBox_infoUser.Font = new Font("Segoe UI", 10.2F, FontStyle.Italic);
            groupBox_infoUser.Location = new Point(37, 84);
            groupBox_infoUser.Name = "groupBox_infoUser";
            groupBox_infoUser.Size = new Size(404, 247);
            groupBox_infoUser.TabIndex = 65;
            groupBox_infoUser.TabStop = false;
            groupBox_infoUser.Text = "Thông tin user: ";
            // 
            // dateTimePicker_userDateStart
            // 
            dateTimePicker_userDateStart.Location = new Point(146, 206);
            dateTimePicker_userDateStart.Name = "dateTimePicker_userDateStart";
            dateTimePicker_userDateStart.Size = new Size(232, 30);
            dateTimePicker_userDateStart.TabIndex = 73;
            // 
            // txt_userFullName
            // 
            txt_userFullName.Location = new Point(146, 30);
            txt_userFullName.Name = "txt_userFullName";
            txt_userFullName.Size = new Size(232, 30);
            txt_userFullName.TabIndex = 67;
            // 
            // lb_userDateStart
            // 
            lb_userDateStart.AutoSize = true;
            lb_userDateStart.BackColor = Color.Transparent;
            lb_userDateStart.Font = new Font("Segoe UI", 10.2F, FontStyle.Italic);
            lb_userDateStart.Location = new Point(20, 214);
            lb_userDateStart.Name = "lb_userDateStart";
            lb_userDateStart.Size = new Size(119, 23);
            lb_userDateStart.TabIndex = 72;
            lb_userDateStart.Text = "Ngày bắt đầu: ";
            lb_userDateStart.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lb_userFullName
            // 
            lb_userFullName.AutoSize = true;
            lb_userFullName.BackColor = Color.Transparent;
            lb_userFullName.Font = new Font("Segoe UI", 10.2F, FontStyle.Italic);
            lb_userFullName.Location = new Point(20, 38);
            lb_userFullName.Name = "lb_userFullName";
            lb_userFullName.Size = new Size(124, 23);
            lb_userFullName.TabIndex = 66;
            lb_userFullName.Text = "Tên nhân viên: ";
            lb_userFullName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txt_userEmail
            // 
            txt_userEmail.Location = new Point(146, 156);
            txt_userEmail.Name = "txt_userEmail";
            txt_userEmail.Size = new Size(232, 30);
            txt_userEmail.TabIndex = 71;
            // 
            // lb_userNumberPhone
            // 
            lb_userNumberPhone.AutoSize = true;
            lb_userNumberPhone.BackColor = Color.Transparent;
            lb_userNumberPhone.Font = new Font("Segoe UI", 10.2F, FontStyle.Italic);
            lb_userNumberPhone.Location = new Point(20, 99);
            lb_userNumberPhone.Name = "lb_userNumberPhone";
            lb_userNumberPhone.Size = new Size(114, 23);
            lb_userNumberPhone.TabIndex = 68;
            lb_userNumberPhone.Text = "Số điện thoại: ";
            lb_userNumberPhone.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lb_userEmail
            // 
            lb_userEmail.AutoSize = true;
            lb_userEmail.BackColor = Color.Transparent;
            lb_userEmail.Font = new Font("Segoe UI", 10.2F, FontStyle.Italic);
            lb_userEmail.Location = new Point(20, 164);
            lb_userEmail.Name = "lb_userEmail";
            lb_userEmail.Size = new Size(59, 23);
            lb_userEmail.TabIndex = 70;
            lb_userEmail.Text = "Email: ";
            lb_userEmail.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txt_userNumberPhone
            // 
            txt_userNumberPhone.Location = new Point(146, 91);
            txt_userNumberPhone.Name = "txt_userNumberPhone";
            txt_userNumberPhone.Size = new Size(232, 30);
            txt_userNumberPhone.TabIndex = 69;
            // 
            // groupBox_user
            // 
            groupBox_user.Controls.Add(lb_userPasswordHash);
            groupBox_user.Controls.Add(txt_userPasswordHash);
            groupBox_user.Controls.Add(lb_userUserName);
            groupBox_user.Controls.Add(txt_userUserName);
            groupBox_user.Font = new Font("Segoe UI", 10.2F, FontStyle.Italic);
            groupBox_user.Location = new Point(447, 85);
            groupBox_user.Name = "groupBox_user";
            groupBox_user.Size = new Size(360, 242);
            groupBox_user.TabIndex = 66;
            groupBox_user.TabStop = false;
            groupBox_user.Text = "Tài khoản: ";
            // 
            // lb_userPasswordHash
            // 
            lb_userPasswordHash.BackColor = Color.Transparent;
            lb_userPasswordHash.Font = new Font("Segoe UI", 10.2F, FontStyle.Italic);
            lb_userPasswordHash.Location = new Point(7, 109);
            lb_userPasswordHash.Name = "lb_userPasswordHash";
            lb_userPasswordHash.Size = new Size(122, 23);
            lb_userPasswordHash.TabIndex = 75;
            lb_userPasswordHash.Text = "Mật khẩu: ";
            lb_userPasswordHash.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txt_userPasswordHash
            // 
            txt_userPasswordHash.Location = new Point(148, 101);
            txt_userPasswordHash.Name = "txt_userPasswordHash";
            txt_userPasswordHash.PasswordChar = '*';
            txt_userPasswordHash.Size = new Size(204, 30);
            txt_userPasswordHash.TabIndex = 76;
            // 
            // lb_userUserName
            // 
            lb_userUserName.BackColor = Color.Transparent;
            lb_userUserName.Font = new Font("Segoe UI", 10.2F, FontStyle.Italic);
            lb_userUserName.Location = new Point(7, 48);
            lb_userUserName.Name = "lb_userUserName";
            lb_userUserName.Size = new Size(135, 23);
            lb_userUserName.TabIndex = 74;
            lb_userUserName.Text = "Tên đăng nhập: ";
            lb_userUserName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txt_userUserName
            // 
            txt_userUserName.Location = new Point(148, 45);
            txt_userUserName.Name = "txt_userUserName";
            txt_userUserName.Size = new Size(204, 30);
            txt_userUserName.TabIndex = 74;
            // 
            // frm_employees_manager
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MistyRose;
            ClientSize = new Size(1171, 713);
            Controls.Add(groupBox_user);
            Controls.Add(groupBox_infoUser);
            Controls.Add(groupBox1);
            Controls.Add(btn_userSearch);
            Controls.Add(txt_userSearch);
            Controls.Add(lb_userSearch);
            Controls.Add(btn_userUpdate);
            Controls.Add(btn_userFix);
            Controls.Add(btn_userDelete);
            Controls.Add(btn_userAdd);
            Controls.Add(groupBox_listEmployee);
            Controls.Add(lb_frm_employees_manager_title);
            Font = new Font("Segoe UI", 10.2F, FontStyle.Italic);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frm_employees_manager";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý nhân viên";
            Load += frm_employees_manager_Load;
            ((System.ComponentModel.ISupportInitialize)dgv_lisUser).EndInit();
            groupBox_listEmployee.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox_infoUser.ResumeLayout(false);
            groupBox_infoUser.PerformLayout();
            groupBox_user.ResumeLayout(false);
            groupBox_user.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgv_lisUser;
        private Button btn_userSearch;
        private TextBox txt_userSearch;
        private Label lb_userSearch;
        private Button btn_userUpdate;
        private Button btn_userFix;
        private Button btn_userDelete;
        private Button btn_userAdd;
        private GroupBox groupBox_listEmployee;
        private Label lb_frm_employees_manager_title;
        private RadioButton radioButton_optionEmployee;
        private RadioButton radioButton_optionAdmin;
        private GroupBox groupBox1;
        private GroupBox groupBox_infoUser;
        private DateTimePicker dateTimePicker_userDateStart;
        private TextBox txt_userFullName;
        private Label lb_userDateStart;
        private Label lb_userFullName;
        private TextBox txt_userEmail;
        private Label lb_userNumberPhone;
        private Label lb_userEmail;
        private TextBox txt_userNumberPhone;
        private GroupBox groupBox_user;
        private Label lb_userPasswordHash;
        private TextBox txt_userPasswordHash;
        private Label lb_userUserName;
        private TextBox txt_userUserName;
    }
}