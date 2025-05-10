using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TransferObject
{
    public class Food
    {
        public Food() { }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,3)")] 
        public decimal Price { get; set; }
        public string? Image { get; set; }
        public SpicyLevel? Level { get; set; } 
        public string? Description { get; set; }


        //Khóa ngoại và quan hệ 1 - n với Category
        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
    public enum SpicyLevel
    {
        Level0,
        Level1,
        Level2, 
        Level3,
        Level4,
        Level5,
        Level6,
        Level7
    }
}
