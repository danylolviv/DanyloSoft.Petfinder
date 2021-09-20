using System.Collections.Generic;
using DanyloSoft.PetFinder.Core.IServices;
using DanyloSoft.PetFinder.PetServiceRestApi.Dto.Owners;
using Microsoft.AspNetCore.Mvc;

namespace DanyloSoft.PetFinder.PetServiceRestApi.Controllers

{
  [Route("api/[controller]")]
  [ApiController]
  public class OwnerController : ControllerBase
  {
    private OwnerTransformer _tr;
    private readonly IOwnerService _ownerService;


    public OwnerController(IOwnerService ownerService)
    {
      _ownerService = ownerService;
      _tr = new OwnerTransformer();
    }


    [HttpGet]
    public List<GetOwnerDto> GetAllOwners()
    {
      var listOwners = new List<GetOwnerDto>();
      foreach (var owner in _ownerService.getAllOwners())
      {
        listOwners.Add(_tr.GetOwner(owner));
      }

      return listOwners;
    }

    [HttpGet("{id}")]
    public ActionResult<GetOwnerDto> GetOwnerById(int id)
    {
      return _tr.GetOwner(_ownerService.GetById(id));
    }

    [HttpPost]
    public ActionResult<GetOwnerDto> CreateOwner(
      [FromBody] PostOwnerDto newOwnerDto)
    {
      if (string.IsNullOrEmpty(newOwnerDto.Name))
      {
        return BadRequest(" name is required for creating new pet");
      }

      return _tr.GetOwner(
        _ownerService.CreateOwner(_tr.PostOwnerTrans(newOwnerDto)));
    }

    [HttpPut("{id}")]
    public ActionResult<GetOwnerDto> UpdateOwner(int id, PutOwnerDto putOwnerDto)
    {
      if (id < 1 || id != putOwnerDto.Id)
      {
        return BadRequest("Pet id and id mush match.");
      }

      return _tr.GetOwner(_ownerService.UpdateOwner(_tr.PutOwnerTrans(putOwnerDto,
        _ownerService.GetById(id))));
    }

    [HttpDelete("{id}")]
    public ActionResult<GetOwnerDto> DeleteOwner(int id, DeleteOwnerDto ownerToDelete)
    {
      if (id != ownerToDelete.id)
      {
        return BadRequest(
          "Sorry owner could not be deleted because of lack of access, " +
          "try matching id in the url with the id of video you want to delete");
      }

      return Ok(_tr.GetOwner(_ownerService.DeleteOwner(ownerToDelete.id))) ;
    }
  }
}

