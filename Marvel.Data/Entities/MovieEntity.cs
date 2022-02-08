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
        [MinLength(2, ErrorMessage = "{0} must be more than {1} characters in length.")]
        [MaxLength(100, ErrorMessage = "{0} must be less than {1} characters in length.")]
        public string MovieName { get; set; }

        public DateTime ReleaseDate { get; set; }

        public int MovieBoxOfficeUSD { get; set; }
        
        public List<string> MovieCharacters { get; set; }

        [MinLength(2, ErrorMessage = "{0} must be more than {1} characters in length.")]
        [MaxLength(100, ErrorMessage = "{0} must be less than {1} characters in length.")]
        public string MovieDirector { get; set; }

        public List<TeamEntity> MovieTeams { get; set; } // to be determined if adding or not
        // public List<string> MovieLocations { get; set; }
    }
}