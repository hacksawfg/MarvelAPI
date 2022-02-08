using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Marvel.Data.Entities;

namespace Marvel.Models.CastCrew
{
    public class CastCrewUpdate
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Role { get; set; }
        public DateTime Birthday { get; set; }
        [Required]
        public string ImdbPage { get; set; }
        public virtual ICollection<MovieEntity> Movies { get; set; }
        //public virtual MarvelCharacterEntity Character { get; set; }
    }
}