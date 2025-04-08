namespace PresentationLayer
{
    partial class frm_tables_manager
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
            ListViewItem listViewItem1 = new ListViewItem("");
            lb_frm_tables_manager_title = new Label();
            groupBox_listTable = new GroupBox();
            flowLayoutPanel_listTable = new FlowLayoutPanel();
            groupBox_infoTable = new GroupBox();
            listView_orderDetail = new ListView();
            Name = new ColumnHeader();
            Price = new ColumnHeader();
            Quantity = new ColumnHeader();
            SubTotal = new ColumnHeader();
            lb_tableStatus = new Label();
            lb_tableNumber = new Label();
            btn_pay = new Button();
            btn_print = new Button();
            groupBox_optionPays = new GroupBox();
            radioButton_optionMomo = new RadioButton();
            radioButton_optionBank = new RadioButton();
            radioButton_optionCash = new RadioButton();
            label1 = new Label();
            label2 = new Label();
            lb_sum = new Label();
            groupBox_tableSwap = new GroupBox();
            btn_tableSwap = new Button();
            lb_table_1 = new Label();
            txt_table_1 = new TextBox();
            txt_table_2 = new TextBox();
            lb_table_2 = new Label();
            groupBox_listTable.SuspendLayout();
            groupBox_infoTable.SuspendLayout();
            groupBox_optionPays.SuspendLayout();
            groupBox_tableSwap.SuspendLayout();
            SuspendLayout();
            // 
            // lb_frm_tables_manager_title
            // 
            lb_frm_tables_manager_title.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lb_frm_tables_manager_title.Location = new Point(432, 9);
            lb_frm_tables_manager_title.Name = "lb_frm_tables_manager_title";
            lb_frm_tables_manager_title.Size = new Size(318, 63);
            lb_frm_tables_manager_title.TabIndex = 20;
            lb_frm_tables_manager_title.Text = "Sơ đồ bàn ăn";
            lb_frm_tables_manager_title.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // groupBox_listTable
            // 
            groupBox_listTable.Controls.Add(flowLayoutPanel_listTable);
            groupBox_listTable.Font = new Font("Segoe UI", 10.2F, FontStyle.Italic);
            groupBox_listTable.Location = new Point(12, 68);
            groupBox_listTable.Name = "groupBox_listTable";
            groupBox_listTable.Size = new Size(662, 633);
            groupBox_listTable.TabIndex = 21;
            groupBox_listTable.TabStop = false;
            groupBox_listTable.Text = "Danh sách bàn ăn :";
            // 
            // flowLayoutPanel_listTable
            // 
            flowLayoutPanel_listTable.BackColor = SystemColors.Control;
            flowLayoutPanel_listTable.Dock = DockStyle.Fill;
            flowLayoutPanel_listTable.Font = new Font("Segoe UI", 10.2F, FontStyle.Italic);
            flowLayoutPanel_listTable.Location = new Point(3, 26);
            flowLayoutPanel_listTable.Name = "flowLayoutPanel_listTable";
            flowLayoutPanel_listTable.Size = new Size(656, 604);
            flowLayoutPanel_listTable.TabIndex = 0;
            // 
            // groupBox_infoTable
            // 
            groupBox_infoTable.Controls.Add(listView_orderDetail);
            groupBox_infoTable.Controls.Add(lb_tableStatus);
            groupBox_infoTable.Controls.Add(lb_tableNumber);
            groupBox_infoTable.Font = new Font("Segoe UI", 10.2F, FontStyle.Italic);
            groupBox_infoTable.Location = new Point(680, 199);
            groupBox_infoTable.Name = "groupBox_infoTable";
            groupBox_infoTable.Size = new Size(474, 323);
            groupBox_infoTable.TabIndex = 22;
            groupBox_infoTable.TabStop = false;
            groupBox_infoTable.Text = "Thông tin bàn ăn :";
            // 
            // listView_orderDetail
            // 
            listView_orderDetail.Columns.AddRange(new ColumnHeader[] { Name, Price, Quantity, SubTotal });
            listView_orderDetail.Items.AddRange(new ListViewItem[] { listViewItem1 });
            listView_orderDetail.Location = new Point(0, 86);
            listView_orderDetail.Name = "listView_orderDetail";
            listView_orderDetail.Size = new Size(498, 231);
            listView_orderDetail.TabIndex = 28;
            listView_orderDetail.UseCompatibleStateImageBehavior = false;
            listView_orderDetail.View = View.Details;
            // 
            // Name
            // 
            Name.Text = "Tên món";
            Name.Width = 120;
            // 
            // Price
            // 
            Price.Text = "Giá món";
            Price.Width = 100;
            // 
            // Quantity
            // 
            Quantity.Text = "Số lượng";
            Quantity.Width = 100;
            // 
            // SubTotal
            // 
            SubTotal.Text = "Thành tiền";
            SubTotal.Width = 120;
            // 
            // lb_tableStatus
            // 
            lb_tableStatus.AutoSize = true;
            lb_tableStatus.Location = new Point(11, 54);
            lb_tableStatus.Name = "lb_tableStatus";
            lb_tableStatus.Size = new Size(31, 23);
            lb_tableStatus.TabIndex = 27;
            lb_tableStatus.Text = "???";
            // 
            // lb_tableNumber
            // 
            lb_tableNumber.AutoSize = true;
            lb_tableNumber.Location = new Point(11, 23);
            lb_tableNumber.Name = "lb_tableNumber";
            lb_tableNumber.Size = new Size(31, 23);
            lb_tableNumber.TabIndex = 26;
            lb_tableNumber.Text = "???";
            // 
            // btn_pay
            // 
            btn_pay.BackColor = Color.Brown;
            btn_pay.Font = new Font("Segoe UI", 10.2F, FontStyle.Italic);
            btn_pay.ForeColor = Color.Black;
            btn_pay.Location = new Point(680, 647);
            btn_pay.Name = "btn_pay";
            btn_pay.Size = new Size(345, 51);
            btn_pay.TabIndex = 23;
            btn_pay.Text = "Thanh toán";
            btn_pay.UseVisualStyleBackColor = false;
            btn_pay.Click += btn_pay_Click;
            // 
            // btn_print
            // 
            btn_print.Font = new Font("Segoe UI", 10.2F, FontStyle.Italic);
            btn_print.Location = new Point(1031, 647);
            btn_print.Name = "btn_print";
            btn_print.Size = new Size(120, 51);
            btn_print.TabIndex = 24;
            btn_print.Text = "In hóa đơn";
            btn_print.UseVisualStyleBackColor = true;
            btn_print.Click += btn_print_Click;
            // 
            // groupBox_optionPays
            // 
            groupBox_optionPays.Controls.Add(radioButton_optionMomo);
            groupBox_optionPays.Controls.Add(radioButton_optionBank);
            groupBox_optionPays.Controls.Add(radioButton_optionCash);
            groupBox_optionPays.Font = new Font("Segoe UI", 10.2F, FontStyle.Italic);
            groupBox_optionPays.Location = new Point(680, 548);
            groupBox_optionPays.Name = "groupBox_optionPays";
            groupBox_optionPays.Size = new Size(475, 93);
            groupBox_optionPays.TabIndex = 26;
            groupBox_optionPays.TabStop = false;
            groupBox_optionPays.Text = "Phương thức thanh toán";
            // 
            // radioButton_optionMomo
            // 
            radioButton_optionMomo.AutoSize = true;
            radioButton_optionMomo.Font = new Font("Segoe UI", 10.2F, FontStyle.Italic);
            radioButton_optionMomo.Location = new Point(377, 42);
            radioButton_optionMomo.Name = "radioButton_optionMomo";
            radioButton_optionMomo.Size = new Size(78, 27);
            radioButton_optionMomo.TabIndex = 2;
            radioButton_optionMomo.TabStop = true;
            radioButton_optionMomo.Text = "Momo";
            radioButton_optionMomo.UseVisualStyleBackColor = true;
            radioButton_optionMomo.CheckedChanged += radioButton_optionMomo_CheckedChanged;
            // 
            // radioButton_optionBank
            // 
            radioButton_optionBank.AutoSize = true;
            radioButton_optionBank.Font = new Font("Segoe UI", 10.2F, FontStyle.Italic);
            radioButton_optionBank.Location = new Point(193, 42);
            radioButton_optionBank.Name = "radioButton_optionBank";
            radioButton_optionBank.Size = new Size(114, 27);
            radioButton_optionBank.TabIndex = 1;
            radioButton_optionBank.TabStop = true;
            radioButton_optionBank.Text = "Ngân hàng";
            radioButton_optionBank.UseVisualStyleBackColor = true;
            // 
            // radioButton_optionCash
            // 
            radioButton_optionCash.AutoSize = true;
            radioButton_optionCash.Font = new Font("Segoe UI", 10.2F, FontStyle.Italic);
            radioButton_optionCash.Location = new Point(24, 42);
            radioButton_optionCash.Name = "radioButton_optionCash";
            radioButton_optionCash.Size = new Size(97, 27);
            radioButton_optionCash.TabIndex = 0;
            radioButton_optionCash.TabStop = true;
            radioButton_optionCash.Text = "Tiền mặt";
            radioButton_optionCash.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(100, 23);
            label1.TabIndex = 1;
            // 
            // label2
            // 
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Size = new Size(100, 23);
            label2.TabIndex = 0;
            // 
            // lb_sum
            // 
            lb_sum.AutoSize = true;
            lb_sum.Location = new Point(691, 525);
            lb_sum.Name = "lb_sum";
            lb_sum.Size = new Size(30, 20);
            lb_sum.TabIndex = 28;
            lb_sum.Text = "???";
            lb_sum.Click += lb_sum_Click;
            // 
            // groupBox_tableSwap
            // 
            groupBox_tableSwap.Controls.Add(btn_tableSwap);
            groupBox_tableSwap.Controls.Add(lb_table_1);
            groupBox_tableSwap.Controls.Add(txt_table_1);
            groupBox_tableSwap.Controls.Add(txt_table_2);
            groupBox_tableSwap.Controls.Add(lb_table_2);
            groupBox_tableSwap.Font = new Font("Segoe UI", 10.2F, FontStyle.Italic);
            groupBox_tableSwap.Location = new Point(680, 68);
            groupBox_tableSwap.Name = "groupBox_tableSwap";
            groupBox_tableSwap.Size = new Size(474, 125);
            groupBox_tableSwap.TabIndex = 34;
            groupBox_tableSwap.TabStop = false;
            groupBox_tableSwap.Text = "Chuyển bàn : ";
            // 
            // btn_tableSwap
            // 
            btn_tableSwap.Font = new Font("Segoe UI", 10.2F, FontStyle.Italic);
            btn_tableSwap.Location = new Point(325, 42);
            btn_tableSwap.Name = "btn_tableSwap";
            btn_tableSwap.Size = new Size(126, 62);
            btn_tableSwap.TabIndex = 35;
            btn_tableSwap.Text = "Chuyển";
            btn_tableSwap.UseVisualStyleBackColor = true;
            btn_tableSwap.Click += btn_tableSwap_Click;
            // 
            // lb_table_1
            // 
            lb_table_1.AutoSize = true;
            lb_table_1.Location = new Point(20, 42);
            lb_table_1.Name = "lb_table_1";
            lb_table_1.Size = new Size(81, 23);
            lb_table_1.TabIndex = 38;
            lb_table_1.Text = "Bàn ăn 1:";
            // 
            // txt_table_1
            // 
            txt_table_1.Location = new Point(95, 42);
            txt_table_1.Multiline = true;
            txt_table_1.Name = "txt_table_1";
            txt_table_1.Size = new Size(211, 20);
            txt_table_1.TabIndex = 37;
            // 
            // txt_table_2
            // 
            txt_table_2.Location = new Point(95, 84);
            txt_table_2.Multiline = true;
            txt_table_2.Name = "txt_table_2";
            txt_table_2.Size = new Size(211, 20);
            txt_table_2.TabIndex = 35;
            // 
            // lb_table_2
            // 
            lb_table_2.AutoSize = true;
            lb_table_2.Location = new Point(20, 84);
            lb_table_2.Name = "lb_table_2";
            lb_table_2.Size = new Size(81, 23);
            lb_table_2.TabIndex = 36;
            lb_table_2.Text = "Bàn ăn 2:";
            // 
            // frm_tables_manager
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MistyRose;
            ClientSize = new Size(1163, 713);
            Controls.Add(groupBox_tableSwap);
            Controls.Add(lb_sum);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(groupBox_optionPays);
            Controls.Add(btn_print);
            Controls.Add(btn_pay);
            Controls.Add(groupBox_infoTable);
            Controls.Add(groupBox_listTable);
            Controls.Add(lb_frm_tables_manager_title);
            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sơ đồ bàn ăn";
            Load += frm_tables_manager_Load;
            groupBox_listTable.ResumeLayout(false);
            groupBox_infoTable.ResumeLayout(false);
            groupBox_infoTable.PerformLayout();
            groupBox_optionPays.ResumeLayout(false);
            groupBox_optionPays.PerformLayout();
            groupBox_tableSwap.ResumeLayout(false);
            groupBox_tableSwap.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lb_frm_tables_manager_title;
        private GroupBox groupBox_listTable;
        private FlowLayoutPanel flowLayoutPanel_listTable;
        private GroupBox groupBox_infoTable;
        private Label lb_tableStatus;
        private Label lb_tableNumber;
        private Button btn_pay;
        private Button btn_print;
        private Label lb_total;
        private GroupBox groupBox_optionPays;
        private RadioButton radioButton_optionMomo;
        private RadioButton radioButton_optionBank;
        private RadioButton radioButton_optionCash;
        private Label label1;
        private Label label2;
        private Label lb_sum;
        private ListView listView_orderDetail;
        private ColumnHeader Name;
        private ColumnHeader Price;
        private ColumnHeader Quantity;
        private ColumnHeader SubTotal;
        private GroupBox groupBox_tableSwap;
        private Label lb_table_1;
        private TextBox txt_table_1;
        private TextBox txt_table_2;
        private Label lb_table_2;
        private Button btn_tableSwap;
    }
}