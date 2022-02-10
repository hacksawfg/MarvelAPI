using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Marvel.Models.CastCrew
{
    public class AddCastCrewToMovie
    {
        [Required]
        public int CastCrewId { get; set; }
        [Required]
        public int MovieId { get; set; }
    }
}