using DAL.DiscordBranch;
using DAL.InvitationBranch;
using DAL.ParticipationBranch;
using DAL.SeasonBranch;
using DAL.TeamBranch;
using DAL.UserBranch;
using DLL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.SeasonBranch;
using Models.TeamBranch;
using System.Security.Claims;
using Models.ParticipationBranch;
using System.Drawing;

namespace DCCS.Pages
{
    [Authorize(AuthenticationSchemes = "Discord")]
    public class SeasonModel : PageModel
    {
        SeasonManager seasonManager = new SeasonManager(new SeasonDAL());

        [BindProperty]
        public Season Season { get; set; }
        [BindProperty]
        public bool captain { get; set; }
        [BindProperty]
        public List<Team> Teams { get; set; }
        [BindProperty]
        public string team { get; set; }
        [BindProperty]
        public string Status { get; set; }

        [BindProperty]
        public List<Team> Participants { get; set; }


        public int seasonId;


        UserManager userManager = new UserManager(new UserDAL());
        TeamManager teamManager = new TeamManager(new TeamDAL());
        APIManager apiManager = new APIManager(new DiscordAPI());
        ParticipationManager participationManager = new ParticipationManager(new ParticipationDAL());

        public IActionResult OnGet(int seasonid)
        {
            // check if member
            if (!userManager.AlreadyRegistered(User.FindFirstValue(ClaimTypes.NameIdentifier).ToString()))
            {
                return RedirectToPage("/Signup");
            }

            // get participants
            List<Participation> participations = participationManager.GetParticipants(seasonid);

            Participants = new List<Team>();

            // convert participants list to team list
            foreach(var participant in participations)
            {
                // get team
                Team team = teamManager.GetTeam(participant.TeamId.ToString());
                Participants.Add(team);
            }

            seasonId = seasonid;
            Season = seasonManager.GetSeason(seasonId);

            string id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string teamid = userManager.GetUserTeamId(id);

            // check participation status
            Status = participationManager.GetStatus(teamid, seasonid);

            // check if captain
            if (userManager.IsCaptain(id))
            {
                captain = true;
            }
            else
            {
                captain = false;
            }

            if (captain && Status == "")
            {
                // get all teams owned
                Teams = teamManager.GetTeamsOwned(id);
            }

            return null;
        }

        public IActionResult OnPostParticipate(int seasonid)
        {
            // get team id
            int teamId = Convert.ToInt16(team);
            string name = teamManager.GetTeamName(teamId.ToString());
            Season = seasonManager.GetSeason(seasonid);

            // add participation
            participationManager.AddParticipation(new Participation(teamId, seasonid, "pending"));

            // discord dm
            apiManager.DM(User.FindFirstValue(ClaimTypes.NameIdentifier), ":white_check_mark: You have succesfully registered team " + name + " for " + Season.SeasonName + ". It is currently pending admin approval.");

            return RedirectToPage("/Success");
        }
    }
}
