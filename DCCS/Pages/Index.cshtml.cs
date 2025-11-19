using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace DCCS.Pages
{
    [AllowAnonymous]
    [Authorize(AuthenticationSchemes = "Discord")]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            var discordId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}