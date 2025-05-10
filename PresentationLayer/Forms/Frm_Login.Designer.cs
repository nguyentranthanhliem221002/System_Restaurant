namespace PresentationLayer
{
    partial class frm_login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_login));
            lb_frm_login_title = new Label();
            panel_frm_login = new Panel();
            lb_userName = new Label();
            lb_password = new Label();
            txt_userName = new TextBox();
            txt_password = new TextBox();
            btn_submit = new Button();
            btn_hideFrm = new Button();
            btn_smallFrm = new Button();
            btn_exitFrm = new Button();
            btn_showPassword = new Button();
            SuspendLayout();
            // 
            // lb_frm_login_title
            // 
            lb_frm_login_title.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lb_frm_login_title.Location = new Point(731, 136);
            lb_frm_login_title.Name = "lb_frm_login_title";
            lb_frm_login_title.Size = new Size(318, 63);
            lb_frm_login_title.TabIndex = 2;
            lb_frm_login_title.Text = "Đăng nhập";
            lb_frm_login_title.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel_frm_login
            // 
            panel_frm_login.BackColor = Color.White;
            panel_frm_login.BackgroundImage = (Image)resources.GetObject("panel_frm_login.BackgroundImage");
            panel_frm_login.Location = new Point(0, 0);
            panel_frm_login.Name = "panel_frm_login";
            panel_frm_login.Size = new Size(580, 713);
            panel_frm_login.TabIndex = 3;
            // 
            // lb_userName
            // 
            lb_userName.AutoSize = true;
            lb_userName.Font = new Font("Segoe UI", 10.2F, FontStyle.Italic);
            lb_userName.Location = new Point(625, 242);
            lb_userName.Name = "lb_userName";
            lb_userName.Size = new Size(121, 23);
            lb_userName.TabIndex = 4;
            lb_userName.Text = "Tên đăng nhập";
            lb_userName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lb_password
            // 
            lb_password.AutoSize = true;
            lb_password.Font = new Font("Segoe UI", 10.2F, FontStyle.Italic);
            lb_password.Location = new Point(625, 316);
            lb_password.Name = "lb_password";
            lb_password.Size = new Size(79, 23);
            lb_password.TabIndex = 5;
            lb_password.Text = "Mật khẩu";
            lb_password.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txt_userName
            // 
            txt_userName.Location = new Point(763, 242);
            txt_userName.Name = "txt_userName";
            txt_userName.Size = new Size(286, 27);
            txt_userName.TabIndex = 6;
            // 
            // txt_password
            // 
            txt_password.Location = new Point(763, 309);
            txt_password.Name = "txt_password";
            txt_password.PasswordChar = '*';
            txt_password.Size = new Size(319, 27);
            txt_password.TabIndex = 7;
            // 
            // btn_submit
            // 
            btn_submit.BackColor = Color.Red;
            btn_submit.Font = new Font("Segoe UI", 10.2F, FontStyle.Italic);
            btn_submit.ForeColor = Color.Black;
            btn_submit.Location = new Point(763, 411);
            btn_submit.Name = "btn_submit";
            btn_submit.Size = new Size(286, 60);
            btn_submit.TabIndex = 8;
            btn_submit.Text = "Đăng nhập";
            btn_submit.UseVisualStyleBackColor = false;
            btn_submit.Click += btn_submit_Click;
            // 
            // btn_hideFrm
            // 
            btn_hideFrm.BackColor = Color.Silver;
            btn_hideFrm.ForeColor = Color.White;
            btn_hideFrm.Location = new Point(966, 12);
            btn_hideFrm.Name = "btn_hideFrm";
            btn_hideFrm.Size = new Size(40, 40);
            btn_hideFrm.TabIndex = 12;
            btn_hideFrm.Text = "-";
            btn_hideFrm.UseVisualStyleBackColor = false;
            // 
            // btn_smallFrm
            // 
            btn_smallFrm.BackColor = Color.Red;
            btn_smallFrm.ForeColor = Color.White;
            btn_smallFrm.Location = new Point(1042, 12);
            btn_smallFrm.Name = "btn_smallFrm";
            btn_smallFrm.Size = new Size(40, 40);
            btn_smallFrm.TabIndex = 11;
            btn_smallFrm.Text = "[ ]";
            btn_smallFrm.UseVisualStyleBackColor = false;
            // 
            // btn_exitFrm
            // 
            btn_exitFrm.BackColor = Color.Red;
            btn_exitFrm.ForeColor = Color.White;
            btn_exitFrm.Location = new Point(1111, 12);
            btn_exitFrm.Name = "btn_exitFrm";
            btn_exitFrm.Size = new Size(40, 40);
            btn_exitFrm.TabIndex = 10;
            btn_exitFrm.Text = "x";
            btn_exitFrm.UseVisualStyleBackColor = false;
            btn_exitFrm.Click += btn_exitFrm_Click;
            // 
            // btn_showPassword
            // 
            btn_showPassword.BackColor = SystemColors.GradientInactiveCaption;
            btn_showPassword.BackgroundImage = (Image)resources.GetObject("btn_showPassword.BackgroundImage");
            btn_showPassword.BackgroundImageLayout = ImageLayout.Zoom;
            btn_showPassword.Location = new Point(1042, 307);
            btn_showPassword.Name = "btn_showPassword";
            btn_showPassword.Size = new Size(42, 29);
            btn_showPassword.TabIndex = 82;
            btn_showPassword.UseVisualStyleBackColor = false;
            btn_showPassword.Click += btn_showPassword_Click;
            // 
            // frm_login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSalmon;
            ClientSize = new Size(1163, 713);
            Controls.Add(btn_showPassword);
            Controls.Add(btn_hideFrm);
            Controls.Add(btn_smallFrm);
            Controls.Add(btn_exitFrm);
            Controls.Add(btn_submit);
            Controls.Add(txt_password);
            Controls.Add(txt_userName);
            Controls.Add(lb_password);
            Controls.Add(lb_userName);
            Controls.Add(panel_frm_login);
            Controls.Add(lb_frm_login_title);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frm_login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng nhập";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lb_frm_login_title;
        private Panel panel_frm_login;
        private Label lb_userName;
        private Label lb_password;
        private TextBox txt_userName;
        private TextBox txt_password;
        private Button btn_submit;
        private Button btn_hideFrm;
        private Button btn_smallFrm;
        private Button btn_exitFrm;
        private Button btn_showPassword;
    }
}