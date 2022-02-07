using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marvel.Data.Entities;

namespace Marvel.Models.CastCrew
{
    public class CastCrewDetail
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public DateTime Birthday { get; set; }
        public string ImdbPage { get; set; }
        public virtual ICollection<MovieEntity> Movies { get; set; }
        //public virtual CharacterEntity Character { get; set; }
    }
}