using System;
using System.Globalization;
using DanyloSoft.PetFinder.Core.IServices;
using DanyloSoft.PetFinder.Core.Models;
using DanyloSoft.PetFinder.Domain.Services;

namespace DanyloSoft.PetFinder.UI
{
    public class MenuImplementation
    {
        private IPetService _petService;
        private IPetTypeService _petTypeService;
        private DateTime dateToCheckTheOkStatment = new DateTime(1237, 12, 12);
        public MenuImplementation(IPetService petServ, IPetTypeService petTypeServ)
        {
            _petService = petServ;
            _petTypeService = petTypeServ;
        }
        public Pet CreatePet()
        {
            Pt(StringConstants.CreatePetGreeting);
            Press1ToContinue();
            Pt(StringConstants.PetNameInput);
            string name = Console.ReadLine();
            PetType petType = GetPetType(_petTypeService);
            Pt(StringConstants.InputBirthDateGreeting);
            DateTime birthDate = GenerateDate(Console.ReadLine());
            Pt(StringConstants.InputSellhDateGreeting);
            DateTime sellDate = GenerateDate(Console.ReadLine());
            Pt(StringConstants.SelectColorGreeting);
            string color = Console.ReadLine();
            Pt(StringConstants.PetPriceGreeting);
            double price;
            bool priceTry = double.TryParse(Console.ReadLine(), out price);
            Pet newPet = new Pet
            {
                Name = name, 
                Birthday = birthDate,
                SellOutDate = sellDate,
                Color = color,
                PetType = petType,
                Price = price
            };
            Pt(StringConstants.CurrentPetCreated(newPet));
            Pt(StringConstants.FinishCreateProcess);
            int input;
            while (int.TryParse(Console.ReadLine(),out input))
            {
                if (input == 1)
                {
                    _petService.CreatePet(newPet);
                }

                if (input == 0)
                {
                    return null;
                }
            }
            
            CreatePet();
            Console.ReadLine();
            return null;
        }

        private PetType GetPetType(IPetTypeService petTypeService)
        {
            Pt(StringConstants.SelectPetTypeGreeting);
            foreach (var petType in petTypeService.GetListPetTypes())
            {
                Pt(petType.ToString());
            }

            int processorVal = 0;
            while (processorVal == 0)
            {
                Pt(StringConstants.TypeTheId);
                int typedId;
                if (int.TryParse(Console.ReadLine(),out typedId))
                {
                    foreach (var petType in petTypeService.GetListPetTypes())
                    {
                        if (typedId == petType.Id)
                        {
                            Pt($"Pet type of your choice is: {petType.ToString()}");
                            return petType;
                        }
                    }
                }
                Pt(StringConstants.NotSutisfyingInput);
            }
            return null;
        }


        public void SeePetList()
        {
            Pt(StringConstants.PetListGreeting);
            foreach (var pet in _petService.GetPets())
            {
                Pt(pet.ToString());
            }
            
            Pt(StringConstants.ExitMainMenuText);
            int parsedNum;
            while (int.TryParse(Console.ReadLine(), out parsedNum))
            {
                if (parsedNum == 0)
                {
                    Pt(StringConstants.SeeYou);
                }
            }
        }

        public void UpdatePet()
        {
            Pt(StringConstants.EditPetsGreeting);
            foreach (var pet in _petService.GetPets())
            {
                Pt(pet.ToString());
                Pt("");
            }
            Pt(StringConstants.EditPetsGreeting);
            int chosenId;
            while (int.TryParse(Read(StringConstants.ProvideId),out chosenId))
            {
                foreach (var petToUpdate in _petService.GetPets())
                {
                    if (chosenId == petToUpdate.Id)
                    {
                        Pt(StringConstants.ConfirmUpdate);
                        Pt(petToUpdate.ToString());
                        if (int.Parse(Console.ReadLine()) == 1)
                        {
                            Pet updatedPet = UpdateProcess(petToUpdate);
                            Pt(StringConstants.ConfirmNewPet);
                            Pt(updatedPet.ToString());
                            if (int.Parse(Console.ReadLine()) == 1)
                            {
                                _petService.UpdatePet(updatedPet);
                                Pt(StringConstants.SuccessfulUpdatedPet);
                            }
                        }
                        break;
                    }
                }
                Pt(StringConstants.UpdateAnotherOrQuit);
                if (int.Parse(Console.ReadLine()) == 1)
                {
                    UpdatePet();
                }
                break;
            }
            
        }

        private Pet UpdateProcess(Pet petToUpdate)
        {
            Pt(StringConstants.UpdateProcessExplained);
            Press1ToContinue();
            
            Pt($"Pet name: {petToUpdate.Name}");
            string newName = Console.ReadLine();
            if (newName.ToLower().Equals("ok"))  newName = petToUpdate.Name; 
            
            Pt($"Pet type: {petToUpdate.PetType.ToString()}");
            PetType newPetType = GetPetType(_petTypeService) ?? petToUpdate.PetType;
            
            Pt($"Pet birthdate: {petToUpdate.Birthday}");
            DateTime newBirthDate = GenerateDate(Console.ReadLine());
            if (newBirthDate == dateToCheckTheOkStatment) newBirthDate = petToUpdate.Birthday;
            
            Pt($"Pet sell date: {petToUpdate.SellOutDate}");
            DateTime newSellDate = GenerateDate(Console.ReadLine()) ;
            if (newSellDate == dateToCheckTheOkStatment) newSellDate = petToUpdate.SellOutDate;
            
            Pt($"Pet color: {petToUpdate.Color}");
            string newColor = Console.ReadLine();
            if (newColor.ToLower().Equals("ok"))  newColor = petToUpdate.Color;

            Pt($"Pet price: {petToUpdate.Price}");
            double newPrice;
            bool priceTry = double.TryParse(Console.ReadLine(), out newPrice);
            if (!priceTry) newPrice = petToUpdate.Price;

            Pet newPet = new Pet
            {
                Name = newName,
                Birthday = newBirthDate,
                Color = newColor,
                SellOutDate = newSellDate,
                PetType = newPetType,
                Price = newPrice,
                Id = petToUpdate.Id
            };
            return newPet;
        }

        private string Read(string message)
        {
            Pt(message);
            return Console.ReadLine();
        }

        public void DeletePet()
        {
            Pt(StringConstants.DeletePetGreeting);
            foreach (var pet in _petService.GetPets())
            {
                Pt(pet.ToString());
                Pt("");
            }
            Pt(StringConstants.DeletePetGreeting);
            int chosenId;
            while (int.TryParse(Console.ReadLine(),out chosenId))
            {
                foreach (var petToDelete in _petService.GetPets())
                {
                    if (chosenId == petToDelete.Id)
                    {
                        Pt(StringConstants.ConfirmDelete);
                        Pt(petToDelete.ToString());
                        if (int.Parse(Console.ReadLine()) == 1)
                        {
                            _petService.DeletePet(petToDelete);
                            Pt(StringConstants.SuccessfullyDeleted);
                        }
                        break;
                    }
                }
                Pt(StringConstants.DeleteAnotherOrQuit);
                if (int.Parse(Console.ReadLine()) == 1)
                {
                    DeletePet();
                }
            }
        }

        public void SearchPet()
        {
            Pt(StringConstants.WhatToSearchFor);
        }
        
        private void Pt(string toPrint)
        {
            Console.WriteLine(toPrint);
        }
        
        private void Press1ToContinue()
        {
            Pt(StringConstants.PresToContinue);
            var input = "";

            int parsedNum = -1;
            
            while (!int.TryParse(input, out parsedNum))
            {
                if (parsedNum == 1)
                {
                    break;
                }
                input = Console.ReadLine();
                //GenerateDate(input);
                //GenerateDate(input, "dskjjkds")
            }
        }

        private DateTime GenerateDate(string input, string pattern = "M/dd/yyyy")
        {
            DateTime outputDate = DateTime.Now;
            var processManager = 0;
            while (processManager == 0)
            {
                if (DateTime.TryParseExact(input,pattern, CultureInfo.InvariantCulture, DateTimeStyles.None,out outputDate))
                {
                    Pt("Successful date input");
                    Pt($"Your date is {outputDate.ToString()}");
                    Pt(StringConstants.Press1ToContinue);
                    var var = 0;
                    if (int.TryParse(Console.ReadLine(), out var))
                    {
                        if (var == 1)
                        {
                            return outputDate;
                        }
                    }
                }
                if (input.Contains("now"))
                {
                    outputDate = DateTime.Today;
                    Pt($"Your date is {outputDate.ToString("M/dd/yyyy")}");
                    Pt(StringConstants.Press1ToContinue);
                    var var = 0;
                    if (int.TryParse(Console.ReadLine(), out var))
                    {
                        if (var == 1)
                        {
                            return outputDate;
                        }
                    }
                }

                if (input.Contains("ok"))
                {
                    return dateToCheckTheOkStatment;
                }
                processManager = 1;
            }
            Pt(StringConstants.NotSutisfyingInput);
            return GenerateDate(Console.ReadLine());
        }
    }
}