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
            foreach (var pet in list)
            {
                GetForeignData(pet);
            }
           return list;
        }

        public Pet GetPetById(int id)
        {
            return _repo.GetPetById(id);
        }

        public Pet CreatePet(Pet newPet)
        {
            // PetType petType = _petTypeRepo.GetById(newPet.PetType.Id);
            // newPet.PetType = petType;
            return GetForeignData(_repo.CreatePet(newPet));
        }

        public Pet GetForeignData(Pet pet)
        {
            pet.PetType = _petTypeRepo.GetById(pet.PetType.Id);
            pet.Owner = _owneRepo.GetById(pet.Owner.Id);
            pet.Color = _colorRepo.GetColorById(pet.Color.Id);
            return pet;
        }

        public Pet UpdatePet(Pet newPet)
        {
            return GetForeignData(_repo.UpdatePet(newPet));
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