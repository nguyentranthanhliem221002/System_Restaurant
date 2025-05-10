using BusinessLayer.Service;
using TransferObject;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Drawing;
using QRCoder;
using OfficeOpenXml;
using ClosedXML.Excel;  // Thêm thư viện này nếu chưa có

namespace PresentationLayer
{
    public partial class frm_tables_manager : Form
    {
        private readonly TableService _tableService;
        private readonly OrderService _orderService;
        private readonly MomoService _momoService;
        private readonly OrderDetailService _orderDetailService;
        private readonly IServiceProvider _serviceProvider;
        private readonly ContextMenuStrip _contextMenuStrip;

        public frm_tables_manager(TableService tableService, OrderService orderService, IServiceProvider serviceProvider, OrderDetailService orderDetailService, MomoService momoService)
        {
            InitializeComponent();
            _tableService = tableService ?? throw new ArgumentNullException(nameof(tableService));
            _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
            _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
            _momoService = momoService ?? throw new ArgumentNullException(nameof(momoService));
            _orderDetailService = orderDetailService ?? throw new ArgumentNullException(nameof(orderDetailService));
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

                foreach (var table in tables)
                {
                    if (table.Status == TableStatus.Ordered &&
                        (!TemporaryDataStorage.TemporaryOrderDetails.ContainsKey(table.Id) ||
                         !TemporaryDataStorage.TemporaryOrderDetails[table.Id].Any()))
                    {
                        _tableService.UpdateTableStatus(table.Id, TableStatus.Available);
                        table.Status = TableStatus.Available; 
                    }
                }

                flowLayoutPanel_listTable.Controls.Clear();

                foreach (var table in tables)
                {
                    var btnTable = new Button
                    {
                        Text = $"Bàn {table.Id}",
                        Width = 120,
                        Height = 120,
                        Tag = table,
                        BackColor = GetTableColor(table.Status), // dùng trạng thái đã cập nhật
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
            //if (selectedTable == null)
            //{
            //    MessageBox.Show("Vui lòng chọn một bàn để đặt món.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            var frmMain = Application.OpenForms.OfType<frm_main>().FirstOrDefault();
            if (frmMain != null)
            {
                var frmOrderDetail = _serviceProvider.GetRequiredService<frm_orderDetails_manager>();
                frmOrderDetail.SetTableInfo(selectedTable);
                frmOrderDetail.LoadTemporaryOrderDetails();
                frmMain.OpenChildForm(frmOrderDetail);
            }
        }

        private void DeleteItem_Click(object sender, EventArgs e) => MessageBox.Show("Chức năng chưa được cập nhật!");

        private async void btn_pay_Click(object sender, EventArgs e)
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

            var order = GetOrderForTable(selectedTable);
            if (order == null)
            {
                MessageBox.Show("Không tìm thấy đơn hàng cho bàn này!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (radioButton_optionMomo.Checked)
            {
                try
                {
                    string orderId = $"ORDER_{DateTime.Now.Ticks}";
                    //long amount = 500000; // Hoặc tính tổng giá trị đơn hàng thực tế nếu có

                    string payUrl = await _momoService.CreateMomoPaymentAsync();

                    if (string.IsNullOrWhiteSpace(payUrl))
                    {
                        MessageBox.Show("Không thể tạo thanh toán MoMo. Vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    ShowMomoQRCode(selectedTable, payUrl);
                }
                catch (KeyNotFoundException keyEx)
                {
                    MessageBox.Show($"Lỗi dữ liệu trả về từ MoMo: {keyEx.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi tạo thanh toán MoMo: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                return;
            }

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


        private void ShowMomoQRCode(Table table, string payUrl)
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

            // Tạo mã QR từ payUrl
            using (var qrGenerator = new QRCodeGenerator())
            {
                var qrCodeData = qrGenerator.CreateQrCode(payUrl, QRCodeGenerator.ECCLevel.Q);
                var qrCode = new QRCode(qrCodeData);
                pictureBox.Image = qrCode.GetGraphic(10);
            }

            qrForm.Controls.Add(pictureBox);
            qrForm.ShowDialog();
        }



        //private void ShowMomoQRCode(Table table)
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

        //    // Đảm bảo tên tài nguyên đúng với namespace và đường dẫn của file hình ảnh
        //    var assembly = Assembly.GetExecutingAssembly();
        //    string resourceName = "PresentationLayer.Resources.QR_MOMO.jpg"; // Đảm bảo đúng đường dẫn tài nguyên trong assembly

        //    using (var stream = assembly.GetManifestResourceStream(resourceName))
        //    {
        //        if (stream != null)
        //        {
        //            try
        //            {
        //                pictureBox.Image = Image.FromStream(stream);
        //            }
        //            catch (Exception ex)
        //            {
        //                MessageBox.Show($"Lỗi khi tải hình ảnh: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            }
        //        }
        //        else
        //        {
        //            MessageBox.Show("Không tìm thấy tài nguyên hình ảnh QR_MOMO. Kiểm tra lại tên tài nguyên và cấu trúc thư mục.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }

        //    // Thêm PictureBox vào form và hiển thị
        //    qrForm.Controls.Add(pictureBox);
        //    qrForm.ShowDialog();
        //}

        private Order GetOrderForTable(Table selectedTable)
        {
            // Giả sử bạn có một phương thức để lấy thông tin đơn hàng theo bàn
            // Ví dụ trả về một đơn hàng mẫu hoặc lấy từ cơ sở dữ liệu
            return new Order { Total = 500000 }; // Đây chỉ là một ví dụ
        }

        private void CompletePayment(Table selectedTable)
        {
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

            SaveOrderToExcel(selectedTable.Id); 
        }
        private void SaveOrderToExcel(int tableId)
        {
            var orderDetails = new List<OrderDetail>();

            foreach (ListViewItem item in listView_orderDetail.Items)
            {
                var orderDetail = new OrderDetail
                {
                    Food = new Food
                    {
                        Name = item.SubItems[0].Text,  
                        Price = Convert.ToDecimal(item.SubItems[1].Text) 
                    },
                    Quantity = Convert.ToInt32(item.SubItems[2].Text)  
                };

                orderDetails.Add(orderDetail);
            }

            if (orderDetails == null || !orderDetails.Any())
            {
                MessageBox.Show("Không tìm thấy chi tiết đơn hàng cho bàn này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tạo workbook và worksheet
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Hóa Đơn");

                // Thiết lập các tiêu đề cột
                worksheet.Cell(1, 1).Value = "Hóa đơn";
                worksheet.Cell(1, 2).Value = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");  // Ngày tháng năm và giờ phút giây
                worksheet.Cell(1, 3).Value = "Người thực hiện";  // Thêm cột "Ai thực hiện"

                // Thiết lập cột cho chi tiết đơn hàng
                worksheet.Cell(2, 1).Value = "Tên món";
                worksheet.Cell(2, 2).Value = "Giá";
                worksheet.Cell(2, 3).Value = "Số lượng";
                worksheet.Cell(2, 4).Value = "Tổng tiền";

                int row = 3;  // Dữ liệu bắt đầu từ dòng 3
                decimal totalOrderAmount = 0;

                // Lặp qua các chi tiết đơn hàng (OrderDetails)
                foreach (var detail in orderDetails) // orderDetails là danh sách OrderDetail đã lấy từ ListView
                {
                    worksheet.Cell(row, 1).Value = detail.Food.Name;  // Tên món ăn
                    worksheet.Cell(row, 2).Value = detail.Food.Price.ToString();  // Giá của món
                    worksheet.Cell(row, 3).Value = detail.Quantity;  // Số lượng
                    decimal itemTotal = detail.Quantity * detail.Food.Price;  // Tổng tiền cho món
                    worksheet.Cell(row, 4).Value = itemTotal.ToString();

                    totalOrderAmount += itemTotal;
                    row++;
                }

                // Điền tổng tiền vào cột Tổng
                worksheet.Cell(row, 3).Value = "Tổng tiền";
                worksheet.Cell(row, 4).Value = totalOrderAmount.ToString();

                // Căn giữa tất cả các tiêu đề và dữ liệu
                worksheet.Range(1, 1, 1, 4).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;  // Căn giữa hàng tiêu đề
                worksheet.Range(2, 1, row, 4).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;  // Căn giữa các dòng dữ liệu

                // Điều chỉnh chiều rộng cột tự động để vừa với nội dung
                worksheet.Columns().AdjustToContents();

                // Căn giữa toàn bộ bảng dữ liệu trong khung Excel (cả theo chiều ngang và dọc)
                worksheet.SheetView.Freeze(2, 1);  // Giữ nguyên các tiêu đề
                worksheet.Cells().Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                worksheet.Cells().Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

                // Đặt chiều cao cho dòng tiêu đề và các dòng dữ liệu
                worksheet.Rows().Height = 20;  // Tăng chiều cao của các dòng để dễ đọc

                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);  // Lấy đường dẫn tới Desktop của người dùng
                string directoryPath = Path.Combine(desktopPath, "Hoa don");  // Kết hợp với tên thư mục "Hoa don"

                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);  // Tạo thư mục nếu chưa tồn tại
                }

                // Đặt tên file và lưu file Excel vào thư mục "Hoa don"
                string filePath = Path.Combine(directoryPath, $"HoaDon_{tableId}_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx");

                // Lưu file Excel vào ổ đĩa
                workbook.SaveAs(filePath);

                // Thông báo người dùng
                MessageBox.Show($"Hóa đơn đã được lưu vào file Excel tại: {filePath}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_tableSwap_Click(object sender, EventArgs e)
        {
            try
            {
                int tableId1 = Int32.Parse(txt_table_1.Text);
                int tableId2 = Int32.Parse(txt_table_2.Text);

               _tableService.SwapTable(tableId1, tableId2); // Gọi từ repository

                MessageBox.Show($"Đã hoán đổi món ăn giữa bàn {tableId1} và {tableId2}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }


        private void lb_sum_Click(object sender, EventArgs e)
        {

        }
    }
}
