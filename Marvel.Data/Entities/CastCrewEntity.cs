using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Marvel.Data.Entities
{
    public class CastCrewEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Role { get; set; }
        public DateTime Birthday { get; set; }
        [Required]
        public string ImdbPage { get; set; }
        public ICollection<MovieEntity> Movies { get; set; }
        public virtual MarvelCharacterEntity Character { get; set; }
    }
}