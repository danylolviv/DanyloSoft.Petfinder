using System.Collections.Generic;
using System.Linq;
using DanyloSoft.PetFinder.Core.Models;
using DanyloSoft.PetFinder.Domain.IRepositories;
using DanyloSoft.PetFinder.Infrastructure.Data.Entities;
using DanyloSoft.PetFinder.Infrastructure.Data.Entities.Transformers;

namespace DanyloSoft.PetFinder.Infrastructure.Data.Repos
{
  public class ColorRepo : IColorRepository
  {
    private readonly PetFinderAppContext _ctx;
    private readonly EntityTransformer _tr;
    public ColorRepo(PetFinderAppContext ctx)
    {
      _ctx = ctx;
      _tr = new EntityTransformer();
    }
    public IEnumerable<Color> GetAllColors()
    {
      return _ctx.ColorTable
        .Select(entity => _tr.FromColorEntity(entity) ).ToList();
    }

    public Color GetColorById(int id)
    {
      return _tr.FromColorEntity(_ctx.ColorTable.Find(id));
    }
    
    public ColorEntity GetColorByIdSpecial(int id)
    {
      return _ctx.ColorTable.Find(id);
    }

    public Color CreateColor(string colorName)
    {
      var colorEntity = new ColorEntity() {ColorName = colorName};
      var newCol = _tr.FromColorEntity(_ctx.Add(colorEntity).Entity);
      _ctx.SaveChanges();
      return newCol;
    }

    public Color DeleteColor(int id)
    {
      var color = GetColorById(id);
      _ctx.ColorTable.Remove(GetColorByIdSpecial(id));
      _ctx.SaveChanges();
      return color;
    }

    public Color UpdateColor(Color updatedColor)
    {
      var existingEntity = GetColorByIdSpecial(updatedColor.Id);
      existingEntity.ColorName = updatedColor.ColorName;
      var updatedColorV = _tr.FromColorEntity(
        _ctx.Update(existingEntity).Entity);
      _ctx.SaveChanges();
      return updatedColorV;
    }
    // WHY THIS NO WORKIE LARS!?
    // var updatedColorV = _tr.FromColorEntity(
    //   _ctx.Update(_tr.ToColorEntity(updatedColor)).Entity);
    // _ctx.SaveChanges();
    // return updatedColorV;
    
  }
}