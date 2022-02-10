using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marvel.Models.MarvelCharacter;

namespace Marvel.Models.Movie
{
    public class MovieCharacterList
    {
        public string MovieName { get; set; }
        public ICollection<MarvelCharacterList> MovieCharacters { get; set; }
    }
}