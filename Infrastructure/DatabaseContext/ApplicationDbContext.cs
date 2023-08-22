using Application.Data;
using Domain.Weathers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DatabaseContext
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext, IUnitOfWork
    {
        public ApplicationDbContext(DbContextOptions options)
        : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            modelBuilder.HasPostgresExtension("uuid-ossp");
            modelBuilder.Entity<WeatherForecast>().HasKey(x => x.Id).HasName("Id");

            modelBuilder.Entity<WeatherForecast>().HasIndex(x => x.Id).HasDatabaseName("WeatherForecast_Index").IsUnique();
            modelBuilder.Entity<WeatherForecast>().Property(x => x.Id)
                   .HasColumnName("Id")
                   .HasColumnType("uuid")
                   .HasDefaultValueSql("uuid_generate_v4()")
                   .IsRequired();
        }
        public DbSet<WeatherForecast> WeatherForecasts { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var result = await base.SaveChangesAsync(cancellationToken);
            return result;
        }
    }
}
