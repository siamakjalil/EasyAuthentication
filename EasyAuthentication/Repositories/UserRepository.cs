using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using EasyAuthentication.Configurations;
using EasyAuthentication.Constants;
using EasyAuthentication.Contracts;
using EasyAuthentication.Models.Entity;
using EasyAuthentication.Models.Jwt;
using EasyAuthentication.Models.Request;
using EasyAuthentication.Models.Response;

namespace EasyAuthentication.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IdentityDbContext _context;

        public UserRepository(IdentityDbContext context)
        {
            _context = context;
        }
        public async Task<List<User>> GetAll(Expression<Func<User, bool>> where = null, int skip = 0, int take = 20)
        {
            var dbSet = _context.Set<User>();
            IQueryable<User> query = dbSet;
            if (where != null)
            {
                query = query.Where(where);
            }
            query = query.OrderByDescending(u => u.Id).Skip(skip).Take(take);
            return await query.ToListAsync();
        }
        public async Task<int> GetCount(Expression<Func<User, bool>>? where = null)
        {
            var dbSet = _context.Set<User>();
            IQueryable<User> query = dbSet;
            if (where != null)
            {
                return await query.CountAsync(where);
            }
            return await query.CountAsync();
        }
        public async Task<User> GetProfile(Guid userId)
        {
            var model = await _context.Users.FindAsync(userId);
            return model;
        }

        public async Task<User> UpdateProfile(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> AddUser(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> UpdateUser(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<bool> Exist(string mobileNumber, Guid id)
        {
            return await _context.Users.AnyAsync(u => u.MobileNumber == mobileNumber && (id == Guid.Empty || u.Id != id));
        }

    }
}
