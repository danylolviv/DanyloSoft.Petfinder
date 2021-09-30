using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DanyloSoft.PetFinder.Core.Filters;
using DanyloSoft.PetFinder.Core.Models;
using DanyloSoft.PetFinder.Domain.IRepositories;
using DanyloSoft.PetFinder.Infrastructure.Data.Entities;
using DanyloSoft.PetFinder.Infrastructure.Data.Entities.Transformers;
using Microsoft.EntityFrameworkCore;

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

    public List<Pet> GetPets(Filter filter)
    {
      /* For now since the data aount is not large we can use 
        .Select(_tr.FromPetEntityGetPets);, but need to keep in mind
        that this way there might be taken too much info from the Db */
      
      var selectQuery = _ctx.PetTable
        .Select(_tr.FromPetEntityGetPets);

      if (filter.SearchQuery != null)
      {
        selectQuery.Where(p =>
          p.Name.ToLower().Contains(filter.SearchQuery.ToLower()));
      }

      if (filter.OrderDirection != null && filter.OrderBy != null)
      {
        if (filter.OrderDirection.ToLower().Equals("asc"))
        {
          switch (filter.OrderBy.ToLower())
          {
            case "name":
              selectQuery = selectQuery.OrderBy(p => p.Name);
              break;
            case "id":
              selectQuery = selectQuery.OrderBy(p => p.Id);
              break;
          }
        }
        else
        {
          switch (filter.OrderBy.ToLower())
          {
            case "name":
              selectQuery = selectQuery.OrderByDescending(p => p.Name);
              break;
            case "id":
              selectQuery = selectQuery.OrderByDescending(p => p.Id);
              break;
          }
        }
      }
      
      
      var query = selectQuery
        .Skip(filter.Count * (filter.Page - 1))
        .Take(filter.Count);

      return query.ToList();
    }

    public Pet GetPetById(int id)
    {
      
      // Lars' dope af code Passing the method into the select statement. 
      
      return _ctx.PetTable
        .Include(p => p.PetType)
        .Include(o => o.Owner)
        .Include(c => c.Color)
        .Select(_tr.FromPetEntity)
        .FirstOrDefault(p => p.Id == id);
      /*return _tr.FromPetEntity(_ctx.PetTable
        .Include(p => p.PetType)
        .Include(o => o.Owner)
        .Include(c => c.Color)
        .FirstOrDefault(c => c.Id == id));*/
    }

    public Pet CreatePet(Pet newPet)
    {
      var entity = _tr.ToPetEntity(newPet);
      var entitySaved =  _ctx.Add(entity).Entity;
      _ctx.SaveChanges();
      var entityFoundWithRelation = _ctx.PetTable
        .Include(p => p.PetType)
        .Include(r => r.Color)
        .Include(m => m.Owner)
        .FirstOrDefault(c => c.Id == entitySaved.Id);
      var createdPet = _tr.FromPetEntity(entityFoundWithRelation);
      return createdPet;
    }

    public Pet UpdatePet(Pet updatedPet)
    {
      var existingPet = GetPetByIdSpecial(updatedPet.Id);
      existingPet.Name = updatedPet.Name;
      existingPet.ColorId = updatedPet.Color.Id;
      existingPet.Price = updatedPet.Price;
      var updatedPetResult = _tr.FromPetEntitySimple(_ctx.Update(existingPet).Entity);
      _ctx.SaveChanges();
      return updatedPetResult;
    }

    public PetEntity GetPetByIdSpecial(int id)
    {
      return _ctx.PetTable
        .FirstOrDefault(c => c.Id == id);
    }
    
    public void DeletePet(int Id)
    {
      var pet = GetPetByIdSpecial(Id);
      _ctx.Remove(new PetEntity{Id = Id});
      _ctx.SaveChanges();
    }

    public int GetPetCount()
    {
      return _ctx.PetTable.Count();
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
          return GetPets(new Filter(){Count = 10});
      }
      return GetPets(new Filter(){Count = 10});
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