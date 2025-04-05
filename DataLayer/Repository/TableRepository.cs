using DataLayer.IRepository;
using TransferObject;

namespace DataLayer.Repository
{
    public class TableRepository : ITableRepository
    {
        private readonly ApplicationDbContext _context; // Đảm bảo đã khởi tạo DbContext để kết nối đến cơ sở dữ liệu

        public TableRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Lấy tất cả bàn ăn
        public List<Table> GetAllTables()
        {
            try
            {
                return _context.Tables.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy tất cả bàn ăn từ cơ sở dữ liệu: " + ex.Message);
            }
        }

        // Cập nhật trạng thái bàn
        public void UpdateTableStatus(int tableId, TableStatus status)
        {
            var table = _context.Tables.FirstOrDefault(t => t.Id == tableId);
            if (table != null)
            {
                table.Status = status;
                _context.SaveChanges();
            }
        }

        // Lấy trạng thái bàn mới nhất
        public TableStatus GetLatestTableStatus(int tableId)
        {
            var table = _context.Tables.FirstOrDefault(t => t.Id == tableId);
            return table?.Status ?? TableStatus.Available;
        }

        // Hoàn tất thanh toán
        public void CompletePayment(int tableId)
        {
            try
            {
                // Kiểm tra xem có dữ liệu tạm thời cho bàn này không
                if (!TemporaryDataStorage.TemporaryOrderDetails.ContainsKey(tableId) ||
                    !TemporaryDataStorage.TemporaryOrderDetails[tableId].Any())
                {
                    throw new Exception("Không có dữ liệu để thanh toán.");
                }

                // Lấy các món ăn tạm thời của bàn cụ thể
                var temporaryOrderDetails = TemporaryDataStorage.TemporaryOrderDetails[tableId];

                var table = _context.Tables.FirstOrDefault(t => t.Id == tableId);
                if (table != null)
                {
                    // Tạo đơn hàng mới
                    var order = new Order
                    {
                        TableId = tableId,
                        OrderDate = DateTime.Now,
                        Total = temporaryOrderDetails.Sum(item => item.SubTotal),
                        UserId = CurrentUser.UserId // Giả sử CurrentUser được lấy hợp lệ
                    };

                    _context.Orders.Add(order);
                    _context.SaveChanges(); // Lưu để có Order.Id

                    // Lưu chi tiết đơn hàng
                    foreach (var item in temporaryOrderDetails)
                    {
                        // Kiểm tra nếu FoodId hợp lệ
                        if (item.FoodId == 0)
                        {
                            throw new Exception("Món ăn không hợp lệ. FoodId không thể bằng 0.");
                        }

                        var food = _context.Foods.FirstOrDefault(f => f.Id == item.FoodId);
                        if (food == null)
                        {
                            throw new Exception($"Món ăn với ID {item.FoodId} không tồn tại.");
                        }

                        var orderDetail = new OrderDetail
                        {
                            OrderId = order.Id,
                            Quantity = item.Quantity,
                            SubTotal = item.SubTotal,
                            FoodId = item.FoodId
                        };
                        _context.OrderDetails.Add(orderDetail);
                    }

                    _context.SaveChanges(); // Lưu OrderDetails

                    // Cập nhật trạng thái bàn
                    table.Status = TableStatus.Available;
                    _context.SaveChanges();

                    // Xóa dữ liệu tạm sau khi lưu xong
                    TemporaryDataStorage.TemporaryOrderDetails[tableId].Clear(); // Xóa dữ liệu tạm cho bàn này
                }
                else
                {
                    throw new Exception("Bàn không tồn tại.");
                }
            }
            catch (Exception ex)
            {
                // Kiểm tra lỗi chi tiết hơn nếu có
                string errorMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                throw new Exception("Lỗi khi hoàn tất thanh toán: " + errorMessage);
            }
        }
    }
}
