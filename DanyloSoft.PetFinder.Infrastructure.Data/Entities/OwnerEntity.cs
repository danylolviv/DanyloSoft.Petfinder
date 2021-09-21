using System.Collections.Generic;

namespace DanyloSoft.PetFinder.Infrastructure.Data.Entities
{
  public class OwnerEntity
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Address { get; set; }
    public List<PetEntity> ListPets { get; set; }
  }
}