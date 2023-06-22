using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using StocksAPI.DataBase.Models;

namespace StocksAPI.DataBase;

public partial class StocksContext : DbContext
{
    public StocksContext()
    {

    }

    public StocksContext(DbContextOptions<StocksContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Device> Devices { get; set; }

    public virtual DbSet<Log> Logs { get; set; }

    public virtual DbSet<Manufacturer> Manufacturers { get; set; }

    public virtual DbSet<Plot> Plots { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<TypesOfPlot> TypesOfPlots { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("Stocks");
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Device>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.Manufacturer).WithMany(p => p.Devices)
                .HasForeignKey(d => d.ManufacturerId);
        });

        modelBuilder.Entity<Log>(entity =>
        {
            entity.Property(e => e.Subject).HasMaxLength(500);
        });

        modelBuilder.Entity<Manufacturer>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Plot>(entity =>
        {
            entity.Property(e => e.Id).HasMaxLength(14);
            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.TypeOfPlot).WithMany(p => p.Plots)
                .HasForeignKey(d => d.TypeOfPlotId);
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<TypesOfPlot>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
