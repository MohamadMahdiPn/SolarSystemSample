using Microsoft.EntityFrameworkCore;
using SolarSystemSample.Data.Entities;
using System;

namespace SolarSystemSample.Data.DatabaseContext;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<SolarSystem> SolarSystems => Set<SolarSystem>();
    public DbSet<Planet> Planets => Set<Planet>();
    public DbSet<Moon> Moons => Set<Moon>();


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // SolarSystem
        modelBuilder.Entity<SolarSystem>(entity =>
        {
            entity.ToTable("SolarSystems");
            entity.Property(x => x.Name).HasMaxLength(200).IsRequired();
            entity.Property(x => x.StarName).HasMaxLength(200).IsRequired();
        });

        // Planet
        modelBuilder.Entity<Planet>(entity =>
        {
            entity.ToTable("Planets");
            entity.Property(x => x.Name).HasMaxLength(200).IsRequired();
            entity.Property(x => x.Label).HasMaxLength(100).IsRequired();
            entity.Property(x => x.Type).HasMaxLength(100).IsRequired();
            entity.Property(x => x.Color).HasMaxLength(30);

            entity.HasOne(p => p.SolarSystem)
                .WithMany(s => s.Planets)
                .HasForeignKey(p => p.SolarSystemId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        // Moon
        modelBuilder.Entity<Moon>(entity =>
        {
            entity.ToTable("Moons");
            entity.Property(x => x.Name).HasMaxLength(200).IsRequired();
            entity.Property(x => x.Label).HasMaxLength(100).IsRequired();
            entity.Property(x => x.Type).HasMaxLength(100).IsRequired();
            entity.Property(x => x.Color).HasMaxLength(30);

            entity.HasOne(m => m.Planet)
                .WithMany(p => p.Moons)
                .HasForeignKey(m => m.PlanetId)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }
}