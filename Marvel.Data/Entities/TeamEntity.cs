otusing System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Marvel.Data.Entities
{
    public class TeamEntity
    {
        [Key]
        public int TeamId { get; set; }
        [Required]
        public string TeamName { get; set; }
        // public ICollection<MarvelCharacterEntity> TeamMembers { get; set; }
        public string Leader { get; set; }
        }
}