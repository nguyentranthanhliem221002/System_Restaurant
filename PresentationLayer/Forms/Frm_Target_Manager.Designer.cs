namespace PresentationLayer.Forms
{
    partial class frm_target_manager
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
            lb_frm_foods_manager_title = new Label();
            dgv_target = new DataGridView();
            groupBox_target = new GroupBox();
            lb_targetTime = new Label();
            dateTimePicker_targetTime = new DateTimePicker();
            btn_targetSearch = new Button();
            ((System.ComponentModel.ISupportInitialize)dgv_target).BeginInit();
            groupBox_target.SuspendLayout();
            SuspendLayout();
            // 
            // lb_frm_foods_manager_title
            // 
            lb_frm_foods_manager_title.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lb_frm_foods_manager_title.Location = new Point(396, 9);
            lb_frm_foods_manager_title.Name = "lb_frm_foods_manager_title";
            lb_frm_foods_manager_title.Size = new Size(368, 63);
            lb_frm_foods_manager_title.TabIndex = 2;
            lb_frm_foods_manager_title.Text = "Thống kê doanh thu";
            lb_frm_foods_manager_title.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dgv_target
            // 
            dgv_target.AllowUserToAddRows = false;
            dgv_target.AllowUserToDeleteRows = false;
            dgv_target.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_target.BorderStyle = BorderStyle.None;
            dgv_target.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_target.Dock = DockStyle.Fill;
            dgv_target.Location = new Point(3, 23);
            dgv_target.Name = "dgv_target";
            dgv_target.ReadOnly = true;
            dgv_target.RowHeadersWidth = 51;
            dgv_target.Size = new Size(1133, 452);
            dgv_target.TabIndex = 3;
            // 
            // groupBox_target
            // 
            groupBox_target.Controls.Add(dgv_target);
            groupBox_target.Location = new Point(12, 223);
            groupBox_target.Name = "groupBox_target";
            groupBox_target.Size = new Size(1139, 478);
            groupBox_target.TabIndex = 4;
            groupBox_target.TabStop = false;
            groupBox_target.Text = "Doanh thu : ";
            // 
            // lb_targetTime
            // 
            lb_targetTime.AutoSize = true;
            lb_targetTime.BackColor = Color.Transparent;
            lb_targetTime.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lb_targetTime.Location = new Point(21, 78);
            lb_targetTime.Name = "lb_targetTime";
            lb_targetTime.Size = new Size(137, 20);
            lb_targetTime.TabIndex = 13;
            lb_targetTime.Text = "Ngày/ Tháng/ Năm";
            lb_targetTime.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dateTimePicker_targetTime
            // 
            dateTimePicker_targetTime.Location = new Point(164, 75);
            dateTimePicker_targetTime.Name = "dateTimePicker_targetTime";
            dateTimePicker_targetTime.Size = new Size(250, 27);
            dateTimePicker_targetTime.TabIndex = 15;
            // 
            // btn_targetSearch
            // 
            btn_targetSearch.Location = new Point(420, 75);
            btn_targetSearch.Name = "btn_targetSearch";
            btn_targetSearch.Size = new Size(94, 27);
            btn_targetSearch.TabIndex = 16;
            btn_targetSearch.Text = "Tìm kiếm";
            btn_targetSearch.UseVisualStyleBackColor = true;
            // 
            // frm_target_manager
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1163, 713);
            Controls.Add(btn_targetSearch);
            Controls.Add(dateTimePicker_targetTime);
            Controls.Add(lb_targetTime);
            Controls.Add(groupBox_target);
            Controls.Add(lb_frm_foods_manager_title);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frm_target_manager";
            Text = "Quản lý doanh thu";
            Load += frm_target_manager_Load;
            ((System.ComponentModel.ISupportInitialize)dgv_target).EndInit();
            groupBox_target.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lb_frm_foods_manager_title;
        private DataGridView dgv_target;
        private GroupBox groupBox_target;
        private Label lb_targetTime;
        private DateTimePicker dateTimePicker_targetTime;
        private Button btn_targetSearch;
    }
}