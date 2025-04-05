using DataLayer.IRepository;
using TransferObject;

namespace BusinessLayer.Service
{
    public class OrderDetailService
    {
        private readonly IOrderDetailRepository _orderDetailRepository;

        // Constructor để inject OrderDetailRepository vào trong Service
        public OrderDetailService(IOrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        // Phương thức lưu OrderDetail
        public void SaveOrderDetail(OrderDetail orderDetail)
        {
            _orderDetailRepository.SaveOrderDetail(orderDetail);
        }

        // Phương thức lấy OrderDetails theo OrderId
        public IEnumerable<OrderDetail> GetOrderDetailsByOrderId(int orderId)
        {
            return _orderDetailRepository.GetOrderDetailsByOrderId(orderId);
        }
    }
}
