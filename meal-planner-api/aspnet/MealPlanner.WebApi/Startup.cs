using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MealPlanner.DataContext;
using MealPlanner.DataContext.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Cosmos.Storage.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace MealPlanner.WebApi
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

      // Swagger
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "Meal Planner API", Version = "v1" });
      });
      

      // Database (DataContext using Azure Cosmos DB)
      string serviceEndPoint = this.Configuration.GetValue<string>("ServiceEndPoint");
      string authKeyOrResourceToken = this.Configuration.GetValue<string>("AuthKeyOrResourceToken");
      string databaseName = this.Configuration.GetValue<string>("DatabaseName");
      
      services.AddDbContext<MealPlannerContext>(
          options =>
          options.UseCosmos(
            serviceEndPoint,
            authKeyOrResourceToken,
            databaseName,
            contextOptions =>
            {
              contextOptions.ExecutionStrategy(d => new CosmosExecutionStrategy(d));
            }
          )
        );

      services.AddScoped<UnitOfWork>();


      services.AddMvc();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, MealPlannerContext context)
    {
      // Database
      context.Database.EnsureCreated();

      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseHttpsRedirection();

      // Swagger
      app.UseSwagger();
      app.UseSwaggerUI(c =>
      {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Meal Planner API V1");
      });

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
