using DataLayer.IRepository;
using Microsoft.EntityFrameworkCore;
using TransferObject;

namespace DataLayer.Repository
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly ApplicationDbContext _context; // Đảm bảo đã khởi tạo DbContext để kết nối đến cơ sở dữ liệu

        public OrderDetailRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<OrderDetail> GetAllOrderDetails() => _context.OrderDetails.ToList();

        // Phương thức lưu OrderDetail
        public void SaveOrderDetail(OrderDetail orderDetail)
        {
            _context.OrderDetails.Add(orderDetail);
            
            _context.SaveChanges(); // Lưu OrderDetail
        }

        // Phương thức lấy OrderDetail theo OrderId
        public IEnumerable<OrderDetail> GetOrderDetailsByOrderId(int orderId)
        {
            return _context.OrderDetails.Where(od => od.OrderId == orderId).ToList();
        }
        public List<OrderDetail> GetOrderDetailsByTableId(int tableId)
        {
            // Lấy tất cả các chi tiết đơn hàng (OrderDetail) từ một đơn hàng có liên kết với tableId
            return _context.OrderDetails
                           .Where(od => od.Order.TableId == tableId)  // Điều kiện lọc theo TableId
                           .Include(od => od.Food)  // Bao gồm thông tin món ăn (Food)
                           .ToList();
        }

    }
}
