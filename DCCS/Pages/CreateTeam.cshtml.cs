using DCCS.Pages.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.UserBranch;
using Models.TeamBranch;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Security.Claims;
using System.Drawing;
using System.Drawing.Imaging;
using System.Security.Claims;
using DLL;
using DAL.TeamBranch;
using Microsoft.AspNetCore.Authorization;
using DAL.DiscordBranch;
using DAL.UserBranch;

namespace DCCS.Pages
{
    [Authorize(AuthenticationSchemes = "Discord")]
    public class CreateTeamModel : PageModel
    {
        [BindProperty]
        public CreateTeamViewModel CreateTeamViewModel { get; set; }
        [BindProperty]
        [AllowedExtensions(new string[] { ".png" })]
        public IFormFile TeamLogo { get; set; }
        [BindProperty]
        public bool rulebookRead { get; set; }
        [BindProperty]
        [Required]
        public string Represent { get; set; }

        private IWebHostEnvironment _environment;
        public CreateTeamModel(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        TeamManager teamManager = new TeamManager(new TeamDAL());
        APIManager apiManager = new APIManager(new DiscordAPI());
        UserManager userManager = new UserManager(new UserDAL());

        public IActionResult OnGet()
        {
            // check if member
            if (!userManager.AlreadyRegistered(User.FindFirstValue(ClaimTypes.NameIdentifier).ToString()))
            {
                return RedirectToPage("/Signup");
            } else
            {
                return null;
            }
        }

        public async Task<IActionResult> OnPost()
        {
            if (!rulebookRead)
            {
                ModelState.AddModelError("rulebook", $"You must acknowledge that you have read and understood the DCCS rulebook by checking the designated box. Please review the rulebook and try again.");
            }

            if (Represent == "-")
            {
                ModelState.AddModelError("rulebook", $"Please select whether the team is representing a university or an association.");
            }

            // check for empty fields
            //if (string.IsNullOrEmpty(CreateTeamViewModel.AssociationName))
            //{
            //    CreateTeamViewModel.AssociationName = "-";
            //}

            CreateTeamViewModel.AssociationName = "-";

            // check if team name is duplicate
            // get all team names
            List<string> teams = teamManager.GetTeamNames();

            // check duplicate
            foreach(string team in teams)
            {
                if (team == CreateTeamViewModel.TeamName)
                {
                    ModelState.AddModelError("rulebook", $"Team name already taken.");
                }
            }

            if (ModelState.IsValid)
            {
                var discordId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                // change photo filename to id.png 
                string picture = CreateTeamViewModel.TeamName + ".png";

                var pictureFile = Path.Combine(_environment.ContentRootPath, "wwwroot/image/team_logo", picture);
                using (var fileStream = new FileStream(pictureFile, FileMode.Create))
                {
                    // Convert the FormFile to a Stream and resize the picture
                    using (var stream = TeamLogo.OpenReadStream())
                    using (var image = Image.FromStream(stream))
                    {
                        var resizedImage = new Bitmap(image, new Size(500, 500));
                        resizedImage.Save(fileStream, ImageFormat.Png);
                    }
                }

                // store data to db
                Team team = new Team(CreateTeamViewModel.TeamName, CreateTeamViewModel.University, CreateTeamViewModel.FaceitURL, Represent, CreateTeamViewModel.AssociationName, discordId);
                teamManager.AddTeam(team);

                // add team id to user teamid
                // get team id
                string id = teamManager.GetTeamId(discordId, CreateTeamViewModel.TeamName);

                // add team id to user
                userManager.UpdateUserTeam(discordId, id);

                apiManager.DM(discordId, ":white_check_mark: Your team has been created. Invite players from your team page. You can access your team page from your profile.");
                return RedirectToPage("/Success");
            }
            else
            {
                return Page();
            }
        }

        public class AllowedExtensionsAttribute : ValidationAttribute
        {
            private readonly string[] _extensions;
            public AllowedExtensionsAttribute(string[] extensions)
            {
                _extensions = extensions;
            }

            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                var file = value as IFormFile;
                if (file != null)
                {
                    var extension = Path.GetExtension(file.FileName);
                    if (!_extensions.Contains(extension.ToLower()))
                    {
                        return new ValidationResult(GetErrorMessage());
                    }
                }

                return ValidationResult.Success;
            }

            public string GetErrorMessage()
            {
                return $"This image extension is not allowed. PNG file only.";
            }
        }

        [System.Runtime.Versioning.SupportedOSPlatform("windows")]
        public partial class ImageFileAttribute : ValidationAttribute
        {
            public int Width;
            public int Height;

            public override bool IsValid(object value)
            {
                var file = value as IFormFile;
                Image image = Image.FromStream(file.OpenReadStream());
                if (image == null)
                    return true;

                if (image.Width != Width)
                    return false;

                if (image.Height != Height)
                    return false;

                return true;
            }
        }
    }
}
