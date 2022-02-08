using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Marvel.Data.Entities;

namespace Marvel.Data
{
    public class MarvelCharacterEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Nemesis { get; set; }
        public string TeamMembership { get; set; }
        public string Appearances { get; set; }
        public string Powers { get; set; }
        public string Gear { get; set; }

        public List<TeamEntity> Teams { get; set; }
        public virtual CastCrewEntity Actor { get; set; }
        public List<MovieEntity> Movies { get; set; }
    }
}