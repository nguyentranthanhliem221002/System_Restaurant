using DataLayer.IRepository;
using DataLayer;
using TransferObject;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public User Authenticate(string userName, string password)
    {
        var user = _context.Users.FirstOrDefault(u => u.UserName == userName);
        if (user != null && BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
        {
            return user;
        }
        return null;
    }

    public User GetById(int userId)
    {
        return _context.Users.Find(userId);
    }

    public List<User> GetAllUsers()
        => _context.Users.ToList();

    // Thêm người dùng mới
    public void AddUser(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
    }

    // Xóa người dùng theo ID
    public void DeleteUser(int userId)
    {
        var user = _context.Users.Find(userId);
        if (user != null)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
    }

    // Tìm kiếm người dùng theo tên đăng nhập
    public List<User> SearchByUsername(string userName)
    {
        return _context.Users.Where(u => u.UserName.Contains(userName)).ToList();
    }

    // Cập nhật thông tin người dùng
    public void UpdateUser(User user)
    {
        // Tìm người dùng trong cơ sở dữ liệu theo ID
        var existingUser = _context.Users.Find(user.Id);
        if (existingUser != null)
        {
            // Cập nhật các trường thông tin người dùng
            existingUser.FullName = user.FullName; // Cập nhật họ tên
            existingUser.NumberPhone = user.NumberPhone; // Cập nhật số điện thoại
            existingUser.Email = user.Email; // Cập nhật email
            existingUser.DateStart = user.DateStart; // Cập nhật ngày bắt đầu làm việc
            existingUser.UserName = user.UserName; // Cập nhật tên đăng nhập

            // Nếu có thay đổi mật khẩu, bạn cần đảm bảo mã hóa lại
            if (!string.IsNullOrEmpty(user.PasswordHash))
            {
                existingUser.PasswordHash = user.PasswordHash;
            }

            // Cập nhật vai trò (nếu cần thiết)
            existingUser.RoleId = user.RoleId;

            // Lưu thay đổi vào cơ sở dữ liệu
            _context.SaveChanges();
        }
        else
        {
            // Xử lý khi không tìm thấy người dùng
            throw new ArgumentException($"User with ID {user.Id} not found.");
        }
    }

    public IEnumerable<User> GetUsersByRoleId(int roleId)
    {
        return _context.Users.Where(u => u.RoleId == roleId).ToList();
    }

}
