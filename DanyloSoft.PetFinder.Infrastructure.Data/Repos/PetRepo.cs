using System.Collections.Generic;
using System.Linq;
using DanyloSoft.PetFinder.Core.Models;
using DanyloSoft.PetFinder.Domain.IRepositories;
using DanyloSoft.PetFinder.Infrastructure.Data.Entities.Transformers;

namespace DanyloSoft.PetFinder.Infrastructure.Data.Repos
{
  public class PetRepo : IPetRepository
  {
    private readonly PetFinderAppContext _ctx;
    private readonly EntityTransformer _tr;

    public PetRepo(PetFinderAppContext ctx)
    {
      _ctx = ctx;
      _tr = new EntityTransformer();
    }

    public List<Pet> GetPets()
    {
      return _ctx.PetTable
        .Select(entity =>  _tr.FromPetEntity(entity) ).ToList();
    }

    public Pet GetPetById(int id)
    {
      return _tr.FromPetEntity(_ctx.PetTable
        .FirstOrDefault(c => c.Id == id));
    }

    public Pet CreatePet(Pet newPet)
    {
      var entity = _tr.ToPetEntity(newPet);
      var createdPet = _tr.FromPetEntity(_ctx.Add(entity).Entity);
      _ctx.SaveChanges();
      return createdPet;
    }

    public Pet UpdatePet(Pet newPet)
    {
      var entity = _tr.ToPetEntity(newPet);
      var updatedPet = _tr.FromPetEntity(_ctx.Update(entity).Entity);
      _ctx.SaveChanges();
      return updatedPet;
    }
    // IS SAVE_CHANGES that important, below old code
    // public Pet UpdatePet(Pet newPet)
    // {
    //   var entity = _tr.ToPetEntity(newPet);
    //   return _tr.FromPetEntity(_ctx.Update(entity).Entity);
    // }

    public void DeletePet(int Id)
    {
      var pet = GetPetById(Id);
      _ctx.Remove(pet);
      _ctx.SaveChanges();
    }

    #region Sorting algorithms

    public IEnumerable<Pet> GetOrderedListPets(int searchQuery)
    {
      switch (searchQuery)
      {
        case 1:
          return SortLowestToHighest();
        case 2:
          return SortHighestToLowest();
        case 3:
          return Get5Cheapest();
        case 4:
          return GetPets();
      }
      return GetPets();
    }

    public List<Pet> Get5Cheapest()
    {
      var orderByResult = from pet in _ctx.PetTable
        orderby pet.Price //Sorts the studentList collection in ascending order
        select _tr.FromPetEntity(pet);
      return orderByResult.Take(5).ToList();
    }

    private IEnumerable<Pet> SortLowestToHighest()
    {
      var orderByResult = from pet in _ctx.PetTable
        orderby pet.Price //Sorts the studentList collection in ascending order
        select _tr.FromPetEntity(pet);
      return orderByResult;
    }

    private IEnumerable<Pet> SortHighestToLowest()
    {
      var orderByResult = from pet in _ctx.PetTable
        orderby pet.Price descending //Sorts the studentList collection in descending order
        select _tr.FromPetEntity(pet);
      return orderByResult;
    }
    
    private IEnumerable<Pet> List5Cheapest()
    {
      return null;
      // var orderByResult = from pet in GetAllPets()
      //     orderby pet.Price //Sorts the studentList collection in ascending order
      //     select pet;
      // IEnumerable<Pet> first5 = orderByResult.Take(5);
      //
      // var orderByResult2 = from pet in first5
      //     orderby pet.Price //Sorts the studentList collection in ascending order
      //     select pet;
      // return orderByResult2;
    }

    #endregion
    
  }
}