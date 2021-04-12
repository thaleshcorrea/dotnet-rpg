using System.Threading.Tasks;
using dotnet_rpg.Data;
using dotnet_rpg.Repository.CharacterRepository;
using dotnet_rpg.Repository.SkillRepository;
using dotnet_rpg.Repository.UserRepository;

namespace dotnet_rpg.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private DataContext _context;
        private ICharacterRepository _character;
        private ISkillRepository _skill;
        private IUserRepository _user;

        public ICharacterRepository Character 
        {
            get {
                if(_character == null)
                {
                    _character = new Repository.CharacterRepository.CharacterRepository(_context);
                }
                return _character;
            }
        }

        public ISkillRepository Skill 
        {
            get {
                if(_skill == null)
                {
                    _skill = new Repository.SkillRepository.SkillRepository(_context);
                }
                return _skill;
            }
        }

        public IUserRepository User 
        {
            get {
                if(_user == null)
                {
                    _user = new Repository.UserRepository.UserRepository(_context);
                }
                return _user;
            }
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}