namespace DanyloSoft.PetFinder.PetServiceRestApi.Dto
{
  public class GetPetsByColorDto
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public GetColorDto PetColor { get; set; }
  }
}