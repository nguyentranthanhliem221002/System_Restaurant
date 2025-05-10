namespace PresentationLayer.Forms
{
    partial class frm_users_manager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_users_manager));
            lb_frm_users_manager_title = new Label();
            groupBox_listUser = new GroupBox();
            dgv_lisUser = new DataGridView();
            groupBox_user = new GroupBox();
            btn_showPasswordConfirm = new Button();
            lb_userPasswordConfirm = new Label();
            txt_userPasswordConfirm = new TextBox();
            btn_showPassword = new Button();
            btn_showPasswordNew = new Button();
            lb_userPasswordNew = new Label();
            txt_userPasswordNew = new TextBox();
            lb_userPasswordHash = new Label();
            txt_userPasswordHash = new TextBox();
            lb_userUserName = new Label();
            txt_userUserName = new TextBox();
            btn_changePassword = new Button();
            groupBox_listUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_lisUser).BeginInit();
            groupBox_user.SuspendLayout();
            SuspendLayout();
            // 
            // lb_frm_users_manager_title
            // 
            lb_frm_users_manager_title.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lb_frm_users_manager_title.Location = new Point(398, 9);
            lb_frm_users_manager_title.Name = "lb_frm_users_manager_title";
            lb_frm_users_manager_title.Size = new Size(358, 72);
            lb_frm_users_manager_title.TabIndex = 45;
            lb_frm_users_manager_title.Text = "Quản lý tài khoản";
            lb_frm_users_manager_title.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // groupBox_listUser
            // 
            groupBox_listUser.Controls.Add(dgv_lisUser);
            groupBox_listUser.Font = new Font("Segoe UI", 10.2F, FontStyle.Italic);
            groupBox_listUser.Location = new Point(22, 116);
            groupBox_listUser.Name = "groupBox_listUser";
            groupBox_listUser.Size = new Size(634, 538);
            groupBox_listUser.TabIndex = 48;
            groupBox_listUser.TabStop = false;
            groupBox_listUser.Text = "Danh sách tài khoản  :";
            // 
            // dgv_lisUser
            // 
            dgv_lisUser.AllowUserToAddRows = false;
            dgv_lisUser.AllowUserToDeleteRows = false;
            dgv_lisUser.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_lisUser.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_lisUser.Dock = DockStyle.Fill;
            dgv_lisUser.Location = new Point(3, 26);
            dgv_lisUser.Name = "dgv_lisUser";
            dgv_lisUser.ReadOnly = true;
            dgv_lisUser.RowHeadersWidth = 51;
            dgv_lisUser.Size = new Size(628, 509);
            dgv_lisUser.TabIndex = 1;
            // 
            // groupBox_user
            // 
            groupBox_user.Controls.Add(btn_showPasswordConfirm);
            groupBox_user.Controls.Add(lb_userPasswordConfirm);
            groupBox_user.Controls.Add(txt_userPasswordConfirm);
            groupBox_user.Controls.Add(btn_showPassword);
            groupBox_user.Controls.Add(btn_showPasswordNew);
            groupBox_user.Controls.Add(lb_userPasswordNew);
            groupBox_user.Controls.Add(txt_userPasswordNew);
            groupBox_user.Controls.Add(lb_userPasswordHash);
            groupBox_user.Controls.Add(txt_userPasswordHash);
            groupBox_user.Controls.Add(lb_userUserName);
            groupBox_user.Controls.Add(txt_userUserName);
            groupBox_user.Font = new Font("Segoe UI", 10.2F, FontStyle.Italic);
            groupBox_user.Location = new Point(662, 116);
            groupBox_user.Name = "groupBox_user";
            groupBox_user.Size = new Size(459, 453);
            groupBox_user.TabIndex = 67;
            groupBox_user.TabStop = false;
            groupBox_user.Text = "Tài khoản: ";
            // 
            // btn_showPasswordConfirm
            // 
            btn_showPasswordConfirm.BackColor = SystemColors.GradientInactiveCaption;
            btn_showPasswordConfirm.BackgroundImage = (Image)resources.GetObject("btn_showPasswordConfirm.BackgroundImage");
            btn_showPasswordConfirm.BackgroundImageLayout = ImageLayout.Zoom;
            btn_showPasswordConfirm.Location = new Point(411, 225);
            btn_showPasswordConfirm.Name = "btn_showPasswordConfirm";
            btn_showPasswordConfirm.Size = new Size(42, 32);
            btn_showPasswordConfirm.TabIndex = 84;
            btn_showPasswordConfirm.UseVisualStyleBackColor = false;
            btn_showPasswordConfirm.Click += btn_showPasswordConfirm_Click;
            // 
            // lb_userPasswordConfirm
            // 
            lb_userPasswordConfirm.BackColor = Color.Transparent;
            lb_userPasswordConfirm.Font = new Font("Segoe UI", 10.2F, FontStyle.Italic);
            lb_userPasswordConfirm.Location = new Point(7, 234);
            lb_userPasswordConfirm.Name = "lb_userPasswordConfirm";
            lb_userPasswordConfirm.Size = new Size(158, 23);
            lb_userPasswordConfirm.TabIndex = 82;
            lb_userPasswordConfirm.Text = "Xác nhận mật khẩu:";
            lb_userPasswordConfirm.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txt_userPasswordConfirm
            // 
            txt_userPasswordConfirm.Location = new Point(171, 227);
            txt_userPasswordConfirm.Name = "txt_userPasswordConfirm";
            txt_userPasswordConfirm.PasswordChar = '*';
            txt_userPasswordConfirm.Size = new Size(282, 30);
            txt_userPasswordConfirm.TabIndex = 83;
            // 
            // btn_showPassword
            // 
            btn_showPassword.BackColor = SystemColors.GradientInactiveCaption;
            btn_showPassword.BackgroundImage = (Image)resources.GetObject("btn_showPassword.BackgroundImage");
            btn_showPassword.BackgroundImageLayout = ImageLayout.Zoom;
            btn_showPassword.Location = new Point(411, 100);
            btn_showPassword.Name = "btn_showPassword";
            btn_showPassword.Size = new Size(42, 32);
            btn_showPassword.TabIndex = 81;
            btn_showPassword.UseVisualStyleBackColor = false;
            btn_showPassword.Click += btn_showPassword_Click;
            // 
            // btn_showPasswordNew
            // 
            btn_showPasswordNew.BackColor = SystemColors.GradientInactiveCaption;
            btn_showPasswordNew.BackgroundImage = (Image)resources.GetObject("btn_showPasswordNew.BackgroundImage");
            btn_showPasswordNew.BackgroundImageLayout = ImageLayout.Zoom;
            btn_showPasswordNew.Location = new Point(411, 167);
            btn_showPasswordNew.Name = "btn_showPasswordNew";
            btn_showPasswordNew.Size = new Size(42, 32);
            btn_showPasswordNew.TabIndex = 80;
            btn_showPasswordNew.UseVisualStyleBackColor = false;
            btn_showPasswordNew.Click += btn_showPasswordNew_Click;
            // 
            // lb_userPasswordNew
            // 
            lb_userPasswordNew.BackColor = Color.Transparent;
            lb_userPasswordNew.Font = new Font("Segoe UI", 10.2F, FontStyle.Italic);
            lb_userPasswordNew.Location = new Point(7, 176);
            lb_userPasswordNew.Name = "lb_userPasswordNew";
            lb_userPasswordNew.Size = new Size(158, 23);
            lb_userPasswordNew.TabIndex = 77;
            lb_userPasswordNew.Text = "Mật khẩu mới:";
            lb_userPasswordNew.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txt_userPasswordNew
            // 
            txt_userPasswordNew.Location = new Point(171, 169);
            txt_userPasswordNew.Name = "txt_userPasswordNew";
            txt_userPasswordNew.PasswordChar = '*';
            txt_userPasswordNew.Size = new Size(282, 30);
            txt_userPasswordNew.TabIndex = 78;
            // 
            // lb_userPasswordHash
            // 
            lb_userPasswordHash.BackColor = Color.Transparent;
            lb_userPasswordHash.Font = new Font("Segoe UI", 10.2F, FontStyle.Italic);
            lb_userPasswordHash.Location = new Point(7, 109);
            lb_userPasswordHash.Name = "lb_userPasswordHash";
            lb_userPasswordHash.Size = new Size(158, 23);
            lb_userPasswordHash.TabIndex = 75;
            lb_userPasswordHash.Text = "Mật khẩu cũ:  ";
            lb_userPasswordHash.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txt_userPasswordHash
            // 
            txt_userPasswordHash.Location = new Point(171, 102);
            txt_userPasswordHash.Name = "txt_userPasswordHash";
            txt_userPasswordHash.PasswordChar = '*';
            txt_userPasswordHash.Size = new Size(282, 30);
            txt_userPasswordHash.TabIndex = 76;
            // 
            // lb_userUserName
            // 
            lb_userUserName.BackColor = Color.Transparent;
            lb_userUserName.Font = new Font("Segoe UI", 10.2F, FontStyle.Italic);
            lb_userUserName.Location = new Point(7, 48);
            lb_userUserName.Name = "lb_userUserName";
            lb_userUserName.Size = new Size(158, 23);
            lb_userUserName.TabIndex = 74;
            lb_userUserName.Text = "Tên đăng nhập: ";
            lb_userUserName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txt_userUserName
            // 
            txt_userUserName.Location = new Point(171, 45);
            txt_userUserName.Name = "txt_userUserName";
            txt_userUserName.Size = new Size(282, 30);
            txt_userUserName.TabIndex = 74;
            // 
            // btn_changePassword
            // 
            btn_changePassword.Location = new Point(662, 594);
            btn_changePassword.Name = "btn_changePassword";
            btn_changePassword.Size = new Size(459, 57);
            btn_changePassword.TabIndex = 68;
            btn_changePassword.Text = "Đổi mật khẩu";
            btn_changePassword.UseVisualStyleBackColor = true;
            btn_changePassword.Click += btn_changePassword_Click;
            // 
            // frm_users_manager
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MistyRose;
            ClientSize = new Size(1153, 666);
            Controls.Add(btn_changePassword);
            Controls.Add(groupBox_user);
            Controls.Add(groupBox_listUser);
            Controls.Add(lb_frm_users_manager_title);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frm_users_manager";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý tài khoản";
            Load += frm_users_manager_Load;
            groupBox_listUser.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv_lisUser).EndInit();
            groupBox_user.ResumeLayout(false);
            groupBox_user.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lb_frm_users_manager_title;
        private GroupBox groupBox_listUser;
        private DataGridView dgv_lisUser;
        private GroupBox groupBox_user;
        private Label lb_userPasswordHash;
        private TextBox txt_userPasswordHash;
        private Label lb_userUserName;
        private TextBox txt_userUserName;
        private Label lb_userPasswordNew;
        private TextBox txt_userPasswordNew;
        private Button btn_changePassword;
        private Button btn_showPasswordNew;
        private Button btn_showPassword;
        private Button btn_showPasswordConfirm;
        private Label lb_userPasswordConfirm;
        private TextBox txt_userPasswordConfirm;
    }
}