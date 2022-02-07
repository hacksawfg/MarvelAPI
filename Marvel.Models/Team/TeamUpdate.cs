using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Marvel.Models.Team
{
    public class TeamUpdate
    {
        [Required, MaxLength(100, ErrorMessage = "{0} must contain no more than {1} characters.")]
        public string TeamName { get; set; }
        public string Leader { get; set; }
        
    }
}