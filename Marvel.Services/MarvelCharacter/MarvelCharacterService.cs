using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marvel.Data;
using Marvel.Models.MarvelCharacter;
using Microsoft.EntityFrameworkCore;

namespace Marvel.Services.MarvelCharacter
{
    public class MarvelCharacterService : IMarvelCharacterService
    {
        private readonly MarvelDbContext _context;
        public MarvelCharacterService(MarvelDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateMarvelCharacterAsync(MarvelCharacterCreate marvelCharacter)
        {
            var newMarvelCharacter = new MarvelCharacterEntity
            {
                Name = marvelCharacter.Name,
                Nemesis = marvelCharacter.Nemesis,
                TeamMembership = marvelCharacter.TeamMembership,
                Appearances = marvelCharacter.Appearances,
                Powers = marvelCharacter.Powers,
                Gear = marvelCharacter.Gear
            };
            _context.Add(newMarvelCharacter);

            var numberOfChanges = await _context.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        public async Task<ICollection<MarvelCharacterList>> GetAllMarvelCharactersAsync()
        {
            var marvelCharacter = await _context.MarvelCharacters
                .Select(entity => new MarvelCharacterList
                {
                    Id = entity.Id,
                    Name = entity.Name
                }).ToListAsync();

            return marvelCharacter;
        }

        public async Task<MarvelCharacterDetail> GetMarvelCharacterDetailAsync(int marvelCharacterId)
        {
            var marvelCharacter = await _context.MarvelCharacters.FirstOrDefaultAsync(m => m.Id == marvelCharacterId);

            return marvelCharacter is null ? null : new MarvelCharacterDetail
            {
                Id = marvelCharacter.Id,
                Name = marvelCharacter.Name,
                Nemesis = marvelCharacter.Nemesis,
                TeamMembership = marvelCharacter.TeamMembership,
                Appearances = marvelCharacter.Appearances,
                Powers = marvelCharacter.Powers,
                Gear = marvelCharacter.Gear
            };
        }

         public async Task<bool> UpdateMarvelCharacterByIdAsync(MarvelCharacterUpdate request)
        {
            var marvelCharacterUpdate = await _context.MarvelCharacters.FindAsync(request.Name);
            marvelCharacterUpdate.Nemesis = request.Nemesis;
            marvelCharacterUpdate.TeamMembership = request.TeamMembership;
            marvelCharacterUpdate.Appearances = request.Appearances;
            marvelCharacterUpdate.Powers = request.Powers;
            marvelCharacterUpdate.Gear = request.Gear;

            return await _context.SaveChangesAsync() == 1;
        }

         public async Task<bool> DeleteMarvelCharacterByIdAsync(int marvelCharacterId)
        {
            var marvelCharacterDelete = await _context.MarvelCharacters.FindAsync(marvelCharacterId);

            _context.MarvelCharacters.Remove(marvelCharacterDelete);
            return await _context.SaveChangesAsync() == 1;
        }
    }
}