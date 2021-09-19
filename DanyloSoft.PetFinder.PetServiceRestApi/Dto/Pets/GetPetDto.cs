using System;

namespace DanyloSoft.PetFinder.PetServiceRestApi.Dto
{
  public class GetPetDto
  {
    public string Name { get; set; }
    public string PetType { get; set; }
    public int ColorId { get; set; }
    public double Price { get; set; }
  }
}