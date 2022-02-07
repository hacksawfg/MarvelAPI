using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Marvel.Data.Entities
{
    public class MovieEntity
    {
        [Key]
        int MovieId { get; set; }
        [Required]
        public string MovieName { get; set; }
        public DateTime ReleaseDate { get; set; }
        public decimal MovieBoxOfficeUSD { get; set; }
        public List<string> MovieCharacters { get; set; }
        public string MovieDirector { get; set; }
        // public Team MovieTeams { get; set; } // to be determined if adding or not
        public List<string> MovieLocations { get; set; }
    }
}