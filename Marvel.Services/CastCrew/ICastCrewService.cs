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
        Task<CastCrewDetail> GetCastCrewByName(string name);
    }
}