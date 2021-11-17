using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using IdentityApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityApp.Pages.Roles
{
    public class CreateModel : AdminPageModel
    {

        public RoleManager<IdentityRole> RoleManager;

        public CreateModel(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            RoleManager = roleManager;
        }

        [BindProperty]
        [Required]
        public string Name { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                IdentityRole role = new IdentityRole { Name = Name };
                IdentityResult result = await RoleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToPage("List");
                }
                foreach (IdentityError err in result.Errors)
                {
                    ModelState.AddModelError("", err.Description);
                }
            }
            return Page();
        }
    }
}
