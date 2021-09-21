using System.Collections.Generic;
using DanyloSoft.PetFinder.Core.Models;

namespace DanyloSoft.PetFinder.Core.IServices
{
  public interface IOwnerService
  {
    Owner CreateOwner(Owner newOwner);
    IEnumerable<Owner> getAllOwners();
    Owner GetOwnerWithPets(int id);
    Owner UpdateOwner(Owner updatedOwner);
    Owner DeleteOwner(int id);
    Owner GetById(int id);
  }
}