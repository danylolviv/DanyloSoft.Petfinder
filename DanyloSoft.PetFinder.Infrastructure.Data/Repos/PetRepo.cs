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
      throw new System.NotImplementedException();
    }

    public IOrderedEnumerable<Pet> GetPets()
    {
      throw new System.NotImplementedException();
    }

    public Pet GetPetById(int id)
    {
      throw new System.NotImplementedException();
    }

    public List<Pet> Get5Cheapest()
    {
      throw new System.NotImplementedException();
    }

    public List<Pet> GetPetsCheapestFirst()
    {
      throw new System.NotImplementedException();
    }

    public Pet UpdatePet(Pet oldPet)
    {
      throw new System.NotImplementedException();
    }

    public void DeletePet(Pet petToDelete)
    {
      throw new System.NotImplementedException();
    }
  }
}