using System.Collections.Generic;
using System.Linq;
using DanyloSoft.PetFinder.Core.IServices;
using DanyloSoft.PetFinder.Core.Models;
using DanyloSoft.PetFinder.Domain.IRepositories;

namespace DanyloSoft.PetFinder.Domain.Services
{
    public class PetService : IPetService
    {
        private IPetRepository _repo;

        public PetService(IPetRepository repo)
        {
            _repo = repo;
        }
        
        public Pet CreatePet(Pet newPet)
        {
           return _repo.CreatePet(newPet);
        }

        

        

        public IOrderedEnumerable<Pet> GetAllPets()
        {
           return _repo.GetPets();
        }

        public IOrderedEnumerable<Pet> GetOrderedListPets(int orderType)
        {
            switch (orderType)
            {
                case 1:
                    return SortLowestToHighest();
                case 2:
                    return SortHighestToLowest();
                case 3:
                    return List5Cheapest();
                case 4:
                    return GetAllPets();
            }
            return _repo.GetPets();
        }
        
        private IOrderedEnumerable<Pet> SortLowestToHighest()
        {
            var orderByResult = from pet in GetAllPets()
                orderby pet.Price //Sorts the studentList collection in ascending order
                select pet;
            return orderByResult;
        }

        private IOrderedEnumerable<Pet> SortHighestToLowest()
        {
            var orderByResult = from pet in GetAllPets()
                orderby pet.Price descending //Sorts the studentList collection in descending order
                select pet;
            return orderByResult;
        }
        
        private IOrderedEnumerable<Pet> List5Cheapest()
        {
            // var orderByResult = from pet in GetAllPets()
            //     orderby pet.Price //Sorts the studentList collection in ascending order
            //     select pet;
            // return orderByResult.Take(5);
            
            var orderByResult = from pet in GetAllPets()
                orderby pet.Price //Sorts the studentList collection in ascending order
                select pet;
            IEnumerable<Pet> first5 = orderByResult.Take(5);
            
            var orderByResult2 = from pet in first5
                orderby pet.Price //Sorts the studentList collection in ascending order
                select pet;
            return orderByResult2;
        }
        

        public Pet UpdatePet(Pet newPet)
        {
            return _repo.UpdatePet(newPet);
        }

        public void DeletePet(Pet petToDelete)
        {
            _repo.DeletePet(petToDelete);
        }
    }
}