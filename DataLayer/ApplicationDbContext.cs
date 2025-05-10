using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using TransferObject;

namespace DataLayer
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Constructor không tham số để hỗ trợ tạo migrations
        public ApplicationDbContext() { }

        public DbSet<Food> Foods { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<PaymentMomo> PaymentMomos { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        // Đọc chuỗi kết nối từ appsettings.json
        //        var configuration = new ConfigurationBuilder()
        //            .SetBasePath(Directory.GetCurrentDirectory())
        //            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        //            .Build();

        //        var connectionString = configuration.GetConnectionString("DefaultConnection");
        //        optionsBuilder.UseSqlServer(connectionString);
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Thiết lập độ chính xác cho các trường decimal
            modelBuilder.Entity<Food>()
                .Property(f => f.Price)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Order>()
                .Property(o => o.Total)
                .HasPrecision(18, 3);

            modelBuilder.Entity<OrderDetail>()
                .Property(od => od.SubTotal)
                .HasPrecision(18, 3);

            // Quan hệ 1 - n: Category - Food
            modelBuilder.Entity<Food>()
                .HasOne(f => f.Category)
                .WithMany(c => c.Foods)
                .HasForeignKey(f => f.CategoryId)
                .OnDelete(DeleteBehavior.Restrict); // Không xóa Food khi Category bị xóa

            // Quan hệ 1 - n: Role - User
            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Restrict); // Không xóa Role khi User bị xóa

            // Quan hệ 1 - n: Order - OrderDetail
            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Order)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(od => od.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            // Quan hệ 1 - n: User - Order 
            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)      
                .WithMany(u => u.Orders)  
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Restrict); // Không xóa User khi Order bị xóa
        }
    }
}
