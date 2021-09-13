using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DanyloSoft.PetFinder.Core.IServices;
using DanyloSoft.PetFinder.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DanyloSoft.PetFinder.PetServiceRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerService _ownerService;

        public OwnerController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        [HttpGet]
        public List<Owner> GetAllOwners()
        {
            return _ownerService.getAllOwners();
        }

        [HttpGet("{id}")]
        public ActionResult<Owner> GetWnerById(int id)
        {
            return _ownerService.GetById(id);
        }
        
        [HttpPost]
        public ActionResult<Owner> CreatePet([FromBody] Owner newOwner)
        {
            if (string.IsNullOrEmpty(newOwner.Name))
            {
                return BadRequest(" name is required for creating new pet");
            }

            Owner newOwner1 = new Owner
            {
                Name = newOwner.Name,
                Age = newOwner.Age,
                Address = newOwner.Address
        
            };
            return _ownerService.CreateOwner(newOwner1);
        }
        
        [HttpPut("{id}")]
        public ActionResult<Owner> UpdateOwner(int id, Owner updatedOwner)
        {
            if (id < 1 || id != updatedOwner.Id)
            {
                return BadRequest("Pet id and id mush match.");
            }
            return _ownerService.UpdateOwner(updatedOwner);
        }

        [HttpDelete("{id}")]
        public ActionResult<Pet> DeletePet(int id, Pet ownerToDelete)
        {
            if (id != ownerToDelete.Id)
            {
                return BadRequest(
                    "Sorry the video could not be deleted because of lack of access, " +
                    "try matching id in the url with the id of video you want to delete");
            }
            _ownerService.DeleteOwner(ownerToDelete.Id);
            return Ok($"Successfully deleted video with id {id}");
        }
        
    }
}