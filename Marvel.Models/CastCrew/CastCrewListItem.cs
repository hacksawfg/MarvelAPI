using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marvel.Data;

namespace Marvel.Models.CastCrew
{
    public class CastCrewListItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public string Character { get; set; }
    }
}