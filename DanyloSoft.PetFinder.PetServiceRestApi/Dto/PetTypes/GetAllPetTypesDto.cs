using System.Collections.Generic;

namespace DanyloSoft.PetFinder.PetServiceRestApi.Dto.PetTypes
{
  public class GetAllPetTypesDto
  {
    public List<GetPetTypeDto> PetTypes { get; set; }
    public int Count { get; set; }
  }
}