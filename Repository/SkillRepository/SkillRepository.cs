using dotnet_rpg.Data;
using dotnet_rpg.Models;

namespace dotnet_rpg.Repository.SkillRepository
{
    public class SkillRepository : RepositoryBase<Skill>, ISkillRepository
    {
        private readonly DataContext _context;
        public SkillRepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}