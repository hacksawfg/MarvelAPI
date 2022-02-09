using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marvel.Data;
using Marvel.Data.Entities;

namespace Marvel.Models.Movie
{
    public class MovieDetail
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public DateTime ReleaseDate { get; set; }
        public double MovieBoxOfficeUSD { get; set; }
        public string MovieDirector { get; set; }
        public ICollection<TeamEntity> MovieTeams { get; set; }
        public ICollection<MarvelCharacterEntity> MovieCharacters { get; set; }
    }
}