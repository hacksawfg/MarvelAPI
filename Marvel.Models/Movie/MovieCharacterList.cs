using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marvel.Models.Movie
{
    public class MovieCharacterList
    {
        public string MovieName { get; set; }
        public ICollection<string> MovieCharacters { get; set; }
    }
}