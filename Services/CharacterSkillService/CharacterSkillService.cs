using System;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using dotnet_rpg.Data;
using dotnet_rpg.Dtos.Character;
using dotnet_rpg.Dtos.CharacterSkill;
using dotnet_rpg.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace dotnet_rpg.Services.CharacterSkillService
{
    public class CharacterSkillService : ICharacterSkillService
    {
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        public CharacterSkillService(DataContext context, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _context = context;

        }

        private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

        public async Task<ServiceResponse<GetCharacterDto>> AddCharacterSkill(AddCharacterSkillDto newCharacterSkill)
        {
            ServiceResponse<GetCharacterDto> response = new ServiceResponse<GetCharacterDto>();
            try
            {
                Character character = await _context.Characters
                    .Include(x => x.Weapon)
                    .Include(x => x.CharacterSkills).ThenInclude(cs => cs.Skill)
                    .FirstOrDefaultAsync(x => x.Id == newCharacterSkill.CharacterId
                        && x.User.Id == GetUserId());

                if(character == null)
                {
                    response.Sucess = false;
                    response.Message = "Personagem não econtrado";
                    return response;
                }
                
                Skill skill = await _context.Skills
                    .FirstOrDefaultAsync(x => x.Id == newCharacterSkill.SkillId);

                if(skill == null)
                {
                    response.Sucess = false;
                    response.Message = "Skill not found";
                    return response;
                }

                CharacterSkill characterSkill = new CharacterSkill
                {
                    Character = character,
                    Skill = skill,
                };

                await _context.AddAsync(characterSkill);
                await _context.SaveChangesAsync();

                response.Data = _mapper.Map<GetCharacterDto>(character);
            }
            catch(Exception ex) 
            {
                response.Sucess = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}