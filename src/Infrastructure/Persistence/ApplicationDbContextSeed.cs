using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;

namespace CleanArchitecture.Infrastructure.Persistence
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager)
        {
            var defaultUser = new ApplicationUser { UserName = "re@za", Email = "re@za" };

            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                await userManager.CreateAsync(defaultUser, "re!za123");
            }
        }
    }
}
