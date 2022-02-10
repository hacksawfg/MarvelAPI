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
        public Task<bool> CreateMarvelCharacterAsync(MarvelCharacterCreate newMarvelCharacter);
        //Get All Characters
        public Task<ICollection<MarvelCharacterList>> GetAllMarvelCharactersAsync();  
         //Get Detail Characters
        public Task<MarvelCharacterDetail> GetMarvelCharacterDetailAsync(int marvelCharacterId);
        //Update Character
        public Task<bool> UpdateMarvelCharacterByIdAsync(MarvelCharacterUpdate request);
         //Delete Character
        public Task<bool> DeleteMarvelCharacterByIdAsync(int marvelCharacterId);
        public Task<bool> AddMarvelCharacterToMovieAsync(int characterId, AddMarvelCharacterToMovie request);
    }
}