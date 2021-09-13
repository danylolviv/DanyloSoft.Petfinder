using System.Collections.Generic;
using DanyloSoft.PetFinder.Core.IServices;
using DanyloSoft.PetFinder.Core.Models;
using DanyloSoft.PetFinder.Domain.IRepositories;

namespace DanyloSoft.PetFinder.Domain.Services
{
  public class OwnerService : IOwnerService
  {
    private readonly IOwnerRepository _repo;

    public OwnerService(IOwnerRepository ownerRepository)
    {
      _repo = ownerRepository;
    }
    public Owner CreateOwner(Owner newOwner)
    {
      return _repo.CreateOwner(newOwner);
    }

    public IEnumerable<Owner> getAllOwners()
    {
      return _repo.getAllOwners();
    }

    public Owner UpdateOwner(Owner updatedOwner)
    {
      throw new System.NotImplementedException();
    }

    public Owner DeleteOwner(int id)
    {
      throw new System.NotImplementedException();
    }

    public Owner GetById(int id)
    {
      throw new System.NotImplementedException();
    }
  }
}