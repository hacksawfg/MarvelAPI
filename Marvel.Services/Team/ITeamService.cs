using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marvel.Models.Team;

namespace Marvel.Services.Team
{
    public interface ITeamService
    {
        Task<bool> CreateTeamAsync(TeamCreate request);
        // Task<bool> AddTeamToCharacterAsync(int teamId, AddTeamToCharacter request);
        // Task<bool> AddTeamToMovieAsyc(int teamId, AddTeamToMovie request);
        Task<IEnumerable<TeamListItem>> GetAllTeamsAsync();
        Task<TeamDetail> GetTeamByIdAsync(int teamId);
        Task<TeamDetail> GetTeamByNameAsync(string name);
        Task<bool> UpdateTeamByIdAsync(TeamUpdate request);
        Task<bool> DeleteTeamByIdAsync(int teamId);
    }
}