using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MScApp.Core;

[assembly: HostingStartup(typeof(MScApp.Areas.Identity.IdentityHostingStartup))]
namespace MScApp.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                services.AddDbContext<MScAppDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("MScAppContextConnection")));

                services.AddIdentity<AppUser, IdentityRole>(
                    options =>
                    {
                        options.SignIn.RequireConfirmedAccount = false;
                        options.Password.RequireNonAlphanumeric = false;
                    })
                    .AddEntityFrameworkStores<MScAppDbContext>()
                    .AddDefaultUI()
                    .AddDefaultTokenProviders();

            });
        }
    }
}