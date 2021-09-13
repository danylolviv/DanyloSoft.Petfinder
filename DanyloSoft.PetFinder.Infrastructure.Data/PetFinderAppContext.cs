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
    public DbSet<Pet> PetTable { get; set; }
    public DbSet<PetType> PetTypeTable { get; set; }
    public DbSet<Owner> OwnerTable { get; set; }
  }
}