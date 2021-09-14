using DanyloSoft.PetFinder.Core.IServices;
using DanyloSoft.PetFinder.Domain.IRepositories;
using DanyloSoft.PetFinder.Domain.Services;
using DanyloSoft.PetFinder.Infrastructure.Data;
using DanyloSoft.PetFinder.Infrastructure.Data.Repos;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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

      var loggerFactory = LoggerFactory.Create(builder =>
      {
        builder.AddConsole();
      });
      
      

      services.AddDbContext<PetFinderAppContext>(
        opt =>
        {
          opt
            .UseLoggerFactory(loggerFactory)
            .UseSqlite("Data Source=PetFinderApp.db");
        }, ServiceLifetime.Transient);
      
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

        using (var scope = app.ApplicationServices.CreateScope())
        {
          var ctx = scope.ServiceProvider.GetService<PetFinderAppContext>();
          ctx.Database.EnsureDeleted();
          ctx.Database.EnsureCreated();
        }
      }

      //app.UseHttpsRedirection();

      app.UseRouting();

      //app.UseAuthorization();

      app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }
  }
}