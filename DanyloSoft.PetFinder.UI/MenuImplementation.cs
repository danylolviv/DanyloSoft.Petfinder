using System;

namespace DanyloSoft.PetFinder.UI
{
    public class MenuImplementation
    {
        public void CreatePet()
        {
            Pt(StringConstants.CreatePetGreeting);
        }

        public void SeePetList()
        {
            Pt(StringConstants.PetListGreeting);
        }

        public void UpdatePet()
        {
            Pt(StringConstants.EditPetsGreeting);
        }

        public void DeletePet()
        {
            Pt(StringConstants.DeletePetGreeting);
        }

        public void SearchPet()
        {
            Pt(StringConstants.WhatToSearchFor);
        }
        
        private void Pt(string toPrint)
        {
            Console.WriteLine(toPrint);
        }
    }
}