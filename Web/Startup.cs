using Application.Ingredients.Commands.CreateIngredient;
using Application.Ingredients.Commands.UpdateIngredient;
using Application.Ingredients.Queries.GetIngredientDetail;
using Application.Ingredients.Queries.GetIngredients;
using Application.Interfaces;
using Common.Configuration;
using Infrastructure.Notifications;
using Infrastructure.Stock;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Persistence;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Web.Extensions;

namespace Web
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
            services.AddControllersWithViews();
            services.AddHealthChecks()
                .AddSqlServer(Configuration.GetConnectionString("RecetasLucrecia"));
            services.AddHealthChecksUI()
                .AddSqlServerStorage(Configuration.GetConnectionString("RecetasLucrecia"));

            services.AddDbContext<DatabaseService>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("RecetasLucrecia"))
            );

            string appKey = Configuration.GetValue<string>("General:SMSProvider:AppKey");
            bool isBillingEnabled = Configuration.GetValue<bool>("IsBillingEnabled");
            int defaultPort = Configuration.GetValue<int>("DefaultPort");

            string appName = Configuration.GetValue<string>("ApplicationName");

            string customerName = Configuration.GetValue<string>("Customer:Name");
            string customerNit = Configuration.GetValue<string>("Customer:NIT");
            string otherConnectionString = Configuration.GetValue<string>("ASPNETCORE_CONNECTIONSTRING");

            services.Add(new ServiceDescriptor(typeof(IDatabaseService), typeof(DatabaseService), ServiceLifetime.Transient));
            services.AddTransient(typeof(IGetIngredientsQuery), typeof(GetIngredientsQuery));
            services.AddTransient(typeof(IGetIngredientDetailQuery), typeof(GetIngredientDetailQuery));
            services.AddTransient(typeof(ICreateIngredientCommand), typeof(CreateIngredientCommand));
            services.AddTransient(typeof(IUpdateIngredientCommand), typeof(UpdateIngredientCommand));
            services.AddTransient(typeof(IStockService), typeof(NikeStockService));


            services.Configure<SMSProviderOptions>(Configuration.GetSection(SMSProviderOptions.SectionName));
            services.Configure<MailProviderOptions>(Configuration.GetSection(MailProviderOptions.SectionName));
            services.Configure<GeneralOptions>(Configuration.GetSection(GeneralOptions.SectionName));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment() || env.IsStaging())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.Use(async (context, next) =>
            {
                await next();

                if (context.Response.StatusCode == 404)
                {
                    context.Request.Path = "/Home/ContentNotFound";
                    await next();
                }
            });

            app.UseAuthorization();

            app.UseRequestCulture();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapHealthChecksUI();
            });
        }
    }
}
