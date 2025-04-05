using BusinessLayer.Service;
using TransferObject;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Drawing;
using QRCoder;
using OfficeOpenXml;  // Thêm thư viện này nếu chưa có

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

            // Giả sử bạn có đối tượng Order liên quan đến bàn này
            var order = GetOrderForTable(selectedTable); // Bạn cần có một phương thức để lấy đối tượng Order cho bàn này

            // Nếu chọn Momo thì hiển thị mã QR trước
            if (radioButton_optionMomo.Checked)
            {
                //ShowMomoQRCode(selectedTable, order);
                ShowMomoQRCode(selectedTable);

                return; // Đợi quét QR xong rồi mới thanh toán
            }

            // Xử lý thanh toán bình thường
            CompletePayment(selectedTable);
        }

        //private void ShowMomoQRCode(Table table, Order order)
        //{
        //    var qrForm = new Form
        //    {
        //        Text = $"Thanh toán MoMo - Bàn {table.Id}",
        //        Size = new Size(300, 350),
        //        StartPosition = FormStartPosition.CenterParent
        //    };

        //    var pictureBox = new PictureBox
        //    {
        //        Dock = DockStyle.Fill,
        //        SizeMode = PictureBoxSizeMode.Zoom
        //    };

        //    // Lấy tổng tiền từ đơn hàng
        //    decimal totalAmount = order.Total;

        //    // Tạo URL thanh toán với tổng tiền từ đơn hàng
        //    string paymentUrl = $"https://momo.vn/payment?tableId={table.Id}&amount={totalAmount}"; // Dùng order.Total để lấy số tiền

        //    // Tạo mã QR từ URL thanh toán
        //    using (var qrGenerator = new QRCodeGenerator())
        //    {
        //        var qrCodeData = qrGenerator.CreateQrCode(paymentUrl, QRCodeGenerator.ECCLevel.Q);
        //        var qrCode = new QRCode(qrCodeData);
        //        pictureBox.Image = qrCode.GetGraphic(20); // Thay đổi độ lớn của mã QR nếu cần
        //    }

        //    // Thêm PictureBox vào form và hiển thị
        //    qrForm.Controls.Add(pictureBox);
        //    qrForm.ShowDialog();
        //}
        private void ShowMomoQRCode(Table table)
        {
            var qrForm = new Form
            {
                Text = $"Thanh toán MoMo - Bàn {table.Id}",
                Size = new Size(300, 350),
                StartPosition = FormStartPosition.CenterParent
            };

            var pictureBox = new PictureBox
            {
                Dock = DockStyle.Fill,
                SizeMode = PictureBoxSizeMode.Zoom
            };

            // Đảm bảo tên tài nguyên đúng với namespace và đường dẫn của file hình ảnh
            var assembly = Assembly.GetExecutingAssembly();
            string resourceName = "PresentationLayer.Resources.QR_MOMO.jpg"; // Đảm bảo đúng đường dẫn tài nguyên trong assembly

            using (var stream = assembly.GetManifestResourceStream(resourceName))
            {
                if (stream != null)
                {
                    try
                    {
                        pictureBox.Image = Image.FromStream(stream);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi tải hình ảnh: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy tài nguyên hình ảnh QR_MOMO. Kiểm tra lại tên tài nguyên và cấu trúc thư mục.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // Thêm PictureBox vào form và hiển thị
            qrForm.Controls.Add(pictureBox);
            qrForm.ShowDialog();
        }

        private Order GetOrderForTable(Table selectedTable)
        {
            // Giả sử bạn có một phương thức để lấy thông tin đơn hàng theo bàn
            // Ví dụ trả về một đơn hàng mẫu hoặc lấy từ cơ sở dữ liệu
            return new Order { Total = 500000 }; // Đây chỉ là một ví dụ
        }

        private void CompletePayment(Table selectedTable)
        {
            // Giả lập hoàn tất thanh toán
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

        private void radioButton_optionMomo_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btn_print_Click(object sender, EventArgs e)
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

            // Giả sử bạn có đối tượng Order liên quan đến bàn này
            var order = GetOrderForTable(selectedTable); // Bạn cần có một phương thức để lấy đối tượng Order cho bàn này

            // Tạo và lưu hóa đơn vào file Excel
            SaveOrderToExcel(order);
        }
        private void SaveOrderToExcel(Order order)
        {
            // Tạo một đối tượng ExcelPackage
            using (var package = new ExcelPackage())
            {
                // Thêm một worksheet mới vào file Excel
                var worksheet = package.Workbook.Worksheets.Add("Hóa Đơn");

                // Thiết lập các tiêu đề cột
                worksheet.Cells[1, 1].Value = "Tên món";
                worksheet.Cells[1, 2].Value = "Giá";
                worksheet.Cells[1, 3].Value = "Số lượng";
                worksheet.Cells[1, 4].Value = "Tổng tiền";

                // Lặp qua các chi tiết đơn hàng (OrderDetails) và điền thông tin vào Excel
                int row = 2;
                decimal totalOrderAmount = 0;
                foreach (var detail in order.OrderDetails)
                {
                    worksheet.Cells[row, 1].Value = detail.Food.Name; // Tên món ăn
                    worksheet.Cells[row, 2].Value = detail.Food.Price; // Giá của món
                    worksheet.Cells[row, 3].Value = detail.Quantity; // Số lượng
                    decimal itemTotal = detail.Quantity * detail.SubTotal; // Tổng tiền cho món
                    worksheet.Cells[row, 4].Value = itemTotal;

                    totalOrderAmount += itemTotal;
                    row++;
                }

                // Điền tổng tiền vào cột Tổng
                worksheet.Cells[row, 3].Value = "Tổng tiền";
                worksheet.Cells[row, 4].Value = totalOrderAmount;

                // Đặt đường dẫn lưu file Excel vào thư mục OneDrive (hoặc thư mục mong muốn)
                string directoryPath = @"C:\Users\nguye\OneDrive\Máy tính này\Invoices"; // Thư mục lưu trữ hóa đơn
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath); // Tạo thư mục nếu chưa tồn tại
                }

                string filePath = Path.Combine(directoryPath, $"HoaDon_{order.Id}_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx"); // Đặt tên file với id đơn hàng và thời gian hiện tại

                // Lưu file Excel vào ổ đĩa
                FileInfo fi = new FileInfo(filePath);
                package.SaveAs(fi);

                // Thông báo người dùng
                MessageBox.Show($"Hóa đơn đã được lưu vào file Excel tại: {filePath}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
