using Microsoft.EntityFrameworkCore;
using TransferObject;

namespace DataLayer.IRepository
{
    public interface IOrderDetailRepository
    {
        void SaveOrderDetail(OrderDetail orderDetail);
        IEnumerable<OrderDetail> GetOrderDetailsByOrderId(int orderId);
    }
}
