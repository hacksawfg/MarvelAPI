using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marvel.Data;
using Marvel.Data.Entities;
using Marvel.Models.CastCrew;
using Marvel.Models.MarvelCharacter;
using Marvel.Models.Movie;
using Marvel.Models.Team;
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
                    // MovieCharacters = entity.MovieCharacters,
                    MovieDirector = entity.MovieDirector,
                    MovieTeams = entity.MovieTeams.Select(t => new TeamListItem {
                        TeamId = t.TeamId,
                        TeamName = t.TeamName
                    }).ToList()
                }).ToListAsync();
            
            return movies;
        }

        public async Task<MovieDetail> GetMovieDetailAsync(int movieId)
        {
            var movie = await _context.Movies
            .Include(t => t.MovieTeams)
            .Include(c => c.MovieCharacters)
            .Include(k => k.MovieCastCrew)
            .FirstOrDefaultAsync(m => m.MovieId == movieId);

            return movie is null ? null : new MovieDetail
            {
                MovieId = movie.MovieId,
                MovieName = movie.MovieName,
                MovieBoxOfficeUSD = movie.MovieBoxOfficeUSD,
                MovieDirector = movie.MovieDirector,
                MovieCharacters = movie.MovieCharacters.Select(c => new MarvelCharacterList {
                    Id = c.Id,
                    Name = c.Name
                }).ToList(),
                MovieTeams = movie.MovieTeams.Select(t => new TeamListItem {
                    TeamId = t.TeamId,
                    TeamName = t.TeamName
                }).ToList(),
                MovieCastCrew = movie.MovieCastCrew.Select(k => new CastCrewListItem {
                    Id = k.Id,
                    Name = k.Name,
                    Role = k.Role
                }).ToList()
            };
        }
        public async Task<bool> UpdateAMovieByIdAsync(MovieUpdate request)
        {
            var movieUpdate = await _context.Movies.FindAsync(request.MovieId);
            movieUpdate.MovieName = (request.MovieName ?? movieUpdate.MovieName);
            movieUpdate.MovieBoxOfficeUSD = (request.MovieBoxOfficeUSD ?? movieUpdate.MovieBoxOfficeUSD);
            movieUpdate.MovieDirector = (request.MovieDirector ?? movieUpdate.MovieDirector);

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