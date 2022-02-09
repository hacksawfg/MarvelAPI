using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Marvel.Models.MarvelCharacter
{
    public class MarvelCharacterUpdate
    {
        [Required]
        public string Name { get; set; }
        public string Nemesis { get; set; }
        public string TeamMembership { get; set; }
        public string Appearances { get; set; }

        [Required]
        public string Powers { get; set; }
        public string Gear { get; set; }
    }
}