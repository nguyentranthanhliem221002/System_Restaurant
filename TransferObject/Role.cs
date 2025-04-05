using System.ComponentModel.DataAnnotations;

namespace TransferObject
{
    public enum RoleType
    {
        admin = 1,
        employee = 2
    }
    public class Role
    {
        public Role() { }

        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public RoleType RoleType { get; set; }
        public string? Description { get; set; }


        // Một Role có nhiều User
        public ICollection<User> Users { get; set; } = new List<User>();
    }
}
