using TransferObject;

namespace DataLayer.IRepository
{
    public interface IUserRepository
    {
        User Authenticate(string userName, string password);
        User GetById(int userId);
        List<User> GetAllUsers();
        void AddUser(User user);
        void DeleteUser(int userId);
        List<User> SearchByUsername(string userName);
        void UpdateUser(User user);
        IEnumerable<User> GetUsersByRoleId(int roleId);
        User GetUserByUserName(string userName);  

        bool ChangePassword(string userName, string newPasswordHash);
    }
}
