using DAL.DiscordBranch;
using DAL.ParticipationBranch;
using DAL.SeasonBranch;
using DAL.TeamBranch;
using DAL.UserBranch;
using DLL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.ParticipationBranch;
using Models.TeamBranch;
using Models.UserBranch;
using System.Security.Claims;

namespace DCCS.Pages
{
    [Authorize(AuthenticationSchemes = "Discord")]
    public class ParticipationConfirmationModel : PageModel
    {
        [BindProperty]
        public List<Participation> Participations { get; set; }
        [BindProperty]
        public List<Team> Teams { get; set; }
        [BindProperty]
        public List<List<User>> Users { get; set; }

        ParticipationManager participationManager = new ParticipationManager(new ParticipationDAL());
        SeasonManager seasonManager = new SeasonManager(new SeasonDAL());
        TeamManager teamManager = new TeamManager(new TeamDAL());
        UserManager userManager = new UserManager(new UserDAL());
        APIManager apiManager = new APIManager(new DiscordAPI());

        public IActionResult OnGet()
        {
            // check if admin or not
            if (!userManager.IsAdmin(User.FindFirstValue(ClaimTypes.NameIdentifier).ToString()))
            {
                return RedirectToPage("/AccessDenied");
            }

            // get participations
            Participations = participationManager.GetParticipations();
            Teams = new List<Team>();
            Users = new List<List<User>>();

            foreach(var participation in Participations)
            {
                // get tournament name
                seasonManager.GetSeason(participation.TournamentId);

                // get team everything
                Teams.Add(teamManager.GetTeam(participation.TeamId.ToString()));

                // get team members details
                Users.Add(userManager.GetUsersInTeam(participation.TeamId.ToString()));
            }

            return null;
        }

        public IActionResult OnPostAccept()
        {
            string teamId = Request.Form["buttonValue"];
            string captain = teamManager.GetCaptainId(teamId);

            int participationId = Convert.ToInt16(Request.Form["buttonValue1"]);

            // update participation to accepted
            participationManager.UpdateStatus(participationId);

            // discord dm
            apiManager.DM(captain, ":white_check_mark: Your tournament participation request has been accepted.");

            return RedirectToPage("/ParticipationConfirmation");
        }

        public IActionResult OnPostDeny()
        {
            string teamId = Request.Form["buttonValue"];
            string captain = teamManager.GetCaptainId(teamId);

            int participationId = Convert.ToInt16(Request.Form["buttonValue1"]);

            // delete participation
            participationManager.Delete(participationId);

            // discord dm
            apiManager.DM(captain, ":x: Your tournament participation request has been rejected.");

            return RedirectToPage("/ParticipationConfirmation");

        }
    }
}
