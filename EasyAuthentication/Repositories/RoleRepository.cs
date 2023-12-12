using EasyAuthentication.Configurations;
using EasyAuthentication.Contracts;
using EasyAuthentication.Models.Entity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Net.Sockets;
using EasyAuthentication.Models.Response;
using System.Data;

namespace EasyAuthentication.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly IdentityDbContext _context;

        public RoleRepository(IdentityDbContext context)
        {
            _context = context;
        }

        public async Task<List<Role>> GetAll(Expression<Func<Role, bool>>? where = null, int skip = 0, int take = 20)
        {
            var dbSet = _context.Set<Role>();
            IQueryable<Role> query = dbSet;
            if (where != null)
            {
                query = query.Where(where);
            }
            query = query.OrderByDescending(u => u.Id).Skip(skip).Take(take);
            return await query.ToListAsync();
        }
        public async Task<Role> Get(int roleId)
        {
            return await _context.Roles.FindAsync(roleId);
        }
        public async Task<int> GetCount(Expression<Func<Role, bool>>? where = null)
        {
            var dbSet = _context.Set<Role>();
            IQueryable<Role> query = dbSet;
            if (where != null)
            {
                return await query.CountAsync(where);
            }
            return await query.CountAsync();
        }

        public async Task<Role> UpdateRole(Role role)
        {
            _context.Roles.Update(role);
            await _context.SaveChangesAsync();
            return role;
        }

        public async Task<Role> AddRole(Role role)
        {
            await _context.Roles.AddAsync(role);
            await _context.SaveChangesAsync();
            return role;
        }

        public async Task<bool> Exist(string mobileNumber, int id)
        {
            return await _context.Roles.AnyAsync(u => u.Title == mobileNumber && (id == 0 || u.Id != id));
        }

        public async Task<bool> RemoveRole(int id)
        {
            var role = await Get(id);
            if (role == null) return false;
            var userRole = await _context.UserInRoles.Where(u => u.RoleId == id).ToListAsync();
            _context.UserInRoles.RemoveRange(userRole);
            await _context.SaveChangesAsync();

            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<List<UserInRole>> GetUserRoles(Guid userId)
        {
            return await _context.UserInRoles
                .Include(u => u.Role)
                .Where(u => u.UserId == userId)
                .ToListAsync();
        }

        public async Task AddRoleToUser(Guid userId, int roleId)
        {
            await _context.UserInRoles.AddAsync(new UserInRole()
            {
                RoleId = roleId,
                UserId = userId,
            });
            await _context.SaveChangesAsync();
        }

        public async Task RemoveUserRole(int id)
        {
            var role = await _context.UserInRoles.FindAsync(id);
            if (role == null) { return; }

            _context.Remove(role);
            await _context.SaveChangesAsync();
        }
    }
}
