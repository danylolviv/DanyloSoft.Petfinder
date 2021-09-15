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
      List<GetColorDto> listColors = new List<GetColorDto>();
      foreach (var color in _service.GetAllColors())
      {
        listColors.Add(_tr.GetColorTrans(color));
      }
      return listColors;
    }
    

    [HttpGet("{id}")]
    public GetColorDto GetColorById(int id)
    {
      return _tr.GetColorTrans(_service.GetColorById(id));
    }
    
    [HttpPost]
    public GetColorDto CreateColor(PostColorDto postColorDto)
    {
      return _tr.GetColorTrans(_service.CreateColor(postColorDto.Name));
    }

    [HttpPut("{id}")]
    public GetColorDto UpdateColor(PutColorDto putColorDto)
    {
      return _tr.GetColorTrans(_tr.PutColorTrans(putColorDto));
    }

    [HttpDelete("{id}")]
    public GetColorDto DeleteColor(DeleteColorDto deleteColorDto)
    {
      return _tr.GetColorTrans(_service.DeleteColor(deleteColorDto.id));
    }
  }
}