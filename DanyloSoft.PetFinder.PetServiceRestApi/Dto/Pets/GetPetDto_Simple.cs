using System;
using DanyloSoft.PetFinder.PetServiceRestApi.Dto.PetTypes;

namespace DanyloSoft.PetFinder.PetServiceRestApi.Dto
{
  public class GetPetDto_Simple
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime BirthDay { get; set; }
    public GetPetTypeDto PetType { get; set; }
    public double Price { get; set; }
  }
}