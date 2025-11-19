using DAL.UserBranch;
using DAL.DiscordBranch;
using DLL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.UserBranch;
using Discord;
using Discord.Net;
using Discord.WebSocket;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace DCCS.Pages
{
    [Authorize(AuthenticationSchemes = "Discord")]
    public class UserConfirmationModel : PageModel
    {
        UserManager userManager = new UserManager(new UserDAL());
        APIManager apiManager = new APIManager(new DiscordAPI());

        [BindProperty]
        public List<User> users { get; set; }

        public IActionResult OnGet()
        {
            // check if admin or not
            if (!userManager.IsAdmin(User.FindFirstValue(ClaimTypes.NameIdentifier).ToString())) {
                return RedirectToPage("/AccessDenied");
            }

            // get all pending users
            users = userManager.GetPendingUsers();

            return null;
        }

        public IActionResult OnPostAccept() {
            string discordId = Request.Form["buttonValue"];
            userManager.UpdateAccepted(discordId);
            apiManager.DM(discordId, ":white_check_mark: Your profile request has been accepted.");

            return RedirectToPage("/UserConfirmation");
        }

        public IActionResult OnPostDeny() {
            string discordId = Request.Form["buttonValue2"];

            apiManager.DM(discordId, ":x: Your profile request has been rejected. Create a new profile to access website functionalities.");

            // delete user
            userManager.Delete(discordId.ToString());

            return RedirectToPage("/UserConfirmation");
        }
    }
}
