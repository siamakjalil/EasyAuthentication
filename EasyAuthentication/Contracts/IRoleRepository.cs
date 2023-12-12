using EasyAuthentication.Models.Entity;
using System.Linq.Expressions;
using EasyAuthentication.Models.Response;

namespace EasyAuthentication.Contracts
{
    public interface IRoleRepository
    {
        Task<List<Role>> GetAll(Expression<Func<Role, bool>>? where = null, int skip = 0, int take = 20);
        Task<Role> Get(int roleId);
        Task<int> GetCount(Expression<Func<Role, bool>>? where = null); 
        Task<Role> AddRole(Role role);
        Task<Role> UpdateRole(Role role);
        Task<bool> Exist(string title , int id);
        Task<bool> RemoveRole(int id);

        Task<List<UserInRole>> GetUserRoles(Guid userId);
        Task AddRoleToUser(Guid userId, int roleId);
        Task RemoveUserRole(int id);
    }
}
