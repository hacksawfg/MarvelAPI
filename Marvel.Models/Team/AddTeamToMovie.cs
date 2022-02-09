using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Marvel.Models.Team
{
    public class AddTeamToMovie
    {
        [Required]
        public int TeamId { get; set; }
        [Required]
        public int MovieId { get; set; }
    }
}