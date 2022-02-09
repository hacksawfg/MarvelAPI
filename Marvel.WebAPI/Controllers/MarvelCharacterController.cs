using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Marvel.Models.MarvelCharacter;
using Marvel.Services.MarvelCharacter;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Marvel.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarvelCharacterController : Controller
    {
       private readonly IMarvelCharacterService _marvelCharacter;

       public MarvelCharacterController(IMarvelCharacterService marvelCharacter)
        {
            _marvelCharacter = marvelCharacter;
        }

         [HttpPost("Create")]
        public async Task<IActionResult> CreateMarvelCharacter([FromBody] MarvelCharacterCreate newMarvelCharacter)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            if (await _marvelCharacter.CreateMarvelCharacterAsync(newMarvelCharacter))
                return Ok("Character was created successfully");
            
            return BadRequest("Unable to create character");
        }
    }
}