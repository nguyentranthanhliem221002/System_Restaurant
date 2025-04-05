using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TransferObject
{
    public enum TableStatus
    {
        Available = 1,  // Bàn trống
        Ordered = 2,    // Đã order món
        Paid = 3        // Đã thanh toán
    }
    public class Table
    {
        public Table() { }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty; // Thêm tên bàn
        [Required]
        [Column(TypeName = "nvarchar(20)")] // Lưu trạng thái dạng chuỗi
        public TableStatus Status { get; set; } = TableStatus.Available;

        // Một Table có nhiều Order
        public ICollection<Order> Orders { get; set; } = new List<Order>();

    }
}
