namespace DanyloSoft.PetFinder.Core.Filters
{
  public class Filter
  {
    public int Count { get; set; }
    public int Page { get; set; }
    public string OrderBy { get; set; }
    public string OrderDirection { get; set; }
    public string SearchQuery { get; set; }
  }
}