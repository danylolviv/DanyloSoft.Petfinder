using System;
using DanyloSoft.PetFinder.Core.IServices;

namespace DanyloSoft.PetFinder.UI
{
    public class MainMenu : IMenu
    {
        private MenuImplementation mi;
        private IPetService _petService;
        private IPetTypeService _petTypeService;
        
        public MainMenu(IPetService petServ, IPetTypeService petTypeServ)
        {
            _petService = petServ;
            _petTypeService = petTypeServ;
            mi = new MenuImplementation(_petService, _petTypeService);
        }
        public void Start()
        {
            WelcomeGreeting();
            StartMenu();
        }

        private void StartMenu()
        {
            int choice;
            while ((choice = GetMainMenuSelection()) != 0)
            {
                
                switch (choice)
                {
                    case 1:
                        mi.CreatePet();
                        break;
                    case 2:
                        mi.SeePetList();
                        break;
                    case 3:
                        mi.UpdatePet();
                        break;
                    case 4:
                        mi.DeletePet();
                        break;
                    case 5:
                        mi.SearchPet();
                        break;
                }
            }
            Pt(StringConstants.ExitAppText);
        }

        private int GetMainMenuSelection()
        {
            ShowMainMenu();
            Pt("");
            var selectionString = Console.ReadLine();
            int selection;
            if (int.TryParse(selectionString, out selection))
            {
                return selection;
            }
            return -1;
        }

        private void ShowMainMenu()
        {
            Pt(StringConstants.CreatePetMenuText);
            Pt(StringConstants.ShowPetsMenuText);
            Pt(StringConstants.EditPet);
            Pt(StringConstants.DeletePet);
            Pt(StringConstants.SearchPet);
            Pt("");
            Pt(StringConstants.AppExit);
        }

        private void WelcomeGreeting()
        {
            Pt(StringConstants.WelcomeGreeting);
        }

        private void Pt(string toPrint)
        {
            Console.WriteLine(toPrint);
        }
    }
}