using System.Collections.Generic;
using System.Linq;
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
        

        IEnumerable<Pet> GetAllPets();

        IEnumerable<Pet> GetOrderedListPets(int orderType);

        Pet UpdatePet(Pet newPet);
        void DeletePet(Pet petToDelete);
        
    }
}