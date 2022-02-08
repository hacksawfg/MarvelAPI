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
            if (await GetTeamByNameAsync(model.TeamName) != null) return false; 
            var entity = new TeamEntity
            {
                TeamName = model.TeamName,
                Leader = model.Leader
            };
            _ctx.Teams.Add(entity);
            var numberOfChanges = await _ctx.SaveChangesAsync();
            return numberOfChanges == 1;
        }
        public async Task<TeamEntity> GetTeamByNameAsync(string name)
        { 
            return await _ctx.Teams.FirstOrDefaultAsync(team => team.TeamName.ToLower() == name.ToLower()); 
        }
        public async Task<IEnumerable<TeamListItem>> GetAllTeamsAsync()
        {
            var team = await _ctx.Teams.Select(entity => new TeamListItem
            {
                TeamName = entity.TeamName,
            })
            .ToListAsync();
        return team;
        }
        public async Task<TeamDetail> GetTeamByIdAsnyc(int teamId)
        {
            var teamEntity = await _ctx.Teams.FirstOrDefaultAsync(entity => entity.TeamId == teamId);
            return teamEntity is null ? null : new TeamDetail
            {
                TeamName = teamEntity.TeamName,
                Leader = teamEntity.Leader
            };
        }
        public async Task<bool> UpdateTeamByIdAsync(TeamUpdate request)
        {
            var entity = await _ctx.Teams.FindAsync(request.TeamId);
            entity.TeamName = request.TeamName;
            entity.Leader = request.Leader;
            var changes = await _ctx.SaveChangesAsync();
            return changes == 1;
        }
        public async Task<bool> DeleteTeamByIdAsync(int teamId)
        {
            var teamEntity = await _ctx.Teams.FindAsync(teamId);
            _ctx.Teams.Remove(teamEntity);
            return await _ctx.SaveChangesAsync() == 1;
        }

        Task<IEnumerable<TeamListItem>> ITeamService.GetAllTeamsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TeamDetail> GetTeamByIdAsync(int teamId)
        {
            throw new NotImplementedException();
        }
    }
}