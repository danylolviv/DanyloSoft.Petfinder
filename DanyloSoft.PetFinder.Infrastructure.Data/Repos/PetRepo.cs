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

    public IOrderedEnumerable<Pet> GetPets()
    {
      return _ctx.PetTable;
    }

    public Pet GetPetById(int id)
    {
      return _ctx.PetTable
        .FirstOrDefault(c => c.Id == id);
    }

    public Pet CreatePet(Pet newPet)
    {
      return _ctx.Add(newPet).Entity;
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
      return _ctx.PetTable;
    }

    public List<Pet> Get5Cheapest()
    {
      var orderByResult = from pet in _ctx.PetTable
        orderby pet.Price //Sorts the studentList collection in ascending order
        select pet;
      return orderByResult.Take(5).ToList();
    }

    private IOrderedEnumerable<Pet> SortLowestToHighest()
    {
      var orderByResult = from pet in _ctx.PetTable
        orderby pet.Price //Sorts the studentList collection in ascending order
        select pet;
      return orderByResult;
    }

    private IOrderedEnumerable<Pet> SortHighestToLowest()
    {
      var orderByResult = from pet in _ctx.PetTable
        orderby pet.Price descending //Sorts the studentList collection in descending order
        select pet;
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