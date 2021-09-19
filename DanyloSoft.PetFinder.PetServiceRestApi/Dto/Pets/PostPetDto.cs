using System;
using DanyloSoft.PetFinder.Core.Models;

namespace DanyloSoft.PetFinder.PetServiceRestApi.Dto
{
  public class PostPetDTO
  {
    public string Name { get; set; }
    public int PetTypeId { get; set; }
    public DateTime Birthday { get; set; }
    public int ColorId { get; set; }
    public double Price { get; set; }
  }
}