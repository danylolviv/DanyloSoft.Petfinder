using DanyloSoft.PetFinder.Infrastructure.Data.Entities;

namespace DanyloSoft.PetFinder.PetServiceRestApi.Dto.PetTypes
{
  public class GetPetsByPetTypeDto
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public GetPetTypeDto PetType { get; set; }
  }
}