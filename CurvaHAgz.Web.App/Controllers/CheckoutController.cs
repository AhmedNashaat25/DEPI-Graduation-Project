using CurvaHAgz.Web.App.Helper;
using CurvaHAgz.Web.App.Models;
using CurvaHagz.Data.App;
using CurvaHagz.Models.App;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using Microsoft.EntityFrameworkCore;
using Stripe.Checkout;

namespace CurvaHAgz.Web.App.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly CurvaHagzContext _context;

        public CheckoutController(CurvaHagzContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var cart = WorkingWithSession.GetObjectFromJson<List<SelectedBooking>>(HttpContext.Session, "cart") ?? new List<SelectedBooking>();

            var playgroundIds = cart.Select(c => c.PlayGroundId).ToList();
            var playgrounds = _context.playGrounds
                                      .AsNoTracking()
                                      .Where(p => playgroundIds.Contains(p.PlaygroundId))
                                      .ToList();

            var viewModel = cart.Select(c => new
            {
                PlayGround = playgrounds.FirstOrDefault(p => p.PlaygroundId == c.PlayGroundId),
                Duration = c.Duration
            }).ToList();

            ViewBag.cart = viewModel;

            int total = (int)(viewModel.Sum(item => item.PlayGround.HourlyPrice * item.Duration));
            int totalDuration = viewModel.Sum(item => item.Duration);

            ViewBag.DollarAmount =(int) TempData["TotalAmount"]/100;
            ViewBag.TotalDuration = TempData["TotalDuration"];

            TempData["TotalAmount"] = total;
            TempData["TotalDuration"] = totalDuration;

            return View();
        }



        [HttpPost]
        public IActionResult CreateCheckoutSession()
        {
            var domain = "https://localhost:44352";
            if (!TempData.ContainsKey("TotalAmount"))
            {
                return RedirectToAction("Index");
            }

            var totalAmount = Convert.ToInt32(TempData["TotalAmount"]);
            var totalInPiasters = totalAmount * 100; // Stripe expects piasters, not EGP

            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string> { "card" },
                LineItems = new List<SessionLineItemOptions>
        {
            new SessionLineItemOptions
            {
                PriceData = new SessionLineItemPriceDataOptions
                {
                    Currency = "egp",
                    UnitAmount = totalInPiasters, // total amount, not per unit
                    ProductData = new SessionLineItemPriceDataProductDataOptions
                    {
                        Name = "Playground Booking"
                    }
                },
                Quantity = 1 // we charge for 1 total booking
            }
        },
                Mode = "payment",
                SuccessUrl = domain + "/Playground/GetAll?session_id={CHECKOUT_SESSION_ID}",
                CancelUrl = domain + "/Checkout/Cancel"
            };

            var service = new SessionService();
            Session session = service.Create(options);

            return Redirect(session.Url);
        }






        public IActionResult Success() => RedirectToAction("Playground","GetAll");
        public IActionResult Cancel() => View();
    }
}

