using System.Collections.Generic;

namespace DanyloSoft.PetFinder.PetServiceRestApi.Dto
{
  public class GetAllColorDto
  {
    public List<GetColorDto> Colors { get; set; }
    public int Count { get; set; }
  }
}