using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using IdentityApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityApp.Pages.Users
{
    public class EditorModel : AdminPageModel
    {
        public UserManager<ApplicationUser> UserManager;

        public EditorModel(UserManager<ApplicationUser> usrManager)
        {
            UserManager = usrManager;
        }

        [BindProperty]
        [Required]
        public string Id { get; set; }

        [BindProperty]
        [Required]
        public string UserName { get; set; }

        [BindProperty]
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public async Task OnGetAsync(string id)
        {
            ApplicationUser user = await UserManager.FindByIdAsync(id);
            Id = user.Id; UserName = user.UserName; Email = user.Email;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = await UserManager.FindByIdAsync(Id);
                user.UserName = UserName;
                user.Email = Email;
                IdentityResult result = await UserManager.UpdateAsync(user);
                if (result.Succeeded && !String.IsNullOrEmpty(Password))
                {
                    await UserManager.RemovePasswordAsync(user);
                    result = await UserManager.AddPasswordAsync(user, Password);
                }
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
