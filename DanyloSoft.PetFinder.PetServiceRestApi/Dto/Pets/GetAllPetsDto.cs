using System.Collections.Generic;

namespace DanyloSoft.PetFinder.PetServiceRestApi.Dto
{
  public class GetAllPetsDto
  {
    public List<GetPetDto_Simple> ListPets { get; set; }
    public int PetCount { get; set; }
  }
}