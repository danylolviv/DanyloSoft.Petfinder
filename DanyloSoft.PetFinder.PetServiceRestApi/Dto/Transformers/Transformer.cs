using DanyloSoft.PetFinder.Core.Models;
using DanyloSoft.PetFinder.PetServiceRestApi.Dto.Owners;

namespace DanyloSoft.PetFinder.PetServiceRestApi.Dto.Transformers
{
  public class Transformer
  {

    public Pet PostPetTrans(PostPetDTO postPetDto)
    {
      Pet pet = new Pet
      {
        Name = postPetDto.Name,
        Color = new Color
        {
          Id = postPetDto.ColorId
        },
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

    public Owner PostOwnerTrans(PostOwnerDto newOwner)
    {
      Owner owner = new Owner
      {
        Name = newOwner.Name,
        Age = newOwner.Age,
        Address = newOwner.Address
        
      };
      return owner;
    }

    public Owner PutOwnerTrans(PutOwnerDto putOwnerDto, Owner oldOwner)
    {
      Owner owner = new Owner
      {
        Id = putOwnerDto.Id,
        Name = putOwnerDto.Name,
        Age = putOwnerDto.Age,
        Address = putOwnerDto.Address,
        OwnersPets = oldOwner.OwnersPets
      };
      return owner;
    }

    public Color PutColorTrans(PutColorDto putColorDto)
    {
      Color col = new Color
      {
        Id = putColorDto.Id,
        ColorName = putColorDto.ColorName
      };
      return col;
    }
  }
}