using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marvel.Data.Entities;
using Marvel.Models.MarvelCharacter;
using Marvel.Models.Movie;

namespace Marvel.Models.CastCrew
{
    public class CastCrewDetail
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public MarvelCharacterList CharacterPlayed { get; set; }
        public DateTime Birthday { get; set; }
        public string ImdbPage { get; set; }
        public virtual ICollection<MovieListItem> Movies { get; set; }
        
    }
}