using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marvel.Data.Entities;
using Marvel.Models.CastCrew;
using Marvel.Models.Movie;
using Marvel.Models.Team;

namespace Marvel.Models.MarvelCharacter
{
    public class MarvelCharacterDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SecretIdentity { get; set; }
        public string Nemesis { get; set; }
        public string Powers { get; set; }
        public string Gear { get; set; }
        public ICollection<TeamListItem> Teams { get; set; }
        public CastCrewListItem Actor { get; set; }
        public ICollection<MovieListItem> Movies { get; set; }
    }
}