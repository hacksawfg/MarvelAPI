using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Marvel.Models.CastCrew;
using Marvel.Services.CastCrew;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Marvel.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CastCrewController : ControllerBase
    {
        private readonly ICastCrewService  _castCrewService;
        public CastCrewController (ICastCrewService castCrewService)
        {
            _castCrewService = castCrewService;
        }
        [HttpPost("Create")]
        public async Task<IActionResult> CreateCastCrew([FromBody] CastCrewCreate model)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            var result = await _castCrewService.AddCastCrew(model);
            if (result) { return Ok("Cast/Crew member added to database."); }
            return BadRequest("Cast/Crew member could not be added.");
        }
        [HttpGet, ProducesResponseType(typeof(IEnumerable<CastCrewListItem>), 1000)]
        public async Task<IActionResult> GetAllCastCrew()
        {
            var castCrewMembers = await _castCrewService.GetAllCastCrewAsync();
            return Ok(castCrewMembers);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetCastCrewById([FromRoute]int Id)
        {
            var castCrew = await _castCrewService.GetCastCrewByIdAsync(Id);

            return castCrew is not null
                ? Ok(castCrew)
                : NotFound();
        }
        [HttpGet]
        public async Task<IActionResult> GetCastCrewByName([FromBody]string name)
        {
            var castCrew = await _castCrewService.GetCastCrewByNameAsync(name);

            return castCrew is not null
                ? Ok(castCrew)
                : NotFound();
        }
        
    }
}