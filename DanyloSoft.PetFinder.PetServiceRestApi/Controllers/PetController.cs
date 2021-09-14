using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DanyloSoft.PetFinder.Core.IServices;
using DanyloSoft.PetFinder.Core.Models;
using DanyloSoft.PetFinder.PetServiceRestApi.Dto;
using DanyloSoft.PetFinder.PetServiceRestApi.Dto.Transformers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DanyloSoft.PetFinder.PetServiceRestApi.Controllers
{
  [ApiController]
  [Route("petFinderApi/[controller]")]
  public class PetController : ControllerBase
  {
    private Transformer _transformer;
    private readonly IPetService _petService;

    public PetController(IPetService petService)
    {
      _petService = petService;
      _transformer = new Transformer();
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

    // [HttpGet("{id}")]
    // public List<Pet> GetPetsByOwnerId(int ownerId)
    // {
    //   return _petService.GetPetsByOwnerId(ownerId);
    // }

    [HttpPost]
    public ActionResult<Pet> CreatePet([FromBody] PostPetDTO newPetDTO)
    {
      if (string.IsNullOrEmpty(newPetDTO.Name))
      {
        return BadRequest(" name is required for creating new pet");
      }
      return _petService.CreatePet(_transformer.PostPetTrans(newPetDTO));
    }

    [HttpPut("{id}")]
    public ActionResult<Pet> UpdatePet(int id, PutPetDTO updatedPetDto)
    {
      if (id < 1 || id != updatedPetDto.Id)
      {
        return BadRequest("Pet id and id mush match.");
      }
      
      return _petService.UpdatePet(_transformer.PutPetTrans(updatedPetDto, _petService.GetPetById(id)));
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
      _petService.DeletePet(id);
      return Ok($"Successfully deleted video with id {id}");
      
    }
    
    //WHY WHY WHY!!!!!??????
    
    // [HttpDelete("{id}")]
    // public ActionResult<Pet> DeletePet(int id, Pet petToDelete)
    // {
    //   if (id != petToDelete.Id)
    //   {
    //     return BadRequest(
    //       "Sorry the video could not be deleted because of lack of access, " +
    //       "try matching id in the url with the id of video you want to delete");
    //   }
    //   _petService.DeletePet(petToDelete);
    //   return Ok($"Successfully deleted video with id {id}");
    // }
  }
}