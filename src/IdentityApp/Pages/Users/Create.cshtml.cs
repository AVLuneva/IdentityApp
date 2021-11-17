using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using IdentityApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityApp.Pages.Users
{
    public class CreateModel : AdminPageModel
    {
        public UserManager<ApplicationUser> UserManager;

        public CreateModel(UserManager<ApplicationUser> usrManager)
        {
            UserManager = usrManager;
        }

        [BindProperty]
        [Required]
        public string UserName { get; set; }

        [BindProperty]
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [BindProperty]
        [Required]
        public string Password { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser { UserName = UserName, Email = Email };
                IdentityResult result = await UserManager.CreateAsync(user, Password);
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
