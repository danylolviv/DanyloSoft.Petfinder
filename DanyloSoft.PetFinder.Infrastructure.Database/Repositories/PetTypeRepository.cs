using System.Collections.Generic;
using DanyloSoft.PetFinder.Core.Models;
using DanyloSoft.PetFinder.Domain.IRepositories;

namespace DanyloSoft.PetFinder.Infrastructure.Database.Repositories
{
    public class PetTypeRepository : IPetTypeRepository
    {
        public PetTypeRepository()
        {
            //Adding Items to the list
            CreatePetType(new PetType {Name = "Dog"});
            CreatePetType(new PetType {Name = "Cat"});
            CreatePetType(new PetType {Name = "Hamster"});
            CreatePetType(new PetType {Name = "Guinea Pig"});
        }
        private List<PetType> _listOfPetTypes = new List<PetType>();
        private int _runningId = 1;
        public List<PetType> GetListPetTypes()
        {
            return _listOfPetTypes;
        }

        public PetType CreatePetType(PetType newPetType)
        {
            newPetType.Id = _runningId++;
            _listOfPetTypes.Add(newPetType);
            return newPetType;
        }

        public IEnumerable<PetType> GetByQuery(string query)
        {
            List<PetType> searchRes = new List<PetType>();
            foreach (var petType in _listOfPetTypes)
            {
                if (petType.Name.ToLower().Contains(query))
                {
                    searchRes.Add(petType);
                }
            }
            return searchRes;
        }

        public PetType RemovePetType(PetType petTypeToRemove)
        {
            throw new System.NotImplementedException();
        }

        public PetType EditPetType(PetType petTypeToEdit)
        {
            throw new System.NotImplementedException();
        }
    }
}