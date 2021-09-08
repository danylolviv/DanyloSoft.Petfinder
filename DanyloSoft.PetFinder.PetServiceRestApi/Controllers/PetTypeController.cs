using System.Collections.Generic;
using DanyloSoft.PetFinder.Core.IServices;
using DanyloSoft.PetFinder.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace DanyloSoft.PetFinder.PetServiceRestApi.Controllers
{
  [ApiController]
  [Route("petFinderApi/[controller]")]
  public class PetTypeController : ControllerBase
  {
    private readonly IPetTypeService _petTypeService;
    
    public PetTypeController(IPetTypeService petTypeService)
    {
      _petTypeService = petTypeService;
    }

    [HttpGet]
    public IEnumerable<PetType> GetAllPetTypes()
    {
      return _petTypeService.GetListPetTypes();
    }

    [HttpGet("{query}")]
    public IEnumerable<PetType> GetPetTypesQuery(string query)
    {
      return _petTypeService.GetByQuery(query);
    }
  }
}