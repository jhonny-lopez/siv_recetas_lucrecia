using Application.Contacts.Commands.CreateContactCommand;
using Application.Employees.Commands.CreateEmployee;
using Application.Employees.Commands.UpdateEmployee;
using Application.Interfaces;
using Application.Recipes.Queries.GetFilteredRecipesList;
using Application.Recipes.Queries.GetRecipeDetailsQuery;
using Application.Recipes.Queries.GetRecipesCategoriesList;
using Application.Regions.States;
using Infrastructure.Notifications;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Application.Recipes.Queries.GetRecipeCategoriesList;
using Application.Events.Commands.CreateEventWithDTO;
using Application.Events.Commands.CreateEventWithoutDTO;
using Application.Events.Queries.GetEventDetailsById;

namespace Service
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

            services.AddDbContext<DatabaseService>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("RecetasLucrecia"))
            );

            services.AddCors(c =>
            {
                c.AddPolicy("AllOrigins", options => options.AllowAnyOrigin());
                c.AddPolicy("ProductionPolicy", options => options.WithOrigins("http://127.0.0.1:5500"));
            });

            services.AddAutoMapper(typeof(Startup));
            
            services.Add(new ServiceDescriptor(typeof(IDatabaseService), typeof(DatabaseService), ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(typeof(IGetStatesListQuery), typeof(GetStatesListQuery), ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(typeof(IGetFilteredRecipesListQuery), typeof(GetFilteredRecipesListQuery), ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(typeof(IGetRecipesCategoriesListQuery), typeof(GetRecipesCategoriesListQuery), ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(typeof(IGetRecipeDetailsQuery), typeof(GetRecipeDetailsQuery), ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(typeof(ICreateContactCommand), typeof(CreateContactCommand), ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(typeof(INotificationsFactory), typeof(NotificationsFactory), ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(typeof(ICreateEmployeeCommand), typeof(CreateEmployeeCommand), ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(typeof(IUpdateEmployeeCommand), typeof(UpdateEmployeeCommand), ServiceLifetime.Transient));
            
            services.AddTransient(typeof(ICreateEventWithDTOCommand), typeof(CreateEventWithDTOCommand));
            services.AddTransient(typeof(ICreateEventCommandWithoutDTO), typeof(CreateEventCommand));
            services.AddTransient(typeof(IGetEventDetailsByIdQuery), typeof(GetEventDetailsByIdQuery));
            services.AddTransient(typeof(IGetEventDetailsByIdQuery), typeof(GetEventDetailsByIdQuery));

            services.AddMediatR(typeof(Application.Shared.MediatorAssemblyResolver).Assembly);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseCors("AllowOrigin");
            }
            else if (env.IsStaging())
            {

            }
            else if (env.IsProduction())
            {
                app.UseCors("ProductionPolicy");
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
