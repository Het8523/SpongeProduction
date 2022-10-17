using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SpongeProduction.Models;

namespace SpongeProduction.Data
{
    public class SpongeProductionContext : DbContext
    {
        public SpongeProductionContext(DbContextOptions<SpongeProductionContext> options)
            : base(options)
        {
        }

        public DbSet<Sponge> Sponge { get; set; }
    }
}
