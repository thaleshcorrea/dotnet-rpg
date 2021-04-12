using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet_rpg.Models;

namespace dotnet_rpg.Repository.CharacterRepository
{
    public interface ICharacterRepository : IRepositoryBase<Character>
    {
        Task<List<Character>> GetAllCharacters();
        Task<Character> GetCharacterById(int characterId, int userId);
        Task<Character> GetCharacterWithNesteds(int characterId);
    }
}