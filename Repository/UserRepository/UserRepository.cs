using System.Threading.Tasks;
using dotnet_rpg.Data;
using dotnet_rpg.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_rpg.Repository.UserRepository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> ExistsUser(string username)
        {
            return await GetByCondition(x => x.Username.ToLower().Equals(username.ToLower()))
                .AnyAsync();
        }

        public async Task<User> GetUserById(int userId)
        {
            return await GetByCondition(x => x.Id == userId)
                .FirstOrDefaultAsync();
        }

        public async Task<User> GetUserByUsername(string username)
        {
            return await GetByCondition(x => x.Username.ToLower().Equals(username.ToLower()))
                .FirstOrDefaultAsync();
        }
    }
}