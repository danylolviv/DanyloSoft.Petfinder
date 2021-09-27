using System.Collections.Generic;
using DanyloSoft.PetFinder.Core.IServices;
using DanyloSoft.PetFinder.Core.Models;
using DanyloSoft.PetFinder.PetServiceRestApi.Dto;
using DanyloSoft.PetFinder.PetServiceRestApi.Dto.Transformers;
using Microsoft.AspNetCore.Mvc;

namespace DanyloSoft.PetFinder.PetServiceRestApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ColorCOntroller : ControllerBase
  {
    
    
    private readonly IColorService _service;
    private readonly ColorTransformer _tr;

    
    
    public ColorCOntroller(IColorService colorService)
    {
      _service = colorService;
      _tr = new ColorTransformer();
    }
    
    
    
    [HttpGet]
    public List<GetColorDto> GetAllColors()
    {
      var listColors = new List<GetColorDto>();
      foreach (var color in _service.GetAllColors())
      {
        listColors.Add(_tr.GetColorTrans(color));
      }
      return listColors;
    }
    

    // [HttpGet("{id}")]
    // public GetColorDto GetColorById(int id)
    // {
    //   return _tr.GetColorTrans(_service.GetColorById(id));
    // }
    
    [HttpGet("{id}")]
    public List<GetPetsByColorDto> GetPetsByColorId(int id)
    {
      var listPetColorSearchDto = new List<GetPetsByColorDto>();
      var listPets = _service.GetPetsByColorId(id);
      foreach (var pet in listPets)
      {
        listPetColorSearchDto.Add(_tr.GetPetsByColor(pet));
      }
      return listPetColorSearchDto;
    }
    
    [HttpPost]
    public GetColorDto CreateColor(PostColorDto postColorDto)
    {
      return _tr.GetColorTrans(_service.CreateColor(postColorDto.Name));
    }

    [HttpPut("{id}")]
    public GetColorDto UpdateColor(PutColorDto putColorDto)
    {
      return _tr.GetColorTrans(_service.UpdateColor(_tr.PutColorTrans(putColorDto)));
    }

    [HttpDelete("{id}")]
    public ActionResult<GetColorDto> DeleteColor(DeleteColorDto deleteColorDto, int id)
    {
      if (id == deleteColorDto.id)
      {
        return _tr.GetColorTrans(_service.DeleteColor(deleteColorDto.id));  
      }
      return BadRequest("No good");
    }
  }
}