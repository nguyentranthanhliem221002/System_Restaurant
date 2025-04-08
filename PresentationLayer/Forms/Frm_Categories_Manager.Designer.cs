namespace PresentationLayer
{
    partial class frm_categories_manager
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
            txt_categoryName = new TextBox();
            lb_categoryName = new Label();
            lb_frm_categories_manager_title = new Label();
            groupBox_listCategory = new GroupBox();
            dgv_listCategory = new DataGridView();
            btn_categoryAdd = new Button();
            btn_categoryDelete = new Button();
            btn_categoryFix = new Button();
            btn_categoryUpdate = new Button();
            txt_categorySearch = new TextBox();
            lb_categorySearch = new Label();
            btn_categorySearch = new Button();
            groupBox_listCategory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_listCategory).BeginInit();
            SuspendLayout();
            // 
            // txt_categoryName
            // 
            txt_categoryName.Location = new Point(144, 84);
            txt_categoryName.Name = "txt_categoryName";
            txt_categoryName.Size = new Size(299, 30);
            txt_categoryName.TabIndex = 30;
            // 
            // lb_categoryName
            // 
            lb_categoryName.AutoSize = true;
            lb_categoryName.BackColor = Color.Transparent;
            lb_categoryName.Font = new Font("Segoe UI", 10.2F, FontStyle.Italic);
            lb_categoryName.Location = new Point(28, 92);
            lb_categoryName.Name = "lb_categoryName";
            lb_categoryName.Size = new Size(82, 23);
            lb_categoryName.TabIndex = 20;
            lb_categoryName.Text = "Tên loại : ";
            lb_categoryName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lb_frm_categories_manager_title
            // 
            lb_frm_categories_manager_title.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lb_frm_categories_manager_title.Location = new Point(471, 10);
            lb_frm_categories_manager_title.Name = "lb_frm_categories_manager_title";
            lb_frm_categories_manager_title.Size = new Size(358, 72);
            lb_frm_categories_manager_title.TabIndex = 19;
            lb_frm_categories_manager_title.Text = "Quản lý loại";
            lb_frm_categories_manager_title.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // groupBox_listCategory
            // 
            groupBox_listCategory.Controls.Add(dgv_listCategory);
            groupBox_listCategory.Font = new Font("Segoe UI", 10.2F, FontStyle.Italic);
            groupBox_listCategory.Location = new Point(28, 202);
            groupBox_listCategory.Name = "groupBox_listCategory";
            groupBox_listCategory.Size = new Size(1241, 528);
            groupBox_listCategory.TabIndex = 36;
            groupBox_listCategory.TabStop = false;
            groupBox_listCategory.Text = "Danh sách loại  :";
            // 
            // dgv_listCategory
            // 
            dgv_listCategory.AllowUserToAddRows = false;
            dgv_listCategory.AllowUserToDeleteRows = false;
            dgv_listCategory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10.2F, FontStyle.Italic);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgv_listCategory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgv_listCategory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10.2F, FontStyle.Italic);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgv_listCategory.DefaultCellStyle = dataGridViewCellStyle2;
            dgv_listCategory.Dock = DockStyle.Fill;
            dgv_listCategory.Location = new Point(3, 26);
            dgv_listCategory.Name = "dgv_listCategory";
            dgv_listCategory.ReadOnly = true;
            dgv_listCategory.RowHeadersWidth = 51;
            dgv_listCategory.Size = new Size(1235, 499);
            dgv_listCategory.TabIndex = 1;
            // 
            // btn_categoryAdd
            // 
            btn_categoryAdd.BackColor = Color.Chartreuse;
            btn_categoryAdd.Font = new Font("Segoe UI", 10.2F, FontStyle.Italic);
            btn_categoryAdd.ForeColor = Color.Black;
            btn_categoryAdd.Location = new Point(32, 737);
            btn_categoryAdd.Name = "btn_categoryAdd";
            btn_categoryAdd.Size = new Size(290, 69);
            btn_categoryAdd.TabIndex = 37;
            btn_categoryAdd.Text = "Thêm";
            btn_categoryAdd.UseVisualStyleBackColor = false;
            btn_categoryAdd.Click += btn_categoryAdd_Click;
            // 
            // btn_categoryDelete
            // 
            btn_categoryDelete.Font = new Font("Segoe UI", 10.2F, FontStyle.Italic);
            btn_categoryDelete.Location = new Point(348, 737);
            btn_categoryDelete.Name = "btn_categoryDelete";
            btn_categoryDelete.Size = new Size(290, 69);
            btn_categoryDelete.TabIndex = 38;
            btn_categoryDelete.Text = "Xóa";
            btn_categoryDelete.UseVisualStyleBackColor = true;
            btn_categoryDelete.Click += btn_categoryDelete_Click;
            // 
            // btn_categoryFix
            // 
            btn_categoryFix.BackColor = Color.Silver;
            btn_categoryFix.Font = new Font("Segoe UI", 10.2F, FontStyle.Italic);
            btn_categoryFix.ForeColor = SystemColors.ControlText;
            btn_categoryFix.Location = new Point(665, 737);
            btn_categoryFix.Name = "btn_categoryFix";
            btn_categoryFix.Size = new Size(290, 69);
            btn_categoryFix.TabIndex = 39;
            btn_categoryFix.Text = "Sửa";
            btn_categoryFix.UseVisualStyleBackColor = false;
            btn_categoryFix.Click += btn_categoryFix_Click;
            // 
            // btn_categoryUpdate
            // 
            btn_categoryUpdate.BackColor = Color.Coral;
            btn_categoryUpdate.Font = new Font("Segoe UI", 10.2F, FontStyle.Italic);
            btn_categoryUpdate.Location = new Point(979, 737);
            btn_categoryUpdate.Name = "btn_categoryUpdate";
            btn_categoryUpdate.Size = new Size(290, 69);
            btn_categoryUpdate.TabIndex = 40;
            btn_categoryUpdate.Text = "Cập nhật";
            btn_categoryUpdate.UseVisualStyleBackColor = false;
            btn_categoryUpdate.Click += btn_categoryUpdate_Click;
            // 
            // txt_categorySearch
            // 
            txt_categorySearch.Location = new Point(928, 89);
            txt_categorySearch.Name = "txt_categorySearch";
            txt_categorySearch.Size = new Size(340, 30);
            txt_categorySearch.TabIndex = 42;
            // 
            // lb_categorySearch
            // 
            lb_categorySearch.AutoSize = true;
            lb_categorySearch.BackColor = Color.Transparent;
            lb_categorySearch.Font = new Font("Segoe UI", 10.2F, FontStyle.Italic);
            lb_categorySearch.Location = new Point(838, 97);
            lb_categorySearch.Name = "lb_categorySearch";
            lb_categorySearch.Size = new Size(83, 23);
            lb_categorySearch.TabIndex = 41;
            lb_categorySearch.Text = "Tìm loại : ";
            lb_categorySearch.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btn_categorySearch
            // 
            btn_categorySearch.BackColor = Color.Aqua;
            btn_categorySearch.Font = new Font("Segoe UI", 10.2F, FontStyle.Italic);
            btn_categorySearch.Location = new Point(928, 126);
            btn_categorySearch.Name = "btn_categorySearch";
            btn_categorySearch.Size = new Size(341, 49);
            btn_categorySearch.TabIndex = 43;
            btn_categorySearch.Text = "Tìm kiếm";
            btn_categorySearch.UseVisualStyleBackColor = false;
            btn_categorySearch.Click += btn_categorySearch_Click;
            // 
            // frm_categories_manager
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MistyRose;
            ClientSize = new Size(1308, 820);
            Controls.Add(btn_categorySearch);
            Controls.Add(txt_categorySearch);
            Controls.Add(lb_categorySearch);
            Controls.Add(btn_categoryUpdate);
            Controls.Add(btn_categoryFix);
            Controls.Add(btn_categoryDelete);
            Controls.Add(btn_categoryAdd);
            Controls.Add(groupBox_listCategory);
            Controls.Add(txt_categoryName);
            Controls.Add(lb_categoryName);
            Controls.Add(lb_frm_categories_manager_title);
            Font = new Font("Segoe UI", 10.2F, FontStyle.Italic);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frm_categories_manager";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý loại";
            Load += frm_categories_manager_Load;
            groupBox_listCategory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv_listCategory).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txt_categoryName;
        private Label lb_categoryName;
        private Label lb_frm_categories_manager_title;
        private GroupBox groupBox_listCategory;
        private DataGridView dgv_listCategory;
        private Button btn_categoryAdd;
        private Button btn_categoryDelete;
        private Button btn_categoryFix;
        private Button btn_categoryUpdate;
        private TextBox txt_categorySearch;
        private Label lb_categorySearch;
        private Button btn_categorySearch;
    }
}