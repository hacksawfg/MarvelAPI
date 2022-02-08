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
<<<<<<< HEAD
        public MarvelDbContext (DbContextOptions<MarvelDbContext> options) : base(options) {}
        public DbSet<CastCrewEntity> CastAndCrewMembers { get; set; }
=======
        public MarvelDbContext (DbContextOptions<MarvelDbContext> options) : base(options) 
        {
            public DbSet<CastCrewEntity> CastAndCrewMembers { get; set; }
            public DbSet<MovieEntity> Movies { get; set; }
            public DbSet<TeamEntity> Teams { get; set; }
        }
>>>>>>> 9a1906a7ecd77bb25c0b3bbfafe01f439264cdc5
    }
}