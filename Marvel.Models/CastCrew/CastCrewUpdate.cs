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
        public int Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public string ImdbPage { get; set; }
        public  ICollection<MovieEntity> Movies { get; set; }
        public  MarvelCharacterEntity Character { get; set; }
    }
}