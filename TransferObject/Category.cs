using System.ComponentModel.DataAnnotations;

namespace TransferObject
{
    public class Category
    {
        public Category() { }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }


        // Một Category có nhiều Food
        public ICollection<Food> Foods { get; set; } = new List<Food>();
    }
}
