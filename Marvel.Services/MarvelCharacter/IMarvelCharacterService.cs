using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marvel.Models.MarvelCharacter;

namespace Marvel.Services.MarvelCharacter
{
    public interface IMarvelCharacterService
    {
        //Character Creation
         Task<bool> CreateMarvelCharacterAsync(MarvelCharacterCreate newMarvelCharacter);
        //Update Character
         Task<bool> UpdateMarvelCharacterByIdAsync(MarvelCharacterUpdate request);
        //Get All Characters
         Task<ICollection<MarvelCharacterList>> GetAllMarvelCharactersAsync();  
    }
}