namespace PresentationLayer;

partial class frm_main
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_main));
        panel_sidebar = new Panel();
        btn_frm_employees_manager = new Button();
        btn_frm_roles_manager = new Button();
        btn_frm_orders_manager = new Button();
        btn_users_manager = new Button();
        btn_frm_foods_manager = new Button();
        btn_frm_tables_manager = new Button();
        panel_nav = new Panel();
        label1 = new Label();
        lb_frm_main_title = new Label();
        btn_exitFrm = new Button();
        lb_roleName = new Label();
        btn_hideFrm = new Button();
        btn_smallFrm = new Button();
        panel_container = new Panel();
        panel_sidebar.SuspendLayout();
        panel_nav.SuspendLayout();
        SuspendLayout();
        // 
        // panel_sidebar
        // 
        panel_sidebar.BackColor = Color.LightSalmon;
        panel_sidebar.Controls.Add(btn_frm_employees_manager);
        panel_sidebar.Controls.Add(btn_frm_roles_manager);
        panel_sidebar.Controls.Add(btn_frm_orders_manager);
        panel_sidebar.Controls.Add(btn_users_manager);
        panel_sidebar.Controls.Add(btn_frm_foods_manager);
        panel_sidebar.Controls.Add(btn_frm_tables_manager);
        panel_sidebar.Location = new Point(0, 87);
        panel_sidebar.Name = "panel_sidebar";
        panel_sidebar.Size = new Size(228, 713);
        panel_sidebar.TabIndex = 0;
        // 
        // btn_frm_employees_manager
        // 
        btn_frm_employees_manager.Font = new Font("Segoe UI", 10.2F, FontStyle.Italic);
        btn_frm_employees_manager.Location = new Point(12, 247);
        btn_frm_employees_manager.Name = "btn_frm_employees_manager";
        btn_frm_employees_manager.Size = new Size(202, 88);
        btn_frm_employees_manager.TabIndex = 5;
        btn_frm_employees_manager.Text = "Quản lý nhân viên";
        btn_frm_employees_manager.UseVisualStyleBackColor = true;
        btn_frm_employees_manager.Click += btn_frm_employees_manager_Click;
        // 
        // btn_frm_roles_manager
        // 
        btn_frm_roles_manager.Font = new Font("Segoe UI", 10.2F, FontStyle.Italic);
        btn_frm_roles_manager.Location = new Point(12, 490);
        btn_frm_roles_manager.Name = "btn_frm_roles_manager";
        btn_frm_roles_manager.Size = new Size(202, 88);
        btn_frm_roles_manager.TabIndex = 4;
        btn_frm_roles_manager.Text = "Quản lý quyền";
        btn_frm_roles_manager.UseVisualStyleBackColor = true;
        btn_frm_roles_manager.Click += btn_frm_roles_manager_Click;
        // 
        // btn_frm_orders_manager
        // 
        btn_frm_orders_manager.Font = new Font("Segoe UI", 10.2F, FontStyle.Italic);
        btn_frm_orders_manager.Location = new Point(12, 364);
        btn_frm_orders_manager.Name = "btn_frm_orders_manager";
        btn_frm_orders_manager.Size = new Size(202, 88);
        btn_frm_orders_manager.TabIndex = 3;
        btn_frm_orders_manager.Text = "Doanh thu";
        btn_frm_orders_manager.UseVisualStyleBackColor = true;
        btn_frm_orders_manager.Click += btn_frm_order_manager_Click;
        // 
        // btn_users_manager
        // 
        btn_users_manager.Font = new Font("Segoe UI", 10.2F, FontStyle.Italic, GraphicsUnit.Point, 0);
        btn_users_manager.Location = new Point(12, 613);
        btn_users_manager.Name = "btn_users_manager";
        btn_users_manager.Size = new Size(202, 88);
        btn_users_manager.TabIndex = 2;
        btn_users_manager.Text = "Tài khoản";
        btn_users_manager.UseVisualStyleBackColor = true;
        btn_users_manager.Click += btn_users_manager_Click;
        // 
        // btn_frm_foods_manager
        // 
        btn_frm_foods_manager.Font = new Font("Segoe UI", 10.2F, FontStyle.Italic);
        btn_frm_foods_manager.Location = new Point(12, 129);
        btn_frm_foods_manager.Name = "btn_frm_foods_manager";
        btn_frm_foods_manager.Size = new Size(202, 88);
        btn_frm_foods_manager.TabIndex = 1;
        btn_frm_foods_manager.Text = "Quản lý món ";
        btn_frm_foods_manager.UseVisualStyleBackColor = true;
        btn_frm_foods_manager.Click += btn_frm_foods_manager_Click;
        // 
        // btn_frm_tables_manager
        // 
        btn_frm_tables_manager.Font = new Font("Segoe UI", 10.2F, FontStyle.Italic);
        btn_frm_tables_manager.Location = new Point(12, 6);
        btn_frm_tables_manager.Name = "btn_frm_tables_manager";
        btn_frm_tables_manager.Size = new Size(202, 88);
        btn_frm_tables_manager.TabIndex = 0;
        btn_frm_tables_manager.Text = "Sơ đồ bàn ăn";
        btn_frm_tables_manager.UseVisualStyleBackColor = true;
        btn_frm_tables_manager.Click += btn_frm_tables_manager_Click;
        // 
        // panel_nav
        // 
        panel_nav.BackColor = Color.Tomato;
        panel_nav.Controls.Add(label1);
        panel_nav.Controls.Add(lb_frm_main_title);
        panel_nav.Controls.Add(btn_exitFrm);
        panel_nav.Controls.Add(lb_roleName);
        panel_nav.Controls.Add(btn_hideFrm);
        panel_nav.Controls.Add(btn_smallFrm);
        panel_nav.Location = new Point(0, -1);
        panel_nav.Name = "panel_nav";
        panel_nav.Size = new Size(1391, 88);
        panel_nav.TabIndex = 1;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Italic);
        label1.ForeColor = Color.White;
        label1.Location = new Point(948, 40);
        label1.Name = "label1";
        label1.Size = new Size(128, 23);
        label1.TabIndex = 5;
        label1.Text = "Đăng nhập bởi :";
        label1.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lb_frm_main_title
        // 
        lb_frm_main_title.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
        lb_frm_main_title.ForeColor = Color.White;
        lb_frm_main_title.Location = new Point(12, 10);
        lb_frm_main_title.Name = "lb_frm_main_title";
        lb_frm_main_title.Size = new Size(327, 65);
        lb_frm_main_title.TabIndex = 3;
        lb_frm_main_title.Text = "System Restaurant";
        lb_frm_main_title.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // btn_exitFrm
        // 
        btn_exitFrm.BackColor = Color.Red;
        btn_exitFrm.ForeColor = Color.White;
        btn_exitFrm.Location = new Point(1343, 26);
        btn_exitFrm.Name = "btn_exitFrm";
        btn_exitFrm.Size = new Size(35, 35);
        btn_exitFrm.TabIndex = 0;
        btn_exitFrm.Text = "x";
        btn_exitFrm.UseVisualStyleBackColor = false;
        btn_exitFrm.Click += btn_exitFrm_Click;
        // 
        // lb_roleName
        // 
        lb_roleName.AutoSize = true;
        lb_roleName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lb_roleName.Location = new Point(1100, 33);
        lb_roleName.Name = "lb_roleName";
        lb_roleName.Size = new Size(39, 28);
        lb_roleName.TabIndex = 4;
        lb_roleName.Text = "???";
        lb_roleName.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // btn_hideFrm
        // 
        btn_hideFrm.BackColor = Color.Silver;
        btn_hideFrm.ForeColor = Color.White;
        btn_hideFrm.Location = new Point(1240, 26);
        btn_hideFrm.Name = "btn_hideFrm";
        btn_hideFrm.Size = new Size(35, 35);
        btn_hideFrm.TabIndex = 2;
        btn_hideFrm.Text = "-";
        btn_hideFrm.UseVisualStyleBackColor = false;
        // 
        // btn_smallFrm
        // 
        btn_smallFrm.BackColor = Color.Red;
        btn_smallFrm.ForeColor = Color.White;
        btn_smallFrm.Location = new Point(1293, 26);
        btn_smallFrm.Name = "btn_smallFrm";
        btn_smallFrm.Size = new Size(35, 35);
        btn_smallFrm.TabIndex = 1;
        btn_smallFrm.Text = "[ ]";
        btn_smallFrm.UseVisualStyleBackColor = false;
        // 
        // panel_container
        // 
        panel_container.BackColor = SystemColors.Control;
        panel_container.BackgroundImage = (Image)resources.GetObject("panel_container.BackgroundImage");
        panel_container.BackgroundImageLayout = ImageLayout.Stretch;
        panel_container.Location = new Point(220, 87);
        panel_container.Name = "panel_container";
        panel_container.Size = new Size(1171, 713);
        panel_container.TabIndex = 0;
        // 
        // frm_main
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.White;
        ClientSize = new Size(1390, 800);
        Controls.Add(panel_container);
        Controls.Add(panel_nav);
        Controls.Add(panel_sidebar);
        FormBorderStyle = FormBorderStyle.None;
        Name = "frm_main";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Trang chủ";
        Load += frm_main_Load;
        panel_sidebar.ResumeLayout(false);
        panel_nav.ResumeLayout(false);
        panel_nav.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private Panel panel_sidebar;
    private Panel panel_nav;
    private Button btn_hideFrm;
    private Button btn_smallFrm;
    private Button btn_exitFrm;
    private Panel panel_container;
    private Button btn_frm_tables_manager;
    private Label lb_frm_main_title;
    private Button btn_users_manager;
    private Button btn_frm_foods_manager;
    private Button btn_frm_employees_manager;
    private Button btn_frm_roles_manager;
    private Button btn_frm_orders_manager;
    private Label lb_roleName;
    private Label label1;
}
