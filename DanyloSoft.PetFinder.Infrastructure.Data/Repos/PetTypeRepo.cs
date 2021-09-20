using System.Collections.Generic;
using System.Linq;
using DanyloSoft.PetFinder.Core.Models;
using DanyloSoft.PetFinder.Domain.IRepositories;
using DanyloSoft.PetFinder.Infrastructure.Data.Entities;
using DanyloSoft.PetFinder.Infrastructure.Data.Entities.Transformers;

namespace DanyloSoft.PetFinder.Infrastructure.Data.Repos
{
  public class PetTypeRepo : IPetTypeRepository
  {
    private readonly PetFinderAppContext _ctx;
    private readonly EntityTransformer _tr;

    public PetTypeRepo(PetFinderAppContext ctx)
    {
      _ctx = ctx;
      _tr = new EntityTransformer();
    }
    
    public List<PetType> GetListPetTypes()
    {
      return _ctx.PetTypeTable
        .Select(c => _tr.FromPetTypeEntity(c)).ToList();
    }

    public PetType GetById(int id)
    {
      return _tr.FromPetTypeEntity(_ctx.PetTypeTable
        .FirstOrDefault(c => c.Id == id));
    }

    public PetType CreatePetType(PetType newPetType)
    {
      return _tr.FromPetTypeEntity(_ctx.Add(_tr.ToPetTypeEntity(newPetType)).Entity);
    }

    public PetType RemovePetType(PetType petTypeToRemove)
    {
      throw new System.NotImplementedException();
    }

    public PetType EditPetType(PetType petTypeToEdit)
    {
      return _tr.FromPetTypeEntity(_ctx.Update(_tr.ToPetTypeEntity(petTypeToEdit)).Entity);
    }

    
    
    // public IEnumerable<PetType> GetB(string query)
    // {
    //   List<PetTypeEntity> student = _ctx.PetTypeTable
    //     .Select(s => s.Name.Contains(query)).ToList();
    //
    // }

    public IEnumerable<PetType> GetByQuery(string query)
    {
      List<PetType> matchingList = new List<PetType>();
      foreach (var petType in _ctx.PetTypeTable)
      {
        if (petType.Name.ToLower().Contains(query.ToLower()))
        {
          matchingList.Add(_tr.FromPetTypeEntity(petType));
        }
      }
      return matchingList;
    }
  }
}