using System;

namespace DanyloSoft.PetFinder.PetServiceRestApi.Dto
{
  public class PutPetDTO
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public int ColorId { get; set; }
    public double Price { get; set; }
  }
}