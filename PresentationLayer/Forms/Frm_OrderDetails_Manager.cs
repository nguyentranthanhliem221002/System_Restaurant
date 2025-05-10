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

        //private Table GetFocusedTable() => tabControl_listCategory.Controls
        //.OfType<Button>()
        //.FirstOrDefault(btn => btn.Focused)?.Tag as Table;


        //private Button _selectedFoodButton;


        //private void OrderItem_Click(object sender, EventArgs e)
        //{
        //    if (sender is ToolStripMenuItem item && item.Tag is int level && _selectedFoodButton != null)
        //    {
        //        var orderDetail = _selectedFoodButton.Tag as OrderDetail; 

        //        if (orderDetail == null)
        //            return;

              
        //        dgv_orderDetail.Rows.Add(orderDetail.Food.Name, orderDetail.Food.Level, orderDetail.Food.Price, orderDetail.SubTotal, orderDetail.FoodId); 

        //        // Reset sau khi dùng xong
        //        _selectedFoodButton = null;
        //    }
        //}

        private FlowLayoutPanel CreateFoodFlowPanel(Category category)
        {
            var flowPanel = new FlowLayoutPanel {
                Dock = DockStyle.Fill,
                AutoScroll = true, 
         
            };

            foreach (var food in _foodService.GetFoodByCategoryId(category.Id))
            {
                var btnFood = new Button
                {
                    Text = food.Name,
                    Width = 295,
                    Height = 305,
                    Tag = food,
                    TextAlign = ContentAlignment.BottomCenter,
                    BackgroundImageLayout = ImageLayout.Stretch,
                };
           

                var imagePath = Path.Combine(Application.StartupPath, "Resources", food.Image);
                if (File.Exists(imagePath)) // Kiểm tra sự tồn tại của tệp ảnh
                {
                    btnFood.BackgroundImage = Image.FromFile(imagePath);
                }
                else
                {
                 
                }

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
            dgv_orderDetail.Rows.Add(food.Name, food.Level , food.Price.ToString(), 1, food.Price.ToString(), food.Id);
        }

        public void SetTableInfo(Table selectedTable)
        {
            _selectedTable = selectedTable;
            if (selectedTable == null)
            {
                MessageBox.Show("Vui lòng chọn bàn trước khi tiếp tục.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            lb_tableNumber.Text = $"Bàn: {_selectedTable.Id}";

            try
            {
                LoadOrderDetail(_orderService.GetOrdersByTableId(_selectedTable.Id));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lấy đơn hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadOrderDetail(List<OrderDetail> orders)
        { 
            dgv_orderDetail.Rows.Clear();

            foreach (var order in orders)
            {
                dgv_orderDetail.Rows.Add(order.Food?.Name ?? "Món ăn không có thông tin",
                                          order.Food.Level,
                                          order.Food?.Price.ToString() ?? "N/A",
                                          order.Quantity,
                                          (order.Quantity * (order.Food?.Price ?? 0)).ToString(),
                                          order.FoodId
                                          );
            }
        }
        public void SaveTemporaryOrderDetails()
        {
            TemporaryDataStorage.TemporaryOrderDetails[_selectedTable.Id] = dgv_orderDetail.Rows
                .Cast<DataGridViewRow>()
                .Where(row => row.Cells[0].Value != null) // đảm bảo ít nhất có tên món
                .Select(row => new TemporaryOrderDetail
                {
                    FoodName = row.Cells[0].Value?.ToString(),
                    Level = row.Cells[1].Value != null
                        ? Enum.TryParse<SpicyLevel>(row.Cells[1].Value.ToString(), out var level) ? level : (SpicyLevel?)null
                        : null,
                    Price = row.Cells[2].Value != null ? decimal.Parse(row.Cells[2].Value.ToString()) : 0,
                    Quantity = row.Cells[3].Value != null ? int.Parse(row.Cells[3].Value.ToString()) : 0,
                    SubTotal = row.Cells[4].Value != null ? decimal.Parse(row.Cells[4].Value.ToString()) : 0,
                    FoodId = row.Cells[5].Value != null ? int.Parse(row.Cells[5].Value.ToString()) : 0,
                    TableId = _selectedTable.Id
                })
                .ToList();
        }

        public void LoadTemporaryOrderDetails()
        {
            dgv_orderDetail.Rows.Clear();

            var filteredOrderDetails = TemporaryDataStorage.TemporaryOrderDetails
                .Where(kv => kv.Key == _selectedTable.Id)
                .SelectMany(kv => kv.Value)
                .ToList();

            foreach (var item in filteredOrderDetails)
            {
                dgv_orderDetail.Rows.Add(item.FoodName, item.Level, item.Price.ToString(), item.Quantity.ToString(), item.SubTotal.ToString(), item.FoodId, item.TableId);
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
                LoadTemporaryOrderDetails();
            }

            _tableService.UpdateTableStatus(_selectedTable.Id, TableStatus.Ordered);
            _frmTablesManager.UpdateTableColor(_selectedTable.Id, Color.Red);

            MessageBox.Show("Lưu đơn hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

   
    }
}
