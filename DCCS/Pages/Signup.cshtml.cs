using DAL.DiscordBranch;
using DAL.UserBranch;
using DCCS.Pages.ViewModels;
using DLL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.UserBranch;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Drawing.Imaging;
using System.Security.Claims;

namespace DCCS.Pages
{
    [Authorize(AuthenticationSchemes = "Discord")]
    public class SignupModel : PageModel
    {
        [BindProperty]
        public RegisterUserViewModel RegisterUserViewModel { get; set; }
        [BindProperty]
        public string Country { get; set; }
        [BindProperty]
        public string Role { get; set; }
        [BindProperty]
        public string AspectRatio { get; set; }
        [BindProperty]
        public string ScalingMode { get; set; }
        [BindProperty]
        public bool rulebookRead { get; set; }

        //[BindProperty]
        //[AllowedExtensions(new string[] { ".png" })]
        //public IFormFile StudentCardPicture { get; set; }

        [BindProperty]
        [AllowedExtensions(new string[] { ".png" })]
        public IFormFile Picture { get; set; }

        private IWebHostEnvironment _environment;
        public SignupModel(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        UserManager userManager = new UserManager(new UserDAL());
        APIManager apiManager = new APIManager(new DiscordAPI());

        public IActionResult OnGet()
        {
            // check if user is alraedy registered
            var discordId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userManager.AlreadyRegistered(discordId))
            {
                return RedirectToPage("/AccessDenied");
            } else
            {
                return Page();
            }
        }

        public async Task<IActionResult> OnPost()
        {
            if (!rulebookRead)
            {
                ModelState.AddModelError("rulebook", $"You must acknowledge that you have read and understood the DCCS rulebook by checking the designated box. Please review the rulebook and try again.");
            }

            // check for empty fields
            if (string.IsNullOrEmpty(RegisterUserViewModel.Firstname))
            {
                RegisterUserViewModel.Firstname = "-";
            }

            if (string.IsNullOrEmpty(RegisterUserViewModel.Lastname))
            {
                RegisterUserViewModel.Lastname = "-";
            }

            if (string.IsNullOrEmpty(RegisterUserViewModel.Studies))
            {
                RegisterUserViewModel.Studies = "-";
            }

            if (string.IsNullOrEmpty(RegisterUserViewModel.Resolution))
            {
                RegisterUserViewModel.Resolution = "-";
            }

            if (string.IsNullOrEmpty(RegisterUserViewModel.Mouse))
            {
                RegisterUserViewModel.Mouse = "-";
            }

            if (string.IsNullOrEmpty(RegisterUserViewModel.Dpi))
            {
                RegisterUserViewModel.Dpi = "-";    
            }

            if (string.IsNullOrEmpty(RegisterUserViewModel.Sensitivity))
            {
                RegisterUserViewModel.Sensitivity = "-";
            }

            if (string.IsNullOrEmpty(RegisterUserViewModel.ZoomSensitivity))
            {
                RegisterUserViewModel.ZoomSensitivity = "-";
            }

            if (string.IsNullOrEmpty(RegisterUserViewModel.CrosshairCode))
            {
                RegisterUserViewModel.CrosshairCode = "-";
            }

            if (ModelState.IsValid)
            {
                var discordId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                // change photo filename to id_proof.png 
                //string studentCard = discordId + "_proof.png";

                //var studentCardFile = Path.Combine(_environment.ContentRootPath, "wwwroot/image/student_card", studentCard);
                //using (var fileStream = new FileStream(studentCardFile, FileMode.Create))
                //{
                //    // Convert the FormFile to a Stream and resize the student card picture
                //    using (var stream = StudentCardPicture.OpenReadStream())
                //    using (var image = Image.FromStream(stream))
                //    {
                //        var resizedImage = new Bitmap(image, new Size(200, 200));
                //        resizedImage.Save(fileStream, ImageFormat.Png);
                //    }
                //}

                // change photo filename to id.png 
                string picture = discordId + ".png";

                var pictureFile = Path.Combine(_environment.ContentRootPath, "wwwroot/image/picture", picture);
                using (var fileStream = new FileStream(pictureFile, FileMode.Create))
                {
                    // Convert the FormFile to a Stream and resize the picture
                    using (var stream = Picture.OpenReadStream())
                    using (var image = Image.FromStream(stream))
                    {
                        var resizedImage = new Bitmap(image, new Size(400, 400));
                        resizedImage.Save(fileStream, ImageFormat.Png);
                    }
                }

                // store data to db
                User user = new User(discordId, RegisterUserViewModel.SteamId, User.FindFirstValue("urn:discord:discriminator").ToString(), User.Identity.Name, RegisterUserViewModel.IGN, "", "-", RegisterUserViewModel.Firstname, RegisterUserViewModel.Lastname, 
                    Convert.ToDateTime(RegisterUserViewModel.Birthday), Country, RegisterUserViewModel.University, RegisterUserViewModel.Studies, RegisterUserViewModel.FaceitURL,
                    Role, AspectRatio, RegisterUserViewModel.Resolution, ScalingMode, RegisterUserViewModel.Mouse, RegisterUserViewModel.Dpi, RegisterUserViewModel.Sensitivity,
                    RegisterUserViewModel.ZoomSensitivity, RegisterUserViewModel.CrosshairCode);
                userManager.AddUser(user);

                // send a dm
                apiManager.DM(discordId, ":arrows_counterclockwise: Your registration request has been submitted and it is currently pending admin approval. Please allow some time for admins to review your request. If your request has not been processed within 24 hours, please feel free to contact an admin.");

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
