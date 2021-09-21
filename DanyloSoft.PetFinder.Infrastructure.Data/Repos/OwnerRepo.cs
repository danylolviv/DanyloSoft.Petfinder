using System.Collections.Generic;
using System.Linq;
using DanyloSoft.PetFinder.Core.Models;
using DanyloSoft.PetFinder.Domain.IRepositories;
using DanyloSoft.PetFinder.Infrastructure.Data.Entities;
using DanyloSoft.PetFinder.Infrastructure.Data.Entities.Transformers;
using Microsoft.EntityFrameworkCore;

namespace DanyloSoft.PetFinder.Infrastructure.Data.Repos
{
  public class OwnerRepo : IOwnerRepository
  {
    private readonly PetFinderAppContext _ctx;
    private readonly EntityTransformer _tr;

    public OwnerRepo(PetFinderAppContext ctx)
    {
      _ctx = ctx;
      _tr = new EntityTransformer();
    }
    
    public Owner CreateOwner(Owner newOwner)
    {
      var createdOwner = _tr.FromOwnerEntity(_ctx.Add(_tr.ToOwnerEntity(newOwner)).Entity);
      _ctx.SaveChanges();
      return createdOwner;
    }

    public IEnumerable<Owner> getAllOwners()
    {
      return _ctx.OwnerTable
        .Select(c => _tr.FromOwnerEntity(c));
    }

    public Owner GetOwnerWithPets(int id)
    {
      var magic = _ctx.OwnerTable
        .Include(o => o.ListPets)
        .FirstOrDefault(c => c.Id == id);
      var magicOwner = _tr.Special(magic);
      return magicOwner;
    }

    public Owner UpdateOwner(Owner updatedOwner)
    {
      var existingEntity = GetByIdSpecial(updatedOwner.Id);
      existingEntity.Name = updatedOwner.Name;
      existingEntity.Age = updatedOwner.Age;
      existingEntity.Address = updatedOwner.Address;
      var updated = _tr.FromOwnerEntity(_ctx.Update(existingEntity).Entity);
      _ctx.SaveChanges();
      return updated;

    }

    public Owner DeleteOwner(int id)
    {
      var owner = GetByIdSpecial(id);
      _ctx.OwnerTable.Remove(owner);
      _ctx.SaveChanges();
      return _tr.FromOwnerEntity(owner);
    }
    
    //THIS DIDNT WORK WHY!!!? BECAUSE NOT THE SAME ENTITY?
    // public Owner DeleteOwner(int id)
    // {
    //   var owner = GetById(id);
    //   _ctx.OwnerTable.Remove(_tr.ToOwnerEntity(owner));
    //   _ctx.SaveChanges();
    //   return owner;
    // }

    public Owner GetById(int id)
    {
      return _tr.FromOwnerEntity(_ctx.OwnerTable.Find(id));
    }
    
    public OwnerEntity GetByIdSpecial(int id)
    {
      return _ctx.OwnerTable.Find(id);
    }
  }
}