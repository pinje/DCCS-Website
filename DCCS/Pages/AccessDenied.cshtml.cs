using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DCCS.Pages
{
    [Authorize(AuthenticationSchemes = "Discord")]
    public class AccessDeniedModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
