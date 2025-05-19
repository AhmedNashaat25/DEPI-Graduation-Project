using System.Security.Claims;
using CurvaHagz.Bussines.App;
using CurvaHagz.Models.App;
using CurvaHAgz.Web.App.Helper;
using CurvaHAgz.Web.App.Models;
using CurvaHAgz.Web.App.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CurvaHAgz.Web.App.Controllers
{
    public class PlaygroundController : Controller
    {
        private UserManager<User> _UserManager { get; set; }
        private PlaygroundManager _PlaygroundManager { get; set; }
        private BookingManager _BookingManager { get; set; }
        public PlaygroundController(UserManager<User> userManager, PlaygroundManager playgroundManager, BookingManager bookingManager)
        {
            _UserManager = userManager;
            _PlaygroundManager = playgroundManager;
            _BookingManager = bookingManager;
        }

        public IActionResult Index()
        { 
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }
        public async Task<IActionResult> GetAll()
        {
            string userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value;
            User user = await _UserManager.Users.FirstOrDefaultAsync(u => u.Id.ToString() == userId);
            ViewBag.Owner = user.IsOwner;
            ViewBag.City = user.City;
            List<PlayGround> playGrounds = _PlaygroundManager.GetAll();
            List<GetAllPlaygroundVm> Model = new List<GetAllPlaygroundVm>();
            foreach (PlayGround playGround in playGrounds)
            {
                GetAllPlaygroundVm vm = new GetAllPlaygroundVm();
                vm.PlaygroundId = playGround.PlaygroundId;
                vm.PlaygroundName = playGround.PlaygroundName;
                vm.Government = playGround.Government;
                vm.HourlyPrice = playGround.HourlyPrice;
                Model.Add(vm);
            }
            return View(Model);
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add(AddPlaygroundVm Model)
        {
            string userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value;
            User user = await _UserManager.Users.FirstOrDefaultAsync(u => u.Id.ToString() == userId);
            if (user == null)
            {
                return View("LogIn");
            }
            PlayGround playGround = new PlayGround();
            playGround.PlaygroundName = Model.PlaygroundName;
            playGround.Address = Model.Address;
            playGround.City = Model.City;
            playGround.Government = Model.Government;
            playGround.Width = Model.Width;
            playGround.Length = Model.Length;
            playGround.CancelationPolicy = Model.CancelationPolicy; 
            playGround.AvailableForWomen = Model.AvailableForWomen;
            playGround.HourlyPrice = Model.HourlyPrice;
            playGround.DepositeAmount = Model.DepositeAmount;
            playGround.ContactNumber = Model.ContactNumber;
            playGround.OwnerId = user.Id;
            playGround.SurfaceType = Model.SurfaceType;
            playGround.OpeningHour = Model.OpeningHour;
            playGround.ClosingHour = Model.ClosingHour;
            playGround.Feature1 = Model.Feature1;
            playGround.Feature2 = Model.Feature2;
            playGround.Feature3 = Model.Feature3;
            playGround.Feature4 = Model.Feature4;
            playGround.Feature5 = Model.Feature5;
            playGround.Feature6 = Model.Feature6;
            playGround.Description = Model.Description;
            _PlaygroundManager.Add(playGround);
            return View();
        }
        public async Task<IActionResult> Update(int PlaygroundID)
        {
            string userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value;
            User user = await _UserManager.Users.FirstOrDefaultAsync(u => u.Id.ToString() == userId);
            if (user == null)
            {
                return View("LogIn");
            }
            PlayGround playGround = _PlaygroundManager.GetPlayground(PlaygroundID);
            UpdatePlaygroundVm Model = new UpdatePlaygroundVm();
            Model.Id = PlaygroundID;
            Model.PlaygroundName = playGround.PlaygroundName;
            Model.Address = playGround.Address;
            Model.City = playGround.City;
            Model.Government = playGround.Government;
            Model.Width = playGround.Width;
            Model.Length = playGround.Length;
            Model.CancelationPolicy = playGround.CancelationPolicy;
            Model.AvailableForWomen = playGround.AvailableForWomen;
            Model.HourlyPrice = playGround.HourlyPrice;
            Model.DepositeAmount = playGround.DepositeAmount;
            Model.ContactNumber = playGround.ContactNumber;
            Model.SurfaceType = playGround.SurfaceType;
            Model.OpeningHour = playGround.OpeningHour;
            Model.ClosingHour = playGround.ClosingHour;
            Model.Feature1 = playGround.Feature1;
            Model.Feature2 = playGround.Feature2;
            Model.Feature3 = playGround.Feature3;
            Model.Feature4 = playGround.Feature4;
            Model.Feature5 = playGround.Feature5;
            Model.Feature6 = playGround.Feature6;
            Model.Description = playGround.Description;
            return View(Model);
        }
        [HttpPost]
        public IActionResult Edit(UpdatePlaygroundVm Model)
        {
            PlayGround playGround = _PlaygroundManager.GetPlayground(Model.Id);
            playGround.PlaygroundName = Model.PlaygroundName;
            playGround.Address = Model.Address;
            playGround.City = Model.City;
            playGround.Government = Model.Government;
            playGround.Width = Model.Width;
            playGround.Length = Model.Length;
            playGround.CancelationPolicy = Model.CancelationPolicy;
            playGround.AvailableForWomen = Model.AvailableForWomen;
            playGround.HourlyPrice = Model.HourlyPrice;
            playGround.DepositeAmount = Model.DepositeAmount;
            playGround.ContactNumber = Model.ContactNumber;
            playGround.SurfaceType = Model.SurfaceType;
            playGround.OpeningHour = Model.OpeningHour;
            playGround.ClosingHour = Model.ClosingHour;
            playGround.Feature1 = Model.Feature1;
            playGround.Feature2 = Model.Feature2;
            playGround.Feature3 = Model.Feature3;
            playGround.Feature4 = Model.Feature4;
            playGround.Feature5 = Model.Feature5;
            playGround.Feature6 = Model.Feature6;
            playGround.Description = Model.Description;
            _PlaygroundManager.Update(playGround);
            return RedirectToAction("GetAll");
        }
        public async Task<IActionResult> GetOwnerPlaygrounds(PlayerProfileVm Model)
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            User user = await _UserManager.Users.FirstOrDefaultAsync(u => u.Id.ToString() == userId);
            if (user == null)
            {
                return View("LogIn");
            }
            List<PlayGround> playGrounds=_PlaygroundManager.GetOwnerPlaygrounds(user.Id);
            Model.OwnerPlaygrounds = playGrounds;
            return View(Model);
        }

        public async Task<IActionResult> PlayGroundDetails(PlaygroundDetailsVm Model)
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            User user = await _UserManager.Users.FirstOrDefaultAsync(u => u.Id.ToString() == userId);
            ViewBag.Owner = user.IsOwner;
            if (user == null)
            {
                return View("LogIn");
            }
            Model.BookingStart = Model.BookingDate.Date.AddHours(Model.BookingTimeHour);
            PlayGround playGround = _PlaygroundManager.GetPlayground(Model.PlaygroundId);
            Model.PlaygroundName = playGround.PlaygroundName;
            Model.PlaygroundId = playGround.PlaygroundId;
            Model.HourlyPrice = playGround.HourlyPrice;
            Model.Government = playGround.Government;
            Model.Address = playGround.Address;
            Model.City = playGround.City;
            Model.Length = playGround.Length;
            Model.Width = playGround.Width;
            Model.AvailableForWomen = playGround.AvailableForWomen;
            Model.ContactNumber = playGround.ContactNumber;
            Model.DepositeAmount = playGround.DepositeAmount;
            Model.CancelationPolicy = playGround.CancelationPolicy;
            Model.OpeningHour = playGround.OpeningHour;
            Model.ClosingHour = playGround.ClosingHour;
            Model.Description = playGround.Description;
            Model.Feature1 = playGround.Feature1;
            Model.Feature2 = playGround.Feature2;
            Model.Feature3 = playGround.Feature3;
            Model.Feature4 = playGround.Feature4;
            Model.Feature5 = playGround.Feature5;
            Model.Feature6 = playGround.Feature6;
            Model.PlaygroundBookings=_BookingManager.GetPlaygroundBookings(playGround.PlaygroundId);
            return View(Model); 
        }

        [HttpPost]
        public async Task<IActionResult> BookPlayground(PlaygroundDetailsVm Model)
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = await _UserManager.FindByIdAsync(userId);

            if (Model.BookingDate == default)
            {
                Model.BookingDate = DateTime.Today;
            }

            Model.BookingStart = Model.BookingDate.Date.AddHours(Model.BookingTimeHour);
            var playground = _PlaygroundManager.GetPlayground(Model.PlaygroundId);

            DateTime newBookingEnd = Model.BookingStart.AddHours(Model.Duration);

            List<Booking> bookings = _BookingManager.GetPlaygroundBookings(playground.PlaygroundId);
            foreach (Booking existingBooking in bookings)
            {
                if ((Model.BookingStart >= existingBooking.StartTime && Model.BookingStart < existingBooking.EndTime) ||
                    (newBookingEnd > existingBooking.StartTime && newBookingEnd <= existingBooking.EndTime) ||
                    (Model.BookingStart <= existingBooking.StartTime && newBookingEnd >= existingBooking.EndTime))
                {
                    TempData["BookingError"] = $"This time slot conflicts with an existing booking from {existingBooking.StartTime:HH:mm} to {existingBooking.EndTime:HH:mm}. Please select a different time.";
                    return RedirectToAction("PlayGroundDetails", new { PlaygroundId = Model.PlaygroundId });
                }
            }

            Booking booking = new Booking
            {
                PlayerId = user.Id,
                PlaygroundId = Model.PlaygroundId,
                StartTime = Model.BookingStart,
                EndTime = newBookingEnd,
                TotalPrice = playground.HourlyPrice * Model.Duration,
            };

            _BookingManager.Add(booking);

            var selectedBooking = new SelectedBooking
            {
                PlayGroundId = Model.PlaygroundId,
                Duration = Model.Duration
            };

            List<SelectedBooking> cart = WorkingWithSession.GetObjectFromJson<List<SelectedBooking>>(HttpContext.Session, "cart") ?? new List<SelectedBooking>();
            cart.Add(selectedBooking);
            WorkingWithSession.SetObjectasJson(HttpContext.Session, "cart", cart);

            TempData["TotalAmount"] = (int)(booking.TotalPrice * 100); // in qirsh
            TempData["TotalDuration"] = Model.Duration;

            return RedirectToAction("Index", "Checkout");
        }

    }
}
