using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marvel.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Marvel.Data
{
    public class MarvelDbContext : DbContext
    {
        public MarvelDbContext (DbContextOptions<MarvelDbContext> options) : base(options) {}
        public DbSet<CastCrewEntity> CastAndCrewMembers { get; set; }
        public DbSet<MovieEntity> Movies { get; set; }
        public DbSet<TeamEntity> Teams { get; set; }
    }
}