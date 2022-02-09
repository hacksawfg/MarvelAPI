using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Marvel.Data.Entities
{
    public class TeamEntity
    {
        [Key]
        public int TeamId { get; set; }
        [Required]
        public string TeamName { get; set; }
        public ICollection<MarvelCharacterEntity> TeamMembers { get; set; }
        public ICollection<MovieEntity> TeamMovies { get; set; }
        public string Leader { get; set; }
        }
}