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
    public class MovieService : IMovieService
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

        public async Task<ICollection<MovieListItem>> GetAllMarvelMoviesAsync()
        {
            var movies = await _context.Movies
                .Select (entity => new MovieListItem
                {
                    MovieName = entity.MovieName,
                    ReleaseDate = entity.ReleaseDate,
                    MovieBoxOfficeUSD = entity.MovieBoxOfficeUSD,
                    MovieCharacters = (List<string>)entity.MovieCharacters,
                    MovieDirector = entity.MovieDirector
                }).ToListAsync();
            
            return movies;
        }

        public async Task<bool> UpdateAMovieByIdAsync(MovieUpdate request)
        {
            var movieUpdate = await _context.Movies.FindAsync(request.MovieId);

            movieUpdate.MovieName = request.MovieName;
            movieUpdate.MovieBoxOfficeUSD = request.MovieBoxOfficeUSD;
            movieUpdate.MovieCharacters = (ICollection<MarvelCharacterEntity>)request.MovieCharacters;
            movieUpdate.MovieDirector = request.MovieDirector;
            movieUpdate.MovieTeams = (ICollection<TeamEntity>)request.MovieTeams;

            return await _context.SaveChangesAsync() == 1;

        }

        public async Task<bool> DeleteMovieByIdAsync(int movieId)
        {
            var movieDelete = await _context.Movies.FindAsync(movieId);

            _context.Movies.Remove(movieDelete);
            return await _context.SaveChangesAsync() == 1;
        }


    }
}