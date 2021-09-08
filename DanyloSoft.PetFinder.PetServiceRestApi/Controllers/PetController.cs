using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DanyloSoft.PetFinder.Core.IServices;
using DanyloSoft.PetFinder.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DanyloSoft.PetFinder.PetServiceRestApi.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class PetController : ControllerBase
  {

    private readonly IPetService _petService;

    public PetController(IPetService petService)
    {
      _petService = petService;
    }

    [HttpGet]
    public IEnumerable<Pet> GetAllPets()
    {
      return _petService.GetAllPets();
    }
    
    [HttpGet("{id}")]
    public ActionResult<Pet> GetPetById(int id)
    {
      return _petService.GetPetById(id);
    }

    [HttpPost]
    public ActionResult<Pet> CreatePet([FromBody] Pet newPet)
    {
      if (string.IsNullOrEmpty(newPet.Name))
      {
        return BadRequest(" name is required for creating new pet");
      }
      return _petService.CreatePet(newPet);
    }

    [HttpPut("{id}")]
    public ActionResult<Pet> UpdatePet(int id, Pet updatedPet)
    {
      if (id < 1 || id != updatedPet.Id)
      {
        return BadRequest("Pet id and id mush match.");
      }
      return _petService.UpdatePet(updatedPet);
    }

    [HttpDelete("{id}")]
    public ActionResult<Pet> DeletePet(int id, Pet petToDelete)
    {
      if (id != petToDelete.Id)
      {
        return BadRequest(
          "Sorry the video could not be deleted because of lack of access, " +
          "try matching id in the url with the id of video you want to delete");
      }
      _petService.DeletePet(petToDelete);
      return Ok($"Successfully deleted video with id {id}");
    }
  }
}