using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Marvel.Models.Team
{
    public class TeamDetail
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        // public ICollection<CharacterEntity> TeamMembers { get; set; }
        public string Leader { get; set; }
        public int? CharacterId { get; set; }
    }
}