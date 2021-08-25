using System.Collections.Generic;
using DanyloSoft.PetFinder.Core.Models;

namespace DanyloSoft.PetFinder.Core.IServices
{
    public interface IPetTypeService
    {
        List<PetType> GetListPetTypes();

        PetType CreatePetType(PetType newPetType);
        PetType RemovePetType(PetType petTypeToRemove);
        PetType EditPetType(PetType petTypeToEdit);
    }
}