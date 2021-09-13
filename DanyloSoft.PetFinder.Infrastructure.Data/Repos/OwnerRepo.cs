using System.Collections.Generic;
using System.Linq;
using DanyloSoft.PetFinder.Core.Models;
using DanyloSoft.PetFinder.Domain.IRepositories;

namespace DanyloSoft.PetFinder.Infrastructure.Data.Repos
{
  public class OwnerRepo : IOwnerRepository
  {
    private readonly PetFinderAppContext _ctx;

    public OwnerRepo(PetFinderAppContext ctx)
    {
      _ctx = ctx;
    }
    
    public Owner CreateOwner(Owner newOwner)
    {
      var createdOwner = _ctx.Add(newOwner).Entity;
      _ctx.SaveChanges();
      return createdOwner;
    }

    public IEnumerable<Owner> getAllOwners()
    {
      return _ctx.OwnerTable;
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
      return _ctx.OwnerTable
        .FirstOrDefault(c => c.Id == id);
    }
  }
}