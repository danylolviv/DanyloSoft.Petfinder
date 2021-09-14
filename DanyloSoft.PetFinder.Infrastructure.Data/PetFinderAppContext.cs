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
    public IOrderedEnumerable<Pet> PetTable { get; set; }
    public List<PetType> PetTypeTable { get; set; }
    public DbSet<Owner> OwnerTable { get; set; }
  }
}