using System.Collections.Generic;
using DanyloSoft.PetFinder.Core.IServices;
using DanyloSoft.PetFinder.Core.Models;
using DanyloSoft.PetFinder.Domain.IRepositories;

namespace DanyloSoft.PetFinder.Domain.Services
{
  public class ColorService : IColorService
  {
    private readonly IColorRepository _repo;
    public ColorService(IColorRepository repo)
    {
      _repo = repo;
    }
    
    public IEnumerable<Color> GetAllColors()
    {
      return _repo.GetAllColors();
    }

    public Color GetColorById(int id)
    {
      return _repo.GetColorById(id);
    }

    public Color CreateColor(string colorName)
    {
      return _repo.CreateColor(colorName);
    }

    public Color DeleteColor(int id)
    {
      return _repo.DeleteColor(id);
    }

    public Color UpdateColor(Color updatedColor)
    {
      return _repo.UpdateColor(updatedColor);
    }

    public List<Pet> GetPetsByColorId(int id)
    {
      return _repo.GetPetsByColorId(id);
    }
  }
}