using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marvel.Data;
using Marvel.Data.Entities;
using Marvel.Models.Team;
using Microsoft.EntityFrameworkCore;

namespace Marvel.Services.Team
{
    public class TeamService : ITeamService
    {
        private readonly MarvelDbContext _ctx;
        public TeamService(MarvelDbContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<bool> CreateTeamAsync(TeamCreate model)
        {
            if (await GetTeamByNameHelperAsync(model.TeamName) != null) return false; 
            var entity = new TeamEntity
            {
                TeamName = model.TeamName,
                Leader = model.Leader
            };
            _ctx.Teams.Add(entity);
            var numberOfChanges = await _ctx.SaveChangesAsync();
            return numberOfChanges == 1;
        }
        public async Task<TeamEntity> GetTeamByNameHelperAsync(string name)
        { 
            return await _ctx.Teams.FirstOrDefaultAsync(team => team.TeamName.ToLower() == name.ToLower()); 
        }
        public async Task<IEnumerable<TeamListItem>> GetAllTeamsAsync()
        {
            var team = await _ctx.Teams.Select(entity => new TeamListItem
            {
                TeamId = entity.TeamId,
                TeamName = entity.TeamName
            })
            .ToListAsync();
        return team;
        }
        public async Task<TeamDetail> GetTeamByIdAsync(int teamId)
        {
            var teamEntity = await _ctx.Teams.FirstOrDefaultAsync(entity => entity.TeamId == teamId);
            return teamEntity is null ? null : new TeamDetail
            {
                TeamId = teamEntity.TeamId,
                TeamName = teamEntity.TeamName,
                Leader = teamEntity.Leader
            };
        }
        public async Task<TeamDetail> GetTeamByNameAsync(string name)
        {
            var team = await _ctx.Teams.FirstOrDefaultAsync(t => 
                t.TeamName.ToLower() == name.ToLower());
            return team is null ? null : new TeamDetail
            {
                TeamId = team.TeamId,
                TeamName = team.TeamName,
                Leader = team.Leader
            };
        }
        public async Task<bool> UpdateTeamByIdAsync(TeamUpdate request)
        {
            var entity = await _ctx.Teams.FindAsync(request.TeamId);
            entity.TeamName = (request.TeamName ?? entity.TeamName);
            entity.Leader = (request.Leader ?? entity.Leader);
            var changes = await _ctx.SaveChangesAsync();
            return changes == 1;
        }
        public async Task<bool> DeleteTeamByIdAsync(int teamId)
        {
            var teamEntity = await _ctx.Teams.FindAsync(teamId);
            _ctx.Teams.Remove(teamEntity);
            return await _ctx.SaveChangesAsync() == 1;
        }
        public async Task<bool> AddTeamToCharacterAsync(int teamId, AddTeamToCharacter request)
        {
            var entity = await _ctx.MarvelCharacters.FindAsync(request.CharacterId);

            if (request.TeamId == teamId)
            {
                entity.Id = request.CharacterId;
                var numberOfChanges = await _ctx.SaveChangesAsync();
                return numberOfChanges == 1;
            }
            return false;
        }
        public async Task<bool> AddTeamToMovieAsync(int teamId, AddTeamToMovie request)
        {
            var teamEntity = await _ctx.Teams.FindAsync(request.TeamId);
            var movieEntity = await _ctx.Movies
                .Include(m => m.MovieTeams)
                .FirstOrDefaultAsync(m => m.MovieId == request.MovieId);

            if (request.TeamId == teamId)
            {
                movieEntity.MovieTeams.Add(teamEntity);
                var numberOfChanges = await _ctx.SaveChangesAsync();
                return numberOfChanges == 1;
            }
            return false;
        }
    }
}