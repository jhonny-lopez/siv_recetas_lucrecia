using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Web.Areas.Identity.Data;
using Web.Data;

[assembly: HostingStartup(typeof(Web.Areas.Identity.IdentityHostingStartup))]
namespace Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<SecurityWebContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("SecurityWebContextConnection")));

                services.AddIdentity<MyIdentityUser, IdentityRole>(options =>
                    {
                        options.SignIn.RequireConfirmedAccount = true;

                    })
                    .AddEntityFrameworkStores<SecurityWebContext>()
                    .AddDefaultTokenProviders()
                    .AddSignInManager<SignInManager<MyIdentityUser>>();
            });
        }
    }
}