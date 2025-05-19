using CurvaHagz.Bussines.App;
using CurvaHagz.Models.App;
using CurvaHAgz.Web.App.Services;
using CurvaHAgz.Web.App.ViewModels;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace CurvaHAgz.Web.App.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<User> _UserManager;
        private SignInManager<User> _SignInManager;
        private TeamsManager _TeamsManager;
        private PlaygroundManager _PlaygroundManager;
        private BookingManager _BookingManager;
        private readonly IWebHostEnvironment _WebHostEnvironment;
        private readonly IEmailService _EmailService;
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, TeamsManager teamsManager, PlaygroundManager playgroundManager, BookingManager bookingManager ,IWebHostEnvironment webHostEnvironment , IEmailService emailService)
        {
            _UserManager = userManager;
            _SignInManager = signInManager;
            _TeamsManager = teamsManager;
            _PlaygroundManager = playgroundManager;
            _BookingManager = bookingManager;
            _WebHostEnvironment = webHostEnvironment;
            _EmailService = emailService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(UserSignUpVm Model)
        {
            if (ModelState.IsValid)
            {
                var email = Model.Email.Trim();
                var checkEmail = await _UserManager.Users
                .FirstOrDefaultAsync(u =>
                    EF.Functions.Collate(u.Email, "Latin1_General_CS_AS") == email);

                if (checkEmail != null)
                {
                    ModelState.AddModelError(nameof(UserSignUpVm.Email), "This email address is already registered.");
                    return View(Model);
                }


                else
                {
                    User user = new User();
                    user.FName = Model.FName;
                    user.MName = Model.MName;
                    user.LName = Model.LName;
                    user.Email = Model.Email;
                    user.Phone = Model.Phone;
                    user.Gender = Model.Gender;
                    user.Government = Model.Government;
                    user.City = Model.City;
                    user.Address = Model.Address;
                    user.IsOwner = Model.IsOwner;
                    user.UserName = Guid.NewGuid().ToString();

                    IdentityResult result = await _UserManager.CreateAsync(user, Model.Password);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("LogIn");
                    }
                    ModelState.AddModelError(nameof(UserSignUpVm.Password), "Invalid Password");
                    return View(Model);
                }
            }
            else 
            { 

                return View(Model);
            }
        }
        public IActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LogIn(UserLogInVm model)
        {
            User user=await _UserManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                ModelState.AddModelError(nameof(UserLogInVm.Email), "Email isn't found");
                return View(model); 
            }
            bool CheckPass=await _UserManager.CheckPasswordAsync(user, model.Password);
            if (CheckPass)
            {
                await _SignInManager.SignInAsync(user, true);
                return RedirectToAction("PlayerProfile");
            }
            ModelState.AddModelError(nameof(UserLogInVm.Password), "Wrong Password");
            return View(model);
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> PlayerProfile()
        {
            string userId= User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value;
            User user = await _UserManager.Users.FirstOrDefaultAsync(u => u.Id.ToString() == userId);
            if (user == null) return View("LogIn");
            PlayerProfileVm vm = new PlayerProfileVm();
            vm.Email = user.Email;
            vm.FullName=user.FName+' '+user.MName+' '+user.LName;
            vm.Phone= user.Phone;
            vm.FName = user.FName;
            vm.LName = user.LName;
            vm.ProfileImagePath = user.ProfileImagePath;
            ViewBag.IsOwner=user.IsOwner;
            if (user.IsOwner==IsOwner.Owner)
            {
                List<PlayGround> playGrounds = _PlaygroundManager.GetOwnerPlaygrounds(user.Id);
                vm.OwnerPlaygrounds = playGrounds;
            }
            else
            {
                vm.PlayerBookings = _BookingManager.GetPlayerBookings(user.Id);
            }
            return View(vm);
        }
        public async Task<IActionResult> Logout()
        {
            await _SignInManager.SignOutAsync();
            return View("LogIn");
        }
        public async Task<IActionResult> UploadProfilePhoto(IFormFile ProfileImage)
        {
            string userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value;
            User user = await _UserManager.Users.FirstOrDefaultAsync(u => u.Id.ToString() == userId);

            if (ProfileImage != null && ProfileImage.Length > 0)
            {
                string uploadsFolder = Path.Combine(_WebHostEnvironment.WebRootPath, "uploads");
                Directory.CreateDirectory(uploadsFolder);

                string uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(ProfileImage.FileName);
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await ProfileImage.CopyToAsync(stream);
                }

                user.ProfileImagePath = "~/uploads/" + uniqueFileName;
                await _UserManager.UpdateAsync(user);
            }

            return RedirectToAction("PlayerProfile");

        }
        public IActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            var user = await _UserManager.FindByEmailAsync(email);
            if (user == null)
            {
                return View("ResetLinkSent"); // Always show success message to avoid leaking info
            }

            var token = await _UserManager.GeneratePasswordResetTokenAsync(user);
            var resetLink = Url.Action("ResetPassword", "Account", new { token, email = user.Email }, Request.Scheme);

            // Send email here (replace with your email sending logic)
            await _EmailService.SendAsync(user.Email, "Password Reset", $"Reset your password: <a href='{resetLink}'>click here</a>");

            return View("ResetLinkSent");
        }


        [HttpGet]
        public IActionResult ResetPassword(string token, string email)
        {
            if (string.IsNullOrEmpty(token) || string.IsNullOrEmpty(email))
            {
                // If the token or email is missing, redirect to an error or info page
                return RedirectToAction("ForgotPassword"); // Or create a custom error view
            }

            // If token and email are provided, show the reset form
            return View(new ResetPasswordViewModel { Token = token, Email = email });
        }


        [HttpPost]
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = await _UserManager.FindByEmailAsync(model.Email);
            if (user == null)
                return RedirectToAction("Login", "Account");

            var result = await _UserManager.ResetPasswordAsync(user, model.Token, model.NewPassword);
            if (result.Succeeded)
            {
                await _SignInManager.SignOutAsync();
                TempData["Message"] = "Password reset successful. Please log in.";
                return RedirectToAction("Login", "Account");
            }

            foreach (var error in result.Errors)
                ModelState.AddModelError(string.Empty, error.Description);

            return View(model);
        }
    }
}
