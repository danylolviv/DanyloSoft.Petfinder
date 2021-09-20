using DanyloSoft.PetFinder.Core.Models;

namespace DanyloSoft.PetFinder.Infrastructure.Data.Entities.Transformers
{
  public class EntityTransformer
  {
    public ColorEntity ToColorEntity(Color color)
    {
      ColorEntity colorEntity = new ColorEntity
      {
        Id = color.Id,
        ColorName = color.ColorName
      };
      return colorEntity;
    }
    
    public Color FromColorEntity(ColorEntity colorEntity)
    {
      Color color = new Color
      {
        Id = colorEntity.Id,
        ColorName = colorEntity.ColorName
      };
      return color;
    }
    
    public OwnerEntity ToOwnerEntity(Owner owner)
    {
      OwnerEntity ownerEntity = new OwnerEntity
      {
        Id = owner.Id,
        Address = owner.Address,
        Age = owner.Age,
        Name = owner.Name
      };
      return ownerEntity;
    }
    
    public Owner FromOwnerEntity(OwnerEntity ownerEntity)
    {
      Owner owner = new Owner
      {
        Id = ownerEntity.Id,
        Address = ownerEntity.Address,
        Age = ownerEntity.Age,
        Name = ownerEntity.Name
      };
      return owner;
    }
    
    public PetEntity ToPetEntity(Pet pet)
    {
      PetEntity petEntity = new PetEntity
      {
        Id = pet.Id,
        Name = pet.Name,
        Birthday = pet.Birthday,
        SellOutDate = pet.SellOutDate,
        Price = pet.Price,
        
        PetTypeId = pet.PetType.Id,
        ColorId = pet.Color.Id,
        OwnerId = pet.Owner.Id
      };
      return petEntity;
    }
    
    public Pet FromPetEntity(PetEntity petEntity)
    {
      Pet pet = new Pet
      {
        Id = petEntity.Id,
        Name = petEntity.Name,
        Birthday = petEntity.Birthday,
        SellOutDate = petEntity.SellOutDate,
        Price = petEntity.Price,
        
        PetType = new PetType{Id = petEntity.PetTypeId},
        Owner = new Owner{Id = petEntity.OwnerId},
        Color = new Color{Id = petEntity.ColorId}
      };
      return pet;
    }
    
    public PetTypeEntity ToPetTypeEntity(PetType petType)
    {
      PetTypeEntity petTypeEntity = new PetTypeEntity
      {
        Id = petType.Id,
        Name = petType.Name
      };
      return petTypeEntity;
    }
    
    public PetType FromPetTypeEntity(PetTypeEntity petTypeEntity)
    {
      PetType petType = new PetType
      {
        Id = petTypeEntity.Id,
        Name = petTypeEntity.Name
      };
      return petType;
    }
  }
}