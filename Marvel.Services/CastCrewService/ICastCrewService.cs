using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marvel.Models.CastCrew;

namespace Marvel.Services.CastCrew
{
    public interface ICastCrewService
    {
        Task<bool> AddCastCrew(CastCrewCreate request);
        Task<IEnumerable<CastCrewListItem>> GetAllCastCrewAsync();
        Task<CastCrewDetail> GetCastCrewByNameAsync(string name);
        Task<CastCrewDetail> GetCastCrewByIdAsync(int id);
        Task<bool> UpdateCastCrewAsync(CastCrewUpdate request);
        Task<bool> DeleteCastCrewAsync(int castCrewId);
    }
}