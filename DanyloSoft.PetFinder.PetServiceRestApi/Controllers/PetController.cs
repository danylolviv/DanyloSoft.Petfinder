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
    private PetTransformer _tr;
    private readonly IPetService _petService;

    public PetController(IPetService petService)
    {
      _petService = petService;
      _tr = new PetTransformer();
    }

    [HttpGet]
    public ActionResult<List<GetPetDto_Simple>> GetAllPets()
    {
      var listPets = new List<GetPetDto_Simple>();
      foreach (var pet in _petService.GetAllPets())
      {
        listPets.Add(_tr.GetPetSimple(pet));
      }
      if (listPets != null)
      {
        return Ok(listPets); 
      }
      return BadRequest("Something no workie or most likely no pets in repo");
    }
    
    [HttpGet("{id}")]
    public ActionResult<GetPetDto> GetPetById(int id)
    {
      var answer = _tr.GetPet(_petService.GetPetById(id));
      if (answer != null )
      {
        return Ok(answer);
      }
      return BadRequest("Something no workie or most likely no pet with id in repo");
    }

    [HttpPost]
    public ActionResult<GetPetDto> CreatePet([FromBody] PostPetDTO newPetDto)
    {
      if (string.IsNullOrEmpty(newPetDto.Name))
      {
        return BadRequest(" name is required for creating new pet");
      }
      return Ok(_tr.GetPet(_petService.CreatePet(_tr.PostPetTrans(newPetDto))));
    }

    [HttpPut("{id}")]
    public ActionResult<GetPetDto> UpdatePet(int id, PutPetDTO updatedPetDto)
    {
      if (id < 1 || id != updatedPetDto.Id)
      {
        return BadRequest("Pet id and id mush match.");
      }
      
      return _tr.GetPet(_petService.UpdatePet(_tr.PutPetTrans(
        updatedPetDto, _petService.GetPetById(id))));
    }

    [HttpDelete("{id}")]
    public ActionResult<Pet> DeletePet(int id, DeletePetDto deletePetDto)
    {
      if (id != deletePetDto.Id)
      {
        return BadRequest(
          "Sorry the video could not be deleted because of lack of access, " +
          "try matching id in the url with the id of video you want to delete");
      }
      return Ok(_tr.GetPet(_petService.DeletePet(id)));
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