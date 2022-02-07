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
    [Route("[controller]")]
    [ApiController]
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;
        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMovie([FromForm] MovieCreate newMovie)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            if (await _movieService.CreateMarvelMovieAsync(newMovie))
                return Ok("Movie created successfully");
            
            return BadRequest("Unable to create movie");
        }

        [HttpGet]
        public async Task<IActionResult> ListAllMarvelMovies()
        {
            var movies = await _movieService.GetAllMarvelMoviesAsync();
            return Ok(movies);
        }

    }
}