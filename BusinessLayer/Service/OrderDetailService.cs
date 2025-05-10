using DataLayer.IRepository;
using DataLayer.Repository;
using TransferObject;

namespace BusinessLayer.Service
{
    public class OrderDetailService
    {
        private readonly IOrderDetailRepository _orderDetailRepository;

        public OrderDetailService(IOrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        public List<OrderDetail> GetAllOrderDetails() => _orderDetailRepository.GetAllOrderDetails();


        public void SaveOrderDetail(OrderDetail orderDetail)
        {
            _orderDetailRepository.SaveOrderDetail(orderDetail);
        }

        public IEnumerable<OrderDetail> GetOrderDetailsByOrderId(int orderId)
        {
            return _orderDetailRepository.GetOrderDetailsByOrderId(orderId);
        }
        public List<OrderDetail> GetOrderDetailsByTableId(int tableId)
        {
            return _orderDetailRepository.GetOrderDetailsByTableId(tableId);
        }
    }
}
