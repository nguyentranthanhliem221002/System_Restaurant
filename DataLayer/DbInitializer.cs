using TransferObject;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class DbInitializer
    {
        public static void SeedData(ApplicationDbContext context)
        {
            context.Database.Migrate(); // Đảm bảo database đã được tạo
            context.ChangeTracker.Clear(); // Tránh lỗi duplicate key nếu seed lại

            SeedRoles(context); // 🔥 Gọi trước
            SeedUsers(context); // 🔥 Gọi sau

            SeedTables(context);
            SeedCategories(context);
            SeedFoods(context);
        }

        private static void SeedTables(ApplicationDbContext context)
        {
            if (!context.Tables.Any())
            {
                var tables = Enumerable.Range(1, 20).Select(_ => new Table()); // Không set Id
                context.Tables.AddRange(tables);
                context.SaveChanges();
                Console.WriteLine("✅ Seed dữ liệu bàn thành công!");
            }
        }

        private static void SeedCategories(ApplicationDbContext context)
        {
            if (!context.Categories.Any())
            {
                var categories = new List<Category>
                {
                    new Category { Name = "Món Ăn" },
                    new Category { Name = "Đồ Uống" },
                    new Category { Name = "Món Thêm" }
                };
                context.Categories.AddRange(categories);
                context.SaveChanges();
                Console.WriteLine("✅ Seed dữ liệu danh mục thành công!");
            }
        }

        private static void SeedFoods(ApplicationDbContext context)
        {
            var foodCategory = context.Categories.FirstOrDefault(c => c.Name == "Món Ăn");
            if (foodCategory != null)
            {
                if (!context.Foods.Any())
                {
                    var foods = new List<Food>
                    {
                        new Food { Name = "Mì Sin Cay", Price = 55.000M, Image = "sin_cay.jpg", Description = "Mì cay Hàn Quốc", CategoryId = foodCategory.Id },
                        new Food { Name = "Mì Soyumm", Price = 45.000M, Image = "soyumm.jpg", Description = "Mì gói Nhật Bản", CategoryId = foodCategory.Id },
                        new Food { Name = "Mì Tương Đen", Price = 40.000M, Image = "tuong_den.jpg", Description = "Mì tương đen Hàn Quốc", CategoryId = foodCategory.Id }
                    };
                    context.Foods.AddRange(foods);
                    context.SaveChanges();
                    Console.WriteLine("✅ Seed dữ liệu món ăn thành công!");
                }
                else
                {
                    Console.WriteLine("⚠️ Dữ liệu món ăn đã tồn tại!");
                }
            }
            else
            {
                Console.WriteLine("⚠️ Không tìm thấy danh mục 'Món Ăn' để seed dữ liệu món ăn!");
            }
        }

        private static void SeedRoles(ApplicationDbContext context)
        {
            if (!context.Roles.Any())
            {
                var roles = new List<Role>
                {
                    new Role { Name = "Admin", RoleType = RoleType.admin, Description = "Quản trị viên" },
                    new Role { Name = "Employee", RoleType = RoleType.employee, Description = "Nhân viên" }
                };

                context.Roles.AddRange(roles);
                context.SaveChanges();
                Console.WriteLine("✅ Seed dữ liệu vai trò thành công!");
            }
            else
            {
                Console.WriteLine("⚠️ Dữ liệu Role đã tồn tại!");
            }
        }

        private static void SeedUsers(ApplicationDbContext context)
        {
            if (!context.Users.Any())
            {
                // Kiểm tra xem Role đã seed chưa
                var adminRole = context.Roles.FirstOrDefault(r => r.RoleType == RoleType.admin);
                var staffRole = context.Roles.FirstOrDefault(r => r.RoleType == RoleType.employee);

                if (adminRole == null || staffRole == null)
                {
                    Console.WriteLine("⚠️ Không tìm thấy Role để tạo User! Hãy chạy SeedRoles trước.");
                    return; // Thoát nếu không có Role
                }

                var users = new List<User>
                {
                    new User
                    {
                        FullName = "Nguyễn Trần Thanh Liêm",
                        Email = "admin@gmail.com",
                        NumberPhone = "0903049728",
                        DateStart = DateTime.UtcNow,
                        UserName = "Admin",
                        PasswordHash = BCrypt.Net.BCrypt.HashPassword("0"),
                        RoleId = adminRole.Id 
                    },
                    new User
                    {
                        FullName = "Nguyễn Văn A",
                        Email = "nguyenvanA@gmail.com",
                        NumberPhone = "0909113113",
                        DateStart = DateTime.UtcNow,
                        UserName = "Employee",
                        PasswordHash = BCrypt.Net.BCrypt.HashPassword("123"),
                        RoleId = staffRole.Id
                    },
                        new User
                    {
                        FullName = "Trần Nguyễn Thanh B",
                        Email = "trannguyenthanhB@gmail.com",
                        NumberPhone = "0903789789",
                        DateStart = DateTime.UtcNow,
                        UserName = "Employee",
                        PasswordHash = BCrypt.Net.BCrypt.HashPassword("123"),
                        RoleId = staffRole.Id
                    },
                            new User
                    {
                        FullName = "Châu Thành C",
                        Email = "chauthanhC@gmail.com",
                        NumberPhone = "0905528583",
                        DateStart = DateTime.UtcNow,
                        UserName = "Employee",
                        PasswordHash = BCrypt.Net.BCrypt.HashPassword("123"),
                        RoleId = staffRole.Id
                    }

                };

                context.Users.AddRange(users);
                context.SaveChanges();
                Console.WriteLine("✅ Seed dữ liệu tài khoản thành công!");
            }
            else
            {
                Console.WriteLine("⚠️ Dữ liệu User đã tồn tại!");
            }
        }
    }
}
