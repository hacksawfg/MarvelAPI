using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marvel.Data;
using Marvel.Data.Entities;
using Marvel.Models.CastCrew;
using Marvel.Models.MarvelCharacter;
using Marvel.Models.Movie;
using Microsoft.EntityFrameworkCore;

namespace Marvel.Services.CastCrew
{
    public class CastCrewService : ICastCrewService
    {
        private readonly MarvelDbContext _dbContext;
        public CastCrewService(MarvelDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> AddCastCrew(CastCrewCreate request)
        {
            var castCrewEntity = new CastCrewEntity
            {
                Name = request.Name,
                Role = request.Role,
                Birthday = request.Birthday,
                ImdbPage = request.ImdbPage,
            };
            _dbContext.CastAndCrewMembers.Add(castCrewEntity);
            var numberOfChanges = await _dbContext.SaveChangesAsync();
            return numberOfChanges == 1;
        }
        public async Task<IEnumerable<CastCrewListItem>> GetAllCastCrewAsync()
        {
            var castCrew = await _dbContext.CastAndCrewMembers
                .Select(e => new CastCrewListItem
                    {
                        Id = e.Id,
                        Name = e.Name,
                        Role = e.Role,
                        Character = e.Character.Name

                    })
                .ToListAsync();
            return castCrew;
        }
        public async Task<CastCrewDetail> GetCastCrewByNameAsync(string name)
        {
            var castCrewEntity = await _dbContext.CastAndCrewMembers.Include(m => m.Movies).Include(c => c.Character).FirstOrDefaultAsync(e => 
                e.Name.ToLower() == name.ToLower());
            return castCrewEntity is null ? null : new CastCrewDetail
            {
                Id = castCrewEntity.Id,
                Name = castCrewEntity.Name,
                Role = castCrewEntity.Role,
                CharacterPlayed = new MarvelCharacterList {
                    Id = castCrewEntity.Character.Id,
                    Name = castCrewEntity.Character.Name
                },
                Birthday = castCrewEntity.Birthday,
                ImdbPage = castCrewEntity.ImdbPage,
                Movies = castCrewEntity.Movies.Select(m => new MovieListItem {
                    MovieName = m.MovieName
                }).ToList()
            };
        }
        public async Task<CastCrewDetail> GetCastCrewByIdAsync(int id)
        {
            var castCrewEntity = await _dbContext.CastAndCrewMembers.Include(m => m.Movies).Include(c => c.Character).FirstOrDefaultAsync(e => 
                e.Id == id);
            return castCrewEntity is null ? null : new CastCrewDetail
            {
                Id = castCrewEntity.Id,
                Name = castCrewEntity.Name,
                Role = castCrewEntity.Role,
                CharacterPlayed = new MarvelCharacterList {
                    Id = castCrewEntity.Character.Id,
                    Name = castCrewEntity.Character.Name
                },
                Birthday = castCrewEntity.Birthday,
                ImdbPage = castCrewEntity.ImdbPage,
                Movies = castCrewEntity.Movies.Select(m => new MovieListItem {
                    MovieName = m.MovieName
                }).ToList()
            };
        }
        public async Task<bool> UpdateCastCrewAsync(CastCrewUpdate request)
        {
            var entity = await _dbContext.CastAndCrewMembers.FindAsync(request.Id);
            entity.Name = (request.Name ?? entity.Name);
            entity.Role = (request.Role ?? entity.Role);
            entity.ImdbPage = (request.ImdbPage ?? entity.ImdbPage);
            var numberOfChanges = await _dbContext.SaveChangesAsync();
            return numberOfChanges == 1;
        }
        public async Task<bool> DeleteCastCrewAsync(int castCrewId)
        {
            var castCrewEntity = await _dbContext.CastAndCrewMembers.FindAsync(castCrewId);
            _dbContext.CastAndCrewMembers.Remove(castCrewEntity);
            return await _dbContext.SaveChangesAsync() == 1;
        }
        public async Task<bool> AddCastCrewToMovieAsync(int castCrewId, AddCastCrewToMovie request)
        {
            var castCrewEntity = await _dbContext.CastAndCrewMembers.FindAsync(request.CastCrewId);
            var movieEntity = await _dbContext.Movies
                .Include(m => m.MovieCastCrew)
                .FirstOrDefaultAsync(m => m.MovieId == request.MovieId);

            if (request.CastCrewId == castCrewId)
            {
                movieEntity.MovieCastCrew.Add(castCrewEntity);
                var numberOfChanges = await _dbContext.SaveChangesAsync();
                return numberOfChanges == 1;
            }
            return false;
        }
        public async Task<bool> SetCastCrewToMarvelCharacter(int castCrewId, int marvelCharacterId)
        {
            var castCrewEntity = await _dbContext.CastAndCrewMembers.FindAsync(castCrewId);
            var marvelCharacterEntity = await _dbContext.MarvelCharacters.FindAsync(marvelCharacterId);
            marvelCharacterEntity.Actor = castCrewEntity;
            // marvelCharacterEntity.Actor.Add(castCrewEntity);
            marvelCharacterEntity = castCrewEntity.Character;
            var numberOfChanges = await _dbContext.SaveChangesAsync();
            return numberOfChanges >= 1;
        }
    }
}