using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marvel.Data;
using Marvel.Data.Entities;
using Marvel.Models.Movie;
using Microsoft.EntityFrameworkCore;

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

        public async Task<List<MovieListItem>> GetAllMarvelMoviesAsync()
        {
            var movies = await _context.Movies
                .Select (entity => new MovieListItem
                {
                    MovieName = entity.MovieName,
                    ReleaseDate = entity.ReleaseDate,
                    MovieBoxOfficeUSD = entity.MovieBoxOfficeUSD,
                    MovieCharacters = entity.MovieCharacters,
                    MovieDirector = entity.MovieDirector
                }).ToListAsync();
            
            return movies;
        }
    }
}