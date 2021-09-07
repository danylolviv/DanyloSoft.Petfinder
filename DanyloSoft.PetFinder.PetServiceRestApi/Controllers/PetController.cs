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
  [Route("[controller]")]
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
  }
}