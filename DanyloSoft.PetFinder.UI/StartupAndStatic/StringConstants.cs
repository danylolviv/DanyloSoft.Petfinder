using System;
using DanyloSoft.PetFinder.Core.Models;

namespace DanyloSoft.PetFinder.UI
{
    public class StringConstants
    {
        public static readonly string WelcomeGreeting = "Welcome to the PetFinder - web portal which opens new horizon for you - The Pet Owner.";
        
        public static readonly string CreatePetMenuText = "...::Type 1::... To create new pet";
        public static readonly string ShowPetsMenuText = "...::Type 2::... To see available pets";
        public static readonly string EditPet = "...::Type 3::... To edit selected video from the list";
        public static readonly string DeletePet = "...::Type 4::... To delete a pet from the system";
        public static readonly string SearchPet = "...::Type 5::... To search for pet";
        
        public const string CreatePetGreeting = "You will be asked few questions to specify the Pet you want to create. [Press 1 to continue]";
        public static string EditPetsGreeting = "Here is a list of Pets in Library, to edit video type its Id and press Enter.";
        public static string PetListGreeting = "Select a view for the pets in Library";
        public const string WhatToSearchFor = "Please Decide what to search for (1 - Id, 2 - Title, 0 - To Go Back)";
        public static string DeletePetGreeting =
            "Here is a list of Pets in the system, to delete pet type its Id and press Enter.";
        public const string SearchPetGreeting = "Please Decide what to search for";
        public const string SearchOptionId = "...::Type 1::... Search by Id";
        public const string SearchOptionQuery = "...::Type 2::... Search by query";
        public const string SearchOptionGenre = "...::Type 3::...Please Decide what to search for (1 - Id, 2 - Title, 0 - To Go Back)";

        public static string PresToContinue = "To continue press ...:: 1 ::...";
        
        
        
        
        
        public static readonly string PleaseSelectMain = "Select One of the items below";
        
        public const string PleaseSelectCorrectSearchOptions = "Please Select a nnumber between 0 and 2";
        
        public const string ExitMainMenuText = "Type 0 to Exit";
        public const string PleaseSelectCorrectItem = "Please Select a Number Between 0 and 5";
        
        public const string VideoStoryLine = "Type Video StoryLine (with more then 2 char and less then 240)";
        public const string VideoName = "Type Video Name (with more then 2 char and less then 40)";
        
        
        public static string ExitAppText = "Thank you for using this service, you pressed 0, and application exited!";
        public static string Press0ToMainMenu = "Press 0 to go to Main Menu";

        
        public static string VideoDeleteError = "The id that you typed doesn't exist try different Id      Typed Id = ";

        public static string VideoEditProcess = "You chose to edit video with following title: ";
        public static string VideoEditing_NewTitle = "New Title:";
        public static string VideoEditing_NewStoryLine = "New StoryLine:";
        public static string SavingUpdatedVideo = "Following is how the new video will be saved, ..:: press 5 ::.. to save it";
        public static string SuccessfulUpdate = "You have successfully updated video, Congrats, have a beer";
        public static string SearchById = "Mode: search by Id initialized. Type Id";
        public static string SearchByTitle = "Mode: search by Title initialized. Type full title or part of it.";
        public static string VideoSearchWarning = "Wrong input, try typing a number!";
        public static string SearchResults = "Here are the results from your recent search. Press 1 to start over.";

        public static string InputBirthDateGreeting = "Please input the birth date in following format ...:: M/dd/yyyy ::... or just type .: now :.";
        public static string InputDateAgree = "If you are happy with the date selection press .: 1 :. to continue .: 0 :.";
        public static string Press1ToContinue = "If you are sutisfied press ..: 1 :. to continue.";

        public static string NotSutisfyingInput = "!!!!   Your input didn't sutisfy the needs of the program please try again   !!!!";
        public static string PetNameInput = "Please type the name of the pet.";
        public static string SelectPetTypeGreeting = "Its time to select pet type, below is the list of pet types select one by writing its Id";
        public static string TypeTheId = "Please select the id";
        public static string InputSellhDateGreeting = "Please input the sell date in following format ...:: M/dd/yyyy ::... or just type .: now :.";
        public static string SelectColorGreeting = "What is the color of the Pet";

        public static string PetPriceGreeting = "What is the asking price for the Pet?";

        public static string FinishCreateProcess =
            "If you are happy with created Pet press .: 1 :. to save it or press .: 0 :. to exit without saving";

        public static string SeeYou = "Come back again, we are always open";
        public static string ConfirmDelete = "You chose following pet to delete, press ..: 1 :.. to confirm, or ..: 0 :. to cancel.";

        public static string SuccessfullyDeleted =
            "Your pet was successfully deleted";

        public static string DeleteAnotherOrQuit = "Press ..: 1 :.. to delete another pet or press ..: 0 :.. to exit to MainMenu";
        public static string NoMatchesWereFound = "No pets with this Id were found";

        public static string CurrentPetCreated(Pet pet)
        {
            string output = $"Here is the Pet you just created: " +
                     $"{pet.ToString()}";
            return output;
        }
    }
}