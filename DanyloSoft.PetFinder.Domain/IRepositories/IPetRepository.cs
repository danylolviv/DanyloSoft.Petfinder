using System.Collections.Generic;
using System.Linq;
using DanyloSoft.PetFinder.Core.Models;

namespace DanyloSoft.PetFinder.Domain.IRepositories
{
    public interface IPetRepository
    {
        Pet CreatePet(Pet newPet);
        ///    <summary>
        ///    This should be ideally taken out into a different filtering class.
        ///    But for now this will be here knowing this.  
        /// </summary>
        IOrderedEnumerable<Pet> GetPets();

        Pet GetPetById(int id);
        List<Pet> Get5Cheapest();
        List<Pet> GetPetsCheapestFirst();

        Pet UpdatePet(Pet oldPet);
        void DeletePet(int Id);    
    }
}