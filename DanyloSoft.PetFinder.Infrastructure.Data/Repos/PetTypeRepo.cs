using System.Collections.Generic;
using System.Linq;
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
      return _ctx.PetTypeTable.ToList();
    }

    public PetType GetById(int id)
    {
      return _ctx.PetTypeTable
        .FirstOrDefault(c => c.Id == id);
    }

    public PetType CreatePetType(PetType newPetType)
    {
      return _ctx.Add(newPetType).Entity;
    }

    public PetType RemovePetType(PetType petTypeToRemove)
    {
      throw new System.NotImplementedException();
    }

    public PetType EditPetType(PetType petTypeToEdit)
    {
      return _ctx.Update(petTypeToEdit).Entity;
    }

    public IEnumerable<PetType> GetByQuery(string query)
    {
      List<PetType> matchingList = new List<PetType>();
      foreach (var petType in _ctx.PetTypeTable)
      {
        if (petType.Name.ToLower().Contains(query.ToLower()))
        {
          matchingList.Add(petType);
        }
      }
      return matchingList;
    }
  }
}