using BusinessLayer.Service;
using TransferObject;
using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace PresentationLayer
{
    public partial class frm_tables_manager : Form
    {
        private readonly TableService _tableService;
        private readonly OrderService _orderService;
        private readonly IServiceProvider _serviceProvider;
        private readonly ContextMenuStrip _contextMenuStrip;

        public frm_tables_manager(TableService tableService, OrderService orderService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _tableService = tableService ?? throw new ArgumentNullException(nameof(tableService));
            _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));

            _contextMenuStrip = new ContextMenuStrip();
            _contextMenuStrip.Items.AddRange(new ToolStripItem[]
            {
                new ToolStripMenuItem("Order", null, OrderItem_Click),
                new ToolStripMenuItem("Xóa thông tin bàn", null, DeleteItem_Click)
            });
        }

        private void frm_tables_manager_Load(object sender, EventArgs e) => LoadTables();

        public void LoadTables()
        {
            try
            {
                var tables = _tableService.GetAllTables();
                flowLayoutPanel_listTable.Controls.Clear();

                foreach (var table in tables)
                {
                    var btnTable = new Button
                    {
                        Text = $"Bàn {table.Id}",
                        Width = 100,
                        Height = 100,
                        Tag = table,
                        BackColor = GetTableColor(_tableService.GetLatestTableStatus(table.Id)),
                        ContextMenuStrip = _contextMenuStrip
                    };
                    btnTable.Click += (s, e) => DisplayTableDetails(table.Id);
                    flowLayoutPanel_listTable.Controls.Add(btnTable);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách bàn: {ex.Message}");
            }
        }

        private void DisplayTableDetails(int tableId)
        {
            var selectedTable = flowLayoutPanel_listTable.Controls
                .OfType<Button>()
                .FirstOrDefault(btn => (btn.Tag as Table)?.Id == tableId)?.Tag as Table;

            if (selectedTable == null) return;

            lb_tableNumber.Text = $"Bàn: {selectedTable.Id}";
            lb_tableStatus.Text = GetTableStatusText(selectedTable.Status);

            var orderDetailsForTable = TemporaryDataStorage.TemporaryOrderDetails
                .Where(kv => kv.Key == tableId)
                .SelectMany(kv => kv.Value)
                .ToList();

            if (!orderDetailsForTable.Any())
            {
                MessageBox.Show("Bàn này chưa có món ăn được đặt.");
                return;
            }

            decimal total = 0;
            listView_orderDetail.Items.Clear();
            foreach (var item in orderDetailsForTable)
            {
                var listItem = new ListViewItem(item.FoodName)
                {
                    SubItems = { item.Price.ToString(), item.Quantity.ToString(), item.SubTotal.ToString(), item.FoodId.ToString() }
                };
                total += item.SubTotal;
                listView_orderDetail.Items.Add(listItem);
            }
            lb_sum.Text = $"Tổng tiền: {total}";
        }

        private void OrderItem_Click(object sender, EventArgs e)
        {
            var selectedTable = GetFocusedTable();
            if (selectedTable == null)
            {
                MessageBox.Show("Vui lòng chọn một bàn để đặt món.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var frmMain = Application.OpenForms.OfType<frm_main>().FirstOrDefault();
            if (frmMain != null)
            {
                var frmOrderDetail = _serviceProvider.GetRequiredService<frm_orderDetails_manager>();
                frmOrderDetail.SetTableInfo(selectedTable);
                frmOrderDetail.DisplayTemporaryOrderDetails();
                frmMain.OpenChildForm(frmOrderDetail);
            }
        }

        private void DeleteItem_Click(object sender, EventArgs e) => MessageBox.Show("Chức năng chưa được cập nhật!");

        private void btn_pay_Click(object sender, EventArgs e)
        {
            var selectedTable = flowLayoutPanel_listTable.Controls
                .OfType<Button>()
                .FirstOrDefault(btn => btn.BackColor == GetTableColor(TableStatus.Ordered))?.Tag as Table;

            if (selectedTable == null)
            {
                MessageBox.Show("Vui lòng chọn một bàn đã đặt món để thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!TemporaryDataStorage.TemporaryOrderDetails.Any())
            {
                MessageBox.Show("Không có món nào được đặt để thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _tableService.CompletePayment(selectedTable.Id);
            selectedTable.Status = TableStatus.Available;
            UpdateTableColor(selectedTable.Id, Color.White);
            listView_orderDetail.Items.Clear();
            lb_sum.Text = "Tổng tiền: 0";
            TemporaryDataStorage.TemporaryOrderDetails.Remove(selectedTable.Id);

            MessageBox.Show($"Thanh toán thành công cho Bàn {selectedTable.Id}!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private Table GetFocusedTable() => flowLayoutPanel_listTable.Controls
            .OfType<Button>()
            .FirstOrDefault(btn => btn.Focused)?.Tag as Table;

        private Color GetTableColor(TableStatus status) => status switch
        {
            TableStatus.Available => Color.White,
            TableStatus.Ordered => Color.Green,
            TableStatus.Paid => Color.Orange,
            _ => Color.Gray
        };

        private string GetTableStatusText(TableStatus status) => status switch
        {
            TableStatus.Available => "Trạng thái: Trống",
            TableStatus.Ordered => "Trạng thái: Đang có khách",
            TableStatus.Paid => "Trạng thái: Đã thanh toán",
            _ => "Trạng thái: Không xác định"
        };

        public void UpdateTableColor(int tableId, Color color)
        {
            var button = flowLayoutPanel_listTable.Controls
                .OfType<Button>()
                .FirstOrDefault(btn => (btn.Tag as Table)?.Id == tableId);
            if (button != null)
                button.BackColor = color;
        }
    }
}
