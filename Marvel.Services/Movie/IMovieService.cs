using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marvel.Models.Movie;

namespace Marvel.Services.Movie
{
    public interface IMovieService
    {
        public Task<bool> CreateMarvelMovieAsync(MovieCreate newMovie);
        public Task<List<MovieListItem>> GetAllMarvelMoviesAsync();
    }
}