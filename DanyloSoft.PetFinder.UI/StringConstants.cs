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
        
        public const string CreatePetGreeting = "Create Video";
        public static string EditPetsGreeting = "Here is a list of Pets in Library, to edit video type its Id and press Enter.";
        public static string PetListGreeting = "Select a view for the pets in Library";
        public const string WhatToSearchFor = "Please Decide what to search for (1 - Id, 2 - Title, 0 - To Go Back)";
        public static string DeletePetGreeting =
            "Here is a list of Pets in the system, to delete pet type its Id and press Enter.";
        public const string SearchPetGreeting = "Please Decide what to search for";
        public const string SearchOptionId = "...::Type 1::... Search by Id";
        public const string SearchOptionQuery = "...::Type 2::... Search by query";
        public const string SearchOptionGenre = "...::Type 3::...Please Decide what to search for (1 - Id, 2 - Title, 0 - To Go Back)";

        
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
    }
}