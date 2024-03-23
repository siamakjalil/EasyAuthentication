using EasyAuthentication.Models.Entity;
using System.Linq.Expressions;

namespace EasyAuthentication.Contracts
{
    public interface IUserRepository
    {
        Task<List<User>> GetAll(Expression<Func<User, bool>>? where = null, int skip = 0, int take = 20);
        Task<int> GetCount(Expression<Func<User, bool>>? where = null);
        Task<User> FirstOrDefault(Expression<Func<User, bool>>? where = null);
        Task<User> GetProfile(Guid userId);
        Task<User> UpdateProfile(User user);
        Task<User> AddUser(User user);
        Task<User> UpdateUser(User user);
        Task<bool> Exist(string mobileNumber , Guid id); 
        Task<bool> ExistByEmail(string email , Guid id); 
    }
}
