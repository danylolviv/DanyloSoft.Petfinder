using System;
using System.Security.Authentication.ExtendedProtection;
using Microsoft.Extensions.DependencyInjection;

namespace DanyloSoft.PetFinder.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            
            var mainMenu = new MainMenu();
            mainMenu.Start();
        }
    }
}