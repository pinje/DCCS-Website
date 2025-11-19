using System.ComponentModel.DataAnnotations;

namespace DCCS.Pages.ViewModels
{
    public class CreateTeamViewModel
    {
        public CreateTeamViewModel() { }

        [Required]
        [StringLength(30, ErrorMessage = "Max 30 characters")]
        [RegularExpression(@"^[\w ]+$", ErrorMessage = "Please enter valid letters or numbers only")]
        public string TeamName { get; set; }
        [Required]
        [StringLength(150, ErrorMessage = "Max 150 characters")]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Please enter valid letters")]
        public string University { get; set; }
        [Required]
        [Url]
        [ContainsWord("faceit")]
        [StringLength(255, ErrorMessage = "Max 255 characters")]
        public string FaceitURL { get; set; }
        [StringLength(100, ErrorMessage = "Max 100 characters")]
        [RegularExpression(@"^[\w ]+$", ErrorMessage = "Please enter valid letters or numbers only")]
        public string? AssociationName { get; set; }
    }
}
