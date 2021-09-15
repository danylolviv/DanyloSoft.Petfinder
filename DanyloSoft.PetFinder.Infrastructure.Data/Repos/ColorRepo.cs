using System.Collections.Generic;
using DanyloSoft.PetFinder.Core.Models;
using DanyloSoft.PetFinder.Domain.IRepositories;

namespace DanyloSoft.PetFinder.Infrastructure.Data.Repos
{
  public class ColorRepo : IColorRepository
  {
    private readonly PetFinderAppContext _ctx;
    public ColorRepo(PetFinderAppContext ctx)
    {
      _ctx = ctx;
    }
    public IEnumerable<Color> GetAllColors()
    {
      return _ctx.ColorTable;
    }

    public Color GetColorById(int id)
    {
      return _ctx.ColorTable.Find(id);
    }

    public Color CreateColor(string colorName)
    {
      Color color = new Color {ColorName = colorName};
      var newCol = _ctx.Add(color).Entity;
      _ctx.SaveChanges();
      return newCol;
    }

    public Color DeleteColor(int id)
    {
      throw new System.NotImplementedException();
    }

    public Color UpdateColor(Color updatedColor)
    {
     return _ctx.Update(updatedColor).Entity;
    }
  }
}