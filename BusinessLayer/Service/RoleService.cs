using DataLayer.IRepository;
using TransferObject;

namespace BusinessLayer.Service
{
    public class RoleService
    {
        private readonly IRoleRepository _roleRepository;
        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
        public List<Role> GetAllRoles()
        {
            return _roleRepository.GetAllRoles();
        }
    }
}
