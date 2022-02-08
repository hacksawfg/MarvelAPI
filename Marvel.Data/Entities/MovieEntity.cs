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
        public int MovieId { get; set; }
        
        [Required]
        [MinLength(2, ErrorMessage = "{0} must be more than {1} characters in length.")]
        [MaxLength(100, ErrorMessage = "{0} must be less than {1} characters in length.")]
        public string MovieName { get; set; }

        public DateTime ReleaseDate { get; set; }

        public int MovieBoxOfficeUSD { get; set; }

        [MinLength(2, ErrorMessage = "{0} must be more than {1} characters in length.")]
        [MaxLength(100, ErrorMessage = "{0} must be less than {1} characters in length.")]
        public string MovieDirector { get; set; }


        //  Drawing from other tables section
        public ICollection<TeamEntity> MovieTeams { get; set; } 
        public ICollection<MarvelCharacterEntity> MovieCharacters { get; set; }
        public ICollection<CastCrewEntity> MovieCastCrew { get; set; }
        // public List<string> MovieLocations { get; set; }
    }
}