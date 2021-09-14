using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DanyloSoft.PetFinder.Core.IServices;
using DanyloSoft.PetFinder.Core.Models;
using DanyloSoft.PetFinder.PetServiceRestApi.Dto.Owners;
using DanyloSoft.PetFinder.PetServiceRestApi.Dto.Transformers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DanyloSoft.PetFinder.PetServiceRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private Transformer _transformer;
        private readonly IOwnerService _ownerService;

        public OwnerController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
            _transformer = new Transformer();
        }

        [HttpGet]
        public IEnumerable<Owner> GetAllOwners()
        {
            return _ownerService.getAllOwners();
        }

        [HttpGet("{id}")]
        public ActionResult<Owner> GetOwnerById(int id)
        {
            return _ownerService.GetById(id);
        }
        
        [HttpPost]
        public ActionResult<Owner> CreateOwner([FromBody] PostOwnerDto newOwnerDto)
        {
            if (string.IsNullOrEmpty(newOwnerDto.Name))
            {
                return BadRequest(" name is required for creating new pet");
            }
            return _ownerService.CreateOwner(_transformer.PostOwnerTrans(newOwnerDto));
        }
        
        [HttpPut("{id}")]
        public ActionResult<Owner> UpdateOwner(int id, PutOwnerDto putOwnerDto)
        {
            if (id < 1 || id != putOwnerDto.Id)
            {
                return BadRequest("Pet id and id mush match.");
            }
            return _ownerService.UpdateOwner(_transformer.PutOwnerTrans(putOwnerDto, _ownerService.GetById(id)));
        }

        [HttpDelete("{id}")]
        public ActionResult<Pet> DeleteOwner(int id, Pet ownerToDelete)
        {
            if (id != ownerToDelete.Id)
            {
                return BadRequest(
                    "Sorry owner could not be deleted because of lack of access, " +
                    "try matching id in the url with the id of video you want to delete");
            }
            _ownerService.DeleteOwner(ownerToDelete.Id);
            return Ok($"Successfully deleted owner with id {id}");
        }
        
    }
}