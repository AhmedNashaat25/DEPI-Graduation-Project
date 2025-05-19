using CurvaHagz.Data.App;
using CurvaHagz.Models.App;
using CurvaHAgz.Web.App.Helper;
using CurvaHAgz.Web.App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CurvaHAgz.Web.App.Controllers
{
    public class CartController : Controller
    {
        private readonly CurvaHagzContext _context;

        public CartController(CurvaHagzContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var cart = WorkingWithSession.GetObjectFromJson<List<SelectedBooking>>(HttpContext.Session, "cart") ?? new List<SelectedBooking>();

            // Load playgrounds from DB based on IDs stored in cart
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
            ViewBag.total = viewModel.Sum(item => item.PlayGround.HourlyPrice * item.Duration);

            return View();
        }

        public async Task<IActionResult> Buy(int id)
        {
            var playground = await _context.playGrounds
                                           .AsNoTracking()
                                           .FirstOrDefaultAsync(m => m.PlaygroundId == id);

            if (playground == null)
            {
                return NotFound();
            }

            var cart = WorkingWithSession.GetObjectFromJson<List<SelectedBooking>>(HttpContext.Session, "cart") ?? new List<SelectedBooking>();
            int index = IsExist(cart, id);

            if (index != -1)
            {
                cart[index].Duration++;
            }
            else
            {
                cart.Add(new SelectedBooking { PlayGroundId = id, Duration = 1 });
            }

            WorkingWithSession.SetObjectasJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("Index");
        }

        private int IsExist(List<SelectedBooking> cart, int id)
        {
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].PlayGroundId == id)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
