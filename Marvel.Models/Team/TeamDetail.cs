using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Marvel.Data;
using Marvel.Data.Entities;
using Marvel.Models.Movie;

namespace Marvel.Models.Team
{
    public class TeamDetail
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        // public ICollection<CharacterEntity> TeamMembers { get; set; }
        public string Leader { get; set; }
        public ICollection<MarvelCharacterEntity> TeamMembers { get; set; }
        public ICollection<MovieListItem> TeamMovies { get; set; }
        
    }
}