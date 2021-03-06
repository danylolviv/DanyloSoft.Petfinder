using System;
using System.Collections.Generic;
using System.Linq;
using DanyloSoft.PetFinder.Core.Models;
using DanyloSoft.PetFinder.Domain.IRepositories;

namespace DanyloSoft.PetFinder.Infrastructure.Database.Repositories
{
    public class PetRepository : IPetRepository
    {
        private static IList<Pet> _listPets = new List<Pet>();
        private static int _runningId = 1;

        public PetRepository()
        {
            if (_listPets.Count <= 0)
            {
                PopulateRepo();
            }
            
        }
        
        public Pet CreatePet(Pet newPet)
        {
            newPet.Id = _runningId++;
            _listPets.Add(newPet);
            return newPet;
        }

        public IOrderedEnumerable<Pet> GetPets()
        {
            var listPets = from pet in _listPets
                orderby pet.Id
                select pet;
            return listPets;
        }

        public IEnumerable<Pet> GetOrderedListPets(int searchQuery)
        {
            throw new NotImplementedException();
        }

        public IOrderedEnumerable<Pet> GetOrderedListPets(string searchQuery)
        {
            throw new NotImplementedException();
        }

        public Pet GetPetById(int id)
        {
            foreach (var pet in _listPets)
            {
                if (id == pet.Id)
                {
                    return pet;
                }
            }
            return null;
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
            var petToUpdate = FindById(newPet.Id);
            if (petToUpdate != null)
            {
                petToUpdate.Name = newPet.Name;
                petToUpdate.Birthday = newPet.Birthday;
                petToUpdate.SellOutDate = newPet.SellOutDate;
                petToUpdate.Color = newPet.Color;
                petToUpdate.Price = newPet.Price;
                petToUpdate.PetType = newPet.PetType;
                return petToUpdate;
            }

            return petToUpdate;
        }

        public void DeletePet(int id)
        {
            var foundPetToDel = FindById(id);
            if (foundPetToDel != null)
            {
                _listPets.Remove(foundPetToDel);   
            }
        }

        public Pet FindById(int id)
        {
            foreach (var video in _listPets)
                if (video.Id == id)
                    return video;
            return null;
        }
        
        //Filling fake db
        private void PopulateRepo()
        {
            CreatePet(new Pet
            {
                Birthday = DateTime.Now, Color = "Brown", Name = "Zoozie",
                PetType = new PetType {Id = 1, Name = "Dog"},
                SellOutDate = DateTime.Today, Price = 100.90
            });
            CreatePet(new Pet
            {
                Birthday = DateTime.Now, Color = "Pink", Name = "Many",
                PetType = new PetType {Id = 2, Name = "Cat"},
                SellOutDate = DateTime.Today, Price = 27.90
            });
            CreatePet(new Pet
            {
                Birthday = DateTime.Now, Color = "Orange", Name = "Bob",
                PetType = new PetType {Id = 2, Name = "Cat"},
                SellOutDate = DateTime.Today, Price = 39.90
            });
            CreatePet(new Pet
            {
                Birthday = DateTime.Now, Color = "Brown", Name = "Zoozie",
                PetType = new PetType {Id = 1, Name = "Dog"},
                SellOutDate = DateTime.Today, Price = 45.90
            });
            CreatePet(new Pet
            {
                Birthday = DateTime.Now, Color = "Pink", Name = "Many",
                PetType = new PetType {Id = 2, Name = "Cat"},
                SellOutDate = DateTime.Today, Price = 60.90
            });
            CreatePet(new Pet
            {
                Birthday = DateTime.Now, Color = "Orange", Name = "Bob",
                PetType = new PetType {Id = 2, Name = "Cat"},
                SellOutDate = DateTime.Today, Price = 200.90
            });
            CreatePet(new Pet
            {
                Birthday = DateTime.Now, Color = "Pink", Name = "Many",
                PetType = new PetType {Id = 2, Name = "Cat"},
                SellOutDate = DateTime.Today, Price = 214.90
            });
            CreatePet(new Pet
            {
                Birthday = DateTime.Now, Color = "Orange", Name = "Bob",
                PetType = new PetType {Id = 2, Name = "Cat"},
                SellOutDate = DateTime.Today, Price = 1050.90
            });
            CreatePet(new Pet
            {
                Birthday = DateTime.Now, Color = "Brown", Name = "Zoozie",
                PetType = new PetType {Id = 1, Name = "Dog"},
                SellOutDate = DateTime.Today, Price = 18.90
            });
            CreatePet(new Pet
            {
                Birthday = DateTime.Now, Color = "Pink", Name = "Many",
                PetType = new PetType {Id = 2, Name = "Cat"},
                SellOutDate = DateTime.Today, Price = 33.90
            });
            CreatePet(new Pet
            {
                Birthday = DateTime.Now, Color = "Orange", Name = "Bob",
                PetType = new PetType {Id = 2, Name = "Cat"},
                SellOutDate = DateTime.Today, Price = 54.90
            });
        }
    }
}