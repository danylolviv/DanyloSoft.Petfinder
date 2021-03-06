using System.Collections.Generic;
using System.Linq;
using DanyloSoft.PetFinder.Core.Models;
using DanyloSoft.PetFinder.Infrastructure.Data.Entities;
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

      modelBuilder.Entity<PetEntity>().HasOne(p => p.PetType)
        .WithMany(pt => pt.Pets).HasForeignKey(p => p.PetTypeId);

      modelBuilder.Entity<PetEntity>()
        .HasOne(v => v.PetType)
        .WithMany(p => p.Pets)
        .HasForeignKey(f => new {f.PetTypeId})
        .OnDelete(DeleteBehavior.SetNull);

      modelBuilder.Entity<PetEntity>().HasOne(o => o.Owner)
        .WithMany(pt => pt.ListPets).HasForeignKey(p => p.OwnerId);
      
      modelBuilder.Entity<PetTypeEntity>().HasData(new PetTypeEntity {Id = 1, Name = "Dog"});
      modelBuilder.Entity<PetTypeEntity>().HasData(new PetTypeEntity {Id = 2, Name = "Cat"});
      modelBuilder.Entity<PetTypeEntity>().HasData(new PetTypeEntity {Id = 3, Name = "Zebra"});
      modelBuilder.Entity<PetTypeEntity>().HasData(new PetTypeEntity {Id = 4, Name = "Tiger"});
      modelBuilder.Entity<ColorEntity>().HasData(new ColorEntity {Id = 1, ColorName = "Green"}); 
      modelBuilder.Entity<ColorEntity>().HasData(new ColorEntity {Id = 2, ColorName = "Black"}); 
      modelBuilder.Entity<ColorEntity>().HasData(new ColorEntity {Id = 3, ColorName = "Magenta"});
      modelBuilder.Entity<OwnerEntity>().HasData(new OwnerEntity 
        {Id = 1, Name = "Margaret", Address = "Pentington 67", Age = 45});      
      modelBuilder.Entity<OwnerEntity>().HasData(new OwnerEntity 
        {Id = 2, Name = "Winston", Address = "Burton Ave.",Age = 17});
      modelBuilder.Entity<OwnerEntity>().HasData(new OwnerEntity 
        {Id = 3, Name = "Salma", Address = "Crossroad", Age = 17});

      for (int i = 1; i < 1000; i++)
      {
        modelBuilder.Entity<PetEntity>().HasData(new PetEntity()
        {
          Id = i, 
          Name = "Oof" + i, 
          ColorId = 1, 
          OwnerId = 1, 
          PetTypeId = 1,
          Price = 69+i
        });
      }
    }

    public DbSet<PetEntity> PetTable { get; set; }
    public DbSet<PetTypeEntity> PetTypeTable { get; set; }
    public DbSet<OwnerEntity> OwnerTable { get; set; }
    public DbSet<ColorEntity> ColorTable { get; set; }
  }
}