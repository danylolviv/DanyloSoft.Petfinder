using System.Collections.Generic;
using DanyloSoft.PetFinder.Core.Models;

namespace DanyloSoft.PetFinder.Domain.IRepositories
{
  public interface IColorRepository
  {
    IEnumerable<Color> GetAllColors();
    Color GetColorById(int id);
    Color CreateColor(string colorName);
    Color DeleteColor(int id);
    Color UpdateColor(Color updatedColor);
    List<Pet> GetPetsByColorId(int id);
  }
}