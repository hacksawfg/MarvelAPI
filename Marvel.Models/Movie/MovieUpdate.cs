using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marvel.Models.Movie
{
    public class MovieUpdate
    {
        public string MovieName { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int MovieBoxOfficeUSD { get; set; }
        public List<string> MovieCharacters { get; set; }
        public string MovieDirector { get; set; }
        // public List<Team> MovieTeams { get; set; }
    }
}