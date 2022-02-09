using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marvel.Models.Team;
using Marvel.Services.Team;
using Microsoft.AspNetCore.Mvc;

namespace Marvel.WebAPI.Controllers
{

    [Route("api/[controller]"), ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _teamService;
        public TeamController(ITeamService teamService) {_teamService = teamService;}
        [HttpPost("Create")]
        public async Task<IActionResult> CreateTeam([FromBody] TeamCreate model)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            var createResult = await _teamService.CreateTeamAsync(model);
            if (createResult) { return Ok("Team added to database."); }
            return BadRequest("Team could not be added.");
        }
        [HttpPut("AddToCharacter{teamId:int}")]
        public async Task<IActionResult> AddTeamToCharacter([FromRoute] int teamId, [FromBody] AddTeamToCharacter request)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return await _teamService.AddTeamToCharacterAsync(teamId, request)
                ? Ok("Team was added to the character's details successfully!")
                : BadRequest("Team could not be added to the character's details.");
        }
        [HttpPut("AddToMovie{teamId:int}")]
        public async Task<IActionResult> AddTeamToMovie([FromRoute] int teamId, [FromBody] AddTeamToMovie request)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return await _teamService.AddTeamToMovieAsyc(teamId, request)
                ? Ok("Team was added to the movie's details successfully!")
                : BadRequest("Team could not be added to the movie's details.");
        }
        [HttpGet("List"), ProducesResponseType(typeof(IEnumerable<TeamListItem>), 1000)]
        public async Task<IActionResult> GetAllTeams()
        {
            var teams = await _teamService.GetAllTeamsAsync();
            return Ok(teams);
        }
        [HttpGet("Get/{teamId:int}")]
        public async Task<IActionResult> GetTeamById([FromRoute] int teamId)
        {
            var team = await _teamService.GetTeamByIdAsync(teamId);
            return team is not null ? Ok(team) : NotFound();
        }
        [HttpGet("Get/{teamName:string}")]
        public async Task<IActionResult> GetTeamByName([FromBody]string name)
        {
            var team = await _teamService.GetTeamByNameAsync(name);

            return team is not null
                ? Ok(team)
                : NotFound();
        }
        [HttpPut("Update/{teamId:int}")]
        public async Task<IActionResult> UpdateTeamById([FromBody] TeamUpdate request)
        {
            if(!ModelState.IsValid) { return BadRequest(ModelState); }
            return await _teamService.UpdateTeamByIdAsync(request)
                ? Ok("Team updated successfully.")
                : BadRequest("Team could not be updated.");
        }
        [HttpDelete("Delete/{teamId:int}")]
        public async Task<IActionResult> DeleteTeamById([FromRoute] int teamId)
        {
            return await _teamService.DeleteTeamByIdAsync(teamId)
                ? Ok("Team was deleted successfully.")
                : BadRequest("Team could not be deleted.");
        }
    }
}