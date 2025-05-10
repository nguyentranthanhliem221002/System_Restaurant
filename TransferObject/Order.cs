using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TransferObject
{

    public class Order
    {
        public Order() { }
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,3)")]
        public decimal Total { get; set; }
        public OrderStatus Status { get; set; }

        // Khóa ngoại và có quan hệ 1 - n với Role
        public int UserId { get; set; }
        public User User { get; set; }


        // Khóa ngoại và có quan hệ 1 - n với Table
        public int TableId { get; set; }
        public Table Table { get; set; }


        // Một Order có nhiều OrderDetail
        public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

        public enum OrderStatus
        {
            Success,
            Pending,
            Cancel,
            Failed

        }
    }
}
