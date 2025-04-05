namespace PresentationLayer
{
    partial class frm_foods_manager
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
            lb_foodName = new Label();
            lb_foodPrice = new Label();
            lb_foodImage = new Label();
            lb_foodCategory = new Label();
            pictureBox_foodImage = new PictureBox();
            btn_loadImage = new Button();
            txt_foodName = new TextBox();
            txt_foodPrice = new TextBox();
            comboBox_listCategory = new ComboBox();
            lb_foodDescription = new Label();
            txt_foodDescription = new TextBox();
            btn_frm_categories_manager = new Button();
            groupBox_listFood = new GroupBox();
            dgv_listFood = new DataGridView();
            btn_foodSearch = new Button();
            txt_foodSearch = new TextBox();
            lb_foodSearch = new Label();
            btn_foodUpdate = new Button();
            btn_foodFix = new Button();
            btn_foodDelete = new Button();
            btn_foodAdd = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox_foodImage).BeginInit();
            groupBox_listFood.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_listFood).BeginInit();
            SuspendLayout();
            // 
            // lb_frm_foods_manager_title
            // 
            lb_frm_foods_manager_title.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lb_frm_foods_manager_title.Location = new Point(420, 9);
            lb_frm_foods_manager_title.Name = "lb_frm_foods_manager_title";
            lb_frm_foods_manager_title.Size = new Size(318, 63);
            lb_frm_foods_manager_title.TabIndex = 1;
            lb_frm_foods_manager_title.Text = "Quản lý món ăn";
            lb_frm_foods_manager_title.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lb_foodName
            // 
            lb_foodName.AutoSize = true;
            lb_foodName.BackColor = Color.Transparent;
            lb_foodName.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lb_foodName.Location = new Point(26, 80);
            lb_foodName.Name = "lb_foodName";
            lb_foodName.Size = new Size(97, 20);
            lb_foodName.TabIndex = 2;
            lb_foodName.Text = "Tên món ăn : ";
            lb_foodName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lb_foodPrice
            // 
            lb_foodPrice.AutoSize = true;
            lb_foodPrice.BackColor = Color.Transparent;
            lb_foodPrice.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lb_foodPrice.Location = new Point(26, 126);
            lb_foodPrice.Name = "lb_foodPrice";
            lb_foodPrice.Size = new Size(72, 20);
            lb_foodPrice.TabIndex = 3;
            lb_foodPrice.Text = "Giá món :";
            lb_foodPrice.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lb_foodImage
            // 
            lb_foodImage.AutoSize = true;
            lb_foodImage.BackColor = Color.Transparent;
            lb_foodImage.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lb_foodImage.Location = new Point(420, 77);
            lb_foodImage.Name = "lb_foodImage";
            lb_foodImage.Size = new Size(79, 20);
            lb_foodImage.TabIndex = 4;
            lb_foodImage.Text = "Hình ảnh : ";
            lb_foodImage.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lb_foodCategory
            // 
            lb_foodCategory.AutoSize = true;
            lb_foodCategory.BackColor = Color.Transparent;
            lb_foodCategory.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lb_foodCategory.Location = new Point(26, 271);
            lb_foodCategory.Name = "lb_foodCategory";
            lb_foodCategory.Size = new Size(48, 20);
            lb_foodCategory.TabIndex = 5;
            lb_foodCategory.Text = "Loại : ";
            lb_foodCategory.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pictureBox_foodImage
            // 
            pictureBox_foodImage.Location = new Point(420, 119);
            pictureBox_foodImage.Name = "pictureBox_foodImage";
            pictureBox_foodImage.Size = new Size(333, 172);
            pictureBox_foodImage.TabIndex = 10;
            pictureBox_foodImage.TabStop = false;
            // 
            // btn_loadImage
            // 
            btn_loadImage.Location = new Point(505, 70);
            btn_loadImage.Name = "btn_loadImage";
            btn_loadImage.Size = new Size(148, 30);
            btn_loadImage.TabIndex = 11;
            btn_loadImage.Text = "Tải ảnh";
            btn_loadImage.UseVisualStyleBackColor = true;
            btn_loadImage.Click += btn_loadImage_Click;
            // 
            // txt_foodName
            // 
            txt_foodName.Location = new Point(129, 77);
            txt_foodName.Name = "txt_foodName";
            txt_foodName.Size = new Size(280, 27);
            txt_foodName.TabIndex = 12;
            // 
            // txt_foodPrice
            // 
            txt_foodPrice.Location = new Point(129, 119);
            txt_foodPrice.Name = "txt_foodPrice";
            txt_foodPrice.Size = new Size(280, 27);
            txt_foodPrice.TabIndex = 13;
            // 
            // comboBox_listCategory
            // 
            comboBox_listCategory.FormattingEnabled = true;
            comboBox_listCategory.Location = new Point(129, 263);
            comboBox_listCategory.Name = "comboBox_listCategory";
            comboBox_listCategory.Size = new Size(139, 28);
            comboBox_listCategory.TabIndex = 14;
            // 
            // lb_foodDescription
            // 
            lb_foodDescription.AutoSize = true;
            lb_foodDescription.BackColor = Color.Transparent;
            lb_foodDescription.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lb_foodDescription.Location = new Point(26, 162);
            lb_foodDescription.Name = "lb_foodDescription";
            lb_foodDescription.Size = new Size(81, 20);
            lb_foodDescription.TabIndex = 15;
            lb_foodDescription.Text = "Chú thích : ";
            lb_foodDescription.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txt_foodDescription
            // 
            txt_foodDescription.Location = new Point(129, 162);
            txt_foodDescription.Multiline = true;
            txt_foodDescription.Name = "txt_foodDescription";
            txt_foodDescription.Size = new Size(280, 85);
            txt_foodDescription.TabIndex = 16;
            // 
            // btn_frm_categories_manager
            // 
            btn_frm_categories_manager.Location = new Point(274, 263);
            btn_frm_categories_manager.Name = "btn_frm_categories_manager";
            btn_frm_categories_manager.Size = new Size(135, 28);
            btn_frm_categories_manager.TabIndex = 17;
            btn_frm_categories_manager.Text = "Quản lý loại";
            btn_frm_categories_manager.UseVisualStyleBackColor = true;
            btn_frm_categories_manager.Click += btn_frm_categories_manager_Click;
            // 
            // groupBox_listFood
            // 
            groupBox_listFood.Controls.Add(dgv_listFood);
            groupBox_listFood.Location = new Point(26, 318);
            groupBox_listFood.Name = "groupBox_listFood";
            groupBox_listFood.Size = new Size(1103, 317);
            groupBox_listFood.TabIndex = 18;
            groupBox_listFood.TabStop = false;
            groupBox_listFood.Text = "Danh sách món ăn :";
            // 
            // dgv_listFood
            // 
            dgv_listFood.AllowUserToAddRows = false;
            dgv_listFood.AllowUserToDeleteRows = false;
            dgv_listFood.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_listFood.BackgroundColor = SystemColors.Control;
            dgv_listFood.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_listFood.Dock = DockStyle.Fill;
            dgv_listFood.Location = new Point(3, 23);
            dgv_listFood.Name = "dgv_listFood";
            dgv_listFood.ReadOnly = true;
            dgv_listFood.RowHeadersWidth = 51;
            dgv_listFood.Size = new Size(1097, 291);
            dgv_listFood.TabIndex = 1;
            // 
            // btn_foodSearch
            // 
            btn_foodSearch.BackColor = Color.Aqua;
            btn_foodSearch.Location = new Point(826, 106);
            btn_foodSearch.Name = "btn_foodSearch";
            btn_foodSearch.Size = new Size(303, 43);
            btn_foodSearch.TabIndex = 46;
            btn_foodSearch.Text = "Search";
            btn_foodSearch.UseVisualStyleBackColor = false;
            btn_foodSearch.Click += btn_foodSearch_Click;
            // 
            // txt_foodSearch
            // 
            txt_foodSearch.Location = new Point(826, 73);
            txt_foodSearch.Name = "txt_foodSearch";
            txt_foodSearch.Size = new Size(303, 27);
            txt_foodSearch.TabIndex = 45;
            // 
            // lb_foodSearch
            // 
            lb_foodSearch.AutoSize = true;
            lb_foodSearch.BackColor = Color.Transparent;
            lb_foodSearch.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lb_foodSearch.Location = new Point(746, 80);
            lb_foodSearch.Name = "lb_foodSearch";
            lb_foodSearch.Size = new Size(74, 20);
            lb_foodSearch.TabIndex = 44;
            lb_foodSearch.Text = "Tìm loại : ";
            lb_foodSearch.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btn_foodUpdate
            // 
            btn_foodUpdate.BackColor = Color.Coral;
            btn_foodUpdate.Location = new Point(868, 641);
            btn_foodUpdate.Name = "btn_foodUpdate";
            btn_foodUpdate.Size = new Size(258, 60);
            btn_foodUpdate.TabIndex = 50;
            btn_foodUpdate.Text = "Cập nhật";
            btn_foodUpdate.UseVisualStyleBackColor = false;
            btn_foodUpdate.Click += btn_foodUpdate_Click;
            // 
            // btn_foodFix
            // 
            btn_foodFix.BackColor = Color.Silver;
            btn_foodFix.Location = new Point(594, 641);
            btn_foodFix.Name = "btn_foodFix";
            btn_foodFix.Size = new Size(258, 60);
            btn_foodFix.TabIndex = 49;
            btn_foodFix.Text = "Sửa";
            btn_foodFix.UseVisualStyleBackColor = false;
            btn_foodFix.Click += btn_foodFix_Click;
            // 
            // btn_foodDelete
            // 
            btn_foodDelete.Location = new Point(314, 641);
            btn_foodDelete.Name = "btn_foodDelete";
            btn_foodDelete.Size = new Size(258, 60);
            btn_foodDelete.TabIndex = 48;
            btn_foodDelete.Text = "Xóa";
            btn_foodDelete.UseVisualStyleBackColor = true;
            btn_foodDelete.Click += btn_foodDelete_Click;
            // 
            // btn_foodAdd
            // 
            btn_foodAdd.BackColor = Color.Chartreuse;
            btn_foodAdd.Location = new Point(29, 641);
            btn_foodAdd.Name = "btn_foodAdd";
            btn_foodAdd.Size = new Size(258, 60);
            btn_foodAdd.TabIndex = 47;
            btn_foodAdd.Text = "Thêm";
            btn_foodAdd.UseVisualStyleBackColor = false;
            btn_foodAdd.Click += btn_foodAdd_Click;
            // 
            // frm_foods_manager
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1163, 713);
            Controls.Add(btn_foodUpdate);
            Controls.Add(btn_foodFix);
            Controls.Add(btn_foodDelete);
            Controls.Add(btn_foodAdd);
            Controls.Add(btn_foodSearch);
            Controls.Add(txt_foodSearch);
            Controls.Add(lb_foodSearch);
            Controls.Add(groupBox_listFood);
            Controls.Add(btn_frm_categories_manager);
            Controls.Add(txt_foodDescription);
            Controls.Add(lb_foodDescription);
            Controls.Add(comboBox_listCategory);
            Controls.Add(txt_foodPrice);
            Controls.Add(txt_foodName);
            Controls.Add(btn_loadImage);
            Controls.Add(pictureBox_foodImage);
            Controls.Add(lb_foodCategory);
            Controls.Add(lb_foodImage);
            Controls.Add(lb_foodPrice);
            Controls.Add(lb_foodName);
            Controls.Add(lb_frm_foods_manager_title);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frm_foods_manager";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "L";
            Load += frm_foods_manager_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox_foodImage).EndInit();
            groupBox_listFood.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv_listFood).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lb_frm_foods_manager_title;
        private Label lb_foodName;
        private Label lb_foodPrice;
        private Label lb_foodImage;
        private Label lb_foodCategory;
        private PictureBox pictureBox_foodImage;
        private Button btn_loadImage;
        private TextBox txt_foodName;
        private TextBox txt_foodPrice;
        private ComboBox comboBox_listCategory;
        private Label lb_foodDescription;
        private TextBox txt_foodDescription;
        private Button btn_frm_categories_manager;
        private GroupBox groupBox_listFood;
        private DataGridView dgv_listFood;
        private Button btn_foodSearch;
        private TextBox txt_foodSearch;
        private Label lb_foodSearch;
        private Button btn_foodUpdate;
        private Button btn_foodFix;
        private Button btn_foodDelete;
        private Button btn_foodAdd;
    }
}