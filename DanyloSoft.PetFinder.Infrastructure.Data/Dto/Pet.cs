using System;

namespace DanyloSoft.PetFinder.Infrastructure.Data.Dto
{
  public class Pet
  {
    public int Id {get; set;}
    public string Name { get; set; }
    public DateTime Birthday { get; set; }
    public DateTime SellOutDate { get; set; }
    public string Color { get; set; }
    public double Price { get; set; }
    
    public int PetTypeId { get; set; }
    public int OwnerId { get; set; }
  }
}