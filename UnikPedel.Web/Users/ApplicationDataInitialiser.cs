using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace UnikPedel.Web.Users
{
    public static  class ApplicationDataInitialiser
    {
        public static void SeedData(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //SeedRoles(roleManager);
            SeedUsers(userManager);
        }
        public static void SeedUsers(UserManager<IdentityUser> userManager)
        {
            if (userManager.FindByNameAsync("admin@contoso.com").Result == null)
            {
                var user = new IdentityUser
                {
                    UserName = "admin@contoso.com",
                    Email = "admin@contoso.com",
                    NormalizedUserName = "ADMIN",
                    NormalizedEmail = "ADMIN@CONTOSO.COM"
                };
                var password = "123456";
                var result = userManager.CreateAsync(user, password).Result;
                if (result.Succeeded) userManager.AddClaimAsync(user, new Claim(UserClaimTypeEnum.IsAdmin, "")).Wait();
            }
        }
        //public static void SeedRoles(RoleManager<IdentityRole> roleManager)
        //{
        //    if (!roleManager.RoleExistsAsync("Administrator").Result)
        //    {
        //        var role = new IdentityRole
        //        {
        //            Name = "Administrator"
        //        };
        //        roleManager.CreateAsync(role).Wait();
        //    }
        //}
    }
}
