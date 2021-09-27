using System.Collections.Generic;
using System.Linq;
using DanyloSoft.PetFinder.Core.Models;
using DanyloSoft.PetFinder.Domain.IRepositories;
using DanyloSoft.PetFinder.Infrastructure.Data.Entities;
using DanyloSoft.PetFinder.Infrastructure.Data.Entities.Transformers;
using Microsoft.EntityFrameworkCore;

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

    public PetTypeEntity GetByIdSpecial(int id)
    {
      return _ctx.PetTypeTable
        .FirstOrDefault(c => c.Id == id);
    }
    
    public PetType CreatePetType(string newPetType)
    {
      PetTypeEntity ptE = new PetTypeEntity {Name = newPetType};
      var createdPetType = _tr.FromPetTypeEntity(_ctx.Add(ptE).Entity);
      _ctx.SaveChanges();
      return createdPetType;
    }

    public PetType RemovePetType(PetType petTypeToRemove)
    {
      var deletedEntity =
        _ctx.PetTypeTable.Remove(GetByIdSpecial(petTypeToRemove.Id)).Entity;
      _ctx.SaveChanges();
      return _tr.FromPetTypeEntity(deletedEntity);
    }

    public PetType EditPetType(PetType petTypeToEdit)
    {
      var existingProp = GetByIdSpecial(petTypeToEdit.Id);
      existingProp.Name = petTypeToEdit.Name;
      var updatedProp = _tr.FromPetTypeEntity(_ctx.Update(existingProp).Entity);
      _ctx.SaveChanges();
      return updatedProp;
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

    public List<Pet> GetPetsByPetType(int petTypeId)
    {
      var listPets = new List<Pet>();
      var mL = _ctx.PetTable.Include(pT => pT.PetType).Select(p => p)
        .Where(p => p.PetTypeId == petTypeId);
      foreach (var petEntity in mL)
      {
        listPets.Add(_tr.ForPetTypeSearch(petEntity));
      }

      return listPets;
    }
  }
}