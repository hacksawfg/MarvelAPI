using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Marvel.Data.Entities;

namespace Marvel.Data
{
    public class MarvelCharacterEntity
    {
        [Key]
        public int Id { get; set; }
        [MinLength(2, ErrorMessage = "{0} must be more than {1} characters in length.")]
        [MaxLength(100, ErrorMessage = "{0} must be less than {1} characters in length.")]
        public string Name { get; set; }
        [MinLength(2, ErrorMessage = "{0} must be more than {1} characters in length.")]
        [MaxLength(100, ErrorMessage = "{0} must be less than {1} characters in length.")]
        public string SecretIdentity { get; set; }
        public string Nemesis { get; set; }
        public string Powers { get; set; }
        public string Gear { get; set; }
        public ICollection<TeamEntity> Teams { get; set; }
        [ForeignKey(nameof(Actor))]
        public int? CastCrewId { get; set; }
        public CastCrewEntity Actor { get; set; }
        public ICollection<MovieEntity> Movies { get; set; }
    }
}