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
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public string Leader { get; set; }
    }
}