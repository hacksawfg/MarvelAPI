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

        [HttpGet("List")]
        public async Task<IActionResult> ListAllMarvelCharacters()
        {
            var marvelCharacter = await _marvelCharacter.GetAllMarvelCharactersAsync();
            return Ok(marvelCharacter);
        }

         [HttpGet("List/{Id:int}")]
        public async Task<IActionResult> ListMarvelCharacterById(int marvelCharacterId)
        {
            var marvelCharacter = await _marvelCharacter.GetMarvelCharacterDetailAsync(marvelCharacterId);

            return marvelCharacter is not null
                ? Ok(marvelCharacter)
                : NotFound();
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateMarvelCharacterById([FromBody] MarvelCharacterUpdate request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return await _marvelCharacter.UpdateMarvelCharacterByIdAsync(request)
                ? Ok("Character updated")
                : BadRequest("Unable to update character");
        }

         [HttpDelete("Delete/{Id:int}")]
        public async Task<IActionResult> DeleteMarvelCharacter([FromRoute] int marvelCharacterId)
        {
            return await _marvelCharacter.DeleteMarvelCharacterByIdAsync(marvelCharacterId)
            ? Ok("Character removed")
            : BadRequest("Unable to delete character");
        }

    }
}