using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marvel.Data;
using Marvel.Models.MarvelCharacter;
using Marvel.Models.Movie;
using Marvel.Models.Team;
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
            var marvelCharacter = await _context.MarvelCharacters.Include(m => m.Movies).Include(t => t.Teams).FirstOrDefaultAsync(c => c.Id == marvelCharacterId);

            return marvelCharacter is null ? null : new MarvelCharacterDetail
            {
                Id = marvelCharacter.Id,
                Name = marvelCharacter.Name,
                Nemesis = marvelCharacter.Nemesis,
                Teams = marvelCharacter.Teams.Select(t => new TeamListItem {
                    TeamId = t.TeamId,
                    TeamName = t.TeamName
                }).ToList(),
                Movies = marvelCharacter.Movies.Select(m => new MovieListItem {
                    MovieName = m.MovieName
                }).ToList(),
                Powers = marvelCharacter.Powers,
                Gear = marvelCharacter.Gear
            };
        }
        public async Task<bool> UpdateMarvelCharacterByIdAsync(MarvelCharacterUpdate request)
        {
            var marvelCharacterUpdate = await _context.MarvelCharacters.FindAsync(request.Id);
            marvelCharacterUpdate.Name = (request.Name ?? marvelCharacterUpdate.Name);
            marvelCharacterUpdate.Nemesis = (request.Nemesis ?? marvelCharacterUpdate.Nemesis);
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

        public async Task<bool> AddMarvelCharacterToMovie (int movieId, int marvelCharacterId)
        {
            var movieEntity = await _context.CastAndCrewMembers.FindAsync(movieId);
            var marvelCharacterEntity = await _context.MarvelCharacters.FindAsync(marvelCharacterId);
            movieEntity.Character = marvelCharacterEntity;
            marvelCharacterEntity.Actor = movieEntity;
            return await _context.SaveChangesAsync() == 2;
        }
    }
}