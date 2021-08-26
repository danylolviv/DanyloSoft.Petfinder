using System;
using System.Collections.Generic;
using DanyloSoft.PetFinder.Core.Models;
using DanyloSoft.PetFinder.Domain.IRepositories;

namespace DanyloSoft.PetFinder.Infrastructure.Database.Repositories
{
    public class PetRepository : IPetRepository
    {
        private static List<Pet> _listPets = new List<Pet>();
        private static int _runningId = 1;

        public PetRepository()
        {
            PopulateRepo();
        }
        
        public Pet CreatePet(Pet newPet)
        {
            newPet.Id = _runningId++;
            _listPets.Add(newPet);
            return newPet;
        }

        public List<Pet> GetPets()
        {
            return _listPets;
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
            _listPets.Remove(petToDelete);
        }
        
        //Filling fake db
        private void PopulateRepo()
        {
            CreatePet(new Pet
            {
                Birthday = DateTime.Now, Color = "Brown", Name = "Zoozie",
                PetType = new PetType {Id = 1, Name = "Dog"},
                SellOutDate = DateTime.Today, Price = 39.90
            });
            CreatePet(new Pet
            {
                Birthday = DateTime.Now, Color = "Pink", Name = "Many",
                PetType = new PetType {Id = 2, Name = "Cat"},
                SellOutDate = DateTime.Today, Price = 39.90
            });
            CreatePet(new Pet
            {
                Birthday = DateTime.Now, Color = "Orange", Name = "Bob",
                PetType = new PetType {Id = 2, Name = "Cat"},
                SellOutDate = DateTime.Today, Price = 39.90
            });
        }
    }
}