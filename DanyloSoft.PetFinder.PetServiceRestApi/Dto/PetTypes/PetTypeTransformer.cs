using DanyloSoft.PetFinder.Core.Models;

namespace DanyloSoft.PetFinder.PetServiceRestApi.Dto.PetTypes
{
  public class PetTypeTransformer
  {
    public GetPetTypeDto GetPetType(PetType petType)
    {
      return new GetPetTypeDto {Name = petType.Name};
    }

    public PetType PostPetType(PostPetTypeDto postPetTypeDto)
    {
      return new PetType {Name = postPetTypeDto.Name};
    }

    public PetType PutPetType( PutPetTypeDto putPetTypeDto)
    {
      return new PetType {Id = putPetTypeDto.Id, Name = putPetTypeDto.NewName};
    }
  }
}