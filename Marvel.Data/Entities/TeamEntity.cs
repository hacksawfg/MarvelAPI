using System;
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
        public ICollection<CharacterEntity> TeamMembers { get; set; }
        public string Leader { get; set; }

        [ForeignKey(nameof(Movie_Characters))]
        public int? MovieId { get; set; }
        [ForeignKey(nameof(Character_Teams))]  
        public int? CharacterId { get; set; }
    }
}