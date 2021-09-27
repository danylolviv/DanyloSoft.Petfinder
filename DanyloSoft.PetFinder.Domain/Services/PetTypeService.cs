using System.Collections.Generic;
using DanyloSoft.PetFinder.Core.IServices;
using DanyloSoft.PetFinder.Core.Models;
using DanyloSoft.PetFinder.Domain.IRepositories;

namespace DanyloSoft.PetFinder.Domain.Services
{
    public class PetTypeService : IPetTypeService
    {

        public IPetTypeRepository _repo;

        public PetTypeService(IPetTypeRepository repo)
        {
            _repo = repo;
        }
        public List<PetType> GetListPetTypes()
        {
            return _repo.GetListPetTypes();
        }

        public PetType CreatePetType(string newPetType)
        {
            return _repo.CreatePetType(newPetType);
        }

        public PetType RemovePetType(PetType petTypeToRemove)
        {
            return _repo.RemovePetType(petTypeToRemove);
        }

        public PetType EditPetType(PetType petTypeToRemove)
        {
            return _repo.EditPetType(petTypeToRemove);
        }

        public IEnumerable<PetType> GetByQuery(string query)
        {
            return _repo.GetByQuery(query);
        }

        public List<Pet> GGetPetsByPetType(int petTypeId)
        {
            return _repo.GetPetsByPetType(petTypeId);
        }
    }
}