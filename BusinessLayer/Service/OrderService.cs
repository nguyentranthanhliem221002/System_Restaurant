using DataLayer.IRepository;
using TransferObject;

public class OrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IOrderDetailRepository _orderDetailRepository;

    public List<Order> GetAllOrders() => _orderRepository.GetAllOrders().ToList();
    // Cập nhật constructor để nhận cả hai repository
    public OrderService(IOrderRepository orderRepository, IOrderDetailRepository orderDetailRepository)
    {
        _orderRepository = orderRepository;
        _orderDetailRepository = orderDetailRepository;
    }

    // Phương thức lưu đơn hàng
    public void SaveOrder(Order order)
    {
        _orderRepository.SaveOrder(order);
    }

    // Phương thức lưu OrderDetail
    public void SaveOrderDetail(OrderDetail orderDetail)
    {
        _orderDetailRepository.SaveOrderDetail(orderDetail);
    }
    public List<OrderDetail> GetOrdersByTableId(int tableId)
    {
        return _orderRepository.GetOrdersByTableId(tableId);
    }
    public void UpdateOrderTotal(Order order)
    {
        // Tính tổng tiền từ các OrderDetail
        decimal total = 0;

        var orderDetails = _orderDetailRepository.GetOrderDetailsByOrderId(order.Id);

        if (orderDetails != null)
        {
            foreach (var orderDetail in orderDetails)
            {
                total += orderDetail.SubTotal; // Tổng tiền của các OrderDetail
            }
        }

        // Cập nhật lại tổng tiền trong Order
        order.Total = total;

        // Cập nhật vào cơ sở dữ liệu
        _orderRepository.UpdateOrderTotal(order);
    }


}
