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
        Price = postPetDto.Price,
        Birthday = postPetDto.Birthday,
        
        PetType = new PetType {Id = postPetDto.PetTypeId},
        Owner = new Owner{Id = postPetDto.OwnerId},
        Color = new Color {Id = postPetDto.ColorId}
      };
      return pet;
    }

    public Pet PutPetTrans(PutPetDTO putPetDto, Pet oldPet)
    {
      Pet pet = new Pet
      {
        Id = oldPet.Id,
        Name = putPetDto.Name,
        Color = new Color
        {
          Id = putPetDto.ColorId
        },
        Price = putPetDto.Price,
        Birthday = oldPet.Birthday,
        PetType = new PetType {Id = oldPet.PetType.Id}
      };
      return pet;
    }

    public GetPetDto GetPet(Pet petM)
    {
      GetPetDto pet = new GetPetDto
      {
        Name = petM.Name,
        ColorName = petM.Color.ColorName,
        OwnerName = petM.Owner.Name,
        PetType = petM.PetType.Name,
        Price = petM.Price
      };
      return pet;
    }
  }
}