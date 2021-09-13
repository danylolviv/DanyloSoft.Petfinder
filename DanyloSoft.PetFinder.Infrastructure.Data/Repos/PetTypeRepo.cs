using System.Collections.Generic;
using DanyloSoft.PetFinder.Core.Models;
using DanyloSoft.PetFinder.Domain.IRepositories;

namespace DanyloSoft.PetFinder.Infrastructure.Data.Repos
{
  public class PetTypeRepo : IPetTypeRepository
  {
    private readonly PetFinderAppContext _ctx;

    public PetTypeRepo(PetFinderAppContext ctx)
    {
      _ctx = ctx;
    }
    
    public List<PetType> GetListPetTypes()
    {
      throw new System.NotImplementedException();
    }

    public PetType CreatePetType(PetType newPetType)
    {
      throw new System.NotImplementedException();
    }

    public PetType RemovePetType(PetType petTypeToRemove)
    {
      throw new System.NotImplementedException();
    }

    public PetType EditPetType(PetType petTypeToEdit)
    {
      throw new System.NotImplementedException();
    }

    public IEnumerable<PetType> GetByQuery(string query)
    {
      throw new System.NotImplementedException();
    }
  }
}