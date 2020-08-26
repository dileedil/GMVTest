using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dao
{
    public class GMVDBContext : DbContext 
    {
        public GMVDBContext(DbContextOptions<GMVDBContext> gmvOptions)
            :base(gmvOptions)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("userId=pgAdmin;Password=srdksql;server=localhost;Port=54524;Database=myDB;");
    
    public DbSet<BusStops> busStops { get; set; }
        public DbSet<Routes> routes { get; set; }
        public DbSet<BusStopRouteTimes> busStopRouteTimes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BusStops>();
            modelBuilder.Entity<Routes>();
            modelBuilder.Entity<BusStopRouteTimes>();
        }
    }
}
