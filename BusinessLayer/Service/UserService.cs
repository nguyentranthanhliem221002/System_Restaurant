using DataLayer.IRepository;
using TransferObject;

namespace BusinessLayer.Service
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // Xác thực người dùng
        public User Authenticate(string userName, string password)
        {
            return _userRepository.Authenticate(userName, password);
        }

        // Lấy thông tin người dùng theo ID
        public User GetById(int userId)
        {
            return _userRepository.GetById(userId);
        }

        // Lấy tất cả người dùng
        public List<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        // Thêm người dùng
        public void AddUser(User user)
        {
            _userRepository.AddUser(user);
        }

        // Xóa người dùng
        public void DeleteUser(int userId)
        {
            _userRepository.DeleteUser(userId);
        }

        // Tìm kiếm người dùng theo tên đăng nhập
        public List<User> SearchByUsername(string userName)
        {
            return _userRepository.SearchByUsername(userName);
        }

        // Cập nhật thông tin người dùng
        public void UpdateUser(User user)
        {
            _userRepository.UpdateUser(user);
        }
        public IEnumerable<User> GetUsersByRoleId(int roleId)
        {
            return _userRepository.GetUsersByRoleId(roleId);
        }

        public User GetUserByUserName(string userName)
        {
            try
            {
                return _userRepository.GetUserByUserName(userName);  
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy thông tin người dùng: " + ex.Message);
            }
        }

        public bool ChangePassword(string userName, string newPasswordHash)
        {
            try
            {
                return _userRepository.ChangePassword(userName, newPasswordHash);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thay đổi mật khẩu: " + ex.Message);
            }
        }


    }
}
