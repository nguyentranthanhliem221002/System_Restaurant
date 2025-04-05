using DataLayer.IRepository;
using Microsoft.EntityFrameworkCore;
using TransferObject;

namespace DataLayer.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context; // Đảm bảo đã khởi tạo DbContext để kết nối đến cơ sở dữ liệu

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<Order> GetAllOrders() => _context.Orders.ToList();
        public void SaveOrder(Order order)
        {
            // Kiểm tra nếu order.Id không có, hoặc chưa được gán ID, có thể gây lỗi khi lưu
            if (order.Id == 0)
            {
                _context.Orders.Add(order);
            }
            else
            {
                _context.Orders.Update(order);
            }
            _context.SaveChanges(); // Lưu Order
        }

        public Order GetOrderById(int id)
        {
            return _context.Orders.FirstOrDefault(o => o.Id == id);
        }
        public Order GetLatestOrderByTableId(int tableId)
        {
            return _context.Orders
                           .Where(order => order.TableId == tableId)
                           .OrderByDescending(order => order.OrderDate)
                           .FirstOrDefault();
        }
        public List<OrderDetail> GetOrdersByTableId(int tableId)
        {
            return _context.OrderDetails
                           .Where(o => o.Order.TableId == tableId)
                           .Include(o => o.Food)  // Bao gồm đối tượng Food trong truy vấn
                           .ToList();
        }
        public void UpdateOrderTotal(Order order)
        {
            var existingOrder = _context.Orders.FirstOrDefault(o => o.Id == order.Id);
            if (existingOrder != null)
            {
                existingOrder.Total = order.Total; // Cập nhật tổng tiền vào đơn hàng
                _context.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu
            }
        }
    }
}
