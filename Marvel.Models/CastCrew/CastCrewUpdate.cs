using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Marvel.Data;
using Marvel.Data.Entities;

namespace Marvel.Models.CastCrew
{
    public class CastCrewUpdate
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Role { get; set; }
        public DateTime Birthday { get; set; }
        [Required]
        public string ImdbPage { get; set; }
        public  ICollection<MovieEntity> Movies { get; set; }
        public  MarvelCharacterEntity Character { get; set; }
    }
}