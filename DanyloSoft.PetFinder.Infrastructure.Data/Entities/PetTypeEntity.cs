using System.Collections.Generic;
using DanyloSoft.PetFinder.Core.Models;

namespace DanyloSoft.PetFinder.Infrastructure.Data.Entities
{
  public class PetTypeEntity
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public List<PetEntity> Pets { get; set; }
    public OwnerEntity Owner { get; set; }
  }
}