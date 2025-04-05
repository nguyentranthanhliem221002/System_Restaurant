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
        var existingUser = _context.Users.Find(user.Id);
        if (existingUser != null)
        {
            existingUser.UserName = user.UserName;
            existingUser.PasswordHash = user.PasswordHash; // Nếu có thay đổi mật khẩu
            // Thêm các trường khác cần cập nhật ở đây

            _context.SaveChanges();
        }
    }
}
