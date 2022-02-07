using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Marvel.Models.Team
{
    public class TeamCreate
    {
        [Required, MaxLength(100, ErrorMessage = "{0} must contain no more than {1} characters.")]
        public string TeamName { get; set; }
        public ICollection<CharacterEntity> TeamMembers { get; set; }
        public string Leader { get; set; }

        [ForeignKey(nameof(Movie_Characters))]
        public int? MovieId { get; set; }
        [ForeignKey(nameof(Character_Teams))]  
        public int? CharacterId { get; set; }
    }
}