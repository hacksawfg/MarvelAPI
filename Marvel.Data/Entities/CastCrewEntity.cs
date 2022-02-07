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
        public string Name { get; set; }
        public string Role { get; set; }
        public DateTime Birthday { get; set; }
        public string ImdbPage { get; set; }
        public virtual ICollection<MovieEntity> Movies { get; set; }
        //public virtual CharacterEntity Character { get; set; }
    }
}