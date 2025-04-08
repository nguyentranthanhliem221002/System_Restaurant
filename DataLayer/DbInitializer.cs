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
            var categoryMonAn = context.Categories.FirstOrDefault(c => c.Name == "Món Ăn");
            var categoryDoUong = context.Categories.FirstOrDefault(c => c.Name == "Đồ Uống");
            var categoryMonThem = context.Categories.FirstOrDefault(c => c.Name == "Món Thêm");

            if (categoryMonAn == null || categoryDoUong == null || categoryMonThem == null)
            {
                Console.WriteLine("⚠️ Không tìm thấy đầy đủ danh mục! Hãy chắc chắn rằng đã gọi SeedCategories trước.");
                return;
            }

            if (!context.Foods.Any())
            {
                var foods = new List<Food>
                {
                    new Food { Name = "Mì lẩu hái bách tuột", Price = 45M, Image = @"C:\Users\nguye\OneDrive\Máy tính\System_Restaurant\PresentationLayer\Resources\miLauThai_bachTuot.png", Description = "...", CategoryId = categoryMonAn.Id },
                    new Food { Name = "Mì lẩu thái cá", Price = 45M, Image = @"C:\Users\nguye\OneDrive\Máy tính\System_Restaurant\PresentationLayer\Resources\miLauThai_ca.png", Description = "...", CategoryId = categoryMonAn.Id },
                    new Food { Name = "Mì lẩu thái đùi gà", Price = 45M, Image = @"C:\Users\nguye\OneDrive\Máy tính\System_Restaurant\PresentationLayer\Resources\miLauThai_duiga.png", Description = "...", CategoryId = categoryMonAn.Id },
                    new Food { Name = "Mì lẩu thái cá hồi", Price = 45M, Image = @"C:\Users\nguye\OneDrive\Máy tính\System_Restaurant\PresentationLayer\Resources\miLauThai_caHoi.png", Description = "...", CategoryId = categoryMonAn.Id },
                    new Food { Name = "Mì lẩu thái xúc xích", Price = 45M, Image = @"C:\Users\nguye\OneDrive\Máy tính\System_Restaurant\PresentationLayer\Resources\miLauThai_xucXich.png", Description = "...", CategoryId = categoryMonAn.Id },
                    new Food { Name = "Mì lẩu thái sườn sụn", Price = 45M, Image = @"C:\Users\nguye\OneDrive\Máy tính\System_Restaurant\PresentationLayer\Resources\miLauThai_suonSun.png", Description = "...", CategoryId = categoryMonAn.Id },
                    new Food { Name = "Mì lẩu thái thập cẩm", Price = 45M, Image = @"C:\Users\nguye\OneDrive\Máy tính\System_Restaurant\PresentationLayer\Resources\miLauThai_thapCam.png", Description = "...", CategoryId = categoryMonAn.Id },
                    new Food { Name = "Mì trộn hải sản", Price = 45M, Image = @"C:\Users\nguye\OneDrive\Máy tính\System_Restaurant\PresentationLayer\Resources\miTron_haiSan.png", Description = "...", CategoryId = categoryMonAn.Id },

                    new Food { Name = "Fanta", Price = 20M, Image = @"C:\Users\nguye\OneDrive\Máy tính\System_Restaurant\PresentationLayer\Resources\fanta.png", Description = "...", CategoryId = categoryDoUong.Id },
                    new Food { Name = "Coca Zero", Price = 20M, Image = @"C:\Users\nguye\OneDrive\Máy tính\System_Restaurant\PresentationLayer\Resources\cocazero.jpg", Description = "...", CategoryId = categoryDoUong.Id },
                    new Food { Name = "Aquafina", Price = 15M, Image = @"C:\Users\nguye\OneDrive\Máy tính\System_Restaurant\PresentationLayer\Resources\aqua.jpg", Description = "...", CategoryId = categoryDoUong.Id },
                    new Food { Name = "Sting", Price = 20M, Image = @"C:\Users\nguye\OneDrive\Máy tính\System_Restaurant\PresentationLayer\Resources\sting.jpg", Description = "...", CategoryId = categoryDoUong.Id },
                    new Food { Name = "Soda dâu", Price = 32M, Image = @"C:\Users\nguye\OneDrive\Máy tính\System_Restaurant\PresentationLayer\Resources\soda_dau.png", Description = "...", CategoryId = categoryDoUong.Id },
                    new Food { Name = "Soda chanh", Price = 32M, Image = @"C:\Users\nguye\OneDrive\Máy tính\System_Restaurant\PresentationLayer\Resources\soda_chanh.jpg", Description = "...", CategoryId = categoryDoUong.Id },
                    new Food { Name = "Trà đào", Price = 28M, Image = @"C:\Users\nguye\OneDrive\Máy tính\System_Restaurant\PresentationLayer\Resources\tra_dao.png", Description = "...", CategoryId = categoryDoUong.Id },


                    new Food { Name = "Cơm trắng", Price = 25M, Image = @"C:\Users\nguye\OneDrive\Máy tính\System_Restaurant\PresentationLayer\Resources\com_trang.jpg", Description = "...", CategoryId = categoryMonThem.Id },
                    new Food { Name = "Mì 1 vắt", Price = 15M, Image = @"C:\Users\nguye\OneDrive\Máy tính\System_Restaurant\PresentationLayer\Resources\mi_them.jpg", Description = "...", CategoryId = categoryMonThem.Id },

                    new Food { Name = "Khoai tây chiên", Price = 25M, Image = @"C:\Users\nguye\OneDrive\Máy tính\System_Restaurant\PresentationLayer\Resources\khoai_tay_chien.jpg", Description = "...", CategoryId = categoryMonThem.Id },
                    new Food { Name = "Takoyaki", Price = 25M, Image = @"C:\Users\nguye\OneDrive\Máy tính\System_Restaurant\PresentationLayer\Resources\takoyaki.jpg", Description = "...", CategoryId = categoryMonThem.Id },
                    new Food { Name = "Mandu chiên", Price = 25M, Image = @"C:\Users\nguye\OneDrive\Máy tính\System_Restaurant\PresentationLayer\Resources\mandu_chien.jpg", Description = "...", CategoryId = categoryMonThem.Id },
                    new Food { Name = "Kimpap chiên", Price = 25M, Image = @"C:\Users\nguye\OneDrive\Máy tính\System_Restaurant\PresentationLayer\Resources\kimpap_chien.jpg", Description = "...", CategoryId = categoryMonThem.Id },
                    new Food { Name = "Kim chi", Price = 15M, Image = @"C:\Users\nguye\OneDrive\Máy tính\System_Restaurant\PresentationLayer\Resources\kim_chi.jpg", Description = "...", CategoryId = categoryMonThem.Id },


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
