namespace PresentationLayer
{
    partial class frm_roles_manager
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
            dgv_listRole = new DataGridView();
            groupBox_roles = new GroupBox();
            lb_frm_roles_manager_title = new Label();
            ((System.ComponentModel.ISupportInitialize)dgv_listRole).BeginInit();
            groupBox_roles.SuspendLayout();
            SuspendLayout();
            // 
            // dgv_listRole
            // 
            dgv_listRole.AllowUserToAddRows = false;
            dgv_listRole.AllowUserToDeleteRows = false;
            dgv_listRole.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_listRole.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_listRole.Dock = DockStyle.Fill;
            dgv_listRole.Location = new Point(3, 23);
            dgv_listRole.Name = "dgv_listRole";
            dgv_listRole.ReadOnly = true;
            dgv_listRole.RowHeadersWidth = 51;
            dgv_listRole.Size = new Size(1133, 514);
            dgv_listRole.TabIndex = 0;
            // 
            // groupBox_roles
            // 
            groupBox_roles.Controls.Add(dgv_listRole);
            groupBox_roles.Location = new Point(12, 161);
            groupBox_roles.Name = "groupBox_roles";
            groupBox_roles.Size = new Size(1139, 540);
            groupBox_roles.TabIndex = 1;
            groupBox_roles.TabStop = false;
            groupBox_roles.Text = "Danh sách quyền :";
            // 
            // lb_frm_roles_manager_title
            // 
            lb_frm_roles_manager_title.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lb_frm_roles_manager_title.Location = new Point(430, 9);
            lb_frm_roles_manager_title.Name = "lb_frm_roles_manager_title";
            lb_frm_roles_manager_title.Size = new Size(318, 63);
            lb_frm_roles_manager_title.TabIndex = 20;
            lb_frm_roles_manager_title.Text = "Quản lý quyền";
            lb_frm_roles_manager_title.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // frm_roles_manager
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MistyRose;
            ClientSize = new Size(1163, 713);
            Controls.Add(lb_frm_roles_manager_title);
            Controls.Add(groupBox_roles);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frm_roles_manager";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý quyền";
            Load += frm_roles_manager_Load;
            ((System.ComponentModel.ISupportInitialize)dgv_listRole).EndInit();
            groupBox_roles.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgv_listRole;
        private GroupBox groupBox_roles;
        private Label lb_frm_roles_manager_title;
    }
}