using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DanyloSoft.PetFinder.Core.IServices;
using DanyloSoft.PetFinder.Core.Models;
using DanyloSoft.PetFinder.PetServiceRestApi.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DanyloSoft.PetFinder.PetServiceRestApi.Controllers
{
  [ApiController]
  [Route("petFinderApi/[controller]")]
  public class PetController : ControllerBase
  {

    private readonly IPetService _petService;

    public PetController(IPetService petService)
    {
      _petService = petService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Pet>> GetAllPets()
    {
      var answer = _petService.GetAllPets();;
      if (answer != null)
      {
        return Ok(answer); 
      }
      return BadRequest("Something no workie.");
    }
    
    [HttpGet("{id}")]
    public ActionResult<Pet> GetPetById(int id)
    {
      var answer = _petService.GetPetById(id);
      if (answer != null)
      {
        return Ok(answer);
      }
      return BadRequest("Something no workie.");
    }

    [HttpGet("{id}")]
    public List<Pet> GetPetsByOwnerId(int ownerId)
    {
      return _petService.GetPetsByOwnerId(ownerId);
    }

    [HttpPost]
    public ActionResult<Pet> CreatePet([FromBody] PostPetDTO newPetDTO)
    {
      if (string.IsNullOrEmpty(newPetDTO.Name))
      {
        return BadRequest(" name is required for creating new pet");
      }

      Pet newPet = new Pet
      {
        Name = newPetDTO.Name,
        Color = newPetDTO.Color,
        Price = newPetDTO.Price,
        Birthday = newPetDTO.Birthday,
        PetType = new PetType{Id = newPetDTO.PetTypeId}
        
      };
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