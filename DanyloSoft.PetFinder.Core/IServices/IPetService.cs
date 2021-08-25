using System.Collections.Generic;
using DanyloSoft.PetFinder.Core.Models;

namespace DanyloSoft.PetFinder.Core.IServices
{
    public interface IPetService
    {
        Pet CreatePet(Pet newPet);
        ///    <summary>
        ///    This should be ideally taken out into a different filtering class.
        ///    But for now this will be here knowing this.  
        /// </summary>
        List<Pet> GetPets();
        List<Pet> Get5Cheapest();
        List<Pet> GetPetsCheapestFirst();

        Pet UpdatePet(Pet oldPet);
        void DeletePet(Pet petToDelete);
        
    }
}