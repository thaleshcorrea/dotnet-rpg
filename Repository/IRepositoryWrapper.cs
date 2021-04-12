using System.Threading.Tasks;
using dotnet_rpg.Repository.CharacterRepository;
using dotnet_rpg.Repository.SkillRepository;
using dotnet_rpg.Repository.UserRepository;

namespace dotnet_rpg.Repository
{
    public interface IRepositoryWrapper
    {
        ICharacterRepository Character { get; }
        ISkillRepository Skill { get; }
        IUserRepository User { get; }
        Task Save();
    }
}