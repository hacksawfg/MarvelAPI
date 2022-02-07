using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marvel.Data;
using Marvel.Data.Entities;
using Marvel.Models.Movie;

namespace Marvel.Services.Movie
{
    public class MovieService
    {
        private readonly MarvelDbContext _context;
        public MovieService(MarvelDbContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateMarvelMovieAsync(MovieCreate movie)
        {
            var newMovie = new MovieEntity
            {
                MovieName = movie.MovieName
            };
            _context.Add(newMovie);

            var numberOfChanges = await _context.SaveChangesAsync();
            return numberOfChanges == 1;
        }
    }
}