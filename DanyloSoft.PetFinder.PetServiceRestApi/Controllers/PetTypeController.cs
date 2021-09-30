using System;
using System.Collections.Generic;
using System.Linq;
using DanyloSoft.PetFinder.Core.IServices;
using DanyloSoft.PetFinder.Core.Models;
using DanyloSoft.PetFinder.PetServiceRestApi.Dto.PetTypes;
using Microsoft.AspNetCore.Mvc;

namespace DanyloSoft.PetFinder.PetServiceRestApi.Controllers
{
  [ApiController]
  [Route("petFinderApi/[controller]")]
  public class PetTypeController : ControllerBase
  {
    private readonly IPetTypeService _petTypeService;
    private readonly PetTypeTransformer _tr;


    public PetTypeController(IPetTypeService petTypeService)
    {
      _petTypeService = petTypeService;
      _tr = new PetTypeTransformer();
    }

    [HttpGet]
    public ActionResult<GetAllPetTypesDto> GetAllPetTypes()
    {
      try
      {
        return Ok(new GetAllPetTypesDto()
        {
          PetTypes = _petTypeService.GetListPetTypes()
            .Select(pT => _tr.GetPetType(pT)).ToList()
        });
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        throw;
      }
    }

    // [HttpGet("{query}")]
    // public ActionResult<List<GetPetTypeDto>> GetPetTypesQuery(string query)
    // {
    //   var listPetTypes = new List<GetPetTypeDto>();
    //   foreach (var petType in _petTypeService.GetByQuery(query))
    //   {
    //     listPetTypes.Add(_tr.GetPetType(petType));
    //   }
    //   return Ok(listPetTypes);
    // }

    [HttpGet("{id}")]
    public ActionResult<List<GetPetsByPetTypeDto>> GetPetsByPetType(int id)
    {
      var listDTOs = new List<GetPetsByPetTypeDto>();
      foreach (var pet in _petTypeService.GGetPetsByPetType(id))
      {
        listDTOs.Add(_tr.GetPetsByPetType(pet));
      }
      return listDTOs;
    }

    [HttpPost]
    public ActionResult<GetPetTypeDto> CreatePetType(PostPetTypeDto postPetTypeDto)
    {
      return _tr.GetPetType(_petTypeService.CreatePetType(postPetTypeDto.Name));
    }

    [HttpPut("{id}")]
    public ActionResult<GetPetTypeDto> UpdatePet(PutPetTypeDto putPetTypeDto)
    {
      var upPet = _petTypeService.EditPetType(_tr.PutPetType(putPetTypeDto));
      return Ok(_tr.GetPetType(upPet));
    }

    [HttpDelete("{id}")]
    public ActionResult<GetPetTypeDto> DeletePetType(int id,
      DeletePetTypeDto deletePetTypeDto)
    {
      return _tr.GetPetType(_petTypeService.RemovePetType(_tr.DeletePetType(deletePetTypeDto)));
    }
  }
}