using System.Collections.Generic;
using System.Linq;
using DanyloSoft.PetFinder.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace DanyloSoft.PetFinder.Infrastructure.Data
{
  public class PetFinderAppContext : DbContext
  {
    public PetFinderAppContext(DbContextOptions<PetFinderAppContext> opt)
      : base(opt)
    {
      
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<PetType>()
        .HasData(new PetType {Id = 1, Name = "Dog"});
      modelBuilder.Entity<PetType>()
        .HasData(new PetType {Id = 2, Name = "Cat"});
      modelBuilder.Entity<PetType>()
        .HasData(new PetType {Id = 3, Name = "Zebra"});
      modelBuilder.Entity<PetType>()
        .HasData(new PetType {Id = 4, Name = "Tiger"});
      modelBuilder.Entity<Color>()
        .HasData(new Color {Id = 1, ColorName = "Green"}); 
      modelBuilder.Entity<Color>()
        .HasData(new Color {Id = 2, ColorName = "Black"}); 
      modelBuilder.Entity<Color>()
        .HasData(new Color {Id = 3, ColorName = "Magenta"});

    }

    public IOrderedEnumerable<Pet> PetTable { get; set; }
    public DbSet<PetType> PetTypeTable { get; set; }
    public DbSet<Owner> OwnerTable { get; set; }
    public DbSet<Color> ColorTable { get; set; }
  }
}