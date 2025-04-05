using TransferObject;

namespace DataLayer.IRepository
{
    public interface IOrderRepository
    {
        List<Order> GetAllOrders();
        void SaveOrder(Order order);
        Order GetOrderById(int id);
        List<OrderDetail> GetOrdersByTableId(int tableId);
        void UpdateOrderTotal(Order order);
    }
}
