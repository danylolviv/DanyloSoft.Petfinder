using System.Collections.Generic;
using DanyloSoft.PetFinder.Core.Models;
using DanyloSoft.PetFinder.Domain.IRepositories;

namespace DanyloSoft.PetFinder.Infrastructure.Database.Repositories
{
    public class PetTypeRepository : IPetTypeRepository
    {
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