using DAL.UserBranch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using DLL;
using Microsoft.AspNetCore.Authorization;
using DAL.InvitationBranch;
using DAL.TeamBranch;
using DAL.DiscordBranch;
using Models.UserBranch;
using Models.TeamBranch;

namespace DCCS.Pages
{
    [AllowAnonymous]
    [Authorize(AuthenticationSchemes = "Discord")]
    public class ProfileModel : PageModel
    {
        [BindProperty]
        public string Status { get; set; }
        [BindProperty]
        public List<List<string>> Invites { get; set;}
        [BindProperty]
        public User user { get; set; }
        [BindProperty]
        public string TeamName { get; set; }
        [BindProperty]
        public string TeamId { get; set; }
        [BindProperty]
        public bool sameUser { get; set; }
        [BindProperty]
        public List<Team> TeamsOwned { get; set; }
        [BindProperty]
        public int Age { get; set; }
        [BindProperty]
        public bool captain { get; set; }

        private IWebHostEnvironment _environment;
        public ProfileModel(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        UserManager userManager = new UserManager(new UserDAL());
        InvitationManager invitationManager = new InvitationManager(new InvitationDAL());
        TeamManager teamManager = new TeamManager(new TeamDAL());
        APIManager apiManager = new APIManager(new DiscordAPI());

        public IActionResult OnGet(long userid)
        {
            if (userid.ToString() != User.FindFirstValue(ClaimTypes.NameIdentifier))
            {
                sameUser = false;
            } else
            {
                sameUser = true;
            }

            string discordId = userid.ToString();
            Status = userManager.UserStatus(discordId);

            if (Status == "accepted")
            {
                // get user details
                user = userManager.GetUser(discordId);

                // get age
                TimeSpan difference = DateTime.Now.Subtract((DateTime)user.Birthday);
                double days = difference.TotalDays;
                Age = (int)(days / 365.25);

                // get team name
                if (user.TeamId == "")
                {
                    TeamName = "No Team";
                    captain = false;
                } else
                {
                    TeamName = teamManager.GetTeamName(user.TeamId);
                    TeamId = user.TeamId;

                    // get captain or not
                    string captainId = teamManager.GetCaptainId(user.TeamId);
                    if (captainId == user.DiscordId)
                    {
                        captain = true;
                    }
                    else
                    {
                        captain = false;
                    }
                }
                
                Invites = new List<List<string>>();

                // get invites
                List<string> invites = invitationManager.GetInvitations(discordId);

                if (invites.Count > 0)
                {
                    foreach (var invitation in invites)
                    {
                        string teamname = teamManager.GetTeamName(invitation.ToString());
                        List<string> invite = new List<string>
                    {
                        invitation.ToString(),
                        teamname
                    };
                        Invites.Add(invite);
                    }
                }

                // get teams
                TeamsOwned = teamManager.GetTeamsOwned(discordId);
            }

            return null;
        }

        public IActionResult OnPostLeaveTeam(long userid)
        {
            var discordId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string teamId = Request.Form["buttonValue"];

            // remove team
            userManager.UpdateUserTeam(discordId, null);

            // discord dm
            string teamname = teamManager.GetTeamName(teamId.ToString());
            apiManager.DM(discordId, ":white_check_mark: You left team \"" + teamname + "\".");

            return RedirectToPage("/Profile", userid);
        }

        public IActionResult OnPostAccept(long userid)
        {
            // check limit
            var discordId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string teamId = Request.Form["buttonValue"];

            if (teamManager.GetTeamMembers(teamId.ToString()).Count > 7)
            {
                // not allowed
                apiManager.DM(discordId, ":x: Cannot join team. Team is full (max 7 players).");

                // delete invitation
                invitationManager.Delete(discordId, teamId);

                return RedirectToPage("/Profile", userid);
            } else
            {
                // add team
                userManager.UpdateUserTeam(discordId, teamId);

                // delete invitation from db
                invitationManager.Delete(discordId, teamId);

                // discord dm
                string teamname = teamManager.GetTeamName(teamId.ToString());
                apiManager.DM(discordId, ":white_check_mark: You joined team \"" + teamname + "\".");

                return RedirectToPage("/Profile", userid);
            }
        }

        public IActionResult OnPostDeny(long userid)
        {
            var discordId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string teamId = Request.Form["buttonValue"];

            // delete invitation from db
            invitationManager.Delete(discordId, teamId);

            return RedirectToPage("/Profile", userid);
        }

        public IActionResult OnPostDelete(long userid)
        {
            string code = Request.Form["buttonValue"];
            User name = userManager.GetUser(userid.ToString());

            // check if code and team name matches
            if (code != name.Ign)
            {
                ModelState.AddModelError("rulebook", $"Does not match.");
                return RedirectToPage("/Profile", userid);
            }
            else
            {
                // delete picture
                string filename = userid + ".png";
                var file = Path.Combine(_environment.ContentRootPath, "wwwroot/image/picture/", filename);

                if (System.IO.File.Exists(file)) // Check if the file exists
                {
                    System.IO.File.Delete(file); // Delete the file
                }

                // delete proof picture
                string filenameproof = userid + "_proof.png";
                var fileproof = Path.Combine(_environment.ContentRootPath, "wwwroot/image/student_card/", filenameproof);

                if (System.IO.File.Exists(fileproof)) // Check if the file exists
                {
                    System.IO.File.Delete(fileproof); // Delete the file
                }

                // delete profile
                userManager.Delete(userid.ToString());

                // delete any invitations
                invitationManager.DeleteByUser(userid.ToString());

                // discord dm
                apiManager.DM(userid.ToString(), ":white_check_mark: Your profile has been deleted.");

                return RedirectToPage("/Success");
            }
        }

        public IActionResult OnPostEditPicture(long userid)
        {
            return RedirectToPage("/EditPicture", userid);
        }

        public IActionResult OnPostCreateTeam(long userid)
        {
            return RedirectToPage("/CreateTeam");
        }
    }
}
