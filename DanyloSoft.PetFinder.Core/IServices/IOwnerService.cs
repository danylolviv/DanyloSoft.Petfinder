using System.Collections.Generic;
using DanyloSoft.PetFinder.Core.Models;

namespace DanyloSoft.PetFinder.Core.IServices
{
  public interface IOwnerService
  {
    Owner CreateOwner(Owner newOwner);
    List<Owner> getAllOwners();
    Owner UpdateOwner(Owner updatedOwner);
    Owner DeleteOwner(int id);
    Owner GetById(int id);
  }
}