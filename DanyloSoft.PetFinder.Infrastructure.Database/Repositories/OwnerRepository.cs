using System.Collections.Generic;
using DanyloSoft.PetFinder.Core.Models;
using DanyloSoft.PetFinder.Domain.IRepositories;

namespace DanyloSoft.PetFinder.Infrastructure.Database.Repositories
{
  public class OwnerRepository : IOwnerRepository
  {
    private List<Owner> _listOwners = new();
    private static int _runningId = 1;

    public OwnerRepository()
    {
      if (_listOwners.Count <= 0)
      {
        PopulateOwners();
      }
    }
    

    public Owner CreateOwner(Owner newOwner)
    {
      newOwner.Id = _runningId++;
      _listOwners.Add(newOwner);
      return newOwner;
    }

    public List<Owner> getAllOwners()
    {
      return _listOwners;
    }

    public Owner UpdateOwner(Owner updatedOwner)
    {
      var ownerToUpdate = GetById(updatedOwner.Id);
      if (ownerToUpdate != null)
      {
        ownerToUpdate.Address = updatedOwner.Address;
        ownerToUpdate.Age = updatedOwner.Age;
        ownerToUpdate.Name = updatedOwner.Name;
        ownerToUpdate.OwnersPets = updatedOwner.OwnersPets;
        return ownerToUpdate;
      }
      return ownerToUpdate;
    }

    public Owner DeleteOwner(int id)
    {
      var foundOwnerToDel = GetById(id);
      if (foundOwnerToDel != null)
      {
        _listOwners.Remove(foundOwnerToDel);
        return null;
      }
      return foundOwnerToDel;
    }

    public Owner GetById(int id)
    {
      foreach (var owner in _listOwners)
        if (owner.Id == id)
          return owner;
      return null;
    }
    
    private void PopulateOwners()
    {
      CreateOwner(new Owner
        {Address = "The Street", Age = 24, Name = "George"});
      CreateOwner(new Owner
        {Address = "Wall Street", Age = 56, Name = "Mathew"});
      CreateOwner(new Owner
        {Address = "Madison sq. Street", Age = 69, Name = "Elizabeth"});
      CreateOwner(new Owner
        {Address = "The Street", Age = 18, Name = "La Clerk"});
    }
  }
}