using Microsoft.AspNetCore.Identity;

namespace BSAM.Identity.Api.Data
{
    public class DataSeeder
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public DataSeeder(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task SeedRoles()
        {
            string[] rolesNames = { "Admin", "User", "Operator" };

            foreach (var namesRole in rolesNames)
            {
                var roleExist = await _roleManager.RoleExistsAsync(namesRole);
                if (!roleExist)
                    await _roleManager.CreateAsync(new IdentityRole(namesRole));
            }
        }
        public async Task SeedAdminUser()
        {
            var user = new IdentityUser { UserName = "humbertopedrosva", Email = "humbertopedrosva@gmail.com", EmailConfirmed = true };
            var role = "Admin";
            var password = "$Abc147258";

            IdentityResult identityResult = await _userManager.CreateAsync(user, password);

            if (identityResult.Succeeded)
                await _userManager.AddToRoleAsync(user, role);
        }
    }
}
