using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Drawing.Imaging;
using System.Security.Claims;

namespace DCCS.Pages
{
    [Authorize(AuthenticationSchemes = "Discord")]
    public class EditPictureModel : PageModel
    {
        [BindProperty]
        [AllowedExtensions(new string[] { ".png" })]
        public IFormFile Picture { get; set; }

        private IWebHostEnvironment _environment;
        public EditPictureModel(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public IActionResult OnGet(long userid)
        {
            if (userid.ToString() != User.FindFirstValue(ClaimTypes.NameIdentifier))
            {
                return RedirectToPage("AccessDenied");
            } else
            {
                return null;
            }
        }

        public async Task<IActionResult> OnPost(long userid)
        {
            if (ModelState.IsValid)
            {
                // change photo filename to id.png 
                string picture = userid + ".png";

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

                return RedirectToPage("/Success");
            } else
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
