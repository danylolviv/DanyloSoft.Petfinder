using System.Collections.Generic;
using System.Linq;
using DanyloSoft.PetFinder.Core.IServices;
using DanyloSoft.PetFinder.Core.Models;
using DanyloSoft.PetFinder.Domain.IRepositories;

namespace DanyloSoft.PetFinder.Domain.Services
{
    public class PetService : IPetService
    {
        private readonly IPetRepository _repo;
        private readonly IOwnerRepository _owneRepo;

        public PetService(IPetRepository repo, IOwnerRepository ownerRepository)
        {
            _repo = repo;
            _owneRepo = ownerRepository;
        }
        
        public Pet CreatePet(Pet newPet)
        {
           return _repo.CreatePet(newPet);
        }

        

        

        public IEnumerable<Pet> GetAllPets()
        {
           return _repo.GetPets();
        }

        public Pet GetPetById(int id)
        {
            return _repo.GetPetById(id);
        }

        public IEnumerable<Pet> GetOrderedListPets(int orderType)
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
        
        private IEnumerable<Pet> List5Cheapest()
        {
            var orderByResult = from pet in GetAllPets()
                orderby pet.Price //Sorts the studentList collection in ascending order
                select pet;
            return orderByResult.Take(5).OrderBy(pet => pet);
            
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
        

        public Pet UpdatePet(Pet newPet)
        {
            return _repo.UpdatePet(newPet);
        }

        public Pet DeletePet(int id)
        {
            var delPet = GetPetById(id);
            _repo.DeletePet(id);
            return delPet;
        }

        public List<Pet> GetPetsByOwnerId(int ownerId)
        {
            var owner = _owneRepo.GetById(ownerId);
            return owner.OwnersPets;
        }
    }
}