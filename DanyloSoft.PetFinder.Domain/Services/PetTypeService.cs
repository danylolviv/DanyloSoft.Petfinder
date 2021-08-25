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
            throw new System.NotImplementedException();
        }

        public PetType CreatePetType(PetType newPetType)
        {
            throw new System.NotImplementedException();
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