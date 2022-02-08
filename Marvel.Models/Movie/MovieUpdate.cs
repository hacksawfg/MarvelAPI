using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marvel.Data.Entities;

namespace Marvel.Models.Movie
{
    public class MovieUpdate
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int MovieBoxOfficeUSD { get; set; }
        public ICollection<string> MovieCharacters { get; set; }
        public string MovieDirector { get; set; }
        public ICollection<TeamEntity> MovieTeams { get; set; }
    }
}