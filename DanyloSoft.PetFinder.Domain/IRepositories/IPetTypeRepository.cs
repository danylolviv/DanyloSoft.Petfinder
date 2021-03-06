using System.Collections.Generic;
using DanyloSoft.PetFinder.Core.Models;

namespace DanyloSoft.PetFinder.Domain.IRepositories
{
    public interface IPetTypeRepository
    {
        List<PetType> GetListPetTypes();
        PetType GetById(int id);
        PetType CreatePetType(string newPetType);
        PetType RemovePetType(PetType petTypeToRemove);
        PetType EditPetType(PetType petTypeToEdit);
        IEnumerable<PetType> GetByQuery(string query);
        List<Pet> GetPetsByPetType(int petTypeId);
    }
}