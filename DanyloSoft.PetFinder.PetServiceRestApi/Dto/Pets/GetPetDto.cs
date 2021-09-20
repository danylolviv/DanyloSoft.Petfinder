using System;

namespace DanyloSoft.PetFinder.PetServiceRestApi.Dto
{
  public class GetPetDto
  {
    public string Name { get; set; }
    public string PetType { get; set; }
    public string ColorName { get; set; }
    public string OwnerName { get; set; }
    public double Price { get; set; }
  }
}