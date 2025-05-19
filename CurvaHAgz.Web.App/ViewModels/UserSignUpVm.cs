using CurvaHagz.Models.App;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CurvaHAgz.Web.App.ViewModels
{
    public class UserSignUpVm
    {
        [Required]
        [RegularExpression("^[A-Z a-z]{2,20}$", ErrorMessage = "Invalid name")]
        public string FName { get; set; }
        [Required]
        [RegularExpression("^[A-Z a-z]{2,20}$", ErrorMessage = "Invalid name")]
        public string MName { get; set; }
        [Required]
        [RegularExpression("^[A-Z a-z]{2,20}$", ErrorMessage = "Invalid name")]
        public string LName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [RegularExpression("^01[0125][0-9]{8}$", ErrorMessage = "phone must be Egyptian")]
        public string Phone { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        [RegularExpression("^[A-Z a-z]{2,20}$", ErrorMessage = "Invalid city name")]
        public string City { get; set; }
        [Required]
        [RegularExpression("^[A-Z a-z]{2,20}$", ErrorMessage = "Invalid Government name")]
        public string Government { get; set; }
        [Required]
        [StringLength(100,MinimumLength =5,ErrorMessage ="Invalid address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        [Required]

        [Compare("Password", ErrorMessage = "Password mismatch")]
        public string ConfirmPassword { get; set; }
        [Required]
        public IsOwner IsOwner { get; set; }
    }
}
