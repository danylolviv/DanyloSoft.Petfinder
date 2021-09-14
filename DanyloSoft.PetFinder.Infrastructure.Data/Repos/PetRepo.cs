using System.Collections.Generic;
using System.Linq;
using DanyloSoft.PetFinder.Core.Models;
using DanyloSoft.PetFinder.Domain.IRepositories;

namespace DanyloSoft.PetFinder.Infrastructure.Data.Repos
{
  public class PetRepo : IPetRepository
  {
    private readonly PetFinderAppContext _ctx;

    public PetRepo(PetFinderAppContext ctx)
    {
      _ctx = ctx;
    }
    public Pet CreatePet(Pet newPet)
    {
      return _ctx.Add(newPet).Entity;
    }

    public IOrderedEnumerable<Pet> GetPets()
    {
      return _ctx.PetTable;
    }

    public Pet GetPetById(int id)
    {
      return _ctx.PetTable
        .FirstOrDefault(c => c.Id == id);
    }

    public List<Pet> Get5Cheapest()
    {
      throw new System.NotImplementedException();
    }

    public List<Pet> GetPetsCheapestFirst()
    {
      throw new System.NotImplementedException();
    }

    public Pet UpdatePet(Pet newPet)
    {
      return _ctx.Update(newPet).Entity;
    }

    public void DeletePet(int Id)
    {
      var pet = GetPetById(Id);
      _ctx.Remove(pet);
    }
  }
}