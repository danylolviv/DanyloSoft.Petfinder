using System.Collections.Generic;
using DanyloSoft.PetFinder.Core.Models;

namespace DanyloSoft.PetFinder.Core.IServices
{
    public interface IPetTypeService
    {
        List<PetType> GetListPetTypes();

        PetType CreatePetType(string newPetTypeName);
        PetType RemovePetType(PetType petTypeToRemove);
        PetType EditPetType(PetType petTypeToEdit);
        IEnumerable<PetType> GetByQuery(string query);
    }
}