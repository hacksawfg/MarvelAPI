using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Marvel.Models.MarvelCharacter
{
    public class AddMarvelCharacterToMovie
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int MovieId { get; set; }
    }
}