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
        
    }
}