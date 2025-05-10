using Microsoft.EntityFrameworkCore;
using TransferObject;

namespace DataLayer.IRepository
{
    public interface IOrderDetailRepository
    {
        List<OrderDetail> GetAllOrderDetails(); 
        void SaveOrderDetail(OrderDetail orderDetail);
        IEnumerable<OrderDetail> GetOrderDetailsByOrderId(int orderId);
        List<OrderDetail> GetOrderDetailsByTableId(int tableId);
    }
}
