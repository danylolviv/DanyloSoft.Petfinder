using DanyloSoft.PetFinder.Core.Models;

namespace DanyloSoft.PetFinder.PetServiceRestApi.Dto.Owners
{
  public class OwnerTransformer
  {

    public GetOwnerDto GetOwner(Owner owner)
    {
      return new GetOwnerDto
        {Address = owner.Address, Age = owner.Age, Name = owner.Name};
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
  }
}