using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Marvel.Models.MarvelCharacter
{
    public class MarvelCharacterUpdate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SecretIdentity { get; set; }
        public string Nemesis { get; set; }
        public string Powers { get; set; }
        public string Gear { get; set; }
    }
}