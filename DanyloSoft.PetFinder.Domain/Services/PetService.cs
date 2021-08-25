using System.Collections.Generic;
using DanyloSoft.PetFinder.Core.IServices;
using DanyloSoft.PetFinder.Core.Models;

namespace DanyloSoft.PetFinder.Domain.Services
{
    public class PetService : IPetService
    {
        public Pet CreatePet(Pet newPet)
        {
            throw new System.NotImplementedException();
        }

        public List<Pet> GetPets()
        {
            throw new System.NotImplementedException();
        }

        public List<Pet> Get5Cheapest()
        {
            throw new System.NotImplementedException();
        }

        public List<Pet> GetPetsCheapestFirst()
        {
            throw new System.NotImplementedException();
        }

        public Pet UpdatePet(Pet oldPet)
        {
            throw new System.NotImplementedException();
        }

        public void DeletePet(Pet petToDelete)
        {
            throw new System.NotImplementedException();
        }
    }
}