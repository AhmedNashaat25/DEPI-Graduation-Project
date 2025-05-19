using System.ComponentModel.DataAnnotations;

namespace CurvaHAgz.Web.App.ViewModels
{
    public class UserLogInVm
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
