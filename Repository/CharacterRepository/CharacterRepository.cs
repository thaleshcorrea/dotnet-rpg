using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using dotnet_rpg.Data;
using dotnet_rpg.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_rpg.Repository.CharacterRepository
{
    public class CharacterRepository : RepositoryBase<Character>, ICharacterRepository
    {
        private readonly DataContext _context;
        public CharacterRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Character>> GetAllCharacters()
        {
            return await GetAll().ToListAsync();
        }

        public async Task<Character> GetCharacterById(int characterId, int userId)
        {
            return await GetByCondition(x => x.Id == characterId && x.User.Id == userId)
                .FirstOrDefaultAsync();
        }

        public async Task<Character> GetCharacterWithNesteds(int characterId)
        {
            return await GetByCondition(x => x.Id == characterId)
                .Include(x => x.CharacterSkills).ThenInclude(x => x.Skill)
                .FirstOrDefaultAsync();
        }
    }
}