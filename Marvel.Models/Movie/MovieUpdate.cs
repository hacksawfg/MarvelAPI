using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marvel.Data.Entities;
using Marvel.Models.MarvelCharacter;
using Marvel.Models.Team;

namespace Marvel.Models.Movie
{
    public class MovieUpdate
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string MovieBoxOfficeUSD { get; set; }
        public ICollection<MarvelCharacterList> MovieCharacters { get; set; }
        public string MovieDirector { get; set; }
        public ICollection<TeamListItem> MovieTeams { get; set; }
    }
}