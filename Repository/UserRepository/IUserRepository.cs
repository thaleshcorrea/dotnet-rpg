using System.Threading.Tasks;
using dotnet_rpg.Models;

namespace dotnet_rpg.Repository.UserRepository
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task<User> GetUserById(int userId);
        Task<User> GetUserByUsername(string username);
        Task<bool> ExistsUser(string username);
    }
}