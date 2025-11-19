using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DCCS.Pages
{
    [AllowAnonymous]
    [Authorize(AuthenticationSchemes = "Discord")]
    public class AboutModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
