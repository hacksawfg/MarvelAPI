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
            var marvelCharacterUpdate = await _context.MarvelCharacters.FindAsync(request.Id);
            marvelCharacterUpdate.Name = (request.Name ?? marvelCharacterUpdate.Name);
            marvelCharacterUpdate.Nemesis = (request.Nemesis ?? marvelCharacterUpdate.Nemesis);
            marvelCharacterUpdate.TeamMembership = (request.TeamMembership ?? marvelCharacterUpdate.TeamMembership);
            marvelCharacterUpdate.Appearances = (request.Appearances ?? marvelCharacterUpdate.Appearances);
            marvelCharacterUpdate.Powers = (request.Powers ?? marvelCharacterUpdate.Powers);
            marvelCharacterUpdate.Gear = (request.Gear ?? marvelCharacterUpdate.Gear);

            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<bool> DeleteMarvelCharacterByIdAsync(int marvelCharacterId)
        {
            var marvelCharacterDelete = await _context.MarvelCharacters.FindAsync(marvelCharacterId);

            _context.MarvelCharacters.Remove(marvelCharacterDelete);
            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<bool> AddMarvelCharacterToMovieAsync(int Id, AddMarvelCharacterToMovie request)
        {
            var marvelCharacterEntity = await _context.MarvelCharacters.FindAsync(request.Id);
            var movieEntity = await _context.Movies
                .Include(m => m.MovieTeams)
                .FirstOrDefaultAsync(m => m.MovieId == request.MovieId);

            if (request.Id == Id)
            {
                movieEntity.MovieCharacters.Add(marvelCharacterEntity);
                var numberOfChanges = await _context.SaveChangesAsync();
                return numberOfChanges == 1;
            }
            return false;
        }
    }
}