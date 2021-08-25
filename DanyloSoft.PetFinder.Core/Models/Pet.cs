using System;

namespace DanyloSoft.PetFinder.Core.Models
{
    public class Pet
    {
        public int Id {get; set;}
        public string Name { get; set; }
        public PetType PetType { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime SellOutDate { get; set; }
        public string Color { get; set; }
        public double Price { get; set; }
    }
}