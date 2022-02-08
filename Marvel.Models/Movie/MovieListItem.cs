using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marvel.Models.Team;

namespace Marvel.Models.Movie
{
    public class MovieListItem
    {
        public string MovieName { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int MovieBoxOfficeUSD { get; set; }
        public ICollection<string> MovieCharacters { get; set; }
        public string MovieDirector { get; set; }
        public ICollection<TeamListItem> MovieTeams { get; set; }
    }
}