using DAL.UserBranch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.UserBranch;
using DLL;
using DAL.InvitationBranch;
using System.Security.Claims;
using DAL.DiscordBranch;
using DAL.TeamBranch;
using Microsoft.AspNetCore.Authorization;
using Models.TeamBranch;
using System.Drawing;
using DAL.ParticipationBranch;

namespace DCCS.Pages
{
    [AllowAnonymous]
    [Authorize(AuthenticationSchemes = "Discord")]
    public class TeamModel : PageModel
    {
        [BindProperty]
        public List<User> users { get; set; }
        [BindProperty]
        public List<User> teamMembers { get; set; }
        [BindProperty]
        public string discordId { get; set; }
        [BindProperty]
        public string status { get; set; }
        [BindProperty]
        public bool captain { get; set; }
        [BindProperty]
        public string teamName { get; set;}
        [BindProperty]
        public string captainId { get; set; }

        private IWebHostEnvironment _environment;
        public TeamModel(IWebHostEnvironment environment)
        {
            _environment = environment;
        }


        UserManager userManager = new UserManager(new UserDAL());
        InvitationManager invitationManager= new InvitationManager(new InvitationDAL());
        APIManager apiManager = new APIManager(new DiscordAPI());
        TeamManager teamManager = new TeamManager(new TeamDAL());
        ParticipationManager participationManager = new ParticipationManager(new ParticipationDAL());

        public IActionResult OnGet(int teamId)
        {
            // check if team exists
            if (!teamManager.TeamExists(teamId.ToString()))
            {
                return RedirectToPage("/AccessDenied");
            }

            // get all accepted users
            users = userManager.GetFreeUsers();

            // get all team members
            teamMembers = teamManager.GetTeamMembers(teamId.ToString());

            // get team name
            teamName = teamManager.GetTeamName(teamId.ToString());

            // captain or not
            string id = teamManager.GetCaptainId(teamId.ToString());
            if (id != User.FindFirstValue(ClaimTypes.NameIdentifier))
            {
                captain = false;
            }
            else
            {
                captain = true;
            }

            // get captain id
            captainId = id;

            return null;
        }

        public IActionResult OnPostInvite(int teamId)
        {
            // check limit
            if (teamManager.GetTeamMembers(teamId.ToString()).Count > 7)
            {
                // not allowed
                apiManager.DM(captainId, ":x: Cannot invite more players. Team is full (max 7 players).");

                return RedirectToPage("/Team", teamId);
            } else
            {
                invitationManager.Invite(discordId, teamId.ToString());

                // send a discord dm notification
                apiManager.DM(discordId, ":envelope: You've been invited to a team. Check your profile page to accept or deny the invitation.");

                return RedirectToPage("/Team", teamId);
            }
        }

        public IActionResult OnPostChangeStatus(int teamId)
        {
            string targetId = Request.Form["buttonValue1"];
            userManager.UpdateUserStatus(targetId, status);

            return RedirectToPage("/Team", teamId);
        }

        public IActionResult OnPostKick(int teamId)
        {
            string targetId = Request.Form["buttonValue"];
            userManager.UpdateUserTeam(targetId, null);

            // discord dm
            string name = teamManager.GetTeamName(teamId.ToString());
            apiManager.DM(targetId, ":no_entry: You've been kicked from team \"" + name + "\".");

            return RedirectToPage("/Team", teamId);
        }

        public IActionResult OnPostDelete(int teamId)
        {
            string code = Request.Form["buttonValue"];
            string name = teamManager.GetTeamName(teamId.ToString());
            string id = User.FindFirstValue(ClaimTypes.NameIdentifier).ToString();

            // check if code and team name matches
            if (code != name)
            {
                ModelState.AddModelError("rulebook", $"Does not match.");
                return RedirectToPage("/Team", teamId);
            } else
            {
                // delete team logo
                string filename = name + ".png";
                var file = Path.Combine(_environment.ContentRootPath, "wwwroot/image/team_logo/", filename);

                if (System.IO.File.Exists(file)) // Check if the file exists
                {
                    System.IO.File.Delete(file); // Delete the file
                }

                // get all team members
                List<User> members = teamManager.GetTeamMembers(teamId.ToString());

                // delete captain from list
                string captain = teamManager.GetCaptainId(teamId.ToString());
                members.RemoveAll(user => user.DiscordId == captain);

                // for all team members, replace team 
                foreach(var member in members)
                {
                    userManager.UpdateUserTeam(member.DiscordId, null);
                }

                // check if captain was in that team
                if (userManager.GetUserTeamId(id) == teamId.ToString())
                {
                    // update user team to null
                    userManager.UpdateUserTeam(id, null);
                }

                // delete team
                teamManager.Delete(teamId.ToString());

                // delete any participations
                participationManager.DeleteByTeam(teamId.ToString());

                // discord dm
                apiManager.DM(captain, ":white_check_mark: Your team " + name + " has been deleted.");

                return RedirectToPage("/Success");
            }
        }
    }
}
