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

        [Required]
        [MinLength(2, ErrorMessage = "{0} must be more than {1} characters in length.")]
        [MaxLength(100, ErrorMessage = "{0} must be less than {1} characters in length.")]
        public string Name { get; set; }

        [MinLength(2, ErrorMessage = "{0} must be more than {1} characters in length.")]
        [MaxLength(100, ErrorMessage = "{0} must be less than {1} characters in length.")]
        public string Nemesis { get; set; }
        public string TeamMembership { get; set; }
        public string Appearances { get; set; }

        [Required]
        public string Powers { get; set; }
        public string Gear { get; set; }

        
        public List<TeamEntity> Teams { get; set; }
        [ForeignKey(nameof(Actor))]
        public int? CastCrewId { get; set; }
        public virtual CastCrewEntity Actor { get; set; }
        public List<MovieEntity> Movies { get; set; }
    }
}