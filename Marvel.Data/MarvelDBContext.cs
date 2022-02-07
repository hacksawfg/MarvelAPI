using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Marvel.Data
{
    public class MarvelDbContext : DbContext
    {
        public MarvelDbContext (DbContextOptions<MarvelDbContext> options) : base(options) {}
    }
}