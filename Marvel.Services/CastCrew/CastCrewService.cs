using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marvel.Data;
using Marvel.Data.Entities;
using Marvel.Models.CastCrew;
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
        public async Task<CastCrewDetail> GetCastCrewByName(string name)
        {
            var castCrewEntity = await _dbContext.CastAndCrewMembers.FirstOrDefaultAsync(c => 
                c.Name.ToLower() == name.ToLower());
            return castCrewEntity is null ? null : new CastCrewDetail
            {
                Id = castCrewEntity.Id,
                Name = castCrewEntity.Name,
                Role = castCrewEntity.Role,
                Birthday = castCrewEntity.Birthday,
                ImdbPage = castCrewEntity.ImdbPage,
                Movies = castCrewEntity.Movies
            };
        }
    }
}