using System;
using DanyloSoft.PetFinder.Core.Models;

namespace DanyloSoft.PetFinder.Infrastructure.Data.Entities
{
  public class PetEntity
  {
    public int Id {get; set;}
    public string Name { get; set; }
    public DateTime Birthday { get; set; }
    public DateTime SellOutDate { get; set; }
    public double Price { get; set; }
    
    
    public int PetTypeId { get; set; }
    public PetTypeEntity PetType { get; set; }
    public int OwnerId { get; set; }
    public OwnerEntity Owner { get; set; }
    public int ColorId { get; set; }
    public ColorEntity Color { get; set; }
  }
}