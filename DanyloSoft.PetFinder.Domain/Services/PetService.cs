using System.Collections.Generic;
using System.Linq;
using DanyloSoft.PetFinder.Core.IServices;
using DanyloSoft.PetFinder.Core.Models;
using DanyloSoft.PetFinder.Domain.IRepositories;

namespace DanyloSoft.PetFinder.Domain.Services
{
    public class PetService : IPetService
    {
        private readonly IPetRepository _repo;
        private readonly IOwnerRepository _owneRepo;
        private readonly IPetTypeRepository _petTypeRepo;
        private readonly IColorRepository _colorRepo;


        public PetService(IPetRepository repo, IOwnerRepository ownerRepository, IPetTypeRepository petTypeRepository, IColorRepository colorRepository)
        {
            _repo = repo;
            _owneRepo = ownerRepository;
            _petTypeRepo = petTypeRepository;
            _colorRepo = colorRepository;
        }


        public IEnumerable<Pet> GetAllPets()
        {
            IEnumerable<Pet> list = _repo.GetPets();
            return list;
        }

        public Pet GetPetById(int id)
        {
            var pet = _repo.GetPetById(id);
            return pet;
        }

        public Pet CreatePet(Pet newPet)
        {
            // PetType petType = _petTypeRepo.GetById(newPet.PetType.Id);
            // newPet.PetType = petType;
            return _repo.CreatePet(newPet);
        }

        

        public Pet UpdatePet(Pet newPet)
        {
            return _repo.UpdatePet(newPet);
        }

        public IEnumerable<Pet> GetOrderedListPets(int orderType)
        {
            return GetOrderedListPets(orderType);
        }
        
        public Pet DeletePet(int id)
        {
            var delPet = GetPetById(id);
            _repo.DeletePet(id);
            return delPet;
        }

        public List<Pet> GetPetsByOwnerId(int ownerId)
        {
            var owner = _owneRepo.GetById(ownerId);
            return owner.OwnersPets;
        }
    }
}