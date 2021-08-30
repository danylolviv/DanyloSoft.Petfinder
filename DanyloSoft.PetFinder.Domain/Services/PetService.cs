using System.Collections.Generic;
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

        public List<Pet> GetPets()
        {
            return _repo.GetPets();
        }

        public List<Pet> Get5Cheapest()
        {
            throw new System.NotImplementedException();
        }

        public List<Pet> GetPetsCheapestFirst()
        {
            throw new System.NotImplementedException();
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