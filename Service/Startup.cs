using Application.Contacts.Commands.CreateContactCommand;
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
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
            });

            services.Add(new ServiceDescriptor(typeof(IDatabaseService), typeof(DatabaseService), ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(typeof(IGetStatesListQuery), typeof(GetStatesListQuery), ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(typeof(IGetFilteredRecipesListQuery), typeof(GetFilteredRecipesListQuery), ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(typeof(IGetRecipesCategoriesListQuery), typeof(GetRecipesCategoriesListQuery), ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(typeof(IGetRecipeDetailsQuery), typeof(GetRecipeDetailsQuery), ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(typeof(ICreateContactCommand), typeof(CreateContactCommand), ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(typeof(INotificationsFactory), typeof(NotificationsFactory), ServiceLifetime.Transient));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(options => options.AllowAnyOrigin());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
