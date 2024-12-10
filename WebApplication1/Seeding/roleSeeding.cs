using Microsoft.AspNetCore.Identity;

namespace ECOMMERECE.Seeding
{
    public class roleSeeding
    {
        public static async Task seedRoles(RoleManager<IdentityRole> roleManager)
        {
            string[] roles = { "Admin", "User","Provider"};
            foreach (var role in roles)
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }
    }
}
