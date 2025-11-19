using System.ComponentModel.DataAnnotations;

namespace DCCS.Pages.ViewModels
{
    public class RegisterUserViewModel
    {
        public RegisterUserViewModel()
        {

        }
        [Required]
        [StringLength(17, MinimumLength = 17, ErrorMessage = "SteamID64 has 17 digits")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Please enter valid numbers")]
        public string SteamId { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "Max 20 characters")]
        [RegularExpression(@"^[\w ]+$", ErrorMessage = "Please enter valid letters or numbers only")]
        public string IGN { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "Max 30 characters")]
        [RegularExpression(@"^[a-zA-ZÀ-ȕ ]+$", ErrorMessage = "Please enter valid letters")]
        public string? Firstname { get; set; }
        [StringLength(30, ErrorMessage = "Max 30 characters")]
        [RegularExpression(@"^[a-zA-ZÀ-ȕ ]+$", ErrorMessage = "Please enter valid letters")]
        public string? Lastname { get; set; }
        [Required]
        public string Birthday { get; set; }
        //[StringLength(20, ErrorMessage = "Max 20 characters")]
        //[RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Please enter valid letters")]
        //public string? Country { get; set; }
        [Required]
        [StringLength(150, ErrorMessage = "Max 150 characters")]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Please enter valid letters")]
        public string University { get; set; }
        [StringLength(200, ErrorMessage = "Max 200 characters")]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Please enter valid letters")]
        public string? Studies { get; set; }
        [Required]
        [Url]
        [ContainsWord("faceit")]
        [StringLength(255, ErrorMessage = "Max 255 characters")]
        public string FaceitURL { get; set; }
        [StringLength(20, ErrorMessage = "Max 20 characters")]
        public string? Resolution { get; set; }
        [StringLength(255, ErrorMessage = "Max 255 characters")]
        [RegularExpression(@"^[\w ]+$", ErrorMessage = "Please enter valid letters or numbers only.")]
        public string? Mouse { get; set; }
        [StringLength(5, ErrorMessage = "Max 5 numbers")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Please enter valid numbers")]
        public string? Dpi { get; set; }
        [StringLength(10, ErrorMessage = "Max 10 characters")]
        [RegularExpression("^[-+]?[0-9]*\\.?[0-9]+$", ErrorMessage = "Please enter a valid decimal number (add .00 for whole number e.g. 1.00)")]
        public string? Sensitivity { get; set; }
        [StringLength(10, ErrorMessage = "Max 10 characters")]
        [RegularExpression("^[-+]?[0-9]*\\.?[0-9]+$", ErrorMessage = "Please enter a valid decimal number (add .00 for whole number e.g. 1.00)")]
        public string? ZoomSensitivity { get; set; }
        [StringLength(150, ErrorMessage = "Max 150 characters")]
        public string? CrosshairCode { get; set; }
    }

    public class ContainsWordAttribute : ValidationAttribute
    {
        private readonly string _word;

        public ContainsWordAttribute(string word)
        {
            _word = word;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is string stringValue && stringValue.Contains(_word))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult($"The {validationContext.DisplayName} must contain the word '{_word}'.");
        }
    }
}
