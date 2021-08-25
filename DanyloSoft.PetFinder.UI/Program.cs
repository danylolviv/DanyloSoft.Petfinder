using System;
using System.Security.Authentication.ExtendedProtection;
using DanyloSoft.PetFinder.Core.IServices;
using DanyloSoft.PetFinder.Domain.IRepositories;
using DanyloSoft.PetFinder.Domain.Services;
using DanyloSoft.PetFinder.Infrastructure.Database.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DanyloSoft.PetFinder.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            
            serviceCollection.AddScoped<IPetRepository, PetRepository>();
            serviceCollection.AddScoped<IPetService, PetService>();
            serviceCollection.AddScoped<IPetTypeRepository, PetTypeRepository>();
            serviceCollection.AddScoped<IPetTypeService, PetTypeService>();
            serviceCollection.AddScoped<IMenu, MainMenu>();

            
            var serviceProvider = serviceCollection.BuildServiceProvider();
            
            var mainMenu = serviceProvider.GetRequiredService<IMenu>();
            
            mainMenu.Start();
        }
    }
}