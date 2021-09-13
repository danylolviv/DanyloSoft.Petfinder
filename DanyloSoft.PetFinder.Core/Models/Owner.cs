using System.Collections.Generic;

namespace DanyloSoft.PetFinder.Core.Models
{
  public class Owner
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Address { get; set; }
    public List<Pet> OwnersPets { get; set; }
  }
}