using DataLayer.IRepository;
using TransferObject;

namespace DataLayer.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ApplicationDbContext _context;
        public RoleRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<Role> GetAllRoles() => _context.Roles.ToList();

    }
}
