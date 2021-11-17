using System.Collections.Generic;
using System.Threading.Tasks;
using IdentityApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityApp.Pages.Users
{
    public class ListModel : AdminPageModel
    {
        public UserManager<ApplicationUser> UserManager;

        public ListModel(UserManager<ApplicationUser> userManager)
        {
            UserManager = userManager;
        }

        public IEnumerable<ApplicationUser> Users { get; set; }

        public void OnGet()
        {
            Users = UserManager.Users;
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            ApplicationUser user = await UserManager.FindByIdAsync(id);
            if (user != null)
            {
                await UserManager.DeleteAsync(user);
            }
            return RedirectToPage();
        }
    }
}
