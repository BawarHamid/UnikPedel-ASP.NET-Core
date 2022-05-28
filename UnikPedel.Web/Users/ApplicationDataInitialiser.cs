using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace UnikPedel.Web.Users
{
    public static  class ApplicationDataInitialiser
    {
        public static void SeedData(UserManager<IdentityUser> userManager)
        {
            
            SeedUsers(userManager);
        }
        public static void SeedUsers(UserManager<IdentityUser> userManager)
        {
            if (userManager.FindByNameAsync("admin@admin.com").Result == null)
            {
                var user = new IdentityUser
                {
                    UserName = "admin@admin.com",
                    Email = "admin@admin.com",
                    NormalizedUserName = "ADMIN",
                    NormalizedEmail = "ADMIN@ADMIN.COM"
                };
                var password = "123456";
                var result = userManager.CreateAsync(user, password).Result;
                if (result.Succeeded) userManager.AddClaimAsync(user, new Claim(UserClaimTypeEnum.IsAdmin, "")).Wait();
            }
        }
       
    }
}
