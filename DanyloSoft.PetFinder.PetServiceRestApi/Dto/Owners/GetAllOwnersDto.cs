using System.Collections.Generic;

namespace DanyloSoft.PetFinder.PetServiceRestApi.Dto.Owners
{
  public class GetAllOwnersDto
  {
    public List<GetOwnerDto> Owners { get; set; }
    public int Count {get; set;}
  }
}