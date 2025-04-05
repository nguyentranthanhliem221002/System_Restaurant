using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TransferObject
{
    public class OrderDetail
    {
        public OrderDetail() { }
        [Key]
        public int Id { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,3)")]
        public decimal SubTotal { get; set; }


        // Khóa ngoại và quan hệ 1 - n với Order
        public int OrderId { get; set; }
        public Order Order { get; set; }


        // Một Order có nhiều Food
        public int FoodId {  get; set; }
        public Food Food { get; set; }
       
    }
}

