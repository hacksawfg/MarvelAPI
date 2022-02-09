using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marvel.Models.MarvelCharacter
{
    public class MarvelCharacterDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Nemesis { get; set; }
        public string TeamMembership { get; set; }
        public string Appearances { get; set; }
        public string Powers { get; set; }
        public string Gear { get; set; }
    }
}