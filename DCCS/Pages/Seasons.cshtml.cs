using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DLL;
using DAL.SeasonBranch;
using Models.SeasonBranch;
using Microsoft.AspNetCore.Authorization;

namespace DCCS.Pages
{
    [AllowAnonymous]
    [Authorize(AuthenticationSchemes = "Discord")]
    public class SeasonsModel : PageModel
    {
        SeasonManager seasonManager = new SeasonManager(new SeasonDAL());
        [BindProperty]
        public List<Season> seasons { get; set; }

        public void OnGet()
        {
            seasons = seasonManager.GetAllSeasons();
        }
    }
}
