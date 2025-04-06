using BusinessLayer.Service;
using DataLayer.Service;
using Microsoft.Extensions.DependencyInjection;
using PresentationLayer.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TransferObject;

namespace PresentationLayer
{
    public partial class frm_orderDetails_manager : Form
    {
        private Table _selectedTable;
        private readonly FoodService _foodService;
        private readonly CategoryService _categoryService;
        private readonly TableService _tableService;
        private readonly OrderDetailService _orderDetailService;
        private readonly OrderService _orderService;
        private readonly frm_tables_manager _frmTablesManager;

        public frm_orderDetails_manager(
            FoodService foodService,
            CategoryService categoryService,
            OrderDetailService orderDetailService,
            OrderService orderService,
            TableService tableService,
            frm_tables_manager frmTablesManager)
        {
            InitializeComponent();

            _foodService = foodService ?? throw new ArgumentNullException(nameof(foodService));
            _categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
            _orderDetailService = orderDetailService ?? throw new ArgumentNullException(nameof(orderDetailService));
            _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
            _tableService = tableService ?? throw new ArgumentNullException(nameof(tableService));
            _frmTablesManager = frmTablesManager ?? throw new ArgumentNullException(nameof(frmTablesManager));
        }

        private void frm_orderDetails_manager_Load(object sender, EventArgs e) => LoadCategoriesAndFoods();

        private void LoadCategoriesAndFoods()
        {
            tabControl_listCategory.TabPages.Clear();

            foreach (var category in _categoryService.GetAllCategories())
            {
                var tabPage = new TabPage(category.Name)
                {
                    Controls = { CreateFoodFlowPanel(category) }
                };
                tabControl_listCategory.TabPages.Add(tabPage);
            }
        }

        private FlowLayoutPanel CreateFoodFlowPanel(Category category)
        {
            var flowPanel = new FlowLayoutPanel { Dock = DockStyle.Fill };

            foreach (var food in _foodService.GetFoodByCategoryId(category.Id))
            {
                var btnFood = new Button
                {
                    Text = food.Name,
                    Width = 100,
                    Height = 100,
                    Tag = food,
                    TextAlign = ContentAlignment.MiddleCenter
                };
                btnFood.Click += BtnFood_Click;
                flowPanel.Controls.Add(btnFood);
            }

            return flowPanel;
        }

        private void BtnFood_Click(object sender, EventArgs e)
        {
            var food = (Food)((Button)sender).Tag;
            if (food == null) return;

            var existingRow = dgv_orderDetail.Rows.Cast<DataGridViewRow>()
                .FirstOrDefault(row => row.Cells["Name"].Value?.ToString() == food.Name);

            if (existingRow != null)
            {
                UpdateExistingOrder(existingRow, food);
            }
            else
            {
                AddNewOrder(food);
            }
        }

        private void UpdateExistingOrder(DataGridViewRow row, Food food)
        {
            int currentQuantity = int.Parse(row.Cells["Quantity"].Value?.ToString());
            row.Cells["Quantity"].Value = currentQuantity + 1;
            row.Cells["SubTotal"].Value = (currentQuantity + 1) * food.Price;
        }

        private void AddNewOrder(Food food)
        {
            dgv_orderDetail.Rows.Add(food.Name, food.Price.ToString(), 1, food.Price.ToString(), food.Id);
        }

        public void SetTableInfo(Table selectedTable)
        {
            _selectedTable = selectedTable;
            lb_tableNumber.Text = $"Bàn: {_selectedTable.Id}";

            try
            {
                DisplayOrders(_orderService.GetOrdersByTableId(_selectedTable.Id));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lấy đơn hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayOrders(List<OrderDetail> orders)
        {
            dgv_orderDetail.Rows.Clear();

            //if (_tableService.GetLatestTableStatus(_selectedTable.Id) != TableStatus.Ordered)
            //{
            //    MessageBox.Show("Chỉ hiển thị chi tiết món ăn khi bàn đang ở trạng thái đã đặt món.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}

            foreach (var order in orders)
            {
                dgv_orderDetail.Rows.Add(order.Food?.Name ?? "Món ăn không có thông tin",
                                          order.Food?.Price.ToString() ?? "N/A",
                                          order.Quantity,
                                          (order.Quantity * (order.Food?.Price ?? 0)).ToString(),
                                          order.FoodId);
            }
        }

        public void SaveTemporaryOrderDetails()
        {
            TemporaryDataStorage.TemporaryOrderDetails[_selectedTable.Id] = dgv_orderDetail.Rows.Cast<DataGridViewRow>()
                .Where(row => row.Cells[0].Value != null)
                .Select(row => new TemporaryOrderDetail
                {
                    FoodName = row.Cells[0].Value.ToString(),
                    Price = decimal.Parse(row.Cells[1].Value.ToString()),
                    Quantity = int.Parse(row.Cells[2].Value.ToString()),
                    SubTotal = decimal.Parse(row.Cells[3].Value.ToString()),
                    FoodId = int.Parse(row.Cells[4].Value.ToString()),
                    TableId = _selectedTable.Id
                })
                .ToList();
        }

        public void DisplayTemporaryOrderDetails()
        {
            dgv_orderDetail.Rows.Clear();

            var filteredOrderDetails = TemporaryDataStorage.TemporaryOrderDetails
                .Where(kv => kv.Key == _selectedTable.Id)
                .SelectMany(kv => kv.Value)
                .ToList();

            foreach (var item in filteredOrderDetails)
            {
                dgv_orderDetail.Rows.Add(item.FoodName, item.Price.ToString(), item.Quantity.ToString(), item.SubTotal.ToString(), item.FoodId);
            }
        }

        private void button_saveOrderDetail_Click(object sender, EventArgs e)
        {
            if (_selectedTable == null || dgv_orderDetail.Rows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn bàn và món ăn trước khi lưu!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (CurrentUser.RoleId == 0)
            {
                MessageBox.Show("Không tìm thấy RoleId. Vui lòng đăng nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SaveTemporaryOrderDetails();

            if (TemporaryDataStorage.TemporaryOrderDetails.Any())
            {
                DisplayTemporaryOrderDetails();
            }

            _tableService.UpdateTableStatus(_selectedTable.Id, TableStatus.Ordered);
            _frmTablesManager.UpdateTableColor(_selectedTable.Id, Color.Red);

            MessageBox.Show("Lưu đơn hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
