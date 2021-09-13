using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DanyloSoft.PetFinder.Core.IServices;
using DanyloSoft.PetFinder.Domain.IRepositories;
using DanyloSoft.PetFinder.Domain.Services;
using DanyloSoft.PetFinder.Infrastructure.Data;
using DanyloSoft.PetFinder.Infrastructure.Data.Repos;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace DanyloSoft.PetFinder.PetServiceRestApi
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddControllers();
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1",
          new OpenApiInfo
          {
            Title = "DanyloSoft.PetFinder.PetServiceRestApi", Version = "v1"
          });
      });

      services.AddDbContext<PetFinderAppContext>(
        opt => opt.UseInMemoryDatabase("ThaDB")
        );
      
      services.AddScoped<IPetService, PetService>();
      services.AddScoped<IPetRepository, PetRepo>();
      services.AddScoped<IPetTypeService, PetTypeService>();
      services.AddScoped<IPetTypeRepository, PetTypeRepo>();
      services.AddScoped<IOwnerService, OwnerService>();
      services.AddScoped<IOwnerRepository, OwnerRepo>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json",
          "DanyloSoft.PetFinder.PetServiceRestApi v1"));
      }

      //app.UseHttpsRedirection();

      app.UseRouting();

      //app.UseAuthorization();

      app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }
  }
}