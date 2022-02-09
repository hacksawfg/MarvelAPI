using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Marvel.Models.Movie;
using Marvel.Services.Movie;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Marvel.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;
        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateMovie([FromBody] MovieCreate newMovie)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            if (await _movieService.CreateMarvelMovieAsync(newMovie))
                return Ok("Movie created successfully");
            
            return BadRequest("Unable to create movie");
        }

        [HttpGet("List")]
        public async Task<IActionResult> ListAllMarvelMovies()
        {
            var movies = await _movieService.GetAllMarvelMoviesAsync();
            return Ok(movies);
        }

        [HttpGet("List/{movieId:int}")]
        public async Task<IActionResult> ListMovieById(int movieId)
        {
            var movie = await _movieService.GetMovieDetailAsync(movieId);

            return movie is not null
                ? Ok(movie)
                : NotFound();
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAMovieById([FromBody] MovieUpdate request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return await _movieService.UpdateAMovieByIdAsync(request)
                ? Ok("Movie updated")
                : BadRequest("Unable to update movie");
        }

        [HttpDelete("Delete/{movieId:int}")]
        public async Task<IActionResult> DeleteAMovie([FromRoute] int movieId)
        {
            return await _movieService.DeleteMovieByIdAsync(movieId)
            ? Ok("Movie removed")
            : BadRequest("Unable to delete movie");
        }

    }
}