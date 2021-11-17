using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityApp.Pages.Roles
{
    public class ListModel : AdminPageModel
    {
        public UserManager<ApplicationUser> UserManager;
        public RoleManager<IdentityRole> RoleManager;

        public ListModel(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            UserManager = userManager;
            RoleManager = roleManager;
        }

        public IEnumerable<IdentityRole> Roles { get; set; }

        public void OnGet()
        {
            Roles = RoleManager.Roles;
        }

        public async Task<string> GetMembersString(string role)
        {
            IEnumerable<ApplicationUser> users = (await UserManager.GetUsersInRoleAsync(role));
            string result = users.Count() == 0
                ? "No members"
                : string.Join(", ", users.Take(3).Select(u => u.UserName).ToArray());
            return users.Count() > 3 ? $"{result}, (plus others)" : result;
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            IdentityRole role = await RoleManager.FindByIdAsync(id);
            await RoleManager.DeleteAsync(role);
            return RedirectToPage();
        }
    }
}
