using System.ComponentModel.DataAnnotations;

namespace TransferObject
{
    public class User
    {
        public User() { } 


        // Thông tin chung của một User ( Employee và Admin )
        [Key]
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        public string Email { get; set; }
        [Required]
        public string NumberPhone { get; set; }
        public DateTime DateStart { get; set; }


        // Tài khoản và mật khẩu
        public string UserName { get; set; }
        public string PasswordHash { get; set; }


        // Khóa ngoại và có quan hệ 1 - n với Role
        public int RoleId { get; set; }
        public Role Role { get; set; }


        // Một Order có nhiều OrderDetail
        public ICollection<Order> Orders { get; set; } = new List<Order>();

    }
}
