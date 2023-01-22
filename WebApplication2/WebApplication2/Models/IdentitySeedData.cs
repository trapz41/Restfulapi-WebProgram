using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace WebApplication2.Models
{

    public static class IdentitySeedData
    {
        private const string kullaniciadi = "admin";
        private const string sifre = "admin";

        public static async void EnsurePopulated(IApplicationBuilder app)
        {

            AppIdentityDbContext context = app.ApplicationServices
                .CreateScope().ServiceProvider
                .GetRequiredService<AppIdentityDbContext>();
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            UserManager<IdentityUser> userManager = app.ApplicationServices
                .CreateScope().ServiceProvider
                .GetRequiredService<UserManager<IdentityUser>>();

            IdentityUser user = await userManager.FindByIdAsync(kullaniciadi);
            if (user == null)
            {
                user = new IdentityUser("Admin");
                await userManager.CreateAsync(user, sifre);
            }
        }
    }
}


