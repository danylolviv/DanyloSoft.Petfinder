using DanyloSoft.PetFinder.Core.Models;

namespace DanyloSoft.PetFinder.PetServiceRestApi.Dto
{
  public class PetTransformer
  {
    public Pet PostPetTrans(PostPetDTO postPetDto)
    {
      Pet pet = new Pet
      {
        Name = postPetDto.Name,
        Color = postPetDto.Color,
        Price = postPetDto.Price,
        Birthday = postPetDto.Birthday,
        PetType = new PetType {Id = postPetDto.PetTypeId}
      };
      return pet;
    }

    public Pet PutPetTrans(PutPetDTO putPetDto, Pet oldPet)
    {
      Pet pet = new Pet
      {
        Id = oldPet.Id,
        Name = putPetDto.Name,
        Color = putPetDto.Color,
        Price = putPetDto.Price,
        Birthday = oldPet.Birthday,
        PetType = new PetType {Id = oldPet.PetType.Id}
      };
      return pet;
    }
  }
}