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
        public Color Color { get; set; }
        public double Price { get; set; }

        public override string ToString()
        {
            string outString =
                $"...:: {Id} ::...{Name} {PetType.Name} Birth Date: {Birthday.Date.ToString("M/dd/yyyy")} Sell Date {SellOutDate.Date.ToString("M/dd/yyyy")} Color: {Color} Price: {Price}";
            return outString;
        }
    }
}