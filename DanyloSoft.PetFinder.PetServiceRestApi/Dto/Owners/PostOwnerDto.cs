using System.Collections.Generic;
using DanyloSoft.PetFinder.Core.Models;

namespace DanyloSoft.PetFinder.PetServiceRestApi.Dto.Owners
{
  public class PostOwnerDto
  {
    public string Name { get; set; }
    public int Age { get; set; }
    public string Address { get; set; }
  }
}