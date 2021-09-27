using DanyloSoft.PetFinder.Core.Models;

namespace DanyloSoft.PetFinder.PetServiceRestApi.Dto
{
  public class ColorTransformer
  {
    public Color PutColorTrans(PutColorDto putColorDto)
    {
      Color col = new Color
      {
        Id = putColorDto.Id,
        ColorName = putColorDto.ColorName
      };
      return col;
    }

    public GetColorDto GetColorTrans(Color color)
    {
      return new GetColorDto {color = color.ColorName};
    }

    public GetPetsByColorDto GetPetsByColor(Pet pet)
    {
      return new GetPetsByColorDto()
      {
        Id = pet.Id,
        Name = pet.Name,
        PetColor = new GetColorDto() {color = pet.Color.ColorName}
      };
    }
  }
}